using System;
using System.Runtime.InteropServices;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    internal static class SafeNativeMethods
    {
        [DllImport("user32.dll", ExactSpelling = true)]
        internal static extern bool IsWindowVisible(IntPtr hWnd);
    }
}
