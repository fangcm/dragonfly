using System;
using System.Windows.Forms;

namespace SetupLibrary
{
    public partial class PasswordForm : Form
    {
        private string password;

        public PasswordForm()
        {
            InitializeComponent();
            this.textBoxPassword.Focus();
            this.Focus();
        }

        public void ResetPassword()
        {
            Random random = new Random();
            string key = random.Next(100, 999).ToString();
            labelTip.Text = "提示:" + key;

            password = DateTime.Now.Day.ToString() + key;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (password.Equals(this.textBoxPassword.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.textBoxPassword.Focus();
                MessageBox.Show(this, "密码错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
