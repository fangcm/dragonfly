namespace Dragonfly.Plugin.Task
{
    partial class JobSettingForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTriggers = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownTooLate = new System.Windows.Forms.NumericUpDown();
            this.labelTooLate2 = new System.Windows.Forms.Label();
            this.labelTooLate1 = new System.Windows.Forms.Label();
            this.dateTimePickerTooLate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxTooLate = new System.Windows.Forms.CheckBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.labelMinute = new System.Windows.Forms.Label();
            this.labelInterval = new System.Windows.Forms.Label();
            this.tabPageExecute = new System.Windows.Forms.TabPage();
            this.checkBoxUseQuestionNotify = new System.Windows.Forms.CheckBox();
            this.checkBoxLockScreen = new System.Windows.Forms.CheckBox();
            this.labelInternal = new System.Windows.Forms.Label();
            this.numericUpDownLockScreen = new System.Windows.Forms.NumericUpDown();
            this.labelLockScreen = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButtonNone = new System.Windows.Forms.RadioButton();
            this.radioButtonHibernate = new System.Windows.Forms.RadioButton();
            this.radioButtonShutdown = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxApp = new System.Windows.Forms.TextBox();
            this.labelApp = new System.Windows.Forms.Label();
            this.textBoxAppStartpath = new System.Windows.Forms.TextBox();
            this.labelAppParam = new System.Windows.Forms.Label();
            this.labelAppStartpath = new System.Windows.Forms.Label();
            this.textBoxAppParam = new System.Windows.Forms.TextBox();
            this.checkBoxRunApp = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.tabPageAdjustment = new System.Windows.Forms.TabPage();
            this.listViewAdjustment = new System.Windows.Forms.ListView();
            this.checkBoxAdjustment = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageTriggers.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTooLate)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.tabPageExecute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLockScreen)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPageAdjustment.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
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
            this.splitContainer1.Size = new System.Drawing.Size(611, 457);
            this.splitContainer1.SplitterDistance = 401;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTriggers);
            this.tabControl1.Controls.Add(this.tabPageExecute);
            this.tabControl1.Controls.Add(this.tabPageAdjustment);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(611, 401);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageTriggers
            // 
            this.tabPageTriggers.Controls.Add(this.groupBox3);
            this.tabPageTriggers.Controls.Add(this.labelDescription);
            this.tabPageTriggers.Controls.Add(this.textBoxDescription);
            this.tabPageTriggers.Controls.Add(this.groupBox1);
            this.tabPageTriggers.Location = new System.Drawing.Point(4, 25);
            this.tabPageTriggers.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageTriggers.Name = "tabPageTriggers";
            this.tabPageTriggers.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageTriggers.Size = new System.Drawing.Size(603, 372);
            this.tabPageTriggers.TabIndex = 1;
            this.tabPageTriggers.Text = "触发时间";
            this.tabPageTriggers.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownTooLate);
            this.groupBox3.Controls.Add(this.labelTooLate2);
            this.groupBox3.Controls.Add(this.labelTooLate1);
            this.groupBox3.Controls.Add(this.dateTimePickerTooLate);
            this.groupBox3.Controls.Add(this.checkBoxTooLate);
            this.groupBox3.Location = new System.Drawing.Point(27, 109);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(530, 70);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其它任务";
            // 
            // numericUpDownTooLate
            // 
            this.numericUpDownTooLate.Location = new System.Drawing.Point(301, 20);
            this.numericUpDownTooLate.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownTooLate.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.numericUpDownTooLate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTooLate.Name = "numericUpDownTooLate";
            this.numericUpDownTooLate.Size = new System.Drawing.Size(60, 25);
            this.numericUpDownTooLate.TabIndex = 3;
            this.numericUpDownTooLate.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // labelTooLate2
            // 
            this.labelTooLate2.AutoSize = true;
            this.labelTooLate2.Location = new System.Drawing.Point(373, 26);
            this.labelTooLate2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTooLate2.Name = "labelTooLate2";
            this.labelTooLate2.Size = new System.Drawing.Size(37, 15);
            this.labelTooLate2.TabIndex = 4;
            this.labelTooLate2.Text = "分钟";
            // 
            // labelTooLate1
            // 
            this.labelTooLate1.AutoSize = true;
            this.labelTooLate1.Location = new System.Drawing.Point(223, 26);
            this.labelTooLate1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTooLate1.Name = "labelTooLate1";
            this.labelTooLate1.Size = new System.Drawing.Size(67, 15);
            this.labelTooLate1.TabIndex = 2;
            this.labelTooLate1.Text = "后，锁屏";
            // 
            // dateTimePickerTooLate
            // 
            this.dateTimePickerTooLate.CustomFormat = "HH:mm";
            this.dateTimePickerTooLate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTooLate.Location = new System.Drawing.Point(127, 20);
            this.dateTimePickerTooLate.Name = "dateTimePickerTooLate";
            this.dateTimePickerTooLate.ShowUpDown = true;
            this.dateTimePickerTooLate.Size = new System.Drawing.Size(83, 25);
            this.dateTimePickerTooLate.TabIndex = 1;
            this.dateTimePickerTooLate.Value = new System.DateTime(2017, 2, 15, 22, 0, 0, 0);
            // 
            // checkBoxTooLate
            // 
            this.checkBoxTooLate.AutoSize = true;
            this.checkBoxTooLate.Location = new System.Drawing.Point(61, 26);
            this.checkBoxTooLate.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxTooLate.Name = "checkBoxTooLate";
            this.checkBoxTooLate.Size = new System.Drawing.Size(59, 19);
            this.checkBoxTooLate.TabIndex = 0;
            this.checkBoxTooLate.Text = "每天";
            this.checkBoxTooLate.UseVisualStyleBackColor = true;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(24, 212);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(82, 15);
            this.labelDescription.TabIndex = 2;
            this.labelDescription.Text = "提醒内容：";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(27, 231);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(530, 60);
            this.textBoxDescription.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownInterval);
            this.groupBox1.Controls.Add(this.labelMinute);
            this.groupBox1.Controls.Add(this.labelInterval);
            this.groupBox1.Location = new System.Drawing.Point(27, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(530, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "定时任务";
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Location = new System.Drawing.Point(176, 20);
            this.numericUpDownInterval.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.numericUpDownInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(72, 25);
            this.numericUpDownInterval.TabIndex = 1;
            this.numericUpDownInterval.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // labelMinute
            // 
            this.labelMinute.AutoSize = true;
            this.labelMinute.Location = new System.Drawing.Point(256, 22);
            this.labelMinute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMinute.Name = "labelMinute";
            this.labelMinute.Size = new System.Drawing.Size(37, 15);
            this.labelMinute.TabIndex = 2;
            this.labelMinute.Text = "分钟";
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(58, 22);
            this.labelInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(112, 15);
            this.labelInterval.TabIndex = 0;
            this.labelInterval.Text = "任务重复间隔：";
            // 
            // tabPageExecute
            // 
            this.tabPageExecute.Controls.Add(this.checkBoxAdjustment);
            this.tabPageExecute.Controls.Add(this.checkBoxUseQuestionNotify);
            this.tabPageExecute.Controls.Add(this.checkBoxLockScreen);
            this.tabPageExecute.Controls.Add(this.labelInternal);
            this.tabPageExecute.Controls.Add(this.numericUpDownLockScreen);
            this.tabPageExecute.Controls.Add(this.labelLockScreen);
            this.tabPageExecute.Controls.Add(this.groupBox5);
            this.tabPageExecute.Controls.Add(this.groupBox2);
            this.tabPageExecute.Controls.Add(this.checkBoxRunApp);
            this.tabPageExecute.Location = new System.Drawing.Point(4, 25);
            this.tabPageExecute.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageExecute.Name = "tabPageExecute";
            this.tabPageExecute.Size = new System.Drawing.Size(603, 372);
            this.tabPageExecute.TabIndex = 2;
            this.tabPageExecute.Text = "操作";
            this.tabPageExecute.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseQuestionNotify
            // 
            this.checkBoxUseQuestionNotify.AutoSize = true;
            this.checkBoxUseQuestionNotify.Location = new System.Drawing.Point(312, 20);
            this.checkBoxUseQuestionNotify.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxUseQuestionNotify.Name = "checkBoxUseQuestionNotify";
            this.checkBoxUseQuestionNotify.Size = new System.Drawing.Size(134, 19);
            this.checkBoxUseQuestionNotify.TabIndex = 3;
            this.checkBoxUseQuestionNotify.Text = "锁屏时做练习题";
            this.checkBoxUseQuestionNotify.UseVisualStyleBackColor = true;
            // 
            // checkBoxLockScreen
            // 
            this.checkBoxLockScreen.AutoSize = true;
            this.checkBoxLockScreen.Location = new System.Drawing.Point(29, 20);
            this.checkBoxLockScreen.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxLockScreen.Name = "checkBoxLockScreen";
            this.checkBoxLockScreen.Size = new System.Drawing.Size(104, 19);
            this.checkBoxLockScreen.TabIndex = 0;
            this.checkBoxLockScreen.Text = "锁定屏幕：";
            this.checkBoxLockScreen.UseVisualStyleBackColor = true;
            // 
            // labelInternal
            // 
            this.labelInternal.AutoSize = true;
            this.labelInternal.Location = new System.Drawing.Point(26, 69);
            this.labelInternal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInternal.Name = "labelInternal";
            this.labelInternal.Size = new System.Drawing.Size(82, 15);
            this.labelInternal.TabIndex = 4;
            this.labelInternal.Text = "触发操作：";
            // 
            // numericUpDownLockScreen
            // 
            this.numericUpDownLockScreen.Location = new System.Drawing.Point(146, 19);
            this.numericUpDownLockScreen.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownLockScreen.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownLockScreen.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLockScreen.Name = "numericUpDownLockScreen";
            this.numericUpDownLockScreen.Size = new System.Drawing.Size(72, 25);
            this.numericUpDownLockScreen.TabIndex = 1;
            this.numericUpDownLockScreen.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // labelLockScreen
            // 
            this.labelLockScreen.AutoSize = true;
            this.labelLockScreen.Location = new System.Drawing.Point(226, 24);
            this.labelLockScreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLockScreen.Name = "labelLockScreen";
            this.labelLockScreen.Size = new System.Drawing.Size(37, 15);
            this.labelLockScreen.TabIndex = 2;
            this.labelLockScreen.Text = "分钟";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButtonNone);
            this.groupBox5.Controls.Add(this.radioButtonHibernate);
            this.groupBox5.Controls.Add(this.radioButtonShutdown);
            this.groupBox5.Location = new System.Drawing.Point(144, 52);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(417, 59);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            // 
            // radioButtonNone
            // 
            this.radioButtonNone.AutoSize = true;
            this.radioButtonNone.Location = new System.Drawing.Point(276, 26);
            this.radioButtonNone.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonNone.Name = "radioButtonNone";
            this.radioButtonNone.Size = new System.Drawing.Size(73, 19);
            this.radioButtonNone.TabIndex = 2;
            this.radioButtonNone.TabStop = true;
            this.radioButtonNone.Text = "无操作";
            this.radioButtonNone.UseVisualStyleBackColor = true;
            // 
            // radioButtonHibernate
            // 
            this.radioButtonHibernate.AutoSize = true;
            this.radioButtonHibernate.Location = new System.Drawing.Point(8, 26);
            this.radioButtonHibernate.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonHibernate.Name = "radioButtonHibernate";
            this.radioButtonHibernate.Size = new System.Drawing.Size(88, 19);
            this.radioButtonHibernate.TabIndex = 0;
            this.radioButtonHibernate.TabStop = true;
            this.radioButtonHibernate.Text = "自动休眠";
            this.radioButtonHibernate.UseVisualStyleBackColor = true;
            // 
            // radioButtonShutdown
            // 
            this.radioButtonShutdown.AutoSize = true;
            this.radioButtonShutdown.Location = new System.Drawing.Point(143, 26);
            this.radioButtonShutdown.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonShutdown.Name = "radioButtonShutdown";
            this.radioButtonShutdown.Size = new System.Drawing.Size(88, 19);
            this.radioButtonShutdown.TabIndex = 1;
            this.radioButtonShutdown.TabStop = true;
            this.radioButtonShutdown.Text = "自动关机";
            this.radioButtonShutdown.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxApp);
            this.groupBox2.Controls.Add(this.labelApp);
            this.groupBox2.Controls.Add(this.textBoxAppStartpath);
            this.groupBox2.Controls.Add(this.labelAppParam);
            this.groupBox2.Controls.Add(this.labelAppStartpath);
            this.groupBox2.Controls.Add(this.textBoxAppParam);
            this.groupBox2.Location = new System.Drawing.Point(29, 204);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(532, 131);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // textBoxApp
            // 
            this.textBoxApp.Location = new System.Drawing.Point(135, 23);
            this.textBoxApp.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxApp.Name = "textBoxApp";
            this.textBoxApp.Size = new System.Drawing.Size(385, 25);
            this.textBoxApp.TabIndex = 1;
            // 
            // labelApp
            // 
            this.labelApp.AutoSize = true;
            this.labelApp.Location = new System.Drawing.Point(8, 26);
            this.labelApp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApp.Name = "labelApp";
            this.labelApp.Size = new System.Drawing.Size(82, 15);
            this.labelApp.TabIndex = 0;
            this.labelApp.Text = "外部程序：";
            // 
            // textBoxAppStartpath
            // 
            this.textBoxAppStartpath.Location = new System.Drawing.Point(135, 89);
            this.textBoxAppStartpath.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAppStartpath.Name = "textBoxAppStartpath";
            this.textBoxAppStartpath.Size = new System.Drawing.Size(385, 25);
            this.textBoxAppStartpath.TabIndex = 5;
            // 
            // labelAppParam
            // 
            this.labelAppParam.AutoSize = true;
            this.labelAppParam.Location = new System.Drawing.Point(8, 59);
            this.labelAppParam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppParam.Name = "labelAppParam";
            this.labelAppParam.Size = new System.Drawing.Size(98, 15);
            this.labelAppParam.TabIndex = 2;
            this.labelAppParam.Text = "参数(可选)：";
            // 
            // labelAppStartpath
            // 
            this.labelAppStartpath.AutoSize = true;
            this.labelAppStartpath.Location = new System.Drawing.Point(8, 92);
            this.labelAppStartpath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppStartpath.Name = "labelAppStartpath";
            this.labelAppStartpath.Size = new System.Drawing.Size(128, 15);
            this.labelAppStartpath.TabIndex = 4;
            this.labelAppStartpath.Text = "开始目录(可选)：";
            // 
            // textBoxAppParam
            // 
            this.textBoxAppParam.Location = new System.Drawing.Point(135, 56);
            this.textBoxAppParam.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAppParam.Name = "textBoxAppParam";
            this.textBoxAppParam.Size = new System.Drawing.Size(385, 25);
            this.textBoxAppParam.TabIndex = 3;
            // 
            // checkBoxRunApp
            // 
            this.checkBoxRunApp.AutoSize = true;
            this.checkBoxRunApp.Location = new System.Drawing.Point(29, 176);
            this.checkBoxRunApp.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxRunApp.Name = "checkBoxRunApp";
            this.checkBoxRunApp.Size = new System.Drawing.Size(89, 19);
            this.checkBoxRunApp.TabIndex = 7;
            this.checkBoxRunApp.Text = "运行程序";
            this.checkBoxRunApp.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(462, 4);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 29);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(350, 4);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 29);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // tabPageAdjustment
            // 
            this.tabPageAdjustment.Controls.Add(this.listViewAdjustment);
            this.tabPageAdjustment.Location = new System.Drawing.Point(4, 25);
            this.tabPageAdjustment.Name = "tabPageAdjustment";
            this.tabPageAdjustment.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdjustment.Size = new System.Drawing.Size(603, 372);
            this.tabPageAdjustment.TabIndex = 3;
            this.tabPageAdjustment.Text = "应用调节";
            this.tabPageAdjustment.UseVisualStyleBackColor = true;
            // 
            // listViewAdjustment
            // 
            this.listViewAdjustment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAdjustment.FullRowSelect = true;
            this.listViewAdjustment.GridLines = true;
            this.listViewAdjustment.Location = new System.Drawing.Point(3, 3);
            this.listViewAdjustment.Name = "listViewAdjustment";
            this.listViewAdjustment.Size = new System.Drawing.Size(597, 366);
            this.listViewAdjustment.TabIndex = 0;
            this.listViewAdjustment.UseCompatibleStateImageBehavior = false;
            this.listViewAdjustment.View = System.Windows.Forms.View.Details;
            // 
            // checkBoxAdjustment
            // 
            this.checkBoxAdjustment.AutoSize = true;
            this.checkBoxAdjustment.Location = new System.Drawing.Point(29, 128);
            this.checkBoxAdjustment.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxAdjustment.Name = "checkBoxAdjustment";
            this.checkBoxAdjustment.Size = new System.Drawing.Size(119, 19);
            this.checkBoxAdjustment.TabIndex = 6;
            this.checkBoxAdjustment.Text = "启用应用调节";
            this.checkBoxAdjustment.UseVisualStyleBackColor = true;
            // 
            // JobSettingForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(611, 457);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "JobSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时提醒";
            this.Load += new System.EventHandler(this.TaskSettingsForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTriggers.ResumeLayout(false);
            this.tabPageTriggers.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTooLate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.tabPageExecute.ResumeLayout(false);
            this.tabPageExecute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLockScreen)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPageAdjustment.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTriggers;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPageExecute;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxApp;
        private System.Windows.Forms.Label labelApp;
        private System.Windows.Forms.TextBox textBoxAppStartpath;
        private System.Windows.Forms.Label labelAppParam;
        private System.Windows.Forms.Label labelAppStartpath;
        private System.Windows.Forms.TextBox textBoxAppParam;
        private System.Windows.Forms.CheckBox checkBoxRunApp;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.Label labelMinute;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.CheckBox checkBoxLockScreen;
        private System.Windows.Forms.Label labelInternal;
        private System.Windows.Forms.NumericUpDown numericUpDownLockScreen;
        private System.Windows.Forms.Label labelLockScreen;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButtonNone;
        private System.Windows.Forms.RadioButton radioButtonHibernate;
        private System.Windows.Forms.RadioButton radioButtonShutdown;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxTooLate;
        private System.Windows.Forms.Label labelTooLate1;
        private System.Windows.Forms.DateTimePicker dateTimePickerTooLate;
        private System.Windows.Forms.NumericUpDown numericUpDownTooLate;
        private System.Windows.Forms.Label labelTooLate2;
        private System.Windows.Forms.CheckBox checkBoxUseQuestionNotify;
        private System.Windows.Forms.TabPage tabPageAdjustment;
        private System.Windows.Forms.ListView listViewAdjustment;
        private System.Windows.Forms.CheckBox checkBoxAdjustment;
    }
}