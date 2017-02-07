namespace Dragonfly.Plugin.Task
{
    partial class TaskSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageContent = new System.Windows.Forms.TabPage();
            this.labelContent = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.SchetabTriggers = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxInterval = new System.Windows.Forms.ComboBox();
            this.checkBoxSunday = new System.Windows.Forms.CheckBox();
            this.checkBoxSaturday = new System.Windows.Forms.CheckBox();
            this.checkBoxFriday = new System.Windows.Forms.CheckBox();
            this.checkBoxThursday = new System.Windows.Forms.CheckBox();
            this.checkBoxInterval = new System.Windows.Forms.CheckBox();
            this.checkBoxWednesday = new System.Windows.Forms.CheckBox();
            this.checkBoxTuesday = new System.Windows.Forms.CheckBox();
            this.checkBoxMonday = new System.Windows.Forms.CheckBox();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.labelStart = new System.Windows.Forms.Label();
            this.radioButtonWeek = new System.Windows.Forms.RadioButton();
            this.radioButtonDay = new System.Windows.Forms.RadioButton();
            this.radioButtonOnce = new System.Windows.Forms.RadioButton();
            this.tabPageExecute = new System.Windows.Forms.TabPage();
            this.checkBoxShowAnimation = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.numericUpDownLockScreen = new System.Windows.Forms.NumericUpDown();
            this.radioButtonLockScreen = new System.Windows.Forms.RadioButton();
            this.labelLockScreen = new System.Windows.Forms.Label();
            this.radioButtonHibernate = new System.Windows.Forms.RadioButton();
            this.radioButtonShutdown = new System.Windows.Forms.RadioButton();
            this.checkBoxInternal = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxApp = new System.Windows.Forms.TextBox();
            this.labelApp = new System.Windows.Forms.Label();
            this.buttonApp = new System.Windows.Forms.Button();
            this.textBoxAppStartpath = new System.Windows.Forms.TextBox();
            this.labelAppParam = new System.Windows.Forms.Label();
            this.labelAppStartpath = new System.Windows.Forms.Label();
            this.textBoxAppParam = new System.Windows.Forms.TextBox();
            this.checkBoxRunApp = new System.Windows.Forms.CheckBox();
            this.checkBoxShowMessage = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageContent.SuspendLayout();
            this.SchetabTriggers.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPageExecute.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLockScreen)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageContent);
            this.tabControl1.Controls.Add(this.SchetabTriggers);
            this.tabControl1.Controls.Add(this.tabPageExecute);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(458, 319);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageContent
            // 
            this.tabPageContent.Controls.Add(this.labelContent);
            this.tabPageContent.Controls.Add(this.labelTitle);
            this.tabPageContent.Controls.Add(this.textBoxContent);
            this.tabPageContent.Controls.Add(this.textBoxTitle);
            this.tabPageContent.Location = new System.Drawing.Point(4, 22);
            this.tabPageContent.Name = "tabPageContent";
            this.tabPageContent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageContent.Size = new System.Drawing.Size(450, 293);
            this.tabPageContent.TabIndex = 0;
            this.tabPageContent.Text = "内容";
            this.tabPageContent.UseVisualStyleBackColor = true;
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(22, 52);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(41, 12);
            this.labelContent.TabIndex = 2;
            this.labelContent.Text = "内容：";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(22, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(41, 12);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "标题：";
            // 
            // textBoxContent
            // 
            this.textBoxContent.Location = new System.Drawing.Point(24, 67);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(410, 90);
            this.textBoxContent.TabIndex = 3;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(70, 17);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(364, 21);
            this.textBoxTitle.TabIndex = 1;
            // 
            // SchetabTriggers
            // 
            this.SchetabTriggers.Controls.Add(this.groupBox1);
            this.SchetabTriggers.Location = new System.Drawing.Point(4, 22);
            this.SchetabTriggers.Name = "SchetabTriggers";
            this.SchetabTriggers.Padding = new System.Windows.Forms.Padding(3);
            this.SchetabTriggers.Size = new System.Drawing.Size(450, 293);
            this.SchetabTriggers.TabIndex = 1;
            this.SchetabTriggers.Text = "触发时间";
            this.SchetabTriggers.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.dateTimePickerStartTime);
            this.groupBox1.Controls.Add(this.dateTimePickerStartDate);
            this.groupBox1.Controls.Add(this.labelStart);
            this.groupBox1.Controls.Add(this.radioButtonWeek);
            this.groupBox1.Controls.Add(this.radioButtonDay);
            this.groupBox1.Controls.Add(this.radioButtonOnce);
            this.groupBox1.Location = new System.Drawing.Point(22, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxInterval);
            this.groupBox3.Controls.Add(this.checkBoxSunday);
            this.groupBox3.Controls.Add(this.checkBoxSaturday);
            this.groupBox3.Controls.Add(this.checkBoxFriday);
            this.groupBox3.Controls.Add(this.checkBoxThursday);
            this.groupBox3.Controls.Add(this.checkBoxInterval);
            this.groupBox3.Controls.Add(this.checkBoxWednesday);
            this.groupBox3.Controls.Add(this.checkBoxTuesday);
            this.groupBox3.Controls.Add(this.checkBoxMonday);
            this.groupBox3.Location = new System.Drawing.Point(71, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 120);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // comboBoxInterval
            // 
            this.comboBoxInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInterval.Enabled = false;
            this.comboBoxInterval.FormattingEnabled = true;
            this.comboBoxInterval.Items.AddRange(new object[] {
            "5分钟",
            "30分钟",
            "1小时",
            "2小时"});
            this.comboBoxInterval.Location = new System.Drawing.Point(120, 16);
            this.comboBoxInterval.Name = "comboBoxInterval";
            this.comboBoxInterval.Size = new System.Drawing.Size(121, 20);
            this.comboBoxInterval.TabIndex = 6;
            this.comboBoxInterval.Visible = false;
            // 
            // checkBoxSunday
            // 
            this.checkBoxSunday.AutoSize = true;
            this.checkBoxSunday.Location = new System.Drawing.Point(166, 82);
            this.checkBoxSunday.Name = "checkBoxSunday";
            this.checkBoxSunday.Size = new System.Drawing.Size(60, 16);
            this.checkBoxSunday.TabIndex = 9;
            this.checkBoxSunday.Text = "星期日";
            this.checkBoxSunday.UseVisualStyleBackColor = true;
            this.checkBoxSunday.Visible = false;
            // 
            // checkBoxSaturday
            // 
            this.checkBoxSaturday.AutoSize = true;
            this.checkBoxSaturday.Location = new System.Drawing.Point(86, 82);
            this.checkBoxSaturday.Name = "checkBoxSaturday";
            this.checkBoxSaturday.Size = new System.Drawing.Size(60, 16);
            this.checkBoxSaturday.TabIndex = 8;
            this.checkBoxSaturday.Text = "星期六";
            this.checkBoxSaturday.UseVisualStyleBackColor = true;
            this.checkBoxSaturday.Visible = false;
            // 
            // checkBoxFriday
            // 
            this.checkBoxFriday.AutoSize = true;
            this.checkBoxFriday.Location = new System.Drawing.Point(6, 82);
            this.checkBoxFriday.Name = "checkBoxFriday";
            this.checkBoxFriday.Size = new System.Drawing.Size(60, 16);
            this.checkBoxFriday.TabIndex = 7;
            this.checkBoxFriday.Text = "星期五";
            this.checkBoxFriday.UseVisualStyleBackColor = true;
            this.checkBoxFriday.Visible = false;
            // 
            // checkBoxThursday
            // 
            this.checkBoxThursday.AutoSize = true;
            this.checkBoxThursday.Location = new System.Drawing.Point(246, 61);
            this.checkBoxThursday.Name = "checkBoxThursday";
            this.checkBoxThursday.Size = new System.Drawing.Size(60, 16);
            this.checkBoxThursday.TabIndex = 6;
            this.checkBoxThursday.Text = "星期四";
            this.checkBoxThursday.UseVisualStyleBackColor = true;
            this.checkBoxThursday.Visible = false;
            // 
            // checkBoxInterval
            // 
            this.checkBoxInterval.AutoSize = true;
            this.checkBoxInterval.Location = new System.Drawing.Point(6, 20);
            this.checkBoxInterval.Name = "checkBoxInterval";
            this.checkBoxInterval.Size = new System.Drawing.Size(108, 16);
            this.checkBoxInterval.TabIndex = 0;
            this.checkBoxInterval.Text = "任务重复间隔：";
            this.checkBoxInterval.UseVisualStyleBackColor = true;
            this.checkBoxInterval.Visible = false;
            this.checkBoxInterval.CheckedChanged += new System.EventHandler(this.checkBoxInterval_CheckedChanged);
            // 
            // checkBoxWednesday
            // 
            this.checkBoxWednesday.AutoSize = true;
            this.checkBoxWednesday.Location = new System.Drawing.Point(166, 61);
            this.checkBoxWednesday.Name = "checkBoxWednesday";
            this.checkBoxWednesday.Size = new System.Drawing.Size(60, 16);
            this.checkBoxWednesday.TabIndex = 5;
            this.checkBoxWednesday.Text = "星期三";
            this.checkBoxWednesday.UseVisualStyleBackColor = true;
            this.checkBoxWednesday.Visible = false;
            // 
            // checkBoxTuesday
            // 
            this.checkBoxTuesday.AutoSize = true;
            this.checkBoxTuesday.Location = new System.Drawing.Point(86, 61);
            this.checkBoxTuesday.Name = "checkBoxTuesday";
            this.checkBoxTuesday.Size = new System.Drawing.Size(60, 16);
            this.checkBoxTuesday.TabIndex = 4;
            this.checkBoxTuesday.Text = "星期二";
            this.checkBoxTuesday.UseVisualStyleBackColor = true;
            this.checkBoxTuesday.Visible = false;
            // 
            // checkBoxMonday
            // 
            this.checkBoxMonday.AutoSize = true;
            this.checkBoxMonday.Location = new System.Drawing.Point(6, 61);
            this.checkBoxMonday.Name = "checkBoxMonday";
            this.checkBoxMonday.Size = new System.Drawing.Size(60, 16);
            this.checkBoxMonday.TabIndex = 3;
            this.checkBoxMonday.Text = "星期一";
            this.checkBoxMonday.UseVisualStyleBackColor = true;
            this.checkBoxMonday.Visible = false;
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(261, 29);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.ShowUpDown = true;
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(87, 21);
            this.dateTimePickerStartTime.TabIndex = 5;
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(128, 29);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(126, 21);
            this.dateTimePickerStartDate.TabIndex = 4;
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(69, 33);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(53, 12);
            this.labelStart.TabIndex = 3;
            this.labelStart.Text = "开始时间";
            // 
            // radioButtonWeek
            // 
            this.radioButtonWeek.AutoSize = true;
            this.radioButtonWeek.Location = new System.Drawing.Point(7, 73);
            this.radioButtonWeek.Name = "radioButtonWeek";
            this.radioButtonWeek.Size = new System.Drawing.Size(47, 16);
            this.radioButtonWeek.TabIndex = 2;
            this.radioButtonWeek.Text = "每周";
            this.radioButtonWeek.UseVisualStyleBackColor = true;
            this.radioButtonWeek.CheckedChanged += new System.EventHandler(this.radioButtonWeek_CheckedChanged);
            // 
            // radioButtonDay
            // 
            this.radioButtonDay.AutoSize = true;
            this.radioButtonDay.Location = new System.Drawing.Point(7, 51);
            this.radioButtonDay.Name = "radioButtonDay";
            this.radioButtonDay.Size = new System.Drawing.Size(47, 16);
            this.radioButtonDay.TabIndex = 1;
            this.radioButtonDay.Text = "每天";
            this.radioButtonDay.UseVisualStyleBackColor = true;
            this.radioButtonDay.CheckedChanged += new System.EventHandler(this.radioButtonDay_CheckedChanged);
            // 
            // radioButtonOnce
            // 
            this.radioButtonOnce.AutoSize = true;
            this.radioButtonOnce.Checked = true;
            this.radioButtonOnce.Location = new System.Drawing.Point(7, 29);
            this.radioButtonOnce.Name = "radioButtonOnce";
            this.radioButtonOnce.Size = new System.Drawing.Size(47, 16);
            this.radioButtonOnce.TabIndex = 0;
            this.radioButtonOnce.TabStop = true;
            this.radioButtonOnce.Text = "一次";
            this.radioButtonOnce.UseVisualStyleBackColor = true;
            this.radioButtonOnce.CheckedChanged += new System.EventHandler(this.radioButtonOnce_CheckedChanged);
            // 
            // tabPageExecute
            // 
            this.tabPageExecute.Controls.Add(this.checkBoxShowAnimation);
            this.tabPageExecute.Controls.Add(this.groupBox5);
            this.tabPageExecute.Controls.Add(this.checkBoxInternal);
            this.tabPageExecute.Controls.Add(this.groupBox2);
            this.tabPageExecute.Controls.Add(this.checkBoxRunApp);
            this.tabPageExecute.Controls.Add(this.checkBoxShowMessage);
            this.tabPageExecute.Location = new System.Drawing.Point(4, 22);
            this.tabPageExecute.Name = "tabPageExecute";
            this.tabPageExecute.Size = new System.Drawing.Size(450, 293);
            this.tabPageExecute.TabIndex = 2;
            this.tabPageExecute.Text = "操作";
            this.tabPageExecute.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowAnimation
            // 
            this.checkBoxShowAnimation.AutoSize = true;
            this.checkBoxShowAnimation.Location = new System.Drawing.Point(22, 41);
            this.checkBoxShowAnimation.Name = "checkBoxShowAnimation";
            this.checkBoxShowAnimation.Size = new System.Drawing.Size(72, 16);
            this.checkBoxShowAnimation.TabIndex = 5;
            this.checkBoxShowAnimation.Text = "动画效果";
            this.checkBoxShowAnimation.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numericUpDownLockScreen);
            this.groupBox5.Controls.Add(this.radioButtonLockScreen);
            this.groupBox5.Controls.Add(this.labelLockScreen);
            this.groupBox5.Controls.Add(this.radioButtonHibernate);
            this.groupBox5.Controls.Add(this.radioButtonShutdown);
            this.groupBox5.Location = new System.Drawing.Point(22, 85);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(410, 47);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // numericUpDownLockScreen
            // 
            this.numericUpDownLockScreen.Enabled = false;
            this.numericUpDownLockScreen.Location = new System.Drawing.Point(89, 19);
            this.numericUpDownLockScreen.Maximum = new decimal(new int[] {
            36000,
            0,
            0,
            0});
            this.numericUpDownLockScreen.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLockScreen.Name = "numericUpDownLockScreen";
            this.numericUpDownLockScreen.Size = new System.Drawing.Size(54, 21);
            this.numericUpDownLockScreen.TabIndex = 5;
            this.numericUpDownLockScreen.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // radioButtonLockScreen
            // 
            this.radioButtonLockScreen.AutoSize = true;
            this.radioButtonLockScreen.Enabled = false;
            this.radioButtonLockScreen.Location = new System.Drawing.Point(12, 19);
            this.radioButtonLockScreen.Name = "radioButtonLockScreen";
            this.radioButtonLockScreen.Size = new System.Drawing.Size(71, 16);
            this.radioButtonLockScreen.TabIndex = 0;
            this.radioButtonLockScreen.TabStop = true;
            this.radioButtonLockScreen.Text = "锁定屏幕";
            this.radioButtonLockScreen.UseVisualStyleBackColor = true;
            // 
            // labelLockScreen
            // 
            this.labelLockScreen.AutoSize = true;
            this.labelLockScreen.Location = new System.Drawing.Point(149, 21);
            this.labelLockScreen.Name = "labelLockScreen";
            this.labelLockScreen.Size = new System.Drawing.Size(17, 12);
            this.labelLockScreen.TabIndex = 2;
            this.labelLockScreen.Text = "秒";
            // 
            // radioButtonHibernate
            // 
            this.radioButtonHibernate.AutoSize = true;
            this.radioButtonHibernate.Enabled = false;
            this.radioButtonHibernate.Location = new System.Drawing.Point(185, 19);
            this.radioButtonHibernate.Name = "radioButtonHibernate";
            this.radioButtonHibernate.Size = new System.Drawing.Size(71, 16);
            this.radioButtonHibernate.TabIndex = 3;
            this.radioButtonHibernate.TabStop = true;
            this.radioButtonHibernate.Text = "自动休眠";
            this.radioButtonHibernate.UseVisualStyleBackColor = true;
            // 
            // radioButtonShutdown
            // 
            this.radioButtonShutdown.AutoSize = true;
            this.radioButtonShutdown.Enabled = false;
            this.radioButtonShutdown.Location = new System.Drawing.Point(305, 19);
            this.radioButtonShutdown.Name = "radioButtonShutdown";
            this.radioButtonShutdown.Size = new System.Drawing.Size(71, 16);
            this.radioButtonShutdown.TabIndex = 4;
            this.radioButtonShutdown.TabStop = true;
            this.radioButtonShutdown.Text = "自动关机";
            this.radioButtonShutdown.UseVisualStyleBackColor = true;
            // 
            // checkBoxInternal
            // 
            this.checkBoxInternal.AutoSize = true;
            this.checkBoxInternal.Location = new System.Drawing.Point(22, 63);
            this.checkBoxInternal.Name = "checkBoxInternal";
            this.checkBoxInternal.Size = new System.Drawing.Size(72, 16);
            this.checkBoxInternal.TabIndex = 1;
            this.checkBoxInternal.Text = "内置操作";
            this.checkBoxInternal.UseVisualStyleBackColor = true;
            this.checkBoxInternal.CheckedChanged += new System.EventHandler(this.checkBoxInternal_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxApp);
            this.groupBox2.Controls.Add(this.labelApp);
            this.groupBox2.Controls.Add(this.buttonApp);
            this.groupBox2.Controls.Add(this.textBoxAppStartpath);
            this.groupBox2.Controls.Add(this.labelAppParam);
            this.groupBox2.Controls.Add(this.labelAppStartpath);
            this.groupBox2.Controls.Add(this.textBoxAppParam);
            this.groupBox2.Location = new System.Drawing.Point(22, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 120);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // textBoxApp
            // 
            this.textBoxApp.Enabled = false;
            this.textBoxApp.Location = new System.Drawing.Point(6, 36);
            this.textBoxApp.Name = "textBoxApp";
            this.textBoxApp.Size = new System.Drawing.Size(316, 21);
            this.textBoxApp.TabIndex = 1;
            // 
            // labelApp
            // 
            this.labelApp.AutoSize = true;
            this.labelApp.Location = new System.Drawing.Point(6, 21);
            this.labelApp.Name = "labelApp";
            this.labelApp.Size = new System.Drawing.Size(41, 12);
            this.labelApp.TabIndex = 0;
            this.labelApp.Text = "程序：";
            // 
            // buttonApp
            // 
            this.buttonApp.Enabled = false;
            this.buttonApp.Location = new System.Drawing.Point(328, 34);
            this.buttonApp.Name = "buttonApp";
            this.buttonApp.Size = new System.Drawing.Size(75, 23);
            this.buttonApp.TabIndex = 2;
            this.buttonApp.Text = "浏览...";
            this.buttonApp.UseVisualStyleBackColor = true;
            // 
            // textBoxAppStartpath
            // 
            this.textBoxAppStartpath.Enabled = false;
            this.textBoxAppStartpath.Location = new System.Drawing.Point(113, 90);
            this.textBoxAppStartpath.Name = "textBoxAppStartpath";
            this.textBoxAppStartpath.Size = new System.Drawing.Size(290, 21);
            this.textBoxAppStartpath.TabIndex = 6;
            // 
            // labelAppParam
            // 
            this.labelAppParam.AutoSize = true;
            this.labelAppParam.Location = new System.Drawing.Point(6, 66);
            this.labelAppParam.Name = "labelAppParam";
            this.labelAppParam.Size = new System.Drawing.Size(77, 12);
            this.labelAppParam.TabIndex = 3;
            this.labelAppParam.Text = "参数(可选)：";
            // 
            // labelAppStartpath
            // 
            this.labelAppStartpath.AutoSize = true;
            this.labelAppStartpath.Location = new System.Drawing.Point(4, 93);
            this.labelAppStartpath.Name = "labelAppStartpath";
            this.labelAppStartpath.Size = new System.Drawing.Size(101, 12);
            this.labelAppStartpath.TabIndex = 5;
            this.labelAppStartpath.Text = "开始目录(可选)：";
            // 
            // textBoxAppParam
            // 
            this.textBoxAppParam.Enabled = false;
            this.textBoxAppParam.Location = new System.Drawing.Point(113, 63);
            this.textBoxAppParam.Name = "textBoxAppParam";
            this.textBoxAppParam.Size = new System.Drawing.Size(290, 21);
            this.textBoxAppParam.TabIndex = 4;
            // 
            // checkBoxRunApp
            // 
            this.checkBoxRunApp.AutoSize = true;
            this.checkBoxRunApp.Location = new System.Drawing.Point(22, 138);
            this.checkBoxRunApp.Name = "checkBoxRunApp";
            this.checkBoxRunApp.Size = new System.Drawing.Size(72, 16);
            this.checkBoxRunApp.TabIndex = 3;
            this.checkBoxRunApp.Text = "运行程序";
            this.checkBoxRunApp.UseVisualStyleBackColor = true;
            this.checkBoxRunApp.CheckedChanged += new System.EventHandler(this.checkBoxRunApp_CheckedChanged);
            // 
            // checkBoxShowMessage
            // 
            this.checkBoxShowMessage.AutoSize = true;
            this.checkBoxShowMessage.Checked = true;
            this.checkBoxShowMessage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowMessage.Location = new System.Drawing.Point(22, 19);
            this.checkBoxShowMessage.Name = "checkBoxShowMessage";
            this.checkBoxShowMessage.Size = new System.Drawing.Size(96, 16);
            this.checkBoxShowMessage.TabIndex = 0;
            this.checkBoxShowMessage.Text = "显示提醒信息";
            this.checkBoxShowMessage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonCancel);
            this.splitContainer1.Panel2.Controls.Add(this.buttonOK);
            this.splitContainer1.Size = new System.Drawing.Size(458, 359);
            this.splitContainer1.SplitterDistance = 319;
            this.splitContainer1.TabIndex = 5;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(379, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(298, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // TaskSettingsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(458, 359);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TaskSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提醒";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TaskSettingsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageContent.ResumeLayout(false);
            this.tabPageContent.PerformLayout();
            this.SchetabTriggers.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPageExecute.ResumeLayout(false);
            this.tabPageExecute.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLockScreen)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageContent;
        private System.Windows.Forms.TabPage SchetabTriggers;
        private System.Windows.Forms.TabPage tabPageExecute;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonWeek;
        private System.Windows.Forms.RadioButton radioButtonDay;
        private System.Windows.Forms.RadioButton radioButtonOnce;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxSunday;
        private System.Windows.Forms.CheckBox checkBoxSaturday;
        private System.Windows.Forms.CheckBox checkBoxFriday;
        private System.Windows.Forms.CheckBox checkBoxThursday;
        private System.Windows.Forms.CheckBox checkBoxWednesday;
        private System.Windows.Forms.CheckBox checkBoxTuesday;
        private System.Windows.Forms.CheckBox checkBoxMonday;
        private System.Windows.Forms.CheckBox checkBoxInterval;
        private System.Windows.Forms.Label labelApp;
        private System.Windows.Forms.CheckBox checkBoxRunApp;
        private System.Windows.Forms.CheckBox checkBoxShowMessage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxApp;
        private System.Windows.Forms.Button buttonApp;
        private System.Windows.Forms.TextBox textBoxAppStartpath;
        private System.Windows.Forms.Label labelAppParam;
        private System.Windows.Forms.Label labelAppStartpath;
        private System.Windows.Forms.TextBox textBoxAppParam;
        private System.Windows.Forms.RadioButton radioButtonShutdown;
        private System.Windows.Forms.RadioButton radioButtonHibernate;
        private System.Windows.Forms.Label labelLockScreen;
        private System.Windows.Forms.CheckBox checkBoxInternal;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButtonLockScreen;
        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ComboBox comboBoxInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownLockScreen;
        private System.Windows.Forms.CheckBox checkBoxShowAnimation;
    }
}