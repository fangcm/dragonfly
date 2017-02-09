using System;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Task
{
    public enum EnumInterval : int
    {
        Interval5Mins = 0,
        Interval30Mins = 1,
        Interval1Hour = 2,
        Interval2Hour = 3
    }

    public enum NotifyInternalType : int
    {
        ShutDown = 1,
        Hibernate = 2,
        LockScreen = 4
    }


    public partial class TaskSettingsForm : Form
    {
        public TaskSettingsForm()
        {
            InitializeComponent();
            comboBoxInterval.SelectedIndex = 0;
        }

 

        private void checkBoxInternal_CheckedChanged(object sender, EventArgs e)
        {
            bool bChecked = checkBoxInternal.Checked;
            this.radioButtonLockScreen.Enabled = bChecked;
            this.numericUpDownLockScreen.Enabled = bChecked;
            this.radioButtonHibernate.Enabled = bChecked;
            this.radioButtonShutdown.Enabled = bChecked;
        }

        private void checkBoxRunApp_CheckedChanged(object sender, EventArgs e)
        {
            bool bChecked = checkBoxRunApp.Checked;
            this.textBoxApp.Enabled = bChecked;
            this.buttonApp.Enabled = bChecked;
            this.textBoxAppParam.Enabled = bChecked;
            this.textBoxAppStartpath.Enabled = bChecked;
        }

        private void TaskSettingsForm_Load(object sender, EventArgs e)
        {
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

 

        public EnumInterval Interval
        {
            get
            {
                return (EnumInterval)comboBoxInterval.SelectedIndex;
            }
            set
            {
                comboBoxInterval.SelectedIndex = (int)value;
            }
        }

 

        public bool IsNotifyInternal
        {
            get { return this.checkBoxInternal.Checked; }
            set { checkBoxInternal.Checked = value; }
        }

        public NotifyInternalType NotifyInternalType
        {
            get
            {
                NotifyInternalType ret;
                if (radioButtonLockScreen.Checked)
                    ret = NotifyInternalType.LockScreen;
                else if (this.radioButtonHibernate.Checked)
                    ret = NotifyInternalType.Hibernate;
                else if (this.radioButtonShutdown.Checked)
                    ret = NotifyInternalType.ShutDown;
                else
                    ret = NotifyInternalType.LockScreen;

                return ret;
            }
            set
            {
                if ((value & NotifyInternalType.LockScreen) != 0 )
                    radioButtonLockScreen.Checked = true;
                else if ((value & NotifyInternalType.Hibernate) != 0 )
                    radioButtonHibernate.Checked = true;
                else if ((value & NotifyInternalType.ShutDown) != 0)
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

        public string TriggerCron
        {
            get
            {

                int s = dateTimePickerStartTime.Value.Second;
                int m = dateTimePickerStartTime.Value.Minute;
                int h = dateTimePickerStartTime.Value.Hour;

                string day = "*";
                string week = "?";
                if (radioButtonWeek.Checked)
                {
                    string temp = "";
                    if (checkBoxMonday.Checked) { temp += "MON,"; }
                    if (checkBoxTuesday.Checked) { temp += "TUE,"; }
                    if (checkBoxWednesday.Checked) { temp += "WED,"; }
                    if (checkBoxThursday.Checked) { temp += "THU,"; }
                    if (checkBoxFriday.Checked) { temp += "FRI,"; }
                    if (checkBoxSaturday.Checked) { temp += "SAT,"; }
                    if (checkBoxSunday.Checked) { temp += "SUN,"; }

                    if (temp.EndsWith(","))
                    {
                        week = temp.Substring(0, temp.Length - 1);
                        day = "?";
                    }
                    else
                    {
                        week = "?";
                        day = "*";
                    }

                }

                string cron;

                if (radioButtonDay.Checked || radioButtonWeek.Checked)
                {

                    if (checkBoxInterval.Checked)
                    {
                        EnumInterval index = (EnumInterval)comboBoxInterval.SelectedIndex;
                        switch (index)
                        {
                            case EnumInterval.Interval5Mins:
                                cron = string.Format("{0} {1}/5 * {2} * {3}", s, m % 5, day, week);
                                break;
                            case EnumInterval.Interval30Mins:
                                cron = string.Format("{0} {1}/30 * {2} * {3}", s, m % 30, day, week);
                                break;
                            case EnumInterval.Interval1Hour:
                                cron = string.Format("{0} {1} {2}/1 {3} * {4}", s, m, h, day, week);
                                break;
                            case EnumInterval.Interval2Hour:
                                cron = string.Format("{0} {1} {2}/2 {3} * {4}", s, m, h, day, week);
                                break;
                            default:
                                cron = string.Format("{0} {1} {2} {3} * {4}", s, m, h, day, week);
                                break;

                        }
                    }
                    else
                    {
                        cron = string.Format("{0} {1} {2} {3} * {4}", s, m, h, day, week);
                    }


                }
                else
                {
                    cron = string.Format("{0} {1} {2} {3} {4} ? {5}", s, m, h, dateTimePickerStartTime.Value.Day, dateTimePickerStartTime.Value.Month, dateTimePickerStartTime.Value.Year);
                }

                return cron;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (Title.Length == 0)
            {
                this.tabControl1.SelectedIndex = 0;
                this.textBoxTitle.Focus();
                MessageBox.Show(this,"请输入提醒的标题", "输入错误");
                return;
            }

            if (Description.Length == 0)
            {
                this.tabControl1.SelectedIndex = 0;
                this.textBoxContent.Focus();
                MessageBox.Show(this,"请输入提醒的内容", "输入错误");
                return;
            }
            if (!(checkBoxRunApp.Checked || checkBoxShowMessage.Checked || checkBoxInternal.Checked || checkBoxShowAnimation.Checked))
            {
                this.tabControl1.SelectedIndex = 2;
                this.checkBoxShowMessage.Focus();
                MessageBox.Show(this,"请至少选择一项提醒的操作", "输入错误");
                return;
            }

            if (radioButtonWeek.Checked && DaysOfTheWeek == DaysOfTheWeek.None)
            {
                this.tabControl1.SelectedIndex = 1;
                this.radioButtonWeek.Focus();
                MessageBox.Show(this, "请至少选择星期一到星期日中的一天", "输入错误");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }




    }
}
