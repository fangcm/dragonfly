using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    internal static class UnsafeNativeMethods
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int GetClassName(IntPtr hwnd, StringBuilder className, int maxCount);

        [DllImport("kernel32.dll")]
        internal static extern uint GetCurrentProcessId();
        [DllImport("User32.dll", ExactSpelling = true)]
        internal static extern uint GetWindowThreadProcessId(IntPtr hwnd, out uint dwProcessId);
        [DllImport("User32.dll", ExactSpelling = true)]
        internal static extern bool IsWindow(IntPtr hWnd);
        [DllImport("User32.dll", ExactSpelling = true)]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool CloseHandle(IntPtr h);
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr OpenProcess(int flags, bool inherit, uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr VirtualAlloc(IntPtr address, UIntPtr size, int allocationType, int protect);
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr address, UIntPtr size, int allocationType, int protect);
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool VirtualFree(IntPtr address, UIntPtr size, int freeType);
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr address, UIntPtr size, int freeType);

        internal const int PAGE_NOACCESS = 0x01;
        internal const int PAGE_READWRITE = 0x04;

        internal const int MEM_COMMIT = 0x1000;
        internal const int MEM_RELEASE = 0x8000;
        internal const int MEM_FREE = 0x10000;

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr Source, IntPtr Dest, IntPtr /*SIZE_T*/ size, out IntPtr /*SIZE_T*/ bytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr Source, SafeCoTaskMem destAddress, IntPtr /*SIZE_T*/ size, out IntPtr /*SIZE_T*/ bytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr Dest, IntPtr sourceAddress, IntPtr /*SIZE_T*/ size, out IntPtr /*SIZE_T*/ bytesWritten);

        //
        // Messages and Message Queues Functions
        //
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern IntPtr SendMessageTimeout(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, int flags, int uTimeout, out IntPtr pResult);
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern IntPtr SendMessageTimeout(IntPtr hwnd, int uMsg, IntPtr wParam, StringBuilder lParam, int flags, int uTimeout, out IntPtr result);
        [DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern IntPtr SendMessageTimeout(IntPtr hwnd, int uMsg, out int wParam, out int lParam, int flags, int uTimeout, out IntPtr result);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll", EntryPoint = "FindWindowEx")]
        internal static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        internal static extern int GetDlgCtrlID(IntPtr hwndCtl);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal extern static IntPtr GetDlgItem(IntPtr hDlg, int nControlID);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool GetWindowRect(IntPtr hWnd, [In, Out] ref NativeMethods.Win32Rect rect);

    }
}
