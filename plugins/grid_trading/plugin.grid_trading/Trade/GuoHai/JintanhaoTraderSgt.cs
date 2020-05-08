using Dragonfly.Plugin.GridTrading.Utils;
using Dragonfly.Plugin.GridTrading.Utils.Win32;
using System;
using System.Collections.Generic;


namespace Dragonfly.Plugin.GridTrading.Trade.GuoHai
{
    // 国海金叹号
    internal partial class JintanhaoTrader
    {
        public void SgtBuyStock(string stockCode, decimal price, int volume)
        {
            if (hHkStockTree == IntPtr.Zero || hHkSgtBuy == IntPtr.Zero)
            {
                return;
            }

            Log(LoggType.Red, "深港通购买股票: " + stockCode + ", 价格: " + price + ", 数量: " + volume);
            MouseClickToolbar(hToolBar, 0);
            //WindowTreeView.SelectItem(hHkStockTree, hHkSgtBuy);
            WindowTreeView.SimulateClick(hHkStockTree, hHkSgtBuy);
            Misc.Delay(1000);


            IntPtr panel = WindowHwnd.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr btnConfirm = WindowHwnd.GetDlgItem(panel, 0x07DA);
            if (btnConfirm == IntPtr.Zero || WindowHwnd.GetWindowText(btnConfirm) != "买入下单")
            {
                Log(LoggType.Black, "不是买入下单页面");
                return;
            }

            IntPtr hStaticMaxBuyVolume = WindowHwnd.GetDlgItem(panel, 0x07E6);
            IntPtr hEditCode = WindowHwnd.FindVisibleHwndInParent(panel, IntPtr.Zero, "AfxWnd42", null);
            IntPtr hEditPrice = WindowHwnd.GetDlgItem(panel, 0x2EE6);
            IntPtr hEditVolume = WindowHwnd.GetDlgItem(panel, 0x2EE7);

            if (hEditCode == IntPtr.Zero || hEditPrice == IntPtr.Zero || hEditVolume == IntPtr.Zero)
            {
                Log(LoggType.Red, "不是买入下单的控件页面");
                return;
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

            string maxBuyVolume = WindowStatic.GetText(hStaticMaxBuyVolume);
            if (maxBuyVolume != null && maxBuyVolume.Length > 0)
            {
                int maxVolume = int.Parse(maxBuyVolume);
                if (maxVolume < volume)
                {
                    Log(LoggType.Red, "资金不足，不能购买");
                    return;
                }
            }

            WindowButton.Click(btnConfirm);
            Misc.Delay(500);

            IntPtr hConfirmDlg = WindowHwnd.FindHwndInParentRecursive(IntPtr.Zero, "#32770", "买入交易确认", true);
            if (hConfirmDlg != IntPtr.Zero)
            {
                IntPtr hBtnYes = WindowHwnd.FindHwndInParentRecursive(hConfirmDlg, "Button", "买入确认");
                IntPtr hBtnNo = WindowHwnd.FindHwndInParentRecursive(hConfirmDlg, "Button", "取消");

                IntPtr hStaticConfirm = WindowHwnd.GetDlgItem(hConfirmDlg, 0x1B65);
                string txtConfirm = WindowHwnd.GetWindowText(hStaticConfirm);

                Dictionary<string, string> patten = new Dictionary<string, string>();
                patten["操作类别"] = @"^买入$";
                patten["股票代码"] = @"^" + stockCode;
                patten["委托价格"] = @"^" + price.ToString().Replace(".", "\\.");
                patten["委托数量"] = @"^" + volume + "股";
                patten["委托方式"] = "限价委托";
                if (ValidateTipText(txtConfirm, patten))
                {
                    Log(LoggType.Gray, "校验提示正常: " + txtConfirm.Replace('\n', ' '));
                    WindowButton.Click(hBtnYes);

                }
                else
                {
                    Log(LoggType.Red, "校验提示异常: " + txtConfirm.Replace('\n', ' '));
                    WindowButton.Click(hBtnNo);
                }
            }
            else
            {
                Log(LoggType.Red, "没有检测到卖出确认对话框");
            }

        }

        public void SgtSellStock(string stockCode, decimal price, int volume)
        {
            if (hHkStockTree == IntPtr.Zero || hHkSgtSell == IntPtr.Zero)
            {
                return;
            }


            Log(LoggType.Red, "深港通卖出股票: " + stockCode + ", 价格: " + price + ", 数量: " + volume);
            MouseClickToolbar(hToolBar, 0);
            //WindowTreeView.SelectItem(hHkStockTree, hHkSgtSell);
            WindowTreeView.SimulateClick(hHkStockTree, hHkSgtSell);
            Misc.Delay(1000);


            IntPtr panel = WindowHwnd.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr btnConfirm = WindowHwnd.GetDlgItem(panel, 0x07DA);
            if (btnConfirm == IntPtr.Zero || WindowHwnd.GetWindowText(btnConfirm) != "卖出下单")
            {
                Log(LoggType.Black, "不是卖出下单页面");
                return;
            }

            IntPtr hStaticMaxSellVolume = WindowHwnd.GetDlgItem(panel, 0x0811);
            IntPtr hEditCode = WindowHwnd.FindVisibleHwndInParent(panel, IntPtr.Zero, "AfxWnd42", null);
            IntPtr hEditPrice = WindowHwnd.GetDlgItem(panel, 0x2EE6);
            IntPtr hEditVolume = WindowHwnd.GetDlgItem(panel, 0x2EE7);

            if (hEditCode == IntPtr.Zero || hEditPrice == IntPtr.Zero || hEditVolume == IntPtr.Zero)
            {
                Log(LoggType.Red, "不是卖出下单的控件页面");
                return;
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
            string maxSellVolume = WindowStatic.GetText(hStaticMaxSellVolume);
            if (maxSellVolume != null && maxSellVolume.Length > 0)
            {
                int maxVolume = int.Parse(maxSellVolume);
                if (maxVolume < volume)
                {
                    Log(LoggType.Red, "股票不足，不能卖出");
                    return;
                }
            }

            WindowButton.Click(btnConfirm);
            Misc.Delay(500);

            IntPtr hConfirmDlg = WindowHwnd.FindHwndInParentRecursive(IntPtr.Zero, "#32770", "卖出交易确认", true);
            if (hConfirmDlg != IntPtr.Zero)
            {
                IntPtr hBtnYes = WindowHwnd.FindHwndInParentRecursive(hConfirmDlg, "Button", "卖出确认");
                IntPtr hBtnNo = WindowHwnd.FindHwndInParentRecursive(hConfirmDlg, "Button", "取消");

                IntPtr hStaticConfirm = WindowHwnd.GetDlgItem(hConfirmDlg, 0x1B65);
                string txtConfirm = WindowHwnd.GetWindowText(hStaticConfirm);

                Dictionary<string, string> patten = new Dictionary<string, string>();
                patten["操作类别"] = @"^卖出$";
                patten["股票代码"] = @"^" + stockCode;
                patten["委托价格"] = @"^" + price.ToString().Replace(".", "\\.");
                patten["委托数量"] = @"^" + volume + "股";
                patten["委托方式"] = "限价委托";
                if (ValidateTipText(txtConfirm, patten))
                {
                    Log(LoggType.Gray, "校验提示正常: " + txtConfirm.Replace('\n', ' '));
                    WindowButton.Click(hBtnYes);

                }
                else
                {
                    Log(LoggType.Red, "校验提示异常: " + txtConfirm.Replace('\n', ' '));
                    WindowButton.Click(hBtnNo);
                }
            }
            else
            {
                Log(LoggType.Red, "没有检测到卖出确认对话框");
            }
        }


        public List<ModelRevocableOrder> SgtRevocableOrders()
        {
            if (hHkStockTree == IntPtr.Zero || hHkSgtCancel == IntPtr.Zero)
            {
                return null;
            }

            Log(LoggType.Red, "深港通可撤委托");
            MouseClickToolbar(hToolBar, 0);
            //WindowTreeView.SelectItem(hHkStockTree, hHkSgtCancel);
            WindowTreeView.SimulateClick(hHkStockTree, hHkSgtCancel);

            Misc.Delay(1000);


            IntPtr panel = WindowHwnd.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr hOutputButton = WindowHwnd.GetDlgItem(panel, 0x047F);
            if (!(NativeMethods.IsWindowVisible(hOutputButton) && NativeMethods.IsWindowEnabled(hOutputButton)))
            {
                Log(LoggType.Red, "深港通可撤委托 - 无可撤单（输出按钮不可用）");
                return null;
            }
            WindowButton.Click(hOutputButton);
            return (List<ModelRevocableOrder>)ParseModelDataFromTxtFileAfterConfirDlg(ModelRevocableOrder.Parse);
        }

        public List<ModelTodayDeals> SgtTodayDealsList()
        {
            if (hHkStockTree == IntPtr.Zero || hHkSgtTodayDeals == IntPtr.Zero)
            {
                return null;
            }

            Log(LoggType.Black, "深港通当日成交");
            MouseClickToolbar(hToolBar, 0);
            //WindowTreeView.SelectItem(hHkStockTree, hHkSgtTodayDeals);
            WindowTreeView.SimulateClick(hHkStockTree, hHkSgtTodayDeals);

            Misc.Delay(1000);


            IntPtr panel = WindowHwnd.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr hOutputButton = WindowHwnd.GetDlgItem(panel, 0x047F);
            if (!(NativeMethods.IsWindowVisible(hOutputButton) && NativeMethods.IsWindowEnabled(hOutputButton)))
            {
                Log(LoggType.Red, "深港通当日成交 - 无成交（输出按钮不可用）");
                return null;
            }
            WindowButton.Click(hOutputButton);
            return (List<ModelTodayDeals>)ParseModelDataFromTxtFileAfterConfirDlg(ModelTodayDeals.Parse);
        }

        public List<ModelHoldingStock> SgtHoldingStockList()
        {
            if (hHkStockTree == IntPtr.Zero || hHkSgtHoldingStock == IntPtr.Zero)
            {
                return null;
            }

            Log(LoggType.Black, "深港通资金股份");
            MouseClickToolbar(hToolBar, 0);
            //WindowTreeView.SelectItem(hHkStockTree, hHkSgtHoldingStock);
            WindowTreeView.SimulateClick(hHkStockTree, hHkSgtHoldingStock);
            Misc.Delay(1000);


            IntPtr panel = WindowHwnd.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr btnConfirm = WindowHwnd.GetDlgItem(panel, 0x06BB);
            if (btnConfirm == IntPtr.Zero || WindowHwnd.GetWindowText(btnConfirm) != "修改成本")
            {
                Log(LoggType.Black, "深港通资金股份 - 不是该页面");
                return null;
            }


            IntPtr hOutputButton = WindowHwnd.GetDlgItem(panel, 0x047F);
            if (!(NativeMethods.IsWindowVisible(hOutputButton) && NativeMethods.IsWindowEnabled(hOutputButton)))
            {
                Log(LoggType.Red, "深港通资金股份 - 输出按钮不可用");
                return null;
            }
            WindowButton.Click(hOutputButton);
            return (List<ModelHoldingStock>)ParseModelDataFromTxtFileAfterConfirDlg(ModelHoldingStock.Parse);
        }


    }
}
