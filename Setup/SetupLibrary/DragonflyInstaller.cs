using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;

namespace SetupLibrary
{
    [RunInstaller(true)]
    public partial class DragonflyInstaller : Installer
    {
        public DragonflyInstaller()
        {
            InitializeComponent();
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);

            string targetDir = this.Context.Parameters["TargetDir"];
            string mainApp = Path.Combine(targetDir, "dragonfly.main.exe");

            Process process = new Process();
            process.StartInfo.FileName = mainApp;
            process.StartInfo.WorkingDirectory = targetDir;
            process.Start();
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);

            PasswordForm passwordForm = new PasswordForm();
            passwordForm.ResetPassword();
            if (passwordForm.ShowDialog(ForegroundWindow.Instance) != System.Windows.Forms.DialogResult.OK)
            {
                throw new InstallException("密码错误");
            }

        }

    }
}
