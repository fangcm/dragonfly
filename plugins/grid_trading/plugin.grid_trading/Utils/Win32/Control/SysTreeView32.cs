using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    internal class SysTreeView32
    {

        internal static void SimulateClick(IntPtr hTreeView, IntPtr hItem)
        {
            // get item rect
            NativeMethods.Win32Rect rectItem = GetItemRect(hTreeView, hItem, true);

            // get control coordinates at which we will "click"
            NativeMethods.Win32Point pt = new NativeMethods.Win32Point(((rectItem.left + rectItem.right) / 2), ((rectItem.top + rectItem.bottom) / 2));

            // convert back to client
            Misc.MapWindowPoints(IntPtr.Zero, hTreeView, ref pt, 1);
            // click
            SimulateClick(hTreeView,pt);
        }

        // simulate click via posting WM_LBUTTONDOWN(UP)
        internal static void SimulateClick(IntPtr hTreeView, NativeMethods.Win32Point pt)
        {
            // Fails if a SendMessage is used instead of the Post.
            NativeMethods.PostMessage(hTreeView, NativeMethods.WM_LBUTTONDOWN, IntPtr.Zero, NativeMethods.Util.MAKELPARAM(pt.x, pt.y));
            NativeMethods.PostMessage(hTreeView, NativeMethods.WM_LBUTTONUP, IntPtr.Zero, NativeMethods.Util.MAKELPARAM(pt.x, pt.y));
        }


        #region get all Helpers

        internal static List<TreeItemNode> GetAllItems(IntPtr hTreeView)
        {
            List<TreeItemNode> itemList = new List<TreeItemNode>();
            var hTreeItem = GetRoot(hTreeView);
            while (hTreeItem != IntPtr.Zero)
            {
                string text = GetItemText(hTreeView, hTreeItem);
                TreeItemNode node = new TreeItemNode(hTreeItem, text);
                itemList.Add(node);

                PopulateChildItems(hTreeView, hTreeItem, node);

                hTreeItem = GetNextItem(hTreeView, hTreeItem);
            };
            return itemList;
        }

        private static void PopulateChildItems(IntPtr hTreeView, IntPtr hItem, TreeItemNode node)
        {
            if (!TreeViewItem_HasChildren(hTreeView, hItem))
            {
                return;
            }

            var hChild = GetFirstChild(hTreeView, hItem);
            while (hChild != IntPtr.Zero)
            {
                string text = GetItemText(hTreeView, hChild);
                TreeItemNode childNode = new TreeItemNode(hChild, text);
                node.Children.Add(childNode);

                PopulateChildItems(hTreeView, hChild, childNode);

                hChild = GetNextItem(hTreeView, hChild);
            };
        }

        internal class TreeItemNode
        {
            internal IntPtr Handle { set; get; }
            internal string Text { set; get; }
            private List<TreeItemNode> children = new List<TreeItemNode>();

            public TreeItemNode(IntPtr handle, string text)
            {
                Handle = handle;
                Text = text;
            }

            internal List<TreeItemNode> Children
            {
                get { return children; }
            }
        }

        #endregion

        #region Expand/Collapse Helpers
        // expand tree view item
        internal static bool Expand(IntPtr hTreeView, IntPtr hItem)
        {
            return Misc.ProxySendMessageInt(hTreeView, NativeMethods.TVM_EXPAND, new IntPtr(NativeMethods.TVE_EXPAND), hItem) != 0;
        }

        // collapse tree view item
        internal static bool Collapse(IntPtr hTreeView, IntPtr hItem)
        {
            return Misc.ProxySendMessageInt(hTreeView, NativeMethods.TVM_EXPAND, new IntPtr(NativeMethods.TVE_COLLAPSE), hItem) != 0;
        }

        // detect if tree view item is expanded.
        internal static bool IsItemExpanded(IntPtr hTreeView, IntPtr hItem)
        {
            int expanded = GetItemState(hTreeView, hItem, NativeMethods.TVIS_EXPANDED);

            return (Misc.IsBitSet(expanded, NativeMethods.TVIS_EXPANDED));
        }
        #endregion

        #region Selection Helpers

        // select tree view item
        internal static bool SelectItem(IntPtr hTreeView, IntPtr hItem)
        {
            bool fRet;
            if (Misc.ProxySendMessageInt(hTreeView, NativeMethods.TVM_SELECTITEM, new IntPtr(NativeMethods.TVGN_CARET | NativeMethods.TVSI_NOSINGLEEXPAND), hItem) != 0)
            {
                fRet = true;
            }
            else
            {
                fRet = Misc.ProxySendMessageInt(hTreeView, NativeMethods.TVM_SELECTITEM, new IntPtr(NativeMethods.TVGN_CARET), hItem) != 0;
            }

            return fRet;
        }

        // retrieve currently selected item
        internal static IntPtr GetSelection(IntPtr hTreeView)
        {
            return GetNext(hTreeView, IntPtr.Zero, NativeMethods.TVGN_CARET);
        }

        #endregion

        #region Navigation Helper

        // retrieve the parent of the current item
        internal static IntPtr Parent(IntPtr hTreeView, IntPtr hItem)
        {
            return GetNext(hTreeView, hItem, NativeMethods.TVGN_PARENT);
        }

        // retrieve the next item
        internal static IntPtr GetNextItem(IntPtr hTreeView, IntPtr hItem)
        {
            return GetNext(hTreeView, hItem, NativeMethods.TVGN_NEXT);
        }

        // retrieve the previous item
        internal static IntPtr GetPreviousItem(IntPtr hTreeView, IntPtr hItem)
        {
            return GetNext(hTreeView, hItem, NativeMethods.TVGN_PREVIOUS);
        }

        // retrieve root of the tree view
        internal static IntPtr GetRoot(IntPtr hTreeView)
        {
            return GetNext(hTreeView, IntPtr.Zero, NativeMethods.TVGN_ROOT);
        }

        // retrieve the first child of the current tree view item
        internal static IntPtr GetFirstChild(IntPtr hTreeView, IntPtr hItem)
        {
            return GetNext(hTreeView, hItem, NativeMethods.TVGN_CHILD);
        }

        #endregion

        #region Common Helpers

        // generic method for TVM_GETNEXTITEM message
        internal static IntPtr GetNext(IntPtr hTreeView, IntPtr hItem, int flag)
        {
            return Misc.ProxySendMessage(hTreeView, NativeMethods.TVM_GETNEXTITEM, new IntPtr(flag), hItem);
        }

        // generic way to retrieve item's state
        internal static int GetItemState(IntPtr hTreeView, IntPtr hItem, int stateMask)
        {
            return Misc.ProxySendMessageInt(hTreeView, NativeMethods.TVM_GETITEMSTATE, hItem, new IntPtr(stateMask));
        }

        // detect if tree view item has children
        internal static bool TreeViewItem_HasChildren(IntPtr hTreeView, IntPtr item)
        {
            NativeMethods.TVITEM hItem;

            if (!GetItem(hTreeView, item, NativeMethods.TVIF_CHILDREN, out hItem))
            {
                // @review: should we throw here
                return false;
            }

            return (hItem.cChildren > 0);
        }


        internal static unsafe NativeMethods.Win32Rect GetItemRect(IntPtr hTreeView, IntPtr hItem, bool labelOnly)
        {
            NativeMethods.Win32Rect rc = NativeMethods.Win32Rect.Empty;

            // This strange line of code is here to make the TVM_GETITEMRECT work on 64 bit platform
            // This message expcects an IntPtr on input and a Rect for output.  On a 64 bit platform we 
            // will just overwrite the first 2 members of the rect structure with the IntPtr.
            *((IntPtr*)&(rc.left)) = hItem;

            IntPtr rectangle = new IntPtr(&(rc.left));
            IntPtr partialDisplay = (labelOnly) ? new IntPtr(1) : IntPtr.Zero;

            if (!XSendMessage.XSend(hTreeView, NativeMethods.TVM_GETITEMRECT, partialDisplay, rectangle, Marshal.SizeOf(rc.GetType())))
            {
                return NativeMethods.Win32Rect.Empty;
            }

            // Temporarily allow the possibility of returning a bounding rect for scrolled off items.  
            // Will need to revisit this when there is a method that can scroll items into view.
            //if (Misc.IsItemVisible(hTreeView, ref rc))
            Misc.MapWindowPoints(hTreeView, IntPtr.Zero, ref rc, 2);
            return rc;
        }


        // generic method to retrieve info about tree view item
        // NOTE: this method should not be used to retrieve a text
        // instead use GetItemText
        internal static bool GetItem(IntPtr hTreeView, IntPtr hItem, int mask, out NativeMethods.TVITEM tvItem)
        {
            tvItem = new NativeMethods.TVITEM();
            tvItem.Init(hItem);
            tvItem.mask = (uint)mask;

            return GetItem(hTreeView, ref tvItem);
        }

        internal static string GetItemText(IntPtr hTreeView, IntPtr hItem)
        {
            NativeMethods.TVITEM tvItem = new NativeMethods.TVITEM();
            tvItem.mask = NativeMethods.TVIF_TEXT;
            tvItem.hItem = hItem;
            tvItem.cchTextMax = 512;
            return GetItemText(hTreeView, tvItem);
        }

        #endregion


        internal static unsafe bool GetItem(IntPtr hTreeView, ref NativeMethods.TVITEM tvItem)
        {
            TVITEM_32 item32 = new TVITEM_32(tvItem);

            bool result = XSendMessage.XSend(hTreeView, NativeMethods.TVM_GETITEMW, IntPtr.Zero, new IntPtr(&item32), Marshal.SizeOf(item32.GetType()));
            if (result)
            {
                tvItem = (NativeMethods.TVITEM)item32;
            }
            return result;
        }

        internal static unsafe string GetItemText(IntPtr hTreeView, NativeMethods.TVITEM tvItem)
        {
            TVITEM_32 item32 = new TVITEM_32(tvItem);

            return XSendMessage.GetTextWithinStructure(hTreeView, NativeMethods.TVM_GETITEMW, IntPtr.Zero, new IntPtr(&item32),
                        Marshal.SizeOf(item32.GetType()), new IntPtr(&item32.pszText), item32.cchTextMax, true);
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct TVITEM_32
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
