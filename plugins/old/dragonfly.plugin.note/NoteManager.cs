using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Dragonfly.Common.Plugin;
using Dragonfly.Common.Utils;

namespace Dragonfly.Plugin.Note
{
    public class NoteManager : IPlugIn
    {
        private string sSettingsFileName;
        private ArrayList noteArray = new ArrayList();

        public Font defaultFont = new Font("SimSun", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
        public Color colorText = Color.Black;
        public Color colorBackground = Color.Khaki;
        public bool bUseRadomBackColor = true;
        public int nFade = 50;

        public bool bAlwaysStayOnTop = true;

        public int nMinHeight = 80;
        public int nMinWidth = 150;
        public int nMaxHeight = 300;
        public int nMaxWidth = 500;

        public Keys hotkeyShowAllNotes = Keys.F11;
        public Keys hotkeyModifiersShowAllNotes = Keys.Alt;
        public Keys hotkeyHideAllNotes = Keys.F12;
        public Keys hotkeyModifiersHideAllNotes = Keys.Alt;

        private Dragonfly.Common.Controls.SystemHotkey systemHotkeyHideAll;
        private Dragonfly.Common.Controls.SystemHotkey systemHotkeyShowAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewNote;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuHideAllNotes;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuShowAllNotes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

        private NoteOptionPanel optionDlg;
        private NoteMainPanel mainPanel;

        public NoteManager()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = appDataPath + "\\fangcm\\";
            DirectoryUtils.CreateDirectory(path);
            this.sSettingsFileName = path + "NoteSettings.xml";

            this.systemHotkeyHideAll = new Dragonfly.Common.Controls.SystemHotkey();
            this.systemHotkeyShowAll = new Dragonfly.Common.Controls.SystemHotkey();
            this.toolStripMenuNotifyIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuNewNote = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuShowAllNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuHideAllNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();

            this.systemHotkeyHideAll.Pressed += new System.EventHandler(this.systemHotkeyHideAll_Pressed);
            this.systemHotkeyShowAll.Pressed += new System.EventHandler(this.systemHotkeyShowAll_Pressed);
            // 
            // toolStripMenuNotifyIcon
            // 
            this.toolStripMenuNotifyIcon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuNewNote,
            this.toolStripSeparator1,
            this.toolStripMenuShowAllNotes,
            this.toolStripMenuHideAllNotes});
            this.toolStripMenuNotifyIcon.Name = "toolStripMenuNotifyIcon";
            this.toolStripMenuNotifyIcon.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuNotifyIcon.Text = "便签";
            // 
            // toolStripMenuNewNote
            // 
            this.toolStripMenuNewNote.Image = global::Dragonfly.Plugin.Note.Properties.Resources.addnote;
            this.toolStripMenuNewNote.ImageTransparentColor = System.Drawing.Color.Teal;
            this.toolStripMenuNewNote.Name = "toolStripMenuNewNote";
            this.toolStripMenuNewNote.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuNewNote.Text = "新建便签(&N)";
            this.toolStripMenuNewNote.Click += new System.EventHandler(this.toolStripMenuNewNote_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripMenuShowAllNotes
            // 
            this.toolStripMenuShowAllNotes.Name = "toolStripMenuShowAllNotes";
            this.toolStripMenuShowAllNotes.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuShowAllNotes.Text = "显示全部便签";
            this.toolStripMenuShowAllNotes.Click += new System.EventHandler(this.toolStripMenuShowAllNotes_Click);
            // 
            // toolStripMenuHideAllNotes
            // 
            this.toolStripMenuHideAllNotes.Name = "toolStripMenuHideAllNotes";
            this.toolStripMenuHideAllNotes.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuHideAllNotes.Text = "隐藏全部便签";
            this.toolStripMenuHideAllNotes.Click += new System.EventHandler(this.toolStripMenuHideAllNotes_Click);

        }

        ~NoteManager()
        {
            RemoveAllNotes();
        }


