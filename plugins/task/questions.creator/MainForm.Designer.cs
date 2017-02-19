namespace Dragonfly.Questions.Creator
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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.treeViewExam = new System.Windows.Forms.TreeView();
            this.imglstTreeNode = new System.Windows.Forms.ImageList(this.components);
            this.panel_exam = new System.Windows.Forms.Panel();
            this.btn_save_properties = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.num_exam_passmark = new System.Windows.Forms.NumericUpDown();
            this.txt_exam_title = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelReading = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_reading_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_reading_title = new System.Windows.Forms.TextBox();
            this.panel_question = new System.Windows.Forms.Panel();
            this.txt_question_text = new System.Windows.Forms.TextBox();
            this.lbl_reading_question = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkMulipleChoice = new System.Windows.Forms.CheckBox();
            this.panel_question_options = new System.Windows.Forms.Panel();
            this.btn_remove_option = new System.Windows.Forms.Button();
            this.btn_add_options = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addReadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delReadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.addQuestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delQuestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogExam = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogExam = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.panel_exam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_exam_passmark)).BeginInit();
            this.panelReading.SuspendLayout();
            this.panel_question.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 25);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.treeViewExam);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.panel_exam);
            this.splitContainerMain.Size = new System.Drawing.Size(805, 497);
            this.splitContainerMain.SplitterDistance = 228;
            this.splitContainerMain.TabIndex = 0;
            // 
            // treeViewExam
            // 
            this.treeViewExam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewExam.ImageIndex = 0;
            this.treeViewExam.ImageList = this.imglstTreeNode;
            this.treeViewExam.Location = new System.Drawing.Point(0, 0);
            this.treeViewExam.Name = "treeViewExam";
            this.treeViewExam.SelectedImageIndex = 0;
            this.treeViewExam.Size = new System.Drawing.Size(228, 497);
            this.treeViewExam.TabIndex = 0;
            this.treeViewExam.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewExam_BeforeSelect);
            this.treeViewExam.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewExam_AfterSelect);
            // 
            // imglstTreeNode
            // 
            this.imglstTreeNode.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstTreeNode.ImageStream")));
            this.imglstTreeNode.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstTreeNode.Images.SetKeyName(0, "Exam.png");
            this.imglstTreeNode.Images.SetKeyName(1, "New_Section.png");
            this.imglstTreeNode.Images.SetKeyName(2, "New_Question.png");
            // 
            // panel_exam
            // 
            this.panel_exam.Controls.Add(this.btn_save_properties);
            this.panel_exam.Controls.Add(this.label9);
            this.panel_exam.Controls.Add(this.num_exam_passmark);
            this.panel_exam.Controls.Add(this.txt_exam_title);
            this.panel_exam.Controls.Add(this.label5);
            this.panel_exam.Controls.Add(this.label2);
            this.panel_exam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_exam.Location = new System.Drawing.Point(0, 0);
            this.panel_exam.Name = "panel_exam";
            this.panel_exam.Size = new System.Drawing.Size(573, 497);
            this.panel_exam.TabIndex = 3;
            // 
            // btn_save_properties
            // 
            this.btn_save_properties.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_save_properties.Location = new System.Drawing.Point(197, 142);
            this.btn_save_properties.Name = "btn_save_properties";
            this.btn_save_properties.Size = new System.Drawing.Size(75, 23);
            this.btn_save_properties.TabIndex = 17;
            this.btn_save_properties.Text = "Save";
            this.btn_save_properties.UseVisualStyleBackColor = true;
            this.btn_save_properties.Click += new System.EventHandler(this.btn_save_properties_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(278, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "(On a scale of 1000)";
            // 
            // num_exam_passmark
            // 
            this.num_exam_passmark.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.num_exam_passmark.Location = new System.Drawing.Point(161, 102);
            this.num_exam_passmark.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_exam_passmark.Name = "num_exam_passmark";
            this.num_exam_passmark.Size = new System.Drawing.Size(111, 21);
            this.num_exam_passmark.TabIndex = 15;
            this.num_exam_passmark.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_exam_passmark.ValueChanged += new System.EventHandler(this.Changed);
            // 
            // txt_exam_title
            // 
            this.txt_exam_title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_exam_title.Location = new System.Drawing.Point(161, 64);
            this.txt_exam_title.Name = "txt_exam_title";
            this.txt_exam_title.Size = new System.Drawing.Size(240, 21);
            this.txt_exam_title.TabIndex = 14;
            this.txt_exam_title.TextChanged += new System.EventHandler(this.Changed);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "Passmark:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "Title:";
            // 
            // panelReading
            // 
            this.panelReading.Controls.Add(this.label3);
            this.panelReading.Controls.Add(this.txt_reading_text);
            this.panelReading.Controls.Add(this.label1);
            this.panelReading.Controls.Add(this.txt_reading_title);
            this.panelReading.Location = new System.Drawing.Point(32, 42);
            this.panelReading.Name = "panelReading";
            this.panelReading.Size = new System.Drawing.Size(221, 238);
            this.panelReading.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "Reading text:";
            // 
            // txt_reading_text
            // 
            this.txt_reading_text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_reading_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_reading_text.Location = new System.Drawing.Point(12, 96);
            this.txt_reading_text.Multiline = true;
            this.txt_reading_text.Name = "txt_reading_text";
            this.txt_reading_text.Size = new System.Drawing.Size(197, 127);
            this.txt_reading_text.TabIndex = 22;
            this.txt_reading_text.TextChanged += new System.EventHandler(this.Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "Reading title:";
            // 
            // txt_reading_title
            // 
            this.txt_reading_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_reading_title.Location = new System.Drawing.Point(107, 31);
            this.txt_reading_title.Name = "txt_reading_title";
            this.txt_reading_title.Size = new System.Drawing.Size(102, 21);
            this.txt_reading_title.TabIndex = 15;
            this.txt_reading_title.TextChanged += new System.EventHandler(this.Changed);
            // 
            // panel_question
            // 
            this.panel_question.Controls.Add(this.txt_question_text);
            this.panel_question.Controls.Add(this.lbl_reading_question);
            this.panel_question.Controls.Add(this.label11);
            this.panel_question.Controls.Add(this.chkMulipleChoice);
            this.panel_question.Controls.Add(this.panel_question_options);
            this.panel_question.Controls.Add(this.btn_remove_option);
            this.panel_question.Controls.Add(this.btn_add_options);
            this.panel_question.Location = new System.Drawing.Point(301, 42);
            this.panel_question.Name = "panel_question";
            this.panel_question.Size = new System.Drawing.Size(477, 424);
            this.panel_question.TabIndex = 1;
            // 
            // txt_question_text
            // 
            this.txt_question_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_question_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_question_text.Location = new System.Drawing.Point(12, 78);
            this.txt_question_text.Multiline = true;
            this.txt_question_text.Name = "txt_question_text";
            this.txt_question_text.Size = new System.Drawing.Size(453, 79);
            this.txt_question_text.TabIndex = 21;
            this.txt_question_text.TextChanged += new System.EventHandler(this.Changed);
            // 
            // lbl_reading_question
            // 
            this.lbl_reading_question.AutoSize = true;
            this.lbl_reading_question.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_reading_question.Location = new System.Drawing.Point(14, 28);
            this.lbl_reading_question.Name = "lbl_reading_question";
            this.lbl_reading_question.Size = new System.Drawing.Size(0, 15);
            this.lbl_reading_question.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "Question Text:";
            // 
            // chkMulipleChoice
            // 
            this.chkMulipleChoice.AutoSize = true;
            this.chkMulipleChoice.Location = new System.Drawing.Point(12, 163);
            this.chkMulipleChoice.Name = "chkMulipleChoice";
            this.chkMulipleChoice.Size = new System.Drawing.Size(222, 16);
            this.chkMulipleChoice.TabIndex = 17;
            this.chkMulipleChoice.Text = "Is this question multiple choice?";
            this.chkMulipleChoice.UseVisualStyleBackColor = true;
            this.chkMulipleChoice.CheckedChanged += new System.EventHandler(this.chkMulipleChoice_CheckChanged);
            // 
            // panel_question_options
            // 
            this.panel_question_options.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_question_options.AutoScroll = true;
            this.panel_question_options.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_question_options.Location = new System.Drawing.Point(12, 186);
            this.panel_question_options.Name = "panel_question_options";
            this.panel_question_options.Size = new System.Drawing.Size(364, 170);
            this.panel_question_options.TabIndex = 14;
            this.panel_question_options.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.OptionsChanged);
            this.panel_question_options.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.OptionsChanged);
            // 
            // btn_remove_option
            // 
            this.btn_remove_option.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_remove_option.Enabled = false;
            this.btn_remove_option.Location = new System.Drawing.Point(386, 276);
            this.btn_remove_option.Name = "btn_remove_option";
            this.btn_remove_option.Size = new System.Drawing.Size(79, 23);
            this.btn_remove_option.TabIndex = 16;
            this.btn_remove_option.Text = "Remove";
            this.btn_remove_option.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_remove_option.UseVisualStyleBackColor = true;
            this.btn_remove_option.Click += new System.EventHandler(this.btn_remove_option_Click);
            // 
            // btn_add_options
            // 
            this.btn_add_options.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add_options.Location = new System.Drawing.Point(386, 220);
            this.btn_add_options.Name = "btn_add_options";
            this.btn_add_options.Size = new System.Drawing.Size(79, 23);
            this.btn_add_options.TabIndex = 15;
            this.btn_add_options.Text = "Add";
            this.btn_add_options.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_add_options.UseVisualStyleBackColor = true;
            this.btn_add_options.Click += new System.EventHandler(this.btn_add_options_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(805, 25);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(152, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addReadingToolStripMenuItem,
            this.delReadingToolStripMenuItem,
            this.toolStripSeparator3,
            this.addQuestionToolStripMenuItem,
            this.delQuestionToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // addReadingToolStripMenuItem
            // 
            this.addReadingToolStripMenuItem.Name = "addReadingToolStripMenuItem";
            this.addReadingToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.addReadingToolStripMenuItem.Text = "Add reading";
            this.addReadingToolStripMenuItem.Click += new System.EventHandler(this.addReadingToolStripMenuItem_Click);
            // 
            // delReadingToolStripMenuItem
            // 
            this.delReadingToolStripMenuItem.Enabled = false;
            this.delReadingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("delReadingToolStripMenuItem.Image")));
            this.delReadingToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delReadingToolStripMenuItem.Name = "delReadingToolStripMenuItem";
            this.delReadingToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.delReadingToolStripMenuItem.Text = "Delete reading";
            this.delReadingToolStripMenuItem.Click += new System.EventHandler(this.delReadingToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // addQuestionToolStripMenuItem
            // 
            this.addQuestionToolStripMenuItem.Enabled = false;
            this.addQuestionToolStripMenuItem.Name = "addQuestionToolStripMenuItem";
            this.addQuestionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.addQuestionToolStripMenuItem.Text = "Add question";
            this.addQuestionToolStripMenuItem.Click += new System.EventHandler(this.addQuestionToolStripMenuItem_Click);
            // 
            // delQuestionToolStripMenuItem
            // 
            this.delQuestionToolStripMenuItem.Enabled = false;
            this.delQuestionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("delQuestionToolStripMenuItem.Image")));
            this.delQuestionToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delQuestionToolStripMenuItem.Name = "delQuestionToolStripMenuItem";
            this.delQuestionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.delQuestionToolStripMenuItem.Text = "Delete question";
            this.delQuestionToolStripMenuItem.Click += new System.EventHandler(this.delQuestionToolStripMenuItem_Click);
            // 
            // openFileDialogExam
            // 
            this.openFileDialogExam.Filter = "Examination question file|*.eqf";
            // 
            // saveFileDialogExam
            // 
            this.saveFileDialogExam.Filter = "Examination question file|*.eqf";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 522);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.panelReading);
            this.Controls.Add(this.panel_question);
            this.Name = "MainForm";
            this.Text = "题库";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.panel_exam.ResumeLayout(false);
            this.panel_exam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_exam_passmark)).EndInit();
            this.panelReading.ResumeLayout(false);
            this.panelReading.PerformLayout();
            this.panel_question.ResumeLayout(false);
            this.panel_question.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TreeView treeViewExam;
        private System.Windows.Forms.Panel panel_question;
        private System.Windows.Forms.Panel panelReading;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addReadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addQuestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem delReadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delQuestionToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogExam;
        private System.Windows.Forms.ImageList imglstTreeNode;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExam;
        private System.Windows.Forms.Panel panel_exam;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown num_exam_passmark;
        private System.Windows.Forms.TextBox txt_exam_title;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_save_properties;
        private System.Windows.Forms.CheckBox chkMulipleChoice;
        private System.Windows.Forms.Panel panel_question_options;
        private System.Windows.Forms.Button btn_remove_option;
        private System.Windows.Forms.Button btn_add_options;
        private System.Windows.Forms.TextBox txt_question_text;
        private System.Windows.Forms.Label lbl_reading_question;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_reading_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_reading_title;
    }
}

