using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Note
{
    public enum NoteState { Normal, Small };

    public partial class NoteForm : Form
    {
        public delegate void EventHandleNoteDataChanged(NoteForm sender, EventArgs e);
        public event EventHandleNoteDataChanged NodeDataChanged;

        private NoteManager noteManager;
        private int nFade = 50;
        private Size minSize = new Size(150, 80);
        private Size maxSize = new Size(500,300);
        private NoteState noteState = NoteState.Normal;
        private const int INDENT = 10;
        private Point mouseOffset;  //to move the window
        private Size normalNoteSize;

        private bool bModified = false;

        public NoteForm()
        {
            InitializeComponent();

            this.labelCaption.AutoEllipsis = true;
            this.normalNoteSize = this.panelMain.Size;
            this.richTextBoxNote.TextChanged += new EventHandler(richTextBoxNote_TextChanged);
        }

        #region Properties

        public NoteManager NoteManager
        {
            get
            {
                return this.noteManager;
            }
            set
            {
                this.noteManager = value;
            }
        }


        public string Title
        {
            get { return this.labelCaption.Text; }
            set
            {
                this.labelCaption.Text = value;
                bModified = true;
            }
        }

        public string NoteText
        {
            get
            {
                string rc = this.richTextBoxNote.Rtf;
                if (rc == null)
                    return string.Empty;
                if (rc.EndsWith("\0"))
                    rc = rc.Substring(0, rc.Length - 1);
                return rc;
            }
            set
            {
                bModified = true;
                try { this.richTextBoxNote.Rtf = value; }
                catch { richTextBoxNote.Text = value; };
            }
        }

        public string NotePlainText
        {
            get
            {
                return this.richTextBoxNote.Text;
            }
            set
            {
                bModified = true;
                richTextBoxNote.Text = value;
            }
        }

        public Font NoteFont
        {
            get
            {
                return this.richTextBoxNote.Font;
            }
            set
            {
                bModified = true;
                this.Font = value;
                this.richTextBoxNote.Font = value;
            }
        }
        public Color NoteForeColor
        {
            get
            {
                return this.richTextBoxNote.ForeColor;
            }
            set
            {
                bModified = true;
                this.richTextBoxNote.ForeColor = value;
            }
        }
        public bool NoteModified
        {
            get
            {
                return bModified;
            }
            set
            {
                bModified = value;
                this.richTextBoxNote.Modified = value;
            }
        }

        public Color NoteBackColor
        {
            get
            {
                return this.panelMain.BackColor;
            }
            set
            {
                bModified = true;
                this.panelMain.BackColor = value;
                this.richTextBoxNote.BackColor = value;
                this.ResizeMe.BackColor = value;
                Color c = Color.FromArgb((int)(value.R * 0.9),
                                     (int)(value.G * 0.9),
                                     (int)(value.B * 0.9));
                this.hideButton.BackColor = c;
                this.showbarButton.BackColor = c;
                this.labelCaption.BackColor = c;
                this.panelCaption.BackColor = c;
            }
        }
        public int Fade
        {
            get
            {
                return nFade;
            }
            set
            {
                bModified = true;
                this.nFade = value;
                this.Opacity = (double)value / 100;
            }
        }

        public RichTextBox RichTextBox
        {
            get
            {
                return this.richTextBoxNote;
            }
        }

        public bool Hidden
        {
            get { return !this.Visible; }
            set 
            {
                this.Visible = !value; 
            }
        }

        public Size NoteSize
        {
            get
            {
                return this.normalNoteSize;
            }
            set
            {
                bModified = true;
                this.normalNoteSize = value;
                if (normalNoteSize.Width < this.minSize.Width)
                {
                    normalNoteSize.Width = this.minSize.Width;
                }
                if (normalNoteSize.Height < this.minSize.Height)
                {
                    normalNoteSize.Height = this.minSize.Height;
                }
                if (normalNoteSize.Width > this.maxSize.Width)
                {
                    normalNoteSize.Width = this.maxSize.Width;
                }
                if (normalNoteSize.Height > this.maxSize.Height)
                {
                    normalNoteSize.Height = this.maxSize.Height;
                }

                if (noteState == NoteState.Normal)
                {
                    this.Size = normalNoteSize;
                    this.panelMain.Size = normalNoteSize;
                }
                else
                {
                    this.Size = this.panelMain.Size = new Size(150, this.panelCaption.Size.Height);
                }

                this.labelCaption.MaximumSize = new Size(panelMain.Width - 40, labelCaption.Height);
            }
        }

        public new int Height
        {
            get { return this.normalNoteSize.Height; }
        }

        public new int Width
        {
            get { return this.normalNoteSize.Width; }
        }

        public NoteState NoteState
        {
            get { return this.noteState; }

            set
            {
                if (this.noteState != value)
                {
                    bModified = true;
                }

                this.noteState = value;

                if (noteState == NoteState.Normal)
                {
                    this.Size = this.panelMain.Size = normalNoteSize;
                    this.ResizeMe.Visible = true;
                    this.richTextBoxNote.Visible = true;
                }
                else if (noteState == NoteState.Small)
                {
                    this.ResizeMe.Visible = false;
                    this.richTextBoxNote.Visible = false;
                    this.Size = this.panelMain.Size = new Size(150, this.panelCaption.Size.Height); ;
                }
                this.labelCaption.MaximumSize = new Size(panelMain.Width - 40, labelCaption.Height);

            }
        }

        public Size NoteMinSize
        {
            get
            {
                return minSize;
            }
            set
            {
                this.minSize = value;
            }
        }

        public Size NoteMaxSize
        {
            get
            {
                return maxSize;
            }
            set
            {
                this.maxSize = value;
            }
        }

        #endregion

        private void NoteForm_Load(object sender, EventArgs e)
        {
            bModified = false;
            this.richTextBoxNote.Modified = false;
        }


        private void NoteForm_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1;
            this.hideButton.Visible = true;
            this.showbarButton.Visible = true;
        }

        private void NoteForm_Deactivate(object sender, EventArgs e)
        {
            this.Opacity = (double)nFade / 100;
            this.hideButton.Visible = false;
            this.showbarButton.Visible = false;

            OnNodeDataChanged();
        }

        private void OnNodeDataChanged()
        {
            if (this.richTextBoxNote.Modified || bModified)
            {
                if (NodeDataChanged != null)
                {
                    NodeDataChanged.Invoke(this, EventArgs.Empty);
                }

                bModified = false;
                this.richTextBoxNote.Modified = false;
            }
        }

        void richTextBoxNote_TextChanged(object sender, EventArgs e)
        {
            bModified = true;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBoxNote.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBoxNote.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBoxNote.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBoxNote.Copy();
        }


        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBoxNote.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "清除全部内容将删除便签内所有内容，并且不能撤消，确实要清除全部内容吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.richTextBoxNote.Clear();
                bModified = true;
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBoxNote.SelectAll();
        }
        private void insertPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "插入图片";
                dlg.DefaultExt = "jpg";
                dlg.Filter = "所有图片格式文件(*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif)|" +
                            "*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif|Bitmap文件(*.bmp)|*.bmp|" +
                            "GIF文件(*.gif)|*.gif|JPEG文件(*.jpg)|*.jpg;*.jpeg|PNG文件(*.png)|*.png|TIF文件(*.tif)|*.tif|所有文件(*.*)|*.*";
                dlg.FilterIndex = 1;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string strImagePath = dlg.FileName;
                        Image img = Image.FromFile(strImagePath);
                        Clipboard.SetDataObject(img);
                        DataFormats.Format df;
                        df = DataFormats.GetFormat(DataFormats.Bitmap);
                        if (this.richTextBoxNote.CanPaste(df))
                        {
                            this.richTextBoxNote.Paste(df);
                        }
                    }
                    catch
                    {
                        MessageBox.Show(this,"不能插入图片文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(richTextBoxNote.SelectionFont == null))
                {
                    Font currentFont = richTextBoxNote.SelectionFont;
                    FontStyle newFontStyle = richTextBoxNote.SelectionFont.Style ^ FontStyle.Underline;

                    richTextBoxNote.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "错误!");
            }
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // bold, italic, underline
            try
            {
                if (!(richTextBoxNote.SelectionFont == null))
                {
                    Font currentFont = richTextBoxNote.SelectionFont;
                    FontStyle newFontStyle = richTextBoxNote.SelectionFont.Style ^ FontStyle.Italic;

                    richTextBoxNote.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "错误!");
            }
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(richTextBoxNote.SelectionFont == null))
                {
                    Font currentFont = richTextBoxNote.SelectionFont;
                    FontStyle newFontStyle = richTextBoxNote.SelectionFont.Style ^ FontStyle.Bold;

                    richTextBoxNote.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "错误!");
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog dlg = new FontDialog())
            {
                if (richTextBoxNote.SelectionFont != null)
                    dlg.Font = richTextBoxNote.SelectionFont;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    richTextBoxNote.SelectionFont = dlg.Font;
                }
            }

        }

        private void fontcolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (ColorDialog dlg = new ColorDialog())
                {
                    dlg.Color = richTextBoxNote.SelectionColor;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        richTextBoxNote.SelectionColor = dlg.Color;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "错误!");
            }

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (ColorDialog dlg = new ColorDialog())
                {
                    dlg.Color = richTextBoxNote.SelectionColor;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        richTextBoxNote.SelectionBackColor = dlg.Color;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "错误!");
            }

        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBoxNote.SelectionAlignment = HorizontalAlignment.Left;

            leftToolStripMenuItem.Checked = true;
            centerToolStripMenuItem.Checked = false;
            rightToolStripMenuItem.Checked = false;
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBoxNote.SelectionAlignment = HorizontalAlignment.Center;

            leftToolStripMenuItem.Checked = false;
            centerToolStripMenuItem.Checked = true;
            rightToolStripMenuItem.Checked = false;
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBoxNote.SelectionAlignment = HorizontalAlignment.Right;

            leftToolStripMenuItem.Checked = false;
            centerToolStripMenuItem.Checked = false;
            rightToolStripMenuItem.Checked = true;
        }
        private void increaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBoxNote.SelectionIndent += INDENT;
        }

        private void decreaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBoxNote.SelectionIndent -= INDENT;
        }
        private void bulletsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBoxNote.SelectionBullet = !this.richTextBoxNote.SelectionBullet;
        }


        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxNote.ZoomFactor < 64.0f - 0.20f)
            {
                richTextBoxNote.ZoomFactor += 0.20f;
            }
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxNote.ZoomFactor > 0.16f + 0.20f)
            {
                richTextBoxNote.ZoomFactor -= 0.20f;
            }
        }

        private void zoomRealsizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxNote.ZoomFactor = 1f;
        }

        private void zoomHalfsizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxNote.ZoomFactor = 0.5f;
        }
        private void deleteNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteNote(); 
        }

        public void deleteNote()
        {
            DialogResult result = MessageBox.Show(this, "确实要删除该便签吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.NoteManager.RemoveNote(this);
            }
        }

        private void topToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
            this.topToolStripMenuItem.Checked = this.TopMost;
        }


        private void hideNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bModified = true;
            this.Visible = false;
        }

        private void richTextBoxNote_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBoxNote.SelectionFont != null)
            {
                this.boldToolStripMenuItem.Checked = richTextBoxNote.SelectionFont.Bold;
                this.italicToolStripMenuItem.Checked = richTextBoxNote.SelectionFont.Italic;
                this.underlineToolStripMenuItem.Checked = richTextBoxNote.SelectionFont.Underline;


                switch (richTextBoxNote.SelectionAlignment)
                {
                    case HorizontalAlignment.Left:
                        leftToolStripMenuItem.Checked = true;
                        centerToolStripMenuItem.Checked = false;
                        rightToolStripMenuItem.Checked = false;
                        break;

                    case HorizontalAlignment.Center:
                        leftToolStripMenuItem.Checked = false;
                        centerToolStripMenuItem.Checked = true;
                        rightToolStripMenuItem.Checked = false;
                        break;

                    case HorizontalAlignment.Right:
                        leftToolStripMenuItem.Checked = false;
                        centerToolStripMenuItem.Checked = false;
                        rightToolStripMenuItem.Checked = true;
                        break;
                }

                bulletsToolStripMenuItem.Checked = richTextBoxNote.SelectionBullet;

            }

        }
        private void toolStripTextBoxNoteTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ContextMenuStrip.Close();
            }
        }

        private void toolStripTextBoxNoteTitle_TextChanged(object sender, EventArgs e)
        {
            this.labelCaption.Text = toolStripTextBoxNoteTitle.Text;

            this.bModified = true;
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            this.undoToolStripMenuItem.Enabled = this.richTextBoxNote.CanUndo;
            this.redoToolStripMenuItem.Enabled = this.richTextBoxNote.CanRedo;

            this.cutToolStripMenuItem.Enabled = (this.richTextBoxNote.SelectionLength > 0);
            this.copyToolStripMenuItem.Enabled = (this.richTextBoxNote.SelectionLength > 0);
            this.pasteToolStripMenuItem.Enabled = this.richTextBoxNote.CanPaste(DataFormats.GetFormat(DataFormats.Rtf));

            this.topToolStripMenuItem.Checked = this.TopMost;
            this.toolStripTextBoxNoteTitle.Text = this.labelCaption.Text;
        }

        private void NoteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    this.Visible = false;
                    break;
            }

            OnNodeDataChanged();
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            bModified = true;
            this.Visible = false;
        }

        private void showbarButton_Click(object sender, EventArgs e)
        {
            if (NoteState == NoteState.Normal)
            {
                NoteState = NoteState.Small;
            }
            else
            {
                NoteState = NoteState.Normal;
            }

        }


        private Point scaleBasePoint;

        private void ResizeMe_MouseDown(object sender, MouseEventArgs e)
        {
            scaleBasePoint = System.Windows.Forms.Cursor.Position;

        }

        private void ResizeMe_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                Point curPosition = System.Windows.Forms.Cursor.Position;

                int newWidth = this.NoteSize.Width + curPosition.X - scaleBasePoint.X;
                int newHeight = this.NoteSize.Height + curPosition.Y - scaleBasePoint.Y;

                if (newWidth < this.minSize.Width)
                {
                    newWidth = this.minSize.Width;
                    curPosition.X = this.scaleBasePoint.X;
                }
                if (newHeight < this.minSize.Height)
                {
                    newHeight = this.minSize.Height;
                    curPosition.Y = this.scaleBasePoint.Y;
                }
                if (newWidth > this.maxSize.Width)
                {
                    newWidth = this.maxSize.Width;
                    curPosition.X = this.scaleBasePoint.X;
                }

                if (newHeight > this.maxSize.Height)
                {
                    newHeight = this.maxSize.Height;
                    curPosition.Y = this.scaleBasePoint.Y;
                }

                this.NoteSize = new Size(newWidth, newHeight);
                this.scaleBasePoint = curPosition;
                bModified = true;
            }
        }


        private void NoteForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender == this) //the form itself
            {
                mouseOffset = new Point(-e.X, -e.Y);
            }
            else //a other control which also sends this event
            {
                Control control = (Control)sender;
                if (control.Parent != this)
                    mouseOffset = new Point(-e.X - control.Bounds.X - control.Parent.Bounds.X, -e.Y - control.Bounds.Y - control.Parent.Bounds.Y);
                else
                    mouseOffset = new Point(-e.X - control.Bounds.X, -e.Y - control.Bounds.Y);
            }

            panelMain.Focus();
        }


        private void NoteForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePosition = Control.MousePosition;
                mousePosition.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePosition;
                bModified = true;
            }

        }

        private void NoteForm_MouseHover(object sender, EventArgs e)
        {
            Activate();
        }

        private void NoteForm_DoubleClick(object sender, EventArgs e)
        {
            if (NoteState == NoteState.Normal)
            {
                NoteState = NoteState.Small;
            }
            else
            {
                NoteState = NoteState.Normal;
            }

        }

        public new void CenterToScreen()
        {
            base.CenterToScreen();
        }

  

    }
}
