namespace Dragonfly.Plugin.GridTrading
{
    partial class GridTradingMainPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridTradingMainPanel));
            this.listViewMain = new System.Windows.Forms.ListView();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewMain
            // 
            this.listViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMain.FullRowSelect = true;
            this.listViewMain.GridLines = true;
            this.listViewMain.Location = new System.Drawing.Point(0, 27);
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.ShowGroups = false;
            this.listViewMain.Size = new System.Drawing.Size(353, 123);
            this.listViewMain.TabIndex = 1;
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            this.listViewMain.View = System.Windows.Forms.View.Details;
            // 
            // toolStripMain
            // 
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSetting,
            this.toolStripButtonInit,
            this.toolStripButtonOrder,
            this.toolStripButton4,
            this.toolStripButton5});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(353, 27);
            this.toolStripMain.TabIndex = 2;
            this.toolStripMain.Text = "toolStripMain";
            // 
            // toolStripButtonSetting
            // 
            this.toolStripButtonSetting.Image = global::Dragonfly.Plugin.GridTrading.Properties.Resources.setting;
            this.toolStripButtonSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSetting.Name = "toolStripButtonSetting";
            this.toolStripButtonSetting.Size = new System.Drawing.Size(56, 24);
            this.toolStripButtonSetting.Text = "参数";
            this.toolStripButtonSetting.Click += new System.EventHandler(this.toolStripButtonSetting_Click);
            // 
            // toolStripButtonInit
            // 
            this.toolStripButtonInit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonInit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonInit.Image")));
            this.toolStripButtonInit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInit.Name = "toolStripButtonInit";
            this.toolStripButtonInit.Size = new System.Drawing.Size(60, 24);
            this.toolStripButtonInit.Text = "关联交易";
            this.toolStripButtonInit.Click += new System.EventHandler(this.toolStripButtonInit_Click);
            // 
            // toolStripButtonOrder
            // 
            this.toolStripButtonOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonOrder.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOrder.Image")));
            this.toolStripButtonOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOrder.Name = "toolStripButtonOrder";
            this.toolStripButtonOrder.Size = new System.Drawing.Size(36, 24);
            this.toolStripButtonOrder.Text = "下单";
            this.toolStripButtonOrder.Click += new System.EventHandler(this.toolStripButtonOrder_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(58, 24);
            this.toolStripButton4.Text = "Holding";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(37, 24);
            this.toolStripButton5.Text = "deal";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // GridTradingMainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewMain);
            this.Controls.Add(this.toolStripMain);
            this.Name = "GridTradingMainPanel";
            this.Size = new System.Drawing.Size(353, 150);
            this.Load += new System.EventHandler(this.GridTradingMainPanel_Load);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewMain;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonSetting;
        private System.Windows.Forms.ToolStripButton toolStripButtonInit;
        private System.Windows.Forms.ToolStripButton toolStripButtonOrder;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
    }
}
