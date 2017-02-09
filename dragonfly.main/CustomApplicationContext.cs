using System;
using System.Windows.Forms;

namespace Dragonfly.Main
{
    internal class CustomApplicationContext : ApplicationContext
    {
        NotifyIcon notifyIcon = new NotifyIcon();
        MainAppForm mainAppForm = new MainAppForm();
        PasswordBox passwordDialog = null;

        public CustomApplicationContext()
        {
            MenuItem menuShowMainForm = new MenuItem("［蜻蜓］工具...", new EventHandler(ShowMainForm_Click));
            MenuItem menuExit = new MenuItem("退出", new EventHandler(ExitApp_Click));

            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { menuShowMainForm, menuExit }); ;
            notifyIcon.Icon = global::Dragonfly.Main.Properties.Resources.NotifyIcon;
            notifyIcon.Text = "［蜻蜓］工具";
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
                if (passwordDialog == null || passwordDialog.IsDisposed)
                {
                    passwordDialog = new PasswordBox();
                    passwordDialog.ResetPassword();
                    if (passwordDialog.ShowDialog() == DialogResult.OK)
                    {
                        mainAppForm.Show();
                        mainAppForm.Activate();
                    }
                    passwordDialog.Dispose();

                }
                else
                {
                    passwordDialog.ResetPassword();
                    passwordDialog.Activate();
                }
                return;

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
                
                System.Environment.Exit(0);
            }

        }

    }
}
