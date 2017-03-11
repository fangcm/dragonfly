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
            RegistryInit();

            InitializeComponent();
            this.Text = "［蜻蜓］工具";

            InitPlugIns();
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
            catch(Exception e)
            {
                TraceLog.error(e.Message);
            }
        }

        private void InitPlugIns()
        {
            if(pluginManager != null)
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
            RegistryInit();
        }
    }
}
