namespace Dragonfly.Plugin.Task
{
    partial class AdjustmentConditionForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.num_seconds = new System.Windows.Forms.NumericUpDown();
            this.labelMinute = new System.Windows.Forms.Label();
            this.labelInterval = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_conditonValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rb_processname = new System.Windows.Forms.RadioButton();
            this.rb_filename = new System.Windows.Forms.RadioButton();
            this.rb_title = new System.Windows.Forms.RadioButton();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_AccumulatedDec = new System.Windows.Forms.RadioButton();
            this.rb_AccumulatedDelay = new System.Windows.Forms.RadioButton();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_seconds)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.num_seconds);
            this.groupBox3.Controls.Add(this.labelMinute);
            this.groupBox3.Controls.Add(this.labelInterval);
            this.groupBox3.Location = new System.Drawing.Point(21, 239);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(298, 56);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // num_seconds
            // 
            this.num_seconds.Location = new System.Drawing.Point(80, 21);
            this.num_seconds.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.num_seconds.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.num_seconds.Name = "num_seconds";
            this.num_seconds.Size = new System.Drawing.Size(54, 21);
            this.num_seconds.TabIndex = 1;
            this.num_seconds.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // labelMinute
            // 
            this.labelMinute.AutoSize = true;
            this.labelMinute.Location = new System.Drawing.Point(153, 24);
            this.labelMinute.Name = "labelMinute";
            this.labelMinute.Size = new System.Drawing.Size(17, 12);
            this.labelMinute.TabIndex = 2;
            this.labelMinute.Text = "秒";
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(6, 24);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(65, 12);
            this.labelInterval.TabIndex = 0;
            this.labelInterval.Text = "调节时间：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_conditonValue);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.rb_processname);
            this.groupBox2.Controls.Add(this.rb_filename);
            this.groupBox2.Controls.Add(this.rb_title);
            this.groupBox2.Location = new System.Drawing.Point(21, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 91);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "判断条件";
            // 
            // txt_conditonValue
            // 
            this.txt_conditonValue.Location = new System.Drawing.Point(80, 55);
            this.txt_conditonValue.Name = "txt_conditonValue";
            this.txt_conditonValue.Size = new System.Drawing.Size(194, 21);
            this.txt_conditonValue.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "条件值：";
            // 
            // rb_processname
            // 
            this.rb_processname.AutoSize = true;
            this.rb_processname.Checked = true;
            this.rb_processname.Location = new System.Drawing.Point(181, 21);
            this.rb_processname.Name = "rb_processname";
            this.rb_processname.Size = new System.Drawing.Size(71, 16);
            this.rb_processname.TabIndex = 2;
            this.rb_processname.TabStop = true;
            this.rb_processname.Text = "进程名称";
            this.rb_processname.UseVisualStyleBackColor = true;
            // 
            // rb_filename
            // 
            this.rb_filename.AutoSize = true;
            this.rb_filename.Location = new System.Drawing.Point(6, 21);
            this.rb_filename.Name = "rb_filename";
            this.rb_filename.Size = new System.Drawing.Size(59, 16);
            this.rb_filename.TabIndex = 0;
            this.rb_filename.Text = "文件名";
            this.rb_filename.UseVisualStyleBackColor = true;
            // 
            // rb_title
            // 
            this.rb_title.AutoSize = true;
            this.rb_title.Location = new System.Drawing.Point(91, 21);
            this.rb_title.Name = "rb_title";
            this.rb_title.Size = new System.Drawing.Size(71, 16);
            this.rb_title.TabIndex = 1;
            this.rb_title.Text = "窗口标题";
            this.rb_title.UseVisualStyleBackColor = true;
            // 
            // txt_title
            // 
            this.txt_title.Location = new System.Drawing.Point(64, 21);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(221, 21);
            this.txt_title.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(19, 23);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(41, 12);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "说明：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_AccumulatedDec);
            this.groupBox1.Controls.Add(this.rb_AccumulatedDelay);
            this.groupBox1.Location = new System.Drawing.Point(21, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 47);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "调节方向";
            // 
            // rb_AccumulatedDec
            // 
            this.rb_AccumulatedDec.AutoSize = true;
            this.rb_AccumulatedDec.Checked = true;
            this.rb_AccumulatedDec.Location = new System.Drawing.Point(174, 21);
            this.rb_AccumulatedDec.Name = "rb_AccumulatedDec";
            this.rb_AccumulatedDec.Size = new System.Drawing.Size(95, 16);
            this.rb_AccumulatedDec.TabIndex = 1;
            this.rb_AccumulatedDec.TabStop = true;
            this.rb_AccumulatedDec.Text = "持续递减调节";
            this.rb_AccumulatedDec.UseVisualStyleBackColor = true;
            // 
            // rb_AccumulatedDelay
            // 
            this.rb_AccumulatedDelay.AutoSize = true;
            this.rb_AccumulatedDelay.Location = new System.Drawing.Point(38, 21);
            this.rb_AccumulatedDelay.Name = "rb_AccumulatedDelay";
            this.rb_AccumulatedDelay.Size = new System.Drawing.Size(107, 16);
            this.rb_AccumulatedDelay.TabIndex = 0;
            this.rb_AccumulatedDelay.TabStop = true;
            this.rb_AccumulatedDelay.Text = "触发锁屏时延时";
            this.rb_AccumulatedDelay.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(244, 318);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(160, 318);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // AdjustmentConditionForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(346, 366);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AdjustmentConditionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "调节项";
            this.Load += new System.EventHandler(this.AdjustmentConditionForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_seconds)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.NumericUpDown num_seconds;
        private System.Windows.Forms.Label labelMinute;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_processname;
        private System.Windows.Forms.RadioButton rb_filename;
        private System.Windows.Forms.RadioButton rb_title;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_AccumulatedDec;
        private System.Windows.Forms.RadioButton rb_AccumulatedDelay;
        private System.Windows.Forms.TextBox txt_conditonValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
    }
}