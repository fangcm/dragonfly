using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

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
            RunProcess(targetDir, mainApp, "", false);

            string service = Path.Combine(targetDir, "dsmanager.exe");
            Process s = RunProcess(targetDir, service, "-install", true);
            if (s != null)
            {
                s.WaitForExit(5000);
            }

            try
            {
                using (ServiceController sc = new ServiceController("dsmanager"))
                {
                    sc.Start();
                }
            }
            catch (Exception)
            {
            }
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

            try
            {
                using (ServiceController sc = new ServiceController("dsmanager"))
                {
                    TimeSpan timeout = new TimeSpan(0, 0, 15);
                    if (sc.Status != ServiceControllerStatus.Stopped)
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                    }
                }
            }
            catch (Exception)
            {
            }

            string service = Path.Combine(targetDir, "dsmanager.exe");
            RunProcess(targetDir, service, "-uninstall", true);

        }



        private Process RunProcess(string targetDir, string exeFile, string args, bool isAdmin)
        {
            Process process = new Process();
            process.StartInfo.FileName = exeFile;
            process.StartInfo.WorkingDirectory = targetDir;
            process.StartInfo.Arguments = args;
            if (isAdmin)
            {
                process.StartInfo.Verb = "runas";
            }
            process.Start();

            return process;
        }
    }
}
