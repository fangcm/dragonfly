using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Dragonfly.Task.Notify.Common
{
    internal enum RestartOptions
    {
        LogOff = 0,
        PowerOff = 8,
        Reboot = 2,
        ShutDown = 1,
        Suspend = -1,
        Hibernate = -2
    }

    internal class RestartUtil
    {
        public static void ExitWindows(RestartOptions how, bool force)
        {
            try
            {
                switch (how)
                {
                    case RestartOptions.Suspend:
                        SuspendSystem(false, force);
                        break;
                    case RestartOptions.Hibernate:
                        SuspendSystem(true, force);
                        break;
                    default:
                        ExitWindows(Convert.ToInt32(how), force);
                        break;
                }
            }
            catch (PrivilegeException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        private static void ExitWindows(int how, bool force)
        {
            EnableToken("SeShutdownPrivilege");
            if (force)
                how = how | EWX_FORCE;
            if (ExitWindowsEx(how, 0) == 0)
                throw new PrivilegeException(FormatError(Marshal.GetLastWin32Error()));
        }

        private static void EnableToken(string privilege)
        {
            if (!CheckEntryPoint("advapi32.dll", "AdjustTokenPrivileges"))
                return;
            IntPtr tokenHandle = IntPtr.Zero;
            LUID privilegeLUID = new LUID();
            TOKEN_PRIVILEGES newPrivileges = new TOKEN_PRIVILEGES();
            TOKEN_PRIVILEGES tokenPrivileges = default(TOKEN_PRIVILEGES);

            if ((OpenProcessToken(Process.GetCurrentProcess().Handle, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref tokenHandle)) == 0)
                throw new PrivilegeException(FormatError(Marshal.GetLastWin32Error()));
            if ((LookupPrivilegeValue("", privilege, ref privilegeLUID)) == 0)
                throw new PrivilegeException(FormatError(Marshal.GetLastWin32Error()));
            tokenPrivileges.PrivilegeCount = 1;
            tokenPrivileges.Privileges.Attributes = SE_PRIVILEGE_ENABLED;
            tokenPrivileges.Privileges.pLuid = privilegeLUID;
            int Size = 4;
            if ((AdjustTokenPrivileges(tokenHandle, 0, ref tokenPrivileges, 4 + (12 * tokenPrivileges.PrivilegeCount), ref newPrivileges, ref Size)) == 0)
                throw new PrivilegeException(FormatError(Marshal.GetLastWin32Error()));
        }

        private static void SuspendSystem(bool hibernate, bool force)
        {
            if (!CheckEntryPoint("powrprof.dll", "SetSuspendState"))
                throw new PlatformNotSupportedException("The SetSuspendState method is not supported on this system!");
            SetSuspendState(Convert.ToInt32((hibernate ? 1 : 0)), Convert.ToInt32((force ? 1 : 0)), 0);
        }
        private static bool CheckEntryPoint(string library, string method)
        {
            IntPtr libPtr = LoadLibrary(library);
            if (!libPtr.Equals(IntPtr.Zero))
            {
                if (!GetProcAddress(libPtr, method).Equals(IntPtr.Zero))
                {
                    FreeLibrary(libPtr);
                    return true;
                }
                FreeLibrary(libPtr);
            }
            return false;
        }
        private static string FormatError(int number)
        {
            StringBuilder Buffer = new StringBuilder(255);
            FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, IntPtr.Zero, number, 0, Buffer, Buffer.Capacity, 0);
            return Buffer.ToString();
        }



        #region Imports


        [StructLayout(LayoutKind.Sequential, Pack = 1)]

        public struct LUID
        {
            public int LowPart;
            public int HighPart;
        }
        public struct LUID_AND_ATTRIBUTES
        {
            public LUID pLuid;
            public int Attributes;
        }

        public struct TOKEN_PRIVILEGES
        {
            public int PrivilegeCount;
            public LUID_AND_ATTRIBUTES Privileges;
        }

        private const int SE_PRIVILEGE_ENABLED = 0x00000002;
        private const int TOKEN_QUERY = 0x00000008;
        private const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        private const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        private const int EWX_LOGOFF = 0x00000000;
        private const int EWX_SHUTDOWN = 0x00000001;
        private const int EWX_REBOOT = 0x00000002;
        private const int EWX_FORCE = 0x00000004;
        private const int EWX_POWEROFF = 0x00000008;
        private const int EWX_FORCEIFHUNG = 0x00000010;
        private const int FORMAT_MESSAGE_FROM_SYSTEM = 0x1000;

        [DllImport("kernel32", EntryPoint = "LoadLibraryA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr LoadLibrary(string lpLibFileName);
        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int FreeLibrary(IntPtr hLibModule);
        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
        [DllImport("Powrprof", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int SetSuspendState(int Hibernate, int ForceCritical, int DisableWakeEvent);
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int OpenProcessToken(IntPtr ProcessHandle, int DesiredAccess, ref IntPtr TokenHandle);
        [DllImport("advapi32.dll", EntryPoint = "LookupPrivilegeValueA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LookupPrivilegeValue(string lpSystemName, string lpName, ref LUID lpLuid);
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int AdjustTokenPrivileges(IntPtr TokenHandle, int DisableAllPrivileges, ref TOKEN_PRIVILEGES NewState, int BufferLength, ref TOKEN_PRIVILEGES PreviousState, ref int ReturnLength);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int ExitWindowsEx(int uFlags, int dwReserved);
        [DllImport("kernel32", EntryPoint = "FormatMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int FormatMessage(int dwFlags, IntPtr lpSource, int dwMessageId, int dwLanguageId, StringBuilder lpBuffer, int nSize, int Arguments);



        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetCurrentProcess();



        #endregion

    }

    internal class PrivilegeException : Exception
    {
        public PrivilegeException()
            : base()
        {
        }
        public PrivilegeException(string message)
            : base(message)
        {
        }
    }
}
