using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    internal class SysListView32
    {
        internal static List<Dictionary<string, string>> GetAllText(IntPtr hwnd)
        {
            int rowCount = GetRowCount(hwnd);
            if (rowCount <= 0)
            {
                return null;
            }

            List<string> columns = SysHeader.GetAllHeaders(hwnd);
            if (columns == null || columns.Count == 0)
            {
                return null;
            }

            List<Dictionary<string, string>> dataList = new List<Dictionary<string, string>>(rowCount);
            for (int row = 0; row < rowCount; row++)
            {
                Dictionary<string, string> items = new Dictionary<string, string>(columns.Count);
                for (int col = 0; col < columns.Count; col++)
                {
                    items[""+col] = GetText(hwnd, row, col);
                }
                dataList.Add(items);
            }

            return dataList;
        }


        // retrieve count of columns in the listview
        internal static int GetColumnCount(IntPtr hwnd)
        {
            int column = SysHeader.GetSubItemCount(hwnd);
            return (column <= -1) ? 0 : column;
        }

        // get listview item count
        internal static int GetRowCount(IntPtr hwnd)
        {
            int row = Misc.ProxySendMessageInt(hwnd, NativeMethods.LVM_GETITEMCOUNT, IntPtr.Zero, IntPtr.Zero);
            return (row <= -1) ? 0 : row;
        }

        // unselect all items in the listview
        internal static bool UnselectAll(IntPtr hwnd)
        {
            return SetItemState(hwnd, -1, NativeMethods.LVIS_SELECTED, 0);
        }

        // select specified listview item
        internal static bool SelectItem(IntPtr hwnd, int item)
        {
            return SetItemState(hwnd, item, NativeMethods.LVIS_SELECTED, NativeMethods.LVIS_SELECTED);
        }

        // un-select specified listview item
        internal static bool UnSelectItem(IntPtr hwnd, int item)
        {
            return SetItemState(hwnd, item, NativeMethods.LVIS_SELECTED, 0);
        }

        // detect if listview item selected
        internal static bool IsItemSelected(IntPtr hwnd, int listItem)
        {
            return Misc.IsBitSet(GetItemState(hwnd, listItem, NativeMethods.LVIS_SELECTED), NativeMethods.LVIS_SELECTED);
        }


        // retrieve listview item text
        internal static string GetText(IntPtr hwnd, int item, int subitem)
        {
            NativeMethods.LVITEM lvitem = new NativeMethods.LVITEM();
            lvitem.mask = NativeMethods.LVIF_TEXT;
            lvitem.iItem = item;
            lvitem.iSubItem = subitem;
            return GetItemText(hwnd, lvitem);
        }

        // get listview item check state
        internal static int GetCheckedState(IntPtr hwnd, int item)
        {
            int state = GetItemState(hwnd, item, NativeMethods.LVIS_STATEIMAGEMASK);

            return ((state >> 12) - 1);
        }

        private static int GetItemState(IntPtr hwnd, int item, int stateMask)
        {
            return Misc.ProxySendMessageInt(hwnd, NativeMethods.LVM_GETITEMSTATE, new IntPtr(item), new IntPtr(stateMask));
        }
        // set listview item state
        private static bool SetItemState(IntPtr hwnd, int item, int stateMask, int state)
        {
            NativeMethods.LVITEM lvitem = new NativeMethods.LVITEM();

            lvitem.mask = NativeMethods.LVIF_STATE;
            lvitem.state = state;
            lvitem.stateMask = stateMask;

            return SetItem(hwnd, item, lvitem);
        }

        // This overload method is used to get ListView Item text.
        internal static unsafe string GetItemText(IntPtr hwnd, NativeMethods.LVITEM item)
        {
            item.cchTextMax = 256;
            LVITEM_32 item32 = new LVITEM_32(item);

            return XSendMessage.GetTextWithinStructureRemoteBitness(hwnd, NativeMethods.LVM_GETITEMW, IntPtr.Zero,
                new IntPtr(&item32), Marshal.SizeOf(item32.GetType()), new IntPtr(&item32.pszText),
                item32.cchTextMax, true, false);

        }

        // This overload method is used to set ListView Item data.
        internal static unsafe bool SetItem(IntPtr hwnd, int index, NativeMethods.LVITEM item)
        {
            LVITEM_32 item32 = new LVITEM_32(item);
            return XSendMessage.XSend(hwnd, NativeMethods.LVM_SETITEMSTATE, new IntPtr(index), new IntPtr(&item32), Marshal.SizeOf(item32.GetType()));
        }

        // This overload method is used to get ListView Item data with LVITEM_V6.  LVITEM_V6 is used to get ListView Group ID.
        internal static unsafe bool GetItem(IntPtr hwnd, ref NativeMethods.LVITEM_V6 item)
        {
            LVITEM_V6_32 item32 = new LVITEM_V6_32(item);
            bool result = XSendMessage.XSend(hwnd, NativeMethods.LVM_GETITEMW, IntPtr.Zero, new IntPtr(&item32), Marshal.SizeOf(item32.GetType()));

            if (result)
            {
                item = (NativeMethods.LVITEM_V6)item32;
            }
            return result;

        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct LVITEM_32
        {
            internal int mask;
            internal int iItem;
            internal int iSubItem;
            internal int state;
            internal int stateMask;
            internal int pszText;
            internal int cchTextMax;
            internal int iImage;
            internal int lParam;
            internal int iIndent;

            // This constructor should only be called with LVITEM is a 64 bit structure
            internal LVITEM_32(NativeMethods.LVITEM item)
            {
                mask = item.mask;
                iItem = item.iItem;
                iSubItem = item.iSubItem;
                state = item.state;
                stateMask = item.stateMask;
                pszText = 0;
                cchTextMax = item.cchTextMax;
                iImage = item.iImage;
                lParam = unchecked((int)item.lParam);
                iIndent = item.iIndent;
            }

            // This operator should only be called when LVITEM is a 64 bit structure
            static public explicit operator NativeMethods.LVITEM(LVITEM_32 item)
            {
                NativeMethods.LVITEM nativeItem = new NativeMethods.LVITEM();

                nativeItem.mask = item.mask;
                nativeItem.iItem = item.iItem;
                nativeItem.iSubItem = item.iSubItem;
                nativeItem.state = item.state;
                nativeItem.stateMask = item.stateMask;
                nativeItem.pszText = new IntPtr(item.pszText);
                nativeItem.cchTextMax = item.cchTextMax;
                nativeItem.iImage = item.iImage;
                nativeItem.lParam = new IntPtr(item.lParam);
                nativeItem.iIndent = item.iIndent;

                return nativeItem;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct LVITEM_V6_32
        {
            internal uint mask;
            internal int iItem;
            internal int iSubItem;
            internal int state;
            internal int stateMask;
            internal int pszText;
            internal int cchTextMax;
            internal int iImage;
            internal int lParam;
            internal int iIndent;
            internal int iGroupID;
            internal int cColumns;
            internal int puColumns;

            // This constructor should only be called with LVITEM_V6 is a 64 bit structure
            internal LVITEM_V6_32(NativeMethods.LVITEM_V6 item)
            {
                mask = item.mask;
                iItem = item.iItem;
                iSubItem = item.iSubItem;
                state = item.state;
                stateMask = item.stateMask;
                pszText = 0;
                cchTextMax = item.cchTextMax;
                iImage = item.iImage;
                lParam = unchecked((int)item.lParam);
                iIndent = item.iIndent;
                iGroupID = item.iGroupID;
                cColumns = item.cColumns;
                puColumns = 0;
            }

            // This operator should only be called when LVITEM_V6 is a 64 bit structure
            static public explicit operator NativeMethods.LVITEM_V6(LVITEM_V6_32 item)
            {
                NativeMethods.LVITEM_V6 nativeItem = new NativeMethods.LVITEM_V6();

                nativeItem.mask = item.mask;
                nativeItem.iItem = item.iItem;
                nativeItem.iSubItem = item.iSubItem;
                nativeItem.state = item.state;
                nativeItem.stateMask = item.stateMask;
                nativeItem.pszText = new IntPtr(item.pszText);
                nativeItem.cchTextMax = item.cchTextMax;
                nativeItem.iImage = item.iImage;
                nativeItem.lParam = new IntPtr(item.lParam);
                nativeItem.iIndent = item.iIndent;
                nativeItem.iGroupID = item.iGroupID;
                nativeItem.cColumns = item.cColumns;
                nativeItem.puColumns = new IntPtr(item.puColumns);

                return nativeItem;
            }
        }
    }
}
