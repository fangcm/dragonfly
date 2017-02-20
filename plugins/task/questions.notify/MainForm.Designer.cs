namespace Dragonfly.Questions.Notify
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelExam = new System.Windows.Forms.Panel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerExam = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.labelQuestionNo = new System.Windows.Forms.Label();
            this.flp_options = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelReadingTitle = new System.Windows.Forms.Label();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_previous = new System.Windows.Forms.Button();
            this.btn_finish = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btn_start_exam = new System.Windows.Forms.Button();
            this.panelStart = new System.Windows.Forms.Panel();
            this.label_tip = new System.Windows.Forms.Label();
            this.label_clock = new System.Windows.Forms.Label();
            this.txt_reading = new Dragonfly.Questions.Notify.RichTextBoxEx();
            this.txt_question = new Dragonfly.Questions.Notify.RichTextBoxEx();
            this.panelExam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExam)).BeginInit();
            this.splitContainerExam.Panel1.SuspendLayout();
            this.splitContainerExam.Panel2.SuspendLayout();
            this.splitContainerExam.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelExam
            // 
            this.panelExam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExam.BackColor = System.Drawing.SystemColors.Info;
            this.panelExam.Controls.Add(this.splitContainerMain);
            this.panelExam.Controls.Add(this.label1);
            this.panelExam.Controls.Add(this.labelReadingTitle);
            this.panelExam.ForeColor = System.Drawing.SystemColors.InfoText;
            this.panelExam.Location = new System.Drawing.Point(17, 13);
            this.panelExam.Name = "panelExam";
            this.panelExam.Size = new System.Drawing.Size(818, 473);
            this.panelExam.TabIndex = 0;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerMain.ForeColor = System.Drawing.SystemColors.InfoText;
            this.splitContainerMain.Location = new System.Drawing.Point(3, 47);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.txt_reading);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerExam);
            this.splitContainerMain.Size = new System.Drawing.Size(812, 423);
            this.splitContainerMain.SplitterDistance = 482;
            this.splitContainerMain.TabIndex = 5;
            // 
            // splitContainerExam
            // 
            this.splitContainerExam.BackColor = System.Drawing.SystemColors.Info;
            this.splitContainerExam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerExam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerExam.ForeColor = System.Drawing.SystemColors.InfoText;
            this.splitContainerExam.Location = new System.Drawing.Point(0, 0);
            this.splitContainerExam.Name = "splitContainerExam";
            this.splitContainerExam.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerExam.Panel1
            // 
            this.splitContainerExam.Panel1.Controls.Add(this.label2);
            this.splitContainerExam.Panel1.Controls.Add(this.labelQuestionNo);
            this.splitContainerExam.Panel1.Controls.Add(this.txt_question);
            // 
            // splitContainerExam.Panel2
            // 
            this.splitContainerExam.Panel2.Controls.Add(this.flp_options);
            this.splitContainerExam.Size = new System.Drawing.Size(326, 423);
            this.splitContainerExam.SplitterDistance = 270;
            this.splitContainerExam.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Question:";
            // 
            // labelQuestionNo
            // 
            this.labelQuestionNo.AutoSize = true;
            this.labelQuestionNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelQuestionNo.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelQuestionNo.Location = new System.Drawing.Point(77, 12);
            this.labelQuestionNo.Name = "labelQuestionNo";
            this.labelQuestionNo.Size = new System.Drawing.Size(17, 16);
            this.labelQuestionNo.TabIndex = 1;
            this.labelQuestionNo.Text = "1";
            // 
            // flp_options
            // 
            this.flp_options.BackColor = System.Drawing.SystemColors.Info;
            this.flp_options.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_options.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_options.Font = new System.Drawing.Font("宋体", 14F);
            this.flp_options.ForeColor = System.Drawing.SystemColors.InfoText;
            this.flp_options.Location = new System.Drawing.Point(0, 0);
            this.flp_options.Name = "flp_options";
            this.flp_options.Size = new System.Drawing.Size(324, 147);
            this.flp_options.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(19, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reading title:";
            // 
            // labelReadingTitle
            // 
            this.labelReadingTitle.AutoSize = true;
            this.labelReadingTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelReadingTitle.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelReadingTitle.Location = new System.Drawing.Point(125, 9);
            this.labelReadingTitle.Name = "labelReadingTitle";
            this.labelReadingTitle.Size = new System.Drawing.Size(53, 16);
            this.labelReadingTitle.TabIndex = 1;
            this.labelReadingTitle.Text = "Title";
            // 
            // btn_next
            // 
            this.btn_next.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_next.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_next.Location = new System.Drawing.Point(212, 502);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(74, 21);
            this.btn_next.TabIndex = 2;
            this.btn_next.Text = "Next";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_previous
            // 
            this.btn_previous.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_previous.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_previous.Location = new System.Drawing.Point(113, 502);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(74, 21);
            this.btn_previous.TabIndex = 1;
            this.btn_previous.Text = "Previous";
            this.btn_previous.UseVisualStyleBackColor = true;
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            // 
            // btn_finish
            // 
            this.btn_finish.AccessibleDescription = "";
            this.btn_finish.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_finish.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_finish.Location = new System.Drawing.Point(311, 502);
            this.btn_finish.Name = "btn_finish";
            this.btn_finish.Size = new System.Drawing.Size(74, 21);
            this.btn_finish.TabIndex = 3;
            this.btn_finish.Text = "Finish";
            this.btn_finish.UseVisualStyleBackColor = true;
            this.btn_finish.Click += new System.EventHandler(this.btn_finish_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelExam);
            this.panelMain.Controls.Add(this.btn_finish);
            this.panelMain.Controls.Add(this.btn_previous);
            this.panelMain.Controls.Add(this.btn_next);
            this.panelMain.Location = new System.Drawing.Point(55, 12);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(869, 544);
            this.panelMain.TabIndex = 4;
            // 
            // btn_start_exam
            // 
            this.btn_start_exam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_start_exam.Location = new System.Drawing.Point(140, 220);
            this.btn_start_exam.Name = "btn_start_exam";
            this.btn_start_exam.Size = new System.Drawing.Size(120, 25);
            this.btn_start_exam.TabIndex = 5;
            this.btn_start_exam.Text = "start exam";
            this.btn_start_exam.UseVisualStyleBackColor = true;
            this.btn_start_exam.Click += new System.EventHandler(this.btn_start_exam_Click);
            // 
            // panelStart
            // 
            this.panelStart.Controls.Add(this.label_tip);
            this.panelStart.Controls.Add(this.btn_start_exam);
            this.panelStart.Location = new System.Drawing.Point(29, 45);
            this.panelStart.Name = "panelStart";
            this.panelStart.Size = new System.Drawing.Size(400, 400);
            this.panelStart.TabIndex = 6;
            // 
            // label_tip
            // 
            this.label_tip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_tip.AutoSize = true;
            this.label_tip.Location = new System.Drawing.Point(185, 154);
            this.label_tip.Name = "label_tip";
            this.label_tip.Size = new System.Drawing.Size(23, 12);
            this.label_tip.TabIndex = 6;
            this.label_tip.Text = "tip";
            // 
            // label_clock
            // 
            this.label_clock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_clock.AutoSize = true;
            this.label_clock.Location = new System.Drawing.Point(754, 524);
            this.label_clock.Name = "label_clock";
            this.label_clock.Size = new System.Drawing.Size(41, 12);
            this.label_clock.TabIndex = 7;
            this.label_clock.Text = "label3";
            // 
            // txt_reading
            // 
            this.txt_reading.BackColor = System.Drawing.SystemColors.Info;
            this.txt_reading.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_reading.DetectUrls = false;
            this.txt_reading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_reading.Font = new System.Drawing.Font("宋体", 14F);
            this.txt_reading.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txt_reading.Location = new System.Drawing.Point(0, 0);
            this.txt_reading.Name = "txt_reading";
            this.txt_reading.ReadOnly = true;
            this.txt_reading.Size = new System.Drawing.Size(480, 421);
            this.txt_reading.TabIndex = 0;
            this.txt_reading.Text = "";
            // 
            // txt_question
            // 
            this.txt_question.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_question.BackColor = System.Drawing.SystemColors.Info;
            this.txt_question.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_question.Font = new System.Drawing.Font("宋体", 14F);
            this.txt_question.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txt_question.Location = new System.Drawing.Point(3, 48);
            this.txt_question.Name = "txt_question";
            this.txt_question.ReadOnly = true;
            this.txt_question.Size = new System.Drawing.Size(319, 218);
            this.txt_question.TabIndex = 2;
            this.txt_question.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(854, 545);
            this.Controls.Add(this.label_clock);
            this.Controls.Add(this.panelStart);
            this.Controls.Add(this.panelMain);
            this.Name = "MainForm";
            this.panelExam.ResumeLayout(false);
            this.panelExam.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerExam.Panel1.ResumeLayout(false);
            this.splitContainerExam.Panel1.PerformLayout();
            this.splitContainerExam.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExam)).EndInit();
            this.splitContainerExam.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelStart.ResumeLayout(false);
            this.panelStart.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelExam;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_previous;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelReadingTitle;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerExam;
        private System.Windows.Forms.FlowLayoutPanel flp_options;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelQuestionNo;
        private RichTextBoxEx txt_reading;
        private RichTextBoxEx txt_question;
        private System.Windows.Forms.Button btn_finish;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btn_start_exam;
        private System.Windows.Forms.Panel panelStart;
        private System.Windows.Forms.Label label_tip;
        private System.Windows.Forms.Label label_clock;
    }
}

