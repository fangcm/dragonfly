using Dragonfly.Common.Utils;
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

            MenuItem[] menus = null;
            if (AppConfig.GetBoolean("MenuExit", false))
            {
                MenuItem menuExit = new MenuItem("退出", new EventHandler(ExitApp_Click));
                menus = new MenuItem[] { menuShowMainForm, menuExit };
            }
            else
            {
                menus = new MenuItem[] { menuShowMainForm };
            }

            notifyIcon.ContextMenu = new ContextMenu(menus); ;
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
                if (passCheck())
                {
                    mainAppForm.Show();
                    mainAppForm.Activate();
                }
                else
                {
                    return;
                }
            }
            else
            {
                mainAppForm.Activate();
            }
        }

        void ExitApp_Click(object sender, EventArgs e)
        {
            if (!passCheck())
            {
                return;
            }
            DialogResult result = MessageBox.Show("确实要退出［蜻蜓］软件吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                notifyIcon.Visible = false;
                notifyIcon.Dispose();

                Application.Exit();
            }
        }

        private bool passCheck()
        {
            if (!AppConfig.GetBoolean("HidePasswordDialog", false))
            {
                if (passwordDialog == null || passwordDialog.IsDisposed)
                {
                    passwordDialog = new PasswordBox();
                    passwordDialog.ResetPassword();
                    DialogResult result = passwordDialog.ShowDialog();
                    passwordDialog.Dispose();
                    if (result == DialogResult.OK)
                    {
                        return true;
                    }
                }
                else
                {
                    passwordDialog.ResetPassword();
                    passwordDialog.Activate();
                }
                return false;
            }
            return true;
        }
    }
}
