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
            this.comboBoxInterval = new System.Windows.Forms.ComboBox();
            this.tabPageExecute = new System.Windows.Forms.TabPage();
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelInterval = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageContent.SuspendLayout();
            this.SchetabTriggers.SuspendLayout();
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
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(611, 366);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageContent
            // 
            this.tabPageContent.Controls.Add(this.labelContent);
            this.tabPageContent.Controls.Add(this.labelTitle);
            this.tabPageContent.Controls.Add(this.textBoxContent);
            this.tabPageContent.Controls.Add(this.textBoxTitle);
            this.tabPageContent.Location = new System.Drawing.Point(4, 25);
            this.tabPageContent.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageContent.Name = "tabPageContent";
            this.tabPageContent.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageContent.Size = new System.Drawing.Size(603, 337);
            this.tabPageContent.TabIndex = 0;
            this.tabPageContent.Text = "内容";
            this.tabPageContent.UseVisualStyleBackColor = true;
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(29, 65);
            this.labelContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(52, 15);
            this.labelContent.TabIndex = 2;
            this.labelContent.Text = "内容：";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(29, 25);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(52, 15);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "标题：";
            // 
            // textBoxContent
            // 
            this.textBoxContent.Location = new System.Drawing.Point(32, 84);
            this.textBoxContent.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(545, 112);
            this.textBoxContent.TabIndex = 3;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(93, 21);
            this.textBoxTitle.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(484, 25);
            this.textBoxTitle.TabIndex = 1;
            // 
            // SchetabTriggers
            // 
            this.SchetabTriggers.Controls.Add(this.labelInterval);
            this.SchetabTriggers.Controls.Add(this.comboBoxInterval);
            this.SchetabTriggers.Location = new System.Drawing.Point(4, 25);
            this.SchetabTriggers.Margin = new System.Windows.Forms.Padding(4);
            this.SchetabTriggers.Name = "SchetabTriggers";
            this.SchetabTriggers.Padding = new System.Windows.Forms.Padding(4);
            this.SchetabTriggers.Size = new System.Drawing.Size(603, 337);
            this.SchetabTriggers.TabIndex = 1;
            this.SchetabTriggers.Text = "触发时间";
            this.SchetabTriggers.UseVisualStyleBackColor = true;
            // 
            // comboBoxInterval
            // 
            this.comboBoxInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInterval.FormattingEnabled = true;
            this.comboBoxInterval.Items.AddRange(new object[] {
            "5分钟",
            "30分钟",
            "1小时",
            "2小时"});
            this.comboBoxInterval.Location = new System.Drawing.Point(196, 33);
            this.comboBoxInterval.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxInterval.Name = "comboBoxInterval";
            this.comboBoxInterval.Size = new System.Drawing.Size(160, 23);
            this.comboBoxInterval.TabIndex = 6;
            // 
            // tabPageExecute
            // 
            this.tabPageExecute.Controls.Add(this.groupBox5);
            this.tabPageExecute.Controls.Add(this.checkBoxInternal);
            this.tabPageExecute.Controls.Add(this.groupBox2);
            this.tabPageExecute.Controls.Add(this.checkBoxRunApp);
            this.tabPageExecute.Location = new System.Drawing.Point(4, 25);
            this.tabPageExecute.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageExecute.Name = "tabPageExecute";
            this.tabPageExecute.Size = new System.Drawing.Size(603, 337);
            this.tabPageExecute.TabIndex = 2;
            this.tabPageExecute.Text = "操作";
            this.tabPageExecute.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numericUpDownLockScreen);
            this.groupBox5.Controls.Add(this.radioButtonLockScreen);
            this.groupBox5.Controls.Add(this.labelLockScreen);
            this.groupBox5.Controls.Add(this.radioButtonHibernate);
            this.groupBox5.Controls.Add(this.radioButtonShutdown);
            this.groupBox5.Location = new System.Drawing.Point(27, 48);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(547, 59);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // numericUpDownLockScreen
            // 
            this.numericUpDownLockScreen.Enabled = false;
            this.numericUpDownLockScreen.Location = new System.Drawing.Point(119, 24);
            this.numericUpDownLockScreen.Margin = new System.Windows.Forms.Padding(4);
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
            this.numericUpDownLockScreen.Size = new System.Drawing.Size(72, 25);
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
            this.radioButtonLockScreen.Location = new System.Drawing.Point(16, 24);
            this.radioButtonLockScreen.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonLockScreen.Name = "radioButtonLockScreen";
            this.radioButtonLockScreen.Size = new System.Drawing.Size(88, 19);
            this.radioButtonLockScreen.TabIndex = 0;
            this.radioButtonLockScreen.TabStop = true;
            this.radioButtonLockScreen.Text = "锁定屏幕";
            this.radioButtonLockScreen.UseVisualStyleBackColor = true;
            // 
            // labelLockScreen
            // 
            this.labelLockScreen.AutoSize = true;
            this.labelLockScreen.Location = new System.Drawing.Point(199, 26);
            this.labelLockScreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLockScreen.Name = "labelLockScreen";
            this.labelLockScreen.Size = new System.Drawing.Size(22, 15);
            this.labelLockScreen.TabIndex = 2;
            this.labelLockScreen.Text = "秒";
            // 
            // radioButtonHibernate
            // 
            this.radioButtonHibernate.AutoSize = true;
            this.radioButtonHibernate.Enabled = false;
            this.radioButtonHibernate.Location = new System.Drawing.Point(247, 24);
            this.radioButtonHibernate.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonHibernate.Name = "radioButtonHibernate";
            this.radioButtonHibernate.Size = new System.Drawing.Size(88, 19);
            this.radioButtonHibernate.TabIndex = 3;
            this.radioButtonHibernate.TabStop = true;
            this.radioButtonHibernate.Text = "自动休眠";
            this.radioButtonHibernate.UseVisualStyleBackColor = true;
            // 
            // radioButtonShutdown
            // 
            this.radioButtonShutdown.AutoSize = true;
            this.radioButtonShutdown.Enabled = false;
            this.radioButtonShutdown.Location = new System.Drawing.Point(407, 24);
            this.radioButtonShutdown.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonShutdown.Name = "radioButtonShutdown";
            this.radioButtonShutdown.Size = new System.Drawing.Size(88, 19);
            this.radioButtonShutdown.TabIndex = 4;
            this.radioButtonShutdown.TabStop = true;
            this.radioButtonShutdown.Text = "自动关机";
            this.radioButtonShutdown.UseVisualStyleBackColor = true;
            // 
            // checkBoxInternal
            // 
            this.checkBoxInternal.AutoSize = true;
            this.checkBoxInternal.Location = new System.Drawing.Point(27, 21);
            this.checkBoxInternal.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxInternal.Name = "checkBoxInternal";
            this.checkBoxInternal.Size = new System.Drawing.Size(89, 19);
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
            this.groupBox2.Location = new System.Drawing.Point(27, 142);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(547, 150);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // textBoxApp
            // 
            this.textBoxApp.Enabled = false;
            this.textBoxApp.Location = new System.Drawing.Point(8, 45);
            this.textBoxApp.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxApp.Name = "textBoxApp";
            this.textBoxApp.Size = new System.Drawing.Size(420, 25);
            this.textBoxApp.TabIndex = 1;
            // 
            // labelApp
            // 
            this.labelApp.AutoSize = true;
            this.labelApp.Location = new System.Drawing.Point(8, 26);
            this.labelApp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApp.Name = "labelApp";
            this.labelApp.Size = new System.Drawing.Size(52, 15);
            this.labelApp.TabIndex = 0;
            this.labelApp.Text = "程序：";
            // 
            // buttonApp
            // 
            this.buttonApp.Enabled = false;
            this.buttonApp.Location = new System.Drawing.Point(437, 42);
            this.buttonApp.Margin = new System.Windows.Forms.Padding(4);
            this.buttonApp.Name = "buttonApp";
            this.buttonApp.Size = new System.Drawing.Size(100, 29);
            this.buttonApp.TabIndex = 2;
            this.buttonApp.Text = "浏览...";
            this.buttonApp.UseVisualStyleBackColor = true;
            // 
            // textBoxAppStartpath
            // 
            this.textBoxAppStartpath.Enabled = false;
            this.textBoxAppStartpath.Location = new System.Drawing.Point(151, 112);
            this.textBoxAppStartpath.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAppStartpath.Name = "textBoxAppStartpath";
            this.textBoxAppStartpath.Size = new System.Drawing.Size(385, 25);
            this.textBoxAppStartpath.TabIndex = 6;
            // 
            // labelAppParam
            // 
            this.labelAppParam.AutoSize = true;
            this.labelAppParam.Location = new System.Drawing.Point(8, 82);
            this.labelAppParam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppParam.Name = "labelAppParam";
            this.labelAppParam.Size = new System.Drawing.Size(98, 15);
            this.labelAppParam.TabIndex = 3;
            this.labelAppParam.Text = "参数(可选)：";
            // 
            // labelAppStartpath
            // 
            this.labelAppStartpath.AutoSize = true;
            this.labelAppStartpath.Location = new System.Drawing.Point(5, 116);
            this.labelAppStartpath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppStartpath.Name = "labelAppStartpath";
            this.labelAppStartpath.Size = new System.Drawing.Size(128, 15);
            this.labelAppStartpath.TabIndex = 5;
            this.labelAppStartpath.Text = "开始目录(可选)：";
            // 
            // textBoxAppParam
            // 
            this.textBoxAppParam.Enabled = false;
            this.textBoxAppParam.Location = new System.Drawing.Point(151, 79);
            this.textBoxAppParam.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAppParam.Name = "textBoxAppParam";
            this.textBoxAppParam.Size = new System.Drawing.Size(385, 25);
            this.textBoxAppParam.TabIndex = 4;
            // 
            // checkBoxRunApp
            // 
            this.checkBoxRunApp.AutoSize = true;
            this.checkBoxRunApp.Location = new System.Drawing.Point(27, 114);
            this.checkBoxRunApp.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxRunApp.Name = "checkBoxRunApp";
            this.checkBoxRunApp.Size = new System.Drawing.Size(89, 19);
            this.checkBoxRunApp.TabIndex = 3;
            this.checkBoxRunApp.Text = "运行程序";
            this.checkBoxRunApp.UseVisualStyleBackColor = true;
            this.checkBoxRunApp.CheckedChanged += new System.EventHandler(this.checkBoxRunApp_CheckedChanged);
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
            this.splitContainer1.Size = new System.Drawing.Size(611, 427);
            this.splitContainer1.SplitterDistance = 366;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 5;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(505, 4);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 29);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(397, 4);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 29);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(76, 36);
            this.labelInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(112, 15);
            this.labelInterval.TabIndex = 7;
            this.labelInterval.Text = "任务重复间隔：";
            // 
            // TaskSettingsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(611, 427);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TaskSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提醒";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TaskSettingsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageContent.ResumeLayout(false);
            this.tabPageContent.PerformLayout();
            this.SchetabTriggers.ResumeLayout(false);
            this.SchetabTriggers.PerformLayout();
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
        private System.Windows.Forms.Label labelApp;
        private System.Windows.Forms.CheckBox checkBoxRunApp;
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
        private System.Windows.Forms.Label labelInterval;
    }
}