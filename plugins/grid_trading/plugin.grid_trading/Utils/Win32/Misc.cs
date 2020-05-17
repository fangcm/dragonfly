using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    static class Misc
    {
        private const int _sendMessageFlags = 0x0001;
        private const int _sendMessageTimeoutValue = 10000;

        internal static IntPtr ProxySendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            IntPtr result;

            IntPtr resultSendMessage = NativeMethods.SendMessageTimeout(hwnd, msg, wParam, lParam, _sendMessageFlags, _sendMessageTimeoutValue, out result);
            int lastWin32Error = Marshal.GetLastWin32Error();

            if (resultSendMessage == IntPtr.Zero)
            {
                EvaluateSendMessageTimeoutError(lastWin32Error);
            }

            return result;
        }

        internal static int ProxySendMessageInt(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            IntPtr result = ProxySendMessage(hwnd, msg, wParam, lParam);
            return unchecked((int)(long)result);
        }

        internal static IntPtr ProxySendMessage(IntPtr hwnd, int msg, IntPtr wParam, StringBuilder sb)
        {
            IntPtr result;

            IntPtr resultSendMessage = NativeMethods.SendMessageTimeout(hwnd, msg, wParam, sb, _sendMessageFlags, _sendMessageTimeoutValue, out result);
            int lastWin32Error = Marshal.GetLastWin32Error();

            if (resultSendMessage == IntPtr.Zero)
            {
                EvaluateSendMessageTimeoutError(lastWin32Error);
            }

            return result;
        }

        internal static int ProxySendMessageInt(IntPtr hwnd, int msg, IntPtr wParam, StringBuilder sb)
        {
            IntPtr result = ProxySendMessage(hwnd, msg, wParam, sb);
            return unchecked((int)(long)result);
        }

        internal static IntPtr ProxySendMessage(IntPtr hwnd, int msg, IntPtr wParam, ref NativeMethods.Win32Rect lParam)
        {
            IntPtr result;

            IntPtr resultSendMessage = NativeMethods.SendMessageTimeout(hwnd, msg, wParam, ref lParam, _sendMessageFlags, _sendMessageTimeoutValue, out result);
            int lastWin32Error = Marshal.GetLastWin32Error();

            if (resultSendMessage == IntPtr.Zero)
            {
                EvaluateSendMessageTimeoutError(lastWin32Error);
            }

            return result;
        }

        internal static IntPtr ProxySendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, bool ignoreTimeout)
        {
            IntPtr result;

            IntPtr resultSendMessage = NativeMethods.SendMessageTimeout(hwnd, msg, wParam, lParam, _sendMessageFlags, _sendMessageTimeoutValue, out result);
            int lastWin32Error = Marshal.GetLastWin32Error();

            if (resultSendMessage == IntPtr.Zero)
            {
                EvaluateSendMessageTimeoutError(lastWin32Error, ignoreTimeout);
            }

            return result;
        }

        internal static IntPtr ProxySendMessage(IntPtr hwnd, int msg, out int wParam, out int lParam)
        {
            IntPtr result;

            IntPtr resultSendMessage = NativeMethods.SendMessageTimeout(hwnd, msg, out wParam, out lParam, _sendMessageFlags, _sendMessageTimeoutValue, out result);
            int lastWin32Error = Marshal.GetLastWin32Error();

            if (resultSendMessage == IntPtr.Zero)
            {
                EvaluateSendMessageTimeoutError(lastWin32Error);
            }

            return result;
        }

        internal static IntPtr ProxySendMessage(IntPtr hwnd, int msg, int wParam, IntPtr lParam)
        {
            return ProxySendMessage(hwnd, msg, new IntPtr(wParam), lParam);
        }

        internal static string ProxyGetText(IntPtr hwnd)
        {
            return ProxyGetText(hwnd, 256);
        }

        internal static string ProxyGetText(IntPtr hwnd, int length)
        {
            // if the length is zero don't bother asking for the text.
            if (length == 0)
            {
                return "";
            }

            // Length passes to SendMessage includes terminating NUL
            StringBuilder str = new StringBuilder(length + 1);

            // Send the message...
            ProxySendMessage(hwnd, NativeMethods.WM_GETTEXT, (IntPtr)str.Capacity, str);

            // We don't try to decifer between a zero length string and an error
            return str.ToString();
        }


        // wrapper for MapWindowPoints
        internal static int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, ref NativeMethods.Win32Rect rect, int cPoints)
        {
            return NativeMethods.MapWindowPoints(hWndFrom, hWndTo, ref rect, cPoints);
        }

        // wrapper for MapWindowPoints
        internal static int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, ref NativeMethods.Win32Point pt, int cPoints)
        {
            return NativeMethods.MapWindowPoints(hWndFrom, hWndTo, ref pt, cPoints);
        }

        internal static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)//毫秒
            {
                Application.DoEvents();
            }
        }

        internal static int MAKELPARAM(int x, int y)
        {
            return ((y << 16) | (x & 0xFFFF));
        }

        internal static bool IsBitSet(int flags, int bit)
        {
            return (flags & bit) == bit;
        }

        #region Exception
        private static void EvaluateSendMessageTimeoutError(int error)
        {
            EvaluateSendMessageTimeoutError(error, false);
        }

        private static void EvaluateSendMessageTimeoutError(int error, bool ignoreTimeout)
        {
            // 1460 This operation returned because the timeout period expired. ERROR_TIMEOUT
            if (error == 0 || error == 1460)
            {
                if (!ignoreTimeout)
                {
                    throw new TimeoutException();
                }
            }
            else
            {
                ThrowWin32ExceptionsIfError(error);
            }
        }

        internal static void ThrowWin32ExceptionsIfError(int errorCode)
        {
            throw new Win32Exception(errorCode);
        }
        #endregion

        #region mouse

        //限制鼠标在屏幕上的一个区域内
        public static void LockMouse(NativeMethods.Win32Rect rect)
        {
            NativeMethods.ClipCursor(ref rect);
        }

        /// 解除鼠标的区域限制
        public static void UnLockMouse()
        {
            NativeMethods.ClipCursor(IntPtr.Zero);
        }

        internal static void MouseClick(IntPtr hwnd, int x, int y)
        {
            NativeMethods.PostMessage(hwnd, NativeMethods.WM_LBUTTONDOWN, IntPtr.Zero, NativeMethods.Util.MAKELPARAM(x, y));
            NativeMethods.PostMessage(hwnd, NativeMethods.WM_LBUTTONUP, IntPtr.Zero, NativeMethods.Util.MAKELPARAM(x, y));
        }

        internal static void MouseClickScreen(int x, int y)
        {
            NativeMethods.Win32Point p = new NativeMethods.Win32Point();
            NativeMethods.GetCursorPos(out p);

            try
            {
                NativeMethods.ShowCursor(false);
                NativeMethods.SetCursorPos(x, y);

                NativeMethods.mouse_event((int)(NativeMethods.MouseEventFlags.LeftDown | NativeMethods.MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
                Delay(10);
                NativeMethods.mouse_event((int)(NativeMethods.MouseEventFlags.LeftUp | NativeMethods.MouseEventFlags.Absolute), 0, 0, 0, IntPtr.Zero);
                Delay(10);
            }
            finally
            {
                NativeMethods.SetCursorPos(p.x, p.y);
                NativeMethods.ShowCursor(true);
            }
        }

        #endregion

        internal static void KeyboardPress(IntPtr handle, string text)
        {
            foreach (char letter in text)
            {
                NativeMethods.PostMessage(handle, NativeMethods.WM_CHAR, new IntPtr(letter), IntPtr.Zero);
                Misc.Delay(100);
            }
        }

        internal static void Press(string text)
        {
            foreach (char letter in text)
            {
                NativeMethods.keybd_event((Keys)letter, 0, 0, 0);
            }
        }

    }
}
