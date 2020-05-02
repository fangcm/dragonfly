using System;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    internal class Button
    {
        internal static void Click(IntPtr hwnd)
        {
            // Now cause the button click.
            NativeMethods.PostMessage(hwnd, NativeMethods.BM_CLICK, IntPtr.Zero, IntPtr.Zero);
        }
    }
}
