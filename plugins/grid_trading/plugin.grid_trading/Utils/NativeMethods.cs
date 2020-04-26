using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading.Utils
{

    public class NativeMethods
    {
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll", EntryPoint = "FindWindowEx")]
        internal static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        internal static extern bool SendMessage(IntPtr hWnd, int Msg, int wParam, StringBuilder lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        [DllImport("User32.Dll")]
        internal static extern IntPtr PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        internal static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        internal const int WM_GETTEXTLENGTH = 0x000E;
        internal const int WM_SETTEXT = 0x000C;
        internal const int WM_GETTEXT = 0x000D;
        internal const int WM_CLOSE = 0x0010;
        internal const int WM_SETFOCUS = 0x0007;
        internal const int WM_KILLFOCUS = 0x0008;
        internal const int WM_CHAR = 0x0102;
        internal const int WM_LBUTTONDOWN = 0x201;
        internal const int WM_LBUTTONUP = 0x202;
        internal const int WM_LBUTTONDBLCLK = 0x203;
        internal const int WM_PARENTNOTIFY = 0x0210;

        internal const int MK_LBUTTON = 0x1;
        internal const int BM_CLICK = 0x00F5;

        internal enum GetWindow_Cmd : uint { GW_HWNDFIRST = 0, GW_HWNDLAST = 1, GW_HWNDNEXT = 2, GW_HWNDPREV = 3, GW_OWNER = 4, GW_CHILD = 5, GW_ENABLEDPOPUP = 6 }

        internal const int TV_FIRST = 0x1100;
        internal const int TVGN_ROOT = 0x0;
        internal const int TVGN_NEXT = 0x1;
        internal const int TVGN_CHILD = 0x4;
        internal const int TVGN_FIRSTVISIBLE = 0x5;
        internal const int TVGN_NEXTVISIBLE = 0x6;
        internal const int TVGN_CARET = 0x9;
        internal const int TVM_GETCOUNT = TV_FIRST + 5;
        internal const int TVM_SELECTITEM = (TV_FIRST + 11);
        internal const int TVM_GETNEXTITEM = (TV_FIRST + 10);
        internal const int TVM_GETITEM = (TV_FIRST + 12);
        internal const int TV_SELECTITEM = 0x110B;
        internal const int TVM_GETITEMRECT = (TV_FIRST + 4);

        internal const int LVM_GETITEMRECT = (0x1000 + 14);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            internal int left;
            internal int top;
            internal int right;
            internal int bottom;
        }

        [DllImport("kernel32 ", CharSet = CharSet.Unicode)]
        internal static extern int CopyMemory(RECT Destination, IntPtr Source, int Length);

        [DllImport("kernel32.dll")]
        internal static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        internal const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        internal const int PROCESS_VM_OPERATION = 0x0008;
        internal const int PROCESS_VM_READ = 0x0010;
        internal const int PROCESS_VM_WRITE = 0x0020;

        [DllImport("kernel32.dll")]
        internal static extern IntPtr VirtualAllocEx(IntPtr hwnd, Int32 lpaddress, int size, int type, Int32 tect);
        [DllImport("kernel32.dll")]
        internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        internal static extern int GetProcAddress(int hwnd, string lpname);
        [DllImport("kernel32.dll")]
        internal static extern int GetModuleHandleA(string name);
        [DllImport("kernel32.dll")]
        internal static extern IntPtr CreateRemoteThread(IntPtr hwnd, int attrib, int size, int address, int par, int flags, int threadid);
        [DllImport("kernel32.dll")]
        internal static extern Int32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);
        [DllImport("kernel32.dll")]
        internal static extern Boolean VirtualFree(IntPtr lpAddress, Int32 dwSize, Int32 dwFreeType);

        internal const int MEM_COMMIT = 0x1000;
        internal const int MEM_RESERVE = 0x2000;
        internal const int MEM_RELEASE = 0x8000;
        internal const int PAGE_READWRITE = 0x04;

        [DllImport("kernel32.dll")]
        internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, uint nSize, ref uint lpNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        internal static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint dwFreeType);

        [DllImport("kernel32.dll")]
        internal static extern bool CloseHandle(IntPtr handle);

        [DllImport("user32.dll")]
        internal static extern int GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll")]
        internal static extern int SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        internal static extern IntPtr SetActiveWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32")]
        internal extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        [DllImport("User32")]
        internal extern static bool GetCursorPos(out POINT p);

        [DllImport("User32")]
        internal extern static int ShowCursor(bool bShow);

        [Flags]
        internal enum MouseEventFlags
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            Wheel = 0x0800,
            Absolute = 0x8000
        }

        internal enum TodayStatus
        {
            Normal,
            BuyOverFlow,
            SellOverFlow,
            Updated
        }

        internal enum OrderStatus
        {
            Buy,
            Sell,
            All,
            Repeated
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            internal int X;
            internal int Y;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct LVITEM
        {
            internal int mask;
            internal int iItem;
            internal int iSubItem;
            internal int state;
            internal int stateMask;
            internal IntPtr pszText; // string
            internal int cchTextMax;
            internal int iImage;
            internal IntPtr lParam;
            internal int iIndent;
            internal int iGroupId;
            internal int cColumns;
            internal IntPtr puColumns;
        }

        internal const int LVIF_TEXT = 0x0001;

        internal const int LVM_FIRST = 0x1000;
        internal const int LVM_GETITEMCOUNT = LVM_FIRST + 4;
        internal const int LVM_GETITEMW = LVM_FIRST + 75;

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        internal static extern IntPtr GetWindowLong32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        internal static extern IntPtr GetWindowLong64(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        internal static extern IntPtr SetWindowLong32(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        internal static extern IntPtr SetWindowLong64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        internal static IntPtr GetWindowLong(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 8)
            {
                return GetWindowLong64(hWnd, nIndex);
            }
            else
            {
                return GetWindowLong32(hWnd, nIndex);
            }
        }

        internal enum WindowLongFlags : int
        {
            GWL_EXSTYLE = -20,
            GWLP_HINSTANCE = -6,
            GWLP_HWNDPARENT = -8,
            GWL_ID = -12,
            GWL_STYLE = -16,
            GWL_USERDATA = -21,
            GWL_WNDPROC = -4,
            DWLP_USER = 0x8,
            DWLP_MSGRESULT = 0x0,
            DWLP_DLGPROC = 0x4
        }

        internal const long WS_VISIBLE = 0x10000000;

        internal const int EM_SETSEL = 0x00B1;
        internal const int EM_REPLACESEL = 0x00C2;
        internal const int EM_GETSELTEXT = 0x043E;

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int maxCount);
        [DllImport("user32.dll", EntryPoint = "SetWindowText")]
        internal static extern int SetWindowText(IntPtr hwnd, string lpString);
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetParent(IntPtr hwnd);
    }
}
