namespace Dragonfly.Questions.Core
{
    partial class RadioButtonControl
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
            this.rb_letter = new System.Windows.Forms.RadioButton();
            this.txt_text = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rb_letter
            // 
            this.rb_letter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rb_letter.AutoSize = true;
            this.rb_letter.Location = new System.Drawing.Point(9, 42);
            this.rb_letter.Name = "rb_letter";
            this.rb_letter.Size = new System.Drawing.Size(36, 19);
            this.rb_letter.TabIndex = 0;
            this.rb_letter.Text = "Z";
            this.rb_letter.UseVisualStyleBackColor = true;
            this.rb_letter.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // txt_text
            // 
            this.txt_text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_text.DetectUrls = false;
            this.txt_text.Location = new System.Drawing.Point(51, 3);
            this.txt_text.Name = "txt_text";
            this.txt_text.ReadOnly = true;
            this.txt_text.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txt_text.Size = new System.Drawing.Size(245, 94);
            this.txt_text.TabIndex = 1;
            this.txt_text.Text = "";
            // 
            // RadioButtonControl
            // 
            this.Controls.Add(this.txt_text);
            this.Controls.Add(this.rb_letter);
            this.MinimumSize = new System.Drawing.Size(120, 30);
            this.Name = "RadioButtonControl";
            this.Size = new System.Drawing.Size(300, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox txt_text;
        public System.Windows.Forms.RadioButton rb_letter;
    }
}
