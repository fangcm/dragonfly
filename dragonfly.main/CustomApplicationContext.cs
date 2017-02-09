using System;
using System.Windows.Forms;

namespace Dragonfly.Main
{
    internal class CustomApplicationContext : ApplicationContext
    {
        NotifyIcon notifyIcon = new NotifyIcon();
        MainAppForm mainAppForm = new MainAppForm();

        public CustomApplicationContext()
        {
            MenuItem menuShowMainForm = new MenuItem("主程序...", new EventHandler(ShowMainForm_Click));
            MenuItem menuExit = new MenuItem("退出", new EventHandler(ExitApp_Click));

            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { menuShowMainForm, menuExit }); ;
            notifyIcon.Icon = global::Dragonfly.Main.Properties.Resources.NotifyIcon;
            notifyIcon.Text = "便签（蜻蜓）";
            notifyIcon.Visible = true;
            notifyIcon.DoubleClick += new EventHandler(notifyIcon_DoubleClick);

            mainAppForm.Hide();
        }

        void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        void ShowMainForm_Click(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        void ShowMainForm()
        {
            if (!mainAppForm.Visible)
            {
                mainAppForm.Show();
            }
            mainAppForm.Activate();
        }

        void ExitApp_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确实要退出［蜻蜓］软件吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                notifyIcon.Visible = false;
                notifyIcon.Dispose();
                mainAppForm.Dispose();
                Application.Exit();
            }

        }

    }
}
