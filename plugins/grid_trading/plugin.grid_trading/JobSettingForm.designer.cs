namespace Dragonfly.Plugin.GridTrading
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
            this.numericUpDownTooLate = new System.Windows.Forms.NumericUpDown();
            this.labelTooLate2 = new System.Windows.Forms.Label();
            this.labelTooLate1 = new System.Windows.Forms.Label();
            this.dateTimePickerTooLate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxTooLate = new System.Windows.Forms.CheckBox();
            this.checkBoxUseQuestionNotify = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_onehour = new System.Windows.Forms.RadioButton();
            this.rb_twohour = new System.Windows.Forms.RadioButton();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.numericUpDownDuration = new System.Windows.Forms.NumericUpDown();
            this.labelDuration2 = new System.Windows.Forms.Label();
            this.labelDuration1 = new System.Windows.Forms.Label();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.labelStartTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTooLate)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxUseQuestionNotify);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonCancel);
            this.splitContainer1.Panel2.Controls.Add(this.buttonOK);
            this.splitContainer1.Size = new System.Drawing.Size(611, 362);
            this.splitContainer1.SplitterDistance = 309;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // numericUpDownTooLate
            // 
            this.numericUpDownTooLate.Location = new System.Drawing.Point(285, 171);
            this.numericUpDownTooLate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            120,
            0,
            0,
            0});
            // 
            // labelTooLate2
            // 
            this.labelTooLate2.AutoSize = true;
            this.labelTooLate2.Location = new System.Drawing.Point(357, 177);
            this.labelTooLate2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTooLate2.Name = "labelTooLate2";
            this.labelTooLate2.Size = new System.Drawing.Size(37, 15);
            this.labelTooLate2.TabIndex = 4;
            this.labelTooLate2.Text = "分钟";
            // 
            // labelTooLate1
            // 
            this.labelTooLate1.AutoSize = true;
            this.labelTooLate1.Location = new System.Drawing.Point(207, 177);
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
            this.dateTimePickerTooLate.Location = new System.Drawing.Point(111, 171);
            this.dateTimePickerTooLate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerTooLate.Name = "dateTimePickerTooLate";
            this.dateTimePickerTooLate.ShowUpDown = true;
            this.dateTimePickerTooLate.Size = new System.Drawing.Size(83, 25);
            this.dateTimePickerTooLate.TabIndex = 1;
            this.dateTimePickerTooLate.Value = new System.DateTime(2017, 2, 15, 22, 0, 0, 0);
            // 
            // checkBoxTooLate
            // 
            this.checkBoxTooLate.AutoSize = true;
            this.checkBoxTooLate.Location = new System.Drawing.Point(45, 177);
            this.checkBoxTooLate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxTooLate.Name = "checkBoxTooLate";
            this.checkBoxTooLate.Size = new System.Drawing.Size(59, 19);
            this.checkBoxTooLate.TabIndex = 0;
            this.checkBoxTooLate.Text = "每天";
            this.checkBoxTooLate.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseQuestionNotify
            // 
            this.checkBoxUseQuestionNotify.AutoSize = true;
            this.checkBoxUseQuestionNotify.Location = new System.Drawing.Point(16, 256);
            this.checkBoxUseQuestionNotify.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxUseQuestionNotify.Name = "checkBoxUseQuestionNotify";
            this.checkBoxUseQuestionNotify.Size = new System.Drawing.Size(134, 19);
            this.checkBoxUseQuestionNotify.TabIndex = 1;
            this.checkBoxUseQuestionNotify.Text = "锁屏时做练习题";
            this.checkBoxUseQuestionNotify.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelStartTime);
            this.groupBox1.Controls.Add(this.dateTimePickerStartTime);
            this.groupBox1.Controls.Add(this.numericUpDownDuration);
            this.groupBox1.Controls.Add(this.labelDuration2);
            this.groupBox1.Controls.Add(this.labelDuration1);
            this.groupBox1.Controls.Add(this.numericUpDownTooLate);
            this.groupBox1.Controls.Add(this.rb_onehour);
            this.groupBox1.Controls.Add(this.labelTooLate2);
            this.groupBox1.Controls.Add(this.rb_twohour);
            this.groupBox1.Controls.Add(this.labelTooLate1);
            this.groupBox1.Controls.Add(this.dateTimePickerTooLate);
            this.groupBox1.Controls.Add(this.checkBoxTooLate);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(461, 215);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "锁屏方案";
            // 
            // rb_onehour
            // 
            this.rb_onehour.AutoSize = true;
            this.rb_onehour.Checked = true;
            this.rb_onehour.Location = new System.Drawing.Point(45, 25);
            this.rb_onehour.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb_onehour.Name = "rb_onehour";
            this.rb_onehour.Size = new System.Drawing.Size(111, 19);
            this.rb_onehour.TabIndex = 0;
            this.rb_onehour.TabStop = true;
            this.rb_onehour.Text = "周期为1小时";
            this.rb_onehour.UseVisualStyleBackColor = true;
            // 
            // rb_twohour
            // 
            this.rb_twohour.AutoSize = true;
            this.rb_twohour.Location = new System.Drawing.Point(45, 52);
            this.rb_twohour.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb_twohour.Name = "rb_twohour";
            this.rb_twohour.Size = new System.Drawing.Size(111, 19);
            this.rb_twohour.TabIndex = 1;
            this.rb_twohour.Text = "周期为2小时";
            this.rb_twohour.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(461, 4);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 29);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(349, 4);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 29);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // numericUpDownDuration
            // 
            this.numericUpDownDuration.Location = new System.Drawing.Point(120, 81);
            this.numericUpDownDuration.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownDuration.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.numericUpDownDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDuration.Name = "numericUpDownDuration";
            this.numericUpDownDuration.Size = new System.Drawing.Size(60, 25);
            this.numericUpDownDuration.TabIndex = 6;
            this.numericUpDownDuration.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // labelDuration2
            // 
            this.labelDuration2.AutoSize = true;
            this.labelDuration2.Location = new System.Drawing.Point(192, 87);
            this.labelDuration2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDuration2.Name = "labelDuration2";
            this.labelDuration2.Size = new System.Drawing.Size(37, 15);
            this.labelDuration2.TabIndex = 7;
            this.labelDuration2.Text = "分钟";
            // 
            // labelDuration1
            // 
            this.labelDuration1.AutoSize = true;
            this.labelDuration1.Location = new System.Drawing.Point(42, 87);
            this.labelDuration1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDuration1.Name = "labelDuration1";
            this.labelDuration1.Size = new System.Drawing.Size(67, 15);
            this.labelDuration1.TabIndex = 5;
            this.labelDuration1.Text = "锁屏时长";
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.CustomFormat = "HH:mm";
            this.dateTimePickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(146, 133);
            this.dateTimePickerStartTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.ShowUpDown = true;
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(83, 25);
            this.dateTimePickerStartTime.TabIndex = 8;
            this.dateTimePickerStartTime.Value = new System.DateTime(2017, 2, 15, 10, 0, 0, 0);
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.Location = new System.Drawing.Point(42, 140);
            this.labelStartTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(97, 15);
            this.labelStartTime.TabIndex = 9;
            this.labelStartTime.Text = "每天起始时间";
            // 
            // JobSettingForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(611, 362);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "JobSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时提醒";
            this.Load += new System.EventHandler(this.GridTradingSettingsForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTooLate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.NumericUpDown numericUpDownTooLate;
        private System.Windows.Forms.Label labelTooLate2;
        private System.Windows.Forms.Label labelTooLate1;
        private System.Windows.Forms.DateTimePicker dateTimePickerTooLate;
        private System.Windows.Forms.CheckBox checkBoxTooLate;
        private System.Windows.Forms.CheckBox checkBoxUseQuestionNotify;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_onehour;
        private System.Windows.Forms.RadioButton rb_twohour;
        private System.Windows.Forms.NumericUpDown numericUpDownDuration;
        private System.Windows.Forms.Label labelDuration2;
        private System.Windows.Forms.Label labelDuration1;
        private System.Windows.Forms.Label labelStartTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
    }
}