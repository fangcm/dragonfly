using Dragonfly.Plugin.GridTrading.Utils;
using System;
using System.Collections.Generic;
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
            listViewGrid.Columns.Add("价格", 50, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("持仓量", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("买单价", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("买单量", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("卖单价", 60, HorizontalAlignment.Right);
            listViewGrid.Columns.Add("卖单数", 60, HorizontalAlignment.Right);

            list = new EditableListView(listViewGrid);
            list.TextBoxColumns = new int[] { 0, 1, 2, 3,4,5 };
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
            bDataChanged = true;
        }

        private void Data_Changed(object sender, System.EventArgs e)
        {
            bDataChanged = true;
        }

        private void treeViewGrid_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Grid g = Grid;
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

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
