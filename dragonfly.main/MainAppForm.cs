using Dragonfly.Common.Plugin;
using Dragonfly.Common.Utils;
using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Dragonfly.Main
{
    public partial class MainAppForm : Form
    {
        private PluginManager pluginManager = null;

        public MainAppForm()
        {
            SetRegistryAutoStart();

            InitializeComponent();
            this.Text = "［蜻蜓］工具";

            InitPlugIns();
        }

        private void SetRegistryAutoStart()
        {
            try
            {
                RegistryUtils reg = new RegistryUtils();
                string autorunCurrentUser = reg.GetStringValue(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "DragonflyNote");
                string autorunLocalMachine = reg.GetStringValue(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "DragonflyNote");
                string autorunExplorer = reg.GetStringValue(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\policies\\Explorer\\Run", "DragonflyNote");

                bool bStarted = false;
                if (string.IsNullOrWhiteSpace(autorunCurrentUser) || !string.Equals(autorunCurrentUser, Application.ExecutablePath))
                {
                    bStarted = reg.SetStringValue(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "DragonflyNote", Application.ExecutablePath);
                }
                else
                {
                    bStarted = true;
                }

                if (bStarted)
                {
                    if (autorunLocalMachine != null)
                    {
                        reg.DeleteValue(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "DragonflyNote");
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(autorunLocalMachine) || !string.Equals(autorunLocalMachine, Application.ExecutablePath))
                    {
                        bStarted = reg.SetStringValue(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "DragonflyNote", Application.ExecutablePath);
                    }
                    else
                    {
                        bStarted = true;
                    }
                }

                if (bStarted)
                {
                    if (autorunExplorer != null)
                    {
                        reg.DeleteValue(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\policies\\Explorer\\Run", "DragonflyNote");
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(autorunExplorer) || !string.Equals(autorunExplorer, Application.ExecutablePath))
                    {
                        reg.SetStringValue(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\policies\\Explorer\\Run", "DragonflyNote", Application.ExecutablePath);
                    }
                }

            }
            catch (Exception e)
            {
                Logger.error("MainAppForm", "Registry Init error . " + e.Message);
            }
        }

        private void InitPlugIns()
        {
            if (pluginManager != null)
            {
                return;
            }

            pluginManager = new PluginManager();

            IPlugin[] plugIns = pluginManager.PlugIns;
            foreach (IPlugin plugIn in plugIns)
            {
                UserControl pluginPanel = plugIn.PluginPanel;

                if (pluginPanel != null)
                {
                    TabPage page = new TabPage(plugIn.Caption);
                    pluginPanel.Dock = DockStyle.Fill;
                    page.Controls.Add(pluginPanel);
                    this.tabControlMain.TabPages.Add(page);
                }
            }
        }

        private void MainAppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            pluginManager.ClosePlugins();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            SetRegistryAutoStart();
        }
    }
}
