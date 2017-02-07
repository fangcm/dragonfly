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

    public enum DaysOfTheWeek : int
    {
        None = 0,
        Sunday = 0x1,
        Monday = 0x2,
        Tuesday = 0x4,
        Wednesday = 0x8,
        Thursday = 0x10,
        Friday = 0x20,
        Saturday = 0x40
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

        private void radioButtonOnce_CheckedChanged(object sender, EventArgs e)
        {
            bool bChecked = radioButtonOnce.Checked;
            checkBoxInterval.Visible = !bChecked;
            comboBoxInterval.Visible = !bChecked;
            checkBoxMonday.Visible = !bChecked;
            checkBoxTuesday.Visible = !bChecked;
            checkBoxWednesday.Visible = !bChecked;
            checkBoxThursday.Visible = !bChecked;
            checkBoxFriday.Visible = !bChecked;
            checkBoxSaturday.Visible = !bChecked;
            checkBoxSunday.Visible = !bChecked;

            if (bChecked)
                dateTimePickerStartTime.Location = new System.Drawing.Point(261, 29);
            else
                dateTimePickerStartTime.Location = dateTimePickerStartDate.Location;
            dateTimePickerStartDate.Visible = bChecked;
        }

        private void radioButtonDay_CheckedChanged(object sender, EventArgs e)
        {
            bool bChecked = radioButtonDay.Checked;
            checkBoxInternal.Visible = bChecked;
            comboBoxInterval.Visible = bChecked;
            checkBoxMonday.Visible = !bChecked;
            checkBoxTuesday.Visible = !bChecked;
            checkBoxWednesday.Visible = !bChecked;
            checkBoxThursday.Visible = !bChecked;
            checkBoxFriday.Visible = !bChecked;
            checkBoxSaturday.Visible = !bChecked;
            checkBoxSunday.Visible = !bChecked;

            if (bChecked)
            {
                dateTimePickerStartTime.Location = dateTimePickerStartDate.Location;
                dateTimePickerStartDate.Visible = false;
            }
        }

        private void radioButtonWeek_CheckedChanged(object sender, EventArgs e)
        {
            bool bChecked = radioButtonWeek.Checked;
            checkBoxInternal.Visible = bChecked;
            comboBoxInterval.Visible = bChecked;
            checkBoxMonday.Visible = bChecked;
            checkBoxTuesday.Visible = bChecked;
            checkBoxWednesday.Visible = bChecked;
            checkBoxThursday.Visible = bChecked;
            checkBoxFriday.Visible = bChecked;
            checkBoxSaturday.Visible = bChecked;
            checkBoxSunday.Visible = bChecked;

            if (bChecked)
            {
                dateTimePickerStartTime.Location = dateTimePickerStartDate.Location;
                dateTimePickerStartDate.Visible = false;
            }
        }

        private void checkBoxInterval_CheckedChanged(object sender, EventArgs e)
        {
            bool bChecked = checkBoxInterval.Checked;
            comboBoxInterval.Enabled = bChecked;
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

        public int TriggerType
        {
            get
            {
                int type;
                if (radioButtonOnce.Checked)
                    type = 1;
                else if (radioButtonDay.Checked)
                    type = 2;
                else if (radioButtonWeek.Checked)
                    type = 3;
                else
                    type = 1;

                return type;
            }
            set
            {
                switch (value)
                {
                    case 1:
                        radioButtonOnce.Checked = true;
                        break;
                    case 2:
                        radioButtonDay.Checked = true;
                        break;
                    case 3:
                        radioButtonWeek.Checked = true;
                        break;
                }

                if (radioButtonOnce.Checked)
                    dateTimePickerStartTime.Location = new System.Drawing.Point(261, 29);
                else
                    dateTimePickerStartTime.Location = dateTimePickerStartDate.Location;
                dateTimePickerStartDate.Visible = radioButtonOnce.Checked;

            }
        }

        public DateTime BeginTime
        {
            get 
            {
                DateTime dtDate;
                if (radioButtonOnce.Checked)
                    dtDate = dateTimePickerStartDate.Value;
                else
                    dtDate = DateTime.Now;

                DateTime dt = new DateTime(
                    dtDate.Year,
                    dtDate.Month,
                    dtDate.Day,
                    dateTimePickerStartTime.Value.Hour,
                    dateTimePickerStartTime.Value.Minute,
                    dateTimePickerStartTime.Value.Second );

                return dt; 
            }
            set
            {
                this.dateTimePickerStartDate.Value = value;
                this.dateTimePickerStartTime.Value = value;
            }
        }

        public bool IsInterval
        {
            get
            {
                return checkBoxInterval.Checked;
            }
            set
            {
                checkBoxInterval.Checked = value;
            }
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

        public DaysOfTheWeek DaysOfTheWeek
        {
            get
            {
                DaysOfTheWeek ret = DaysOfTheWeek.None;

                if (checkBoxMonday.Checked) { ret |= DaysOfTheWeek.Monday; }
                if (checkBoxTuesday.Checked) { ret |= DaysOfTheWeek.Tuesday; }
                if (checkBoxWednesday.Checked) { ret |= DaysOfTheWeek.Wednesday; }
                if (checkBoxThursday.Checked) { ret |= DaysOfTheWeek.Thursday; }
                if (checkBoxFriday.Checked) { ret |= DaysOfTheWeek.Friday; }
                if (checkBoxSaturday.Checked) { ret |= DaysOfTheWeek.Saturday; }
                if (checkBoxSunday.Checked) { ret |= DaysOfTheWeek.Sunday; }
                return ret;
            }
            set
            {
                checkBoxMonday.Checked = ((value & DaysOfTheWeek.Monday) != 0);
                checkBoxTuesday.Checked = ((value & DaysOfTheWeek.Tuesday) != 0);
                checkBoxWednesday.Checked = ((value & DaysOfTheWeek.Wednesday) != 0);
                checkBoxThursday.Checked = ((value & DaysOfTheWeek.Thursday) != 0);
                checkBoxFriday.Checked = ((value & DaysOfTheWeek.Friday) != 0);
                checkBoxSaturday.Checked = ((value & DaysOfTheWeek.Saturday) != 0);
                checkBoxSunday.Checked = ((value & DaysOfTheWeek.Sunday) != 0);
            }
        }

        public bool IsNotifyShowMessage
        {
            get { return checkBoxShowMessage.Checked; }
            set { checkBoxShowMessage.Checked = value; }
        }

        public bool IsNotifyShowAnimation
        {
            get { return checkBoxShowAnimation.Checked; }
            set { checkBoxShowAnimation.Checked = value; }
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
