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
            this.txt_reading = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.labelQuestionNo = new System.Windows.Forms.Label();
            this.txt_question = new System.Windows.Forms.RichTextBox();
            this.flp_options = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelReadingTitle = new System.Windows.Forms.Label();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_previous = new System.Windows.Forms.Button();
            this.panelExam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelExam
            // 
            this.panelExam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExam.Controls.Add(this.splitContainerMain);
            this.panelExam.Controls.Add(this.label1);
            this.panelExam.Controls.Add(this.labelReadingTitle);
            this.panelExam.Location = new System.Drawing.Point(12, 12);
            this.panelExam.Name = "panelExam";
            this.panelExam.Size = new System.Drawing.Size(818, 473);
            this.panelExam.TabIndex = 0;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.Location = new System.Drawing.Point(3, 47);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.txt_reading);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainerMain.Size = new System.Drawing.Size(810, 421);
            this.splitContainerMain.SplitterDistance = 400;
            this.splitContainerMain.TabIndex = 5;
            // 
            // txt_reading
            // 
            this.txt_reading.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txt_reading.DetectUrls = false;
            this.txt_reading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_reading.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_reading.Location = new System.Drawing.Point(0, 0);
            this.txt_reading.Name = "txt_reading";
            this.txt_reading.ReadOnly = true;
            this.txt_reading.Size = new System.Drawing.Size(400, 421);
            this.txt_reading.TabIndex = 0;
            this.txt_reading.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.labelQuestionNo);
            this.splitContainer1.Panel1.Controls.Add(this.txt_question);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flp_options);
            this.splitContainer1.Size = new System.Drawing.Size(406, 421);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
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
            this.labelQuestionNo.Location = new System.Drawing.Point(77, 12);
            this.labelQuestionNo.Name = "labelQuestionNo";
            this.labelQuestionNo.Size = new System.Drawing.Size(17, 16);
            this.labelQuestionNo.TabIndex = 1;
            this.labelQuestionNo.Text = "1";
            // 
            // txt_question
            // 
            this.txt_question.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_question.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txt_question.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_question.Location = new System.Drawing.Point(3, 48);
            this.txt_question.Name = "txt_question";
            this.txt_question.ReadOnly = true;
            this.txt_question.Size = new System.Drawing.Size(400, 160);
            this.txt_question.TabIndex = 2;
            this.txt_question.Text = "";
            // 
            // flp_options
            // 
            this.flp_options.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flp_options.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flp_options.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_options.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_options.Location = new System.Drawing.Point(0, 0);
            this.flp_options.Name = "flp_options";
            this.flp_options.Size = new System.Drawing.Size(406, 207);
            this.flp_options.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
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
            this.labelReadingTitle.Location = new System.Drawing.Point(125, 9);
            this.labelReadingTitle.Name = "labelReadingTitle";
            this.labelReadingTitle.Size = new System.Drawing.Size(53, 16);
            this.labelReadingTitle.TabIndex = 1;
            this.labelReadingTitle.Text = "Title";
            // 
            // btn_next
            // 
            this.btn_next.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_next.Location = new System.Drawing.Point(189, 491);
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
            this.btn_previous.Location = new System.Drawing.Point(109, 491);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(74, 21);
            this.btn_previous.TabIndex = 1;
            this.btn_previous.Text = "Previous";
            this.btn_previous.UseVisualStyleBackColor = true;
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 545);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_previous);
            this.Controls.Add(this.panelExam);
            this.Name = "MainForm";
            this.panelExam.ResumeLayout(false);
            this.panelExam.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelExam;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_previous;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelReadingTitle;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flp_options;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelQuestionNo;
        private System.Windows.Forms.RichTextBox txt_reading;
        private System.Windows.Forms.RichTextBox txt_question;
    }
}

