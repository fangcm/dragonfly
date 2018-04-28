using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Dragonfly.Service
{
    public class ProcessStarter : IDisposable
    {
        private string processPath_ = string.Empty;
        private string processName_ = string.Empty;
        private string arguments_ = string.Empty;
        private WinApi.PROCESS_INFORMATION processInfo_;


        public ProcessStarter()
        {

        }

        public ProcessStarter(string processName, string fullExeName)
        {
            processName_ = processName;
            processPath_ = fullExeName;
        }
        public ProcessStarter(string processName, string fullExeName, string arguments)
        {
            processName_ = processName;
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

        public void Stop()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process current in processes)
            {
                if (current.ProcessName == processName_)
                {
                    current.Kill();
                }
            }
        }

        public int WaitForExit()
        {
            WinApi.WaitForSingleObject(processInfo_.hProcess, WinApi.INFINITE);
            int errorcode = WinApi.GetLastError();
            return errorcode;
        }

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion

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

        public string ProcessName
        {
            get
            {
                return processName_;
            }
            set
            {
                processName_ = value;
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
