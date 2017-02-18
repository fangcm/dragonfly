namespace Dragonfly.Questions
{
    partial class MockExamPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.txt_question = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelTitle = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelReadingTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelButton = new System.Windows.Forms.TableLayoutPanel();
            this.btn_previous = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.flowLayoutPanelOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelTitle.SuspendLayout();
            this.tableLayoutPanelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.txt_question, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelTitle, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelButton, 0, 3);
            this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanelOptions, 0, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 5;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(805, 498);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // txt_question
            // 
            this.txt_question.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_question.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_question.Location = new System.Drawing.Point(3, 33);
            this.txt_question.Multiline = true;
            this.txt_question.Name = "txt_question";
            this.txt_question.ReadOnly = true;
            this.txt_question.Size = new System.Drawing.Size(799, 302);
            this.txt_question.TabIndex = 2;
            // 
            // tableLayoutPanelTitle
            // 
            this.tableLayoutPanelTitle.ColumnCount = 2;
            this.tableLayoutPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTitle.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelTitle.Controls.Add(this.labelReadingTitle, 1, 0);
            this.tableLayoutPanelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTitle.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelTitle.Name = "tableLayoutPanelTitle";
            this.tableLayoutPanelTitle.RowCount = 1;
            this.tableLayoutPanelTitle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTitle.Size = new System.Drawing.Size(799, 24);
            this.tableLayoutPanelTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title:";
            // 
            // labelReadingTitle
            // 
            this.labelReadingTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelReadingTitle.AutoSize = true;
            this.labelReadingTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelReadingTitle.Location = new System.Drawing.Point(63, 8);
            this.labelReadingTitle.Name = "labelReadingTitle";
            this.labelReadingTitle.Size = new System.Drawing.Size(56, 16);
            this.labelReadingTitle.TabIndex = 0;
            this.labelReadingTitle.Text = "label2";
            // 
            // tableLayoutPanelButton
            // 
            this.tableLayoutPanelButton.ColumnCount = 3;
            this.tableLayoutPanelButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelButton.Controls.Add(this.btn_next, 1, 0);
            this.tableLayoutPanelButton.Controls.Add(this.btn_previous, 0, 0);
            this.tableLayoutPanelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelButton.Location = new System.Drawing.Point(3, 421);
            this.tableLayoutPanelButton.Name = "tableLayoutPanelButton";
            this.tableLayoutPanelButton.RowCount = 1;
            this.tableLayoutPanelButton.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelButton.Size = new System.Drawing.Size(799, 34);
            this.tableLayoutPanelButton.TabIndex = 0;
            // 
            // btn_previous
            // 
            this.btn_previous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_previous.Enabled = false;
            this.btn_previous.Location = new System.Drawing.Point(3, 10);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(74, 21);
            this.btn_previous.TabIndex = 0;
            this.btn_previous.Text = "Previous";
            this.btn_previous.UseVisualStyleBackColor = true;
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            // 
            // btn_next
            // 
            this.btn_next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_next.Enabled = false;
            this.btn_next.Location = new System.Drawing.Point(83, 10);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(74, 21);
            this.btn_next.TabIndex = 1;
            this.btn_next.Text = "Next";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // flowLayoutPanelOptions
            // 
            this.flowLayoutPanelOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelOptions.Location = new System.Drawing.Point(3, 341);
            this.flowLayoutPanelOptions.Name = "flowLayoutPanelOptions";
            this.flowLayoutPanelOptions.Size = new System.Drawing.Size(799, 74);
            this.flowLayoutPanelOptions.TabIndex = 3;
            // 
            // MockExamPanel
            // 
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "MockExamPanel";
            this.Size = new System.Drawing.Size(805, 498);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.tableLayoutPanelTitle.ResumeLayout(false);
            this.tableLayoutPanelTitle.PerformLayout();
            this.tableLayoutPanelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelReadingTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButton;
        private System.Windows.Forms.Button btn_previous;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.TextBox txt_question;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOptions;
    }
}
