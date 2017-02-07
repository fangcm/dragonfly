namespace Dragonfly.Plugin.Note
{
    partial class NoteMainPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteMainPanel));
            this.listViewMain = new System.Windows.Forms.ListView();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonShowHide = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonTitle = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripTextBoxTitle = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewMain
            // 
            this.listViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMain.FullRowSelect = true;
            this.listViewMain.GridLines = true;
            this.listViewMain.Location = new System.Drawing.Point(0, 25);
            this.listViewMain.MultiSelect = false;
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.ShowGroups = false;
            this.listViewMain.Size = new System.Drawing.Size(353, 125);
            this.listViewMain.TabIndex = 1;
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            this.listViewMain.View = System.Windows.Forms.View.Details;
            this.listViewMain.SelectedIndexChanged += new System.EventHandler(this.listViewMain_SelectedIndexChanged);
            this.listViewMain.DoubleClick += new System.EventHandler(this.listViewMain_DoubleClick);
            // 
            // toolStripMain
            // 
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.toolStripSeparator1,
            this.toolStripButtonShowHide,
            this.toolStripDropDownButtonTitle,
            this.toolStripSeparator2,
            this.toolStripButtonDelete});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(353, 25);
            this.toolStripMain.TabIndex = 2;
            this.toolStripMain.Text = "toolStripMain";
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.Image = global::Dragonfly.Plugin.Note.Properties.Resources.refresh;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonRefresh.Text = "刷新";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonShowHide
            // 
            this.toolStripButtonShowHide.Image = global::Dragonfly.Plugin.Note.Properties.Resources.hide;
            this.toolStripButtonShowHide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowHide.Name = "toolStripButtonShowHide";
            this.toolStripButtonShowHide.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonShowHide.Text = "隐藏";
            this.toolStripButtonShowHide.Click += new System.EventHandler(this.toolStripButtonShowHide_Click);
            // 
            // toolStripDropDownButtonTitle
            // 
            this.toolStripDropDownButtonTitle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonTitle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxTitle});
            this.toolStripDropDownButtonTitle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonTitle.Image")));
            this.toolStripDropDownButtonTitle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonTitle.Name = "toolStripDropDownButtonTitle";
            this.toolStripDropDownButtonTitle.Size = new System.Drawing.Size(69, 22);
            this.toolStripDropDownButtonTitle.Text = "修改标题";
            this.toolStripDropDownButtonTitle.DropDownOpening += new System.EventHandler(this.toolStripDropDownButtonTitle_DropDownOpening);
            // 
            // toolStripTextBoxTitle
            // 
            this.toolStripTextBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxTitle.Name = "toolStripTextBoxTitle";
            this.toolStripTextBoxTitle.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxTitle_KeyDown);
            this.toolStripTextBoxTitle.TextChanged += new System.EventHandler(this.toolStripTextBoxTitle_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Image = global::Dragonfly.Plugin.Note.Properties.Resources.del;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonDelete.Text = "删除";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // NoteMainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewMain);
            this.Controls.Add(this.toolStripMain);
            this.Name = "NoteMainPanel";
            this.Size = new System.Drawing.Size(353, 150);
            this.Load += new System.EventHandler(this.NoteMainPanel_Load);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewMain;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowHide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonTitle;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxTitle;

    }
}
