using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

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
            listViewAdjustment.Columns.Clear();
            listViewAdjustment.Columns.Add("说明", 110, HorizontalAlignment.Left);
            listViewAdjustment.Columns.Add("调节方向", 70, HorizontalAlignment.Left);
            listViewAdjustment.Columns.Add("条件来源", 80, HorizontalAlignment.Left);
            listViewAdjustment.Columns.Add("条件值", 90, HorizontalAlignment.Left);
            listViewAdjustment.Columns.Add("秒数", 40, HorizontalAlignment.Left);

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

            if (helper.PluginSetting.AdjustmentSetting.Conditions != null)
            {
                foreach (AdjustmentCondition con in helper.PluginSetting.AdjustmentSetting.Conditions)
                {
                    AddAdjustmentCondition(con);
                }
            }

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

                List<AdjustmentCondition> conditions = helper.PluginSetting.AdjustmentSetting.Conditions;
                if (conditions == null)
                {
                    conditions = new List<AdjustmentCondition>();
                }
                else
                {
                    conditions.Clear();
                }

                foreach (ListViewItem lvi in listViewAdjustment.Items)
                {
                    AdjustmentCondition con = lvi.Tag as AdjustmentCondition;
                    if (con != null)
                    {
                        conditions.Add(con);
                    }
                }

                helper.Save();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tsb_newAdjustment_Click(object sender, EventArgs e)
        {
            AdjustmentCondition con = new AdjustmentCondition()
            {
                Title = string.Empty,
                Accumulated = true,
                ConditionType = 2,
                ConditionValue = string.Empty,
                SpanSeconds = 60,
            };

            AdjustmentConditionForm form = new AdjustmentConditionForm();
            form.AdjustmentCondition = con;
            if (form.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            AddAdjustmentCondition(form.AdjustmentCondition);
            Data_Changed(sender, e);
        }

        private void tsb_editAdjustment_Click(object sender, EventArgs e)
        {
            if (listViewAdjustment.SelectedItems.Count == 0)
            {
                return;
            }

            int index = listViewAdjustment.SelectedItems[0].Index;

            AdjustmentConditionForm form = new AdjustmentConditionForm();
            form.AdjustmentCondition = listViewAdjustment.Items[index].Tag as AdjustmentCondition;
            if (form.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            EditAdjustmentCondition(index, form.AdjustmentCondition);

            Data_Changed(sender, e);
        }

        private void tsb_deleteAdjustment_Click(object sender, EventArgs e)
        {
            if (listViewAdjustment.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "请选择要删除的调节项", "错误");
                return;
            }
            if (MessageBox.Show(this, "确实要删除这些调节项吗？", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            foreach (ListViewItem lvi in listViewAdjustment.SelectedItems)
            {
                int index = lvi.Index;
                listViewAdjustment.Items.RemoveAt(index);
            }
            Data_Changed(sender, e);
        }

        private void EditAdjustmentCondition(int index, AdjustmentCondition con)
        {
            ListViewItem lvi = listViewAdjustment.Items[index];
            EditListViewItem(lvi, con);
        }

        private void AddAdjustmentCondition(AdjustmentCondition con)
        {
            ListViewItem lvi = listViewAdjustment.Items.Add(con.Title);
            EditListViewItem(lvi, con);
        }

        private void EditListViewItem(ListViewItem lvi, AdjustmentCondition con)
        {
            lvi.SubItems.Clear();
            lvi.Text = con.Title;
            lvi.SubItems.Add(new ListViewSubItem(lvi, con.Accumulated ? "持续递减" : "锁屏延时"));

            string type = string.Empty;
            //0 filename, 1 title, 2 processname
            switch (con.ConditionType)
            {
                case 0:
                    type = "文件名";
                    break;
                case 1:
                    type = "窗口标题";
                    break;
                case 2:
                    type = "进程名称";
                    break;

            }
            lvi.SubItems.Add(new ListViewSubItem(lvi, type));
            lvi.SubItems.Add(new ListViewSubItem(lvi, con.ConditionValue));
            lvi.SubItems.Add(new ListViewSubItem(lvi, con.SpanSeconds.ToString()));
            lvi.Tag = con;
        }

        private void listViewAdjustment_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool selected = listViewAdjustment.SelectedItems.Count != 0;
            tsb_editAdjustment.Enabled = selected;
            tsb_deleteAdjustment.Enabled = selected;
        }
    }
}
