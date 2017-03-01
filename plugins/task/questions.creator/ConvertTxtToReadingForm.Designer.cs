namespace Dragonfly.Questions.Creator
{
    partial class ConvertTxtToReadingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConvertTxtToReadingForm));
            this.txt_xmlreading = new Dragonfly.Questions.RichTextBoxEx();
            this.txt_rawtext = new Dragonfly.Questions.RichTextBoxEx();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tsb_translate = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_xmlreading
            // 
            this.txt_xmlreading.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_xmlreading.DetectUrls = false;
            this.txt_xmlreading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_xmlreading.Font = new System.Drawing.Font("宋体", 14F);
            this.txt_xmlreading.Location = new System.Drawing.Point(0, 0);
            this.txt_xmlreading.Margin = new System.Windows.Forms.Padding(4);
            this.txt_xmlreading.Name = "txt_xmlreading";
            this.txt_xmlreading.ReadOnly = true;
            this.txt_xmlreading.Size = new System.Drawing.Size(534, 573);
            this.txt_xmlreading.TabIndex = 23;
            this.txt_xmlreading.Text = "";
            // 
            // txt_rawtext
            // 
            this.txt_rawtext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_rawtext.DetectUrls = false;
            this.txt_rawtext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_rawtext.Font = new System.Drawing.Font("宋体", 14F);
            this.txt_rawtext.Location = new System.Drawing.Point(0, 0);
            this.txt_rawtext.Margin = new System.Windows.Forms.Padding(4);
            this.txt_rawtext.Name = "txt_rawtext";
            this.txt_rawtext.Size = new System.Drawing.Size(465, 573);
            this.txt_rawtext.TabIndex = 24;
            this.txt_rawtext.Text = "";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 27);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.txt_rawtext);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.txt_xmlreading);
            this.splitContainerMain.Size = new System.Drawing.Size(1011, 577);
            this.splitContainerMain.SplitterDistance = 469;
            this.splitContainerMain.TabIndex = 4;
            // 
            // tsb_translate
            // 
            this.tsb_translate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_translate.Image = ((System.Drawing.Image)(resources.GetObject("tsb_translate.Image")));
            this.tsb_translate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_translate.Name = "tsb_translate";
            this.tsb_translate.Size = new System.Drawing.Size(76, 24);
            this.tsb_translate.Text = "translate";
            this.tsb_translate.Click += new System.EventHandler(this.tsb_translate_Click);
            // 
            // toolStripMain
            // 
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_translate});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1011, 27);
            this.toolStripMain.TabIndex = 5;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // ConvertTxtToReadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 604);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.toolStripMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "ConvertTxtToReadingForm";
            this.Text = "Convert Txt To Reading";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RichTextBoxEx txt_xmlreading;
        private RichTextBoxEx txt_rawtext;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.ToolStripButton tsb_translate;
        private System.Windows.Forms.ToolStrip toolStripMain;
    }
}