using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    internal class WindowSysHeader
    {
        internal static List<string> GetAllHeaders(IntPtr hwnd)
        {
            IntPtr hwndHeader = ListViewGetHeader(hwnd);
            if (hwndHeader == IntPtr.Zero)
            {
                return null;
            }
            int columnCount = HeaderItemCount(hwndHeader);
            if (columnCount <= 0)
            {
                return null;
            }

            List<string> columns = new List<string>();
            for (int col = 0; col < columnCount; col++)
            {
                columns.Add(GetItemTextFromIndex(hwnd, col));
            }

            return columns;
        }

        private static string GetItemTextFromIndex(IntPtr hwnd, int index)
        {
            NativeMethods.HDITEM hdi = new NativeMethods.HDITEM();
            hdi.Init();
            hdi.mask = NativeMethods.HDI_TEXT;
            hdi.cchTextMax = 256;

            return GetItemText(hwnd, index, hdi);
        }

        internal static int HeaderItemCount(IntPtr hwnd)
        {
            return Misc.ProxySendMessageInt(hwnd, NativeMethods.HDM_GETITEMCOUNT, IntPtr.Zero, IntPtr.Zero);
        }

        internal static int GetSubItemCount(IntPtr hwnd)
        {
            IntPtr hwndHeader = ListViewGetHeader(hwnd);

            if (hwndHeader == IntPtr.Zero)
            {
                return 0;
            }

            return HeaderItemCount(hwndHeader);

        }

        internal static IntPtr ListViewGetHeader(IntPtr hwnd)
        {
            return Misc.ProxySendMessage(hwnd, NativeMethods.LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
        }

        // This overload method is used to get SysHeader Item data.
        internal static unsafe bool GetItem(IntPtr hwnd, int index, ref NativeMethods.HDITEM item)
        {
            HDITEM_32 item32 = new HDITEM_32(item);
            bool result = XSendMessage.XSend(hwnd, NativeMethods.HDM_GETITEMW, new IntPtr(index), new IntPtr(&item32), Marshal.SizeOf(item32.GetType()));

            if (result)
            {
                item = (NativeMethods.HDITEM)item32;
            }

            return result;

        }

        // This overload method is used to get SysHeader Item text.
        internal static unsafe string GetItemText(IntPtr hwnd, int index, NativeMethods.HDITEM item)
        {
            HDITEM_32 item32 = new HDITEM_32(item);
            return XSendMessage.GetTextWithinStructureRemoteBitness(
                      hwnd, NativeMethods.HDM_GETITEMW, new IntPtr(index), new IntPtr(&item32),
                      Marshal.SizeOf(item32.GetType()), new IntPtr(&item32.pszText), item32.cchTextMax,
                      true, false);

        }

        static private int OrderToIndex(IntPtr hwnd, int order)
        {
            return Misc.ProxySendMessageInt(hwnd, NativeMethods.HDM_ORDERTOINDEX, new IntPtr(order), IntPtr.Zero);
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct HDITEM_32
        {
            internal uint mask;
            internal int cxy;
            internal int pszText;
            internal int hbm;
            internal int cchTextMax;
            internal int fmt;
            internal int lParam;
            internal int iImage;
            internal int iOrder;
            internal uint type;
            internal int pvFilter;

            // This constructor should only be called with HDITEM is a 64 bit structure
            internal HDITEM_32(NativeMethods.HDITEM item)
            {
                mask = item.mask;
                cxy = item.cxy;
                pszText = 0;
                hbm = 0;
                cchTextMax = item.cchTextMax;
                fmt = item.fmt;
                lParam = unchecked((int)item.lParam);
                iImage = item.iImage;
                iOrder = item.iOrder;
                type = item.type;
                pvFilter = 0;
            }

            // This operator should only be called when HDITEM is a 64 bit structure
            static public explicit operator NativeMethods.HDITEM(HDITEM_32 item)
            {
                NativeMethods.HDITEM nativeItem = new NativeMethods.HDITEM();

                nativeItem.mask = item.mask;
                nativeItem.cxy = item.cxy;
                nativeItem.pszText = new IntPtr(item.pszText);
                nativeItem.hbm = new IntPtr(item.hbm);
                nativeItem.cchTextMax = item.cchTextMax;
                nativeItem.fmt = item.fmt;
                nativeItem.lParam = new IntPtr(item.lParam);
                nativeItem.iImage = item.iImage;
                nativeItem.iOrder = item.iOrder;
                nativeItem.type = item.type;
                nativeItem.pvFilter = new IntPtr(item.pvFilter);

                return nativeItem;
            }
        }
    }
}
