using System;
using System.Text;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    internal class RichEdit
    {
        internal static string GetText(IntPtr hwnd)
        {
            return Misc.ProxyGetText(hwnd);
        }

        internal static void SetText(IntPtr hwnd, string text)
        {
            int result = Misc.ProxySendMessageInt(hwnd, NativeMethods.EM_GETLIMITTEXT, IntPtr.Zero, IntPtr.Zero);
            if (result < text.Length)
            {
                throw new InvalidOperationException("字符长度限制");
            }

            // Send the message...
            result = Misc.ProxySendMessageInt(hwnd, NativeMethods.WM_SETTEXT, IntPtr.Zero, new StringBuilder(text));
            if (result != 1)
            {
                throw new InvalidOperationException("发送字符数据错误");
            }

            // NativeMethods.SendMessage(handle, NativeMethods.EM_SETSEL, 0, -1);
            // NativeMethods.SendMessage(handle, NativeMethods.EM_REPLACESEL, 1, text);
        }
    }
}
