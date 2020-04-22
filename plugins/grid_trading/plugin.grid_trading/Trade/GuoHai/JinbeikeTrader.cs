﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Window;
using Dragonfly.Common.Utils;
using Dragonfly.Plugin.GridTrading.Utils;

namespace Dragonfly.Plugin.GridTrading.Trade.GuoHai
{
    // 国海金贝壳
    public class JinbeikeTrader : ITrader
    {
        IntPtr hWnd;    // 主窗口句柄
        IntPtr hStockTree;    // A股功能树形控件句柄
        IntPtr hHkStockTree;    // 港股通功能树形控件句柄

        // A股主功能菜单
        IntPtr hBuy, hSell, hBuyMarket, hSellMarket, hCancel;

        private void ClickTreeViewItem(IntPtr hTree, IntPtr hItem)
        {
            Win32API.SendMessage(hTree, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hItem);
        }

        private void InitMainFuncHandler()
        {
            hBuy = Win32API.SendMessage(hStockTree, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_ROOT, IntPtr.Zero);
            hSell = Win32API.SendMessage(hStockTree, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hBuy);
            hBuyMarket = Win32API.SendMessage(hStockTree, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hSell);
            hSellMarket = Win32API.SendMessage(hStockTree, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hBuyMarket);
            hCancel = Win32API.SendMessage(hStockTree, Win32Code.TVM_GETNEXTITEM, Win32Code.TVGN_NEXT, hSellMarket);
        }


        public bool Init()
        {
            hWnd = Win32API.FindWindow(null, @"金贝壳网上交易系统");

            // 获取左侧功能菜单treeview 句柄
            WindowFinder finder = new WindowFinder(hWnd, "TTreeView", string.Empty);
            hStockTree = finder.FoundHandle;
            if (hStockTree == IntPtr.Zero)
            {
                LoggerUtil.Log(LoggType.Red, "没有找到金贝壳交易软件");
                return false;
            }
            InitMainFuncHandler();

            hHkStockTree = Win32API.FindWindowEx(finder.FoundParentHandle, hStockTree, "TTreeView", string.Empty);

            LoggerUtil.Log(LoggType.Black, "关联金贝壳交易软件成功");
            return true;
        }
        
        public void SellStock(string code, float price, int num)
        {
            ClickTreeViewItem(hStockTree,hSell);
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
            ClickTreeViewItem(hStockTree, hBuy);
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
            ClickTreeViewItem(hStockTree, hCancel);
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
