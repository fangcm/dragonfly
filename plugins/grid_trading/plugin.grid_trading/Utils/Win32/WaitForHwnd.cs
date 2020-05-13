using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    internal class WaitForHwnd
    {
        internal static IntPtr WaitForFindHwndInParentRecursive(IntPtr hParent, string lpClassName, string lpWindowName, bool onlyInVisibleParent = false, int timeoutSeconds = 10)
        {
            int counter = timeoutSeconds * 5;
            while (true)
            {
                IntPtr hFinded = WindowHwnd.FindHwndInParentRecursive(hParent, lpClassName, lpWindowName, onlyInVisibleParent);
                if (hFinded != IntPtr.Zero)
                {
                    return hFinded;
                }

                counter--;
                if (counter <= 0)
                {
                    return IntPtr.Zero;
                }

                Misc.Delay(200);
            }
        }

        internal static IntPtr WaitForFindVisibleHwndLikeInParent(IntPtr hParent, IntPtr hChildAfter, string lpClassName, string lpWindowName,
            int confirmDlgId, string confirmTxt, int timeoutSeconds = 10)
        {
            int counter = timeoutSeconds * 5;
            while (true)
            {
                IntPtr hFinded = WindowHwnd.FindVisibleHwndLikeInParent(hParent, hChildAfter, lpClassName, lpWindowName);
                if (hFinded != IntPtr.Zero)
                {
                    IntPtr hConfirm = WindowHwnd.GetDlgItem(hFinded, confirmDlgId);
                    if (hConfirm != IntPtr.Zero
                        && NativeMethods.IsWindowVisible(hConfirm)
                        && WindowHwnd.GetWindowText(hConfirm) == confirmTxt)
                    {
                        return hFinded;
                    }
                }

                counter--;
                if (counter <= 0)
                {
                    return IntPtr.Zero;
                }

                Misc.Delay(200);
            }
        }

        internal static IntPtr WaitForFindVisibleHwndLikeInParent(IntPtr hParent, IntPtr hChildAfter, string lpClassName, string lpWindowName, int confirmVisibleChildrenCount, int timeoutSeconds = 10)
        {
            int counter = timeoutSeconds * 5;
            while (true)
            {
                IntPtr hFinded = WindowHwnd.FindVisibleHwndLikeInParent(hParent, hChildAfter, lpClassName, lpWindowName);
                if (hFinded != IntPtr.Zero)
                {
                    IntPtr hFindChild = IntPtr.Zero;
                    int childrenCount = 0;

                    while (true)
                    {
                        hFindChild = WindowHwnd.FindVisibleHwndInParent(hFinded, hFindChild, null, null);
                        if (hFindChild != IntPtr.Zero)
                        {
                            childrenCount++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (confirmVisibleChildrenCount == childrenCount)
                    {
                        return hFinded;
                    }
                }

                counter--;
                if (counter <= 0)
                {
                    return IntPtr.Zero;
                }

                Misc.Delay(200);
            }
        }

        internal static void WaitForCloseProcess(string procName, string prefixTitle, int timeoutSeconds = 10)
        {
            int counter = timeoutSeconds * 5;
            while (true)
            {
                Process p = WindowHwnd.FindProcess(procName, prefixTitle);
                if (p != null)
                {
                    if (!p.CloseMainWindow())
                        p.Kill();  //当发送关闭窗口命令无效时强行结束进程 
                    return;
                }
                counter--;
                if (counter <= 0)
                {
                    return;
                }

                Misc.Delay(200);
            }
        }

    }
}
