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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownTooLate = new System.Windows.Forms.NumericUpDown();
            this.labelTooLate2 = new System.Windows.Forms.Label();
            this.labelTooLate1 = new System.Windows.Forms.Label();
            this.dateTimePickerTooLate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxTooLate = new System.Windows.Forms.CheckBox();
            this.checkBoxUseQuestionNotify = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_ten = new System.Windows.Forms.RadioButton();
            this.rb_odd = new System.Windows.Forms.RadioButton();
            this.rb_even = new System.Windows.Forms.RadioButton();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTooLate)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxUseQuestionNotify);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonCancel);
            this.splitContainer1.Panel2.Controls.Add(this.buttonOK);
            this.splitContainer1.Size = new System.Drawing.Size(458, 290);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownTooLate);
            this.groupBox2.Controls.Add(this.labelTooLate2);
            this.groupBox2.Controls.Add(this.labelTooLate1);
            this.groupBox2.Controls.Add(this.dateTimePickerTooLate);
            this.groupBox2.Controls.Add(this.checkBoxTooLate);
            this.groupBox2.Location = new System.Drawing.Point(12, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 56);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "其它任务";
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
            120,
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
            this.dateTimePickerTooLate.Margin = new System.Windows.Forms.Padding(2);
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
            // checkBoxUseQuestionNotify
            // 
            this.checkBoxUseQuestionNotify.AutoSize = true;
            this.checkBoxUseQuestionNotify.Location = new System.Drawing.Point(12, 125);
            this.checkBoxUseQuestionNotify.Name = "checkBoxUseQuestionNotify";
            this.checkBoxUseQuestionNotify.Size = new System.Drawing.Size(108, 16);
            this.checkBoxUseQuestionNotify.TabIndex = 1;
            this.checkBoxUseQuestionNotify.Text = "锁屏时做练习题";
            this.checkBoxUseQuestionNotify.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_ten);
            this.groupBox1.Controls.Add(this.rb_odd);
            this.groupBox1.Controls.Add(this.rb_even);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "锁屏方案";
            // 
            // rb_ten
            // 
            this.rb_ten.AutoSize = true;
            this.rb_ten.Location = new System.Drawing.Point(34, 64);
            this.rb_ten.Name = "rb_ten";
            this.rb_ten.Size = new System.Drawing.Size(125, 16);
            this.rb_ten.TabIndex = 2;
            this.rb_ten.Text = "1小时内锁屏10分钟";
            this.rb_ten.UseVisualStyleBackColor = true;
            // 
            // rb_odd
            // 
            this.rb_odd.AutoSize = true;
            this.rb_odd.Checked = true;
            this.rb_odd.Location = new System.Drawing.Point(34, 20);
            this.rb_odd.Name = "rb_odd";
            this.rb_odd.Size = new System.Drawing.Size(149, 16);
            this.rb_odd.TabIndex = 0;
            this.rb_odd.TabStop = true;
            this.rb_odd.Text = "奇数小时开始锁屏1小时";
            this.rb_odd.UseVisualStyleBackColor = true;
            // 
            // rb_even
            // 
            this.rb_even.AutoSize = true;
            this.rb_even.Location = new System.Drawing.Point(34, 42);
            this.rb_even.Name = "rb_even";
            this.rb_even.Size = new System.Drawing.Size(149, 16);
            this.rb_even.TabIndex = 1;
            this.rb_even.Text = "偶数小时开始锁屏1小时";
            this.rb_even.UseVisualStyleBackColor = true;
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
            this.ClientSize = new System.Drawing.Size(458, 290);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "JobSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时提醒";
            this.Load += new System.EventHandler(this.TaskSettingsForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTooLate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDownTooLate;
        private System.Windows.Forms.Label labelTooLate2;
        private System.Windows.Forms.Label labelTooLate1;
        private System.Windows.Forms.DateTimePicker dateTimePickerTooLate;
        private System.Windows.Forms.CheckBox checkBoxTooLate;
        private System.Windows.Forms.CheckBox checkBoxUseQuestionNotify;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_ten;
        private System.Windows.Forms.RadioButton rb_odd;
        private System.Windows.Forms.RadioButton rb_even;
    }
}