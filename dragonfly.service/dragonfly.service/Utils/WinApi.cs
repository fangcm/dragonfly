﻿using System;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace Dragonfly.Service
{
    internal class WinApi
    {
        private static uint STANDARD_RIGHTS_REQUIRED = 0x000F0000;
        private static uint STANDARD_RIGHTS_READ = 0x00020000;
        private static uint TOKEN_ASSIGN_PRIMARY = 0x0001;
        private static uint TOKEN_DUPLICATE = 0x0002;
        private static uint TOKEN_IMPERSONATE = 0x0004;
        private static uint TOKEN_QUERY = 0x0008;
        private static uint TOKEN_QUERY_SOURCE = 0x0010;
        private static uint TOKEN_ADJUST_PRIVILEGES = 0x0020;
        private static uint TOKEN_ADJUST_GROUPS = 0x0040;
        private static uint TOKEN_ADJUST_DEFAULT = 0x0080;
        private static uint TOKEN_ADJUST_SESSIONID = 0x0100;
        private static uint TOKEN_READ = (STANDARD_RIGHTS_READ | TOKEN_QUERY);
        private static uint TOKEN_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | TOKEN_ASSIGN_PRIMARY | TOKEN_DUPLICATE | TOKEN_IMPERSONATE | TOKEN_QUERY | TOKEN_QUERY_SOURCE | TOKEN_ADJUST_PRIVILEGES | TOKEN_ADJUST_GROUPS | TOKEN_ADJUST_DEFAULT | TOKEN_ADJUST_SESSIONID);

        internal const uint NORMAL_PRIORITY_CLASS = 0x0020;

        internal const uint CREATE_UNICODE_ENVIRONMENT = 0x00000400;


        private const uint MAX_PATH = 260;

        internal const uint CREATE_NO_WINDOW = 0x08000000;

        internal const uint INFINITE = 0xFFFFFFFF;

        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            public int nLength;
            public IntPtr lpSecurityDescriptor;
            public int bInheritHandle;
        }

        public enum SECURITY_IMPERSONATION_LEVEL
        {
            SecurityAnonymous,
            SecurityIdentification,
            SecurityImpersonation,
            SecurityDelegation
        }

        public enum TOKEN_TYPE
        {
            TokenPrimary = 1,
            TokenImpersonation
        }

        public enum WTS_CONNECTSTATE_CLASS
        {
            WTSActive,
            WTSConnected,
            WTSConnectQuery,
            WTSShadow,
            WTSDisconnected,
            WTSIdle,
            WTSListen,
            WTSReset,
            WTSDown,
            WTSInit
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct STARTUPINFO
        {
            public Int32 cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public Int32 dwX;
            public Int32 dwY;
            public Int32 dwXSize;
            public Int32 dwYSize;
            public Int32 dwXCountChars;
            public Int32 dwYCountChars;
            public Int32 dwFillAttribute;
            public Int32 dwFlags;
            public Int16 wShowWindow;
            public Int16 cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public int dwProcessId;
            public int dwThreadId;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WTS_SESSION_INFO
        {
            public Int32 SessionID;

            [MarshalAs(UnmanagedType.LPStr)]
            public String pWinStationName;

            public WTS_CONNECTSTATE_CLASS State;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern uint WTSGetActiveConsoleSessionId();

        [DllImport("wtsapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool WTSQueryUserToken(int sessionId, out IntPtr tokenHandle);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal extern static bool DuplicateTokenEx(IntPtr existingToken, uint desiredAccess, IntPtr tokenAttributes, SECURITY_IMPERSONATION_LEVEL impersonationLevel, TOKEN_TYPE tokenType, out IntPtr newToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool CreateProcessAsUser(IntPtr token, string applicationName, string commandLine, ref SECURITY_ATTRIBUTES processAttributes, ref SECURITY_ATTRIBUTES threadAttributes, bool inheritHandles, uint creationFlags, IntPtr environment, string currentDirectory, ref STARTUPINFO startupInfo, out PROCESS_INFORMATION processInformation);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool CloseHandle(IntPtr handle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetLastError();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int WaitForSingleObject(IntPtr token, uint timeInterval);

        [DllImport("wtsapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int WTSEnumerateSessions(System.IntPtr hServer, int Reserved, int Version, ref System.IntPtr ppSessionInfo, ref int pCount);

        [DllImport("userenv.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool CreateEnvironmentBlock(out IntPtr lpEnvironment, IntPtr hToken, bool bInherit);

        [DllImport("wtsapi32.dll", ExactSpelling = true, SetLastError = false)]
        static extern void WTSFreeMemory(IntPtr memory);

        [DllImport("userenv.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DestroyEnvironmentBlock(IntPtr lpEnvironment);


        public static string GetCurrentUserApplicationDataFolderPath()
        {
            // Get token of the current user 
            IntPtr currentUserToken = GetCurrentUserToken();
            if (currentUserToken == IntPtr.Zero)
            {
                return string.Empty;
            }
            // Get user ID by the token
            WindowsIdentity currentUserId = new WindowsIdentity(currentUserToken);
            // Perform impersonation 
            WindowsImpersonationContext impersonatedUser = currentUserId.Impersonate();
            // Get path to the "My Documents" 
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // Make everything as it was 
            impersonatedUser.Undo();
            return path;
        }

        public static IntPtr GetCurrentUserToken()
        {
            IntPtr currentToken = IntPtr.Zero;
            IntPtr primaryToken = IntPtr.Zero;
            IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;

            int dwSessionId = 0;
            IntPtr hUserToken = IntPtr.Zero;
            IntPtr hTokenDup = IntPtr.Zero;

            IntPtr pSessionInfo = IntPtr.Zero;
            int dwCount = 0;

            WTSEnumerateSessions(WTS_CURRENT_SERVER_HANDLE, 0, 1, ref pSessionInfo, ref dwCount);

            Int32 dataSize = Marshal.SizeOf(typeof(WTS_SESSION_INFO));
            Int64 current = (Int64)pSessionInfo;
            for (int i = 0; i < dwCount; i++)
            {
                WTS_SESSION_INFO si = (WTS_SESSION_INFO)Marshal.PtrToStructure((IntPtr)current, typeof(WTS_SESSION_INFO));
                if (WTS_CONNECTSTATE_CLASS.WTSActive == si.State)
                {
                    dwSessionId = si.SessionID;
                    break;
                }

                current += dataSize;
            }

            WTSFreeMemory(pSessionInfo);

            bool bRet = WTSQueryUserToken(dwSessionId, out currentToken);
            if (bRet == false)
            {
                return IntPtr.Zero;
            }

            bRet = DuplicateTokenEx(currentToken, TOKEN_ASSIGN_PRIMARY | TOKEN_ALL_ACCESS, IntPtr.Zero, SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, TOKEN_TYPE.TokenPrimary, out primaryToken);
            if (bRet == false)
            {
                return IntPtr.Zero;
            }

            return primaryToken;
        }
         
    }
}
