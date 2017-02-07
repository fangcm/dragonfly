namespace Dragonfly.Plugin.Note
{
    partial class NoteForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteForm));
            this.richTextBoxNote = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.insertPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.underlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.italicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontcolorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.increaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulletsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alignmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomRealsizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomHalfsizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNoteChangeTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxNoteTitle = new System.Windows.Forms.ToolStripTextBox();
            this.ResizeMe = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelCaption = new System.Windows.Forms.Panel();
            this.showbarButton = new System.Windows.Forms.Button();
            this.hideButton = new System.Windows.Forms.Button();
            this.labelCaption = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelCaption.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxNote
            // 
            this.richTextBoxNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxNote.BackColor = System.Drawing.Color.Khaki;
            this.richTextBoxNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxNote.ContextMenuStrip = this.contextMenuStrip;
            this.richTextBoxNote.Location = new System.Drawing.Point(8, 20);
            this.richTextBoxNote.Margin = new System.Windows.Forms.Padding(8, 20, 8, 8);
            this.richTextBoxNote.Name = "richTextBoxNote";
            this.richTextBoxNote.Size = new System.Drawing.Size(281, 234);
            this.richTextBoxNote.TabIndex = 0;
            this.richTextBoxNote.Text = "";
            this.richTextBoxNote.WordWrap = false;
            this.richTextBoxNote.SelectionChanged += new System.EventHandler(this.richTextBoxNote_SelectionChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator1,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.toolStripSeparator2,
            this.insertPictureToolStripMenuItem,
            this.toolStripSeparator5,
            this.formatToolStripMenuItem,
            this.alignmentToolStripMenuItem,
            this.zoomToolStripMenuItem,
            this.toolStripSeparator3,
            this.deleteNoteToolStripMenuItem,
            this.topToolStripMenuItem,
            this.hideNoteToolStripMenuItem,
            this.toolStripMenuItemNoteChangeTitle});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(143, 358);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.undo;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.undoToolStripMenuItem.Text = "撤销(&U)";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.redo;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.redoToolStripMenuItem.Text = "重做(&R)";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.cut;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.cutToolStripMenuItem.Text = "剪切(&T)";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.copyToolStripMenuItem.Text = "复制(&C)";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.pasteToolStripMenuItem.Text = "粘贴(&P)";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.del;
            this.deleteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.deleteToolStripMenuItem.Text = "清空全部";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("selectAllToolStripMenuItem.Image")));
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.selectAllToolStripMenuItem.Text = "选择全部(&A)";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(139, 6);
            // 
            // insertPictureToolStripMenuItem
            // 
            this.insertPictureToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.insertPicture;
            this.insertPictureToolStripMenuItem.Name = "insertPictureToolStripMenuItem";
            this.insertPictureToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.insertPictureToolStripMenuItem.Text = "插入图片";
            this.insertPictureToolStripMenuItem.Click += new System.EventHandler(this.insertPictureToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(139, 6);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.underlineToolStripMenuItem,
            this.italicToolStripMenuItem,
            this.boldToolStripMenuItem,
            this.toolStripSeparator4,
            this.fontToolStripMenuItem,
            this.fontcolorToolStripMenuItem,
            this.colorToolStripMenuItem,
            this.toolStripSeparator6,
            this.increaseToolStripMenuItem,
            this.decreaseToolStripMenuItem,
            this.bulletsToolStripMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.formatToolStripMenuItem.Text = "格式";
            // 
            // underlineToolStripMenuItem
            // 
            this.underlineToolStripMenuItem.CheckOnClick = true;
            this.underlineToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.underline;
            this.underlineToolStripMenuItem.Name = "underlineToolStripMenuItem";
            this.underlineToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.underlineToolStripMenuItem.Text = "下划线";
            this.underlineToolStripMenuItem.Click += new System.EventHandler(this.underlineToolStripMenuItem_Click);
            // 
            // italicToolStripMenuItem
            // 
            this.italicToolStripMenuItem.CheckOnClick = true;
            this.italicToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.italic;
            this.italicToolStripMenuItem.Name = "italicToolStripMenuItem";
            this.italicToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.italicToolStripMenuItem.Text = "斜体";
            this.italicToolStripMenuItem.Click += new System.EventHandler(this.italicToolStripMenuItem_Click);
            // 
            // boldToolStripMenuItem
            // 
            this.boldToolStripMenuItem.CheckOnClick = true;
            this.boldToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.bold;
            this.boldToolStripMenuItem.Name = "boldToolStripMenuItem";
            this.boldToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.boldToolStripMenuItem.Text = "粗体";
            this.boldToolStripMenuItem.Click += new System.EventHandler(this.boldToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(139, 6);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.font;
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.fontToolStripMenuItem.Text = "字体(&F)";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // fontcolorToolStripMenuItem
            // 
            this.fontcolorToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.fontcolor;
            this.fontcolorToolStripMenuItem.Name = "fontcolorToolStripMenuItem";
            this.fontcolorToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.fontcolorToolStripMenuItem.Text = "字体颜色";
            this.fontcolorToolStripMenuItem.Click += new System.EventHandler(this.fontcolorToolStripMenuItem_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.backcolor;
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.colorToolStripMenuItem.Text = "背景颜色(&B)";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(139, 6);
            // 
            // increaseToolStripMenuItem
            // 
            this.increaseToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.indentIncrease;
            this.increaseToolStripMenuItem.Name = "increaseToolStripMenuItem";
            this.increaseToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.increaseToolStripMenuItem.Text = "增加缩进量";
            this.increaseToolStripMenuItem.Click += new System.EventHandler(this.increaseToolStripMenuItem_Click);
            // 
            // decreaseToolStripMenuItem
            // 
            this.decreaseToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.indentDecrease;
            this.decreaseToolStripMenuItem.Name = "decreaseToolStripMenuItem";
            this.decreaseToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.decreaseToolStripMenuItem.Text = "减少缩进量";
            this.decreaseToolStripMenuItem.Click += new System.EventHandler(this.decreaseToolStripMenuItem_Click);
            // 
            // bulletsToolStripMenuItem
            // 
            this.bulletsToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.bullets;
            this.bulletsToolStripMenuItem.Name = "bulletsToolStripMenuItem";
            this.bulletsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.bulletsToolStripMenuItem.Text = "项目符号(&N)";
            this.bulletsToolStripMenuItem.Click += new System.EventHandler(this.bulletsToolStripMenuItem_Click);
            // 
            // alignmentToolStripMenuItem
            // 
            this.alignmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftToolStripMenuItem,
            this.centerToolStripMenuItem,
            this.rightToolStripMenuItem});
            this.alignmentToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.alignmentToolStripMenuItem.Name = "alignmentToolStripMenuItem";
            this.alignmentToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.alignmentToolStripMenuItem.Text = "对齐";
            // 
            // leftToolStripMenuItem
            // 
            this.leftToolStripMenuItem.CheckOnClick = true;
            this.leftToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.alignLeft;
            this.leftToolStripMenuItem.Name = "leftToolStripMenuItem";
            this.leftToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.leftToolStripMenuItem.Text = "左对齐";
            this.leftToolStripMenuItem.Click += new System.EventHandler(this.leftToolStripMenuItem_Click);
            // 
            // centerToolStripMenuItem
            // 
            this.centerToolStripMenuItem.CheckOnClick = true;
            this.centerToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.alignCenter;
            this.centerToolStripMenuItem.Name = "centerToolStripMenuItem";
            this.centerToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.centerToolStripMenuItem.Text = "居中对齐";
            this.centerToolStripMenuItem.Click += new System.EventHandler(this.centerToolStripMenuItem_Click);
            // 
            // rightToolStripMenuItem
            // 
            this.rightToolStripMenuItem.CheckOnClick = true;
            this.rightToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.alignRight;
            this.rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            this.rightToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.rightToolStripMenuItem.Text = "右对齐";
            this.rightToolStripMenuItem.Click += new System.EventHandler(this.rightToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.zoomRealsizeToolStripMenuItem,
            this.zoomHalfsizeToolStripMenuItem});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.zoomToolStripMenuItem.Text = "缩放";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.zoomIn;
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.zoomInToolStripMenuItem.Text = "放大";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.zoomOut;
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.zoomOutToolStripMenuItem.Text = "缩小";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // zoomRealsizeToolStripMenuItem
            // 
            this.zoomRealsizeToolStripMenuItem.Name = "zoomRealsizeToolStripMenuItem";
            this.zoomRealsizeToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.zoomRealsizeToolStripMenuItem.Text = "100%";
            this.zoomRealsizeToolStripMenuItem.Click += new System.EventHandler(this.zoomRealsizeToolStripMenuItem_Click);
            // 
            // zoomHalfsizeToolStripMenuItem
            // 
            this.zoomHalfsizeToolStripMenuItem.Name = "zoomHalfsizeToolStripMenuItem";
            this.zoomHalfsizeToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.zoomHalfsizeToolStripMenuItem.Text = "50%";
            this.zoomHalfsizeToolStripMenuItem.Click += new System.EventHandler(this.zoomHalfsizeToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(139, 6);
            // 
            // deleteNoteToolStripMenuItem
            // 
            this.deleteNoteToolStripMenuItem.Image = global::Dragonfly.Plugin.Note.Properties.Resources.delnote;
            this.deleteNoteToolStripMenuItem.Name = "deleteNoteToolStripMenuItem";
            this.deleteNoteToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.deleteNoteToolStripMenuItem.Text = "删除便签(&R)";
            this.deleteNoteToolStripMenuItem.Click += new System.EventHandler(this.deleteNoteToolStripMenuItem_Click);
            // 
            // topToolStripMenuItem
            // 
            this.topToolStripMenuItem.Name = "topToolStripMenuItem";
            this.topToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.topToolStripMenuItem.Text = "放在最前(&O)";
            this.topToolStripMenuItem.Click += new System.EventHandler(this.topToolStripMenuItem_Click);
            // 
            // hideNoteToolStripMenuItem
            // 
            this.hideNoteToolStripMenuItem.Name = "hideNoteToolStripMenuItem";
            this.hideNoteToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.hideNoteToolStripMenuItem.Text = "隐藏便签";
            this.hideNoteToolStripMenuItem.Click += new System.EventHandler(this.hideNoteToolStripMenuItem_Click);
            // 
            // toolStripMenuItemNoteChangeTitle
            // 
            this.toolStripMenuItemNoteChangeTitle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxNoteTitle});
            this.toolStripMenuItemNoteChangeTitle.Name = "toolStripMenuItemNoteChangeTitle";
            this.toolStripMenuItemNoteChangeTitle.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuItemNoteChangeTitle.Text = "更改标题";
            // 
            // toolStripTextBoxNoteTitle
            // 
            this.toolStripTextBoxNoteTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxNoteTitle.Name = "toolStripTextBoxNoteTitle";
            this.toolStripTextBoxNoteTitle.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxNoteTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxNoteTitle_KeyDown);
            this.toolStripTextBoxNoteTitle.TextChanged += new System.EventHandler(this.toolStripTextBoxNoteTitle_TextChanged);
            // 
            // ResizeMe
            // 
            this.ResizeMe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResizeMe.BackColor = System.Drawing.Color.Khaki;
            this.ResizeMe.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.ResizeMe.Image = global::Dragonfly.Plugin.Note.Properties.Resources.scale;
            this.ResizeMe.Location = new System.Drawing.Point(274, 238);
            this.ResizeMe.Margin = new System.Windows.Forms.Padding(3);
            this.ResizeMe.Name = "ResizeMe";
            this.ResizeMe.Size = new System.Drawing.Size(24, 24);
            this.ResizeMe.TabIndex = 4;
            this.ResizeMe.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ResizeMe_MouseMove);
            this.ResizeMe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResizeMe_MouseDown);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Khaki;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.panelCaption);
            this.panelMain.Controls.Add(this.richTextBoxNote);
            this.panelMain.Controls.Add(this.ResizeMe);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(299, 264);
            this.panelMain.TabIndex = 5;
            this.panelMain.DoubleClick += new System.EventHandler(this.NoteForm_DoubleClick);
            this.panelMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NoteForm_MouseMove);
            this.panelMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NoteForm_MouseDown);
            this.panelMain.MouseHover += new System.EventHandler(this.NoteForm_MouseHover);
            // 
            // panelCaption
            // 
            this.panelCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCaption.Controls.Add(this.showbarButton);
            this.panelCaption.Controls.Add(this.hideButton);
            this.panelCaption.Controls.Add(this.labelCaption);
            this.panelCaption.Location = new System.Drawing.Point(0, 0);
            this.panelCaption.Margin = new System.Windows.Forms.Padding(1);
            this.panelCaption.Name = "panelCaption";
            this.panelCaption.Size = new System.Drawing.Size(298, 19);
            this.panelCaption.TabIndex = 7;
            this.panelCaption.DoubleClick += new System.EventHandler(this.NoteForm_DoubleClick);
            this.panelCaption.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NoteForm_MouseMove);
            this.panelCaption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NoteForm_MouseDown);
            this.panelCaption.MouseHover += new System.EventHandler(this.NoteForm_MouseHover);
            // 
            // showbarButton
            // 
            this.showbarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showbarButton.BackColor = System.Drawing.Color.Khaki;
            this.showbarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.showbarButton.FlatAppearance.BorderSize = 0;
            this.showbarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showbarButton.Image = global::Dragonfly.Plugin.Note.Properties.Resources.note_showbar;
            this.showbarButton.Location = new System.Drawing.Point(262, 1);
            this.showbarButton.Margin = new System.Windows.Forms.Padding(1);
            this.showbarButton.Name = "showbarButton";
            this.showbarButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.showbarButton.Size = new System.Drawing.Size(16, 16);
            this.showbarButton.TabIndex = 8;
            this.showbarButton.UseVisualStyleBackColor = false;
            this.showbarButton.Click += new System.EventHandler(this.showbarButton_Click);
            // 
            // hideButton
            // 
            this.hideButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hideButton.BackColor = System.Drawing.Color.Khaki;
            this.hideButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.hideButton.FlatAppearance.BorderSize = 0;
            this.hideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideButton.Image = global::Dragonfly.Plugin.Note.Properties.Resources.note_hide;
            this.hideButton.Location = new System.Drawing.Point(280, 1);
            this.hideButton.Margin = new System.Windows.Forms.Padding(1);
            this.hideButton.Name = "hideButton";
            this.hideButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.hideButton.Size = new System.Drawing.Size(16, 16);
            this.hideButton.TabIndex = 7;
            this.hideButton.UseVisualStyleBackColor = false;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // labelCaption
            // 
            this.labelCaption.AutoSize = true;
            this.labelCaption.Location = new System.Drawing.Point(3, 3);
            this.labelCaption.Margin = new System.Windows.Forms.Padding(3);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.Size = new System.Drawing.Size(29, 12);
            this.labelCaption.TabIndex = 6;
            this.labelCaption.Text = "便签";
            this.labelCaption.DoubleClick += new System.EventHandler(this.NoteForm_DoubleClick);
            this.labelCaption.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NoteForm_MouseMove);
            this.labelCaption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NoteForm_MouseDown);
            this.labelCaption.MouseHover += new System.EventHandler(this.NoteForm_MouseHover);
            // 
            // NoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 264);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NoteForm";
            this.Opacity = 0.5;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "便签";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.NoteForm_Deactivate);
            this.Load += new System.EventHandler(this.NoteForm_Load);
            this.DoubleClick += new System.EventHandler(this.NoteForm_DoubleClick);
            this.Activated += new System.EventHandler(this.NoteForm_Activated);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NoteForm_MouseDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NoteForm_FormClosing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NoteForm_MouseMove);
            this.MouseHover += new System.EventHandler(this.NoteForm_MouseHover);
            this.contextMenuStrip.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelCaption.ResumeLayout(false);
            this.panelCaption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxNote;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alignmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem underlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem italicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontcolorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomRealsizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomHalfsizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem insertPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem increaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decreaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bulletsToolStripMenuItem;
        internal System.Windows.Forms.Label ResizeMe;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label labelCaption;
        private System.Windows.Forms.Panel panelCaption;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNoteChangeTitle;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxNoteTitle;
        private System.Windows.Forms.Button hideButton;
        private System.Windows.Forms.Button showbarButton;
    }
}