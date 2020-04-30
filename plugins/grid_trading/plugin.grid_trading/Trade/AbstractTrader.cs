using Dragonfly.Common.Utils;
using Dragonfly.Plugin.GridTrading.Utils;
using Dragonfly.Plugin.GridTrading.Utils.Win32;
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
                if (retHandle == IntPtr.Zero || NativeMethods.IsWindowVisible(retHandle))
                {
                    break;
                }
            } while (retHandle != IntPtr.Zero);

            return retHandle;
        }

        protected IntPtr FindHwndInParentRecursive(IntPtr hParent, string lpClassName, string lpWindowName)
        {
            WindowFinder finder = new WindowFinder(hParent, lpClassName, lpWindowName);
            return finder.FoundHandle;
        }

        protected static IntPtr GetDlgItem(IntPtr hDlg, int nControlID)
        {
            return NativeMethods.GetDlgItem(hDlg, nControlID);
        }

        protected static int GetTreeViewItemCount(IntPtr hTreeView)
        {
            //return NativeMethods.SendMessage(hTreeView, NativeMethods.TVM_GETCOUNT, 0, 0);
            return 0;
        }

        protected void SelectTreeViewItem(IntPtr hTreeView, IntPtr hItem)
        {
            //NativeMethods.SendMessage(hTreeView, NativeMethods.TVM_SELECTITEM, NativeMethods.TVGN_CARET, hItem);
        }

        protected static string GetWindowText(IntPtr hWnd)
        {
            int length = NativeMethods.GetWindowTextLength(hWnd);
            var builder = new StringBuilder(length + 1);
            NativeMethods.GetWindowText(hWnd, builder, builder.Capacity);
            return builder.ToString();
        }

        public static int SetWindowText(IntPtr handle, string text)
        {
            return NativeMethods.SetWindowText(handle, text);
        }

        public static void SetEditText(IntPtr handle, string text)
        {
            // NativeMethods.SendMessage(handle, NativeMethods.WM_SETTEXT, 0, text);
        }

        public static string GetEditText(IntPtr handle)
        {
            StringBuilder data = new StringBuilder(32768);
            // NativeMethods.SendMessage(handle, NativeMethods.WM_GETTEXT, data.Capacity, data);
            return data.ToString();
        }

        public static void SetRichEditText(IntPtr handle, string text)
        {
            // NativeMethods.SendMessage(handle, NativeMethods.EM_SETSEL, 0, -1);
            // NativeMethods.SendMessage(handle, NativeMethods.EM_REPLACESEL, 1, text);
        }

        public static void ClickButton(IntPtr hButton)
        {
            //NativeMethods.PostMessage(hButton, (int)NativeMethods.BM_CLICK, 0, 0);
        }

        public static void MouseClick(IntPtr handle, int x, int y)
        {
            // NativeMethods.SendMessage(handle, NativeMethods.WM_LBUTTONDOWN, 0x00000001, MAKELPARAM(x, y));
            // Delay(5);
            // NativeMethods.SendMessage(handle, NativeMethods.WM_LBUTTONUP, 0x00000000, MAKELPARAM(x, y));
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
