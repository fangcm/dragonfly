using System;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    internal class WindowStatic
    {
        internal static string GetText(IntPtr hwnd)
        {
            return Misc.ProxyGetText(hwnd);
        }

    }
}
