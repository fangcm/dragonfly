using System.Collections;
using System.Windows.Forms;
using Dragonfly.Common.Plugin;
using System;

namespace Dragonfly.Plugin.Task
{
    public enum NotifyInternalType : int
    {
        None = 0,
        ShutDown = 1,
        Hibernate = 2,
    }

    public partial class TaskMainPanel : UserControl
    {
        private TaskPlugin taskPlugin;
        bool bDataChanged = false;

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

        public string Description
        {
            get { return this.textBoxDescription.Text; }
            set { this.textBoxDescription.Text = value; }
        }

        public int IntervalMinutes
        {
            get
            {
                return Convert.ToInt32(numericUpDownLockScreen.Value);
            }
            set
            {
                numericUpDownLockScreen.Value = value;
            }
        }

        public NotifyInternalType NotifyInternalType
        {
            get
            {
                NotifyInternalType ret;

                if (radioButtonHibernate.Checked)
                    ret = NotifyInternalType.Hibernate;
                else if (radioButtonShutdown.Checked)
                    ret = NotifyInternalType.ShutDown;
                else
                    ret = NotifyInternalType.None;

                return ret;
            }
            set
            {
                if (value == NotifyInternalType.Hibernate)
                    radioButtonHibernate.Checked = true;
                else if (value == NotifyInternalType.ShutDown)
                    radioButtonShutdown.Checked = true;
                else
                    radioButtonNull.Checked = true;
            }
        }

        public bool IsLockScreen
        {
            get { return this.checkBoxLockScreen.Checked; }
            set { checkBoxLockScreen.Checked = value; }
        }

        public int LockScreenMinutes
        {
            get { return Convert.ToInt32(numericUpDownLockScreen.Value); }
            set { numericUpDownLockScreen.Value = value; }
        }

        public bool IsNotifyRunApp
        {
            get { return this.checkBoxRunApp.Checked; }
            set { checkBoxRunApp.Checked = value; }
        }

        public string NotifyRunApp
        {
            get { return this.textBoxApp.Text; }
            set { textBoxApp.Text = value; }
        }

        public string NotifyRunAppParam
        {
            get { return this.textBoxAppParam.Text; }
            set { textBoxAppParam.Text = value; }
        }

        public string NotifyRunAppStartpath
        {
            get { return this.textBoxAppStartpath.Text; }
            set { textBoxAppStartpath.Text = value; }
        }

        private void TaskMainPanel_Load(object sender, System.EventArgs e)
        {

            JobSetting setting = this.TaskPlugin.JobSetting;

            Description = setting.Description;
            IntervalMinutes = setting.IntervalMinutes;
            IsLockScreen = setting.IsLockScreen;
            LockScreenMinutes = setting.LockScreenMinutes;
            NotifyInternalType = (NotifyInternalType)setting.NotifyInternalType;
            IsNotifyRunApp = setting.IsNotifyRunApp;
            NotifyRunApp = setting.NotifyRunApp;
            NotifyRunAppParam = setting.NotifyRunAppParam;
            NotifyRunAppStartpath = setting.NotifyRunAppStartpath;

            this.textBoxDescription.TextChanged += new System.EventHandler(this.Data_Changed);
            this.numericUpDownInterval.ValueChanged += new System.EventHandler(this.Data_Changed);
            this.checkBoxLockScreen.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.numericUpDownLockScreen.ValueChanged += new System.EventHandler(this.Data_Changed);
            this.radioButtonHibernate.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.radioButtonShutdown.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.radioButtonNull.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.checkBoxRunApp.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.textBoxApp.TextChanged += new System.EventHandler(this.Data_Changed);
            this.textBoxAppParam.TextChanged += new System.EventHandler(this.Data_Changed);
            this.textBoxAppStartpath.TextChanged += new System.EventHandler(this.Data_Changed);

            bDataChanged = false;
        }

        private void Data_Changed(object sender, System.EventArgs e)
        {
            bDataChanged = true;

        }


    }

}
