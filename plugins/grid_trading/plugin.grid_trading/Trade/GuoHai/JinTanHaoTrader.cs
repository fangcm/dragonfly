using Dragonfly.Common.Utils;
using Dragonfly.Plugin.GridTrading.Utils;
using Dragonfly.Plugin.GridTrading.Utils.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace Dragonfly.Plugin.GridTrading.Trade.GuoHai
{
    // 国海金叹号
    public class JintanhaoTrader : AbstractTrader, ITrader
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
            hMainWnd = Window.FindHwndInParentRecursive(hMainWnd, null, @"通达信网上交易V6");
            IntPtr afxMDIFrame = Window.FindHwndInParentRecursive(hMainWnd, "AfxMDIFrame42", null);
            IntPtr afxWind42TreePanel = Window.GetDlgItem(afxMDIFrame, 0xE900);
            afxWind42DetailPanel = Window.GetDlgItem(afxMDIFrame, 0xE901);

            hToolBar = Window.GetDlgItem(afxWind42TreePanel, 0x00DD);

            if (hToolBar == IntPtr.Zero)
            {
                Log(LoggType.Red, "未找到选择股票市场工具条");
                return false;
            }

            // 获取左侧功能菜单treeview 句柄
            hStockTree = Window.GetDlgItem(hToolBar, 0xE900);
            hHkStockTree = Window.GetDlgItem(hToolBar, 0xE903);

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

        public static void MouseClickToolbar(IntPtr hToolBar, int index)
        {
            NativeMethods.Win32Rect rect = new NativeMethods.Win32Rect();
            NativeMethods.GetWindowRect(hToolBar, ref rect);

            int x = 10 + (rect.right - rect.left) / 3 * index;
            int y = 10;

            Window.SimulateClick(hToolBar, x, y);
        }

        private bool InitStockTreeViewItemHandler()
        {
            var items = SysTreeView32.GetAllItems(hStockTree);
            if (items.Count != 23)
            {
                Log(LoggType.Black, "A股菜单树菜单个数不一致");
                return false;
            }

            SysTreeView32.TreeItemNode node, child;

            node = items.Find((SysTreeView32.TreeItemNode n) => n.Text == "买入");
            if (node != null) { hBuy = node.Handle; }

            node = items.Find((SysTreeView32.TreeItemNode n) => n.Text == "卖出");
            if (node != null) { hSell = node.Handle; }

            node = items.Find((SysTreeView32.TreeItemNode n) => n.Text == "撤单");
            if (node != null) { hCancel = node.Handle; }

            node = items.Find((SysTreeView32.TreeItemNode n) => n.Text == "查询");
            if (node != null)
            {
                child = node.Children.Find((SysTreeView32.TreeItemNode n) => n.Text == "资金股份");
                if (child != null) { hHoldingStock = child.Handle; }
                child = node.Children.Find((SysTreeView32.TreeItemNode n) => n.Text == "当日成交");
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
            var items = SysTreeView32.GetAllItems(hHkStockTree);
            if (items.Count != 2)
            {
                Log(LoggType.Black, "港股通菜单树菜单个数不一致");
                return false;
            }

            SysTreeView32.TreeItemNode node, child;

            node = items.Find((SysTreeView32.TreeItemNode n) => n.Text == "沪港通");
            if (node != null)
            {
                child = node.Children.Find((SysTreeView32.TreeItemNode n) => n.Text == "买入");
                if (child != null) { hHkHgtBuy = child.Handle; }

                child = node.Children.Find((SysTreeView32.TreeItemNode n) => n.Text == "卖出");
                if (child != null) { hHkHgtSell = child.Handle; }

                child = node.Children.Find((SysTreeView32.TreeItemNode n) => n.Text == "撤单");
                if (child != null) { hHkHgtCancel = child.Handle; }

                child = node.Children.Find((SysTreeView32.TreeItemNode n) => n.Text == "当日成交查询");
                if (child != null) { hHkHgtTodayDeals = child.Handle; }
            }

            node = items.Find((SysTreeView32.TreeItemNode n) => n.Text == "深港通");
            if (node != null)
            {
                child = node.Children.Find((SysTreeView32.TreeItemNode n) => n.Text == "买入");
                if (child != null) { hHkSgtBuy = child.Handle; }

                child = node.Children.Find((SysTreeView32.TreeItemNode n) => n.Text == "卖出");
                if (child != null) { hHkSgtSell = child.Handle; }

                child = node.Children.Find((SysTreeView32.TreeItemNode n) => n.Text == "撤单");
                if (child != null) { hHkSgtCancel = child.Handle; }

                child = node.Children.Find((SysTreeView32.TreeItemNode n) => n.Text == "当日成交查询");
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

        public void BuyStock(string code, float price, int num)
        {
            Log(LoggType.Red, "购买股票: " + code + ", 价格: " + price + ", 数量: " + num);
            MouseClickToolbar(hToolBar, 0);
            //SysTreeView32.SelectItem(hStockTree, hBuy);
            SysTreeView32.SimulateClick(hStockTree, hBuy);
            Misc.Delay(1000);


            IntPtr panel = Window.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr btnConfirm = Window.GetDlgItem(panel, 0x07DA);
            if (btnConfirm == IntPtr.Zero || Window.GetWindowText(btnConfirm) != "买入下单")
            {
                Log(LoggType.Black, "不是买入下单页面");
                return;
            }

            IntPtr hStaticMaxBuyNum = Window.GetDlgItem(panel, 0x07E6);
            IntPtr hEditCode = Window.FindVisibleHwndInParent(panel, IntPtr.Zero, "AfxWnd42", null);
            IntPtr hEditPrice = Window.GetDlgItem(panel, 0x2EE6);
            IntPtr hEditNum = Window.GetDlgItem(panel, 0x2EE7);

            if (hEditCode == IntPtr.Zero || hEditPrice == IntPtr.Zero || hEditNum == IntPtr.Zero)
            {
                Log(LoggType.Red, "不是买入下单的控件页面");
                return;
            }

            Window.SetFocus(hEditCode);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditCode, code);
            Window.SetFocus(hEditPrice);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditPrice, "" + price);
            Window.SetFocus(hEditNum);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditNum, "" + num);

            // 点击买入按钮
            Misc.Delay(500);

            string maxBuyNum = Static.GetText(hStaticMaxBuyNum);
            if (maxBuyNum != null && maxBuyNum.Length > 0)
            {
                int maxNum = int.Parse(maxBuyNum);
                if (maxNum < num)
                {
                    Log(LoggType.Red, "资金不足，不能购买");
                    return;
                }
            }

            Button.Click(btnConfirm);
            Misc.Delay(500);

            IntPtr hConfirmDlg = Window.FindHwndInParentRecursive(IntPtr.Zero, null, "买入交易确认", true);
            if (hConfirmDlg != IntPtr.Zero)
            {
                IntPtr hBtnYes = Window.FindHwndInParentRecursive(hConfirmDlg, "Button", "买入确认");
                IntPtr hBtnNo = Window.FindHwndInParentRecursive(hConfirmDlg, "Button", "取消");

                IntPtr hStaticConfirm = Window.GetDlgItem(hConfirmDlg, 0x1B65);
                string txtConfirm = Window.GetWindowText(hStaticConfirm);

                Dictionary<string, string> patten = new Dictionary<string, string>();
                patten["操作类别"] = @"^买入$";
                patten["股票代码"] = @"^" + code;
                patten["委托价格"] = @"^" + price.ToString().Replace(".", "\\.");
                patten["委托数量"] = @"^" + num + "股";
                patten["委托方式"] = "限价委托";
                if (ValidateTipText(txtConfirm, patten))
                {
                    Log(LoggType.Gray, "校验提示正常: " + txtConfirm.Replace('\n', ' '));
                    Button.Click(hBtnYes);

                }
                else
                {
                    Log(LoggType.Red, "校验提示异常: " + txtConfirm.Replace('\n', ' '));
                    Button.Click(hBtnNo);
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
            //SysTreeView32.SelectItem(hStockTree, hSell);
            SysTreeView32.SimulateClick(hStockTree, hSell);
            Misc.Delay(1000);


            IntPtr panel = Window.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr btnConfirm = Window.GetDlgItem(panel, 0x07DA);
            if (btnConfirm == IntPtr.Zero || Window.GetWindowText(btnConfirm) != "卖出下单")
            {
                Log(LoggType.Black, "不是卖出下单页面");
                return;
            }

            IntPtr hStaticMaxSellNum = Window.GetDlgItem(panel, 0x0811);
            IntPtr hEditCode = Window.FindVisibleHwndInParent(panel, IntPtr.Zero, "AfxWnd42", null);
            IntPtr hEditPrice = Window.GetDlgItem(panel, 0x2EE6);
            IntPtr hEditNum = Window.GetDlgItem(panel, 0x2EE7);

            if (hEditCode == IntPtr.Zero || hEditPrice == IntPtr.Zero || hEditNum == IntPtr.Zero)
            {
                Log(LoggType.Red, "不是卖出下单的控件页面");
                return;
            }

            Window.SetFocus(hEditCode);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditCode, code);
            Window.SetFocus(hEditPrice);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditPrice, "" + price);
            Window.SetFocus(hEditNum);
            Misc.Delay(500);
            Misc.KeyboardPress(hEditNum, "" + num);

            // 点击买入按钮
            Misc.Delay(500);
            string maxSellNum = Static.GetText(hStaticMaxSellNum);
            if (maxSellNum != null && maxSellNum.Length > 0)
            {
                int maxNum = int.Parse(maxSellNum);
                if (maxNum < num)
                {
                    Log(LoggType.Red, "股票不足，不能卖出");
                    return;
                }
            }

            Button.Click(btnConfirm);
            Misc.Delay(500);

            IntPtr hConfirmDlg = Window.FindHwndInParentRecursive(IntPtr.Zero, null, "卖出交易确认", true);
            if (hConfirmDlg != IntPtr.Zero)
            {
                IntPtr hBtnYes = Window.FindHwndInParentRecursive(hConfirmDlg, "Button", "卖出确认");
                IntPtr hBtnNo = Window.FindHwndInParentRecursive(hConfirmDlg, "Button", "取消");

                IntPtr hStaticConfirm = Window.GetDlgItem(hConfirmDlg, 0x1B65);
                string txtConfirm = Window.GetWindowText(hStaticConfirm);

                Dictionary<string, string> patten = new Dictionary<string, string>();
                patten["操作类别"] = @"^卖出$";
                patten["股票代码"] = @"^" + code;
                patten["委托价格"] = @"^" + price.ToString().Replace(".", "\\.");
                patten["委托数量"] = @"^" + num + "股";
                patten["委托方式"] = "限价委托";
                if (ValidateTipText(txtConfirm, patten))
                {
                    Log(LoggType.Gray, "校验提示正常: " + txtConfirm.Replace('\n', ' '));
                    Button.Click(hBtnYes);

                }
                else
                {
                    Log(LoggType.Red, "校验提示异常: " + txtConfirm.Replace('\n', ' '));
                    Button.Click(hBtnNo);
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
            //SysTreeView32.SelectItem(hStockTree, hCancel);
            SysTreeView32.SimulateClick(hStockTree, hCancel);


        }

        public List<Dictionary<string, string>> TodayDealsList()
        {
            Log(LoggType.Black, "查询当日成交");
            MouseClickToolbar(hToolBar, 0);
            //SysTreeView32.SelectItem(hStockTree, hTodayDeals);
            SysTreeView32.SimulateClick(hStockTree, hTodayDeals);

            return null;
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

        public List<Dictionary<string, string>> HoldingStockList()
        {
            Log(LoggType.Black, "查询资金股份");
            MouseClickToolbar(hToolBar, 0);
            //SysTreeView32.SelectItem(hStockTree, hHoldingStock);
            SysTreeView32.SimulateClick(hStockTree, hHoldingStock);
            Misc.Delay(1000);


            IntPtr panel = Window.FindVisibleHwndLikeInParent(afxWind42DetailPanel, IntPtr.Zero, "#32770", null);
            IntPtr btnConfirm = Window.GetDlgItem(panel, 0x06BB);
            if (btnConfirm == IntPtr.Zero || Window.GetWindowText(btnConfirm) != "修改成本")
            {
                Log(LoggType.Black, "不是查询资金股份页面");
                return null;
            }
            IntPtr hListView = Window.GetDlgItem(panel, 0x061F);
            List<Dictionary<string, string>> dataList = SysListView32.GetAllText(hListView);
            return dataList;
        }


    }
}
