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


        }




    }

}
