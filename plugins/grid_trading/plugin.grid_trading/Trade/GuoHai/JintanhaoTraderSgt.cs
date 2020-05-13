using Dragonfly.Plugin.GridTrading.Utils;
using Dragonfly.Plugin.GridTrading.Utils.Win32;
using System;
using System.Collections.Generic;


namespace Dragonfly.Plugin.GridTrading.Trade.GuoHai
{
    // 国海金叹号
    internal partial class JintanhaoTrader
    {
        public bool SgtBuyStock(string stockCode, decimal price, int volume)
        {
            Log(LoggType.Black, "购买：深港通【" + stockCode + "】,价:" + price + ",量:" + volume);
            ClickTreeNode(hHkStockTree, hHkSgtBuy);

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

        public bool SgtSellStock(string stockCode, decimal price, int volume)
        {
            Log(LoggType.Black, "卖出：深港通【" + stockCode + "】,价:" + price + ",数:" + volume);
            ClickTreeNode(hHkStockTree, hHkSgtSell);

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


        public List<ModelRevocableOrder> SgtRevocableOrders()
        {
            Log(LoggType.Black, "查询：深港通可撤委托");
            ClickTreeNode(hHkStockTree, hHkSgtCancel);

            IntPtr panel = WaitForHwnd.WaitForFindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null, 0x1B87, "撤 单");
            if (panel == IntPtr.Zero)
            {
                throw new ApplicationException("不是撤单页面");
            }

            IntPtr hOutputButton = WindowHwnd.GetDlgItem(panel, 0x047F);
            if (!(NativeMethods.IsWindowVisible(hOutputButton) && NativeMethods.IsWindowEnabled(hOutputButton)))
            {
                Log(LoggType.Red, "深港通：无可撤委托（输出按钮不可用）");
                return null;
            }
            WindowButton.Click(hOutputButton);
            return (List<ModelRevocableOrder>)ParseModelDataFromTxtFileAfterConfirDlg(ModelRevocableOrder.Parse);
        }

        public List<ModelTodayDeals> SgtTodayDealsList()
        {
            Log(LoggType.Black, "查询：深港通当日成交");
            ClickTreeNode(hHkStockTree, hHkSgtTodayDeals);

            IntPtr panel = WaitForHwnd.WaitForFindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null, 4);
            if (panel == IntPtr.Zero)
            {
                throw new ApplicationException("不是当日成交页面");
            }

            IntPtr hOutputButton = WindowHwnd.GetDlgItem(panel, 0x1B84);
            if (!(NativeMethods.IsWindowVisible(hOutputButton) && NativeMethods.IsWindowEnabled(hOutputButton)))
            {
                Log(LoggType.Black, "深港通：当日无成交（输出按钮不可用）");
                return null;
            }
            WindowButton.Click(hOutputButton);
            return (List<ModelTodayDeals>)ParseModelDataFromTxtFileAfterConfirDlg(ModelTodayDeals.Parse);
        }

        public List<ModelHoldingStock> SgtHoldingStockList()
        {
            Log(LoggType.Black, "查询：深港通资金股份");
            ClickTreeNode(hHkStockTree, hHkSgtHoldingStock);

            IntPtr panel = WaitForHwnd.WaitForFindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null, 7);
            if (panel == IntPtr.Zero)
            {
                throw new ApplicationException("不是资金股份页面");
            }

            IntPtr hOutputButton = WindowHwnd.GetDlgItem(panel, 0x1B9C);
            if (!(NativeMethods.IsWindowVisible(hOutputButton) && NativeMethods.IsWindowEnabled(hOutputButton)))
            {
                Log(LoggType.Black, "深港通资金股份 - 输出按钮不可用");
                return null;
            }
            WindowButton.Click(hOutputButton);
            return (List<ModelHoldingStock>)ParseModelDataFromTxtFileAfterConfirDlg(ModelHoldingStock.Parse);
        }


    }
}
