﻿using System;
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
                return Convert.ToChar(chkLetter.Text);
            }
            set
            {
                chkLetter.Text = value.ToString();
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public override string Text
        {
            get
            {
                return txtText.Text;
            }
            set
            {
                txtText.Text = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public bool Checked
        {
            get
            {
                return chkLetter.Checked;
            }
            set
            {
                chkLetter.Checked = value;
            }
        }
        #endregion
        public OptionsControl()
        {
            InitializeComponent();
        }
    }
}
