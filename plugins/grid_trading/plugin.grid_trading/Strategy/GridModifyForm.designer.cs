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
            this.buttonCancel = new System.Windows.Forms.Button();
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
            this.splitContainer2.Panel1.Controls.Add(this.buttonCancel);
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
            this.splitContainer2.Size = new System.Drawing.Size(557, 359);
            this.splitContainer2.SplitterDistance = 72;
            this.splitContainer2.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(354, 36);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(60, 23);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(354, 6);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(60, 23);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxStockName
            // 
            this.textBoxStockName.Location = new System.Drawing.Point(63, 38);
            this.textBoxStockName.Name = "textBoxStockName";
            this.textBoxStockName.Size = new System.Drawing.Size(53, 21);
            this.textBoxStockName.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(4, 44);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(53, 12);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "股票名称";
            // 
            // textBoxStockCode
            // 
            this.textBoxStockCode.Location = new System.Drawing.Point(63, 8);
            this.textBoxStockCode.Name = "textBoxStockCode";
            this.textBoxStockCode.Size = new System.Drawing.Size(53, 21);
            this.textBoxStockCode.TabIndex = 3;
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(3, 14);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(53, 12);
            this.labelCode.TabIndex = 2;
            this.labelCode.Text = "股票代码";
            // 
            // textBoxMaxPrice
            // 
            this.textBoxMaxPrice.Location = new System.Drawing.Point(286, 38);
            this.textBoxMaxPrice.Name = "textBoxMaxPrice";
            this.textBoxMaxPrice.Size = new System.Drawing.Size(52, 21);
            this.textBoxMaxPrice.TabIndex = 13;
            this.textBoxMaxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelMaxPrice
            // 
            this.labelMaxPrice.AutoSize = true;
            this.labelMaxPrice.Location = new System.Drawing.Point(227, 44);
            this.labelMaxPrice.Name = "labelMaxPrice";
            this.labelMaxPrice.Size = new System.Drawing.Size(53, 12);
            this.labelMaxPrice.TabIndex = 12;
            this.labelMaxPrice.Text = "最大价格";
            // 
            // textBoxMinPrice
            // 
            this.textBoxMinPrice.Location = new System.Drawing.Point(286, 8);
            this.textBoxMinPrice.Name = "textBoxMinPrice";
            this.textBoxMinPrice.Size = new System.Drawing.Size(52, 21);
            this.textBoxMinPrice.TabIndex = 11;
            this.textBoxMinPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelInitVolume
            // 
            this.labelInitVolume.AutoSize = true;
            this.labelInitVolume.Location = new System.Drawing.Point(122, 44);
            this.labelInitVolume.Name = "labelInitVolume";
            this.labelInitVolume.Size = new System.Drawing.Size(53, 12);
            this.labelInitVolume.TabIndex = 8;
            this.labelInitVolume.Text = "初始持股";
            // 
            // textBoxInitVolume
            // 
            this.textBoxInitVolume.Location = new System.Drawing.Point(181, 38);
            this.textBoxInitVolume.Name = "textBoxInitVolume";
            this.textBoxInitVolume.Size = new System.Drawing.Size(40, 21);
            this.textBoxInitVolume.TabIndex = 9;
            this.textBoxInitVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelMinPrice
            // 
            this.labelMinPrice.AutoSize = true;
            this.labelMinPrice.Location = new System.Drawing.Point(227, 14);
            this.labelMinPrice.Name = "labelMinPrice";
            this.labelMinPrice.Size = new System.Drawing.Size(53, 12);
            this.labelMinPrice.TabIndex = 10;
            this.labelMinPrice.Text = "最小价格";
            // 
            // textBoxInitPrice
            // 
            this.textBoxInitPrice.Location = new System.Drawing.Point(181, 8);
            this.textBoxInitPrice.Name = "textBoxInitPrice";
            this.textBoxInitPrice.Size = new System.Drawing.Size(40, 21);
            this.textBoxInitPrice.TabIndex = 7;
            this.textBoxInitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelInitPrice
            // 
            this.labelInitPrice.AutoSize = true;
            this.labelInitPrice.Location = new System.Drawing.Point(122, 14);
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
            this.listViewGrid.Size = new System.Drawing.Size(557, 283);
            this.listViewGrid.TabIndex = 0;
            this.listViewGrid.UseCompatibleStateImageBehavior = false;
            this.listViewGrid.View = System.Windows.Forms.View.Details;
            // 
            // GridModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(557, 359);
            this.Controls.Add(this.splitContainer2);
            this.MinimizeBox = false;
            this.Name = "GridModifyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "交易策略";
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
        private System.Windows.Forms.Button buttonCancel;
    }
}