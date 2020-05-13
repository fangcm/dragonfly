using System;
using System.Diagnostics;
using System.Text;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    internal class WindowHwnd
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

        internal static IntPtr FindHwndInParentRecursive(IntPtr hParent, string lpClassName, string lpWindowName, bool onlyVisibleInParent = false)
        {
            IntPtr iResult = IntPtr.Zero;
            // 首先在父窗体上查找控件
            iResult = NativeMethods.FindWindowEx(hParent, IntPtr.Zero, lpClassName, lpWindowName);
            // 如果找到直接返回控件句柄
            if (iResult != IntPtr.Zero) return iResult;

            // 枚举子窗体，查找控件句柄
            NativeMethods.EnumChildWindows(hParent, (h, l) =>
            {
                if (onlyVisibleInParent)
                {
                    if (!NativeMethods.IsWindowVisible(h)) { return true; }
                }
                IntPtr f1 = NativeMethods.FindWindowEx(h, IntPtr.Zero, lpClassName, lpWindowName);
                if (f1 == IntPtr.Zero)
                {
                    return true;
                }
                else
                {
                    iResult = f1;
                    return false;
                }
            }, IntPtr.Zero);
            // 返回查找结果
            return iResult;
        }

        internal static IntPtr FindVisibleHwndLikeInParent(IntPtr hParent, IntPtr hChildAfter, string lpClassName, string lpWindowName)
        {
            IntPtr hWnd = IntPtr.Zero;
            while (true)
            {
                hWnd = FindVisibleHwndInParent(hParent, hWnd, null, null);
                if (hWnd == IntPtr.Zero)
                {
                    break;
                }
                var windowName = new StringBuilder(256);
                var className = new StringBuilder(256);

                NativeMethods.GetWindowText(hWnd, windowName, 255);
                NativeMethods.GetClassName(hWnd, className, 255);

                bool bMatchWindowName = true;
                if (lpWindowName != null)
                {
                    if (!windowName.ToString().Contains(lpWindowName))
                    {
                        bMatchWindowName = false;
                    }
                }

                bool bMatchClassName = true;
                if (lpClassName != null)
                {
                    if (!className.ToString().Contains(lpClassName))
                    {
                        bMatchClassName = false;
                    }
                }

                if (bMatchWindowName && bMatchClassName)
                {
                    break;
                }
            }


            return hWnd;
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

        internal static bool SetFocus(IntPtr hwnd)
        {
            if (!NativeMethods.IsWindowVisible(hwnd))
            {
                return false;
            }

            return NativeMethods.SetForegroundWindow(hwnd);
        }

        internal static Process FindProcess(string procName, string prefixTitle)
        {
            foreach (Process thisProc in Process.GetProcessesByName(procName))
            {
                if (thisProc.MainWindowTitle.Contains(prefixTitle))
                {
                    return thisProc;
                }
            }
            return null;
        }

    }
}
