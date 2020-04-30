using Dragonfly.Common.Utils;
using System;
using System.Text;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    internal class Window
    {

        internal static IntPtr FindHwndInParent(IntPtr hParent, IntPtr hChildAfter, string lpClassName, string lpWindowName)
        {
            return NativeMethods.FindWindowEx(hParent, hChildAfter, lpClassName, lpWindowName);
        }

        internal static IntPtr FindVisibleHwndInParent(IntPtr hParent, IntPtr hChildAfter, string lpClassName, string lpWindowName)
        {
            IntPtr retHandle = hChildAfter;
            do
            {
                retHandle = NativeMethods.FindWindowEx(hParent, retHandle, lpClassName, lpWindowName);
                if (retHandle == IntPtr.Zero || NativeMethods.IsWindowVisible(retHandle))
                {
                    break;
                }
            } while (retHandle != IntPtr.Zero);

            return retHandle;
        }

        internal static IntPtr FindHwndInParentRecursive(IntPtr hParent, string lpClassName, string lpWindowName)
        {
            WindowFinder finder = new WindowFinder(hParent, lpClassName, lpWindowName);
            return finder.FoundHandle;
        }

        internal static IntPtr GetDlgItem(IntPtr hDlg, int nControlID)
        {
            return NativeMethods.GetDlgItem(hDlg, nControlID);
        }

        internal static string GetWindowText(IntPtr hWnd)
        {
            int length = NativeMethods.GetWindowTextLength(hWnd);
            var builder = new StringBuilder(length + 1);
            NativeMethods.GetWindowText(hWnd, builder, builder.Capacity);
            return builder.ToString();
        }

        internal static bool GetWindowRect(IntPtr hwnd, ref NativeMethods.Win32Rect rc)
        {
            return NativeMethods.GetWindowRect(hwnd, ref rc);
        }


        internal static void MouseClick(IntPtr handle, int x, int y)
        {
            // NativeMethods.SendMessage(handle, NativeMethods.WM_LBUTTONDOWN, 0x00000001, MAKELPARAM(x, y));
            // Delay(5);
            // NativeMethods.SendMessage(handle, NativeMethods.WM_LBUTTONUP, 0x00000000, MAKELPARAM(x, y));
        }

    }
}
