using System;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    internal class Static
    {
        internal static string GetText(IntPtr hwnd)
        {
            return Misc.ProxyGetText(hwnd);
        }

    }
}
