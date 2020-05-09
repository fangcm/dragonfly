namespace Dragonfly.Plugin.GridTrading.Strategy
{
    partial class GridModifyForm
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.labelStrategy = new System.Windows.Forms.Label();
            this.comboBoxStockMarket = new System.Windows.Forms.ComboBox();
            this.comboBoxStrategy = new System.Windows.Forms.ComboBox();
            this.labelMarket = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxStockName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxStockCode = new System.Windows.Forms.TextBox();
            this.labelCode = new System.Windows.Forms.Label();
            this.textBoxMaxPrice = new System.Windows.Forms.TextBox();
            this.labelMaxPrice = new System.Windows.Forms.Label();
            this.textBoxMinPrice = new System.Windows.Forms.TextBox();
            this.labelInitVolume = new System.Windows.Forms.Label();
            this.textBoxInitVolume = new System.Windows.Forms.TextBox();
            this.labelMinPrice = new System.Windows.Forms.Label();
            this.textBoxInitPrice = new System.Windows.Forms.TextBox();
            this.labelInitPrice = new System.Windows.Forms.Label();
            this.listViewGrid = new System.Windows.Forms.ListView();
            this.checkBoxDisable = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer2.Panel1.Controls.Add(this.checkBoxDisable);
            this.splitContainer2.Panel1.Controls.Add(this.labelStrategy);
            this.splitContainer2.Panel1.Controls.Add(this.comboBoxStockMarket);
            this.splitContainer2.Panel1.Controls.Add(this.comboBoxStrategy);
            this.splitContainer2.Panel1.Controls.Add(this.labelMarket);
            this.splitContainer2.Panel1.Controls.Add(this.buttonSave);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxStockName);
            this.splitContainer2.Panel1.Controls.Add(this.labelName);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxStockCode);
            this.splitContainer2.Panel1.Controls.Add(this.labelCode);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxMaxPrice);
            this.splitContainer2.Panel1.Controls.Add(this.labelMaxPrice);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxMinPrice);
            this.splitContainer2.Panel1.Controls.Add(this.labelInitVolume);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxInitVolume);
            this.splitContainer2.Panel1.Controls.Add(this.labelMinPrice);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxInitPrice);
            this.splitContainer2.Panel1.Controls.Add(this.labelInitPrice);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listViewGrid);
            this.splitContainer2.Size = new System.Drawing.Size(609, 359);
            this.splitContainer2.SplitterDistance = 72;
            this.splitContainer2.TabIndex = 0;
            // 
            // labelStrategy
            // 
            this.labelStrategy.AutoSize = true;
            this.labelStrategy.Location = new System.Drawing.Point(246, 44);
            this.labelStrategy.Name = "labelStrategy";
            this.labelStrategy.Size = new System.Drawing.Size(53, 12);
            this.labelStrategy.TabIndex = 14;
            this.labelStrategy.Text = "网格策略";
            // 
            // comboBoxStockMarket
            // 
            this.comboBoxStockMarket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStockMarket.FormattingEnabled = true;
            this.comboBoxStockMarket.Items.AddRange(new object[] {
            "",
            "A股",
            "沪港通",
            "深港通"});
            this.comboBoxStockMarket.Location = new System.Drawing.Point(62, 5);
            this.comboBoxStockMarket.Name = "comboBoxStockMarket";
            this.comboBoxStockMarket.Size = new System.Drawing.Size(60, 20);
            this.comboBoxStockMarket.TabIndex = 1;
            this.comboBoxStockMarket.SelectedIndexChanged += new System.EventHandler(this.Data_Changed);
            // 
            // comboBoxStrategy
            // 
            this.comboBoxStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStrategy.FormattingEnabled = true;
            this.comboBoxStrategy.Items.AddRange(new object[] {
            "",
            "2, 20",
            "1.5,  20",
            "1, 20"});
            this.comboBoxStrategy.Location = new System.Drawing.Point(305, 38);
            this.comboBoxStrategy.Name = "comboBoxStrategy";
            this.comboBoxStrategy.Size = new System.Drawing.Size(120, 20);
            this.comboBoxStrategy.TabIndex = 15;
            this.comboBoxStrategy.SelectedIndexChanged += new System.EventHandler(this.comboBoxStrategy_SelectedIndexChanged);
            // 
            // labelMarket
            // 
            this.labelMarket.AutoSize = true;
            this.labelMarket.Location = new System.Drawing.Point(3, 9);
            this.labelMarket.Name = "labelMarket";
            this.labelMarket.Size = new System.Drawing.Size(53, 12);
            this.labelMarket.TabIndex = 0;
            this.labelMarket.Text = "交易市场";
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(509, 36);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 23);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxStockName
            // 
            this.textBoxStockName.Location = new System.Drawing.Point(305, 5);
            this.textBoxStockName.Name = "textBoxStockName";
            this.textBoxStockName.Size = new System.Drawing.Size(82, 21);
            this.textBoxStockName.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(246, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(53, 12);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "股票名称";
            // 
            // textBoxStockCode
            // 
            this.textBoxStockCode.Location = new System.Drawing.Point(187, 5);
            this.textBoxStockCode.Name = "textBoxStockCode";
            this.textBoxStockCode.Size = new System.Drawing.Size(53, 21);
            this.textBoxStockCode.TabIndex = 3;
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(128, 9);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(53, 12);
            this.labelCode.TabIndex = 2;
            this.labelCode.Text = "股票代码";
            // 
            // textBoxMaxPrice
            // 
            this.textBoxMaxPrice.Location = new System.Drawing.Point(188, 38);
            this.textBoxMaxPrice.Name = "textBoxMaxPrice";
            this.textBoxMaxPrice.Size = new System.Drawing.Size(52, 21);
            this.textBoxMaxPrice.TabIndex = 13;
            this.textBoxMaxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelMaxPrice
            // 
            this.labelMaxPrice.AutoSize = true;
            this.labelMaxPrice.Location = new System.Drawing.Point(129, 44);
            this.labelMaxPrice.Name = "labelMaxPrice";
            this.labelMaxPrice.Size = new System.Drawing.Size(53, 12);
            this.labelMaxPrice.TabIndex = 12;
            this.labelMaxPrice.Text = "最大价格";
            // 
            // textBoxMinPrice
            // 
            this.textBoxMinPrice.Location = new System.Drawing.Point(62, 38);
            this.textBoxMinPrice.Name = "textBoxMinPrice";
            this.textBoxMinPrice.Size = new System.Drawing.Size(52, 21);
            this.textBoxMinPrice.TabIndex = 11;
            this.textBoxMinPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelInitVolume
            // 
            this.labelInitVolume.AutoSize = true;
            this.labelInitVolume.Location = new System.Drawing.Point(498, 9);
            this.labelInitVolume.Name = "labelInitVolume";
            this.labelInitVolume.Size = new System.Drawing.Size(53, 12);
            this.labelInitVolume.TabIndex = 8;
            this.labelInitVolume.Text = "初始持股";
            // 
            // textBoxInitVolume
            // 
            this.textBoxInitVolume.Location = new System.Drawing.Point(557, 5);
            this.textBoxInitVolume.Name = "textBoxInitVolume";
            this.textBoxInitVolume.Size = new System.Drawing.Size(40, 21);
            this.textBoxInitVolume.TabIndex = 9;
            this.textBoxInitVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelMinPrice
            // 
            this.labelMinPrice.AutoSize = true;
            this.labelMinPrice.Location = new System.Drawing.Point(3, 44);
            this.labelMinPrice.Name = "labelMinPrice";
            this.labelMinPrice.Size = new System.Drawing.Size(53, 12);
            this.labelMinPrice.TabIndex = 10;
            this.labelMinPrice.Text = "最小价格";
            // 
            // textBoxInitPrice
            // 
            this.textBoxInitPrice.Location = new System.Drawing.Point(452, 5);
            this.textBoxInitPrice.Name = "textBoxInitPrice";
            this.textBoxInitPrice.Size = new System.Drawing.Size(40, 21);
            this.textBoxInitPrice.TabIndex = 7;
            this.textBoxInitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelInitPrice
            // 
            this.labelInitPrice.AutoSize = true;
            this.labelInitPrice.Location = new System.Drawing.Point(393, 9);
            this.labelInitPrice.Name = "labelInitPrice";
            this.labelInitPrice.Size = new System.Drawing.Size(53, 12);
            this.labelInitPrice.TabIndex = 6;
            this.labelInitPrice.Text = "初始价格";
            // 
            // listViewGrid
            // 
            this.listViewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewGrid.FullRowSelect = true;
            this.listViewGrid.Location = new System.Drawing.Point(0, 0);
            this.listViewGrid.Name = "listViewGrid";
            this.listViewGrid.Size = new System.Drawing.Size(609, 283);
            this.listViewGrid.TabIndex = 0;
            this.listViewGrid.UseCompatibleStateImageBehavior = false;
            this.listViewGrid.View = System.Windows.Forms.View.Details;
            // 
            // checkBoxDisable
            // 
            this.checkBoxDisable.AutoSize = true;
            this.checkBoxDisable.Location = new System.Drawing.Point(440, 41);
            this.checkBoxDisable.Name = "checkBoxDisable";
            this.checkBoxDisable.Size = new System.Drawing.Size(48, 16);
            this.checkBoxDisable.TabIndex = 17;
            this.checkBoxDisable.Text = "禁用";
            this.checkBoxDisable.UseVisualStyleBackColor = true;
            this.checkBoxDisable.CheckedChanged += new System.EventHandler(this.Data_Changed);
            // 
            // GridModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 359);
            this.Controls.Add(this.splitContainer2);
            this.MinimizeBox = false;
            this.Name = "GridModifyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "交易策略";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GridModifyForm_FormClosing);
            this.Load += new System.EventHandler(this.GridModifyForm_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxStockName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxStockCode;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.TextBox textBoxMaxPrice;
        private System.Windows.Forms.Label labelMaxPrice;
        private System.Windows.Forms.TextBox textBoxMinPrice;
        private System.Windows.Forms.Label labelInitVolume;
        private System.Windows.Forms.TextBox textBoxInitVolume;
        private System.Windows.Forms.Label labelMinPrice;
        private System.Windows.Forms.TextBox textBoxInitPrice;
        private System.Windows.Forms.Label labelInitPrice;
        private System.Windows.Forms.ListView listViewGrid;
        private System.Windows.Forms.Label labelMarket;
        private System.Windows.Forms.ComboBox comboBoxStrategy;
        private System.Windows.Forms.ComboBox comboBoxStockMarket;
        private System.Windows.Forms.Label labelStrategy;
        private System.Windows.Forms.CheckBox checkBoxDisable;
    }
}