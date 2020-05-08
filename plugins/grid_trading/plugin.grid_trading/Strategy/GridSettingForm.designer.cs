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
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxStockName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxStockCode = new System.Windows.Forms.TextBox();
            this.labelCode = new System.Windows.Forms.Label();
            this.labelGridType = new System.Windows.Forms.Label();
            this.comboBoxGridType = new System.Windows.Forms.ComboBox();
            this.textBoxMaxPrice = new System.Windows.Forms.TextBox();
            this.labelMaxPrice = new System.Windows.Forms.Label();
            this.textBoxMinPrice = new System.Windows.Forms.TextBox();
            this.labelInitVolume = new System.Windows.Forms.Label();
            this.textBoxInitVolume = new System.Windows.Forms.TextBox();
            this.labelMinPrice = new System.Windows.Forms.Label();
            this.textBoxInitPrice = new System.Windows.Forms.TextBox();
            this.labelInitPrice = new System.Windows.Forms.Label();
            this.buttonCalcu = new System.Windows.Forms.Button();
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
            this.splitContainer1.SplitterDistance = 146;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewGrid
            // 
            this.treeViewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewGrid.Location = new System.Drawing.Point(0, 0);
            this.treeViewGrid.Name = "treeViewGrid";
            this.treeViewGrid.Size = new System.Drawing.Size(146, 359);
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
            this.splitContainer2.Panel1.Controls.Add(this.buttonSave);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxStockName);
            this.splitContainer2.Panel1.Controls.Add(this.labelName);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxStockCode);
            this.splitContainer2.Panel1.Controls.Add(this.labelCode);
            this.splitContainer2.Panel1.Controls.Add(this.labelGridType);
            this.splitContainer2.Panel1.Controls.Add(this.comboBoxGridType);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxMaxPrice);
            this.splitContainer2.Panel1.Controls.Add(this.labelMaxPrice);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxMinPrice);
            this.splitContainer2.Panel1.Controls.Add(this.labelInitVolume);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxInitVolume);
            this.splitContainer2.Panel1.Controls.Add(this.labelMinPrice);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxInitPrice);
            this.splitContainer2.Panel1.Controls.Add(this.labelInitPrice);
            this.splitContainer2.Panel1.Controls.Add(this.buttonCalcu);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listViewGrid);
            this.splitContainer2.Size = new System.Drawing.Size(407, 359);
            this.splitContainer2.SplitterDistance = 122;
            this.splitContainer2.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(274, 9);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(67, 23);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxStockName
            // 
            this.textBoxStockName.Location = new System.Drawing.Point(66, 74);
            this.textBoxStockName.Name = "textBoxStockName";
            this.textBoxStockName.Size = new System.Drawing.Size(53, 21);
            this.textBoxStockName.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(7, 80);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(53, 12);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "股票名称";
            // 
            // textBoxStockCode
            // 
            this.textBoxStockCode.Location = new System.Drawing.Point(66, 44);
            this.textBoxStockCode.Name = "textBoxStockCode";
            this.textBoxStockCode.Size = new System.Drawing.Size(53, 21);
            this.textBoxStockCode.TabIndex = 3;
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(6, 50);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(53, 12);
            this.labelCode.TabIndex = 2;
            this.labelCode.Text = "股票代码";
            // 
            // labelGridType
            // 
            this.labelGridType.AutoSize = true;
            this.labelGridType.Location = new System.Drawing.Point(6, 17);
            this.labelGridType.Name = "labelGridType";
            this.labelGridType.Size = new System.Drawing.Size(53, 12);
            this.labelGridType.TabIndex = 0;
            this.labelGridType.Text = "网格类型";
            // 
            // comboBoxGridType
            // 
            this.comboBoxGridType.FormattingEnabled = true;
            this.comboBoxGridType.Location = new System.Drawing.Point(66, 12);
            this.comboBoxGridType.Name = "comboBoxGridType";
            this.comboBoxGridType.Size = new System.Drawing.Size(112, 20);
            this.comboBoxGridType.TabIndex = 1;
            this.comboBoxGridType.SelectedIndexChanged += new System.EventHandler(this.comboBoxGridType_SelectedIndexChanged);
            // 
            // textBoxMaxPrice
            // 
            this.textBoxMaxPrice.Location = new System.Drawing.Point(289, 74);
            this.textBoxMaxPrice.Name = "textBoxMaxPrice";
            this.textBoxMaxPrice.Size = new System.Drawing.Size(52, 21);
            this.textBoxMaxPrice.TabIndex = 13;
            this.textBoxMaxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelMaxPrice
            // 
            this.labelMaxPrice.AutoSize = true;
            this.labelMaxPrice.Location = new System.Drawing.Point(230, 80);
            this.labelMaxPrice.Name = "labelMaxPrice";
            this.labelMaxPrice.Size = new System.Drawing.Size(53, 12);
            this.labelMaxPrice.TabIndex = 12;
            this.labelMaxPrice.Text = "最大价格";
            // 
            // textBoxMinPrice
            // 
            this.textBoxMinPrice.Location = new System.Drawing.Point(289, 44);
            this.textBoxMinPrice.Name = "textBoxMinPrice";
            this.textBoxMinPrice.Size = new System.Drawing.Size(52, 21);
            this.textBoxMinPrice.TabIndex = 11;
            this.textBoxMinPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelInitVolume
            // 
            this.labelInitVolume.AutoSize = true;
            this.labelInitVolume.Location = new System.Drawing.Point(125, 80);
            this.labelInitVolume.Name = "labelInitVolume";
            this.labelInitVolume.Size = new System.Drawing.Size(53, 12);
            this.labelInitVolume.TabIndex = 8;
            this.labelInitVolume.Text = "初始持股";
            // 
            // textBoxInitVolume
            // 
            this.textBoxInitVolume.Location = new System.Drawing.Point(184, 74);
            this.textBoxInitVolume.Name = "textBoxInitVolume";
            this.textBoxInitVolume.Size = new System.Drawing.Size(40, 21);
            this.textBoxInitVolume.TabIndex = 9;
            this.textBoxInitVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelMinPrice
            // 
            this.labelMinPrice.AutoSize = true;
            this.labelMinPrice.Location = new System.Drawing.Point(230, 50);
            this.labelMinPrice.Name = "labelMinPrice";
            this.labelMinPrice.Size = new System.Drawing.Size(53, 12);
            this.labelMinPrice.TabIndex = 10;
            this.labelMinPrice.Text = "最小价格";
            // 
            // textBoxInitPrice
            // 
            this.textBoxInitPrice.Location = new System.Drawing.Point(184, 44);
            this.textBoxInitPrice.Name = "textBoxInitPrice";
            this.textBoxInitPrice.Size = new System.Drawing.Size(40, 21);
            this.textBoxInitPrice.TabIndex = 7;
            this.textBoxInitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelInitPrice
            // 
            this.labelInitPrice.AutoSize = true;
            this.labelInitPrice.Location = new System.Drawing.Point(125, 50);
            this.labelInitPrice.Name = "labelInitPrice";
            this.labelInitPrice.Size = new System.Drawing.Size(53, 12);
            this.labelInitPrice.TabIndex = 6;
            this.labelInitPrice.Text = "初始价格";
            // 
            // buttonCalcu
            // 
            this.buttonCalcu.Location = new System.Drawing.Point(201, 9);
            this.buttonCalcu.Name = "buttonCalcu";
            this.buttonCalcu.Size = new System.Drawing.Size(67, 23);
            this.buttonCalcu.TabIndex = 14;
            this.buttonCalcu.Text = "重新计算";
            this.buttonCalcu.UseVisualStyleBackColor = true;
            this.buttonCalcu.Click += new System.EventHandler(this.buttonCalcu_Click);
            // 
            // listViewGrid
            // 
            this.listViewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewGrid.Location = new System.Drawing.Point(0, 0);
            this.listViewGrid.Name = "listViewGrid";
            this.listViewGrid.Size = new System.Drawing.Size(407, 233);
            this.listViewGrid.TabIndex = 0;
            this.listViewGrid.UseCompatibleStateImageBehavior = false;
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
            this.Text = "定时提醒";
            this.Load += new System.EventHandler(this.GridTradingSettingsForm_Load);
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
        private System.Windows.Forms.Label labelGridType;
        private System.Windows.Forms.ComboBox comboBoxGridType;
        private System.Windows.Forms.TextBox textBoxMaxPrice;
        private System.Windows.Forms.Label labelMaxPrice;
        private System.Windows.Forms.TextBox textBoxMinPrice;
        private System.Windows.Forms.Label labelInitVolume;
        private System.Windows.Forms.TextBox textBoxInitVolume;
        private System.Windows.Forms.Label labelMinPrice;
        private System.Windows.Forms.TextBox textBoxInitPrice;
        private System.Windows.Forms.Label labelInitPrice;
        private System.Windows.Forms.Button buttonCalcu;
        private System.Windows.Forms.TextBox textBoxStockName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxStockCode;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Button buttonSave;
    }
}