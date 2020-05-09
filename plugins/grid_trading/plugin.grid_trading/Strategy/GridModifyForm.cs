﻿using Dragonfly.Plugin.GridTrading.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading.Strategy
{
    internal partial class GridModifyForm : Form
    {
        private EditableListView list;
        public bool bDataChanged = false;
        public Grid Grid { get; set; }

        public GridModifyForm()
        {
            InitializeComponent();
        }

        private void GridModifyForm_Load(object sender, EventArgs e)
        {
            listViewGrid.Columns.Clear();
            listViewGrid.Columns.Add("价格", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("持仓量", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("买单价", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("买单量", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("卖单价", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("卖单数", 60, HorizontalAlignment.Right);

            RefreshControls();

            list = new EditableListView(listViewGrid);
            list.TextBoxColumns = new int[] { 0, 1 };
            list.Submitting += new EditableListViewSubmitting(listViewSaveEditHandler);

            this.textBoxStockCode.TextChanged += new System.EventHandler(this.Data_Changed);
            this.textBoxStockName.TextChanged += new System.EventHandler(this.Data_Changed);
            this.textBoxInitPrice.TextChanged += new System.EventHandler(this.Data_Changed);
            this.textBoxInitVolume.TextChanged += new System.EventHandler(this.Data_Changed);
            this.textBoxMinPrice.TextChanged += new System.EventHandler(this.Data_Changed);
            this.textBoxMaxPrice.TextChanged += new System.EventHandler(this.Data_Changed);
            bDataChanged = false;
        }

        private void listViewSaveEditHandler(object sender, EditableListViewSubmittingEventArgs e)
        {
            if (e.Cell == null)
            {
                return;
            }
            string value = e.Value;
            ListViewItem item = e.Cell.Item;
            int itemindex = e.Cell.Column.Index;
            item.SubItems[itemindex].Text = value;

            GridNode node = (GridNode)item.Tag;

            if (itemindex == 0)
            {
                node.TradingPrice = decimal.Parse(value);
            }
            else
            {
                node.HoldingVolume = int.Parse(value);
            }

            Grid.ResetOrders();
            RefreshControls();
            bDataChanged = true;
        }

        private void Data_Changed(object sender, System.EventArgs e)
        {
            bDataChanged = true;
        }

        private void RefreshControls()
        {
            Grid g = Grid;
            this.textBoxStockCode.Text = g.StockCode;
            this.textBoxStockName.Text = g.StockName;
            this.textBoxInitPrice.Text = g.InitPrice.ToString();
            this.textBoxInitVolume.Text = g.InitHoldingVolume.ToString();

            listViewGrid.Items.Clear();
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (bDataChanged)
            {
                GridDao.SaveGrid(Grid);

                bDataChanged = false;
            }
        }

        private void GridModifyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bDataChanged)
            {
                DialogResult result = MessageBox.Show("确实要放弃网格数据更改吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
