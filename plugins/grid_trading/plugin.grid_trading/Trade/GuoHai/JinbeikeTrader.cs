using Dragonfly.Common.Utils;
using Dragonfly.Plugin.GridTrading.Utils;
using System;
using System.Runtime.InteropServices;

namespace Dragonfly.Plugin.GridTrading.Trade.GuoHai
{
    // 国海金贝壳
    public class JinbeikeTrader : AbstractTrader, ITrader
    {

        // A股主功能菜单
        IntPtr hStockBtn, hStockTree;    // A股功能树形控件句柄
        IntPtr hBuy, hSell, hCancel;

        // A股主功能菜单
        IntPtr hHkStockBtn, hHkStockTree;    // 港股通功能树形控件句柄
        IntPtr hHkHgtBuy, hHkHgtSell, hHkHgtCancel;
        IntPtr hSkHgtBuy, hSkHgtSell, hSkHgtCancel;

        public bool Init()
        {
            if (!Init(@"金贝壳网上交易系统"))
            {
                Log(LoggType.Red, "【金贝壳网上交易系统】未启动");
                return false;
            }

            hStockBtn = FindHwndInApp("TButton", "股票");
            hHkStockBtn = FindHwndInApp("TButton", "港股通");
            ClickButton(hStockBtn);
            ClickButton(hHkStockBtn);

            // 获取左侧功能菜单treeview 句柄
            WindowFinder finder = new WindowFinder(hMainWnd, "TTreeView", string.Empty);
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
                hTree = GetHwnd(treeParentHandle, hTree, "TTreeView", string.Empty);
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

            Log(LoggType.Black, "关联金贝壳交易软件成功");

            return true;
        }

        private void InitMenuFuncHandler()
        {
            hBuy = (IntPtr)Interop.SendMessage(hStockTree, Interop.TVM_GETNEXTITEM, 0, IntPtr.Zero);
            hSell = (IntPtr)Interop.SendMessage(hStockTree, Interop.TVM_GETNEXTITEM, Interop.TVGN_NEXT, hBuy);
            IntPtr hBuyMarket = (IntPtr)Interop.SendMessage(hStockTree, Interop.TVM_GETNEXTITEM, Interop.TVGN_NEXT, hSell);
            IntPtr hSellMarket = (IntPtr)Interop.SendMessage(hStockTree, Interop.TVM_GETNEXTITEM, Interop.TVGN_NEXT, hBuyMarket);
            hCancel = (IntPtr)Interop.SendMessage(hStockTree, Interop.TVM_GETNEXTITEM, Interop.TVGN_NEXT, hSellMarket);
        }

        private void InitHkMenuFuncHandler()
        {
            hHkHgtBuy = (IntPtr)Interop.SendMessage(hHkStockTree, Interop.TVM_GETNEXTITEM, 0, IntPtr.Zero);
            hHkHgtSell = (IntPtr)Interop.SendMessage(hHkStockTree, Interop.TVM_GETNEXTITEM, Interop.TVGN_NEXT, hHkHgtBuy);
            IntPtr hBuyMarket = (IntPtr)Interop.SendMessage(hHkStockTree, Interop.TVM_GETNEXTITEM, Interop.TVGN_NEXT, hHkHgtSell);
            IntPtr hSellMarket = (IntPtr)Interop.SendMessage(hHkStockTree, Interop.TVM_GETNEXTITEM, Interop.TVGN_NEXT, hBuyMarket);
            hHkHgtCancel = (IntPtr)Interop.SendMessage(hHkStockTree, Interop.TVM_GETNEXTITEM, Interop.TVGN_NEXT, hSellMarket);
        }

        public void SellStock(string code, float price, int num)
        {
            SelectTreeViewItem(hStockTree, hSell);
            ClickButton(hStockBtn);
            /*
                        const int BUY_TXT_CODE = 0x0408;
                        const int BUY_TXT_PRICE = 0x0409;
                        const int BUY_TXT_NUM = 0x040A;
                        const int BUY_BTN_OK = 0x3EE;

                        // 设定代码,价格,数量
                        IntPtr hPanel = GetDetailPanel();
                        IntPtr hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_CODE);
                        Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, code);
                        hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_PRICE);
                        Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, price.ToString());
                        hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_NUM);
                        Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, num.ToString());

                        // 点击买入按钮
                        hCtrl = Win32API.GetDlgItem(hPanel, BUY_BTN_OK);
                        Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONDOWN, 0, 0);
                        Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONUP, 0, 0);
            */
        }

        public void BuyStock(string code, float price, int num)
        {
            SelectTreeViewItem(hStockTree, hBuy);
            ClickButton(hStockBtn);
            /*
                        const int BUY_TXT_CODE = 0x0408;
                        const int BUY_TXT_PRICE = 0x0409;
                        const int BUY_TXT_NUM = 0x040A;
                        const int BUY_BTN_OK = 0x3EE;


                        // 设定代码,价格,数量
                        IntPtr hPanel = GetDetailPanel();
                        IntPtr hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_CODE);
                        Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, code);
                        hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_PRICE);
                        Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, price.ToString());
                        hCtrl = Win32API.GetDlgItem(hPanel, BUY_TXT_NUM);
                        Win32API.SendMessage(hCtrl, Win32Code.WM_SETTEXT, 0, num.ToString());

                        // 点击买入按钮
                        hCtrl = Win32API.GetDlgItem(hPanel, BUY_BTN_OK);
                        Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONDOWN, 0, 0);
                        Win32API.SendMessage(hCtrl, Win32Code.WM_LBUTTONUP, 0, 0);
            */
        }

        public void CancelStock(string code, float price, int num)
        {
            SelectTreeViewItem(hStockTree, hCancel);
            ClickButton(hStockBtn);
        }

        public void TodayDealsList()
        {
            throw new NotImplementedException();
        }

        public void HoldingStockList()
        {
            throw new NotImplementedException();
        }

        public void CashInfo()
        {
            /*
            Win32API.SendMessage(htvi, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hQueryZjgp);

            // TODO:发送复制命令,这里不能正常复制
            IntPtr list = GetPositonList();
            Win32API.SendMessage(list, Win32Code.WM_LBUTTONDOWN, 0, 0);
            Win32API.SendMessage(list, Win32Code.WM_LBUTTONUP, 0, 0);
            Win32API.SendMessage(list, Win32Code.WM_SETFOCUS, 0, 0);
            //Win32API.SendMessage(list, Win32Code.WM_RENDERFORMAT, Win32Code.CF_UNICODETEXT, 0);

            // Win32API.SendMessage(new IntPtr(0x00270bb2), Win32Code.WM_RENDERFORMAT, Win32Code.CF_UNICODETEXT, 0);

            Win32API.SendMessage(list, Win32Code.WM_KEYDOWN, Win32Code.VK_CONTROL, 0);
            Win32API.SendMessage(list, Win32Code.WM_KEYDOWN, Win32Code.VK_C, 0);
            Win32API.SendMessage(list, Win32Code.WM_CHAR, Win32Code.VK_C, 0);
            Win32API.SendMessage(list, Win32Code.WM_KEYUP, Win32Code.VK_C, 0);
            Win32API.SendMessage(list, Win32Code.WM_KEYUP, Win32Code.VK_CONTROL, 0);
            */
        }


    }
}
