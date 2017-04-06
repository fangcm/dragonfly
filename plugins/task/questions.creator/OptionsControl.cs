using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dragonfly.Questions.Creator
{
    public partial class OptionsControl : UserControl
    {

        #region Public Properties
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public char Letter
        {
            get
            {
                return Convert.ToChar(chk_letter.Text);
            }
            set
            {
                chk_letter.Text = value.ToString();
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
                return chk_letter.Checked;
            }
            set
            {
                chk_letter.Checked = value;
            }
        }
        #endregion
        public OptionsControl()
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
