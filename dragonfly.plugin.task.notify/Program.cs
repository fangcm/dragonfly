using System;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Task.Notify
{
    static class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            var arguments = CommandLineArgumentParser.Parse(args);

            bool bLock = false;
            int lockMinutes = 0;
            int cmd = 0;
            string desc = string.Empty;

            if (arguments.Has("-lock"))
            {
                var arg = arguments.Get("-lock").Next;
                if (arg != null)
                {
                    bLock = Convert.ToBoolean(arg.ToString());
                }
            }
            if (arguments.Has("-lockminutes"))
            {
                var arg = arguments.Get("-lockminutes").Next;
                if (arg != null)
                {
                    lockMinutes = Convert.ToInt32(arg.ToString());
                }
            }
            if (arguments.Has("-cmd"))
            {
                var arg = arguments.Get("-cmd").Next;
                if (arg != null)
                {
                    cmd = Convert.ToInt32(arg.ToString());
                }
            }
            if (arguments.Has("-desc"))
            {
                var arg = arguments.Get("-desc").Next;
                if (arg != null)
                {
                    desc = arg.ToString();
                }
            }

            if (bLock == false && cmd == 0)
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form mainWindow = null;

            if (bLock && lockMinutes > 0)
            {
                desc += (" , lockMinutes:"+ lockMinutes);
                mainWindow = Utils.LockScreen(lockMinutes * 60, desc);
                Application.Run(mainWindow);
            }

            switch (cmd)
            {
                case 1:
                    Utils.ExitWindows(RestartOptions.PowerOff, true);
                    break;
                case 2:
                    Utils.ExitWindows(RestartOptions.Hibernate, true);
                    break;
            }

        }
    }
}