        private NoteForm CreateNote()
        {
            return CreateNote(-1,-1,150, 200);
        }

        private NoteForm CreateNote(int nTop, int nLeft, int nHeight, int nWidth)
        {
            Random r = new Random();
            Color backColor;
            if(bUseRadomBackColor)
                backColor = ColorUtils.HsbToRgb(r.Next(255)/360D, r.Next(192, 255)/360D, r.Next(192, 255)/360D);
            else
                backColor = this.colorBackground;

            return CreateNote(nTop, nLeft, nHeight, nWidth, backColor, NoteState.Normal, false);
        }

        private NoteForm CreateNote(int nTop, int nLeft, int nHeight, int nWidth, Color backColor, NoteState state, bool bHidden)
        {
            NoteForm note = new NoteForm();

            note.StartPosition = FormStartPosition.Manual;
            note.Location = new Point(-1000, -1000);
            note.Fade = nFade;
            note.Show();

            note.NoteManager = this;
            note.NoteFont = defaultFont;
            note.NoteForeColor = colorText;
            note.NoteBackColor = backColor;
            note.TopMost = bAlwaysStayOnTop;
            note.NoteMinSize = new Size(nMinWidth, nMinHeight);
            note.NoteMaxSize = new Size(nMaxWidth, nMaxHeight);

            note.Size = new Size(nWidth, nHeight);
            note.NoteState = state;
            note.Hidden = bHidden;

            if (nTop == -1 || nLeft == -1)
                note.CenterToScreen();
            else
                note.Location = new Point(nLeft, nTop);

            noteArray.Add(note);
            return note;
        }

        public void RemoveNote(NoteForm note)
        {
            if (noteArray.Contains(note))
            {
                noteArray.Remove(note);
                note.Close();
                note.Dispose();

                SaveNoteSettings();
            }
        }

        private void RemoveAllNotes()
        {
            foreach (NoteForm note in noteArray)
            {
                note.Close();
            }
            noteArray.Clear();
        }

        private bool ShowAllNotes
        {
            set
            {
                foreach (NoteForm note in noteArray)
                {
                    note.Hidden= !value;
                }
                SaveNoteSettings();
            }
        }

        private void UpdateNotesOptions()
        {
            foreach (NoteForm note in noteArray)
            {
                note.NoteFont = defaultFont;
                note.NoteForeColor = colorText;
                note.Fade = nFade;
                note.TopMost = bAlwaysStayOnTop;
                note.NoteMinSize = new Size(nMinWidth, nMinHeight);
                note.NoteMaxSize = new Size(nMaxWidth, nMaxHeight);

                note.NoteModified = false;

            }

            SaveNoteSettings();
        }
        
        private void toolStripMenuNewNote_Click(object sender, EventArgs e)
        {
            NoteForm note = CreateNote();
            note.NoteModified = false;

            note.NodeDataChanged += new NoteForm.EventHandleNoteDataChanged(note_NodeDataChanged);
        }

        private void toolStripMenuShowAllNotes_Click(object sender, EventArgs e)
        {
            ShowAllNotes = true;
        }

        private void toolStripMenuHideAllNotes_Click(object sender, EventArgs e)
        {
            ShowAllNotes = false;
        }

        private void systemHotkeyHideAll_Pressed(object sender, EventArgs e)
        {
            toolStripMenuHideAllNotes.PerformClick();
        }

        private void systemHotkeyShowAll_Pressed(object sender, EventArgs e)
        {
            toolStripMenuShowAllNotes.PerformClick();
        }

        private void note_NodeDataChanged(NoteForm sender, EventArgs e)
        {
            SaveNoteSettings();
        }


