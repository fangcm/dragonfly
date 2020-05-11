using Dragonfly.Plugin.GridTrading.Utils;
using Dragonfly.Plugin.GridTrading.Utils.Win32;
using System;
using System.Collections.Generic;


namespace Dragonfly.Plugin.GridTrading.Trade.GuoHai
{
    // 国海金叹号
    internal partial class JintanhaoTrader : AbstractTrader, ITrader
    {

        public bool BuyStock(string stockCode, decimal price, int volume)
        {
            if (hStockTree == IntPtr.Zero || hBuy == IntPtr.Zero)
            {
                return false;
            }

            Log(LoggType.Red, "A股购买股票: " + stockCode + ", 价格: " + price + ", 数量: " + volume);
            MouseClickToolbar(hToolBar, 0);
            //WindowTreeView.SelectItem(hStockTree, hBuy);
            WindowTreeView.SimulateClick(hStockTree, hBuy);
            Misc.Delay(1000);


            IntPtr panel = WindowHwnd.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr btnConfirm = WindowHwnd.GetDlgItem(panel, 0x07DA);
            if (btnConfirm == IntPtr.Zero || WindowHwnd.GetWindowText(btnConfirm) != "买入下单")
            {
                Log(LoggType.Black, "不是买入下单页面");
                return false;
            }

            IntPtr hStaticMaxBuyVolume = WindowHwnd.GetDlgItem(panel, 0x07E6);
            IntPtr hEditCode = WindowHwnd.FindVisibleHwndInParent(panel, IntPtr.Zero, "AfxWnd42", null);
            IntPtr hEditPrice = WindowHwnd.GetDlgItem(panel, 0x2EE6);
            IntPtr hEditVolume = WindowHwnd.GetDlgItem(panel, 0x2EE7);

            if (hEditCode == IntPtr.Zero || hEditPrice == IntPtr.Zero || hEditVolume == IntPtr.Zero)
            {
                Log(LoggType.Red, "不是买入下单的控件页面");
                return false;
            }

            WindowHwnd.SetFocus(hEditCode);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditCode, stockCode);
            WindowHwnd.SetFocus(hEditPrice);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditPrice, "" + price);
            WindowHwnd.SetFocus(hEditVolume);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditVolume, "" + volume);

            // 点击买入按钮
            Misc.Delay(500);
            WindowButton.Click(btnConfirm);
            Misc.Delay(500);

            return ConfirmOrder("买入", stockCode, price, volume);

        }

        public bool SellStock(string stockCode, decimal price, int volume)
        {
            if (hStockTree == IntPtr.Zero || hSell == IntPtr.Zero)
            {
                return false;
            }

            Log(LoggType.Red, "A股卖出股票: " + stockCode + ", 价格: " + price + ", 数量: " + volume);
            MouseClickToolbar(hToolBar, 0);
            //WindowTreeView.SelectItem(hStockTree, hSell);
            WindowTreeView.SimulateClick(hStockTree, hSell);
            Misc.Delay(1000);


            IntPtr panel = WindowHwnd.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr btnConfirm = WindowHwnd.GetDlgItem(panel, 0x07DA);
            if (btnConfirm == IntPtr.Zero || WindowHwnd.GetWindowText(btnConfirm) != "卖出下单")
            {
                Log(LoggType.Black, "不是卖出下单页面");
                return false;
            }

            IntPtr hStaticMaxSellVolume = WindowHwnd.GetDlgItem(panel, 0x0811);
            IntPtr hEditCode = WindowHwnd.FindVisibleHwndInParent(panel, IntPtr.Zero, "AfxWnd42", null);
            IntPtr hEditPrice = WindowHwnd.GetDlgItem(panel, 0x2EE6);
            IntPtr hEditVolume = WindowHwnd.GetDlgItem(panel, 0x2EE7);

            if (hEditCode == IntPtr.Zero || hEditPrice == IntPtr.Zero || hEditVolume == IntPtr.Zero)
            {
                Log(LoggType.Red, "不是卖出下单的控件页面");
                return false;
            }

            WindowHwnd.SetFocus(hEditCode);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditCode, stockCode);
            WindowHwnd.SetFocus(hEditPrice);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditPrice, "" + price);
            WindowHwnd.SetFocus(hEditVolume);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditVolume, "" + volume);

            // 点击买入按钮
            Misc.Delay(500);
            WindowButton.Click(btnConfirm);
            Misc.Delay(500);

            return ConfirmOrder("卖出", stockCode, price, volume);

        }


        public List<ModelRevocableOrder> RevocableOrders()
        {
            if (hStockTree == IntPtr.Zero || hCancel == IntPtr.Zero)
            {
                return null;
            }

            Log(LoggType.Red, "A股可撤委托");
            MouseClickToolbar(hToolBar, 0);
            //WindowTreeView.SelectItem(hStockTree, hCancel);
            WindowTreeView.SimulateClick(hStockTree, hCancel);

            Misc.Delay(1000);


            IntPtr panel = WindowHwnd.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr hOutputButton = WindowHwnd.GetDlgItem(panel, 0x047F);
            if (!(NativeMethods.IsWindowVisible(hOutputButton) && NativeMethods.IsWindowEnabled(hOutputButton)))
            {
                Log(LoggType.Red, "A股可撤委托 - 无可撤单（输出按钮不可用）");
                return null;
            }
            WindowButton.Click(hOutputButton);
            return (List<ModelRevocableOrder>)ParseModelDataFromTxtFileAfterConfirDlg(ModelRevocableOrder.Parse);

        }

        public List<ModelTodayDeals> TodayDealsList()
        {
            if (hStockTree == IntPtr.Zero || hTodayDeals == IntPtr.Zero)
            {
                return null;
            }

            Log(LoggType.Black, "A股当日成交");
            MouseClickToolbar(hToolBar, 0);
            //WindowTreeView.SelectItem(hStockTree, hTodayDeals);
            WindowTreeView.SimulateClick(hStockTree, hTodayDeals);

            Misc.Delay(1000);


            IntPtr panel = WindowHwnd.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr hOutputButton = WindowHwnd.GetDlgItem(panel, 0x047F);
            if (!(NativeMethods.IsWindowVisible(hOutputButton) && NativeMethods.IsWindowEnabled(hOutputButton)))
            {
                Log(LoggType.Red, "A股当日成交 - 无成交（输出按钮不可用）");
                return null;
            }
            WindowButton.Click(hOutputButton);
            return (List<ModelTodayDeals>)ParseModelDataFromTxtFileAfterConfirDlg(ModelTodayDeals.Parse);
        }

        public List<ModelHoldingStock> HoldingStockList()
        {
            if (hStockTree == IntPtr.Zero || hHoldingStock == IntPtr.Zero)
            {
                return null;
            }

            Log(LoggType.Black, "A股资金股份");
            MouseClickToolbar(hToolBar, 0);
            //WindowTreeView.SelectItem(hStockTree, hHoldingStock);
            WindowTreeView.SimulateClick(hStockTree, hHoldingStock);
            Misc.Delay(1000);


            IntPtr panel = WindowHwnd.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr btnConfirm = WindowHwnd.GetDlgItem(panel, 0x06BB);
            if (btnConfirm == IntPtr.Zero || WindowHwnd.GetWindowText(btnConfirm) != "修改成本")
            {
                Log(LoggType.Black, "A股资金股份 - 不是该页面");
                return null;
            }


            IntPtr hOutputButton = WindowHwnd.GetDlgItem(panel, 0x047F);
            if (!(NativeMethods.IsWindowVisible(hOutputButton) && NativeMethods.IsWindowEnabled(hOutputButton)))
            {
                Log(LoggType.Red, "A股资金股份 - 输出按钮不可用");
                return null;
            }

            WindowButton.Click(hOutputButton);
            return (List<ModelHoldingStock>)ParseModelDataFromTxtFileAfterConfirDlg(ModelHoldingStock.Parse);
        }


    }
}
