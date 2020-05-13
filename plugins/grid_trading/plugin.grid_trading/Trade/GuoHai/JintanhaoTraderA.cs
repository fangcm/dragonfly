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
            Log(LoggType.Black, "购买：A股【" + stockCode + "】,价:" + price + ",量:" + volume);
            ClickTreeNode(hStockTree, hBuy);

            IntPtr panel = WaitForHwnd.WaitForFindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null, 0x07DA, "买入下单");
            if (panel == IntPtr.Zero)
            {
                throw new ApplicationException("不是买入下单页面");
            }

            IntPtr btnConfirm = WindowHwnd.GetDlgItem(panel, 0x07DA);
            IntPtr hStaticMaxBuyVolume = WindowHwnd.GetDlgItem(panel, 0x07E6);
            IntPtr hEditCode = WindowHwnd.FindVisibleHwndInParent(panel, IntPtr.Zero, "AfxWnd42", null);
            IntPtr hEditPrice = WindowHwnd.GetDlgItem(panel, 0x2EE6);
            IntPtr hEditVolume = WindowHwnd.GetDlgItem(panel, 0x2EE7);

            if (hEditCode == IntPtr.Zero || hEditPrice == IntPtr.Zero || hEditVolume == IntPtr.Zero)
            {
                throw new ApplicationException("不是买入下单的控件页面");
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
            return ConfirmOrder("买入", stockCode, price, volume);

        }

        public bool SellStock(string stockCode, decimal price, int volume)
        {
            Log(LoggType.Black, "卖出：A股【" + stockCode + "】,价:" + price + ",数:" + volume);
            ClickTreeNode(hStockTree, hSell);

            IntPtr panel = WaitForHwnd.WaitForFindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null, 0x07DA, "卖出下单");
            if (panel == IntPtr.Zero)
            {
                throw new ApplicationException("不是卖出下单页面");
            }

            IntPtr btnConfirm = WindowHwnd.GetDlgItem(panel, 0x07DA);
            IntPtr hStaticMaxSellVolume = WindowHwnd.GetDlgItem(panel, 0x0811);
            IntPtr hEditCode = WindowHwnd.FindVisibleHwndInParent(panel, IntPtr.Zero, "AfxWnd42", null);
            IntPtr hEditPrice = WindowHwnd.GetDlgItem(panel, 0x2EE6);
            IntPtr hEditVolume = WindowHwnd.GetDlgItem(panel, 0x2EE7);

            if (hEditCode == IntPtr.Zero || hEditPrice == IntPtr.Zero || hEditVolume == IntPtr.Zero)
            {
                throw new ApplicationException("不是卖出下单的控件页面");
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
            return ConfirmOrder("卖出", stockCode, price, volume);

        }


        public List<ModelRevocableOrder> RevocableOrders()
        {
            Log(LoggType.Black, "查询：A股可撤委托");
            ClickTreeNode(hStockTree, hCancel);

            IntPtr panel = WaitForHwnd.WaitForFindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null, 0x0470, "撤 单");
            if (panel == IntPtr.Zero)
            {
                throw new ApplicationException("不是撤单页面");
            }
            IntPtr hOutputButton = WindowHwnd.GetDlgItem(panel, 0x047F);
            if (!(NativeMethods.IsWindowVisible(hOutputButton) && NativeMethods.IsWindowEnabled(hOutputButton)))
            {
                Log(LoggType.Black, "A股：无可撤委托（输出按钮不可用）");
                return null;
            }
            WindowButton.Click(hOutputButton);
            return (List<ModelRevocableOrder>)ParseModelDataFromTxtFileAfterConfirDlg(ModelRevocableOrder.Parse);

        }

        public List<ModelTodayDeals> TodayDealsList()
        {
            Log(LoggType.Black, "查询：A股当日成交");
            ClickTreeNode(hStockTree, hTodayDeals);

            IntPtr panel = WaitForHwnd.WaitForFindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null, 4);
            if (panel == IntPtr.Zero)
            {
                throw new ApplicationException("不是当日成交页面");
            }

            IntPtr hOutputButton = WindowHwnd.GetDlgItem(panel, 0x047F);
            if (!(NativeMethods.IsWindowVisible(hOutputButton) && NativeMethods.IsWindowEnabled(hOutputButton)))
            {
                Log(LoggType.Black, "A股：当日无成交（输出按钮不可用）");
                return null;
            }
            WindowButton.Click(hOutputButton);
            return (List<ModelTodayDeals>)ParseModelDataFromTxtFileAfterConfirDlg(ModelTodayDeals.Parse);
        }

        public List<ModelHoldingStock> HoldingStockList()
        {
            Log(LoggType.Black, "查询：A股资金股份");
            ClickTreeNode(hStockTree, hHoldingStock);

            IntPtr panel = WaitForHwnd.WaitForFindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null, 0x06BB, "修改成本");
            if (panel == IntPtr.Zero)
            {
                throw new ApplicationException("A股资金股份 - 不是该页面");
            }

            IntPtr hOutputButton = WindowHwnd.GetDlgItem(panel, 0x047F);
            if (!(NativeMethods.IsWindowVisible(hOutputButton) && NativeMethods.IsWindowEnabled(hOutputButton)))
            {
                Log(LoggType.Black, "A股：资金股份输出按钮不可用");
                return null;
            }

            WindowButton.Click(hOutputButton);
            return (List<ModelHoldingStock>)ParseModelDataFromTxtFileAfterConfirDlg(ModelHoldingStock.Parse);
        }


    }
}
