using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

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

            if (Context.Parameters["TargetDir"] == null)
                throw new InstallException("Custom Data: TargetDir not set");

            string targetDir = this.Context.Parameters["TargetDir"].Substring(0, Context.Parameters["TargetDir"].Length - 1);

            if ("1".Equals(Context.Parameters["PROFILE"]))
            {
                File.Delete(System.IO.Path.Combine(targetDir, "dragonfly.main.exe.config"));
            }

            string mainApp = Path.Combine(targetDir, "dragonfly.main.exe");

            Process process = new Process();
            process.StartInfo.FileName = mainApp;
            process.StartInfo.WorkingDirectory = targetDir;
            process.Start();

        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);

            string targetDir = this.Context.Parameters["TargetDir"].Substring(0, Context.Parameters["TargetDir"].Length - 1);

            if (!File.Exists(System.IO.Path.Combine(targetDir, "dragonfly.main.exe.config")))
            {
                PasswordForm passwordForm = new PasswordForm();
                passwordForm.ResetPassword();
                if (passwordForm.ShowDialog(ForegroundWindow.Instance) != System.Windows.Forms.DialogResult.OK)
                {
                    throw new InstallException("密码错误");
                }
            }

        }

    }
}
