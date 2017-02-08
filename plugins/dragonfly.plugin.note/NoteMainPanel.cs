using System.Collections;
using System.Windows.Forms;
using Dragonfly.Common.Plugin;

namespace Dragonfly.Plugin.Note
{
    public partial class NoteMainPanel : PlugInMainPanel
    {
        private ArrayList noteArray;

        public NoteMainPanel()
        {
            InitializeComponent();
        }

        public ToolStripItem ToolStripMenuMain
        {
            get
            {
                return null;
            }
        }

        public ArrayList NoteItems
        {
            get
            {
                return this.noteArray;
            }
            set
            {
                this.noteArray = value;
            }
        }

        private void NoteMainPanel_Load(object sender, System.EventArgs e)
        {
            listViewMain.Columns.Clear();
            listViewMain.Columns.Add("标题", 150, HorizontalAlignment.Left);
            listViewMain.Columns.Add("内容", 400, HorizontalAlignment.Left);

            RefreshNotes();
            RefreshToolbarState();
        }

        private void RefreshNotes()
        {
            this.listViewMain.Items.Clear();
            if (NoteItems != null)
            {
                foreach (NoteForm note in noteArray)
                {
                    ListViewItem item = listViewMain.Items.Add(note.Title);
                    item.Tag = note;

                    item.SubItems.Add(note.NotePlainText);

                }
            }
        }

        private void RefreshToolbarState()
        {
            if (this.listViewMain.SelectedItems.Count == 0)
            {
                toolStripButtonShowHide.Enabled = false;
                toolStripDropDownButtonTitle.Enabled = false;
                toolStripButtonDelete.Enabled = false;
            }
            else
            {
                toolStripButtonShowHide.Enabled = true;
                toolStripDropDownButtonTitle.Enabled = true;
                toolStripButtonDelete.Enabled = true;
            }
        }

        private void toolStripButtonRefresh_Click(object sender, System.EventArgs e)
        {
            RefreshNotes();
            RefreshToolbarState();
        }

        private void toolStripButtonShowHide_Click(object sender, System.EventArgs e)
        {
            if (this.listViewMain.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listViewMain.SelectedItems[0];
                NoteForm note = (NoteForm)item.Tag;
                if(!(note == null || note.IsDisposed))
                {
                    toolStripButtonShowHide.Checked = !toolStripButtonShowHide.Checked;
                    if (toolStripButtonShowHide.Checked)
                    {
                        toolStripButtonShowHide.Text = "显示";
                    }
                    else
                    {
                        toolStripButtonShowHide.Text = "隐藏";
                    }
                    note.Hidden = toolStripButtonShowHide.Checked;
                }
            }
        }


        private void toolStripButtonDelete_Click(object sender, System.EventArgs e)
        {
            if (this.listViewMain.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listViewMain.SelectedItems[0];
                NoteForm note = (NoteForm)item.Tag;
                if (!(note == null || note.IsDisposed))
                {
                    note.deleteNote();
                    this.listViewMain.Items.RemoveAt(item.Index);
                }
            }
        }

        private void listViewMain_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            RefreshToolbarState();

            if (this.listViewMain.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listViewMain.SelectedItems[0];
                NoteForm note = (NoteForm)item.Tag;
                if (note == null || note.IsDisposed)
                {
                    RefreshNotes();
                    RefreshToolbarState();
                }
                else
                {
                    toolStripButtonShowHide.Checked = note.Hidden;
                    if (toolStripButtonShowHide.Checked)
                    {
                        toolStripButtonShowHide.Text = "显示";
                    }
                    else
                    {
                        toolStripButtonShowHide.Text = "隐藏";
                    }
                }
            }
        }

        private void toolStripTextBoxTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.toolStripDropDownButtonTitle.HideDropDown();
            }
        }

        private void toolStripTextBoxTitle_TextChanged(object sender, System.EventArgs e)
        {
            if (this.listViewMain.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listViewMain.SelectedItems[0];
                NoteForm note = (NoteForm)item.Tag;
                if (!(note == null || note.IsDisposed))
                {
                    note.Title = toolStripTextBoxTitle.Text;
                    item.Text = toolStripTextBoxTitle.Text;
                }
            }
        }

        private void toolStripDropDownButtonTitle_DropDownOpening(object sender, System.EventArgs e)
        {
            if (this.listViewMain.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listViewMain.SelectedItems[0];
                NoteForm note = (NoteForm)item.Tag;
                if (!(note == null || note.IsDisposed))
                {
                    toolStripTextBoxTitle.Text = note.Title;
                }
            }

        }

        private void listViewMain_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.listViewMain.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listViewMain.SelectedItems[0];
                NoteForm note = (NoteForm)item.Tag;
                if (!(note == null || note.IsDisposed))
                {
                    note.Hidden = false;
                    note.Activate();
                }
            }

        }


    }
}
