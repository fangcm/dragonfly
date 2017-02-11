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
            this.SchetabTriggers = new System.Windows.Forms.TabPage();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.labelMinute = new System.Windows.Forms.Label();
            this.labelInterval = new System.Windows.Forms.Label();
            this.tabPageExecute = new System.Windows.Forms.TabPage();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SchetabTriggers.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.tabPageExecute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLockScreen)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.splitContainer1.SplitterDistance = 407;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.SchetabTriggers);
            this.tabControl1.Controls.Add(this.tabPageExecute);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(611, 407);
            this.tabControl1.TabIndex = 0;
            // 
            // SchetabTriggers
            // 
            this.SchetabTriggers.Controls.Add(this.labelDescription);
            this.SchetabTriggers.Controls.Add(this.textBoxDescription);
            this.SchetabTriggers.Controls.Add(this.groupBox1);
            this.SchetabTriggers.Location = new System.Drawing.Point(4, 25);
            this.SchetabTriggers.Margin = new System.Windows.Forms.Padding(4);
            this.SchetabTriggers.Name = "SchetabTriggers";
            this.SchetabTriggers.Padding = new System.Windows.Forms.Padding(4);
            this.SchetabTriggers.Size = new System.Drawing.Size(603, 378);
            this.SchetabTriggers.TabIndex = 1;
            this.SchetabTriggers.Text = "触发时间";
            this.SchetabTriggers.UseVisualStyleBackColor = true;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(24, 150);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(82, 15);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "提醒内容：";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(27, 179);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(531, 112);
            this.textBoxDescription.TabIndex = 2;
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
            this.groupBox1.Size = new System.Drawing.Size(531, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Location = new System.Drawing.Point(144, 39);
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
            this.labelMinute.Location = new System.Drawing.Point(226, 41);
            this.labelMinute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMinute.Name = "labelMinute";
            this.labelMinute.Size = new System.Drawing.Size(37, 15);
            this.labelMinute.TabIndex = 2;
            this.labelMinute.Text = "分钟";
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(26, 41);
            this.labelInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(112, 15);
            this.labelInterval.TabIndex = 0;
            this.labelInterval.Text = "任务重复间隔：";
            // 
            // tabPageExecute
            // 
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
            this.tabPageExecute.Size = new System.Drawing.Size(603, 378);
            this.tabPageExecute.TabIndex = 2;
            this.tabPageExecute.Text = "操作";
            this.tabPageExecute.UseVisualStyleBackColor = true;
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
            this.labelInternal.TabIndex = 3;
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
            this.groupBox5.TabIndex = 4;
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
            this.groupBox2.Location = new System.Drawing.Point(29, 171);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(532, 131);
            this.groupBox2.TabIndex = 6;
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
            this.textBoxAppStartpath.TabIndex = 6;
            // 
            // labelAppParam
            // 
            this.labelAppParam.AutoSize = true;
            this.labelAppParam.Location = new System.Drawing.Point(8, 59);
            this.labelAppParam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppParam.Name = "labelAppParam";
            this.labelAppParam.Size = new System.Drawing.Size(98, 15);
            this.labelAppParam.TabIndex = 3;
            this.labelAppParam.Text = "参数(可选)：";
            // 
            // labelAppStartpath
            // 
            this.labelAppStartpath.AutoSize = true;
            this.labelAppStartpath.Location = new System.Drawing.Point(8, 92);
            this.labelAppStartpath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppStartpath.Name = "labelAppStartpath";
            this.labelAppStartpath.Size = new System.Drawing.Size(128, 15);
            this.labelAppStartpath.TabIndex = 5;
            this.labelAppStartpath.Text = "开始目录(可选)：";
            // 
            // textBoxAppParam
            // 
            this.textBoxAppParam.Location = new System.Drawing.Point(135, 56);
            this.textBoxAppParam.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAppParam.Name = "textBoxAppParam";
            this.textBoxAppParam.Size = new System.Drawing.Size(385, 25);
            this.textBoxAppParam.TabIndex = 4;
            // 
            // checkBoxRunApp
            // 
            this.checkBoxRunApp.AutoSize = true;
            this.checkBoxRunApp.Location = new System.Drawing.Point(29, 143);
            this.checkBoxRunApp.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxRunApp.Name = "checkBoxRunApp";
            this.checkBoxRunApp.Size = new System.Drawing.Size(89, 19);
            this.checkBoxRunApp.TabIndex = 5;
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
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TaskSettingsForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.SchetabTriggers.ResumeLayout(false);
            this.SchetabTriggers.PerformLayout();
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage SchetabTriggers;
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
    }
}