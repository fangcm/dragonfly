using System.Collections;
using System.Windows.Forms;
using Dragonfly.Common.Plugin;
using System;

namespace Dragonfly.Plugin.Task
{


    public partial class TaskMainPanel : UserControl
    {
        private TaskPlugin taskPlugin;

        public TaskMainPanel()
        {
            InitializeComponent();
        }

        internal TaskPlugin TaskPlugin
        {
            get
            {
                return this.taskPlugin;
            }
            set
            {
                this.taskPlugin = value;
            }
        }

 
        private void TaskMainPanel_Load(object sender, System.EventArgs e)
        {
            listViewMain.Columns.Clear();
            listViewMain.Columns.Add("标题", 150, HorizontalAlignment.Left);
            listViewMain.Columns.Add("内容", 400, HorizontalAlignment.Left);

            RefreshTasks();

        }



        private void toolStripButtonRefresh_Click(object sender, System.EventArgs e)
        {
            RefreshTasks();

        }

        private void RefreshTasks()
        {
            this.listViewMain.Items.Clear();

        }

        private void toolStripButtonSetting_Click(object sender, EventArgs e)
        {
            JobSettingForm settingForm = new JobSettingForm();
            settingForm.ShowDialog();
        }
    }

}
