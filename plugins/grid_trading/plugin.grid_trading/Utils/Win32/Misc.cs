using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    static class Misc
    {
        private const int _sendMessageFlags = 0x0001;
        private const int _sendMessageTimeoutValue = 10000;

        internal static int ProxySendMessageInt(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            IntPtr result = ProxySendMessage(hwnd, msg, wParam, lParam);
            return unchecked((int)(long)result);
        }

        internal static IntPtr ProxySendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            IntPtr result;

            IntPtr resultSendMessage = NativeMethods.SendMessageTimeout(hwnd, msg, wParam, lParam, _sendMessageFlags, _sendMessageTimeoutValue, out result);
            int lastWin32Error = Marshal.GetLastWin32Error();

            if (resultSendMessage == IntPtr.Zero)
            {
                return IntPtr.Zero;
            }

            return result;
        }

        internal static IntPtr ProxySendMessage(IntPtr hwnd, int msg, int wParam, IntPtr lParam)
        {
            return ProxySendMessage(hwnd, msg, new IntPtr(wParam), lParam);
        }

        internal static bool GetWindowRect(IntPtr hwnd, ref NativeMethods.Win32Rect rc)
        {
            return NativeMethods.GetWindowRect(hwnd, ref rc);
        }


    }
}
