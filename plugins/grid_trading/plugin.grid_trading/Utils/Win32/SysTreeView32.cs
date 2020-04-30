using System;
using System.Runtime.InteropServices;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    internal class SysTreeView32
    {
        internal static string GetTreeItemText(IntPtr hwnd, IntPtr itemHwnd)
        {
            NativeMethods.TVITEM tvItem = new NativeMethods.TVITEM();
            tvItem.mask = NativeMethods.TVIF_TEXT;
            tvItem.hItem = itemHwnd;
            tvItem.cchTextMax = 512;
            return GetTreeItemText(hwnd, tvItem);
        }

        internal static unsafe string GetTreeItemText(IntPtr hwnd, NativeMethods.TVITEM item)
        {
            TVITEM_32 item32 = new TVITEM_32(item);

            return XSendMessage.GetTextWithinStructure(hwnd, NativeMethods.TVM_GETITEMW, IntPtr.Zero, new IntPtr(&item32),
                        Marshal.SizeOf(item32.GetType()), new IntPtr(&item32.pszText), item32.cchTextMax, true);
        }

        internal static NativeMethods.Win32Rect GetTreeViewItemRECT(IntPtr hTreeView, IntPtr treeItemHandle)
        {
            NativeMethods.Win32Rect rect = NativeMethods.Win32Rect.Empty;
            unsafe
            {
                XSendMessage.XSend(hTreeView, NativeMethods.TVM_GETITEMRECT, treeItemHandle, new IntPtr(&rect), Marshal.SizeOf(rect.GetType()));
            }
            return rect;

        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct TVITEM_32
        {
            internal uint mask;
            internal int hItem;
            internal uint state;
            internal uint stateMask;
            internal int pszText;
            internal int cchTextMax;
            internal int iImage;
            internal int iSelectedImage;
            internal int cChildren;
            internal int lParam;

            // This constructor should only be called with TVITEM is a 64 bit structure
            // but refers to an item in a 32-bit TreeView.
            internal TVITEM_32(NativeMethods.TVITEM item)
            {
                mask = item.mask;

                // Since the high 32-bits of item.hItem are zero,
                // we can force them into the 32-bit hItem in a
                // TVITEM_32.
                hItem = item.hItem.ToInt32();

                state = item.state;
                stateMask = item.stateMask;
                pszText = 0;
                cchTextMax = item.cchTextMax;
                iImage = item.iImage;
                iSelectedImage = item.iSelectedImage;
                cChildren = item.cChildren;
                lParam = unchecked((int)item.lParam);
            }

            // This operator should only be called when TVITEM is a 64 bit structure
            static public explicit operator NativeMethods.TVITEM(TVITEM_32 item)
            {
                NativeMethods.TVITEM nativeItem = new NativeMethods.TVITEM();

                nativeItem.mask = item.mask;
                nativeItem.hItem = new IntPtr(item.hItem);
                nativeItem.state = item.state;
                nativeItem.stateMask = item.stateMask;
                nativeItem.pszText = new IntPtr(item.pszText);
                nativeItem.cchTextMax = item.cchTextMax;
                nativeItem.iImage = item.iImage;
                nativeItem.iSelectedImage = item.iSelectedImage;
                nativeItem.cChildren = item.cChildren;
                nativeItem.lParam = new IntPtr(item.lParam);

                return nativeItem;
            }
        }



    }
}
