using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dragonfly.Questions.Creator
{
    public partial class ConvertTxtToReadingForm : Form
    {
        public ConvertTxtToReadingForm()
        {
            InitializeComponent();
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControlMain.SelectedIndex == 1)
            {
                txt_xmlreading.Clear();
                txt_xmlreading.SelectionIndent = 20;
                txt_xmlreading.SelectionRightIndent = 12;
                txt_xmlreading.SetLineHeight(1, 0);
                //txt_xmlreading.SelectedText = (exam == null) ? "" : Helper.SaveExaminationToString(exam);
            }
        }

        private void abc()
        {
            using (StringReader sr = new StringReader(txt_rawtext.Text))
            {
                while (true)
                {
                    String line = sr.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                }
            }
        }
    }
}
