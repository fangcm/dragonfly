using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading.Strategy
{
    internal partial class GridSettingForm : Form
    {
        public bool bDataChanged = false;

        public GridSettingForm()
        {
            InitializeComponent();
        }

        private void GridTradingSettingsForm_Load(object sender, EventArgs e)
        {
            List<Grid> gridList = GridDao.GetAllGrids(false);
            foreach (Grid g in gridList)
            {
                TreeNode node = new TreeNode()
                {
                    Text = g.StockCode + " " + g.StockName,
                    Tag = g,
                };
                treeViewGrid.Nodes.Add(node);
            }

            this.textBoxStockCode.TextChanged += new System.EventHandler(this.Data_Changed);
            this.textBoxStockName.TextChanged += new System.EventHandler(this.Data_Changed);
            this.textBoxInitPrice.TextChanged += new System.EventHandler(this.Data_Changed);
            this.textBoxInitVolume.TextChanged += new System.EventHandler(this.Data_Changed);
            this.textBoxMinPrice.TextChanged += new System.EventHandler(this.Data_Changed);
            this.textBoxMaxPrice.TextChanged += new System.EventHandler(this.Data_Changed);
            bDataChanged = false;
        }

        private void Data_Changed(object sender, System.EventArgs e)
        {
            bDataChanged = true;
        }

        private void treeViewGrid_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeViewGrid.SelectedNode;
            Grid g = (Grid)node.Tag;
            this.textBoxStockCode.Text = g.StockCode;
            this.textBoxStockName.Text = g.StockName;
            this.textBoxInitPrice.Text = g.InitPrice.ToString();
            this.textBoxInitVolume.Text = g.InitHoldingVolume.ToString();
            this.textBoxMinPrice.Text = g.MinPrice.ToString();
            this.textBoxMaxPrice.Text = g.MaxPrice.ToString();
        }

        private void comboBoxGridType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bDataChanged = true;

        }

        private void buttonCalcu_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (bDataChanged)
            {


                

                bDataChanged = false;
            }
        }
    }
}
