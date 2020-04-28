using Dragonfly.Common.Utils;
using Dragonfly.Plugin.GridTrading.Utils;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    public abstract class AbstractTrader
    {
        protected IntPtr hMainWnd;    // 主窗口句柄

        internal void Log(LoggType type, string msg)
        {
            LoggerUtil.Log(type, msg);
        }

        public bool Init(string appClassName, string appName)
        {
            hMainWnd = NativeMethods.FindWindow(appClassName, appName);
            if (hMainWnd == IntPtr.Zero)
                return false;

            return true;
        }

        protected IntPtr FindHwndInApp(string lpClassName, string lpWindowName)
        {
            WindowFinder finder = new WindowFinder(hMainWnd, lpClassName, lpWindowName);
            return finder.FoundHandle;
        }

        protected IntPtr FindHwndInParent(IntPtr hParent, IntPtr hChildAfter, string lpClassName, string lpWindowName)
        {
            return NativeMethods.FindWindowEx(hParent, hChildAfter, lpClassName, lpWindowName);
        }

        protected IntPtr FindHwndInParentRecursive(IntPtr hParent, string lpClassName, string lpWindowName)
        {
            WindowFinder finder = new WindowFinder(hParent, lpClassName, lpWindowName);
            return finder.FoundHandle;
        }

        protected IntPtr FindVisibleHwndInParent(IntPtr hParent, IntPtr hChildAfter, string lpClassName, string lpWindowName)
        {
            IntPtr retHandle = hChildAfter;
            do
            {
                retHandle = NativeMethods.FindWindowEx(hParent, retHandle, lpClassName, lpWindowName);
                int style = (int)NativeMethods.GetWindowLong(retHandle, (int)NativeMethods.WindowLongFlags.GWL_STYLE);

                if ((style & NativeMethods.WS_VISIBLE) != 0)
                {
                    break;
                }
            } while (retHandle != IntPtr.Zero);

            return retHandle;
        }

        protected static int GetTreeViewItemCount(IntPtr hTreeView)
        {
            return NativeMethods.SendMessage(hTreeView, NativeMethods.TVM_GETCOUNT, 0, 0);
        }

        protected void SelectTreeViewItem(IntPtr hTreeView, IntPtr hItem)
        {
            NativeMethods.SendMessage(hTreeView, NativeMethods.TVM_SELECTITEM, NativeMethods.TVGN_CARET, hItem);
        }

        internal static bool GetTreeViewItemRECT(IntPtr hTreeView, IntPtr treeItemHandle, ref NativeMethods.RECT[] rect)
        {
            bool result = false;
            int processId;
            NativeMethods.GetWindowThreadProcessId(hTreeView, out processId);
            IntPtr process = NativeMethods.OpenProcess(NativeMethods.PROCESS_VM_OPERATION | NativeMethods.PROCESS_VM_READ | NativeMethods.PROCESS_VM_WRITE, false, processId);
            IntPtr buffer = NativeMethods.VirtualAllocEx(process, 0, 4096, NativeMethods.MEM_RESERVE | NativeMethods.MEM_COMMIT, NativeMethods.PAGE_READWRITE);
            try
            {
                int bytes;
                NativeMethods.WriteProcessMemory(process, buffer, ref treeItemHandle, Marshal.SizeOf(treeItemHandle), out bytes);
                NativeMethods.SendMessage(hTreeView, NativeMethods.TVM_GETITEMRECT, 1, buffer);
                NativeMethods.ReadProcessMemory(process, buffer, Marshal.UnsafeAddrOfPinnedArrayElement(rect, 0), Marshal.SizeOf(typeof(NativeMethods.RECT)), out bytes);
                result = true;
            }
            finally
            {
                NativeMethods.VirtualFreeEx(process, buffer, 0, NativeMethods.MEM_RELEASE);
                NativeMethods.CloseHandle(process);
            }
            return result;
        }

        public static string GetWindowText(IntPtr hWnd)
        {
            var builder = new StringBuilder();
            return GetWindowText(hWnd, builder);
        }

        public static string GetWindowText(IntPtr hWnd, StringBuilder builder)
        {
            int length = NativeMethods.GetWindowTextLength(hWnd);
            builder.Capacity = Math.Max(builder.Capacity, length + 1);
            NativeMethods.GetWindowText(hWnd, builder, builder.Capacity);
            return builder.ToString();
        }

        public static int SetWindowText(IntPtr handle, string text)
        {
            return NativeMethods.SetWindowText(handle, text);
        }

        public static void SetEditText(IntPtr handle, string text)
        {
            NativeMethods.SendMessage(handle, NativeMethods.WM_SETTEXT, 0, text);
        }

        public static string GetEditText(IntPtr handle)
        {
            StringBuilder data = new StringBuilder(32768);
            NativeMethods.SendMessage(handle, NativeMethods.WM_GETTEXT, data.Capacity, data);
            return data.ToString();
        }

        public static void SetRichEditText(IntPtr handle, string text)
        {
            NativeMethods.SendMessage(handle, NativeMethods.EM_SETSEL, 0, -1);
            NativeMethods.SendMessage(handle, NativeMethods.EM_REPLACESEL, 1, text);
        }

        public static void ClickButton(IntPtr hButton)
        {
            NativeMethods.PostMessage(hButton, (int)NativeMethods.BM_CLICK, 0, 0);
        }

        public static void MouseClick(IntPtr handle, int x, int y)
        {
            NativeMethods.SendMessage(handle, NativeMethods.WM_LBUTTONDOWN, 0x00000001, MAKELPARAM(x, y));
            Delay(5);
            NativeMethods.SendMessage(handle, NativeMethods.WM_LBUTTONUP, 0x00000000, MAKELPARAM(x, y));
        }

        public static void MouseDoubleClick(IntPtr handle, int x, int y)
        {
            NativeMethods.SendMessage(handle, NativeMethods.WM_LBUTTONDBLCLK, 0, MAKELPARAM(x, y));

        }

        public void MouseClickScreen(int x, int y)
        {
            NativeMethods.POINT p = new NativeMethods.POINT();
            NativeMethods.GetCursorPos(out p);

            try
            {
                NativeMethods.ShowCursor(false);
                NativeMethods.SetCursorPos(x, y);

                NativeMethods.mouse_event((int)(NativeMethods.MouseEventFlags.LeftDown | NativeMethods.MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
                Delay(5);
                NativeMethods.mouse_event((int)(NativeMethods.MouseEventFlags.LeftUp | NativeMethods.MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
            }
            finally
            {
                NativeMethods.SetCursorPos(p.X, p.Y);
                NativeMethods.ShowCursor(true);
            }
        }

        public static void KeyboardPress(IntPtr handle, string text)
        {
            foreach (char letter in text)
            {
                NativeMethods.PostMessage(handle, NativeMethods.WM_CHAR, letter, 0);
            }
        }

        public static void Press(string text)
        {
            foreach (char letter in text)
            {
                NativeMethods.keybd_event((Keys)letter, 0, 0, 0);
            }
        }


        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)//毫秒
            {
                Application.DoEvents();
            }
        }

        public static int MAKELPARAM(int x, int y)
        {
            return ((y << 16) | (x & 0xFFFF));
        }



    }
}
