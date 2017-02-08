using System;
using System.Drawing;
using System.Windows.Forms;
using Dragonfly.Common.Plugin;

namespace Dragonfly.Plugin.Note
{
    public partial class NoteOptionPanel : PlugInOptionPanel
    {
        public NoteOptionPanel()
        {
            InitializeComponent();
        }

        public Font NoteFont
        {
            get { return this.labelDemoFont.Font; }
            set
            {
                this.labelDemoFont.Font = value;
                System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));
                this.labelDemoFont.Text = converter.ConvertToString(this.labelDemoFont.Font);
            }
        }

        public Color NoteForeColor
        {
            get { return this.colorComboBoxFont.SelectedColor; }
            set { this.colorComboBoxFont.SelectedColor = value; }
        }

        public Color NoteBackColor
        {
            get { return this.colorComboBoxBackground.SelectedColor; }
            set { this.colorComboBoxBackground.SelectedColor = value; }
        }

        public int NoteFade
        {
            get { return this.trackBarTransparent.Value; }
            set { this.trackBarTransparent.Value = value; }
        }

        public bool NoteAlwaysStayOnTop
        {
            get { return this.checkBoxAlwaysTop.Checked; }
            set { this.checkBoxAlwaysTop.Checked = value; }
        }

        public bool NoteUseRandomColor
        {
            get { return this.checkBoxUseRandomColor.Checked; }
            set { this.checkBoxUseRandomColor.Checked = value; }
        }

        public int NoteMinHeight
        {
            get { return (int)this.numericUpDownMinHeight.Value; }
            set { this.numericUpDownMinHeight.Value = value; }
        }

        public int NoteMinWidth
        {
            get { return (int)this.numericUpDownMinWidth.Value; }
            set { this.numericUpDownMinWidth.Value = value; }
        }

        public int NoteMaxHeight
        {
            get { return (int)this.numericUpDownMaxHeight.Value; }
            set { this.numericUpDownMaxHeight.Value = value; }
        }

        public int NoteMaxWidth
        {
            get { return (int)this.numericUpDownMaxWidth.Value; }
            set { this.numericUpDownMaxWidth.Value = value; }
        }

        public Keys HotkeyShowAllNotes
        {
            get { return this.hotkeyControlShowAllNote.Hotkey; }
            set { this.hotkeyControlShowAllNote.Hotkey = value; }
        }

        public Keys HotkeyModifiersShowAllNotes
        {
            get { return this.hotkeyControlShowAllNote.HotkeyModifiers; }
            set { this.hotkeyControlShowAllNote.HotkeyModifiers = value; }
        }

        public Keys HotkeyHideAllNotes
        {
            get { return this.hotkeyControlHideAllNote.Hotkey; }
            set { this.hotkeyControlHideAllNote.Hotkey = value; }
        }

        public Keys HotkeyModifiersHideAllNotes
        {
            get { return this.hotkeyControlHideAllNote.HotkeyModifiers; }
            set { this.hotkeyControlHideAllNote.HotkeyModifiers = value; }
        }

        private void OptionPanel_Load(object sender, EventArgs e)
        {
            this.labelTransparentTip.Text = this.trackBarTransparent.Value.ToString() + "%";
            this.labelDemoFont.ForeColor = colorComboBoxFont.SelectedColor;
            this.labelDemoFont.BackColor = colorComboBoxBackground.SelectedColor;
            if (NoteUseRandomColor)
            {
                this.labelDemoFont.BackColor = Color.White;
            }
            else
            {
                this.labelDemoFont.BackColor = this.colorComboBoxBackground.SelectedColor;
            }
        }

        private void trackBarTransparent_ValueChanged(object sender, EventArgs e)
        {
            this.labelTransparentTip.Text = this.trackBarTransparent.Value.ToString() + "%";
        }

        private void buttonSelectFont_Click(object sender, EventArgs e)
        {
            using (FontDialog dlg = new FontDialog())
            {
                dlg.Font = this.labelDemoFont.Font;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.labelDemoFont.Font = dlg.Font;
                    System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));
                    this.labelDemoFont.Text = converter.ConvertToString(this.labelDemoFont.Font);
                }
            }
        }

        private void colorComboBoxFont_ColorChanged(object sender, Dragonfly.Common.Controls.ColorChangeArgs e)
        {
            this.labelDemoFont.ForeColor = e.color;
        }

        private void colorComboBoxBackground_ColorChanged(object sender, Dragonfly.Common.Controls.ColorChangeArgs e)
        {
            this.labelDemoFont.BackColor = e.color;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
        }

        private void checkBoxUseRandomColor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUseRandomColor.Checked)
            {
                this.colorComboBoxBackground.Enabled = false;
                this.labelDemoFont.BackColor = Color.White;
            }
            else
            {
                this.colorComboBoxBackground.Enabled = true;
                this.labelDemoFont.BackColor = this.colorComboBoxBackground.SelectedColor;
            }
        }
    }
}
