using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dragonfly.Questions.Core
{
    public partial class CheckBoxControl : UserControl
    {
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public char Letter
        {
            get
            {
                return Convert.ToChar(ck_letter.Text);
            }
            set
            {
                ck_letter.Text = value.ToString();
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public override string Text
        {
            get
            {
                return txt_text.Rtf;
            }
            set
            {
                try
                {
                    txt_text.Rtf = value;
                }
                catch
                {
                    txt_text.Text = value;
                }
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool Checked
        {
            get
            {
                return ck_letter.Checked;
            }
            set
            {
                ck_letter.Checked = value;
            }
        }

        public CheckBoxControl()
        {
            InitializeComponent();
            this.txt_text.WordWrap = false;
            this.txt_text.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txt_text.ContentsResized += new ContentsResizedEventHandler(RichTextBox_ContentsResized);
        }

        private void RichTextBox_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            this.Height = e.NewRectangle.Height + 6;
            this.Width = e.NewRectangle.Width + 55;
        }
    }
}