        private void optionDlg_OptionsChanged(PlugInOptionPanel sender, EventArgs e)
        {
            NoteOptionPanel optionDlg = (NoteOptionPanel)sender;
            this.defaultFont = optionDlg.NoteFont;
            this.colorText = optionDlg.NoteForeColor;
            this.colorBackground = optionDlg.NoteBackColor;
            this.nFade = optionDlg.NoteFade;
            this.bAlwaysStayOnTop = optionDlg.NoteAlwaysStayOnTop;
            this.bUseRadomBackColor = optionDlg.NoteUseRandomColor;
            this.nMinHeight = optionDlg.NoteMinHeight;
            this.nMinWidth = optionDlg.NoteMinWidth;
            this.nMaxHeight = optionDlg.NoteMaxHeight;
            this.nMaxWidth = optionDlg.NoteMaxWidth;
            this.hotkeyShowAllNotes = optionDlg.HotkeyShowAllNotes;
            this.hotkeyModifiersShowAllNotes = optionDlg.HotkeyModifiersShowAllNotes;
            this.hotkeyHideAllNotes = optionDlg.HotkeyHideAllNotes;
            this.hotkeyModifiersHideAllNotes = optionDlg.HotkeyModifiersHideAllNotes;

            UpdateNotesOptions();

            this.systemHotkeyHideAll.SetHotkey(hotkeyModifiersHideAllNotes, hotkeyHideAllNotes);
            this.systemHotkeyShowAll.SetHotkey(hotkeyModifiersShowAllNotes, hotkeyShowAllNotes);
        }

        private bool LoadNoteSettings()
        {
            XmlDocument xmlDocument = XmlHelper.Load(sSettingsFileName);
            if (xmlDocument == null)
            {
                return false;
            }

            XmlNodeList xmlNodelist = xmlDocument.SelectNodes("/NoteWndSettings/NoteWnd");
            foreach (XmlNode xmlNode in xmlNodelist)
            {
                int nTop = XmlHelper.GetParamValue(xmlNode, "top", -1);
                int nLeft = XmlHelper.GetParamValue(xmlNode, "left", -1);
                int nHeight = XmlHelper.GetParamValue(xmlNode, "height", this.nMinHeight);
                int nWidth = XmlHelper.GetParamValue(xmlNode, "width", this.nMinWidth);
                Color noteBackColor = XmlHelper.GetParamValue(xmlNode, "backcolor", this.colorBackground);
                bool bHidden = XmlHelper.GetParamValue(xmlNode, "bHidden", false);
                NoteState state = (NoteState)XmlHelper.GetParamValue(xmlNode, "NoteState", (int)NoteState.Normal);
                string noteText = XmlHelper.GetElementText(xmlNode, "NoteText");
                string noteTitle = XmlHelper.GetElementText(xmlNode, "NoteTitle");

                NoteForm note = CreateNote(nTop, nLeft, nHeight, nWidth, noteBackColor, state, bHidden);
                note.NoteText = noteText;
                note.Title = noteTitle;
                note.NoteModified = false;
                note.NodeDataChanged += new NoteForm.EventHandleNoteDataChanged(note_NodeDataChanged);
            }

            return true;
        }


        private bool SaveNoteSettings()
        {
            XmlDocument xmlDocument = XmlHelper.Load(sSettingsFileName);
            if (xmlDocument == null)
            {
                xmlDocument = new XmlDocument();
                XmlDeclaration xmldecl = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = xmlDocument.DocumentElement;
                xmlDocument.AppendChild(xmldecl);

                XmlNode node = xmlDocument.CreateNode("element", "NoteWndSettings", "");
                xmlDocument.AppendChild(node);
            }

            XmlNode xmlRoot = xmlDocument.SelectSingleNode("/NoteWndSettings");
            xmlRoot.RemoveAll();

            foreach (NoteForm note in noteArray)
            {
                XmlNode xmlNode = xmlDocument.CreateNode("element", "NoteWnd", "");
                XmlHelper.PutParamValue(xmlNode, "top", note.Top);
                XmlHelper.PutParamValue(xmlNode, "left", note.Left);
                XmlHelper.PutParamValue(xmlNode, "height", note.NoteSize.Height);
                XmlHelper.PutParamValue(xmlNode, "width", note.NoteSize.Width);
                XmlHelper.PutParamValue(xmlNode, "backcolor", note.NoteBackColor);
                XmlHelper.PutParamValue(xmlNode, "bHidden", note.Hidden);
                XmlHelper.PutParamValue(xmlNode, "NoteState", (int)note.NoteState);
                XmlHelper.PutElementText(xmlNode, "NoteText", note.NoteText);
                XmlHelper.PutElementText(xmlNode, "NoteTitle", note.Title);
                xmlRoot.AppendChild(xmlNode);
            }
            return XmlHelper.Save(sSettingsFileName, xmlDocument);
        }

