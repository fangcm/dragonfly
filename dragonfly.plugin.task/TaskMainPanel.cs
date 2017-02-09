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
        LockScreen = 3
    }

    public partial class TaskMainPanel : UserControl
    {
        private TaskCenter taskCenter;

        public TaskMainPanel()
        {
            InitializeComponent();
        }

        internal TaskCenter TaskCenter
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

        private void TaskMainPanel_Load(object sender, System.EventArgs e)
        {

        }

        private void checkBoxRunApp_CheckedChanged(object sender, System.EventArgs e)
        {
            bool bChecked = checkBoxRunApp.Checked;
            this.textBoxApp.Enabled = bChecked;
            this.buttonApp.Enabled = bChecked;
            this.textBoxAppParam.Enabled = bChecked;
            this.textBoxAppStartpath.Enabled = bChecked;
        }

        public string Title
        {
            get { return textBoxTitle.Text; }
            set { textBoxTitle.Text = value; }
        }

        public string Description
        {
            get { return this.textBoxContent.Text; }
            set { this.textBoxContent.Text = value; }
        }

        public int Interval
        {
            get
            {
                return Convert.ToInt32(comboBoxInterval.Text);
            }
            set
            {
                comboBoxInterval.Text = value.ToString();
            }
        }

        public NotifyInternalType NotifyInternalType
        {
            get
            {
                NotifyInternalType ret;
                if (radioButtonLockScreen.Checked)
                    ret = NotifyInternalType.LockScreen;
                else if (radioButtonHibernate.Checked)
                    ret = NotifyInternalType.Hibernate;
                else if (radioButtonShutdown.Checked)
                    ret = NotifyInternalType.ShutDown;
                else if (radioButtonNull.Checked)
                    ret = NotifyInternalType.None;
                else
                    ret = NotifyInternalType.LockScreen;

                return ret;
            }
            set
            {
                if (value == NotifyInternalType.LockScreen)
                    radioButtonLockScreen.Checked = true;
                else if (value == NotifyInternalType.Hibernate)
                    radioButtonHibernate.Checked = true;
                else if (value == NotifyInternalType.ShutDown)
                    radioButtonShutdown.Checked = true;
                else if (value == NotifyInternalType.None)
                    radioButtonShutdown.Checked = true;
                else
                    radioButtonLockScreen.Checked = true;
            }
        }

        public int LockScreenSeconds
        {
            get { return (int)numericUpDownLockScreen.Value; }
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

    }

}
