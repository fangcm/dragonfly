using Dragonfly.Common.Utils;
using Dragonfly.Plugin.GridTrading.Utils;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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
            hMainWnd = NativeMethods.FindWindow(null, appName);
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

        protected int GetTreeViewItemCount(IntPtr hTreeView)
        {
            return NativeMethods.SendMessage(hTreeView, NativeMethods.TVM_GETCOUNT, 0, 0);
        }

        protected void SelectTreeViewItem(IntPtr hTreeView, IntPtr hItem)
        {
            NativeMethods.SendMessage(hTreeView, NativeMethods.TVM_SELECTITEM, NativeMethods.TVGN_CARET, hItem);

            NativeMethods.RECT[] rec = new NativeMethods.RECT[1];
            if (GetTreeViewItemRECT(hTreeView, hItem, ref rec))
            {
                NativeMethods.RECT itemrect = rec[0];
                int fixedx = 50;
                int fixedy = 10;
                MouseClick(hTreeView, itemrect.left + fixedx, itemrect.top + fixedy);
            }

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
                uint bytes = 0;
                NativeMethods.WriteProcessMemory(process, buffer, ref treeItemHandle, Marshal.SizeOf(treeItemHandle), ref bytes);
                NativeMethods.SendMessage(hTreeView, NativeMethods.TVM_GETITEMRECT, 1, buffer);
                NativeMethods.ReadProcessMemory(process, buffer, Marshal.UnsafeAddrOfPinnedArrayElement(rect, 0), Marshal.SizeOf(typeof(NativeMethods.RECT)), ref bytes);
                result = true;
            }
            finally
            {
                NativeMethods.VirtualFreeEx(process, buffer, 0, NativeMethods.MEM_RELEASE);
                NativeMethods.CloseHandle(process);
            }
            return result;
        }

        public static void KeyboardPress(IntPtr hwnd, string text)
        {
            Keyboard.Press(hwnd, text);
        }

        public static void ClickButton(IntPtr hButton)
        {
            NativeMethods.SendMessage(hButton, (int)NativeMethods.BM_CLICK, 0, 0);
        }

        public static void MouseClick(IntPtr hButton)
        {
            NativeMethods.SendMessage(hButton, NativeMethods.WM_LBUTTONDOWN, 0, 0);
            NativeMethods.SendMessage(hButton, NativeMethods.WM_LBUTTONUP, 0, 0);
        }

        public static void MouseClick(IntPtr handle, int x, int y)
        {
            NativeMethods.SendMessage(handle, NativeMethods.WM_LBUTTONDOWN, 0x00000001, MAKELPARAM(x, y));
            NativeMethods.SendMessage(handle, NativeMethods.WM_LBUTTONUP, 0x00000000, MAKELPARAM(x, y));
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
                NativeMethods.mouse_event((int)(NativeMethods.MouseEventFlags.LeftUp | NativeMethods.MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
            }
            finally
            {
                NativeMethods.SetCursorPos(p.X, p.Y);
                NativeMethods.ShowCursor(true);
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
