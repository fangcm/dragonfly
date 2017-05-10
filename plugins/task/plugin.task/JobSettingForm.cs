using System;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Task
{
    internal partial class JobSettingForm : Form
    {
        public bool bDataChanged = false;

        public bool IsTooLateLockScreen
        {
            get { return this.checkBoxTooLate.Checked; }
            set { checkBoxTooLate.Checked = value; }
        }

        public string TooLateTriggerTime
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

        public int LockScreenType
        {
            get
            {
                int ret;

                if (rb_odd.Checked)
                    ret = SettingHelper.LockScreenType_Odd;
                else if (rb_even.Checked)
                    ret = SettingHelper.LockScreenType_Even;
                else
                    ret = SettingHelper.LockScreenType_Ten;

                return ret;
            }
            set
            {
                if (value == SettingHelper.LockScreenType_Odd)
                    rb_odd.Checked = true;
                else if (value == SettingHelper.LockScreenType_Even)
                    rb_even.Checked = true;
                else
                    rb_ten.Checked = true;
            }
        }

        public int LockScreenApp
        {
            get { return this.checkBoxUseQuestionNotify.Checked ? 1 : 0; }
            set { this.checkBoxUseQuestionNotify.Checked = (value == 1); }
        }

        public JobSettingForm()
        {
            InitializeComponent();
        }

        private void TaskSettingsForm_Load(object sender, EventArgs e)
        {
            SettingHelper helper = SettingHelper.GetInstance();
            NotifyJobSetting setting = helper.PluginSetting.NotifyJobSetting;
            
            IsTooLateLockScreen = setting.IsTooLateLockScreen;
            TooLateTriggerTime = setting.TooLateTriggerTime;
            TooLateMinutes = setting.TooLateMinutes;
            LockScreenApp = setting.LockScreenApp;
            LockScreenType = setting.LockScreenType;
            
            this.checkBoxUseQuestionNotify.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.rb_odd.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.rb_even.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.rb_ten.CheckedChanged += new System.EventHandler(this.Data_Changed);
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
            if (bDataChanged)
            {
                SettingHelper helper = SettingHelper.GetInstance();
                NotifyJobSetting setting = helper.PluginSetting.NotifyJobSetting;

                setting.IsTooLateLockScreen = IsTooLateLockScreen;
                setting.TooLateTriggerTime = TooLateTriggerTime;
                setting.TooLateMinutes = TooLateMinutes;
                setting.LockScreenApp = LockScreenApp;
                setting.LockScreenType = LockScreenType;

                helper.Save();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
