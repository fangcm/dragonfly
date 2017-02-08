namespace Dragonfly.Plugin.Note
{
    partial class NoteOptionPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSelectFont = new System.Windows.Forms.Button();
            this.labelDemoFont = new System.Windows.Forms.Label();
            this.labelColorFont = new System.Windows.Forms.Label();
            this.labelColorBackground = new System.Windows.Forms.Label();
            this.labelMinHeight = new System.Windows.Forms.Label();
            this.labelMinWidth = new System.Windows.Forms.Label();
            this.labelMaxWidth = new System.Windows.Forms.Label();
            this.labelMaxHeight = new System.Windows.Forms.Label();
            this.checkBoxAlwaysTop = new System.Windows.Forms.CheckBox();
            this.groupBoxFont = new System.Windows.Forms.GroupBox();
            this.checkBoxUseRandomColor = new System.Windows.Forms.CheckBox();
            this.colorComboBoxBackground = new Dragonfly.Common.Controls.ColorComboBox();
            this.colorComboBoxFont = new Dragonfly.Common.Controls.ColorComboBox();
            this.groupBoxMinMaxNote = new System.Windows.Forms.GroupBox();
            this.numericUpDownMaxHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinWidth = new System.Windows.Forms.NumericUpDown();
            this.labelTransparentTip = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.hotkeyControlHideAllNote = new Dragonfly.Common.Controls.HotkeyControl();
            this.labelShowAllNote = new System.Windows.Forms.Label();
            this.labelHideAllNote = new System.Windows.Forms.Label();
            this.hotkeyControlShowAllNote = new Dragonfly.Common.Controls.HotkeyControl();
            this.groupBoxTransparent = new System.Windows.Forms.GroupBox();
            this.trackBarTransparent = new System.Windows.Forms.TrackBar();
            this.groupBoxFont.SuspendLayout();
            this.groupBoxMinMaxNote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinWidth)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBoxTransparent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransparent)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSelectFont
            // 
            this.buttonSelectFont.Location = new System.Drawing.Point(149, 16);
            this.buttonSelectFont.Name = "buttonSelectFont";
            this.buttonSelectFont.Size = new System.Drawing.Size(97, 23);
            this.buttonSelectFont.TabIndex = 0;
            this.buttonSelectFont.Text = "选择字体...";
            this.buttonSelectFont.UseVisualStyleBackColor = true;
            this.buttonSelectFont.Click += new System.EventHandler(this.buttonSelectFont_Click);
            // 
            // labelDemoFont
            // 
            this.labelDemoFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDemoFont.Location = new System.Drawing.Point(149, 45);
            this.labelDemoFont.Name = "labelDemoFont";
            this.labelDemoFont.Size = new System.Drawing.Size(248, 50);
            this.labelDemoFont.TabIndex = 5;
            this.labelDemoFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelColorFont
            // 
            this.labelColorFont.AutoSize = true;
            this.labelColorFont.Location = new System.Drawing.Point(9, 24);
            this.labelColorFont.Name = "labelColorFont";
            this.labelColorFont.Size = new System.Drawing.Size(53, 12);
            this.labelColorFont.TabIndex = 1;
            this.labelColorFont.Text = "字体颜色";
            // 
            // labelColorBackground
            // 
            this.labelColorBackground.AutoSize = true;
            this.labelColorBackground.Location = new System.Drawing.Point(9, 48);
            this.labelColorBackground.Name = "labelColorBackground";
            this.labelColorBackground.Size = new System.Drawing.Size(53, 12);
            this.labelColorBackground.TabIndex = 3;
            this.labelColorBackground.Text = "背景颜色";
            // 
            // labelMinHeight
            // 
            this.labelMinHeight.AutoSize = true;
            this.labelMinHeight.Location = new System.Drawing.Point(9, 59);
            this.labelMinHeight.Name = "labelMinHeight";
            this.labelMinHeight.Size = new System.Drawing.Size(53, 12);
            this.labelMinHeight.TabIndex = 4;
            this.labelMinHeight.Text = "最小高度";
            // 
            // labelMinWidth
            // 
            this.labelMinWidth.AutoSize = true;
            this.labelMinWidth.Location = new System.Drawing.Point(9, 24);
            this.labelMinWidth.Name = "labelMinWidth";
            this.labelMinWidth.Size = new System.Drawing.Size(53, 12);
            this.labelMinWidth.TabIndex = 0;
            this.labelMinWidth.Text = "最小宽度";
            // 
            // labelMaxWidth
            // 
            this.labelMaxWidth.AutoSize = true;
            this.labelMaxWidth.Location = new System.Drawing.Point(186, 24);
            this.labelMaxWidth.Name = "labelMaxWidth";
            this.labelMaxWidth.Size = new System.Drawing.Size(53, 12);
            this.labelMaxWidth.TabIndex = 2;
            this.labelMaxWidth.Text = "最大宽度";
            // 
            // labelMaxHeight
            // 
            this.labelMaxHeight.AutoSize = true;
            this.labelMaxHeight.Location = new System.Drawing.Point(186, 59);
            this.labelMaxHeight.Name = "labelMaxHeight";
            this.labelMaxHeight.Size = new System.Drawing.Size(53, 12);
            this.labelMaxHeight.TabIndex = 6;
            this.labelMaxHeight.Text = "最大高度";
            // 
            // checkBoxAlwaysTop
            // 
            this.checkBoxAlwaysTop.AutoSize = true;
            this.checkBoxAlwaysTop.Location = new System.Drawing.Point(3, 298);
            this.checkBoxAlwaysTop.Name = "checkBoxAlwaysTop";
            this.checkBoxAlwaysTop.Size = new System.Drawing.Size(108, 16);
            this.checkBoxAlwaysTop.TabIndex = 0;
            this.checkBoxAlwaysTop.Text = "便签总在最前端";
            this.checkBoxAlwaysTop.UseVisualStyleBackColor = true;
            // 
            // groupBoxFont
            // 
            this.groupBoxFont.Controls.Add(this.checkBoxUseRandomColor);
            this.groupBoxFont.Controls.Add(this.labelDemoFont);
            this.groupBoxFont.Controls.Add(this.buttonSelectFont);
            this.groupBoxFont.Controls.Add(this.colorComboBoxBackground);
            this.groupBoxFont.Controls.Add(this.colorComboBoxFont);
            this.groupBoxFont.Controls.Add(this.labelColorBackground);
            this.groupBoxFont.Controls.Add(this.labelColorFont);
            this.groupBoxFont.Location = new System.Drawing.Point(3, 3);
            this.groupBoxFont.Name = "groupBoxFont";
            this.groupBoxFont.Size = new System.Drawing.Size(404, 103);
            this.groupBoxFont.TabIndex = 0;
            this.groupBoxFont.TabStop = false;
            this.groupBoxFont.Text = "便签默认字体及颜色";
            // 
            // checkBoxUseRandomColor
            // 
            this.checkBoxUseRandomColor.AutoSize = true;
            this.checkBoxUseRandomColor.Location = new System.Drawing.Point(11, 71);
            this.checkBoxUseRandomColor.Name = "checkBoxUseRandomColor";
            this.checkBoxUseRandomColor.Size = new System.Drawing.Size(120, 16);
            this.checkBoxUseRandomColor.TabIndex = 6;
            this.checkBoxUseRandomColor.Text = "使用随机背景颜色";
            this.checkBoxUseRandomColor.UseVisualStyleBackColor = true;
            this.checkBoxUseRandomColor.CheckedChanged += new System.EventHandler(this.checkBoxUseRandomColor_CheckedChanged);
            // 
            // colorComboBoxBackground
            // 
            this.colorComboBoxBackground.Extended = false;
            this.colorComboBoxBackground.Location = new System.Drawing.Point(68, 45);
            this.colorComboBoxBackground.Name = "colorComboBoxBackground";
            this.colorComboBoxBackground.SelectedColor = System.Drawing.Color.Black;
            this.colorComboBoxBackground.Size = new System.Drawing.Size(50, 20);
            this.colorComboBoxBackground.TabIndex = 4;
            this.colorComboBoxBackground.ColorChanged += new Dragonfly.Common.Controls.ColorChangedHandler(this.colorComboBoxBackground_ColorChanged);
            // 
            // colorComboBoxFont
            // 
            this.colorComboBoxFont.Extended = false;
            this.colorComboBoxFont.Location = new System.Drawing.Point(68, 19);
            this.colorComboBoxFont.Name = "colorComboBoxFont";
            this.colorComboBoxFont.SelectedColor = System.Drawing.Color.Black;
            this.colorComboBoxFont.Size = new System.Drawing.Size(50, 20);
            this.colorComboBoxFont.TabIndex = 2;
            this.colorComboBoxFont.ColorChanged += new Dragonfly.Common.Controls.ColorChangedHandler(this.colorComboBoxFont_ColorChanged);
            // 
            // groupBoxMinMaxNote
            // 
            this.groupBoxMinMaxNote.Controls.Add(this.numericUpDownMaxHeight);
            this.groupBoxMinMaxNote.Controls.Add(this.numericUpDownMaxWidth);
            this.groupBoxMinMaxNote.Controls.Add(this.numericUpDownMinHeight);
            this.groupBoxMinMaxNote.Controls.Add(this.numericUpDownMinWidth);
            this.groupBoxMinMaxNote.Controls.Add(this.labelMaxWidth);
            this.groupBoxMinMaxNote.Controls.Add(this.labelMaxHeight);
            this.groupBoxMinMaxNote.Controls.Add(this.labelMinWidth);
            this.groupBoxMinMaxNote.Controls.Add(this.labelMinHeight);
            this.groupBoxMinMaxNote.Location = new System.Drawing.Point(3, 195);
            this.groupBoxMinMaxNote.Name = "groupBoxMinMaxNote";
            this.groupBoxMinMaxNote.Size = new System.Drawing.Size(404, 88);
            this.groupBoxMinMaxNote.TabIndex = 0;
            this.groupBoxMinMaxNote.TabStop = false;
            this.groupBoxMinMaxNote.Text = "便签大小限制";
            // 
            // numericUpDownMaxHeight
            // 
            this.numericUpDownMaxHeight.Location = new System.Drawing.Point(258, 55);
            this.numericUpDownMaxHeight.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownMaxHeight.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownMaxHeight.Name = "numericUpDownMaxHeight";
            this.numericUpDownMaxHeight.Size = new System.Drawing.Size(60, 21);
            this.numericUpDownMaxHeight.TabIndex = 7;
            this.numericUpDownMaxHeight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numericUpDownMaxWidth
            // 
            this.numericUpDownMaxWidth.Location = new System.Drawing.Point(258, 20);
            this.numericUpDownMaxWidth.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownMaxWidth.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownMaxWidth.Name = "numericUpDownMaxWidth";
            this.numericUpDownMaxWidth.Size = new System.Drawing.Size(60, 21);
            this.numericUpDownMaxWidth.TabIndex = 3;
            this.numericUpDownMaxWidth.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numericUpDownMinHeight
            // 
            this.numericUpDownMinHeight.Location = new System.Drawing.Point(85, 55);
            this.numericUpDownMinHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMinHeight.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownMinHeight.Name = "numericUpDownMinHeight";
            this.numericUpDownMinHeight.Size = new System.Drawing.Size(60, 21);
            this.numericUpDownMinHeight.TabIndex = 5;
            this.numericUpDownMinHeight.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numericUpDownMinWidth
            // 
            this.numericUpDownMinWidth.Location = new System.Drawing.Point(85, 20);
            this.numericUpDownMinWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMinWidth.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownMinWidth.Name = "numericUpDownMinWidth";
            this.numericUpDownMinWidth.Size = new System.Drawing.Size(60, 21);
            this.numericUpDownMinWidth.TabIndex = 1;
            this.numericUpDownMinWidth.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // labelTransparentTip
            // 
            this.labelTransparentTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTransparentTip.Location = new System.Drawing.Point(114, 29);
            this.labelTransparentTip.Name = "labelTransparentTip";
            this.labelTransparentTip.Size = new System.Drawing.Size(35, 21);
            this.labelTransparentTip.TabIndex = 3;
            this.labelTransparentTip.Text = "50%";
            this.labelTransparentTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.hotkeyControlHideAllNote);
            this.groupBox3.Controls.Add(this.labelShowAllNote);
            this.groupBox3.Controls.Add(this.labelHideAllNote);
            this.groupBox3.Controls.Add(this.hotkeyControlShowAllNote);
            this.groupBox3.Location = new System.Drawing.Point(158, 112);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 77);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "便签快捷键";
            // 
            // hotkeyControlHideAllNote
            // 
            this.hotkeyControlHideAllNote.Hotkey = System.Windows.Forms.Keys.None;
            this.hotkeyControlHideAllNote.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.hotkeyControlHideAllNote.Location = new System.Drawing.Point(66, 51);
            this.hotkeyControlHideAllNote.Name = "hotkeyControlHideAllNote";
            this.hotkeyControlHideAllNote.Size = new System.Drawing.Size(177, 21);
            this.hotkeyControlHideAllNote.TabIndex = 3;
            this.hotkeyControlHideAllNote.Text = "None";
            // 
            // labelShowAllNote
            // 
            this.labelShowAllNote.AutoSize = true;
            this.labelShowAllNote.Location = new System.Drawing.Point(7, 29);
            this.labelShowAllNote.Name = "labelShowAllNote";
            this.labelShowAllNote.Size = new System.Drawing.Size(53, 12);
            this.labelShowAllNote.TabIndex = 0;
            this.labelShowAllNote.Text = "显示全部";
            // 
            // labelHideAllNote
            // 
            this.labelHideAllNote.AutoSize = true;
            this.labelHideAllNote.Location = new System.Drawing.Point(7, 54);
            this.labelHideAllNote.Name = "labelHideAllNote";
            this.labelHideAllNote.Size = new System.Drawing.Size(53, 12);
            this.labelHideAllNote.TabIndex = 2;
            this.labelHideAllNote.Text = "隐藏全部";
            // 
            // hotkeyControlShowAllNote
            // 
            this.hotkeyControlShowAllNote.Hotkey = System.Windows.Forms.Keys.None;
            this.hotkeyControlShowAllNote.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.hotkeyControlShowAllNote.Location = new System.Drawing.Point(66, 20);
            this.hotkeyControlShowAllNote.Name = "hotkeyControlShowAllNote";
            this.hotkeyControlShowAllNote.Size = new System.Drawing.Size(177, 21);
            this.hotkeyControlShowAllNote.TabIndex = 1;
            this.hotkeyControlShowAllNote.Text = "None";
            // 
            // groupBoxTransparent
            // 
            this.groupBoxTransparent.Controls.Add(this.labelTransparentTip);
            this.groupBoxTransparent.Controls.Add(this.trackBarTransparent);
            this.groupBoxTransparent.Location = new System.Drawing.Point(3, 112);
            this.groupBoxTransparent.Name = "groupBoxTransparent";
            this.groupBoxTransparent.Size = new System.Drawing.Size(154, 77);
            this.groupBoxTransparent.TabIndex = 4;
            this.groupBoxTransparent.TabStop = false;
            this.groupBoxTransparent.Text = "便签透明度";
            // 
            // trackBarTransparent
            // 
            this.trackBarTransparent.Location = new System.Drawing.Point(11, 25);
            this.trackBarTransparent.Maximum = 100;
            this.trackBarTransparent.Minimum = 30;
            this.trackBarTransparent.Name = "trackBarTransparent";
            this.trackBarTransparent.Size = new System.Drawing.Size(97, 45);
            this.trackBarTransparent.TabIndex = 5;
            this.trackBarTransparent.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarTransparent.Value = 30;
            this.trackBarTransparent.ValueChanged += new System.EventHandler(this.trackBarTransparent_ValueChanged);
            // 
            // NoteOptionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxMinMaxNote);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.checkBoxAlwaysTop);
            this.Controls.Add(this.groupBoxTransparent);
            this.Controls.Add(this.groupBoxFont);
            this.Name = "NoteOptionPanel";
            this.Size = new System.Drawing.Size(410, 325);
            this.Load += new System.EventHandler(this.OptionPanel_Load);
            this.groupBoxFont.ResumeLayout(false);
            this.groupBoxFont.PerformLayout();
            this.groupBoxMinMaxNote.ResumeLayout(false);
            this.groupBoxMinMaxNote.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinWidth)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBoxTransparent.ResumeLayout(false);
            this.groupBoxTransparent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransparent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSelectFont;
        private System.Windows.Forms.Label labelDemoFont;
        private System.Windows.Forms.Label labelColorFont;
        private System.Windows.Forms.Label labelColorBackground;
        private System.Windows.Forms.Label labelMinHeight;
        private System.Windows.Forms.Label labelMinWidth;
        private System.Windows.Forms.Label labelMaxWidth;
        private System.Windows.Forms.Label labelMaxHeight;
        private System.Windows.Forms.CheckBox checkBoxAlwaysTop;
        private Dragonfly.Common.Controls.ColorComboBox colorComboBoxBackground;
        private Dragonfly.Common.Controls.ColorComboBox colorComboBoxFont;
        private System.Windows.Forms.GroupBox groupBoxFont;
        private System.Windows.Forms.GroupBox groupBoxMinMaxNote;
        private System.Windows.Forms.Label labelTransparentTip;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelHideAllNote;
        private Dragonfly.Common.Controls.HotkeyControl hotkeyControlShowAllNote;
        private Dragonfly.Common.Controls.HotkeyControl hotkeyControlHideAllNote;
        private System.Windows.Forms.Label labelShowAllNote;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownMinHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownMinWidth;
        private System.Windows.Forms.GroupBox groupBoxTransparent;
        private System.Windows.Forms.TrackBar trackBarTransparent;
        private System.Windows.Forms.CheckBox checkBoxUseRandomColor;
    }
}
