using System;
using System.Text;
using System.Runtime.InteropServices;
using Dragonfly.Common.Utils;


namespace Dragonfly.Plugin.GridTrading.Trade
{
    public abstract class AbstractTrader
    {
        protected IntPtr hMainWnd;    // 主窗口句柄

        internal void Log(Utils.LoggType type, string msg)
        {
            Utils.LoggerUtil.Log(type, msg);
        }

        public bool Init(string appName)
        {
            hMainWnd = Interop.FindWindow(null, appName);
            if (hMainWnd == IntPtr.Zero)
                return false;

            return true;
        }

        protected IntPtr FindHwndInApp(string lpClassName, string lpWindowName)
        {
            WindowFinder finder = new WindowFinder(hMainWnd, lpClassName, lpWindowName);
            return finder.FoundHandle;
        }

        protected IntPtr GetHwnd(IntPtr hParent, IntPtr hChildAfter, string lpClassName, string lpWindowName)
        {
            return Interop.FindWindowEx(hParent, hChildAfter, lpClassName, lpWindowName);
        }

        protected int GetTreeViewItemCount(IntPtr hTreeView)
        {
            return Interop.SendMessage(hTreeView, Interop.TVM_GETCOUNT, 0, 0);
        }

        protected void SelectTreeViewItem(IntPtr hTreeView, IntPtr hItem)
        {
            Interop.SendMessage(hTreeView, Interop.TVM_SELECTITEM, Interop.TVGN_CARET, hItem);

            Interop.RECT[] rec = new Interop.RECT[1];
            if (GetTreeViewItemRECT(hTreeView, hItem, ref rec))
            {
                Interop.RECT itemrect = rec[0];
                int fixedx = 50;
                int fixedy = 10;
                SendMouseClick(hTreeView, itemrect.left + fixedx, itemrect.top + fixedy);
            }

        }


        protected bool GetTreeViewItemRECT(IntPtr hTreeView, IntPtr treeItemHandle, ref Interop.RECT[] rect)
        {
            bool result = false;
            int processId;
            Interop.GetWindowThreadProcessId(hTreeView, out processId);
            IntPtr process = Interop.OpenProcess(Interop.PROCESS_VM_OPERATION | Interop.PROCESS_VM_READ | Interop.PROCESS_VM_WRITE, false, processId);
            IntPtr buffer = Interop.VirtualAllocEx(process, 0, 4096, Interop.MEM_RESERVE | Interop.MEM_COMMIT, Interop.PAGE_READWRITE);
            try
            {
                uint bytes = 0;
                Interop.WriteProcessMemory(process, buffer, ref treeItemHandle, Marshal.SizeOf(treeItemHandle), ref bytes);
                Interop.SendMessage(hTreeView, Interop.TVM_GETITEMRECT, 1, buffer);
                Interop.ReadProcessMemory(process, buffer, Marshal.UnsafeAddrOfPinnedArrayElement(rect, 0), Marshal.SizeOf(typeof(Interop.RECT)), ref bytes);
                result = true;
            }
            finally
            {
                Interop.VirtualFreeEx(process, buffer, 0, Interop.MEM_RELEASE);
                Interop.CloseHandle(process);
            }
            return result;
        }

        public static void ClickButton(IntPtr hButton)
        {
            Interop.SendMessage(hButton, (int)Interop.BM_CLICK, 0, 0);
        }

        public static void SendMouseClick(IntPtr handle, int x, int y)
        {

            Interop.SendMessage(handle, Interop.WM_LBUTTONDOWN, 0x00000001, MAKELPARAM(x, y));
            Interop.SendMessage(handle, Interop.WM_LBUTTONUP, 0x00000000, MAKELPARAM(x, y));

        }