        public string Name { get { return "DragonflyNote"; } }
        public string Caption { get { return "便签"; } }
        public string Description { get { return "便签（蜻蜓）"; } }
        public string Autor { get { return "fangcm"; } }
        public string Version { get { return "1.0.0"; } }

        public void Initialize(XmlNode settings)
        {
            if (settings != null && settings.Name == "DragonflyNote")
            {
                XmlNode xmlDefault = settings.SelectSingleNode("default");

                this.defaultFont = XmlHelper.GetParamValue(xmlDefault, "defaultFont", this.defaultFont);
                this.colorText = XmlHelper.GetParamValue(xmlDefault, "colorText", this.colorText);
                this.colorBackground = XmlHelper.GetParamValue(xmlDefault, "colorBackground", this.colorBackground);
                this.nFade = XmlHelper.GetParamValue(xmlDefault, "nFade", this.nFade);
                this.bAlwaysStayOnTop = XmlHelper.GetParamValue(xmlDefault, "bAlwaysStayOnTop", this.bAlwaysStayOnTop);
                this.bUseRadomBackColor = XmlHelper.GetParamValue(xmlDefault, "bUseRadomBackColor", this.bUseRadomBackColor);
                this.nMinHeight = XmlHelper.GetParamValue(xmlDefault, "nMinHeight", this.nMinHeight);
                this.nMinWidth = XmlHelper.GetParamValue(xmlDefault, "nMinWidth", this.nMinWidth);
                this.nMaxHeight = XmlHelper.GetParamValue(xmlDefault, "nMaxHeight", this.nMaxHeight);
                this.nMaxWidth = XmlHelper.GetParamValue(xmlDefault, "nMaxWidth", this.nMaxWidth);
                this.hotkeyShowAllNotes = (Keys)XmlHelper.GetParamValue(xmlDefault, "hotkeyShowAllNotes", (int)this.hotkeyShowAllNotes);
                this.hotkeyModifiersShowAllNotes = (Keys)XmlHelper.GetParamValue(xmlDefault, "hotkeyModifiersShowAllNotes", (int)this.hotkeyModifiersShowAllNotes);
                this.hotkeyHideAllNotes = (Keys)XmlHelper.GetParamValue(xmlDefault, "hotkeyHideAllNotes", (int)this.hotkeyHideAllNotes);
                this.hotkeyModifiersHideAllNotes = (Keys)XmlHelper.GetParamValue(xmlDefault, "hotkeyModifiersHideAllNotes", (int)this.hotkeyModifiersHideAllNotes);

            }

            this.systemHotkeyHideAll.SetHotkey(this.hotkeyModifiersHideAllNotes, this.hotkeyHideAllNotes);
            this.systemHotkeyShowAll.SetHotkey(this.hotkeyModifiersShowAllNotes, this.hotkeyShowAllNotes);

            LoadNoteSettings();

        }

        public void Dispose()
        {
            RemoveAllNotes();
        }

