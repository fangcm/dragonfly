using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dragonfly.Questions.Core
{
    public partial class RadioButtonControl : UserControl
    {
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public char Letter
        {
            get
            {
                return Convert.ToChar(rb_letter.Text);
            }
            set
            {
                rb_letter.Text = value.ToString();
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
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool Checked
        {
            get
            {
                return rb_letter.Checked;
            }
            set
            {
                rb_letter.Checked = value;
            }
        }

        public RadioButtonControl()
        {
            InitializeComponent();
            this.rb_letter.Parent = this;
            this.txt_text.WordWrap = false;
            this.txt_text.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txt_text.ContentsResized += new ContentsResizedEventHandler(RichTextBox_ContentsResized);
        }

        private void RichTextBox_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            this.Height = e.NewRectangle.Height + 6;
            this.Width = e.NewRectangle.Width + 55;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton == null)
                return;

            RadioButtonControl target = radioButton.Parent as RadioButtonControl;
            if (target == null)
                return;

            if (target.Checked == false)
                return;

            Control parentControl = target.Parent;
            if (parentControl == null)
                return;

            foreach (Control childControl in parentControl.Controls)
            {
                if (childControl is RadioButtonControl)
                {
                    if (childControl != this)
                    {
                        (childControl as RadioButtonControl).Checked = false;
                    }
                }
            }

        }
    }
}
