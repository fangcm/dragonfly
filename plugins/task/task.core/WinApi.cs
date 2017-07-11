using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Dragonfly.Task.Core
{
    internal class WinApi
    {
        public static void ControllingProcess(IntPtr hMainWnd)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                try
                {
                    if (process.ProcessName.ToLower().Trim() == "taskmgr")
                    {
                        process.Kill();
                        break;
                    }
                }
                catch
                {
                    break;
                }
            }

            if (!CheckIsForegroundProcessId())
            {
                MoveToTopMost(hMainWnd);
            }
        }

        public static void MoveToTopMost(IntPtr hWnd)
        {
            SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }

        public static void SetWindowToolwindowAndTopMost(IntPtr hWnd)
        {
            SetWindowLong(hWnd, GWL_EXSTYLE, GetWindowLong(hWnd, GWL_EXSTYLE) | WS_EX_TOPMOST | WS_EX_TOOLWINDOW);
        }

        public static bool CheckIsForegroundProcessId()
        {
            IntPtr foregroundProcessId;
            IntPtr hWnd = GetForegroundWindow();
            if (GetWindowThreadProcessId(hWnd, out foregroundProcessId) != 0)
            {
                IntPtr currentProcessId = new IntPtr(Process.GetCurrentProcess().Id);
                if (foregroundProcessId == currentProcessId)
                {
                    return true;
                }
            }
            return false;
        }

        public const int HWND_TOPMOST = -1;
        public const uint SWP_NOSIZE = 1;
        public const uint SWP_NOMOVE = 2;
        public const uint TOPMOST_FLAGS = SWP_NOSIZE | SWP_NOMOVE;

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, uint wFlags);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out IntPtr lpdwProcessId);

        private const int GWL_EXSTYLE = (-20);
        private const int WS_EX_TOPMOST = 0x00000008;
        private const int WS_EX_TOOLWINDOW = 0x00000080;

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    }
}
