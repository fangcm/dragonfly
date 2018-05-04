using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;

namespace Dragonfly.Service.Utils
{
    public class ProcessUtils
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct SECURITY_ATTRIBUTES
        {
            public int Length;
            public IntPtr lpSecurityDescriptor;
            public bool bInheritHandle;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct STARTUPINFO
        {
            public int cb;
            public String lpReserved;
            public String lpDesktop;
            public String lpTitle;
            public uint dwX;
            public uint dwY;
            public uint dwXSize;
            public uint dwYSize;
            public uint dwXCountChars;
            public uint dwYCountChars;
            public uint dwFillAttribute;
            public uint dwFlags;
            public short wShowWindow;
            public short cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public uint dwProcessId;
            public uint dwThreadId;
        }

        enum TOKEN_TYPE : int
        {
            TokenPrimary = 1,
            TokenImpersonation = 2
        }

        enum SECURITY_IMPERSONATION_LEVEL : int
        {
            SecurityAnonymous = 0,
            SecurityIdentification = 1,
            SecurityImpersonation = 2,
            SecurityDelegation = 3,
        }

        private const int TOKEN_DUPLICATE = 0x0002;
        private const uint MAXIMUM_ALLOWED = 0x2000000;
        private const int CREATE_NEW_CONSOLE = 0x00000010;

        private const int NORMAL_PRIORITY_CLASS = 0x20;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hSnapshot);

        [DllImport("kernel32.dll")]
        static extern uint WTSGetActiveConsoleSessionId();

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

