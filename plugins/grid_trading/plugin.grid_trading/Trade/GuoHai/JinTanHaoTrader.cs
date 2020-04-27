using Dragonfly.Common.Utils;
using Dragonfly.Plugin.GridTrading.Utils;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Dragonfly.Plugin.GridTrading.Trade.GuoHai
{
    // 国海金叹号
    public class JinTanHaoTrader : AbstractTrader, ITrader
    {

        IntPtr hToolBar;
        // A股主功能菜单
        IntPtr hStockTree;    // A股功能树形控件句柄
        // 港股主功能菜单
        IntPtr hHkStockTree;    // 港股通功能树形控件句柄

        public bool Init()
        {
            if (!Init(@"TdxW_MainFrame_Class", null))
            {
                Log(LoggType.Red, "【国海金叹号网上交易系统】未启动");
                return false;
            }
            IntPtr h1 = FindHwndInParentRecursive(hMainWnd, null, "通达信网上交易V6");
            h1 = NativeMethods.GetDlgItem(h1, 0x00F5);

            IntPtr hp = h1;
            h1 = NativeMethods.GetDlgItem(h1, 0x0000);
            h1 = NativeMethods.FindWindowEx(hp, h1, "AfxWnd42", null);
            h1 = NativeMethods.FindWindowEx(hp, h1, "AfxWnd42", null);
            h1 = NativeMethods.GetDlgItem(h1, 0x0000); // h2 通达信网上交易V6#32770 (对话框)

            h1 = NativeMethods.GetDlgItem(hMainWnd, 0x0000); // Afx:58f0000:0:10003:0:0
            h1 = NativeMethods.GetDlgItem(h1, 0xE900); // mdi
            h1 = NativeMethods.GetDlgItem(h1, 0xE900);
            hToolBar = NativeMethods.GetDlgItem(h1, 0x00DD);

            if (hToolBar == IntPtr.Zero)
            {
                Log(LoggType.Red, "未找到选择股票市场工具条");
                return false;
            }

            Log(LoggType.Black, "关联金贝壳交易软件成功");

            return true;
        }

        public void BuyStock(string code, float price, int num)
        {
            Log(LoggType.Red, "购买股票: " + code + ", 价格: " + price + ", 数量: " + num);
            ChangeTabPage(NativeMethods.GetParent(hToolBar), hToolBar, 1);

            /*
            SelectTreeViewItem(hStockTree, hBuy);
            ClickButton(hStockBtn);

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

            ChangeTabPage(NativeMethods.GetParent(hToolBar), hToolBar, 3);
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

        }

        public void TodayDealsList()
        {
            Log(LoggType.Black, "查询当日成交");

            ChangeTabPage(hMainWnd, hToolBar, 1);
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
