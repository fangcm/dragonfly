namespace Dragonfly.Main
{
    partial class MainAppForm
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
            this.components = new System.ComponentModel.Container();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.contextMenuStripNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuShowMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 24);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(779, 306);
            this.tabControlMain.TabIndex = 1;
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStripMain.Size = new System.Drawing.Size(779, 24);
            this.menuStripMain.TabIndex = 3;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // contextMenuStripNotify
            // 
            this.contextMenuStripNotify.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.toolStripMenuShowMainForm,
            this.toolStripSeparator1,
            this.toolStripMenuAbout,
            this.toolStripSeparator2,
            this.toolStripMenuExit});
            this.contextMenuStripNotify.Name = "contextMenuStripNotify";
            this.contextMenuStripNotify.Size = new System.Drawing.Size(170, 100);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(166, 6);
            // 
            // toolStripMenuShowMainForm
            // 
            this.toolStripMenuShowMainForm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripMenuShowMainForm.Name = "toolStripMenuShowMainForm";
            this.toolStripMenuShowMainForm.Size = new System.Drawing.Size(169, 26);
            this.toolStripMenuShowMainForm.Text = "主程序...";
            this.toolStripMenuShowMainForm.Click += new System.EventHandler(this.toolStripMenuShowMainForm_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // toolStripMenuAbout
            // 
            this.toolStripMenuAbout.Image = global::Dragonfly.Main.Properties.Resources.about;
            this.toolStripMenuAbout.ImageTransparentColor = System.Drawing.Color.Teal;
            this.toolStripMenuAbout.Name = "toolStripMenuAbout";
            this.toolStripMenuAbout.Size = new System.Drawing.Size(169, 26);
            this.toolStripMenuAbout.Text = "关于本软件...";
            this.toolStripMenuAbout.Click += new System.EventHandler(this.toolStripMenuAbout_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(166, 6);
            // 
            // toolStripMenuExit
            // 
            this.toolStripMenuExit.Name = "toolStripMenuExit";
            this.toolStripMenuExit.Size = new System.Drawing.Size(169, 26);
            this.toolStripMenuExit.Text = "退出";
            this.toolStripMenuExit.Click += new System.EventHandler(this.toolStripMenuExit_Click);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.BalloonTipText = "非常感谢您使用本软件，欢迎提供宝贵意见。";
            this.notifyIconMain.BalloonTipTitle = "便签（蜻蜓）";
            this.notifyIconMain.ContextMenuStrip = this.contextMenuStripNotify;
            this.notifyIconMain.Icon = global::Dragonfly.Main.Properties.Resources.NotifyIcon;
            this.notifyIconMain.Text = "便签（蜻蜓）";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.DoubleClick += new System.EventHandler(this.notifyIconMain_DoubleClick);
            // 
            // MainAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 330);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainAppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎使用 [蜻蜓] 工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainAppForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainAppForm_FormClosed);
            this.Load += new System.EventHandler(this.MainAppForm_Load);
            this.Shown += new System.EventHandler(this.MainAppForm_Shown);
            this.contextMenuStripNotify.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotify;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuShowMainForm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAbout;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuExit;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

