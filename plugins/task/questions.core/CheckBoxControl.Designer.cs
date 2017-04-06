namespace Dragonfly.Questions.Core
{
    partial class CheckBoxControl
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
            this.ck_letter = new System.Windows.Forms.CheckBox();
            this.txt_text = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ck_letter
            // 
            this.ck_letter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ck_letter.AutoSize = true;
            this.ck_letter.Location = new System.Drawing.Point(9, 42);
            this.ck_letter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ck_letter.Name = "ck_letter";
            this.ck_letter.Size = new System.Drawing.Size(37, 19);
            this.ck_letter.TabIndex = 0;
            this.ck_letter.Text = "Z";
            this.ck_letter.UseVisualStyleBackColor = true;
            // 
            // txt_text
            // 
            this.txt_text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_text.DetectUrls = false;
            this.txt_text.Location = new System.Drawing.Point(52, 3);
            this.txt_text.Name = "txt_text";
            this.txt_text.ReadOnly = true;
            this.txt_text.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txt_text.Size = new System.Drawing.Size(245, 94);
            this.txt_text.TabIndex = 2;
            this.txt_text.Text = "";
            // 
            // CheckBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_text);
            this.Controls.Add(this.ck_letter);
            this.MinimumSize = new System.Drawing.Size(120, 30);
            this.Name = "CheckBoxControl";
            this.Size = new System.Drawing.Size(300, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox txt_text;
        public System.Windows.Forms.CheckBox ck_letter;
    }
}
