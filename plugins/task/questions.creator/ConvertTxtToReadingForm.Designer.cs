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
            this.tabPageXmlreading = new System.Windows.Forms.TabPage();
            this.txt_xmlreading = new Dragonfly.Questions.RichTextBoxEx();
            this.tabPageGuiRawtext = new System.Windows.Forms.TabPage();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.txt_rawtext = new Dragonfly.Questions.RichTextBoxEx();
            this.tabPageXmlreading.SuspendLayout();
            this.tabPageGuiRawtext.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageXmlreading
            // 
            this.tabPageXmlreading.Controls.Add(this.txt_xmlreading);
            this.tabPageXmlreading.Location = new System.Drawing.Point(4, 4);
            this.tabPageXmlreading.Name = "tabPageXmlreading";
            this.tabPageXmlreading.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageXmlreading.Size = new System.Drawing.Size(750, 457);
            this.tabPageXmlreading.TabIndex = 1;
            this.tabPageXmlreading.Text = "题库代码";
            this.tabPageXmlreading.UseVisualStyleBackColor = true;
            // 
            // txt_xmlreading
            // 
            this.txt_xmlreading.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_xmlreading.DetectUrls = false;
            this.txt_xmlreading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_xmlreading.Font = new System.Drawing.Font("宋体", 14F);
            this.txt_xmlreading.Location = new System.Drawing.Point(3, 3);
            this.txt_xmlreading.Name = "txt_xmlreading";
            this.txt_xmlreading.ReadOnly = true;
            this.txt_xmlreading.Size = new System.Drawing.Size(744, 451);
            this.txt_xmlreading.TabIndex = 23;
            this.txt_xmlreading.Text = "";
            // 
            // tabPageGuiRawtext
            // 
            this.tabPageGuiRawtext.Controls.Add(this.txt_rawtext);
            this.tabPageGuiRawtext.Location = new System.Drawing.Point(4, 4);
            this.tabPageGuiRawtext.Name = "tabPageGuiRawtext";
            this.tabPageGuiRawtext.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGuiRawtext.Size = new System.Drawing.Size(750, 457);
            this.tabPageGuiRawtext.TabIndex = 0;
            this.tabPageGuiRawtext.Text = "题库文本";
            this.tabPageGuiRawtext.UseVisualStyleBackColor = true;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlMain.Controls.Add(this.tabPageGuiRawtext);
            this.tabControlMain.Controls.Add(this.tabPageXmlreading);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(758, 483);
            this.tabControlMain.TabIndex = 3;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // txt_rawtext
            // 
            this.txt_rawtext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_rawtext.DetectUrls = false;
            this.txt_rawtext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_rawtext.Font = new System.Drawing.Font("宋体", 14F);
            this.txt_rawtext.Location = new System.Drawing.Point(3, 3);
            this.txt_rawtext.Name = "txt_rawtext";
            this.txt_rawtext.Size = new System.Drawing.Size(744, 451);
            this.txt_rawtext.TabIndex = 24;
            this.txt_rawtext.Text = "";
            // 
            // ConvertTxtToReadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 483);
            this.Controls.Add(this.tabControlMain);
            this.MinimizeBox = false;
            this.Name = "ConvertTxtToReadingForm";
            this.Text = "Convert Txt To Reading";
            this.tabPageXmlreading.ResumeLayout(false);
            this.tabPageGuiRawtext.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageXmlreading;
        private RichTextBoxEx txt_xmlreading;
        private System.Windows.Forms.TabPage tabPageGuiRawtext;
        private RichTextBoxEx txt_rawtext;
        private System.Windows.Forms.TabControl tabControlMain;
    }
}