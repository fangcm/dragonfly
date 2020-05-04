using Dragonfly.Common.Utils;
using Dragonfly.Plugin.GridTrading.Utils;
using Dragonfly.Plugin.GridTrading.Utils.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Automation;


namespace Dragonfly.Plugin.GridTrading.Trade.GuoHai
{
    // 国海金叹号
    internal class JintanhaoTrader : AbstractTrader, ITrader
    {
        IntPtr afxWind42DetailPanel;
        IntPtr hToolBar;
        // A股主功能菜单
        IntPtr hStockTree;    // A股功能树形控件句柄
        IntPtr hBuy, hSell, hCancel, hTodayDeals, hHoldingStock;
        // 港股主功能菜单
        IntPtr hHkStockTree;    // 港股通功能树形控件句柄
        IntPtr hHkHgtBuy, hHkHgtSell, hHkHgtCancel, hHkHgtTodayDeals, hHkHgtHoldingStock;
        IntPtr hHkSgtBuy, hHkSgtSell, hHkSgtCancel, hHkSgtTodayDeals, hHkSgtHoldingStock;

        public bool Init()
        {
            if (!Init("TdxW_MainFrame_Class", null))
            {
                Log(LoggType.Red, "【国海金叹号网上交易系统】未启动");
                return false;
            }
            hMainWnd = WindowHwnd.FindHwndInParentRecursive(hMainWnd, null, @"通达信网上交易V6");
            IntPtr afxMDIFrame = WindowHwnd.FindHwndInParentRecursive(hMainWnd, "AfxMDIFrame42", null);
            IntPtr afxWind42TreePanel = WindowHwnd.GetDlgItem(afxMDIFrame, 0xE900);
            afxWind42DetailPanel = WindowHwnd.GetDlgItem(afxMDIFrame, 0xE901);

            hToolBar = WindowHwnd.GetDlgItem(afxWind42TreePanel, 0x00DD);

            if (hToolBar == IntPtr.Zero)
            {
                Log(LoggType.Red, "未找到选择股票市场工具条");
                return false;
            }

            // 获取左侧功能菜单treeview 句柄
            hStockTree = WindowHwnd.GetDlgItem(hToolBar, 0xE900);
            hHkStockTree = WindowHwnd.GetDlgItem(hToolBar, 0xE903);

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

            if (!InitStockTreeViewItemHandler())
            {
                Log(LoggType.Red, "初始化A股菜单树失败");
                return false;
            }
            if (!InitHKStockTreeViewItemHandler())
            {
                Log(LoggType.Red, "初始化港股通菜单树失败");
                return false;
            }

            Log(LoggType.Black, "关联金叹号交易软件成功");

            return true;
        }

        private static void MouseClickToolbar(IntPtr hToolBar, int index)
        {
            NativeMethods.Win32Rect rect = new NativeMethods.Win32Rect();
            NativeMethods.GetWindowRect(hToolBar, ref rect);

            int x = 10 + (rect.right - rect.left) / 3 * index;
            int y = 10;

            Misc.SimulateClick(hToolBar, x, y);
        }

        private bool InitStockTreeViewItemHandler()
        {
            var items = WindowTreeView.GetAllItems(hStockTree);
            if (items.Count != 23)
            {
                Log(LoggType.Black, "A股菜单树菜单个数不一致");
                return false;
            }

            WindowTreeView.TreeItemNode node, child;

            node = items.Find((WindowTreeView.TreeItemNode n) => n.Text == "买入");
            if (node != null) { hBuy = node.Handle; }

            node = items.Find((WindowTreeView.TreeItemNode n) => n.Text == "卖出");
            if (node != null) { hSell = node.Handle; }

            node = items.Find((WindowTreeView.TreeItemNode n) => n.Text == "撤单");
            if (node != null) { hCancel = node.Handle; }

            node = items.Find((WindowTreeView.TreeItemNode n) => n.Text == "查询");
            if (node != null)
            {
                child = node.Children.Find((WindowTreeView.TreeItemNode n) => n.Text == "资金股份");
                if (child != null) { hHoldingStock = child.Handle; }
                child = node.Children.Find((WindowTreeView.TreeItemNode n) => n.Text == "当日成交");
                if (child != null) { hTodayDeals = child.Handle; }
            }

            return
                hBuy != IntPtr.Zero &&
                hSell != IntPtr.Zero &&
                hCancel != IntPtr.Zero &&
                hTodayDeals != IntPtr.Zero &&
                hHoldingStock != IntPtr.Zero;
        }

