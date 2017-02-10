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
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelInterval = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButtonNone = new System.Windows.Forms.RadioButton();
            this.radioButtonHibernate = new System.Windows.Forms.RadioButton();
            this.radioButtonShutdown = new System.Windows.Forms.RadioButton();
            this.numericUpDownLockScreen = new System.Windows.Forms.NumericUpDown();
            this.labelLockScreen = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxApp = new System.Windows.Forms.TextBox();
            this.labelApp = new System.Windows.Forms.Label();
            this.buttonApp = new System.Windows.Forms.Button();
            this.textBoxAppStartpath = new System.Windows.Forms.TextBox();
            this.labelAppParam = new System.Windows.Forms.Label();
            this.labelAppStartpath = new System.Windows.Forms.Label();
            this.textBoxAppParam = new System.Windows.Forms.TextBox();
            this.checkBoxRunApp = new System.Windows.Forms.CheckBox();
            this.labelMinute = new System.Windows.Forms.Label();
            this.labelInternal = new System.Windows.Forms.Label();
            this.checkBoxLockScreen = new System.Windows.Forms.CheckBox();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLockScreen)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(17, 23);
            this.labelContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(52, 15);
            this.labelContent.TabIndex = 2;
            this.labelContent.Text = "描述：";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(81, 23);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(484, 85);
            this.textBoxDescription.TabIndex = 3;
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(17, 135);
            this.labelInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(112, 15);
            this.labelInterval.TabIndex = 4;
            this.labelInterval.Text = "任务重复间隔：";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButtonNone);
            this.groupBox5.Controls.Add(this.radioButtonHibernate);
            this.groupBox5.Controls.Add(this.radioButtonShutdown);
            this.groupBox5.Location = new System.Drawing.Point(135, 206);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(430, 59);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            // 
            // radioButtonNone
            // 
            this.radioButtonNone.AutoSize = true;
            this.radioButtonNone.Location = new System.Drawing.Point(216, 26);
            this.radioButtonNone.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonNone.Name = "radioButtonNone";
            this.radioButtonNone.Size = new System.Drawing.Size(73, 19);
            this.radioButtonNone.TabIndex = 5;
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
            this.radioButtonHibernate.TabIndex = 3;
            this.radioButtonHibernate.TabStop = true;
            this.radioButtonHibernate.Text = "自动休眠";
            this.radioButtonHibernate.UseVisualStyleBackColor = true;
            // 
            // radioButtonShutdown
            // 
            this.radioButtonShutdown.AutoSize = true;
            this.radioButtonShutdown.Location = new System.Drawing.Point(114, 26);
            this.radioButtonShutdown.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonShutdown.Name = "radioButtonShutdown";
            this.radioButtonShutdown.Size = new System.Drawing.Size(88, 19);
            this.radioButtonShutdown.TabIndex = 4;
            this.radioButtonShutdown.TabStop = true;
            this.radioButtonShutdown.Text = "自动关机";
            this.radioButtonShutdown.UseVisualStyleBackColor = true;
            // 
            // numericUpDownLockScreen
            // 
            this.numericUpDownLockScreen.Location = new System.Drawing.Point(137, 173);
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
            this.labelLockScreen.Location = new System.Drawing.Point(217, 178);
            this.labelLockScreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLockScreen.Name = "labelLockScreen";
            this.labelLockScreen.Size = new System.Drawing.Size(37, 15);
            this.labelLockScreen.TabIndex = 2;
            this.labelLockScreen.Text = "分钟";
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
            this.groupBox2.Location = new System.Drawing.Point(20, 316);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(547, 150);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // textBoxApp
            // 
            this.textBoxApp.Location = new System.Drawing.Point(8, 45);
            this.textBoxApp.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxApp.Name = "textBoxApp";
            this.textBoxApp.Size = new System.Drawing.Size(403, 25);
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
            this.textBoxAppParam.Location = new System.Drawing.Point(151, 79);
            this.textBoxAppParam.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAppParam.Name = "textBoxAppParam";
            this.textBoxAppParam.Size = new System.Drawing.Size(385, 25);
            this.textBoxAppParam.TabIndex = 4;
            // 
            // checkBoxRunApp
            // 
            this.checkBoxRunApp.AutoSize = true;
            this.checkBoxRunApp.Location = new System.Drawing.Point(20, 287);
            this.checkBoxRunApp.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxRunApp.Name = "checkBoxRunApp";
            this.checkBoxRunApp.Size = new System.Drawing.Size(104, 19);
            this.checkBoxRunApp.TabIndex = 9;
            this.checkBoxRunApp.Text = "运行程序：";
            this.checkBoxRunApp.UseVisualStyleBackColor = true;
            // 
            // labelMinute
            // 
            this.labelMinute.AutoSize = true;
            this.labelMinute.Location = new System.Drawing.Point(217, 135);
            this.labelMinute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMinute.Name = "labelMinute";
            this.labelMinute.Size = new System.Drawing.Size(37, 15);
            this.labelMinute.TabIndex = 6;
            this.labelMinute.Text = "分钟";
            // 
            // labelInternal
            // 
            this.labelInternal.AutoSize = true;
            this.labelInternal.Location = new System.Drawing.Point(17, 223);
            this.labelInternal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInternal.Name = "labelInternal";
            this.labelInternal.Size = new System.Drawing.Size(82, 15);
            this.labelInternal.TabIndex = 7;
            this.labelInternal.Text = "触发操作：";
            // 
            // checkBoxLockScreen
            // 
            this.checkBoxLockScreen.AutoSize = true;
            this.checkBoxLockScreen.Location = new System.Drawing.Point(20, 174);
            this.checkBoxLockScreen.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxLockScreen.Name = "checkBoxLockScreen";
            this.checkBoxLockScreen.Size = new System.Drawing.Size(104, 19);
            this.checkBoxLockScreen.TabIndex = 11;
            this.checkBoxLockScreen.Text = "锁定屏幕：";
            this.checkBoxLockScreen.UseVisualStyleBackColor = true;
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Location = new System.Drawing.Point(135, 133);
            this.numericUpDownInterval.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            36000,
            0,
            0,
            0});
            this.numericUpDownInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(72, 25);
            this.numericUpDownInterval.TabIndex = 12;
            this.numericUpDownInterval.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // TaskMainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownInterval);
            this.Controls.Add(this.checkBoxLockScreen);
            this.Controls.Add(this.labelInternal);
            this.Controls.Add(this.numericUpDownLockScreen);
            this.Controls.Add(this.labelMinute);
            this.Controls.Add(this.labelLockScreen);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkBoxRunApp);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.labelContent);
            this.Controls.Add(this.textBoxDescription);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TaskMainPanel";
            this.Size = new System.Drawing.Size(587, 480);
            this.Load += new System.EventHandler(this.TaskMainPanel_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLockScreen)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown numericUpDownLockScreen;
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
        private System.Windows.Forms.Label labelMinute;
        private System.Windows.Forms.RadioButton radioButtonNone;
        private System.Windows.Forms.Label labelInternal;
        private System.Windows.Forms.CheckBox checkBoxLockScreen;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
    }
}
