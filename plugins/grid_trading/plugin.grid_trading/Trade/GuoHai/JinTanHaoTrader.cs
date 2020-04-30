using Dragonfly.Common.Utils;
using Dragonfly.Plugin.GridTrading.Utils;
using Dragonfly.Plugin.GridTrading.Utils.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace Dragonfly.Plugin.GridTrading.Trade.GuoHai
{
    // 国海金叹号
    public class JintanhaoTrader : AbstractTrader, ITrader
    {

        IntPtr hToolBar;
        // A股主功能菜单
        IntPtr hStockTree;    // A股功能树形控件句柄
        IntPtr hBuy, hSell, hCancel, hTodayDeals;
        // 港股主功能菜单
        IntPtr hHkStockTree;    // 港股通功能树形控件句柄
        IntPtr hHkHgtBuy, hHkHgtSell, hHkHgtCancel, hHkHgtTodayDeals;
        IntPtr hHkSgtBuy, hHkSgtSell, hHkSgtCancel, hHkSgtTodayDeals;

        public bool Init()
        {
            if (!Init("TdxW_MainFrame_Class", null))
            {
                Log(LoggType.Red, "【国海金叹号网上交易系统】未启动");
                return false;
            }
            hMainWnd = FindHwndInApp(null, @"通达信网上交易V6");
            IntPtr mdi = FindHwndInParentRecursive(hMainWnd, "AfxMDIFrame42", null);
            IntPtr tmp = UnsafeNativeMethods.GetDlgItem(mdi, 0xE900);
            hToolBar = UnsafeNativeMethods.GetDlgItem(tmp, 0x00DD);

            if (hToolBar == IntPtr.Zero)
            {
                Log(LoggType.Red, "未找到选择股票市场工具条");
                return false;
            }

            // 获取左侧功能菜单treeview 句柄
            hStockTree = UnsafeNativeMethods.GetDlgItem(hToolBar, 0xE900);
            hHkStockTree = UnsafeNativeMethods.GetDlgItem(hToolBar, 0xE903);

            if (hStockTree == IntPtr.Zero)
            {
                Log(LoggType.Red, "没有找到金叹号交易软件");
                return false;
            }
            if (hHkStockTree == IntPtr.Zero)
            {
                Log(LoggType.Red, "没有找到金叹号港股交易软件");
                return false;
            }

            InitStockTreeViewItemHandler();
            //InitHKStockTreeViewItemHandler();

            Log(LoggType.Black, "关联金叹号交易软件成功");

            return true;
        }

        public static void MouseClickToolbar(IntPtr hToolBar, int index)
        {
            NativeMethods.Win32Rect rect = new NativeMethods.Win32Rect();
            UnsafeNativeMethods.GetWindowRect(hToolBar, ref rect);

            int x = 10 + (rect.right - rect.left) / 3 * index;
            int y = 10;

            MouseClick(hToolBar, x, y);
        }

        private void InitStockTreeViewItemHandler()
        {
            IntPtr hTmp;

            hBuy = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_ROOT, IntPtr.Zero);
            hSell = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, hBuy);
            hTmp = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, hSell);
            hCancel = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, hTmp);
            hTmp = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, hCancel);
            hTmp = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, hTmp);
            hTmp = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_CHILD, hTmp);
            hTmp = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, hTmp);
            hTodayDeals = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, hTmp);
        }


        [DllImport("user32.dll")]
        internal static extern IntPtr SetFocus(IntPtr hWnd);
        const int WM_MOUSEMOVE = 0x200;

        public void BuyStock(string code, float price, int num)
        {
            Log(LoggType.Red, "购买股票: " + code + ", 价格: " + price + ", 数量: " + num);
            MouseClickToolbar(hToolBar, 0);
            SelectTreeViewItem(hStockTree, hBuy);
            /*
            Class1.TVITEMEX item = new Class1.TVITEMEX();
            item.hItem = hBuy;
            item.mask = Class1.TVIF.TEXT;
            bool ret = (bool)Class1.GetItemInTarget(hStockTree, item);

            IntPtr hPanel = FindHwndInApp("TFrmBuyStock", null);

            IntPtr hCode = IntPtr.Zero;
            IntPtr hPrice = IntPtr.Zero;
            IntPtr hNum = IntPtr.Zero;
            IntPtr hButton = IntPtr.Zero;

            IntPtr hChild = IntPtr.Zero;
            while (true)
            {
                hChild = FindVisibleHwndInParent(hPanel, hChild, "TPanel", null);
                if (hChild == IntPtr.Zero)
                {
                    break;
                }


                IntPtr c = FindVisibleHwndInParent(hChild, IntPtr.Zero, "TEdit", null);
                if (c == IntPtr.Zero)
                    continue;
                IntPtr p = FindVisibleHwndInParent(hChild, IntPtr.Zero, "TStockComboBox", null);
                if (p == IntPtr.Zero)
                    continue;
                IntPtr n = FindVisibleHwndInParent(hChild, IntPtr.Zero, "TBoundPriceEdit", null);
                if (n == IntPtr.Zero)
                    continue;
                IntPtr b = FindVisibleHwndInParent(hChild, IntPtr.Zero, "TButton", "委托[F3]");
                if (b == IntPtr.Zero)
                    continue;
                hCode = c;
                hPrice = p;
                hNum = n;
                hButton = b;

            }
            if (hCode == IntPtr.Zero || hPrice == IntPtr.Zero || hNum == IntPtr.Zero || hButton == IntPtr.Zero)
            {
                Log(LoggType.Red, "没有买入下单的控件页面");
                return;
            }

            NativeMethods.SendMessage(hCode, NativeMethods.WM_SETFOCUS, 0, 0);
            SetRichEditText(hCode, code);
            NativeMethods.SendMessage(hCode, NativeMethods.WM_KILLFOCUS, 0, 0);
            NativeMethods.SendMessage(hPrice, NativeMethods.WM_SETFOCUS, 0, 0);
            Delay(500);
            SetEditText(hPrice, "" + price);
            NativeMethods.SendMessage(hPrice, NativeMethods.WM_KILLFOCUS, 0, 0);
            NativeMethods.SendMessage(hNum, NativeMethods.WM_SETFOCUS, 0, 0);
            Delay(500);
            SetRichEditText(hNum, "" + num);
            NativeMethods.SendMessage(hNum, NativeMethods.WM_KILLFOCUS, 0, 0);

            // 点击买入按钮
            ClickButton(hButton);
            Delay(500);
            WindowFinder finder = new WindowFinder(IntPtr.Zero, "TfrmDialogs", "确认");
            IntPtr hConfirmDlg = finder.FoundHandle;
            if (hConfirmDlg != IntPtr.Zero)
            {
                IntPtr hBtnYes = FindHwndInParentRecursive(hConfirmDlg, "TButton", "是(&Y)");
                IntPtr hBtnNo = FindHwndInParentRecursive(hConfirmDlg, "TButton", "否(&N)");

                string sCode = GetEditText(hCode);
                string sPrice = GetEditText(hPrice);
                string sNum = GetEditText(hNum);

                Log(LoggType.Red, "校验购买单: " + sCode + ", 价格: " + sPrice + ", 数量: " + sNum);
                if (sCode == code && sPrice == "" + price && sNum == "" + num)
                {
                    ClickButton(hBtnYes);
                }
                else
                {
                    ClickButton(hBtnNo);
                }

            }
                        */

        }

        public void SellStock(string code, float price, int num)
        {
            Log(LoggType.Red, "卖出股票: " + code + ", 价格: " + price + ", 数量: " + num);
            MouseClickToolbar(hToolBar, 0);
            string a = GetTreeViewItemText(hStockTree, hCancel);
            SelectTreeViewItem(hStockTree, hSell);

            /*
            SelectTreeViewItem(hStockTree, hSell);
            ClickButton(hStockBtn);

            IntPtr hPanel = FindHwndInApp("Tfrm2007", null);

            IntPtr hCode = IntPtr.Zero;
            IntPtr hPrice = IntPtr.Zero;
            IntPtr hNum = IntPtr.Zero;
            IntPtr hButton = IntPtr.Zero;

            IntPtr hChild = IntPtr.Zero;
            while (true)
            {
                hChild = FindVisibleHwndInParent(hPanel, hChild, "TPanel", null);
                if (hChild == IntPtr.Zero)
                {
                    break;
                }


                IntPtr c = FindVisibleHwndInParent(hChild, IntPtr.Zero, "TEdit", null);
                if (c == IntPtr.Zero)
                    continue;
                IntPtr p = FindVisibleHwndInParent(hChild, IntPtr.Zero, "TStockComboBox", null);
                if (p == IntPtr.Zero)
                    continue;
                IntPtr n = FindVisibleHwndInParent(hChild, IntPtr.Zero, "TBoundPriceEdit", null);
                if (n == IntPtr.Zero)
                    continue;
                IntPtr b = FindVisibleHwndInParent(hChild, IntPtr.Zero, "TButton", "委托[F3]");
                if (b == IntPtr.Zero)
                    continue;
                hCode = c;
                hPrice = p;
                hNum = n;
                hButton = b;

            }
            if (hCode == IntPtr.Zero || hPrice == IntPtr.Zero || hNum == IntPtr.Zero || hButton == IntPtr.Zero)
            {
                Log(LoggType.Red, "没有卖出下单的控件页面");
                return;
            }

            NativeMethods.SendMessage(hCode, NativeMethods.WM_SETFOCUS, 0, 0);
            SetRichEditText(hCode, code);
            NativeMethods.SendMessage(hCode, NativeMethods.WM_KILLFOCUS, 0, 0);
            NativeMethods.SendMessage(hPrice, NativeMethods.WM_SETFOCUS, 0, 0);
            Delay(500);
            SetEditText(hPrice, "" + price);
            NativeMethods.SendMessage(hPrice, NativeMethods.WM_KILLFOCUS, 0, 0);
            NativeMethods.SendMessage(hNum, NativeMethods.WM_SETFOCUS, 0, 0);
            Delay(500);
            SetRichEditText(hNum, "" + num);
            NativeMethods.SendMessage(hNum, NativeMethods.WM_KILLFOCUS, 0, 0);

            // 点击买入按钮
            ClickButton(hButton);
            Delay(500);
            WindowFinder finder = new WindowFinder(IntPtr.Zero, "TfrmDialogs", "确认");
            IntPtr hConfirmDlg = finder.FoundHandle;
            if (hConfirmDlg != IntPtr.Zero)
            {
                IntPtr hBtnYes = FindHwndInParentRecursive(hConfirmDlg, "TButton", "是(&Y)");
                IntPtr hBtnNo = FindHwndInParentRecursive(hConfirmDlg, "TButton", "否(&N)");

                string sCode = GetEditText(hCode);
                string sPrice = GetEditText(hPrice);
                string sNum = GetEditText(hNum);

                Log(LoggType.Red, "校验卖出单: " + sCode + ", 价格: " + sPrice + ", 数量: " + sNum);
                if (sCode == code && sPrice == "" + price && sNum == "" + num)
                {
                    ClickButton(hBtnYes);
                }
                else
                {
                    ClickButton(hBtnNo);
                }

            }
            */
        }


        public void CancelStock(string code, float price, int num)
        {
            MouseClickToolbar(hToolBar, 0);
            SelectTreeViewItem(hStockTree, hCancel);

        }

        public void TodayDealsList()
        {
            Log(LoggType.Black, "查询当日成交");

            MouseClickToolbar(hToolBar, 2);

            /*
            // 获取左侧功能菜单treeview 句柄
            WindowFinder finder = new WindowFinder(hMainWnd, "SysTreeView32", null);
            IntPtr treeParentHandle = finder.FoundParentHandle;
            IntPtr hTree = finder.FoundHandle;

            while (hTree != IntPtr.Zero)
            {
                int count = GetTreeViewItemCount(hTree);
                Log(LoggType.Black, "Tree菜单数量:" + count);
                if (count == 109)
                {
                    hStockTree = hTree;
                }
                else if (count == 39)
                {
                    hHkStockBtn = hTree;
                }
                if (hStockTree != IntPtr.Zero && hHkStockBtn != IntPtr.Zero)
                {
                    break;
                }
                hTree = FindHwndInParent(treeParentHandle, hTree, "TTreeView", null);
            }

            if (hStockTree == IntPtr.Zero)
            {
                Log(LoggType.Red, "没有找到金贝壳交易软件");
                return false;
            }
            if (hHkStockBtn == IntPtr.Zero)
            {
                Log(LoggType.Red, "没有找到金贝壳港股交易软件");
                return false;
            }

            InitMenuFuncHandler();
            InitHkMenuFuncHandler();
            */
        }

        public void HoldingStockList()
        {
            Log(LoggType.Black, "查询股票持仓");
            Log(LoggType.Red, "TAdvStringGrid控件还不能解析");
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TV_HITTESTINFO
        {
            /// <summary>Client coordinates of the point to test.</summary>
            public Point pt;
            /// <summary>Variable that receives information about the results of a hit test.</summary>
            public TVHit flags;
            /// <summary>Handle to the item that occupies the point.</summary>
            public IntPtr hItem;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref TV_HITTESTINFO lParam);
        int TVM_HITTEST = (0x1100 + 17);
        [Flags]
        public enum TVHit
        {
            /// <summary>In the client area, but below the last item.</summary>
            NoWhere = 0x0001,
            /// <summary>On the bitmap associated with an item.</summary>
            OnItemIcon = 0x0002,
            /// <summary>On the label (string) associated with an item.</summary>
            OnItemLabel = 0x0004,
            /// <summary>In the indentation associated with an item.</summary>
            OnItemIndent = 0x0008,
            /// <summary>On the button associated with an item.</summary>
            OnItemButton = 0x0010,
            /// <summary>In the area to the right of an item. </summary>
            OnItemRight = 0x0020,
            /// <summary>On the state icon for a tree-view item that is in a user-defined state.</summary>
            OnItemStateIcon = 0x0040,
            /// <summary>On the bitmap or label associated with an item. </summary>
            OnItem = (OnItemIcon | OnItemLabel | OnItemStateIcon),
            /// <summary>Above the client area. </summary>
            Above = 0x0100,
            /// <summary>Below the client area.</summary>
            Below = 0x0200,
            /// <summary>To the right of the client area.</summary>
            ToRight = 0x0400,
            /// <summary>To the left of the client area.</summary>
            ToLeft = 0x0800
        }

        protected new void SelectTreeViewItem(IntPtr hTreeView, IntPtr hItem)
        {
            SetFocus(hTreeView);

            base.SelectTreeViewItem(hTreeView, hItem);
            /*
            NativeMethods.RECT[] rec = new NativeMethods.RECT[1];
            if (GetTreeViewItemRECT(hTreeView, hItem, ref rec))
            {
                NativeMethods.RECT itemrect = rec[0];
                int fixedx = 10;
                int fixedy = 10;
                int x = itemrect.left + fixedx, y = itemrect.top + fixedy;

                NativeMethods.PostMessage(hTreeView, NativeMethods.WM_LBUTTONDOWN, 0x00000001, MAKELPARAM(x, y));

                Delay(5);

                NativeMethods.NMHDR nm;
                nm.hwndFrom = hTreeView;
                nm.idFrom = (uint)NativeMethods.GetDlgCtrlID(hTreeView);
                nm.code = NativeMethods.NM_CLICK;
                IntPtr hParent = NativeMethods.GetParent(hTreeView);
                NativeMethods.PostMessage(hParent, NativeMethods.WM_NOTIFY, (int)nm.idFrom, ref nm);

                TV_HITTESTINFO hitTestInfo = new TV_HITTESTINFO();
                hitTestInfo.pt = new Point(x, y);
                PostMessage(hTreeView, TVM_HITTEST, 0, ref hitTestInfo);

                Delay(5);

                NativeMethods.PostMessage(hTreeView, NativeMethods.WM_LBUTTONUP, 0x00000001, MAKELPARAM(x, y));
            }
            */


        }

        internal static string GetTreeViewItemText(IntPtr hTreeView, IntPtr itemHwnd)
        {
            NativeMethods.TVITEM tvItem = new NativeMethods.TVITEM();
            tvItem.mask = NativeMethods.TVIF_TEXT;
            tvItem.hItem = itemHwnd;
            tvItem.cchTextMax = 512;
            return SysTreeView32.GetTreeItemText(hTreeView, tvItem);
        }
    }
}
