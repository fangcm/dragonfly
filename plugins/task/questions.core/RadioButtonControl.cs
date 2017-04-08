using System;
using System.ComponentModel;
using System.Drawing;
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

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                this.rb_letter.ForeColor = value;
                this.txt_text.ForeColor = value;
            }
        }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                this.rb_letter.BackColor = value;
                this.txt_text.BackColor = value;
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
            int w = Math.Max(e.NewRectangle.Width, 50);
            int h = Math.Max(e.NewRectangle.Height, 16);
            this.Height = h + 6;
            this.Width = w + 55;
            this.txt_text.Height = h;
            this.txt_text.Width = w;
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
