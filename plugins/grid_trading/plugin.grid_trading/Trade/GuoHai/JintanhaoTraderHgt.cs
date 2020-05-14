using Dragonfly.Plugin.GridTrading.Strategy;
using Dragonfly.Plugin.GridTrading.Utils;
using Dragonfly.Plugin.GridTrading.Utils.Win32;
using System;
using System.Collections.Generic;


namespace Dragonfly.Plugin.GridTrading.Trade.GuoHai
{
    // 国海金叹号
    internal partial class JintanhaoTrader
    {
        public bool HgtBuyStock(string stockCode, decimal price, int volume)
        {
            Log(LoggType.Black, "购买：沪港通【" + stockCode + "】,价:" + price + ",量:" + volume);
            ClickTreeNode(hHkStockTree, hHkHgtBuy);

            IntPtr panel = WaitForHwnd.WaitForFindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null, 0x1B7F, "买入");
            if (panel == IntPtr.Zero)
            {
                throw new ApplicationException("不是买入下单页面");
            }

            IntPtr btnConfirm = WindowHwnd.GetDlgItem(panel, 0x1B7F);
            IntPtr hComboBoxType = WindowHwnd.GetDlgItem(panel, 0x1B67);
            IntPtr hEditCode = WindowHwnd.GetDlgItem(panel, 0x1B68);
            IntPtr hEditPrice = WindowHwnd.GetDlgItem(panel, 0x1B6B);
            IntPtr hEditVolume = WindowHwnd.GetDlgItem(panel, 0x1B77);

            if (hComboBoxType == IntPtr.Zero || hEditCode == IntPtr.Zero || hEditPrice == IntPtr.Zero || hEditVolume == IntPtr.Zero)
            {
                throw new ApplicationException("不是买入下单的控件页面");
            }

            SelectComboBox(hComboBoxType, HkOrderTimeType());
            WindowHwnd.SetFocus(hEditCode);
            Misc.Delay(1000);
            Misc.KeyboardPress(hEditCode, stockCode);
            WindowHwnd.SetFocus(hEditPrice);
            Misc.Delay(1000);
            Misc.KeyboardPress(hEditPrice, "" + price);
            WindowHwnd.SetFocus(hEditVolume);
            Misc.Delay(1000);
            Misc.KeyboardPress(hEditVolume, "" + volume);

            // 点击买入按钮
            Misc.Delay(500);
            WindowButton.Click(btnConfirm);
            return ConfirmOrder("买入", stockCode, price, volume, StockMarket.Hgt);

        }

        public bool HgtSellStock(string stockCode, decimal price, int volume)
        {
            Log(LoggType.Black, "卖出：沪港通【" + stockCode + "】,价:" + price + ",数:" + volume);
            ClickTreeNode(hHkStockTree, hHkHgtSell);

            IntPtr panel = WaitForHwnd.WaitForFindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null, 0x1B7F, "卖出");
            if (panel == IntPtr.Zero)
            {
                throw new ApplicationException("不是卖出下单页面");
            }

            IntPtr btnConfirm = WindowHwnd.GetDlgItem(panel, 0x1B7F);
            IntPtr hComboBoxType = WindowHwnd.GetDlgItem(panel, 0x1B67);
            IntPtr hEditCode = WindowHwnd.GetDlgItem(panel, 0x1B68);
            IntPtr hEditPrice = WindowHwnd.GetDlgItem(panel, 0x1B6B);
            IntPtr hEditVolume = WindowHwnd.GetDlgItem(panel, 0x1B77);

            if (hComboBoxType == IntPtr.Zero || hEditCode == IntPtr.Zero || hEditPrice == IntPtr.Zero || hEditVolume == IntPtr.Zero)
            {
                throw new ApplicationException("不是卖出下单的控件页面");
            }

            SelectComboBox(hComboBoxType, HkOrderTimeType());
            WindowHwnd.SetFocus(hEditCode);
            Misc.Delay(1000);
            Misc.KeyboardPress(hEditCode, stockCode);
            WindowHwnd.SetFocus(hEditPrice);
            Misc.Delay(1000);
            Misc.KeyboardPress(hEditPrice, "" + price);
            WindowHwnd.SetFocus(hEditVolume);
            Misc.Delay(1000);
            Misc.KeyboardPress(hEditVolume, "" + volume);

            // 点击买入按钮
            Misc.Delay(500);
            WindowButton.Click(btnConfirm);
            return ConfirmOrder("卖出", stockCode, price, volume, StockMarket.Hgt);

        }


        public List<ModelRevocableOrder> HgtRevocableOrders()
        {
            Log(LoggType.Black, "查询：沪港通可撤委托");
            ClickTreeNode(hHkStockTree, hHkHgtCancel);

            IntPtr panel = WaitForHwnd.WaitForFindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null, 0x1B87, "撤 单");
            if (panel == IntPtr.Zero)
            {
                throw new ApplicationException("不是撤单页面");
            }

            IntPtr hListView = WindowHwnd.GetDlgItem(panel, 0x0064);
            ClickMenuItem(hListView, 32820);
            return (List<ModelRevocableOrder>)ParseModelDataFromTxtFileAfterConfirDlg(ModelRevocableOrder.Parse);
        }

        public List<ModelTodayDeals> HgtTodayDealsList()
        {
            Log(LoggType.Black, "查询：沪港通当日成交");
            ClickTreeNode(hHkStockTree, hHkHgtTodayDeals);

            IntPtr panel = WaitForHwnd.WaitForFindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null, 4);
            if (panel == IntPtr.Zero)
            {
                throw new ApplicationException("不是当日成交页面");
            }

            IntPtr hOutputButton = WindowHwnd.GetDlgItem(panel, 0x1B84);
            if (!(NativeMethods.IsWindowVisible(hOutputButton) && NativeMethods.IsWindowEnabled(hOutputButton)))
            {
                Log(LoggType.Black, "沪港通：当日无成交（输出按钮不可用）");
                return null;
            }
            WindowButton.Click(hOutputButton);
            return (List<ModelTodayDeals>)ParseModelDataFromTxtFileAfterConfirDlg(ModelTodayDeals.Parse);
        }

        public List<ModelHoldingStock> HgtHoldingStockList()
        {
            Log(LoggType.Black, "查询：沪港通资金股份");
            ClickTreeNode(hHkStockTree, hHkHgtHoldingStock);

            IntPtr panel = WaitForHwnd.WaitForFindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null, 7);
            if (panel == IntPtr.Zero)
            {
                throw new ApplicationException("不是资金股份页面");
            }

            IntPtr hOutputButton = WindowHwnd.GetDlgItem(panel, 0x1B9C);
            if (!(NativeMethods.IsWindowVisible(hOutputButton) && NativeMethods.IsWindowEnabled(hOutputButton)))
            {
                Log(LoggType.Black, "沪港通资金股份 - 输出按钮不可用");
                return null;
            }
            WindowButton.Click(hOutputButton);
            return (List<ModelHoldingStock>)ParseModelDataFromTxtFileAfterConfirDlg(ModelHoldingStock.Parse);
        }


    }
}
