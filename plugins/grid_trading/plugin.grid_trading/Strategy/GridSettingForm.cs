using System;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading.Strategy
{
    internal partial class GridSettingForm : Form
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

                if (rb_twohour.Checked)
                    ret = SettingHelper.LockScreenType_TwoHour;
                else
                    ret = SettingHelper.LockScreenType_OneHour;

                return ret;
            }
            set
            {
                if (value == SettingHelper.LockScreenType_TwoHour)
                    rb_twohour.Checked = true;
                else
                    rb_onehour.Checked = true;
            }
        }

        public int LockScreenApp
        {
            get { return this.checkBoxUseQuestionNotify.Checked ? 1 : 0; }
            set { this.checkBoxUseQuestionNotify.Checked = (value == 1); }
        }

        public string StartTime
        {
            get { return this.dateTimePickerStartTime.Value.ToString("HH:mm"); }
            set
            {
                DateTime settingTime;
                try
                {
                    settingTime = DateTime.ParseExact(value, "HH:mm", null);
                }
                catch
                {
                    settingTime = DateTime.ParseExact("10:00", "HH:mm", null);
                }
                dateTimePickerStartTime.Value = settingTime;
            }
        }

        public int LockScreenDuration
        {
            get { return Convert.ToInt32(this.numericUpDownDuration.Value); }
            set { numericUpDownDuration.Value = value; }
        }

        public GridSettingForm()
        {
            InitializeComponent();
        }

        private void GridTradingSettingsForm_Load(object sender, EventArgs e)
        {
            SettingHelper helper = SettingHelper.GetInstance();
            NotifyJobSetting setting = helper.PluginSetting.NotifyJobSetting;

            IsTooLateLockScreen = setting.IsTooLateLockScreen;
            TooLateTriggerTime = setting.TooLateTriggerTime;
            TooLateMinutes = setting.TooLateMinutes;
            LockScreenApp = setting.LockScreenApp;
            LockScreenType = setting.LockScreenType;
            LockScreenDuration = setting.LockScreenDuration;
            StartTime = setting.StartTime;

            this.checkBoxUseQuestionNotify.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.rb_onehour.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.rb_twohour.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.checkBoxTooLate.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.numericUpDownTooLate.ValueChanged += new System.EventHandler(this.Data_Changed);
            this.dateTimePickerTooLate.ValueChanged += new System.EventHandler(this.Data_Changed);
            this.numericUpDownDuration.ValueChanged += new System.EventHandler(this.Data_Changed);
            this.dateTimePickerStartTime.ValueChanged += new System.EventHandler(this.Data_Changed);
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
                setting.LockScreenDuration = LockScreenDuration;
                setting.StartTime = StartTime;

                helper.Save();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