        private bool InitHKStockTreeViewItemHandler()
        {
            var items = WindowTreeView.GetAllItems(hHkStockTree);
            if (items.Count != 2)
            {
                Log(LoggType.Black, "港股通菜单树菜单个数不一致");
                return false;
            }

            WindowTreeView.TreeItemNode node, child;

            node = items.Find((WindowTreeView.TreeItemNode n) => n.Text == "沪港通");
            if (node != null)
            {
                child = node.Children.Find((WindowTreeView.TreeItemNode n) => n.Text == "买入");
                if (child != null) { hHkHgtBuy = child.Handle; }

                child = node.Children.Find((WindowTreeView.TreeItemNode n) => n.Text == "卖出");
                if (child != null) { hHkHgtSell = child.Handle; }

                child = node.Children.Find((WindowTreeView.TreeItemNode n) => n.Text == "撤单");
                if (child != null) { hHkHgtCancel = child.Handle; }

                child = node.Children.Find((WindowTreeView.TreeItemNode n) => n.Text == "当日成交查询");
                if (child != null) { hHkHgtTodayDeals = child.Handle; }
            }

            node = items.Find((WindowTreeView.TreeItemNode n) => n.Text == "深港通");
            if (node != null)
            {
                child = node.Children.Find((WindowTreeView.TreeItemNode n) => n.Text == "买入");
                if (child != null) { hHkSgtBuy = child.Handle; }

                child = node.Children.Find((WindowTreeView.TreeItemNode n) => n.Text == "卖出");
                if (child != null) { hHkSgtSell = child.Handle; }

                child = node.Children.Find((WindowTreeView.TreeItemNode n) => n.Text == "撤单");
                if (child != null) { hHkSgtCancel = child.Handle; }

                child = node.Children.Find((WindowTreeView.TreeItemNode n) => n.Text == "当日成交查询");
                if (child != null) { hHkSgtTodayDeals = child.Handle; }
            }

            return
                hHkHgtBuy != IntPtr.Zero &&
                hHkHgtSell != IntPtr.Zero &&
                hHkHgtCancel != IntPtr.Zero &&
                hHkHgtTodayDeals != IntPtr.Zero &&
                hHkSgtBuy != IntPtr.Zero &&
                hHkSgtSell != IntPtr.Zero &&
                hHkSgtCancel != IntPtr.Zero &&
                hHkSgtTodayDeals != IntPtr.Zero;
        }

        public void KeepAlive()
        {
            // 刷新
            NativeMethods.PostMessage(hMainWnd, NativeMethods.WM_KEYDOWN,
                new IntPtr((int)System.Windows.Forms.Keys.F5), IntPtr.Zero);
        }