        protected void MouseClickScreen(int x, int y)
        {
            Interop.POINT p = new Interop.POINT();
            Interop.GetCursorPos(out p);

            try
            {
                Interop.ShowCursor(false);
                Interop.SetCursorPos(x, y);

                Interop.mouse_event((int)(Interop.MouseEventFlags.LeftDown | Interop.MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
                Interop.mouse_event((int)(Interop.MouseEventFlags.LeftUp | Interop.MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);

                System.Threading.Thread.Sleep(2000);
            }
            finally
            {
                Interop.SetCursorPos(p.X, p.Y);
                Interop.ShowCursor(true);
            }
        }

        public static int MAKELPARAM(int x, int y)
        {
            return ((y << 16) | (x & 0xFFFF));
        }


        protected class Interop
        {
            [DllImport("User32.dll", EntryPoint = "FindWindow")]
            public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

            [DllImport("User32.dll", EntryPoint = "FindWindowEx")]
            public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
            [DllImport("User32.dll", EntryPoint = "SendMessage")]
            public static extern int SendTxtMessage(int hWnd, int Msg, int wParam, char[] lParam);
            [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
            public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);

            [DllImport("User32.Dll")]
            public static extern IntPtr PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

            public const uint WM_GETTEXTLENGTH = 0x000E;
            public const uint WM_SETTEXT = 0x000C;
            public const uint WM_GETTEXT = 0x000D;
            public const uint BM_CLICK = 0x00F5;
            public const uint WM_CLOSE = 0x0010;

            public enum GetWindow_Cmd : uint { GW_HWNDFIRST = 0, GW_HWNDLAST = 1, GW_HWNDNEXT = 2, GW_HWNDPREV = 3, GW_OWNER = 4, GW_CHILD = 5, GW_ENABLEDPOPUP = 6 }

            public const int TV_FIRST = 0x1100;
            public const int TVGN_ROOT = 0x0;
            public const int TVGN_NEXT = 0x1;
            public const int TVGN_CHILD = 0x4;
            public const int TVGN_FIRSTVISIBLE = 0x5;
            public const int TVGN_NEXTVISIBLE = 0x6;
            public const int TVGN_CARET = 0x9;
            public const int TVM_GETCOUNT = TV_FIRST + 5;
            public const int TVM_SELECTITEM = (TV_FIRST + 11);
            public const int TVM_GETNEXTITEM = (TV_FIRST + 10);
            public const int TVM_GETITEM = (TV_FIRST + 12);
            public const int TV_SELECTITEM = 0x110B;
            public const int TVM_GETITEMRECT = (TV_FIRST + 4);

            public const int LVM_GETITEMRECT = (0x1000 + 14);

            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }

            [DllImport("kernel32 ", CharSet = CharSet.Unicode)]
            public static extern int CopyMemory(RECT Destination, IntPtr Source, int Length);

            [DllImport("kernel32.dll")]
            public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

            public const int PROCESS_ALL_ACCESS = 0x1F0FFF;
            public const int PROCESS_VM_OPERATION = 0x0008;
            public const int PROCESS_VM_READ = 0x0010;
            public const int PROCESS_VM_WRITE = 0x0020;

            [DllImport("kernel32.dll")]
            public static extern IntPtr VirtualAllocEx(IntPtr hwnd, Int32 lpaddress, int size, int type, Int32 tect);
            [DllImport("kernel32.dll")]
            public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);
            [DllImport("kernel32.dll")]
            public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);
            [DllImport("kernel32.dll")]
            public static extern int GetProcAddress(int hwnd, string lpname);
            [DllImport("kernel32.dll")]
            public static extern int GetModuleHandleA(string name);
            [DllImport("kernel32.dll")]
            public static extern IntPtr CreateRemoteThread(IntPtr hwnd, int attrib, int size, int address, int par, int flags, int threadid);
            [DllImport("kernel32.dll")]
            public static extern Int32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);
            [DllImport("kernel32.dll")]
            public static extern Boolean VirtualFree(IntPtr lpAddress, Int32 dwSize, Int32 dwFreeType);

            public const int MEM_COMMIT = 0x1000;
            public const int MEM_RESERVE = 0x2000;
            public const int MEM_RELEASE = 0x8000;
            public const int PAGE_READWRITE = 0x04;

            [DllImport("kernel32.dll")]
            public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, uint nSize, ref uint lpNumberOfBytesRead);
            [DllImport("kernel32.dll")]
            public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);

            [DllImport("kernel32.dll")]
            public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint dwFreeType);

            [DllImport("kernel32.dll")]
            public static extern bool CloseHandle(IntPtr handle);

            public const int WM_LBUTTONDOWN = 0x201;
            public const int WM_LBUTTONUP = 0x202;
            public const int WM_LBUTTONDBLCLK = 0x203;
            public const int MK_LBUTTON = 0x1;

            [DllImport("user32.dll")]
            public static extern int GetWindowRect(IntPtr hwnd, out RECT lpRect);

            [DllImport("user32.dll")]
            public static extern int SetCursorPos(int x, int y);

            [DllImport("user32.dll")]
            public static extern IntPtr SetActiveWindow(IntPtr hWnd);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetForegroundWindow(IntPtr hWnd);

            [DllImport("User32")]
            public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

            [DllImport("User32")]
            public extern static bool GetCursorPos(out POINT p);

            [DllImport("User32")]
            public extern static int ShowCursor(bool bShow);

            [Flags]
            public enum MouseEventFlags
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

            public enum TodayStatus
            {
                Normal,
                BuyOverFlow,
                SellOverFlow,
                Updated
            }

            public enum OrderStatus
            {
                Buy,
                Sell,
                All,
                Repeated
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct POINT
            {
                public int X;
                public int Y;
            }

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            public struct LVITEM
            {
                public int mask;
                public int iItem;
                public int iSubItem;
                public int state;
                public int stateMask;
                public IntPtr pszText; // string
                public int cchTextMax;
                public int iImage;
                public IntPtr lParam;
                public int iIndent;
                public int iGroupId;
                public int cColumns;
                public IntPtr puColumns;
            }

            public const int LVIF_TEXT = 0x0001;

            public const int LVM_FIRST = 0x1000;
            public const int LVM_GETITEMCOUNT = LVM_FIRST + 4;
            public const int LVM_GETITEMW = LVM_FIRST + 75;

            [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
            public static extern IntPtr GetWindowLong32(IntPtr hWnd, int nIndex);

            [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
            public static extern IntPtr GetWindowLong64(IntPtr hWnd, int nIndex);

            [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
            public static extern IntPtr SetWindowLong32(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

            [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
            public static extern IntPtr SetWindowLong64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

            public enum WindowLongFlags : int
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

        }

    }
}
