using System;
using System.Windows.Forms;

namespace Dragonfly.Task.Core
{
    public class TaskApplicationContext : ApplicationContext
    {
        private LockScreenForm mainWindow = null;
        private SecondaryScreenForm secondaryScreen = null;
        private int lockMinutes = 0;

        public TaskApplicationContext(LockScreenForm mainWindow, string[] args)
        {
            ParseArgs(args);

            if (secondaryScreen == null)
            {
                secondaryScreen = new SecondaryScreenForm();
                secondaryScreen.Show();
            }

            this.mainWindow = mainWindow;
            if (this.mainWindow != null)
            {
                this.mainWindow.Description = "健康是生命之本，保护视力，从娃娃开始！";
                if (lockMinutes > 0)
                {
                    this.mainWindow.IntervalSeconds = lockMinutes * 60;
                }

                this.mainWindow.FormClosed += MainWindow_FormClosed;
                this.mainWindow.Show();
            }

        }

        private void ParseArgs(string[] args)
        {
            var arguments = CommandLineArgumentParser.Parse(args);

            int lockMinutes = 0;

            if (arguments.Has("-lockminutes"))
            {
                var arg = arguments.Get("-lockminutes").Next;
                if (arg != null)
                {
                    lockMinutes = Convert.ToInt32(arg.ToString());
                }
            }
            if (arguments.Has("-recovery"))
            {
                var arg = arguments.Get("-recovery").Next;
                if (arg != null)
                {
                    NotifySetting setting = NotifySetting.LoadFromFile();
                    if (setting != null && setting.EndTriggerTime != null)
                    {
                        DateTime now = DateTime.Now;
                        if (now.CompareTo(setting.EndTriggerTime) < 0)
                        {
                            lockMinutes = Convert.ToInt32((setting.EndTriggerTime - now).TotalMinutes);
                        }
                    }
                }
                Logger.info("SealedProcessor", "recovery:" + lockMinutes);
            }

            this.lockMinutes = lockMinutes;

            Logger.info("SealedProcessor", "lockMinutes:", lockMinutes);

        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExitThread();
        }

    }
}
