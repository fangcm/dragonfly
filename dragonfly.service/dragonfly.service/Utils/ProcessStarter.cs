using System;
using System.Runtime.InteropServices;

namespace Dragonfly.Service
{
    public class ProcessStarter
    {
        private string processPath_ = string.Empty;
        private string arguments_ = string.Empty;
        private WinApi.PROCESS_INFORMATION processInfo_;

        public ProcessStarter()
        {

        }

        public ProcessStarter(string fullExeName)
        {
            processPath_ = fullExeName;
        }
        public ProcessStarter(string fullExeName, string arguments)
        {
            processPath_ = fullExeName;
            arguments_ = arguments;
        }

        public void Run()
        {

            IntPtr primaryToken = WinApi.GetCurrentUserToken();
            if (primaryToken == IntPtr.Zero)
            {
                return;
            }
            WinApi.STARTUPINFO StartupInfo = new WinApi.STARTUPINFO();
            processInfo_ = new WinApi.PROCESS_INFORMATION();
            StartupInfo.cb = Marshal.SizeOf(StartupInfo);

            WinApi.SECURITY_ATTRIBUTES Security1 = new WinApi.SECURITY_ATTRIBUTES();
            WinApi.SECURITY_ATTRIBUTES Security2 = new WinApi.SECURITY_ATTRIBUTES();

            string command = "\"" + processPath_ + "\"";
            if ((arguments_ != null) && (arguments_.Length != 0))
            {
                command += " " + arguments_;
            }

            IntPtr lpEnvironment = IntPtr.Zero;
            bool resultEnv = WinApi.CreateEnvironmentBlock(out lpEnvironment, primaryToken, false);
            if (resultEnv != true)
            {
                int nError = WinApi.GetLastError();
            }

            WinApi.CreateProcessAsUser(primaryToken, null, command, ref Security1, ref Security2, false,
                WinApi.CREATE_NO_WINDOW | WinApi.NORMAL_PRIORITY_CLASS | WinApi.CREATE_UNICODE_ENVIRONMENT,
                lpEnvironment, null, ref StartupInfo, out processInfo_);

            WinApi.DestroyEnvironmentBlock(lpEnvironment);
            WinApi.CloseHandle(primaryToken);
        }

        public string ProcessPath
        {
            get
            {
                return processPath_;
            }
            set
            {
                processPath_ = value;
            }
        }

        public string Arguments
        {
            get
            {
                return arguments_;
            }
            set
            {
                arguments_ = value;
            }
        }
    }
}
