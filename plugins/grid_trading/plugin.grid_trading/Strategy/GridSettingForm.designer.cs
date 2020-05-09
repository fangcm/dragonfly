namespace Dragonfly.Plugin.GridTrading.Strategy
{
    partial class GridSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewGrid = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBoxStockMarket = new System.Windows.Forms.TextBox();
            this.labelMarket = new System.Windows.Forms.Label();
            this.buttonAddNew = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxStockName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxStockCode = new System.Windows.Forms.TextBox();
            this.labelCode = new System.Windows.Forms.Label();
            this.labelInitVolume = new System.Windows.Forms.Label();
            this.textBoxInitVolume = new System.Windows.Forms.TextBox();
            this.textBoxInitPrice = new System.Windows.Forms.TextBox();
            this.labelInitPrice = new System.Windows.Forms.Label();
            this.buttonModify = new System.Windows.Forms.Button();
            this.listViewGrid = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(557, 359);
            this.splitContainer1.SplitterDistance = 124;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewGrid
            // 
            this.treeViewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewGrid.Location = new System.Drawing.Point(0, 0);
            this.treeViewGrid.Name = "treeViewGrid";
            this.treeViewGrid.Size = new System.Drawing.Size(124, 359);
            this.treeViewGrid.TabIndex = 0;
            this.treeViewGrid.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewGrid_AfterSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.textBoxStockMarket);
            this.splitContainer2.Panel1.Controls.Add(this.labelMarket);
            this.splitContainer2.Panel1.Controls.Add(this.buttonAddNew);
            this.splitContainer2.Panel1.Controls.Add(this.buttonDelete);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxStockName);
            this.splitContainer2.Panel1.Controls.Add(this.labelName);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxStockCode);
            this.splitContainer2.Panel1.Controls.Add(this.labelCode);
            this.splitContainer2.Panel1.Controls.Add(this.labelInitVolume);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxInitVolume);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxInitPrice);
            this.splitContainer2.Panel1.Controls.Add(this.labelInitPrice);
            this.splitContainer2.Panel1.Controls.Add(this.buttonModify);
            this.splitContainer2.Panel1MinSize = 80;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listViewGrid);
            this.splitContainer2.Size = new System.Drawing.Size(429, 359);
            this.splitContainer2.SplitterDistance = 80;
            this.splitContainer2.TabIndex = 0;
            // 
            // textBoxStockMarket
            // 
            this.textBoxStockMarket.Location = new System.Drawing.Point(62, 5);
            this.textBoxStockMarket.Name = "textBoxStockMarket";
            this.textBoxStockMarket.ReadOnly = true;
            this.textBoxStockMarket.Size = new System.Drawing.Size(40, 21);
            this.textBoxStockMarket.TabIndex = 12;
            this.textBoxStockMarket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelMarket
            // 
            this.labelMarket.AutoSize = true;
            this.labelMarket.Location = new System.Drawing.Point(3, 9);
            this.labelMarket.Name = "labelMarket";
            this.labelMarket.Size = new System.Drawing.Size(53, 12);
            this.labelMarket.TabIndex = 11;
            this.labelMarket.Text = "交易市场";
            // 
            // buttonAddNew
            // 
            this.buttonAddNew.Location = new System.Drawing.Point(226, 40);
            this.buttonAddNew.Name = "buttonAddNew";
            this.buttonAddNew.Size = new System.Drawing.Size(40, 23);
            this.buttonAddNew.TabIndex = 8;
            this.buttonAddNew.Text = "新增";
            this.buttonAddNew.UseVisualStyleBackColor = true;
            this.buttonAddNew.Click += new System.EventHandler(this.buttonAddNew_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(340, 40);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(40, 23);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // textBoxStockName
            // 
            this.textBoxStockName.Location = new System.Drawing.Point(283, 5);
            this.textBoxStockName.Name = "textBoxStockName";
            this.textBoxStockName.ReadOnly = true;
            this.textBoxStockName.Size = new System.Drawing.Size(97, 21);
            this.textBoxStockName.TabIndex = 3;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(224, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(53, 12);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "股票名称";
            // 
            // textBoxStockCode
            // 
            this.textBoxStockCode.Location = new System.Drawing.Point(168, 5);
            this.textBoxStockCode.Name = "textBoxStockCode";
            this.textBoxStockCode.ReadOnly = true;
            this.textBoxStockCode.Size = new System.Drawing.Size(50, 21);
            this.textBoxStockCode.TabIndex = 1;
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(109, 9);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(53, 12);
            this.labelCode.TabIndex = 0;
            this.labelCode.Text = "股票代码";
            // 
            // labelInitVolume
            // 
            this.labelInitVolume.AutoSize = true;
            this.labelInitVolume.Location = new System.Drawing.Point(109, 44);
            this.labelInitVolume.Name = "labelInitVolume";
            this.labelInitVolume.Size = new System.Drawing.Size(53, 12);
            this.labelInitVolume.TabIndex = 6;
            this.labelInitVolume.Text = "初始持股";
            // 
            // textBoxInitVolume
            // 
            this.textBoxInitVolume.Location = new System.Drawing.Point(168, 41);
            this.textBoxInitVolume.Name = "textBoxInitVolume";
            this.textBoxInitVolume.ReadOnly = true;
            this.textBoxInitVolume.Size = new System.Drawing.Size(40, 21);
            this.textBoxInitVolume.TabIndex = 7;
            this.textBoxInitVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxInitPrice
            // 
            this.textBoxInitPrice.Location = new System.Drawing.Point(62, 41);
            this.textBoxInitPrice.Name = "textBoxInitPrice";
            this.textBoxInitPrice.ReadOnly = true;
            this.textBoxInitPrice.Size = new System.Drawing.Size(40, 21);
            this.textBoxInitPrice.TabIndex = 5;
            this.textBoxInitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelInitPrice
            // 
            this.labelInitPrice.AutoSize = true;
            this.labelInitPrice.Location = new System.Drawing.Point(3, 44);
            this.labelInitPrice.Name = "labelInitPrice";
            this.labelInitPrice.Size = new System.Drawing.Size(53, 12);
            this.labelInitPrice.TabIndex = 4;
            this.labelInitPrice.Text = "初始价格";
            this.labelInitPrice.Click += new System.EventHandler(this.labelInitPrice_Click);
            // 
            // buttonModify
            // 
            this.buttonModify.Location = new System.Drawing.Point(283, 40);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(40, 23);
            this.buttonModify.TabIndex = 9;
            this.buttonModify.Text = "修改";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // listViewGrid
            // 
            this.listViewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewGrid.FullRowSelect = true;
            this.listViewGrid.Location = new System.Drawing.Point(0, 0);
            this.listViewGrid.Name = "listViewGrid";
            this.listViewGrid.Size = new System.Drawing.Size(429, 275);
            this.listViewGrid.TabIndex = 0;
            this.listViewGrid.UseCompatibleStateImageBehavior = false;
            this.listViewGrid.View = System.Windows.Forms.View.Details;
            // 
            // GridSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 359);
            this.Controls.Add(this.splitContainer1);
            this.MinimizeBox = false;
            this.Name = "GridSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "交易策略";
            this.Load += new System.EventHandler(this.GridSettingForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewGrid;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listViewGrid;
        private System.Windows.Forms.Label labelInitVolume;
        private System.Windows.Forms.TextBox textBoxInitVolume;
        private System.Windows.Forms.TextBox textBoxInitPrice;
        private System.Windows.Forms.Label labelInitPrice;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.TextBox textBoxStockName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxStockCode;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAddNew;
        private System.Windows.Forms.TextBox textBoxStockMarket;
        private System.Windows.Forms.Label labelMarket;
    }
}