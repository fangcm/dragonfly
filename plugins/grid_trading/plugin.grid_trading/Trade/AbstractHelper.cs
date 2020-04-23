using System;
using System.Text;
using System.Runtime.InteropServices;
using Dragonfly.Common.Utils;
using System.Diagnostics;
using System.Collections.Generic;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    public abstract class AbstractTrader
    {
        protected uint processId;  // 主线程
        protected IntPtr hMainWnd;    // 主窗口句柄

        private IntPtr hProcess = IntPtr.Zero;
        private const int dwBufferSize = 1024;
        private IntPtr lpRemoteBuffer = IntPtr.Zero;
        private IntPtr lpLocalBuffer = IntPtr.Zero;

        ~AbstractTrader()
        {
            Close();
        }

        internal void Log(Utils.LoggType type, string msg)
        {
            Utils.LoggerUtil.Log(type, msg);
        }

        public bool Init(string appName)
        {
            Close();

            hMainWnd = FindWindow(null, appName);
            if (hMainWnd == IntPtr.Zero)
                throw new ApplicationException("Failed to FindWindow: " + appName);

            const int SW_RESTORE = 9;
            Interop.ShowWindow(hMainWnd, SW_RESTORE);

            Interop.GetWindowThreadProcessId(hMainWnd, out processId);

            // allocate buffer in local process
            lpLocalBuffer = Marshal.AllocHGlobal(dwBufferSize);
            if (lpLocalBuffer == IntPtr.Zero)
                throw new SystemException("Failed to allocate memory in local process");

            hProcess = Interop.OpenProcess(Interop.PROCESS_ALL_ACCESS, false, processId);
            if (hProcess == IntPtr.Zero)
                throw new ApplicationException("Failed to access process");

            // Allocate a buffer in the remote process
            lpRemoteBuffer = Interop.VirtualAllocEx(hProcess, IntPtr.Zero, dwBufferSize, Interop.MEM_COMMIT, Interop.PAGE_READWRITE);
            if (lpRemoteBuffer == IntPtr.Zero)
                throw new SystemException("Failed to allocate memory in remote process");

            return true;
        }

        protected void Close()
        {
            if (lpLocalBuffer != IntPtr.Zero)
                Marshal.FreeHGlobal(lpLocalBuffer);
            if (lpRemoteBuffer != IntPtr.Zero)
                Interop.VirtualFreeEx(hProcess, lpRemoteBuffer, 0, Interop.MEM_RELEASE);
            if (hProcess != IntPtr.Zero)
                Interop.CloseHandle(hProcess);
        }



        protected void SelectTreeViewItem(IntPtr hTree, IntPtr hItem)
        {
            SendMessage(hTree, TVM_SELECTITEM, TVGN_CARET, hItem);
            /*
            RECT[] rec = new RECT[1];
            if (GetTreeViewItemRECT(hTree, hItem, ref rec))
            {
                RECT itemrect = rec[0];
                int fixedx = 20;
                int fixedy = 10;
                SendMouseClick(hTree, itemrect.left + fixedx, itemrect.top + fixedy);
            }
            */
        }

        protected string GetTreeViewItemTextEx(IntPtr wndTreeView, IntPtr item)
        {
            List<string> outS = new List<string>(); 
            bool ret = SysTreeView32.GetTreeViewText(wndTreeView,outS);
            return "";
        }

        protected string GetTreeViewItemTextEx1(IntPtr wndTreeView, IntPtr item)
        {
            const int TVIF_TEXT = 0x0001;
            const int MAX_TVITEMTEXT = 512;

            Interop.TVITEM tvi = new Interop.TVITEM();
            tvi.mask = TVIF_TEXT;
            tvi.hItem = item;
            tvi.cchTextMax = MAX_TVITEMTEXT;
            // set address to remote buffer immediately following the tvItem
            tvi.pszText = (IntPtr)(lpRemoteBuffer.ToInt64() + Marshal.SizeOf(typeof(Interop.TVITEM)));

            // copy local tvItem to remote buffer
            bool bSuccess = Interop.WriteProcessMemory(hProcess, lpRemoteBuffer, ref tvi, Marshal.SizeOf(typeof(Interop.TVITEM)), IntPtr.Zero);
            if (!bSuccess)
                throw new SystemException("Failed to write to process memory");

            bool res = Interop.SendMessage(wndTreeView, Interop.TVM.GETITEMW, 0, lpRemoteBuffer);

            // copy tvItem back into local buffer (copy whole buffer because we don't yet know how big the string is)
            bSuccess = Interop.ReadProcessMemory(hProcess, lpRemoteBuffer, lpLocalBuffer, dwBufferSize, IntPtr.Zero);
            if (!bSuccess)
                throw new SystemException("Failed to read from process memory");

            return Marshal.PtrToStringAnsi((IntPtr)(lpLocalBuffer.ToInt64() + Marshal.SizeOf(typeof(Interop.TVITEM))));

        }

        protected IntPtr FindTreeViewItem(IntPtr wndTreeView,  IntPtr itemParent, string nodeCaption)
        {
            IntPtr itemChild = Interop.SendMessage(wndTreeView, Interop.TVM.GETNEXTITEM, Interop.TVGN.CHILD, itemParent);
            while (itemChild != IntPtr.Zero)
            {
                if (string.Compare(GetTreeViewItemTextEx(wndTreeView, itemChild), nodeCaption, true) == 0)
                {
                    return itemChild;
                }
                itemChild = Interop.SendMessage(wndTreeView, Interop.TVM.GETNEXTITEM, Interop.TVGN.NEXT, itemChild);
            }
            Debug.WriteLine(string.Format("key '{0}' not found!", nodeCaption));
            return IntPtr.Zero;
        }

        private string GetListViewItemText(IntPtr wndListView, int item)
        {
            const int LVM_GETITEM = 0x1005;
            const int LVIF_TEXT = 0x0001;

            Interop.LVITEM lvItem = new Interop.LVITEM();
            lvItem.mask = LVIF_TEXT;
            lvItem.iItem = item;
            lvItem.iSubItem = 0;
            // set address to remote buffer immediately following the lvItem 
            lvItem.pszText = (IntPtr)(lpRemoteBuffer.ToInt64() + Marshal.SizeOf(typeof(Interop.LVITEM)));
            lvItem.cchTextMax = 50;

            // copy local lvItem to remote buffer
            bool bSuccess = Interop.WriteProcessMemory(hProcess, lpRemoteBuffer, ref lvItem, Marshal.SizeOf(typeof(Interop.LVITEM)), IntPtr.Zero);
            if (!bSuccess)
                throw new SystemException("Failed to write to process memory");

            // Send the message to the remote window with the address of the remote buffer
            bSuccess = Interop.SendMessage(wndListView, LVM_GETITEM, 0, lpRemoteBuffer);
            if (!bSuccess)
                return null;

            // copy lvItem back into local buffer (copy whole buffer because we don't yet know how big the string is)
            bSuccess = Interop.ReadProcessMemory(hProcess, lpRemoteBuffer, lpLocalBuffer, dwBufferSize, IntPtr.Zero);
            if (!bSuccess)
                throw new SystemException("Failed to read from process memory");

            return Marshal.PtrToStringAnsi((IntPtr)(lpLocalBuffer.ToInt64() + Marshal.SizeOf(typeof(Interop.LVITEM))));
        }


        #region common

        protected IntPtr FindHwndInApp(string lpClassName, string lpWindowName)
        {
            WindowFinder finder = new WindowFinder(hMainWnd, lpClassName, lpWindowName);
            return finder.FoundHandle;
        }

        protected IntPtr GetHwnd(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName)
        {
            IntPtr handle = FindWindowEx(hwndParent, hwndChildAfter, lpClassName, lpWindowName);
            if (handle != IntPtr.Zero)
            {
                return handle;
            }
            else
            {
                throw new Exception("failed to get handle");
            }
        }

        protected bool GetTreeViewItemRECT(IntPtr treeViewHandle, IntPtr treeItemHandle, ref RECT[] rect)
        {
            bool result = false;
            int processId;
            GetWindowThreadProcessId(treeViewHandle, out processId);
            IntPtr process = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, false, processId);
            IntPtr buffer = VirtualAllocEx(process, 0, 4096, MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);
            try
            {
                uint bytes = 0;
                WriteProcessMemory(process, buffer, ref treeItemHandle, Marshal.SizeOf(treeItemHandle), ref bytes);
                SendMessage(treeViewHandle, TVM_GETITEMRECT, 1, buffer);
                ReadProcessMemory(process, buffer, Marshal.UnsafeAddrOfPinnedArrayElement(rect, 0), Marshal.SizeOf(typeof(RECT)), ref bytes);
                result = true;
            }
            finally
            {
                VirtualFreeEx(process, buffer, 0, MEM_RELEASE);
                CloseHandle(process);
            }
            return result;
        }

        public static void ClickButton(IntPtr handle)
        {
            SendMessage(handle, (int)BM_CLICK, 0, 0);
        }

        public static void SendMouseClick(IntPtr handle, int x, int y)
        {

            SendMessage(handle, WM_LBUTTONDOWN, 0x00000001, MAKELPARAM(x, y));
            SendMessage(handle, WM_LBUTTONUP, 0x00000000, MAKELPARAM(x, y));

        }

        protected void MouseClickScreen(int x, int y)
        {
            POINT p = new POINT();
            GetCursorPos(out p);

            try
            {
                ShowCursor(false);
                SetCursorPos(x, y);

                mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
                mouse_event((int)(MouseEventFlags.LeftUp | MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);

                System.Threading.Thread.Sleep(2000);
            }
            finally
            {
                SetCursorPos(p.X, p.Y);
                ShowCursor(true);
            }
        }

        public static int MAKELPARAM(int x, int y)
        {
            return ((y << 16) | (x & 0xFFFF));
        }

        #endregion common

        #region Win32

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

        private const uint WM_GETTEXTLENGTH = 0x000E;
        private const uint WM_SETTEXT = 0x000C;
        private const uint WM_GETTEXT = 0x000D;
        private const uint BM_CLICK = 0x00F5;
        private const uint WM_CLOSE = 0x0010;

        enum GetWindow_Cmd : uint { GW_HWNDFIRST = 0, GW_HWNDLAST = 1, GW_HWNDNEXT = 2, GW_HWNDPREV = 3, GW_OWNER = 4, GW_CHILD = 5, GW_ENABLEDPOPUP = 6 }

        private const int TV_FIRST = 0x1100;
        private const int TVGN_ROOT = 0x0;
        private const int TVGN_NEXT = 0x1;
        private const int TVGN_CHILD = 0x4;
        private const int TVGN_FIRSTVISIBLE = 0x5;
        private const int TVGN_NEXTVISIBLE = 0x6;
        private const int TVGN_CARET = 0x9;
        private const int TVM_SELECTITEM = (TV_FIRST + 11);
        private const int TVM_GETNEXTITEM = (TV_FIRST + 10);
        private const int TVM_GETITEM = (TV_FIRST + 12);
        private const int TV_SELECTITEM = 0x110B;
        private const int TVM_GETITEMRECT = (TV_FIRST + 4);

        private const int LVM_GETITEMRECT = (0x1000 + 14);

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

        const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_VM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;

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

        const int MEM_COMMIT = 0x1000;
        const int MEM_RESERVE = 0x2000;
        const int MEM_RELEASE = 0x8000;
        const int PAGE_READWRITE = 0x04;

        [DllImport("kernel32.dll")]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, uint nSize, ref uint lpNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint dwFreeType);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr handle);

        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int MK_LBUTTON = 0x1;

        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        static extern IntPtr SetActiveWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

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
        private struct LVITEM
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

        private const int LVIF_TEXT = 0x0001;

        private const int LVM_FIRST = 0x1000;
        private const int LVM_GETITEMCOUNT = LVM_FIRST + 4;
        private const int LVM_GETITEMW = LVM_FIRST + 75;

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        static extern IntPtr GetWindowLong32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        static extern IntPtr GetWindowLong64(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        static extern IntPtr SetWindowLong32(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        static extern IntPtr SetWindowLong64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

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




        protected class Interop
        {

            #region structs

            /// <summary>
            /// from 'http://dotnetjunkies.com/WebLog/chris.taylor/'
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct LVITEM
            {
                public uint mask;
                public int iItem;
                public int iSubItem;
                public uint state;
                public uint stateMask;
                public IntPtr pszText;
                public int cchTextMax;
                public int iImage;
            }

            /// <summary>
            /// from '.\PlatformSDK\Include\commctrl.h'
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            internal struct TVITEM
            {
                public uint mask;
                public IntPtr hItem;
                public uint state;
                public uint stateMask;
                public IntPtr pszText;
                public int cchTextMax;
                public uint iImage;
                public uint iSelectedImage;
                public uint cChildren;
                public IntPtr lParam;
            }
            #endregion


            [DllImport("user32.dll")]
            internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            internal static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

            [DllImport("kernel32")]
            internal static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

            [DllImport("user32.dll")]
            internal static extern uint WaitForInputIdle(IntPtr hProcess, uint dwMilliseconds);

            [DllImport("kernel32")]
            internal static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, uint flAllocationType, uint flProtect);

            [DllImport("kernel32")]
            internal static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, uint dwFreeType);

            [DllImport("kernel32")]
            internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref LVITEM buffer, int dwSize, IntPtr lpNumberOfBytesWritten);

            [DllImport("kernel32")]
            internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref TVITEM buffer, int dwSize, IntPtr lpNumberOfBytesWritten);

            [DllImport("kernel32")]
            internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, IntPtr lpNumberOfBytesRead);

            [DllImport("kernel32")]
            internal static extern bool CloseHandle(IntPtr hObject);


            internal const uint PROCESS_ALL_ACCESS = (uint)(0x000F0000L | 0x00100000L | 0xFFF);
            internal const uint MEM_COMMIT = 0x1000;
            internal const uint MEM_RELEASE = 0x8000;
            internal const uint PAGE_READWRITE = 0x04;



            /// <summary>
            /// from '.\PlatformSDK\Include\WinUser.h'
            /// </summary>
            internal enum WM : int
            {
                NULL = 0x0000,
                CREATE = 0x0001,
                DESTROY = 0x0002,
                MOVE = 0x0003,
                SIZE = 0x0005,
                ACTIVATE = 0x0006,
                SETFOCUS = 0x0007,
                KILLFOCUS = 0x0008,
                ENABLE = 0x000A,
                SETREDRAW = 0x000B,
                SETTEXT = 0x000C,
                GETTEXT = 0x000D,
                GETTEXTLENGTH = 0x000E,
                PAINT = 0x000F,
                CLOSE = 0x0010,
                QUERYENDSESSION = 0x0011,
                QUIT = 0x0012,
                QUERYOPEN = 0x0013,
                ERASEBKGND = 0x0014,
                SYSCOLORCHANGE = 0x0015,
                ENDSESSION = 0x0016,
                SHOWWINDOW = 0x0018,
                CTLCOLOR = 0x0019,
                WININICHANGE = 0x001A,
                SETTINGCHANGE = 0x001A,
                DEVMODECHANGE = 0x001B,
                ACTIVATEAPP = 0x001C,
                FONTCHANGE = 0x001D,
                TIMECHANGE = 0x001E,
                CANCELMODE = 0x001F,
                SETCURSOR = 0x0020,
                MOUSEACTIVATE = 0x0021,
                CHILDACTIVATE = 0x0022,
                QUEUESYNC = 0x0023,
                GETMINMAXINFO = 0x0024,
                PAINTICON = 0x0026,
                ICONERASEBKGND = 0x0027,
                NEXTDLGCTL = 0x0028,
                SPOOLERSTATUS = 0x002A,
                DRAWITEM = 0x002B,
                MEASUREITEM = 0x002C,
                DELETEITEM = 0x002D,
                VKEYTOITEM = 0x002E,
                CHARTOITEM = 0x002F,
                SETFONT = 0x0030,
                GETFONT = 0x0031,
                SETHOTKEY = 0x0032,
                GETHOTKEY = 0x0033,
                QUERYDRAGICON = 0x0037,
                COMPAREITEM = 0x0039,
                GETOBJECT = 0x003D,
                COMPACTING = 0x0041,
                COMMNOTIFY = 0x0044,
                WINDOWPOSCHANGING = 0x0046,
                WINDOWPOSCHANGED = 0x0047,
                POWER = 0x0048,
                COPYDATA = 0x004A,
                CANCELJOURNAL = 0x004B,
                NOTIFY = 0x004E,
                INPUTLANGCHANGEREQUEST = 0x0050,
                INPUTLANGCHANGE = 0x0051,
                TCARD = 0x0052,
                HELP = 0x0053,
                USERCHANGED = 0x0054,
                NOTIFYFORMAT = 0x0055,
                CONTEXTMENU = 0x007B,
                STYLECHANGING = 0x007C,
                STYLECHANGED = 0x007D,
                DISPLAYCHANGE = 0x007E,
                GETICON = 0x007F,
                SETICON = 0x0080,
                NCCREATE = 0x0081,
                NCDESTROY = 0x0082,
                NCCALCSIZE = 0x0083,
                NCHITTEST = 0x0084,
                NCPAINT = 0x0085,
                NCACTIVATE = 0x0086,
                GETDLGCODE = 0x0087,
                SYNCPAINT = 0x0088,
                NCMOUSEMOVE = 0x00A0,
                NCLBUTTONDOWN = 0x00A1,
                NCLBUTTONUP = 0x00A2,
                NCLBUTTONDBLCLK = 0x00A3,
                NCRBUTTONDOWN = 0x00A4,
                NCRBUTTONUP = 0x00A5,
                NCRBUTTONDBLCLK = 0x00A6,
                NCMBUTTONDOWN = 0x00A7,
                NCMBUTTONUP = 0x00A8,
                NCMBUTTONDBLCLK = 0x00A9,
                KEYDOWN = 0x0100,
                KEYUP = 0x0101,
                CHAR = 0x0102,
                DEADCHAR = 0x0103,
                SYSKEYDOWN = 0x0104,
                SYSKEYUP = 0x0105,
                SYSCHAR = 0x0106,
                SYSDEADCHAR = 0x0107,
                KEYLAST = 0x0108,
                IME_STARTCOMPOSITION = 0x010D,
                IME_ENDCOMPOSITION = 0x010E,
                IME_COMPOSITION = 0x010F,
                IME_KEYLAST = 0x010F,
                INITDIALOG = 0x0110,
                COMMAND = 0x0111,
                SYSCOMMAND = 0x0112,
                TIMER = 0x0113,
                HSCROLL = 0x0114,
                VSCROLL = 0x0115,
                INITMENU = 0x0116,
                INITMENUPOPUP = 0x0117,
                MENUSELECT = 0x011F,
                MENUCHAR = 0x0120,
                ENTERIDLE = 0x0121,
                MENURBUTTONUP = 0x0122,
                MENUDRAG = 0x0123,
                MENUGETOBJECT = 0x0124,
                UNINITMENUPOPUP = 0x0125,
                MENUCOMMAND = 0x0126,
                CHANGEUISTATE = 0x0127,
                UPDATEUISTATE = 0x0128,
                QUERYUISTATE = 0x0129,
                CTLCOLORMSGBOX = 0x0132,
                CTLCOLOREDIT = 0x0133,
                CTLCOLORLISTBOX = 0x0134,
                CTLCOLORBTN = 0x0135,
                CTLCOLORDLG = 0x0136,
                CTLCOLORSCROLLBAR = 0x0137,
                CTLCOLORSTATIC = 0x0138,
                MOUSEMOVE = 0x0200,
                LBUTTONDOWN = 0x0201,
                LBUTTONUP = 0x0202,
                LBUTTONDBLCLK = 0x0203,
                RBUTTONDOWN = 0x0204,
                RBUTTONUP = 0x0205,
                RBUTTONDBLCLK = 0x0206,
                MBUTTONDOWN = 0x0207,
                MBUTTONUP = 0x0208,
                MBUTTONDBLCLK = 0x0209,
                MOUSEWHEEL = 0x020A,
                PARENTNOTIFY = 0x0210,
                ENTERMENULOOP = 0x0211,
                EXITMENULOOP = 0x0212,
                NEXTMENU = 0x0213,
                SIZING = 0x0214,
                CAPTURECHANGED = 0x0215,
                MOVING = 0x0216,
                DEVICECHANGE = 0x0219,
                MDICREATE = 0x0220,
                MDIDESTROY = 0x0221,
                MDIACTIVATE = 0x0222,
                MDIRESTORE = 0x0223,
                MDINEXT = 0x0224,
                MDIMAXIMIZE = 0x0225,
                MDITILE = 0x0226,
                MDICASCADE = 0x0227,
                MDIICONARRANGE = 0x0228,
                MDIGETACTIVE = 0x0229,
                MDISETMENU = 0x0230,
                ENTERSIZEMOVE = 0x0231,
                EXITSIZEMOVE = 0x0232,
                DROPFILES = 0x0233,
                MDIREFRESHMENU = 0x0234,
                IME_SETCONTEXT = 0x0281,
                IME_NOTIFY = 0x0282,
                IME_CONTROL = 0x0283,
                IME_COMPOSITIONFULL = 0x0284,
                IME_SELECT = 0x0285,
                IME_CHAR = 0x0286,
                IME_REQUEST = 0x0288,
                IME_KEYDOWN = 0x0290,
                IME_KEYUP = 0x0291,
                MOUSEHOVER = 0x02A1,
                MOUSELEAVE = 0x02A3,
                CUT = 0x0300,
                COPY = 0x0301,
                PASTE = 0x0302,
                CLEAR = 0x0303,
                UNDO = 0x0304,
                RENDERFORMAT = 0x0305,
                RENDERALLFORMATS = 0x0306,
                DESTROYCLIPBOARD = 0x0307,
                DRAWCLIPBOARD = 0x0308,
                PAINTCLIPBOARD = 0x0309,
                VSCROLLCLIPBOARD = 0x030A,
                SIZECLIPBOARD = 0x030B,
                ASKCBFORMATNAME = 0x030C,
                CHANGECBCHAIN = 0x030D,
                HSCROLLCLIPBOARD = 0x030E,
                QUERYNEWPALETTE = 0x030F,
                PALETTEISCHANGING = 0x0310,
                PALETTECHANGED = 0x0311,
                HOTKEY = 0x0312,
                PRINT = 0x0317,
                PRINTCLIENT = 0x0318,
                HANDHELDFIRST = 0x0358,
                HANDHELDLAST = 0x035F,
                AFXFIRST = 0x0360,
                AFXLAST = 0x037F,
                PENWINFIRST = 0x0380,
                PENWINLAST = 0x038F,
                APP = 0x8000,
                USER = 0x0400,
            }

            /// <summary>
            /// from '.\PlatformSDK\Include\CommCtrl.h'
            /// </summary>
            internal enum Base : int
            {
                LVM = 0x1000,
                TV = 0x1100,
                HDM = 0x1200,
                TCM = 0x1300,
                PGM = 0x1400,
                ECM = 0x1500,
                BCM = 0x1600,
                CBM = 0x1700,
                CCM = 0x2000,
                NM = 0x0000,
                LVN = NM - 100,
                HDN = NM - 300,
                EM = 0x400,
            }



            /// <summary>
            /// from '.\PlatformSDK\Include\CommCtrl.h'
            /// </summary>
            internal enum TVM : int
            {
                FIRST = Base.TV,
                INSERTITEMA = FIRST + 0,
                DELETEITEM = FIRST + 1,
                EXPAND = FIRST + 2,
                GETITEMRECT = FIRST + 4,
                GETCOUNT = FIRST + 5,
                GETINDENT = FIRST + 6,
                SETINDENT = FIRST + 7,
                GETIMAGELIST = FIRST + 8,
                SETIMAGELIST = FIRST + 9,
                GETNEXTITEM = FIRST + 10,
                SELECTITEM = FIRST + 11,
                GETITEMA = FIRST + 12,
                SETITEMA = FIRST + 13,
                EDITLABELA = FIRST + 14,
                GETEDITCONTROL = FIRST + 15,
                GETVISIBLECOUNT = FIRST + 16,
                HITTEST = FIRST + 17,
                CREATEDRAGIMAGE = FIRST + 18,
                SORTCHILDREN = FIRST + 19,
                ENSUREVISIBLE = FIRST + 20,
                SORTCHILDRENCB = FIRST + 21,
                ENDEDITLABELNOW = FIRST + 22,
                GETISEARCHSTRINGA = FIRST + 23,
                SETTOOLTIPS = FIRST + 24,
                GETTOOLTIPS = FIRST + 25,
                SETINSERTMARK = FIRST + 26,
                SETITEMHEIGHT = FIRST + 27,
                GETITEMHEIGHT = FIRST + 28,
                SETBKCOLOR = FIRST + 29,
                SETTEXTCOLOR = FIRST + 30,
                GETBKCOLOR = FIRST + 31,
                GETTEXTCOLOR = FIRST + 32,
                SETSCROLLTIME = FIRST + 33,
                GETSCROLLTIME = FIRST + 34,
                SETINSERTMARKCOLOR = FIRST + 37,
                GETINSERTMARKCOLOR = FIRST + 38,
                GETITEMSTATE = FIRST + 39,
                SETLINECOLOR = FIRST + 40,
                GETLINECOLOR = FIRST + 41,
                MAPACCIDTOHTREEITEM = FIRST + 42,
                MAPHTREEITEMTOACCID = FIRST + 43,
                INSERTITEMW = FIRST + 50,
                GETITEMW = FIRST + 62,
                SETITEMW = FIRST + 63,
                GETISEARCHSTRINGW = FIRST + 64,
                EDITLABELW = FIRST + 65
            }

            internal enum TVE : int
            {
                COLLAPSE = 0x0001,
                EXPAND = 0x0002,
                TOGGLE = 0x0003,
                EXPANDPARTIAL = 0x4000,
                COLLAPSERESET = 0x8000
            }

            /// <summary>
            /// from '.\PlatformSDK\Include\CommCtrl.h'
            /// </summary>
            internal enum TVGN : int
            {
                ROOT = 0x0000,
                NEXT = 0x0001,
                PREVIOUS = 0x0002,
                PARENT = 0x0003,
                CHILD = 0x0004,
                FIRSTVISIBLE = 0x0005,
                NEXTVISIBLE = 0x0006,
                PREVIOUSVISIBLE = 0x0007,
                DROPHILITE = 0x0008,
                CARET = 0x0009,
                LASTVISIBLE = 0x000A
            }

            [DllImport("user32.dll")]
            internal static extern int SendMessage(IntPtr hWnd, WM msg, int wParam, int lParam);

            [DllImport("user32.dll")]
            internal static extern IntPtr SendMessage(IntPtr hWnd, TVM msg, TVGN wParam, IntPtr lParam);

            [DllImport("user32.dll")]
            internal static extern bool SendMessage(IntPtr hWnd, TVM msg, TVE wParam, IntPtr lParam);

            [DllImport("user32.dll")]
            internal static extern bool SendMessage(IntPtr hWnd, TVM msg, int wParam, IntPtr lParam);

            [DllImport("user32.dll")]
            internal static extern bool BringWindowToTop(IntPtr hWnd);

            [DllImport("user32.dll")]
            internal static extern bool SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, IntPtr lParam);

            [DllImport("user32.dll")]
            internal static extern int SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, Int32 lParam);

            [DllImport("user32.dll")]
            internal static extern int PostMessage(IntPtr hWnd, WM msg, Int32 wParam, Int32 lParam);

            [DllImport("user32.dll")]
            internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        }



        #endregion Win32
    }
}
