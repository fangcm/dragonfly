using System;
using System.Text;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    internal class WindowEditBox
    {
        internal static void SetText(IntPtr hwnd, string text)
        {
            int result = Misc.ProxySendMessageInt(hwnd, NativeMethods.EM_GETLIMITTEXT, IntPtr.Zero, IntPtr.Zero);
            // A result of -1 means that no limit is set.
            if (result != -1 && result < text.Length)
            {
                throw new InvalidOperationException("字符长度限制");
            }

            // Send the message...
            result = Misc.ProxySendMessageInt(hwnd, NativeMethods.WM_SETTEXT, IntPtr.Zero, new StringBuilder(text));
            if (result != 1)
            {
                throw new InvalidOperationException("发送字符数据错误");
            }
        }

        internal static string GetText(IntPtr hwnd)
        {
            return Misc.ProxyGetText(hwnd);
        }
    }
}
