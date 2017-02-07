using System;
using System.Windows.Forms;

namespace Dragonfly.Main
{
    public partial class OptionForm : Form
    {
        public OptionForm()
        {
            InitializeComponent();
        }

        public TabControl OptionTab
        {
            get { return this.tabControlOption; }
        }


        private void OptionForm_Load(object sender, EventArgs e)
        {
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        
   
    }
}
