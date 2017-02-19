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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewExam = new System.Windows.Forms.TreeView();
            this.panelSplash = new System.Windows.Forms.Panel();
            this.panelQuestion = new System.Windows.Forms.Panel();
            this.panelReading = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
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
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogExam = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogExam = new System.Windows.Forms.SaveFileDialog();
            this.imglstTreeNode = new System.Windows.Forms.ImageList(this.components);
            this.cms_reading = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_edit_section = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_question = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_delete_question = new System.Windows.Forms.ToolStripMenuItem();
            this.panelExam = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.num_passmark = new System.Windows.Forms.NumericUpDown();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_save_properties = new System.Windows.Forms.Button();
            this.chkMulipleChoice = new System.Windows.Forms.CheckBox();
            this.pan_options = new System.Windows.Forms.Panel();
            this.btn_remove_option = new System.Windows.Forms.Button();
            this.btn_add_options = new System.Windows.Forms.Button();
            this.txt_question_text = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_reading_question = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelQuestion.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.cms_reading.SuspendLayout();
            this.cms_question.SuspendLayout();
            this.panelExam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_passmark)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewExam);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelExam);
            this.splitContainer1.Panel2.Controls.Add(this.panelSplash);
            this.splitContainer1.Panel2.Controls.Add(this.panelQuestion);
            this.splitContainer1.Panel2.Controls.Add(this.panelReading);
            this.splitContainer1.Size = new System.Drawing.Size(699, 370);
            this.splitContainer1.SplitterDistance = 198;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewExam
            // 
            this.treeViewExam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewExam.ImageIndex = 0;
            this.treeViewExam.ImageList = this.imglstTreeNode;
            this.treeViewExam.Location = new System.Drawing.Point(0, 0);
            this.treeViewExam.Name = "treeViewExam";
            this.treeViewExam.SelectedImageIndex = 0;
            this.treeViewExam.Size = new System.Drawing.Size(198, 370);
            this.treeViewExam.TabIndex = 0;
            this.treeViewExam.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewExam_BeforeSelect);
            this.treeViewExam.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewExam_AfterSelect);
            // 
            // panelSplash
            // 
            this.panelSplash.Location = new System.Drawing.Point(61, 35);
            this.panelSplash.Name = "panelSplash";
            this.panelSplash.Size = new System.Drawing.Size(256, 242);
            this.panelSplash.TabIndex = 2;
            // 
            // panelQuestion
            // 
            this.panelQuestion.Controls.Add(this.lbl_reading_question);
            this.panelQuestion.Controls.Add(this.chkMulipleChoice);
            this.panelQuestion.Controls.Add(this.pan_options);
            this.panelQuestion.Controls.Add(this.btn_remove_option);
            this.panelQuestion.Controls.Add(this.btn_add_options);
            this.panelQuestion.Controls.Add(this.txt_question_text);
            this.panelQuestion.Controls.Add(this.label11);
            this.panelQuestion.Location = new System.Drawing.Point(20, 71);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Size = new System.Drawing.Size(256, 242);
            this.panelQuestion.TabIndex = 1;
            // 
            // panelReading
            // 
            this.panelReading.Location = new System.Drawing.Point(189, 17);
            this.panelReading.Name = "panelReading";
            this.panelReading.Size = new System.Drawing.Size(305, 284);
            this.panelReading.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(699, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
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
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Enabled = false;
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // openFileDialogExam
            // 
            this.openFileDialogExam.FileName = "openFileDialog1";
            // 
            // saveFileDialogExam
            // 
            this.saveFileDialogExam.Filter = "OEF File|*.oef";
            // 
            // imglstTreeNode
            // 
            this.imglstTreeNode.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstTreeNode.ImageStream")));
            this.imglstTreeNode.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstTreeNode.Images.SetKeyName(0, "Exam.png");
            this.imglstTreeNode.Images.SetKeyName(1, "New_Section.png");
            this.imglstTreeNode.Images.SetKeyName(2, "New_Question.png");
            // 
            // cms_reading
            // 
            this.cms_reading.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_edit_section});
            this.cms_reading.Name = "cms_section";
            this.cms_reading.Size = new System.Drawing.Size(99, 26);
            // 
            // btn_edit_section
            // 
            this.btn_edit_section.Name = "btn_edit_section";
            this.btn_edit_section.Size = new System.Drawing.Size(98, 22);
            this.btn_edit_section.Text = "Edit";
            // 
            // cms_question
            // 
            this.cms_question.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_delete_question});
            this.cms_question.Name = "cms_question";
            this.cms_question.Size = new System.Drawing.Size(141, 26);
            // 
            // btn_delete_question
            // 
            this.btn_delete_question.Name = "btn_delete_question";
            this.btn_delete_question.ShortcutKeyDisplayString = "Del";
            this.btn_delete_question.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.btn_delete_question.Size = new System.Drawing.Size(140, 22);
            this.btn_delete_question.Text = "Delete";
            // 
            // panelExam
            // 
            this.panelExam.Controls.Add(this.btn_save_properties);
            this.panelExam.Controls.Add(this.label9);
            this.panelExam.Controls.Add(this.num_passmark);
            this.panelExam.Controls.Add(this.txt_title);
            this.panelExam.Controls.Add(this.label5);
            this.panelExam.Controls.Add(this.label2);
            this.panelExam.Location = new System.Drawing.Point(90, 17);
            this.panelExam.Name = "panelExam";
            this.panelExam.Size = new System.Drawing.Size(256, 242);
            this.panelExam.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(155, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "(On a scale of 1000)";
            // 
            // num_passmark
            // 
            this.num_passmark.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.num_passmark.Location = new System.Drawing.Point(38, 159);
            this.num_passmark.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_passmark.Name = "num_passmark";
            this.num_passmark.Size = new System.Drawing.Size(111, 21);
            this.num_passmark.TabIndex = 15;
            this.num_passmark.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_title
            // 
            this.txt_title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_title.Location = new System.Drawing.Point(38, 63);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(240, 21);
            this.txt_title.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-24, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "Passmark:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-24, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "Title:";
            // 
            // btn_save_properties
            // 
            this.btn_save_properties.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_save_properties.Location = new System.Drawing.Point(74, 199);
            this.btn_save_properties.Name = "btn_save_properties";
            this.btn_save_properties.Size = new System.Drawing.Size(75, 23);
            this.btn_save_properties.TabIndex = 17;
            this.btn_save_properties.Text = "Save";
            this.btn_save_properties.UseVisualStyleBackColor = true;
            // 
            // chkMulipleChoice
            // 
            this.chkMulipleChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkMulipleChoice.AutoSize = true;
            this.chkMulipleChoice.Location = new System.Drawing.Point(-133, 145);
            this.chkMulipleChoice.Name = "chkMulipleChoice";
            this.chkMulipleChoice.Size = new System.Drawing.Size(222, 16);
            this.chkMulipleChoice.TabIndex = 17;
            this.chkMulipleChoice.Text = "Is this question multiple choice?";
            this.chkMulipleChoice.UseVisualStyleBackColor = true;
            // 
            // pan_options
            // 
            this.pan_options.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pan_options.AutoScroll = true;
            this.pan_options.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_options.Location = new System.Drawing.Point(-38, 166);
            this.pan_options.Name = "pan_options";
            this.pan_options.Size = new System.Drawing.Size(315, 170);
            this.pan_options.TabIndex = 14;
            // 
            // btn_remove_option
            // 
            this.btn_remove_option.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_remove_option.Enabled = false;
            this.btn_remove_option.Location = new System.Drawing.Point(283, 196);
            this.btn_remove_option.Name = "btn_remove_option";
            this.btn_remove_option.Size = new System.Drawing.Size(75, 23);
            this.btn_remove_option.TabIndex = 16;
            this.btn_remove_option.Text = "Remove";
            this.btn_remove_option.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_remove_option.UseVisualStyleBackColor = true;
            // 
            // btn_add_options
            // 
            this.btn_add_options.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add_options.Location = new System.Drawing.Point(283, 166);
            this.btn_add_options.Name = "btn_add_options";
            this.btn_add_options.Size = new System.Drawing.Size(75, 23);
            this.btn_add_options.TabIndex = 15;
            this.btn_add_options.Text = "Add";
            this.btn_add_options.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_add_options.UseVisualStyleBackColor = true;
            // 
            // txt_question_text
            // 
            this.txt_question_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_question_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_question_text.Location = new System.Drawing.Point(-140, -77);
            this.txt_question_text.Multiline = true;
            this.txt_question_text.Name = "txt_question_text";
            this.txt_question_text.Size = new System.Drawing.Size(540, 57);
            this.txt_question_text.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(-143, -93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 12;
            this.label11.Text = "Question Text:";
            // 
            // lbl_reading_question
            // 
            this.lbl_reading_question.AutoSize = true;
            this.lbl_reading_question.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_reading_question.Location = new System.Drawing.Point(128, 114);
            this.lbl_reading_question.Name = "lbl_reading_question";
            this.lbl_reading_question.Size = new System.Drawing.Size(0, 15);
            this.lbl_reading_question.TabIndex = 18;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 395);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "题库";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelQuestion.ResumeLayout(false);
            this.panelQuestion.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cms_reading.ResumeLayout(false);
            this.cms_question.ResumeLayout(false);
            this.panelExam.ResumeLayout(false);
            this.panelExam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_passmark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewExam;
        private System.Windows.Forms.Panel panelQuestion;
        private System.Windows.Forms.Panel panelReading;
        private System.Windows.Forms.MenuStrip menuStrip1;
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
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.Panel panelSplash;
        private System.Windows.Forms.OpenFileDialog openFileDialogExam;
        private System.Windows.Forms.ImageList imglstTreeNode;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExam;
        private System.Windows.Forms.ContextMenuStrip cms_reading;
        private System.Windows.Forms.ToolStripMenuItem btn_edit_section;
        private System.Windows.Forms.ContextMenuStrip cms_question;
        private System.Windows.Forms.ToolStripMenuItem btn_delete_question;
        private System.Windows.Forms.Panel panelExam;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown num_passmark;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_save_properties;
        private System.Windows.Forms.CheckBox chkMulipleChoice;
        private System.Windows.Forms.Panel pan_options;
        private System.Windows.Forms.Button btn_remove_option;
        private System.Windows.Forms.Button btn_add_options;
        private System.Windows.Forms.TextBox txt_question_text;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_reading_question;
    }
}

