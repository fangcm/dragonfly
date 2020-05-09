﻿using System;
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
            listViewGrid.Columns.Clear();
            listViewGrid.Columns.Add("价格", 50, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("持仓量", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("买单价", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("买单量", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("卖单价", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("卖单数", 60, HorizontalAlignment.Right);

            List<Grid> gridList = GridDao.GetAllGrids(false);
            foreach (Grid g in gridList)
            {
                TreeNode treeNode = new TreeNode()
                {
                    Text = g.StockCode + " " + g.StockName,
                    Tag = g,
                };
                treeViewGrid.Nodes.Add(treeNode);
            }

        }

        private void treeViewGrid_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode treeNode = treeViewGrid.SelectedNode;
            Grid g = (Grid)treeNode.Tag;
            this.textBoxStockCode.Text = g.StockCode;
            this.textBoxStockName.Text = g.StockName;
            this.textBoxInitPrice.Text = g.InitPrice.ToString();
            this.textBoxInitVolume.Text = g.InitHoldingVolume.ToString();
            this.textBoxMinPrice.Text = g.MinPrice.ToString();
            this.textBoxMaxPrice.Text = g.MaxPrice.ToString();

            foreach (GridNode node in g.GridNodes)
            {
                ListViewItem lvi = listViewGrid.Items.Add(node.TradingPrice.ToString());
                lvi.Tag = node;
                lvi.SubItems.Add(node.HoldingVolume.ToString());

                if (node.BuyOrder != null)
                {
                    ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add(node.BuyOrder.Price.ToString());
                    lvsi.ForeColor = Color.Red;

                    lvi.SubItems.Add(node.BuyOrder.Volume.ToString());
                }
                if (node.SellOrder != null)
                {
                    ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add(node.SellOrder.Price.ToString());
                    lvsi.ForeColor = Color.Green;

                    lvi.SubItems.Add(node.SellOrder.Volume.ToString());
                }
            }
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            GridModifyForm form = new GridModifyForm();
            form.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {

        }
    }
}
