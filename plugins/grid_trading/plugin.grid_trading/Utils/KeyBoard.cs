using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading.Utils
{
    public static class Keyboard
    {
        private const uint WM_CHAR = 0x0102;

        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        [DllImport("User32.Dll")]
        private static extern IntPtr PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        public static void Press(string text)
        {
            foreach (char letter in text)
            {
                keybd_event((Keys)letter, 0, 0, 0);
            }
        }



        public static void Press(IntPtr hWnd, string text)
        {
            foreach (char letter in text)
            {
                PostMessage(hWnd, WM_CHAR, letter, 0);
            }
        }
     
    }
}
