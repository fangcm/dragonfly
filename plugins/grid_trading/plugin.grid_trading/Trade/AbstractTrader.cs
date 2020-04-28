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
            if (hItem == IntPtr.Zero)
                return;
            NativeMethods.SendMessage(hTreeView, NativeMethods.TVM_SELECTITEM, NativeMethods.TVGN_CARET, hItem);
        }

        internal const int MY_MAXLVITEMTEXT = 1024;
        protected IntPtr FindTreeViewItem(IntPtr hTreeView, string sItemName)
        {
            IntPtr foundItem = IntPtr.Zero;
            int processId;
            NativeMethods.GetWindowThreadProcessId(hTreeView, out processId);
            IntPtr process = NativeMethods.OpenProcess(NativeMethods.PROCESS_VM_OPERATION | NativeMethods.PROCESS_VM_READ | NativeMethods.PROCESS_VM_WRITE, false, processId);
            IntPtr buffer = NativeMethods.VirtualAllocEx(process, 0, 4096, NativeMethods.MEM_RESERVE | NativeMethods.MEM_COMMIT, NativeMethods.PAGE_READWRITE);
            try
            {
                IntPtr item = (IntPtr)NativeMethods.SendMessage(hTreeView, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_ROOT, 0);
                while (item != IntPtr.Zero)
                {
                    string itemText = GetTreeViewItemText(hTreeView, item);
                    if (itemText == sItemName)
                    {
                        foundItem = item;
                        break;
                    }

                    item = (IntPtr)NativeMethods.SendMessage(hTreeView, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, item);
                }

            }
            finally
            {
                NativeMethods.VirtualFreeEx(process, buffer, 0, NativeMethods.MEM_RELEASE);
                NativeMethods.CloseHandle(process);
            }



            return foundItem;
        }

        protected static string GetTreeViewItemText(IntPtr hTreeView, IntPtr itemHwnd)
        {
            var result = new StringBuilder(1024);

            int vProcessId;
            NativeMethods.GetWindowThreadProcessId(hTreeView, out vProcessId);
            var vProcess = NativeMethods.OpenProcess(NativeMethods.PROCESS_VM_OPERATION | NativeMethods.PROCESS_VM_READ | NativeMethods.PROCESS_VM_WRITE, false, vProcessId);

            var pStrBufferMemory = NativeMethods.VirtualAllocEx(vProcess, 0, 1024, NativeMethods.MEM_COMMIT, NativeMethods.PAGE_READWRITE);
            var remoteBuffer = NativeMethods.VirtualAllocEx(vProcess, 0, Marshal.SizeOf(typeof(NativeMethods.TVITEM)), NativeMethods.MEM_COMMIT, NativeMethods.PAGE_READWRITE);

            try
            {
                var tvItem = new NativeMethods.TVITEM
                {
                    mask = NativeMethods.TVIF_TEXT,
                    hItem = itemHwnd,
                    pszText = pStrBufferMemory,
                    cchTextMax = 1024
                };

                var localBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(tvItem));
                Marshal.StructureToPtr(tvItem, localBuffer, false);

                int vNumberOfBytesWrite;
                NativeMethods.WriteProcessMemory(vProcess, remoteBuffer, ref localBuffer, Marshal.SizeOf(typeof(NativeMethods.TVITEM)), out vNumberOfBytesWrite);

                NativeMethods.SendMessage(hTreeView, NativeMethods.TVM_GETITEM, 0, remoteBuffer.ToInt32());

                int vNumberOfBytesRead;
                NativeMethods.ReadProcessMemory(vProcess, pStrBufferMemory, result, 1024, out vNumberOfBytesRead);


            }
            finally
            {
                NativeMethods.VirtualFreeEx(vProcess, pStrBufferMemory, 0, NativeMethods.MEM_RELEASE);
                NativeMethods.VirtualFreeEx(vProcess, remoteBuffer, 0, NativeMethods.MEM_RELEASE);
                NativeMethods.CloseHandle(vProcess);
            }

            return result.ToString();
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
