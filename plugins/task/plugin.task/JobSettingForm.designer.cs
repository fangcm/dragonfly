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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobSettingForm));
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
            this.checkBoxAdjustment = new System.Windows.Forms.CheckBox();
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
            this.tabPageAdjustment = new System.Windows.Forms.TabPage();
            this.listViewAdjustment = new System.Windows.Forms.ListView();
            this.toolStripAdjustment = new System.Windows.Forms.ToolStrip();
            this.tsb_newAdjustment = new System.Windows.Forms.ToolStripButton();
            this.tsb_editAdjustment = new System.Windows.Forms.ToolStripButton();
            this.tsb_deleteAdjustment = new System.Windows.Forms.ToolStripButton();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
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
            this.toolStripAdjustment.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(458, 366);
            this.splitContainer1.SplitterDistance = 308;
            this.splitContainer1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTriggers);
            this.tabControl1.Controls.Add(this.tabPageExecute);
            this.tabControl1.Controls.Add(this.tabPageAdjustment);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(458, 308);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageTriggers
            // 
            this.tabPageTriggers.Controls.Add(this.groupBox3);
            this.tabPageTriggers.Controls.Add(this.labelDescription);
            this.tabPageTriggers.Controls.Add(this.textBoxDescription);
            this.tabPageTriggers.Controls.Add(this.groupBox1);
            this.tabPageTriggers.Location = new System.Drawing.Point(4, 22);
            this.tabPageTriggers.Name = "tabPageTriggers";
            this.tabPageTriggers.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageTriggers.Size = new System.Drawing.Size(450, 282);
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
            this.groupBox3.Location = new System.Drawing.Point(20, 87);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(398, 56);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其它任务";
            // 
            // numericUpDownTooLate
            // 
            this.numericUpDownTooLate.Location = new System.Drawing.Point(226, 16);
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
            this.numericUpDownTooLate.Size = new System.Drawing.Size(45, 21);
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
            this.labelTooLate2.Location = new System.Drawing.Point(280, 21);
            this.labelTooLate2.Name = "labelTooLate2";
            this.labelTooLate2.Size = new System.Drawing.Size(29, 12);
            this.labelTooLate2.TabIndex = 4;
            this.labelTooLate2.Text = "分钟";
            // 
            // labelTooLate1
            // 
            this.labelTooLate1.AutoSize = true;
            this.labelTooLate1.Location = new System.Drawing.Point(167, 21);
            this.labelTooLate1.Name = "labelTooLate1";
            this.labelTooLate1.Size = new System.Drawing.Size(53, 12);
            this.labelTooLate1.TabIndex = 2;
            this.labelTooLate1.Text = "后，锁屏";
            // 
            // dateTimePickerTooLate
            // 
            this.dateTimePickerTooLate.CustomFormat = "HH:mm";
            this.dateTimePickerTooLate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTooLate.Location = new System.Drawing.Point(95, 16);
            this.dateTimePickerTooLate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerTooLate.Name = "dateTimePickerTooLate";
            this.dateTimePickerTooLate.ShowUpDown = true;
            this.dateTimePickerTooLate.Size = new System.Drawing.Size(63, 21);
            this.dateTimePickerTooLate.TabIndex = 1;
            this.dateTimePickerTooLate.Value = new System.DateTime(2017, 2, 15, 22, 0, 0, 0);
            // 
            // checkBoxTooLate
            // 
            this.checkBoxTooLate.AutoSize = true;
            this.checkBoxTooLate.Location = new System.Drawing.Point(46, 21);
            this.checkBoxTooLate.Name = "checkBoxTooLate";
            this.checkBoxTooLate.Size = new System.Drawing.Size(48, 16);
            this.checkBoxTooLate.TabIndex = 0;
            this.checkBoxTooLate.Text = "每天";
            this.checkBoxTooLate.UseVisualStyleBackColor = true;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(18, 170);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(65, 12);
            this.labelDescription.TabIndex = 2;
            this.labelDescription.Text = "提醒内容：";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(20, 185);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(398, 49);
            this.textBoxDescription.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownInterval);
            this.groupBox1.Controls.Add(this.labelMinute);
            this.groupBox1.Controls.Add(this.labelInterval);
            this.groupBox1.Location = new System.Drawing.Point(20, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "定时任务";
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Location = new System.Drawing.Point(132, 16);
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
            this.numericUpDownInterval.Size = new System.Drawing.Size(54, 21);
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
            this.labelMinute.Location = new System.Drawing.Point(192, 18);
            this.labelMinute.Name = "labelMinute";
            this.labelMinute.Size = new System.Drawing.Size(29, 12);
            this.labelMinute.TabIndex = 2;
            this.labelMinute.Text = "分钟";
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(44, 18);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(89, 12);
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
            this.tabPageExecute.Location = new System.Drawing.Point(4, 22);
            this.tabPageExecute.Name = "tabPageExecute";
            this.tabPageExecute.Size = new System.Drawing.Size(450, 293);
            this.tabPageExecute.TabIndex = 2;
            this.tabPageExecute.Text = "操作";
            this.tabPageExecute.UseVisualStyleBackColor = true;
            // 
            // checkBoxAdjustment
            // 
            this.checkBoxAdjustment.AutoSize = true;
            this.checkBoxAdjustment.Location = new System.Drawing.Point(22, 42);
            this.checkBoxAdjustment.Name = "checkBoxAdjustment";
            this.checkBoxAdjustment.Size = new System.Drawing.Size(96, 16);
            this.checkBoxAdjustment.TabIndex = 4;
            this.checkBoxAdjustment.Text = "启用应用调节";
            this.checkBoxAdjustment.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseQuestionNotify
            // 
            this.checkBoxUseQuestionNotify.AutoSize = true;
            this.checkBoxUseQuestionNotify.Location = new System.Drawing.Point(234, 16);
            this.checkBoxUseQuestionNotify.Name = "checkBoxUseQuestionNotify";
            this.checkBoxUseQuestionNotify.Size = new System.Drawing.Size(108, 16);
            this.checkBoxUseQuestionNotify.TabIndex = 3;
            this.checkBoxUseQuestionNotify.Text = "锁屏时做练习题";
            this.checkBoxUseQuestionNotify.UseVisualStyleBackColor = true;
            // 
            // checkBoxLockScreen
            // 
            this.checkBoxLockScreen.AutoSize = true;
            this.checkBoxLockScreen.Location = new System.Drawing.Point(22, 16);
            this.checkBoxLockScreen.Name = "checkBoxLockScreen";
            this.checkBoxLockScreen.Size = new System.Drawing.Size(84, 16);
            this.checkBoxLockScreen.TabIndex = 0;
            this.checkBoxLockScreen.Text = "锁定屏幕：";
            this.checkBoxLockScreen.UseVisualStyleBackColor = true;
            // 
            // labelInternal
            // 
            this.labelInternal.AutoSize = true;
            this.labelInternal.Location = new System.Drawing.Point(20, 82);
            this.labelInternal.Name = "labelInternal";
            this.labelInternal.Size = new System.Drawing.Size(65, 12);
            this.labelInternal.TabIndex = 5;
            this.labelInternal.Text = "触发操作：";
            // 
            // numericUpDownLockScreen
            // 
            this.numericUpDownLockScreen.Location = new System.Drawing.Point(110, 15);
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
            this.numericUpDownLockScreen.Size = new System.Drawing.Size(54, 21);
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
            this.labelLockScreen.Location = new System.Drawing.Point(170, 19);
            this.labelLockScreen.Name = "labelLockScreen";
            this.labelLockScreen.Size = new System.Drawing.Size(29, 12);
            this.labelLockScreen.TabIndex = 2;
            this.labelLockScreen.Text = "分钟";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButtonNone);
            this.groupBox5.Controls.Add(this.radioButtonHibernate);
            this.groupBox5.Controls.Add(this.radioButtonShutdown);
            this.groupBox5.Location = new System.Drawing.Point(108, 69);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(313, 47);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            // 
            // radioButtonNone
            // 
            this.radioButtonNone.AutoSize = true;
            this.radioButtonNone.Location = new System.Drawing.Point(207, 21);
            this.radioButtonNone.Name = "radioButtonNone";
            this.radioButtonNone.Size = new System.Drawing.Size(59, 16);
            this.radioButtonNone.TabIndex = 2;
            this.radioButtonNone.TabStop = true;
            this.radioButtonNone.Text = "无操作";
            this.radioButtonNone.UseVisualStyleBackColor = true;
            // 
            // radioButtonHibernate
            // 
            this.radioButtonHibernate.AutoSize = true;
            this.radioButtonHibernate.Location = new System.Drawing.Point(6, 21);
            this.radioButtonHibernate.Name = "radioButtonHibernate";
            this.radioButtonHibernate.Size = new System.Drawing.Size(71, 16);
            this.radioButtonHibernate.TabIndex = 0;
            this.radioButtonHibernate.TabStop = true;
            this.radioButtonHibernate.Text = "自动休眠";
            this.radioButtonHibernate.UseVisualStyleBackColor = true;
            // 
            // radioButtonShutdown
            // 
            this.radioButtonShutdown.AutoSize = true;
            this.radioButtonShutdown.Location = new System.Drawing.Point(107, 21);
            this.radioButtonShutdown.Name = "radioButtonShutdown";
            this.radioButtonShutdown.Size = new System.Drawing.Size(71, 16);
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
            this.groupBox2.Location = new System.Drawing.Point(22, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 105);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // textBoxApp
            // 
            this.textBoxApp.Location = new System.Drawing.Point(101, 18);
            this.textBoxApp.Name = "textBoxApp";
            this.textBoxApp.Size = new System.Drawing.Size(290, 21);
            this.textBoxApp.TabIndex = 1;
            // 
            // labelApp
            // 
            this.labelApp.AutoSize = true;
            this.labelApp.Location = new System.Drawing.Point(6, 21);
            this.labelApp.Name = "labelApp";
            this.labelApp.Size = new System.Drawing.Size(65, 12);
            this.labelApp.TabIndex = 0;
            this.labelApp.Text = "外部程序：";
            // 
            // textBoxAppStartpath
            // 
            this.textBoxAppStartpath.Location = new System.Drawing.Point(101, 71);
            this.textBoxAppStartpath.Name = "textBoxAppStartpath";
            this.textBoxAppStartpath.Size = new System.Drawing.Size(290, 21);
            this.textBoxAppStartpath.TabIndex = 5;
            // 
            // labelAppParam
            // 
            this.labelAppParam.AutoSize = true;
            this.labelAppParam.Location = new System.Drawing.Point(6, 47);
            this.labelAppParam.Name = "labelAppParam";
            this.labelAppParam.Size = new System.Drawing.Size(77, 12);
            this.labelAppParam.TabIndex = 2;
            this.labelAppParam.Text = "参数(可选)：";
            // 
            // labelAppStartpath
            // 
            this.labelAppStartpath.AutoSize = true;
            this.labelAppStartpath.Location = new System.Drawing.Point(6, 74);
            this.labelAppStartpath.Name = "labelAppStartpath";
            this.labelAppStartpath.Size = new System.Drawing.Size(101, 12);
            this.labelAppStartpath.TabIndex = 4;
            this.labelAppStartpath.Text = "开始目录(可选)：";
            // 
            // textBoxAppParam
            // 
            this.textBoxAppParam.Location = new System.Drawing.Point(101, 45);
            this.textBoxAppParam.Name = "textBoxAppParam";
            this.textBoxAppParam.Size = new System.Drawing.Size(290, 21);
            this.textBoxAppParam.TabIndex = 3;
            // 
            // checkBoxRunApp
            // 
            this.checkBoxRunApp.AutoSize = true;
            this.checkBoxRunApp.Location = new System.Drawing.Point(22, 121);
            this.checkBoxRunApp.Name = "checkBoxRunApp";
            this.checkBoxRunApp.Size = new System.Drawing.Size(72, 16);
            this.checkBoxRunApp.TabIndex = 7;
            this.checkBoxRunApp.Text = "运行程序";
            this.checkBoxRunApp.UseVisualStyleBackColor = true;
            // 
            // tabPageAdjustment
            // 
            this.tabPageAdjustment.Controls.Add(this.listViewAdjustment);
            this.tabPageAdjustment.Controls.Add(this.toolStripAdjustment);
            this.tabPageAdjustment.Location = new System.Drawing.Point(4, 22);
            this.tabPageAdjustment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageAdjustment.Name = "tabPageAdjustment";
            this.tabPageAdjustment.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageAdjustment.Size = new System.Drawing.Size(450, 282);
            this.tabPageAdjustment.TabIndex = 3;
            this.tabPageAdjustment.Text = "应用调节";
            this.tabPageAdjustment.UseVisualStyleBackColor = true;
            // 
            // listViewAdjustment
            // 
            this.listViewAdjustment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAdjustment.FullRowSelect = true;
            this.listViewAdjustment.GridLines = true;
            this.listViewAdjustment.HideSelection = false;
            this.listViewAdjustment.Location = new System.Drawing.Point(2, 27);
            this.listViewAdjustment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listViewAdjustment.Name = "listViewAdjustment";
            this.listViewAdjustment.Size = new System.Drawing.Size(446, 253);
            this.listViewAdjustment.TabIndex = 0;
            this.listViewAdjustment.UseCompatibleStateImageBehavior = false;
            this.listViewAdjustment.View = System.Windows.Forms.View.Details;
            this.listViewAdjustment.SelectedIndexChanged += new System.EventHandler(this.listViewAdjustment_SelectedIndexChanged);
            // 
            // toolStripAdjustment
            // 
            this.toolStripAdjustment.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripAdjustment.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripAdjustment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_newAdjustment,
            this.tsb_editAdjustment,
            this.tsb_deleteAdjustment});
            this.toolStripAdjustment.Location = new System.Drawing.Point(2, 2);
            this.toolStripAdjustment.Name = "toolStripAdjustment";
            this.toolStripAdjustment.Size = new System.Drawing.Size(446, 25);
            this.toolStripAdjustment.TabIndex = 1;
            // 
            // tsb_newAdjustment
            // 
            this.tsb_newAdjustment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_newAdjustment.Image = ((System.Drawing.Image)(resources.GetObject("tsb_newAdjustment.Image")));
            this.tsb_newAdjustment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_newAdjustment.Name = "tsb_newAdjustment";
            this.tsb_newAdjustment.Size = new System.Drawing.Size(36, 22);
            this.tsb_newAdjustment.Text = "新增";
            this.tsb_newAdjustment.Click += new System.EventHandler(this.tsb_newAdjustment_Click);
            // 
            // tsb_editAdjustment
            // 
            this.tsb_editAdjustment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_editAdjustment.Enabled = false;
            this.tsb_editAdjustment.Image = ((System.Drawing.Image)(resources.GetObject("tsb_editAdjustment.Image")));
            this.tsb_editAdjustment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_editAdjustment.Name = "tsb_editAdjustment";
            this.tsb_editAdjustment.Size = new System.Drawing.Size(36, 22);
            this.tsb_editAdjustment.Text = "修改";
            this.tsb_editAdjustment.Click += new System.EventHandler(this.tsb_editAdjustment_Click);
            // 
            // tsb_deleteAdjustment
            // 
            this.tsb_deleteAdjustment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_deleteAdjustment.Enabled = false;
            this.tsb_deleteAdjustment.Image = ((System.Drawing.Image)(resources.GetObject("tsb_deleteAdjustment.Image")));
            this.tsb_deleteAdjustment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_deleteAdjustment.Name = "tsb_deleteAdjustment";
            this.tsb_deleteAdjustment.Size = new System.Drawing.Size(36, 22);
            this.tsb_deleteAdjustment.Text = "删除";
            this.tsb_deleteAdjustment.Click += new System.EventHandler(this.tsb_deleteAdjustment_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(346, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(262, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // JobSettingForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(458, 366);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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
            this.tabPageAdjustment.PerformLayout();
            this.toolStripAdjustment.ResumeLayout(false);
            this.toolStripAdjustment.PerformLayout();
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
        private System.Windows.Forms.ToolStrip toolStripAdjustment;
        private System.Windows.Forms.ToolStripButton tsb_newAdjustment;
        private System.Windows.Forms.ToolStripButton tsb_deleteAdjustment;
        private System.Windows.Forms.ToolStripButton tsb_editAdjustment;
    }
}