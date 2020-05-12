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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelMarket = new System.Windows.Forms.Label();
            this.labelInitPrice = new System.Windows.Forms.Label();
            this.checkBoxDisable = new System.Windows.Forms.CheckBox();
            this.textBoxInitPrice = new System.Windows.Forms.TextBox();
            this.comboBoxStockMarket = new System.Windows.Forms.ComboBox();
            this.textBoxInitVolume = new System.Windows.Forms.TextBox();
            this.labelInitVolume = new System.Windows.Forms.Label();
            this.labelCode = new System.Windows.Forms.Label();
            this.textBoxStockName = new System.Windows.Forms.TextBox();
            this.textBoxStockCode = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelPercent = new System.Windows.Forms.Label();
            this.textBoxPriceStrategy = new System.Windows.Forms.TextBox();
            this.labelVolumeStrategy = new System.Windows.Forms.Label();
            this.textBoxVolumeStrategy = new System.Windows.Forms.TextBox();
            this.labelPriceStrategy = new System.Windows.Forms.Label();
            this.buttonReBuild = new System.Windows.Forms.Button();
            this.labelMinPrice = new System.Windows.Forms.Label();
            this.textBoxMinPrice = new System.Windows.Forms.TextBox();
            this.labelMaxPrice = new System.Windows.Forms.Label();
            this.textBoxMaxPrice = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.listViewGrid = new System.Windows.Forms.ListView();
            this.textBoxPriceDecimalPlace = new System.Windows.Forms.TextBox();
            this.labelPriceDecimalPlace = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel1.Controls.Add(this.buttonSave);
            this.splitContainer2.Panel1MinSize = 115;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listViewGrid);
            this.splitContainer2.Size = new System.Drawing.Size(651, 554);
            this.splitContainer2.SplitterDistance = 115;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelMarket);
            this.groupBox1.Controls.Add(this.labelInitPrice);
            this.groupBox1.Controls.Add(this.checkBoxDisable);
            this.groupBox1.Controls.Add(this.textBoxInitPrice);
            this.groupBox1.Controls.Add(this.comboBoxStockMarket);
            this.groupBox1.Controls.Add(this.textBoxInitVolume);
            this.groupBox1.Controls.Add(this.labelInitVolume);
            this.groupBox1.Controls.Add(this.labelCode);
            this.groupBox1.Controls.Add(this.textBoxStockName);
            this.groupBox1.Controls.Add(this.textBoxStockCode);
            this.groupBox1.Controls.Add(this.labelName);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // labelMarket
            // 
            this.labelMarket.AutoSize = true;
            this.labelMarket.Location = new System.Drawing.Point(6, 21);
            this.labelMarket.Name = "labelMarket";
            this.labelMarket.Size = new System.Drawing.Size(53, 12);
            this.labelMarket.TabIndex = 0;
            this.labelMarket.Text = "交易市场";
            // 
            // labelInitPrice
            // 
            this.labelInitPrice.AutoSize = true;
            this.labelInitPrice.Location = new System.Drawing.Point(6, 76);
            this.labelInitPrice.Name = "labelInitPrice";
            this.labelInitPrice.Size = new System.Drawing.Size(53, 12);
            this.labelInitPrice.TabIndex = 7;
            this.labelInitPrice.Text = "初始价格";
            // 
            // checkBoxDisable
            // 
            this.checkBoxDisable.AutoSize = true;
            this.checkBoxDisable.Location = new System.Drawing.Point(183, 22);
            this.checkBoxDisable.Name = "checkBoxDisable";
            this.checkBoxDisable.Size = new System.Drawing.Size(48, 16);
            this.checkBoxDisable.TabIndex = 2;
            this.checkBoxDisable.Text = "禁用";
            this.checkBoxDisable.UseVisualStyleBackColor = true;
            this.checkBoxDisable.CheckedChanged += new System.EventHandler(this.Data_Changed);
            // 
            // textBoxInitPrice
            // 
            this.textBoxInitPrice.Location = new System.Drawing.Point(65, 72);
            this.textBoxInitPrice.Name = "textBoxInitPrice";
            this.textBoxInitPrice.Size = new System.Drawing.Size(40, 21);
            this.textBoxInitPrice.TabIndex = 8;
            this.textBoxInitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.comboBoxStockMarket.Location = new System.Drawing.Point(65, 17);
            this.comboBoxStockMarket.Name = "comboBoxStockMarket";
            this.comboBoxStockMarket.Size = new System.Drawing.Size(77, 20);
            this.comboBoxStockMarket.TabIndex = 1;
            this.comboBoxStockMarket.SelectedIndexChanged += new System.EventHandler(this.Data_Changed);
            // 
            // textBoxInitVolume
            // 
            this.textBoxInitVolume.Location = new System.Drawing.Point(183, 72);
            this.textBoxInitVolume.Name = "textBoxInitVolume";
            this.textBoxInitVolume.Size = new System.Drawing.Size(40, 21);
            this.textBoxInitVolume.TabIndex = 10;
            this.textBoxInitVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelInitVolume
            // 
            this.labelInitVolume.AutoSize = true;
            this.labelInitVolume.Location = new System.Drawing.Point(124, 76);
            this.labelInitVolume.Name = "labelInitVolume";
            this.labelInitVolume.Size = new System.Drawing.Size(53, 12);
            this.labelInitVolume.TabIndex = 9;
            this.labelInitVolume.Text = "初始持股";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(6, 47);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(53, 12);
            this.labelCode.TabIndex = 3;
            this.labelCode.Text = "股票代码";
            // 
            // textBoxStockName
            // 
            this.textBoxStockName.Location = new System.Drawing.Point(183, 43);
            this.textBoxStockName.Name = "textBoxStockName";
            this.textBoxStockName.Size = new System.Drawing.Size(82, 21);
            this.textBoxStockName.TabIndex = 6;
            // 
            // textBoxStockCode
            // 
            this.textBoxStockCode.Location = new System.Drawing.Point(65, 43);
            this.textBoxStockCode.Name = "textBoxStockCode";
            this.textBoxStockCode.Size = new System.Drawing.Size(53, 21);
            this.textBoxStockCode.TabIndex = 4;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(124, 47);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(53, 12);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "股票名称";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxPriceDecimalPlace);
            this.groupBox2.Controls.Add(this.labelPriceDecimalPlace);
            this.groupBox2.Controls.Add(this.labelPercent);
            this.groupBox2.Controls.Add(this.textBoxPriceStrategy);
            this.groupBox2.Controls.Add(this.labelVolumeStrategy);
            this.groupBox2.Controls.Add(this.textBoxVolumeStrategy);
            this.groupBox2.Controls.Add(this.labelPriceStrategy);
            this.groupBox2.Controls.Add(this.buttonReBuild);
            this.groupBox2.Controls.Add(this.labelMinPrice);
            this.groupBox2.Controls.Add(this.textBoxMinPrice);
            this.groupBox2.Controls.Add(this.labelMaxPrice);
            this.groupBox2.Controls.Add(this.textBoxMaxPrice);
            this.groupBox2.Location = new System.Drawing.Point(297, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 104);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // labelPercent
            // 
            this.labelPercent.AutoSize = true;
            this.labelPercent.Location = new System.Drawing.Point(108, 50);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(11, 12);
            this.labelPercent.TabIndex = 10;
            this.labelPercent.Text = "%";
            // 
            // textBoxPriceStrategy
            // 
            this.textBoxPriceStrategy.Location = new System.Drawing.Point(72, 44);
            this.textBoxPriceStrategy.Name = "textBoxPriceStrategy";
            this.textBoxPriceStrategy.Size = new System.Drawing.Size(30, 21);
            this.textBoxPriceStrategy.TabIndex = 7;
            this.textBoxPriceStrategy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelVolumeStrategy
            // 
            this.labelVolumeStrategy.AutoSize = true;
            this.labelVolumeStrategy.Location = new System.Drawing.Point(139, 50);
            this.labelVolumeStrategy.Name = "labelVolumeStrategy";
            this.labelVolumeStrategy.Size = new System.Drawing.Size(53, 12);
            this.labelVolumeStrategy.TabIndex = 8;
            this.labelVolumeStrategy.Text = "数量策略";
            // 
            // textBoxVolumeStrategy
            // 
            this.textBoxVolumeStrategy.Location = new System.Drawing.Point(198, 44);
            this.textBoxVolumeStrategy.Name = "textBoxVolumeStrategy";
            this.textBoxVolumeStrategy.Size = new System.Drawing.Size(52, 21);
            this.textBoxVolumeStrategy.TabIndex = 9;
            this.textBoxVolumeStrategy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelPriceStrategy
            // 
            this.labelPriceStrategy.AutoSize = true;
            this.labelPriceStrategy.Location = new System.Drawing.Point(13, 50);
            this.labelPriceStrategy.Name = "labelPriceStrategy";
            this.labelPriceStrategy.Size = new System.Drawing.Size(53, 12);
            this.labelPriceStrategy.TabIndex = 4;
            this.labelPriceStrategy.Text = "价格策略";
            // 
            // buttonReBuild
            // 
            this.buttonReBuild.Location = new System.Drawing.Point(162, 70);
            this.buttonReBuild.Name = "buttonReBuild";
            this.buttonReBuild.Size = new System.Drawing.Size(88, 23);
            this.buttonReBuild.TabIndex = 6;
            this.buttonReBuild.Text = "重新生成网格";
            this.buttonReBuild.UseVisualStyleBackColor = true;
            this.buttonReBuild.Click += new System.EventHandler(this.buttonReBuild_Click);
            // 
            // labelMinPrice
            // 
            this.labelMinPrice.AutoSize = true;
            this.labelMinPrice.Location = new System.Drawing.Point(13, 23);
            this.labelMinPrice.Name = "labelMinPrice";
            this.labelMinPrice.Size = new System.Drawing.Size(53, 12);
            this.labelMinPrice.TabIndex = 0;
            this.labelMinPrice.Text = "最小价格";
            // 
            // textBoxMinPrice
            // 
            this.textBoxMinPrice.Location = new System.Drawing.Point(72, 17);
            this.textBoxMinPrice.Name = "textBoxMinPrice";
            this.textBoxMinPrice.Size = new System.Drawing.Size(52, 21);
            this.textBoxMinPrice.TabIndex = 1;
            this.textBoxMinPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelMaxPrice
            // 
            this.labelMaxPrice.AutoSize = true;
            this.labelMaxPrice.Location = new System.Drawing.Point(139, 23);
            this.labelMaxPrice.Name = "labelMaxPrice";
            this.labelMaxPrice.Size = new System.Drawing.Size(53, 12);
            this.labelMaxPrice.TabIndex = 2;
            this.labelMaxPrice.Text = "最大价格";
            // 
            // textBoxMaxPrice
            // 
            this.textBoxMaxPrice.Location = new System.Drawing.Point(198, 17);
            this.textBoxMaxPrice.Name = "textBoxMaxPrice";
            this.textBoxMaxPrice.Size = new System.Drawing.Size(52, 21);
            this.textBoxMaxPrice.TabIndex = 3;
            this.textBoxMaxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(563, 20);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // listViewGrid
            // 
            this.listViewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewGrid.FullRowSelect = true;
            this.listViewGrid.Location = new System.Drawing.Point(0, 0);
            this.listViewGrid.Name = "listViewGrid";
            this.listViewGrid.Size = new System.Drawing.Size(651, 435);
            this.listViewGrid.TabIndex = 0;
            this.listViewGrid.UseCompatibleStateImageBehavior = false;
            this.listViewGrid.View = System.Windows.Forms.View.Details;
            // 
            // textBoxPriceDecimalPlace
            // 
            this.textBoxPriceDecimalPlace.Location = new System.Drawing.Point(72, 70);
            this.textBoxPriceDecimalPlace.Name = "textBoxPriceDecimalPlace";
            this.textBoxPriceDecimalPlace.Size = new System.Drawing.Size(30, 21);
            this.textBoxPriceDecimalPlace.TabIndex = 12;
            this.textBoxPriceDecimalPlace.Text = "2";
            this.textBoxPriceDecimalPlace.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelPriceDecimalPlace
            // 
            this.labelPriceDecimalPlace.AutoSize = true;
            this.labelPriceDecimalPlace.Location = new System.Drawing.Point(13, 76);
            this.labelPriceDecimalPlace.Name = "labelPriceDecimalPlace";
            this.labelPriceDecimalPlace.Size = new System.Drawing.Size(53, 12);
            this.labelPriceDecimalPlace.TabIndex = 11;
            this.labelPriceDecimalPlace.Text = "小数位数";
            // 
            // GridModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 554);
            this.Controls.Add(this.splitContainer2);
            this.MinimizeBox = false;
            this.Name = "GridModifyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "交易策略";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GridModifyForm_FormClosing);
            this.Load += new System.EventHandler(this.GridModifyForm_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.ComboBox comboBoxStockMarket;
        private System.Windows.Forms.Label labelPriceStrategy;
        private System.Windows.Forms.CheckBox checkBoxDisable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonReBuild;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.TextBox textBoxPriceStrategy;
        private System.Windows.Forms.Label labelVolumeStrategy;
        private System.Windows.Forms.TextBox textBoxVolumeStrategy;
        private System.Windows.Forms.TextBox textBoxPriceDecimalPlace;
        private System.Windows.Forms.Label labelPriceDecimalPlace;
    }
}