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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelExam = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelReadingTitle = new System.Windows.Forms.Label();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.txt_reading = new Dragonfly.Questions.RichTextBoxEx();
            this.splitContainerExam = new System.Windows.Forms.SplitContainer();
            this.txt_question = new Dragonfly.Questions.RichTextBoxEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelQuestionNo = new System.Windows.Forms.Label();
            this.flp_options = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_next = new System.Windows.Forms.Button();
            this.imageListBtn = new System.Windows.Forms.ImageList(this.components);
            this.btn_previous = new System.Windows.Forms.Button();
            this.btn_change = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btn_start_exam = new System.Windows.Forms.Button();
            this.panelStart = new System.Windows.Forms.Panel();
            this.label_tip = new System.Windows.Forms.Label();
            this.label_clock = new System.Windows.Forms.Label();
            this.panelExam.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExam)).BeginInit();
            this.splitContainerExam.Panel1.SuspendLayout();
            this.splitContainerExam.Panel2.SuspendLayout();
            this.splitContainerExam.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelExam
            // 
            this.panelExam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExam.BackColor = System.Drawing.Color.Gray;
            this.panelExam.Controls.Add(this.panel1);
            this.panelExam.Controls.Add(this.splitContainerMain);
            this.panelExam.ForeColor = System.Drawing.SystemColors.InfoText;
            this.panelExam.Location = new System.Drawing.Point(23, 16);
            this.panelExam.Margin = new System.Windows.Forms.Padding(4);
            this.panelExam.Name = "panelExam";
            this.panelExam.Size = new System.Drawing.Size(964, 522);
            this.panelExam.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(17)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelReadingTitle);
            this.panel1.Location = new System.Drawing.Point(5, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 50);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reading title:";
            // 
            // labelReadingTitle
            // 
            this.labelReadingTitle.AutoSize = true;
            this.labelReadingTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelReadingTitle.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labelReadingTitle.Location = new System.Drawing.Point(155, 16);
            this.labelReadingTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelReadingTitle.Name = "labelReadingTitle";
            this.labelReadingTitle.Size = new System.Drawing.Size(387, 20);
            this.labelReadingTitle.TabIndex = 1;
            this.labelReadingTitle.Text = "已经完成了全部的题目了，需要更新题库";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.BackColor = System.Drawing.Color.DimGray;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerMain.ForeColor = System.Drawing.SystemColors.InfoText;
            this.splitContainerMain.Location = new System.Drawing.Point(4, 59);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.txt_reading);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerExam);
            this.splitContainerMain.Panel2MinSize = 125;
            this.splitContainerMain.Size = new System.Drawing.Size(956, 460);
            this.splitContainerMain.SplitterDistance = 543;
            this.splitContainerMain.SplitterWidth = 5;
            this.splitContainerMain.TabIndex = 5;
            // 
            // txt_reading
            // 
            this.txt_reading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(17)))));
            this.txt_reading.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_reading.DetectUrls = false;
            this.txt_reading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_reading.Font = new System.Drawing.Font("宋体", 14F);
            this.txt_reading.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txt_reading.Location = new System.Drawing.Point(0, 0);
            this.txt_reading.Margin = new System.Windows.Forms.Padding(0);
            this.txt_reading.Name = "txt_reading";
            this.txt_reading.ReadOnly = true;
            this.txt_reading.Size = new System.Drawing.Size(543, 460);
            this.txt_reading.TabIndex = 0;
            this.txt_reading.Text = "";
            // 
            // splitContainerExam
            // 
            this.splitContainerExam.BackColor = System.Drawing.Color.DimGray;
            this.splitContainerExam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerExam.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerExam.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.splitContainerExam.Location = new System.Drawing.Point(0, 0);
            this.splitContainerExam.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerExam.Name = "splitContainerExam";
            this.splitContainerExam.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerExam.Panel1
            // 
            this.splitContainerExam.Panel1.BackColor = System.Drawing.Color.DimGray;
            this.splitContainerExam.Panel1.Controls.Add(this.txt_question);
            this.splitContainerExam.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainerExam.Panel2
            // 
            this.splitContainerExam.Panel2.Controls.Add(this.flp_options);
            this.splitContainerExam.Panel2MinSize = 80;
            this.splitContainerExam.Size = new System.Drawing.Size(408, 460);
            this.splitContainerExam.SplitterDistance = 154;
            this.splitContainerExam.SplitterWidth = 5;
            this.splitContainerExam.TabIndex = 0;
            // 
            // txt_question
            // 
            this.txt_question.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(17)))));
            this.txt_question.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_question.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_question.Font = new System.Drawing.Font("宋体", 14F);
            this.txt_question.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txt_question.Location = new System.Drawing.Point(0, 50);
            this.txt_question.Margin = new System.Windows.Forms.Padding(4);
            this.txt_question.Name = "txt_question";
            this.txt_question.ReadOnly = true;
            this.txt_question.Size = new System.Drawing.Size(408, 104);
            this.txt_question.TabIndex = 2;
            this.txt_question.Text = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(17)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.labelQuestionNo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(408, 50);
            this.panel2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(4, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Question:";
            // 
            // labelQuestionNo
            // 
            this.labelQuestionNo.AutoSize = true;
            this.labelQuestionNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelQuestionNo.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labelQuestionNo.Location = new System.Drawing.Point(101, 14);
            this.labelQuestionNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQuestionNo.Name = "labelQuestionNo";
            this.labelQuestionNo.Size = new System.Drawing.Size(20, 20);
            this.labelQuestionNo.TabIndex = 1;
            this.labelQuestionNo.Text = "0";
            // 
            // flp_options
            // 
            this.flp_options.AutoScroll = true;
            this.flp_options.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(17)))));
            this.flp_options.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_options.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_options.Font = new System.Drawing.Font("宋体", 14F);
            this.flp_options.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.flp_options.Location = new System.Drawing.Point(0, 0);
            this.flp_options.Margin = new System.Windows.Forms.Padding(4);
            this.flp_options.Name = "flp_options";
            this.flp_options.Size = new System.Drawing.Size(408, 301);
            this.flp_options.TabIndex = 0;
            // 
            // btn_next
            // 
            this.btn_next.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_next.BackColor = System.Drawing.Color.White;
            this.btn_next.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepPink;
            this.btn_next.FlatAppearance.MouseOverBackColor = System.Drawing.Color.HotPink;
            this.btn_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_next.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_next.ImageKey = "right.ico";
            this.btn_next.ImageList = this.imageListBtn;
            this.btn_next.Location = new System.Drawing.Point(521, 546);
            this.btn_next.Margin = new System.Windows.Forms.Padding(4);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(110, 40);
            this.btn_next.TabIndex = 2;
            this.btn_next.Text = "Next";
            this.btn_next.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_next.UseVisualStyleBackColor = false;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // imageListBtn
            // 
            this.imageListBtn.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBtn.ImageStream")));
            this.imageListBtn.TransparentColor = System.Drawing.Color.White;
            this.imageListBtn.Images.SetKeyName(0, "left.ico");
            this.imageListBtn.Images.SetKeyName(1, "right.ico");
            this.imageListBtn.Images.SetKeyName(2, "finish.ico");
            this.imageListBtn.Images.SetKeyName(3, "play.ico");
            // 
            // btn_previous
            // 
            this.btn_previous.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_previous.BackColor = System.Drawing.Color.White;
            this.btn_previous.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepPink;
            this.btn_previous.FlatAppearance.MouseOverBackColor = System.Drawing.Color.HotPink;
            this.btn_previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_previous.ImageKey = "left.ico";
            this.btn_previous.ImageList = this.imageListBtn;
            this.btn_previous.Location = new System.Drawing.Point(377, 546);
            this.btn_previous.Margin = new System.Windows.Forms.Padding(4);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(110, 40);
            this.btn_previous.TabIndex = 1;
            this.btn_previous.Text = "Previous";
            this.btn_previous.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_previous.UseVisualStyleBackColor = false;
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            // 
            // btn_change
            // 
            this.btn_change.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_change.BackColor = System.Drawing.Color.White;
            this.btn_change.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepPink;
            this.btn_change.FlatAppearance.MouseOverBackColor = System.Drawing.Color.HotPink;
            this.btn_change.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_change.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_change.ImageKey = "finish.ico";
            this.btn_change.ImageList = this.imageListBtn;
            this.btn_change.Location = new System.Drawing.Point(86, 546);
            this.btn_change.Margin = new System.Windows.Forms.Padding(4);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(110, 40);
            this.btn_change.TabIndex = 3;
            this.btn_change.Text = "Change";
            this.btn_change.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_change.UseVisualStyleBackColor = false;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(17)))));
            this.panelMain.Controls.Add(this.panelExam);
            this.panelMain.Controls.Add(this.btn_change);
            this.panelMain.Controls.Add(this.btn_previous);
            this.panelMain.Controls.Add(this.btn_next);
            this.panelMain.Location = new System.Drawing.Point(73, 15);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1032, 611);
            this.panelMain.TabIndex = 4;
            // 
            // btn_start_exam
            // 
            this.btn_start_exam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_start_exam.BackColor = System.Drawing.Color.White;
            this.btn_start_exam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepPink;
            this.btn_start_exam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.HotPink;
            this.btn_start_exam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_start_exam.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_start_exam.ImageKey = "play.ico";
            this.btn_start_exam.ImageList = this.imageListBtn;
            this.btn_start_exam.Location = new System.Drawing.Point(187, 275);
            this.btn_start_exam.Margin = new System.Windows.Forms.Padding(4);
            this.btn_start_exam.Name = "btn_start_exam";
            this.btn_start_exam.Size = new System.Drawing.Size(160, 40);
            this.btn_start_exam.TabIndex = 5;
            this.btn_start_exam.Text = "start exam";
            this.btn_start_exam.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_start_exam.UseVisualStyleBackColor = false;
            this.btn_start_exam.Click += new System.EventHandler(this.btn_start_exam_Click);
            // 
            // panelStart
            // 
            this.panelStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(17)))));
            this.panelStart.Controls.Add(this.label_tip);
            this.panelStart.Controls.Add(this.btn_start_exam);
            this.panelStart.Location = new System.Drawing.Point(27, 48);
            this.panelStart.Margin = new System.Windows.Forms.Padding(4);
            this.panelStart.Name = "panelStart";
            this.panelStart.Size = new System.Drawing.Size(533, 500);
            this.panelStart.TabIndex = 6;
            // 
            // label_tip
            // 
            this.label_tip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_tip.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_tip.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label_tip.Location = new System.Drawing.Point(0, 192);
            this.label_tip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_tip.Name = "label_tip";
            this.label_tip.Size = new System.Drawing.Size(533, 30);
            this.label_tip.TabIndex = 6;
            this.label_tip.Text = "tip";
            this.label_tip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_clock
            // 
            this.label_clock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_clock.AutoSize = true;
            this.label_clock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(17)))));
            this.label_clock.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label_clock.Location = new System.Drawing.Point(1017, 640);
            this.label_clock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_clock.Name = "label_clock";
            this.label_clock.Size = new System.Drawing.Size(55, 15);
            this.label_clock.TabIndex = 7;
            this.label_clock.Text = "label3";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(1139, 681);
            this.Controls.Add(this.label_clock);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelStart);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.panelExam.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerExam.Panel1.ResumeLayout(false);
            this.splitContainerExam.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExam)).EndInit();
            this.splitContainerExam.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelStart.ResumeLayout(false);
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
        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btn_start_exam;
        private System.Windows.Forms.Panel panelStart;
        private System.Windows.Forms.Label label_tip;
        private System.Windows.Forms.Label label_clock;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imageListBtn;
    }
}

