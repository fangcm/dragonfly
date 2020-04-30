using System;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    internal class Button
    {
        internal static void Click(IntPtr hwnd)
        {
            try
            {
                // Now cause the button click.
                Misc.ProxySendMessage(hwnd, NativeMethods.BM_CLICK, IntPtr.Zero, IntPtr.Zero, true);
            }
            catch
            {
            }
        }
    }
}
