using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading.Strategy
{
    internal partial class GridSettingForm : Form
    {
        public GridSettingForm()
        {
            InitializeComponent();
        }

        private void GridSettingForm_Load(object sender, EventArgs e)
        {
            listViewGrid.GridLines = true;
            listViewGrid.Columns.Clear();
            listViewGrid.Columns.Add("价格", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("持仓量", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("买单价", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("买单量", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("卖单价", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("卖单数", 60, HorizontalAlignment.Right);

            RefreshControls();

        }

        private void RefreshControls()
        {
            treeViewGrid.Nodes.Clear();
            List<Grid> gridList = GridDao.GetAllGrids(false);
            foreach (Grid g in gridList)
            {
                TreeNode treeNode = new TreeNode()
                {
                    Text = g.StockCode + " " + g.StockName,
                    Tag = g,
                };
                if (g.DisableFlag == 1)
                {
                    treeNode.ForeColor = Color.Gray;
                }

                treeViewGrid.Nodes.Add(treeNode);
            }

        }

        private void treeViewGrid_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode treeNode = treeViewGrid.SelectedNode;
            Grid g = (Grid)treeNode.Tag;
            this.textBoxStockMarket.Text = g.GetStockMarketDesc();
            this.textBoxStockCode.Text = g.StockCode;
            this.textBoxStockName.Text = g.StockName;
            this.textBoxInitPrice.Text = g.InitPrice.ToString();
            this.textBoxInitVolume.Text = g.InitHoldingVolume.ToString();

            listViewGrid.Items.Clear();
            if (g.GridNodes != null)
            {
                foreach (GridNode node in g.GridNodes)
                {
                    ListViewItem lvi = listViewGrid.Items.Add(node.TradingPrice.ToString());
                    lvi.Tag = node;
                    lvi.UseItemStyleForSubItems = false;
                    lvi.SubItems.Add(node.HoldingVolume.ToString());

                    string price = "";
                    string volume = "";
                    if (node.BuyOrder != null)
                    {
                        price = node.BuyOrder.Price.ToString();
                        volume = node.BuyOrder.Volume.ToString();
                    }
                    ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add(price);
                    lvsi.ForeColor = Color.Red;
                    lvi.SubItems.Add(volume);


                    price = "";
                    volume = "";
                    if (node.SellOrder != null)
                    {
                        price = node.SellOrder.Price.ToString();
                        volume = node.SellOrder.Volume.ToString();
                    }
                    lvsi = lvi.SubItems.Add(price);
                    lvsi.ForeColor = Color.Green;
                    lvi.SubItems.Add(volume);
                }
            }
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            TreeNode treeNode = treeViewGrid.SelectedNode;
            if (treeNode == null)
            {
                MessageBox.Show("请选择网格策略");
                return;
            }

            GridModifyForm form = new GridModifyForm();
            form.Grid = (Grid)treeNode.Tag;
            form.ShowDialog();
            RefreshControls();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            TreeNode treeNode = treeViewGrid.SelectedNode;
            if (treeNode == null)
            {
                MessageBox.Show("请选择网格策略");
                return;
            }
            DialogResult result = MessageBox.Show("确实要删除该网格数据吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Grid g = (Grid)treeNode.Tag;
                GridDao.DeleteGrid(g.Id);
                RefreshControls();
            }
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            GridModifyForm form = new GridModifyForm();
            form.Grid = new Grid();
            form.ShowDialog();
            RefreshControls();
        }

    }
}
