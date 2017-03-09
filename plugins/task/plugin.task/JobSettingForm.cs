using System;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Task
{
    internal partial class JobSettingForm : Form
    {
        public bool bDataChanged = false;

        public string Description
        {
            get { return this.textBoxDescription.Text; }
            set { this.textBoxDescription.Text = value; }
        }

        public int IntervalMinutes
        {
            get { return Convert.ToInt32(this.numericUpDownInterval.Value); }
            set { numericUpDownInterval.Value = value; }
        }

        public bool IsTooLateLockScreen
        {
            get { return this.checkBoxTooLate.Checked; }
            set { checkBoxTooLate.Checked = value; }
        }

        public String TooLateTriggerTime
        {
            get { return this.dateTimePickerTooLate.Value.ToString("HH:mm"); }
            set
            {
                DateTime settingTime;
                try
                {
                    settingTime = DateTime.ParseExact(value, "HH:mm", null);
                }
                catch
                {
                    settingTime = DateTime.ParseExact("21:00", "HH:mm", null);
                }
                dateTimePickerTooLate.Value = settingTime;
            }
        }

        public int TooLateMinutes
        {
            get { return Convert.ToInt32(this.numericUpDownTooLate.Value); }
            set { numericUpDownTooLate.Value = value; }
        }

        public int NotifyInternalType
        {
            get
            {
                int ret;

                if (radioButtonHibernate.Checked)
                    ret = SettingHelper.NotifyInternalType_Hibernate;
                else if (radioButtonShutdown.Checked)
                    ret = SettingHelper.NotifyInternalType_ShutDown;
                else
                    ret = SettingHelper.NotifyInternalType_None;

                return ret;
            }
            set
            {
                if (value == SettingHelper.NotifyInternalType_Hibernate)
                    radioButtonHibernate.Checked = true;
                else if (value == SettingHelper.NotifyInternalType_ShutDown)
                    radioButtonShutdown.Checked = true;
                else
                    radioButtonNone.Checked = true;
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

        public int LockScreenApp
        {
            get { return this.checkBoxUseQuestionNotify.Checked ? 1 : 0; }
            set { this.checkBoxUseQuestionNotify.Checked = (value == 1); }
        }

        public bool IsAppAdjustment
        {
            get { return this.checkBoxAdjustment.Checked; }
            set { this.checkBoxAdjustment.Checked = value; }
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

        public JobSettingForm()
        {
            InitializeComponent();
        }

        private void TaskSettingsForm_Load(object sender, EventArgs e)
        {
            SettingHelper helper = SettingHelper.GetInstance();
            NotifyJobSetting setting = helper.PluginSetting.NotifyJobSetting;

            Description = setting.Description;
            IntervalMinutes = setting.IntervalMinutes;
            IsTooLateLockScreen = setting.IsTooLateLockScreen;
            TooLateTriggerTime = setting.TooLateTriggerTime;
            TooLateMinutes = setting.TooLateMinutes;
            IsLockScreen = setting.IsLockScreen;
            LockScreenMinutes = setting.LockScreenMinutes;
            LockScreenApp = setting.LockScreenApp;
            NotifyInternalType = setting.NotifyInternalType;
            IsAppAdjustment = setting.IsAppAdjustment;
            IsNotifyRunApp = setting.IsNotifyRunApp;
            NotifyRunApp = setting.NotifyRunApp;
            NotifyRunAppParam = setting.NotifyRunAppParam;
            NotifyRunAppStartpath = setting.NotifyRunAppStartpath;

            this.textBoxDescription.TextChanged += new System.EventHandler(this.Data_Changed);
            this.numericUpDownInterval.ValueChanged += new System.EventHandler(this.Data_Changed);
            this.checkBoxLockScreen.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.numericUpDownLockScreen.ValueChanged += new System.EventHandler(this.Data_Changed);
            this.checkBoxUseQuestionNotify.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.radioButtonHibernate.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.radioButtonShutdown.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.radioButtonNone.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.checkBoxAdjustment.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.checkBoxRunApp.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.textBoxApp.TextChanged += new System.EventHandler(this.Data_Changed);
            this.textBoxAppParam.TextChanged += new System.EventHandler(this.Data_Changed);
            this.textBoxAppStartpath.TextChanged += new System.EventHandler(this.Data_Changed);
            this.checkBoxTooLate.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.numericUpDownTooLate.ValueChanged += new System.EventHandler(this.Data_Changed);
            this.dateTimePickerTooLate.ValueChanged += new System.EventHandler(this.Data_Changed);
            bDataChanged = false;
        }

        private void Data_Changed(object sender, System.EventArgs e)
        {
            bDataChanged = true;
            System.Diagnostics.Debug.WriteLine("Data_Changed:" + sender);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (Description.Length == 0)
            {
                this.tabControl1.SelectedIndex = 0;
                this.textBoxDescription.Focus();
                MessageBox.Show(this, "请输入提醒的内容", "输入错误");
                return;
            }

            if (bDataChanged)
            {
                SettingHelper helper = SettingHelper.GetInstance();
                NotifyJobSetting setting = helper.PluginSetting.NotifyJobSetting;

                setting.Description = Description;
                setting.IntervalMinutes = IntervalMinutes;
                setting.IsTooLateLockScreen = IsTooLateLockScreen;
                setting.TooLateTriggerTime = TooLateTriggerTime;
                setting.TooLateMinutes = TooLateMinutes;
                setting.IsLockScreen = IsLockScreen;
                setting.LockScreenMinutes = LockScreenMinutes;
                setting.LockScreenApp = LockScreenApp;
                setting.NotifyInternalType = NotifyInternalType;
                setting.IsAppAdjustment = IsAppAdjustment;
                setting.IsNotifyRunApp = IsNotifyRunApp;
                setting.NotifyRunApp = NotifyRunApp;
                setting.NotifyRunAppParam = NotifyRunAppParam;
                setting.NotifyRunAppStartpath = NotifyRunAppStartpath;

                helper.Save();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
