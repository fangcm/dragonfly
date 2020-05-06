namespace Dragonfly.Plugin.GridTrading
{
    partial class TradingForm
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
            this.groupBoxBuy = new System.Windows.Forms.GroupBox();
            this.buttonBuy = new System.Windows.Forms.Button();
            this.textBoxBuyVolume = new System.Windows.Forms.MaskedTextBox();
            this.textBoxBuyPrice = new System.Windows.Forms.MaskedTextBox();
            this.labelBuyVolume = new System.Windows.Forms.Label();
            this.labelBuyPrice = new System.Windows.Forms.Label();
            this.groupBoxSell = new System.Windows.Forms.GroupBox();
            this.buttonSell = new System.Windows.Forms.Button();
            this.textBoxSellVolume = new System.Windows.Forms.MaskedTextBox();
            this.labelSellVolume = new System.Windows.Forms.Label();
            this.textBoxSellPrice = new System.Windows.Forms.MaskedTextBox();
            this.labelSellPrice = new System.Windows.Forms.Label();
            this.textBoxStockCode = new System.Windows.Forms.MaskedTextBox();
            this.labelStockCode = new System.Windows.Forms.Label();
            this.labelStockMarket = new System.Windows.Forms.Label();
            this.comboBoxStockMarket = new System.Windows.Forms.ComboBox();
            this.groupBoxBuy.SuspendLayout();
            this.groupBoxSell.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxBuy
            // 
            this.groupBoxBuy.Controls.Add(this.buttonBuy);
            this.groupBoxBuy.Controls.Add(this.textBoxBuyVolume);
            this.groupBoxBuy.Controls.Add(this.textBoxBuyPrice);
            this.groupBoxBuy.Controls.Add(this.labelBuyVolume);
            this.groupBoxBuy.Controls.Add(this.labelBuyPrice);
            this.groupBoxBuy.Location = new System.Drawing.Point(12, 82);
            this.groupBoxBuy.Name = "groupBoxBuy";
            this.groupBoxBuy.Size = new System.Drawing.Size(138, 145);
            this.groupBoxBuy.TabIndex = 4;
            this.groupBoxBuy.TabStop = false;
            this.groupBoxBuy.Text = "买入";
            // 
            // buttonBuy
            // 
            this.buttonBuy.Location = new System.Drawing.Point(29, 101);
            this.buttonBuy.Name = "buttonBuy";
            this.buttonBuy.Size = new System.Drawing.Size(75, 23);
            this.buttonBuy.TabIndex = 4;
            this.buttonBuy.Text = "买入确认";
            this.buttonBuy.UseVisualStyleBackColor = true;
            this.buttonBuy.Click += new System.EventHandler(this.buttonBuy_Click);
            // 
            // textBoxBuyVolume
            // 
            this.textBoxBuyVolume.Location = new System.Drawing.Point(67, 56);
            this.textBoxBuyVolume.Mask = "999999";
            this.textBoxBuyVolume.Name = "textBoxBuyVolume";
            this.textBoxBuyVolume.Size = new System.Drawing.Size(57, 21);
            this.textBoxBuyVolume.TabIndex = 3;
            // 
            // textBoxBuyPrice
            // 
            this.textBoxBuyPrice.Location = new System.Drawing.Point(67, 22);
            this.textBoxBuyPrice.Name = "textBoxBuyPrice";
            this.textBoxBuyPrice.Size = new System.Drawing.Size(58, 21);
            this.textBoxBuyPrice.TabIndex = 1;
            // 
            // labelBuyVolume
            // 
            this.labelBuyVolume.AutoSize = true;
            this.labelBuyVolume.Location = new System.Drawing.Point(8, 59);
            this.labelBuyVolume.Name = "labelBuyVolume";
            this.labelBuyVolume.Size = new System.Drawing.Size(53, 12);
            this.labelBuyVolume.TabIndex = 2;
            this.labelBuyVolume.Text = "买入数量";
            // 
            // labelBuyPrice
            // 
            this.labelBuyPrice.AutoSize = true;
            this.labelBuyPrice.Location = new System.Drawing.Point(6, 25);
            this.labelBuyPrice.Name = "labelBuyPrice";
            this.labelBuyPrice.Size = new System.Drawing.Size(53, 12);
            this.labelBuyPrice.TabIndex = 0;
            this.labelBuyPrice.Text = "买入价格";
            // 
            // groupBoxSell
            // 
            this.groupBoxSell.Controls.Add(this.buttonSell);
            this.groupBoxSell.Controls.Add(this.textBoxSellVolume);
            this.groupBoxSell.Controls.Add(this.labelSellVolume);
            this.groupBoxSell.Controls.Add(this.textBoxSellPrice);
            this.groupBoxSell.Controls.Add(this.labelSellPrice);
            this.groupBoxSell.Location = new System.Drawing.Point(174, 82);
            this.groupBoxSell.Name = "groupBoxSell";
            this.groupBoxSell.Size = new System.Drawing.Size(136, 145);
            this.groupBoxSell.TabIndex = 5;
            this.groupBoxSell.TabStop = false;
            this.groupBoxSell.Text = "卖出";
            // 
            // buttonSell
            // 
            this.buttonSell.Location = new System.Drawing.Point(38, 101);
            this.buttonSell.Name = "buttonSell";
            this.buttonSell.Size = new System.Drawing.Size(75, 23);
            this.buttonSell.TabIndex = 4;
            this.buttonSell.Text = "卖出确认";
            this.buttonSell.UseVisualStyleBackColor = true;
            this.buttonSell.Click += new System.EventHandler(this.buttonSell_Click);
            // 
            // textBoxSellVolume
            // 
            this.textBoxSellVolume.Location = new System.Drawing.Point(65, 56);
            this.textBoxSellVolume.Mask = "999999";
            this.textBoxSellVolume.Name = "textBoxSellVolume";
            this.textBoxSellVolume.Size = new System.Drawing.Size(57, 21);
            this.textBoxSellVolume.TabIndex = 3;
            // 
            // labelSellVolume
            // 
            this.labelSellVolume.AutoSize = true;
            this.labelSellVolume.Location = new System.Drawing.Point(6, 59);
            this.labelSellVolume.Name = "labelSellVolume";
            this.labelSellVolume.Size = new System.Drawing.Size(53, 12);
            this.labelSellVolume.TabIndex = 2;
            this.labelSellVolume.Text = "卖出数量";
            // 
            // textBoxSellPrice
            // 
            this.textBoxSellPrice.Location = new System.Drawing.Point(65, 22);
            this.textBoxSellPrice.Name = "textBoxSellPrice";
            this.textBoxSellPrice.Size = new System.Drawing.Size(58, 21);
            this.textBoxSellPrice.TabIndex = 1;
            // 
            // labelSellPrice
            // 
            this.labelSellPrice.AutoSize = true;
            this.labelSellPrice.Location = new System.Drawing.Point(6, 25);
            this.labelSellPrice.Name = "labelSellPrice";
            this.labelSellPrice.Size = new System.Drawing.Size(53, 12);
            this.labelSellPrice.TabIndex = 0;
            this.labelSellPrice.Text = "卖出价格";
            // 
            // textBoxStockCode
            // 
            this.textBoxStockCode.Location = new System.Drawing.Point(153, 47);
            this.textBoxStockCode.Name = "textBoxStockCode";
            this.textBoxStockCode.Size = new System.Drawing.Size(78, 21);
            this.textBoxStockCode.TabIndex = 3;
            // 
            // labelStockCode
            // 
            this.labelStockCode.AutoSize = true;
            this.labelStockCode.Location = new System.Drawing.Point(84, 50);
            this.labelStockCode.Name = "labelStockCode";
            this.labelStockCode.Size = new System.Drawing.Size(53, 12);
            this.labelStockCode.TabIndex = 2;
            this.labelStockCode.Text = "股票代码";
            // 
            // labelStockMarket
            // 
            this.labelStockMarket.AutoSize = true;
            this.labelStockMarket.Location = new System.Drawing.Point(84, 25);
            this.labelStockMarket.Name = "labelStockMarket";
            this.labelStockMarket.Size = new System.Drawing.Size(53, 12);
            this.labelStockMarket.TabIndex = 0;
            this.labelStockMarket.Text = "交易市场";
            // 
            // comboBoxStockMarket
            // 
            this.comboBoxStockMarket.FormattingEnabled = true;
            this.comboBoxStockMarket.Items.AddRange(new object[] {
            "A股",
            "沪港通",
            "深港通"});
            this.comboBoxStockMarket.Location = new System.Drawing.Point(153, 20);
            this.comboBoxStockMarket.Name = "comboBoxStockMarket";
            this.comboBoxStockMarket.Size = new System.Drawing.Size(78, 20);
            this.comboBoxStockMarket.TabIndex = 1;
            // 
            // TradingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 246);
            this.Controls.Add(this.comboBoxStockMarket);
            this.Controls.Add(this.labelStockMarket);
            this.Controls.Add(this.labelStockCode);
            this.Controls.Add(this.groupBoxBuy);
            this.Controls.Add(this.textBoxStockCode);
            this.Controls.Add(this.groupBoxSell);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TradingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下单";
            this.Load += new System.EventHandler(this.GridTradingSettingsForm_Load);
            this.groupBoxBuy.ResumeLayout(false);
            this.groupBoxBuy.PerformLayout();
            this.groupBoxSell.ResumeLayout(false);
            this.groupBoxSell.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxBuy;
        private System.Windows.Forms.Label labelBuyPrice;
        private System.Windows.Forms.Label labelBuyVolume;
        private System.Windows.Forms.GroupBox groupBoxSell;
        private System.Windows.Forms.Label labelSellVolume;
        private System.Windows.Forms.Label labelSellPrice;
        private System.Windows.Forms.ComboBox comboBoxStockMarket;
        private System.Windows.Forms.Label labelStockMarket;
        private System.Windows.Forms.Label labelStockCode;
        private System.Windows.Forms.MaskedTextBox textBoxStockCode;
        private System.Windows.Forms.MaskedTextBox textBoxSellVolume;
        private System.Windows.Forms.MaskedTextBox textBoxSellPrice;
        private System.Windows.Forms.MaskedTextBox textBoxBuyVolume;
        private System.Windows.Forms.MaskedTextBox textBoxBuyPrice;
        private System.Windows.Forms.Button buttonBuy;
        private System.Windows.Forms.Button buttonSell;
    }
}