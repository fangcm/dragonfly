using Dragonfly.Plugin.GridTrading.Utils;
using Dragonfly.Plugin.GridTrading.Utils.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Dragonfly.Plugin.GridTrading.Trade.GuoHai
{
    // 国海金叹号
    internal partial class JintanhaoTrader : AbstractTrader, ITrader
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
                Log(LoggType.MediumBlue, "【国海金叹号网上交易系统】未启动");
                return false;
            }
            hMainWnd = WindowHwnd.FindHwndInParentRecursive(hMainWnd, null, @"通达信网上交易V6");
            IntPtr afxMDIFrame = WindowHwnd.FindHwndInParentRecursive(hMainWnd, "AfxMDIFrame42", null);
            IntPtr afxWind42TreePanel = WindowHwnd.GetDlgItem(afxMDIFrame, 0xE900);
            afxWind42DetailPanel = WindowHwnd.GetDlgItem(afxMDIFrame, 0xE901);

            hToolBar = WindowHwnd.GetDlgItem(afxWind42TreePanel, 0x00DD);

            if (hToolBar == IntPtr.Zero)
            {
                Log(LoggType.MediumBlue, "未找到选择股票市场工具条");
                return false;
            }

            // 获取左侧功能菜单treeview 句柄
            hStockTree = WindowHwnd.GetDlgItem(hToolBar, 0xE900);
            hHkStockTree = WindowHwnd.GetDlgItem(hToolBar, 0xE903);

            if (hStockTree == IntPtr.Zero)
            {
                Log(LoggType.MediumBlue, "没有找到金叹号交易软件");
                return false;
            }
            if (hHkStockTree == IntPtr.Zero)
            {
                Log(LoggType.MediumBlue, "没有找到金叹号港股交易软件");
                return false;
            }

            if (!InitStockTreeViewItemHandler())
            {
                Log(LoggType.MediumBlue, "初始化A股菜单树失败");
                return false;
            }
            if (!InitHKStockTreeViewItemHandler())
            {
                Log(LoggType.MediumBlue, "初始化港股通菜单树失败");
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
                Log(LoggType.MediumBlue, "A股菜单树菜单个数不一致");
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
                Log(LoggType.MediumBlue, "港股通菜单树菜单个数不一致");
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

                child = node.Children.Find((WindowTreeView.TreeItemNode n) => n.Text == "资金股份");
                if (child != null) { hHkHgtHoldingStock = child.Handle; }

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

                child = node.Children.Find((WindowTreeView.TreeItemNode n) => n.Text == "资金股份");
                if (child != null) { hHkSgtHoldingStock = child.Handle; }

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

        internal void ClickTreeNode(IntPtr hTree, IntPtr hItem)
        {
            if (hTree == IntPtr.Zero || hItem == IntPtr.Zero)
            {
                throw new ApplicationException("没有检测到菜单树、菜单项");
            }

            NativeMethods.SwitchToThisWindow(hAppWnd, true);
            int index;
            if (hTree == hStockTree)
                index = 0;
            else
                index = 2;

            MouseClickToolbar(hToolBar, index);
            WindowTreeView.SimulateClick(hTree, hItem);
            Misc.Delay(1000);
            IntPtr hSelectedItem = WindowTreeView.GetSelection(hTree);
            if (hSelectedItem != hItem)
            {
                throw new ApplicationException("没有选中树节点");
            }
        }


        // 委托后确认
        internal bool ConfirmOrder(string direction, string stockCode, decimal price, int volume)
        {
            IntPtr hConfirmDlg = WaitForHwnd.WaitForFindHwndInParentRecursive(IntPtr.Zero, "#32770", direction + "交易确认", true);
            if (hConfirmDlg != IntPtr.Zero)
            {
                IntPtr hBtnYes = WaitForHwnd.WaitForFindHwndInParentRecursive(hConfirmDlg, "Button", direction + "确认");
                IntPtr hBtnNo = WaitForHwnd.WaitForFindHwndInParentRecursive(hConfirmDlg, "Button", "取消");

                IntPtr hStaticConfirm = WindowHwnd.GetDlgItem(hConfirmDlg, 0x1B65);
                string txtConfirm = WindowHwnd.GetWindowText(hStaticConfirm);

                Dictionary<string, string> patten = new Dictionary<string, string>();
                patten["操作类别"] = @"^" + direction + "$";
                patten["股票代码"] = @"^" + stockCode;
                patten["委托价格"] = @"^" + price.ToString().Replace(".", "\\.");
                patten["委托数量"] = @"^" + volume + "股";
                patten["委托方式"] = "限价委托";
                if (!ValidateTipText(txtConfirm, patten))
                {
                    Log(LoggType.MediumBlue, "校验提示异常: " + txtConfirm.Replace('\n', ' '));
                    WindowButton.Click(hBtnNo);
                    return false;
                }
                WindowButton.Click(hBtnYes);

                IntPtr hTipDlg = WaitForHwnd.WaitForFindHwndInParentRecursive(IntPtr.Zero, "#32770", "提示", true);
                if (hTipDlg != IntPtr.Zero)
                {
                    IntPtr hBtnOk = WindowHwnd.GetDlgItem(hTipDlg, 0x1B67);
                    IntPtr hStaticTip = WindowHwnd.GetDlgItem(hTipDlg, 0x1B65);

                    string tipTxt = WindowHwnd.GetWindowText(hStaticTip);
                    WindowButton.Click(hBtnOk);

                    if (!string.IsNullOrEmpty(tipTxt) && tipTxt.Contains("合同号"))
                    {
                        Log(LoggType.Black, direction + "下单成功，【" + stockCode + "】,价格:" + price + ",数量" + volume);
                        return true;
                    }

                    throw new ApplicationException("下单提示信息没有【合同号】，下单可能成功");
                }

                throw new ApplicationException("没有检测到【提示】对话框，下单可能成功");
            }
            else
            {
                throw new ApplicationException("没有检测到卖出确认对话框");
            }


        }

        // 校验弹出框提示信息是否为委托信息
        internal bool ValidateTipText(string tipText, Dictionary<string, string> patten)
        {
            Dictionary<string, string> pattenCopy = new Dictionary<string, string>(patten);
            string[] tipTextArray = tipText.Split('\n');
            foreach (string line in tipTextArray)
            {
                string[] sKeyValue = line.Split(':');
                if (sKeyValue.Length != 2)
                    continue;
                string key = sKeyValue[0].Trim();
                string value = sKeyValue[1].Trim();

                if (pattenCopy.ContainsKey(key))
                {
                    if (Regex.IsMatch(value, pattenCopy[key]))
                    {
                        pattenCopy.Remove(key);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (pattenCopy.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        // 通用保存文件窗口确认后，解析txt文件，返回解析model
        internal static object ParseModelDataFromTxtFileAfterConfirDlg(Func<List<string[]>, object> modelParser)
        {
            IntPtr hConfirmDlg = WaitForHwnd.WaitForFindHwndInParentRecursive(IntPtr.Zero, "#32770", "输出", true);
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
                    WaitForHwnd.WaitForCloseProcess("notepad", Path.GetFileName(tempFile));
                    Misc.Delay(1000);
                    List<string[]> rawData = DataParser.ReadCsv(tempFile);
                    return modelParser(rawData);
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
            throw new ApplicationException("没有等到保存文件确认窗口");
        }

    }
}
