using System;
using System.Windows.Forms;
using Dragonfly.Common.Plugin;
using Dragonfly.Common.Utils;
using Microsoft.Win32;

namespace Dragonfly.Main
{
    public partial class MainAppForm : Form
    {
        private bool bNotifyIconExitApp = false;
        private OptionForm optionDialog = null;
        private PasswordBox passwordDialog = null;
        private AboutBox aboutDialog = null;
        private PluginManager pluginManager;

        public MainAppForm()
        {
            RegistryInit();

            InitializeComponent();

            optionDialog = new OptionForm();
            passwordDialog = new PasswordBox();
            aboutDialog = new AboutBox();

            this.Text = "［蜻蜓］工具";

            InitPlugIns();
        }

        public TabControl MainTab
        {
            get { return this.tabControlMain; }
        }

        private void MainAppForm_Load(object sender, EventArgs e)
        {
            if (this.menuStripMain.Items.Count == 0)
            {
                this.menuStripMain.Visible = false;
            }
        }

        private void RegistryInit()
        {
            try
            {
                RegistryUtils reg = new RegistryUtils();
                string autorun = reg.GetStringValue(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "DragonflyNote");
                if (string.IsNullOrEmpty(autorun))
                {
                    autorun = reg.GetStringValue(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "DragonflyNote");
                    if (string.IsNullOrEmpty(autorun))
                    {
                        autorun = reg.GetStringValue(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\policies\\Explorer\\Run", "DragonflyNote");
                    }
                }
                if (string.IsNullOrEmpty(autorun) || autorun != Application.ExecutablePath)
                {
                    if (!reg.SetStringValue(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\policies\\Explorer\\Run", "DragonflyNote", Application.ExecutablePath))
                        if (!reg.SetStringValue(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "DragonflyNote", Application.ExecutablePath))
                            if (!reg.SetStringValue(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "DragonflyNote", Application.ExecutablePath))
                                System.Diagnostics.Debug.WriteLine("Reg autostart error!");
                }

            }
            catch
            {
            }
        }

        private void InitPlugIns()
        {
            pluginManager = new PluginManager();
            pluginManager.LoadSettings();

            IPlugIn[] plugIns = pluginManager.PlugIns;
            foreach (IPlugIn plugIn in plugIns)
            {
                ToolStripItem notifyIconMenu = plugIn.NotifyIconMenu;
                if (notifyIconMenu != null)
                {
                    this.notifyIconMain.ContextMenuStrip.Items.Insert(0, notifyIconMenu);
                }
                PlugInMainPanel panel = plugIn.MainPanel;

                if (panel != null)
                {
                    TabPage page = new TabPage(plugIn.Caption);
                    panel.Dock = DockStyle.Fill;
                    page.Controls.Add(panel);
                    this.MainTab.TabPages.Add(page);
                }
                ToolStripItem mainMenu = plugIn.MainMenu;
                if (mainMenu != null)
                {
                    this.MainMenuStrip.Items.Add(mainMenu);
                }
            }
        }

        private void MainAppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((!bNotifyIconExitApp) && (e.CloseReason == CloseReason.UserClosing))
            {
                if (!this.notifyIconMain.Visible)
                    this.notifyIconMain.Visible = true;

                if (this.Visible)
                    this.Hide();
                e.Cancel = true;
            }
        }

        private void MainAppForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.notifyIconMain.Visible)
            {
                this.notifyIconMain.Visible = false;
                this.notifyIconMain.Dispose();
            }
            pluginManager.ClosePlugins();
        }

        private void MainAppForm_Shown(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            if (this.Visible)
                this.Hide();
        }

        private void toolStripMenuExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "确实要退出［蜻蜓］软件吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                bNotifyIconExitApp = true;
                this.Close();
            }
        }

        private void toolStripMenuAbout_Click(object sender, EventArgs e)
        {
            if (aboutDialog.Visible)
                aboutDialog.Focus();
            else
            {
                aboutDialog = new AboutBox();
                aboutDialog.Show(this);
            }
        }

        private void toolStripMenuOption_Click(object sender, EventArgs e)
        {
            if (optionDialog.Visible)
            {
                optionDialog.Focus();
                return;
            }

            optionDialog = new OptionForm();

            IPlugIn[] plugIns = pluginManager.PlugIns;
            foreach (IPlugIn plugIn in plugIns)
            {
                PlugInOptionPanel panel = plugIn.OptionPanel;
                if (panel == null)
                    continue;
                TabPage page = new TabPage(plugIn.Caption);
                panel.Dock = DockStyle.Fill;
                page.Controls.Add(panel);
                optionDialog.OptionTab.TabPages.Add(page);
            }

            DialogResult ret = optionDialog.ShowDialog(this);
            if (ret == DialogResult.OK)
            {
                foreach (IPlugIn plugIn in plugIns)
                {
                    PlugInOptionPanel panel = plugIn.OptionPanel;
                    if (panel == null)
                        continue;
                    panel.OptionsUpdated = true;
                }

                this.pluginManager.SaveSettings();
            }
        }

        private void toolStripMenuShowMainForm_Click(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                this.Hide();
                this.ShowInTaskbar = false;
                return;
            }

            if (passwordDialog.Visible)
                passwordDialog.Focus();
            else
            {
                passwordDialog = new PasswordBox();
                DialogResult result = passwordDialog.ShowDialog(this);
                if(result != DialogResult.OK)
                {
                    return;
                }
            }

            this.Visible = true;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();

        }


        private void notifyIconMain_DoubleClick(object sender, EventArgs e)
        {
            toolStripMenuShowMainForm.PerformClick();
        }

    }
}
