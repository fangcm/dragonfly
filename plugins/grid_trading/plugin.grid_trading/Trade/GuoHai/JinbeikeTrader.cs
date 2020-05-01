using Dragonfly.Common.Utils;
using Dragonfly.Plugin.GridTrading.Utils;
using Dragonfly.Plugin.GridTrading.Utils.Win32;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Dragonfly.Plugin.GridTrading.Trade.GuoHai
{
    // 国海金贝壳
    public class JinbeikeTrader : AbstractTrader, ITrader
    {

        // A股主功能菜单
        IntPtr hStockBtn, hStockTree;    // A股功能树形控件句柄
        IntPtr hBuy, hSell, hCancel, hTodayDeals;

        // A股主功能菜单
        IntPtr hHkStockBtn, hHkStockTree;    // 港股通功能树形控件句柄
        IntPtr hHkHgtBuy, hHkHgtSell, hHkHgtCancel;
        IntPtr hSkHgtBuy, hSkHgtSell, hSkHgtCancel;

        public bool Init()
        {
            if (!Init(null, @"金贝壳网上交易系统"))
            {
                Log(LoggType.Red, "【金贝壳网上交易系统】未启动");
                return false;
            }

            hStockBtn = Window.FindHwndInParentRecursive(hMainWnd, "TButton", "股票");
            hHkStockBtn = Window.FindHwndInParentRecursive(hMainWnd, "TButton", "港股通");
            Button.Click(hStockBtn);
            Misc.Delay(500);
            Button.Click(hHkStockBtn);
            Misc.Delay(500);

            // 获取左侧功能菜单treeview 句柄
            WindowFinder finder = new WindowFinder(hMainWnd, "TTreeView", null);
            IntPtr treeParentHandle = finder.FoundParentHandle;
            IntPtr hTree = finder.FoundHandle;

            while (hTree != IntPtr.Zero)
            {
                int count = 0; // SysTreeView32.GetItemCount(hTree);
                Log(LoggType.Black, "Tree菜单数量:" + count);
                if (count == 109)
                {
                    hStockTree = hTree;
                }
                else if (count == 39)
                {
                    hHkStockTree = hTree;
                }
                if (hStockTree != IntPtr.Zero && hHkStockTree != IntPtr.Zero)
                {
                    break;
                }
                hTree = Window.FindHwndInParent(treeParentHandle, hTree, "TTreeView", null);
            }

            if (hStockTree == IntPtr.Zero)
            {
                Log(LoggType.Red, "没有找到金贝壳交易软件");
                return false;
            }
            if (hHkStockTree == IntPtr.Zero)
            {
                Log(LoggType.Red, "没有找到金贝壳港股交易软件");
                return false;
            }

            InitMenuFuncHandler();
            InitHkMenuFuncHandler();

            Log(LoggType.Black, "关联金贝壳交易软件成功");

            return true;
        }

        private void InitMenuFuncHandler()
        {
            IntPtr tmp;

            hBuy = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_ROOT, IntPtr.Zero);
            hSell = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, hBuy);
            tmp = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, hSell);
            tmp = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, tmp);
            hCancel = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, tmp);
            tmp = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, hCancel);
            tmp = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, tmp);
            tmp = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, tmp);
            // 科创板
            tmp = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, tmp);
            // 新股申购
            tmp = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, tmp);
            // 查询功能
            tmp = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, tmp);
            tmp = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_CHILD, tmp);
            hTodayDeals = Misc.ProxySendMessage(hStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, tmp);
        }

        private void InitHkMenuFuncHandler()
        {
            IntPtr tmp;

            hHkHgtBuy = Misc.ProxySendMessage(hHkStockTree, NativeMethods.TVM_GETNEXTITEM, 0, IntPtr.Zero);
            hHkHgtSell = Misc.ProxySendMessage(hHkStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, hHkHgtBuy);
            tmp = Misc.ProxySendMessage(hHkStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, hHkHgtSell);
            tmp = Misc.ProxySendMessage(hHkStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, tmp);
            hHkHgtCancel = Misc.ProxySendMessage(hHkStockTree, NativeMethods.TVM_GETNEXTITEM, NativeMethods.TVGN_NEXT, tmp);
        }

        public void BuyStock(string code, float price, int num)
        {
            Log(LoggType.Red, "购买股票: " + code + ", 价格: " + price + ", 数量: " + num);

            SysTreeView32.SelectItem(hStockTree, hBuy);
            Button.Click(hStockBtn);

            IntPtr hPanel = Window.FindHwndInParentRecursive(hMainWnd, "TFrmBuyStock", null);

            IntPtr hCode = IntPtr.Zero;
            IntPtr hPrice = IntPtr.Zero;
            IntPtr hNum = IntPtr.Zero;
            IntPtr hButton = IntPtr.Zero;

            IntPtr hChild = IntPtr.Zero;
            while (true)
            {
                hChild = Window.FindVisibleHwndInParent(hPanel, hChild, "TPanel", null);
                if (hChild == IntPtr.Zero)
                {
                    break;
                }


                IntPtr c = Window.FindVisibleHwndInParent(hChild, IntPtr.Zero, "TEdit", null);
                if (c == IntPtr.Zero)
                    continue;
                IntPtr p = Window.FindVisibleHwndInParent(hChild, IntPtr.Zero, "TStockComboBox", null);
                if (p == IntPtr.Zero)
                    continue;
                IntPtr n = Window.FindVisibleHwndInParent(hChild, IntPtr.Zero, "TBoundPriceEdit", null);
                if (n == IntPtr.Zero)
                    continue;
                IntPtr b = Window.FindVisibleHwndInParent(hChild, IntPtr.Zero, "TButton", "委托[F3]");
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

            RichEdit.SetText(hCode, code);
            Misc.Delay(500);
            EditBox.SetText(hPrice, "" + price);
            Misc.Delay(500);
            RichEdit.SetText(hNum, "" + num);

            // 点击买入按钮
            Button.Click(hButton);
            Misc.Delay(500);
            WindowFinder finder = new WindowFinder(IntPtr.Zero, "TfrmDialogs", "确认");
            IntPtr hConfirmDlg = finder.FoundHandle;
            if (hConfirmDlg != IntPtr.Zero)
            {
                IntPtr hBtnYes = Window.FindHwndInParentRecursive(hConfirmDlg, "TButton", "是(&Y)");
                IntPtr hBtnNo = Window.FindHwndInParentRecursive(hConfirmDlg, "TButton", "否(&N)");

                string sCode = RichEdit.GetText(hCode);
                string sPrice = EditBox.GetText(hPrice);
                string sNum = RichEdit.GetText(hNum);

                Log(LoggType.Red, "校验购买单: " + sCode + ", 价格: " + sPrice + ", 数量: " + sNum);
                if (sCode == code && sPrice == "" + price && sNum == "" + num)
                {
                    Button.Click(hBtnYes);
                }
                else
                {
                    Button.Click(hBtnNo);
                }

            }
        }

        public void SellStock(string code, float price, int num)
        {
            Log(LoggType.Red, "卖出股票: " + code + ", 价格: " + price + ", 数量: " + num);

            SysTreeView32.SelectItem(hStockTree, hSell);
            Button.Click(hStockBtn);

            IntPtr hPanel = Window.FindHwndInParentRecursive(hMainWnd, "Tfrm2007", null);

            IntPtr hCode = IntPtr.Zero;
            IntPtr hPrice = IntPtr.Zero;
            IntPtr hNum = IntPtr.Zero;
            IntPtr hButton = IntPtr.Zero;

            IntPtr hChild = IntPtr.Zero;
            while (true)
            {
                hChild = Window.FindVisibleHwndInParent(hPanel, hChild, "TPanel", null);
                if (hChild == IntPtr.Zero)
                {
                    break;
                }


                IntPtr c = Window.FindVisibleHwndInParent(hChild, IntPtr.Zero, "TEdit", null);
                if (c == IntPtr.Zero)
                    continue;
                IntPtr p = Window.FindVisibleHwndInParent(hChild, IntPtr.Zero, "TStockComboBox", null);
                if (p == IntPtr.Zero)
                    continue;
                IntPtr n = Window.FindVisibleHwndInParent(hChild, IntPtr.Zero, "TBoundPriceEdit", null);
                if (n == IntPtr.Zero)
                    continue;
                IntPtr b = Window.FindVisibleHwndInParent(hChild, IntPtr.Zero, "TButton", "委托[F3]");
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

            RichEdit.SetText(hCode, code);
            Misc.Delay(500);
            EditBox.SetText(hPrice, "" + price);
            Misc.Delay(500);
            RichEdit.SetText(hNum, "" + num);

            // 点击买入按钮
            Button.Click(hButton);
            Misc.Delay(500);
            WindowFinder finder = new WindowFinder(IntPtr.Zero, "TfrmDialogs", "确认");
            IntPtr hConfirmDlg = finder.FoundHandle;
            if (hConfirmDlg != IntPtr.Zero)
            {
                IntPtr hBtnYes = Window.FindHwndInParentRecursive(hConfirmDlg, "TButton", "是(&Y)");
                IntPtr hBtnNo = Window.FindHwndInParentRecursive(hConfirmDlg, "TButton", "否(&N)");

                string sCode = RichEdit.GetText(hCode);
                string sPrice = EditBox.GetText(hPrice);
                string sNum = RichEdit.GetText(hNum);

                Log(LoggType.Red, "校验卖出单: " + sCode + ", 价格: " + sPrice + ", 数量: " + sNum);
                if (sCode == code && sPrice == "" + price && sNum == "" + num)
                {
                    Button.Click(hBtnYes);
                }
                else
                {
                    Button.Click(hBtnNo);
                }

            }

        }


        public void CancelStock(string code, float price, int num)
        {
            SysTreeView32.SelectItem(hStockTree, hCancel);
            Button.Click(hStockBtn);
        }

        public void TodayDealsList()
        {
            Log(LoggType.Black, "查询当日成交");
            Log(LoggType.Red, "TAdvStringGrid控件还不能解析");
        }

        public void HoldingStockList()
        {
            Log(LoggType.Black, "查询股票持仓");
            Log(LoggType.Red, "TAdvStringGrid控件还不能解析");
        }

        /*
        protected new void SelectTreeViewItem(IntPtr hTreeView, IntPtr hItem)
        {
            base.SelectTreeViewItem(hTreeView, hItem);

            NativeMethods.RECT[] rec = new NativeMethods.RECT[1];
            if (GetTreeViewItemRECT(hTreeView, hItem, ref rec))
            {
                NativeMethods.RECT itemrect = rec[0];
                int fixedx = 50;
                int fixedy = 10;
                //MouseClick(hTreeView, itemrect.left + fixedx, itemrect.top + fixedy);
                IntPtr hParent = NativeMethods.GetParent(hTreeView);
                NativeMethods.SendMessage(hParent, NativeMethods.WM_PARENTNOTIFY, NativeMethods.WM_LBUTTONDOWN, MAKELPARAM(itemrect.left + fixedx, itemrect.top + fixedy));

            }
        }
        */

    }
}