        [DllImport("advapi32.dll", EntryPoint = "CreateProcessAsUser", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private extern static bool CreateProcessAsUser(IntPtr hToken, String lpApplicationName, String lpCommandLine, ref SECURITY_ATTRIBUTES lpProcessAttributes,
            ref SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandle, int dwCreationFlags, IntPtr lpEnvironment,
            String lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);

        [DllImport("advapi32.dll", SetLastError = true)]
        private extern static bool ImpersonateLoggedOnUser(IntPtr hToken);

        [DllImport("advapi32.dll", SetLastError = true)]
        private extern static bool RevertToSelf();

        [DllImport("advapi32.dll", EntryPoint = "DuplicateTokenEx")]
        private extern static bool DuplicateTokenEx(IntPtr ExistingTokenHandle, uint dwDesiredAccess,
            ref SECURITY_ATTRIBUTES lpThreadAttributes, int TokenType,
            int ImpersonationLevel, ref IntPtr DuplicateTokenHandle);

        [DllImport("advapi32", SetLastError = true), SuppressUnmanagedCodeSecurityAttribute]
        static extern bool OpenProcessToken(IntPtr ProcessHandle, int DesiredAccess, ref IntPtr TokenHandle);

        [DllImport("userenv.dll", SetLastError = true)]
        private extern static bool CreateEnvironmentBlock(ref IntPtr lpEnvironment, IntPtr hToken, bool bInherit);

        [DllImport("userenv.dll", SetLastError = true)]
        private static extern bool DestroyEnvironmentBlock(IntPtr lpEnvironment);

        internal static void StartProcessAndBypassUAC(String applicationName, bool duplicateEnvironmentBlock, out PROCESS_INFORMATION procInfo)
        {
            procInfo = new PROCESS_INFORMATION();

            // obtain the currently active session id; every logged on user in the system has a unique session id
            uint dwSessionId = WTSGetActiveConsoleSessionId();

            // obtain the process id of the winlogon process that is running within the currently active session
            Process[] processes = Process.GetProcessesByName("winlogon");
            uint winlogonPid = 0;
            foreach (Process p in processes)
            {
                if ((uint)p.SessionId == dwSessionId)
                {
                    winlogonPid = (uint)p.Id;
                }
                p.Dispose();
            }
            if (winlogonPid == 0)
            {
                throw new Exception("Cannot find sessionId: " + dwSessionId.ToString());
            }

            // obtain a handle to the winlogon process
            IntPtr hProcess = OpenProcess(MAXIMUM_ALLOWED, false, winlogonPid);

            // obtain a handle to the access token of the winlogon process
            IntPtr hPToken = IntPtr.Zero;
            if (!OpenProcessToken(hProcess, TOKEN_DUPLICATE, ref hPToken))
            {
                CloseHandle(hProcess);
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            // Security attibute structure used in DuplicateTokenEx and CreateProcessAsUser
            // I would prefer to not have to use a security attribute variable and to just 
            // simply pass null and inherit (by default) the security attributes
            // of the existing token. However, in C# structures are value types and therefore
            // cannot be assigned the null value.
            SECURITY_ATTRIBUTES sa = new SECURITY_ATTRIBUTES();
            sa.Length = Marshal.SizeOf(sa);

            IntPtr hUserTokenDup = IntPtr.Zero;
            // copy the access token of the winlogon process; the newly created token will be a primary token
            if (!DuplicateTokenEx(hPToken, MAXIMUM_ALLOWED, ref sa, (int)SECURITY_IMPERSONATION_LEVEL.SecurityIdentification, (int)TOKEN_TYPE.TokenPrimary, ref hUserTokenDup))
            {
                CloseHandle(hPToken);
                CloseHandle(hProcess);
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            IntPtr hEnvBlock = duplicateEnvironmentBlock ? GetEnvironmentBlock(hUserTokenDup) : IntPtr.Zero;

            CloseHandle(hPToken); // no longer needed

            bool impersonated = ImpersonateLoggedOnUser(hUserTokenDup);
            bool result;
            try
            {
                // By default CreateProcessAsUser creates a process on a non-interactive window station, meaning
                // the window station has a desktop that is invisible and the process is incapable of receiving
                // user input. To remedy this we set the lpDesktop parameter to indicate we want to enable user 
                // interaction with the new process.
                STARTUPINFO si = new STARTUPINFO();
                si.cb = (int)Marshal.SizeOf(si);
                si.lpDesktop = @"winsta0\default"; // interactive window station parameter; basically this indicates that the process created can display a GUI on the desktop

                // flags that specify the priority and creation method of the process
                int dwCreationFlags = NORMAL_PRIORITY_CLASS | CREATE_NEW_CONSOLE;

                // create a new process in the current user's logon session
                result = CreateProcessAsUser(hUserTokenDup,        // client's access token
                                                null,                   // file to execute
                                                applicationName,        // command line
                                                ref sa,                 // pointer to process SECURITY_ATTRIBUTES
                                                ref sa,                 // pointer to thread SECURITY_ATTRIBUTES
                                                false,                  // handles are not inheritable
                                                dwCreationFlags,        // creation flags
                                                hEnvBlock,            // pointer to new environment block 
                                                null,                   // name of current directory 
                                                ref si,                 // pointer to STARTUPINFO structure
                                                out procInfo            // receives information about new process
                                                );
            }
            finally
            {
                if (impersonated)
                {
                    RevertToSelf();
                }
            }

            if (hEnvBlock != IntPtr.Zero)
            {
                DestroyEnvironmentBlock(hEnvBlock);
            }

            // invalidate the handles
            CloseHandle(hUserTokenDup);
            CloseHandle(hProcess);

            if (!result)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

        }

        private static IntPtr GetEnvironmentBlock(IntPtr token)
        {

            IntPtr envBlock = IntPtr.Zero;
            bool retVal = CreateEnvironmentBlock(ref envBlock, token, false);
            if (retVal == false)
            {
                //Environment Block, things like common paths to My Documents etc. 
                //Will not be created if "false" 
                //It should not adversley affect CreateProcessAsUser. 
                //string message = String.Format("CreateEnvironmentBlock Error: {0}", Marshal.GetLastWin32Error());
            }

            return envBlock;
        }

    }
}
