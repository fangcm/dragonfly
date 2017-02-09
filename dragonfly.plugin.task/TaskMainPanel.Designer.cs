namespace Dragonfly.Plugin.Task
{
    partial class TaskMainPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelContent = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelInterval = new System.Windows.Forms.Label();
            this.comboBoxInterval = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.numericUpDownLockScreen = new System.Windows.Forms.NumericUpDown();
            this.radioButtonLockScreen = new System.Windows.Forms.RadioButton();
            this.labelLockScreen = new System.Windows.Forms.Label();
            this.radioButtonHibernate = new System.Windows.Forms.RadioButton();
            this.radioButtonShutdown = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxApp = new System.Windows.Forms.TextBox();
            this.labelApp = new System.Windows.Forms.Label();
            this.buttonApp = new System.Windows.Forms.Button();
            this.textBoxAppStartpath = new System.Windows.Forms.TextBox();
            this.labelAppParam = new System.Windows.Forms.Label();
            this.labelAppStartpath = new System.Windows.Forms.Label();
            this.textBoxAppParam = new System.Windows.Forms.TextBox();
            this.checkBoxRunApp = new System.Windows.Forms.CheckBox();
            this.labelSecond = new System.Windows.Forms.Label();
            this.labelInternal = new System.Windows.Forms.Label();
            this.radioButtonNull = new System.Windows.Forms.RadioButton();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLockScreen)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(13, 46);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(41, 12);
            this.labelContent.TabIndex = 2;
            this.labelContent.Text = "内容：";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(13, 14);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(41, 12);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "标题：";
            // 
            // textBoxContent
            // 
            this.textBoxContent.Location = new System.Drawing.Point(61, 46);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(364, 69);
            this.textBoxContent.TabIndex = 3;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(61, 11);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(364, 21);
            this.textBoxTitle.TabIndex = 1;
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(13, 136);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(89, 12);
            this.labelInterval.TabIndex = 4;
            this.labelInterval.Text = "任务重复间隔：";
            // 
            // comboBoxInterval
            // 
            this.comboBoxInterval.FormattingEnabled = true;
            this.comboBoxInterval.Items.AddRange(new object[] {
            "5分钟",
            "30分钟",
            "1小时",
            "2小时"});
            this.comboBoxInterval.Location = new System.Drawing.Point(103, 133);
            this.comboBoxInterval.Name = "comboBoxInterval";
            this.comboBoxInterval.Size = new System.Drawing.Size(139, 20);
            this.comboBoxInterval.TabIndex = 5;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButtonNull);
            this.groupBox5.Controls.Add(this.numericUpDownLockScreen);
            this.groupBox5.Controls.Add(this.radioButtonLockScreen);
            this.groupBox5.Controls.Add(this.labelLockScreen);
            this.groupBox5.Controls.Add(this.radioButtonHibernate);
            this.groupBox5.Controls.Add(this.radioButtonShutdown);
            this.groupBox5.Location = new System.Drawing.Point(15, 196);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(410, 47);
            this.groupBox5.TabIndex = 8;
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
            this.numericUpDownLockScreen.TabIndex = 1;
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
            this.radioButtonHibernate.Location = new System.Drawing.Point(172, 19);
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
            this.radioButtonShutdown.Location = new System.Drawing.Point(251, 19);
            this.radioButtonShutdown.Name = "radioButtonShutdown";
            this.radioButtonShutdown.Size = new System.Drawing.Size(71, 16);
            this.radioButtonShutdown.TabIndex = 4;
            this.radioButtonShutdown.TabStop = true;
            this.radioButtonShutdown.Text = "自动关机";
            this.radioButtonShutdown.UseVisualStyleBackColor = true;
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
            this.groupBox2.Location = new System.Drawing.Point(15, 281);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 120);
            this.groupBox2.TabIndex = 10;
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
            this.checkBoxRunApp.Location = new System.Drawing.Point(15, 258);
            this.checkBoxRunApp.Name = "checkBoxRunApp";
            this.checkBoxRunApp.Size = new System.Drawing.Size(84, 16);
            this.checkBoxRunApp.TabIndex = 9;
            this.checkBoxRunApp.Text = "运行程序：";
            this.checkBoxRunApp.UseVisualStyleBackColor = true;
            this.checkBoxRunApp.CheckedChanged += new System.EventHandler(this.checkBoxRunApp_CheckedChanged);
            // 
            // labelSecond
            // 
            this.labelSecond.AutoSize = true;
            this.labelSecond.Location = new System.Drawing.Point(248, 136);
            this.labelSecond.Name = "labelSecond";
            this.labelSecond.Size = new System.Drawing.Size(17, 12);
            this.labelSecond.TabIndex = 6;
            this.labelSecond.Text = "秒";
            // 
            // labelInternal
            // 
            this.labelInternal.AutoSize = true;
            this.labelInternal.Location = new System.Drawing.Point(13, 170);
            this.labelInternal.Name = "labelInternal";
            this.labelInternal.Size = new System.Drawing.Size(65, 12);
            this.labelInternal.TabIndex = 7;
            this.labelInternal.Text = "触发操作：";
            // 
            // radioButtonNull
            // 
            this.radioButtonNull.AutoSize = true;
            this.radioButtonNull.Enabled = false;
            this.radioButtonNull.Location = new System.Drawing.Point(328, 19);
            this.radioButtonNull.Name = "radioButtonNull";
            this.radioButtonNull.Size = new System.Drawing.Size(59, 16);
            this.radioButtonNull.TabIndex = 5;
            this.radioButtonNull.TabStop = true;
            this.radioButtonNull.Text = "无操作";
            this.radioButtonNull.UseVisualStyleBackColor = true;
            // 
            // TaskMainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelInternal);
            this.Controls.Add(this.labelSecond);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkBoxRunApp);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.comboBoxInterval);
            this.Controls.Add(this.labelContent);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxContent);
            this.Controls.Add(this.textBoxTitle);
            this.Name = "TaskMainPanel";
            this.Size = new System.Drawing.Size(440, 410);
            this.Load += new System.EventHandler(this.TaskMainPanel_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLockScreen)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.ComboBox comboBoxInterval;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown numericUpDownLockScreen;
        private System.Windows.Forms.RadioButton radioButtonLockScreen;
        private System.Windows.Forms.Label labelLockScreen;
        private System.Windows.Forms.RadioButton radioButtonHibernate;
        private System.Windows.Forms.RadioButton radioButtonShutdown;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxApp;
        private System.Windows.Forms.Label labelApp;
        private System.Windows.Forms.Button buttonApp;
        private System.Windows.Forms.TextBox textBoxAppStartpath;
        private System.Windows.Forms.Label labelAppParam;
        private System.Windows.Forms.Label labelAppStartpath;
        private System.Windows.Forms.TextBox textBoxAppParam;
        private System.Windows.Forms.CheckBox checkBoxRunApp;
        private System.Windows.Forms.Label labelSecond;
        private System.Windows.Forms.RadioButton radioButtonNull;
        private System.Windows.Forms.Label labelInternal;
    }
}