        public void BuyStock(string code, float price, int num)
        {
            Log(LoggType.Red, "购买股票: " + code + ", 价格: " + price + ", 数量: " + num);
            MouseClickToolbar(hToolBar, 0);
            //WindowTreeView.SelectItem(hStockTree, hBuy);
            WindowTreeView.SimulateClick(hStockTree, hBuy);
            Misc.Delay(1000);


            IntPtr panel = WindowHwnd.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr btnConfirm = WindowHwnd.GetDlgItem(panel, 0x07DA);
            if (btnConfirm == IntPtr.Zero || WindowHwnd.GetWindowText(btnConfirm) != "买入下单")
            {
                Log(LoggType.Black, "不是买入下单页面");
                return;
            }

            IntPtr hStaticMaxBuyNum = WindowHwnd.GetDlgItem(panel, 0x07E6);
            IntPtr hEditCode = WindowHwnd.FindVisibleHwndInParent(panel, IntPtr.Zero, "AfxWnd42", null);
            IntPtr hEditPrice = WindowHwnd.GetDlgItem(panel, 0x2EE6);
            IntPtr hEditNum = WindowHwnd.GetDlgItem(panel, 0x2EE7);

            if (hEditCode == IntPtr.Zero || hEditPrice == IntPtr.Zero || hEditNum == IntPtr.Zero)
            {
                Log(LoggType.Red, "不是买入下单的控件页面");
                return;
            }

            WindowHwnd.SetFocus(hEditCode);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditCode, code);
            WindowHwnd.SetFocus(hEditPrice);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditPrice, "" + price);
            WindowHwnd.SetFocus(hEditNum);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditNum, "" + num);

            // 点击买入按钮
            Misc.Delay(500);

            string maxBuyNum = WindowStatic.GetText(hStaticMaxBuyNum);
            if (maxBuyNum != null && maxBuyNum.Length > 0)
            {
                int maxNum = int.Parse(maxBuyNum);
                if (maxNum < num)
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
                patten["股票代码"] = @"^" + code;
                patten["委托价格"] = @"^" + price.ToString().Replace(".", "\\.");
                patten["委托数量"] = @"^" + num + "股";
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

        public void SellStock(string code, float price, int num)
        {
            Log(LoggType.Red, "卖出股票: " + code + ", 价格: " + price + ", 数量: " + num);
            MouseClickToolbar(hToolBar, 0);
            //WindowTreeView.SelectItem(hStockTree, hSell);
            WindowTreeView.SimulateClick(hStockTree, hSell);
            Misc.Delay(1000);


            IntPtr panel = WindowHwnd.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr btnConfirm = WindowHwnd.GetDlgItem(panel, 0x07DA);
            if (btnConfirm == IntPtr.Zero || WindowHwnd.GetWindowText(btnConfirm) != "卖出下单")
            {
                Log(LoggType.Black, "不是卖出下单页面");
                return;
            }

            IntPtr hStaticMaxSellNum = WindowHwnd.GetDlgItem(panel, 0x0811);
            IntPtr hEditCode = WindowHwnd.FindVisibleHwndInParent(panel, IntPtr.Zero, "AfxWnd42", null);
            IntPtr hEditPrice = WindowHwnd.GetDlgItem(panel, 0x2EE6);
            IntPtr hEditNum = WindowHwnd.GetDlgItem(panel, 0x2EE7);

            if (hEditCode == IntPtr.Zero || hEditPrice == IntPtr.Zero || hEditNum == IntPtr.Zero)
            {
                Log(LoggType.Red, "不是卖出下单的控件页面");
                return;
            }

            WindowHwnd.SetFocus(hEditCode);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditCode, code);
            WindowHwnd.SetFocus(hEditPrice);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditPrice, "" + price);
            WindowHwnd.SetFocus(hEditNum);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditNum, "" + num);

            // 点击买入按钮
            Misc.Delay(500);
            string maxSellNum = WindowStatic.GetText(hStaticMaxSellNum);
            if (maxSellNum != null && maxSellNum.Length > 0)
            {
                int maxNum = int.Parse(maxSellNum);
                if (maxNum < num)
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
                patten["股票代码"] = @"^" + code;
                patten["委托价格"] = @"^" + price.ToString().Replace(".", "\\.");
                patten["委托数量"] = @"^" + num + "股";
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


        public void CancelStock(string code, float price, int num)
        {
            Log(LoggType.Red, "撤单: " + code + ", 价格: " + price + ", 数量: " + num);
            MouseClickToolbar(hToolBar, 0);
            //WindowTreeView.SelectItem(hStockTree, hCancel);
            WindowTreeView.SimulateClick(hStockTree, hCancel);


        }

        public List<ModelTodayDeals> TodayDealsList()
        {
            Log(LoggType.Black, "查询当日成交");
            MouseClickToolbar(hToolBar, 0);
            //WindowTreeView.SelectItem(hStockTree, hTodayDeals);
            WindowTreeView.SimulateClick(hStockTree, hTodayDeals);

            Misc.Delay(1000);


            IntPtr panel = WindowHwnd.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr hOutputButton = WindowHwnd.GetDlgItem(panel, 0x047F);
            if (!(NativeMethods.IsWindowVisible(hOutputButton) && NativeMethods.IsWindowEnabled(hOutputButton)))
            {
                Log(LoggType.Red, "查询当日成交 - 无成交（输出按钮不可用）");
                return null;
            }
            WindowButton.Click(hOutputButton);
            Misc.Delay(500);

            IntPtr hConfirmDlg = WindowHwnd.FindHwndInParentRecursive(IntPtr.Zero, "#32770", "输出", true);
            if (hConfirmDlg != IntPtr.Zero)
            {
                IntPtr hCheckTxt = WindowHwnd.GetDlgItem(hConfirmDlg, 0x00E6);
                IntPtr hEditTxtFile = WindowHwnd.GetDlgItem(hConfirmDlg, 0x00E8);
                IntPtr hBtnYes = WindowHwnd.GetDlgItem(hConfirmDlg, 0x0001);

                WindowButton.Click(hCheckTxt);
                string tempFile = Path.GetTempFileName();
                WindowEditBox.SetText(hEditTxtFile, tempFile);
                WindowButton.Click(hBtnYes);
                try
                {
                    Misc.Delay(1000);
                    WindowHwnd.closeProcess("notepad", Path.GetFileName(tempFile));
                    Misc.Delay(1000);
                    List<string[]> rawData = DataParser.ReadCsv(tempFile);
                    return ModelTodayDeals.Parse(rawData);
                }
                finally
                {
                    try
                    {
                        File.Delete(tempFile);
                    }
                    catch
                    {
                    }
                }
            }
            return null;
        }

        public Tuple<ModelAccountStat, List<ModelHoldingStock>> HoldingStockList()
        {
            Log(LoggType.Black, "查询资金股份");
            MouseClickToolbar(hToolBar, 0);
            //WindowTreeView.SelectItem(hStockTree, hHoldingStock);
            WindowTreeView.SimulateClick(hStockTree, hHoldingStock);
            Misc.Delay(1000);


            IntPtr panel = WindowHwnd.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr btnConfirm = WindowHwnd.GetDlgItem(panel, 0x06BB);
            if (btnConfirm == IntPtr.Zero || WindowHwnd.GetWindowText(btnConfirm) != "修改成本")
            {
                Log(LoggType.Black, "查询资金股份 - 不是该页面");
                return null;
            }


            IntPtr hOutputButton = WindowHwnd.GetDlgItem(panel, 0x047F);
            if (!(NativeMethods.IsWindowVisible(hOutputButton) && NativeMethods.IsWindowEnabled(hOutputButton)))
            {
                Log(LoggType.Red, "查询资金股份 - 输出按钮不可用");
                return null;
            }
            WindowButton.Click(hOutputButton);
            Misc.Delay(500);

            IntPtr hConfirmDlg = WindowHwnd.FindHwndInParentRecursive(IntPtr.Zero, "#32770", "输出", true);
            if (hConfirmDlg != IntPtr.Zero)
            {
                IntPtr hCheckTxt = WindowHwnd.GetDlgItem(hConfirmDlg, 0x00E6);
                IntPtr hEditTxtFile = WindowHwnd.GetDlgItem(hConfirmDlg, 0x00E8);
                IntPtr hBtnYes = WindowHwnd.GetDlgItem(hConfirmDlg, 0x0001);

                WindowButton.Click(hCheckTxt);
                string tempFile = Path.GetTempFileName();
                WindowEditBox.SetText(hEditTxtFile, tempFile);
                WindowButton.Click(hBtnYes);
                try
                {
                    Misc.Delay(1000);
                    WindowHwnd.closeProcess("notepad", Path.GetFileName(tempFile));
                    Misc.Delay(1000);
                    List<string[]> rawData = DataParser.ReadCsv(tempFile);
                    return ModelHoldingStock.Parse(rawData);
                }
                finally
                {
                    try
                    {
                        File.Delete(tempFile);
                    }
                    catch
                    {
                    }
                }
            }
            return null;
        }


    }
}
