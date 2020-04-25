using System;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading.Utils
{
    public static class Keyboard
    {
        private const uint WM_CHAR = 0x0102;



        public static void Press(string text)
        {
            foreach (char letter in text)
            {
                NativeMethods.keybd_event((Keys)letter, 0, 0, 0);
            }
        }



        public static void Press(IntPtr hWnd, string text)
        {
            foreach (char letter in text)
            {
                NativeMethods.PostMessage(hWnd, WM_CHAR, letter, 0);
            }
        }

    }
}
