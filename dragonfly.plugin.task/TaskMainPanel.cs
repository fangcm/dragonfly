using System.Collections;
using System.Windows.Forms;
using Dragonfly.Common.Plugin;

namespace Dragonfly.Plugin.Task
{
    public partial class TaskMainPanel : UserControl
    {
        private TaskCenter taskCenter;
        private TaskManager taskManager;

        public TaskMainPanel()
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

        public TaskCenter TaskCenter
        {
            get
            {
                return this.taskCenter;
            }
            set
            {
                this.taskCenter = value;
            }
        }

        public TaskManager TaskManager
        {
            get
            {
                return this.taskManager;
            }
            set
            {
                this.taskManager = value;
            }
        }

        private void TaskMainPanel_Load(object sender, System.EventArgs e)
        {
            listViewMain.Columns.Clear();
            listViewMain.Columns.Add("标题", 150, HorizontalAlignment.Left);
            listViewMain.Columns.Add("内容", 400, HorizontalAlignment.Left);

            RefreshTasks();
            RefreshToolbarState();
        }

        private void RefreshTasks()
        {
            this.listViewMain.Items.Clear();
            foreach (Task t in taskCenter.Tasks)
            {
                Hashtable param = t.Params;
                string title = (string)param["Title"];
                string description = (string)param["Description"];

                ListViewItem item = listViewMain.Items.Add(title);
                item.Tag = t;
                item.SubItems.Add(description);

            }
        }

        private void RefreshToolbarState()
        {
            if (this.listViewMain.SelectedItems.Count == 0)
            {
                toolStripButtonModify.Enabled = false;
                toolStripButtonDelete.Enabled = false;
            }
            else
            {
                toolStripButtonModify.Enabled = true;
                toolStripButtonDelete.Enabled = true;
            }
        }

        private void toolStripButtonRefresh_Click(object sender, System.EventArgs e)
        {
            RefreshTasks();
            RefreshToolbarState();
        }


        private void toolStripButtonDelete_Click(object sender, System.EventArgs e)
        {
            if (this.listViewMain.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listViewMain.SelectedItems[0];
                Task t = (Task)item.Tag;
                if (t != null)
                {
                    this.taskCenter.DelTask(t);
                    this.listViewMain.Items.RemoveAt(item.Index);
                    taskManager.SaveTaskSettings();
                }
            }
        }

        private void listViewMain_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            RefreshToolbarState();

            if (this.listViewMain.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listViewMain.SelectedItems[0];
                Task task = (Task)item.Tag;
                if (task == null)
                {
                    RefreshTasks();
                    RefreshToolbarState();
                }
            }
        }



        private void toolStripButtonAdd_Click(object sender, System.EventArgs e)
        {
            Task t = taskCenter.AddTask();
            if (t != null)
            {
                Hashtable param = t.Params;
                string title = (string)param["Title"];
                string description = (string)param["Description"];

                ListViewItem item = listViewMain.Items.Add(title);
                item.Tag = t;
                item.SubItems.Add(description);

                taskManager.SaveTaskSettings();
            }
        }

        private void toolStripButtonModify_Click(object sender, System.EventArgs e)
        {
            if (this.listViewMain.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listViewMain.SelectedItems[0];
                Task t = (Task)item.Tag;
                if (t == null)
                {
                    RefreshTasks();
                    RefreshToolbarState();
                    return;
                }

                Task newTask = taskCenter.EditTask(t);
                if (newTask != null)
                {
                    Hashtable param = newTask.Params;
                    string title = (string)param["Title"];
                    string description = (string)param["Description"];

                    item.Text = title;
                    item.SubItems[1].Text = description;
                    item.Tag = newTask;

                    taskManager.SaveTaskSettings();
                }

            }
        }

        private void listViewMain_DoubleClick(object sender, System.EventArgs e)
        {
            toolStripButtonModify_Click(null,null);
        }

      
    }

}