        public XmlNode GetOptionSettings(XmlDocument xmlDocument)
        {
            if (xmlDocument == null)
                return null;

            XmlNode xmlRoot = xmlDocument.CreateNode("element", "DragonflyNote", "");

            XmlNode xmlDefault = xmlDocument.CreateNode("element", "default", "");
            XmlHelper.PutParamValue(xmlDefault, "defaultFont", this.defaultFont);
            XmlHelper.PutParamValue(xmlDefault, "colorText", this.colorText);
            XmlHelper.PutParamValue(xmlDefault, "colorBackground", this.colorBackground);
            XmlHelper.PutParamValue(xmlDefault, "nFade", this.nFade);
            XmlHelper.PutParamValue(xmlDefault, "bAlwaysStayOnTop", this.bAlwaysStayOnTop);
            XmlHelper.PutParamValue(xmlDefault, "bUseRadomBackColor", this.bUseRadomBackColor);
            XmlHelper.PutParamValue(xmlDefault, "nMinHeight", this.nMinHeight);
            XmlHelper.PutParamValue(xmlDefault, "nMinWidth", this.nMinWidth);
            XmlHelper.PutParamValue(xmlDefault, "nMaxHeight", this.nMaxHeight);
            XmlHelper.PutParamValue(xmlDefault, "nMaxWidth", this.nMaxWidth);
            XmlHelper.PutParamValue(xmlDefault, "hotkeyShowAllNotes", (int)this.hotkeyShowAllNotes);
            XmlHelper.PutParamValue(xmlDefault, "hotkeyModifiersShowAllNotes", (int)this.hotkeyModifiersShowAllNotes);
            XmlHelper.PutParamValue(xmlDefault, "hotkeyHideAllNotes", (int)this.hotkeyHideAllNotes);
            XmlHelper.PutParamValue(xmlDefault, "hotkeyModifiersHideAllNotes", (int)this.hotkeyModifiersHideAllNotes); 
            xmlRoot.AppendChild(xmlDefault);

            return xmlRoot;
        }

        public PlugInOptionPanel OptionPanel
        {
            get
            {
                if (optionDlg == null || optionDlg.IsDisposed)
                {
                    this.optionDlg = new NoteOptionPanel();
                    this.optionDlg.OptionsChanged += new PlugInOptionPanel.EventHandleOptionsChanged(optionDlg_OptionsChanged);

                    this.optionDlg.NoteFont = this.defaultFont;
                    this.optionDlg.NoteForeColor = this.colorText;
                    this.optionDlg.NoteBackColor = this.colorBackground;
                    this.optionDlg.NoteFade = this.nFade;
                    this.optionDlg.NoteAlwaysStayOnTop = this.bAlwaysStayOnTop;
                    this.optionDlg.NoteUseRandomColor = this.bUseRadomBackColor;
                    this.optionDlg.NoteMinHeight = this.nMinHeight;
                    this.optionDlg.NoteMinWidth = this.nMinWidth;
                    this.optionDlg.NoteMaxHeight = this.nMaxHeight;
                    this.optionDlg.NoteMaxWidth = this.nMaxWidth;
                    this.optionDlg.HotkeyShowAllNotes = this.hotkeyShowAllNotes;
                    this.optionDlg.HotkeyModifiersShowAllNotes = this.hotkeyModifiersShowAllNotes;
                    this.optionDlg.HotkeyHideAllNotes = this.hotkeyHideAllNotes;
                    this.optionDlg.HotkeyModifiersHideAllNotes = this.hotkeyModifiersHideAllNotes;
                }
                return optionDlg;
            }

        }


        public PlugInMainPanel MainPanel
        {
            get
            {
                if (mainPanel == null || mainPanel.IsDisposed)
                {
                    this.mainPanel = new NoteMainPanel();
                    this.mainPanel.NoteItems = this.noteArray;
                }
                return mainPanel;
            }
        }
        public ToolStripItem MainMenu
        {
            get
            {
                return ((NoteMainPanel)MainPanel).ToolStripMenuMain;
            }
        }
        public ToolStripItem NotifyIconMenu
        {
            get
            {
                return this.toolStripMenuNotifyIcon;
            }
        }
    }
}
