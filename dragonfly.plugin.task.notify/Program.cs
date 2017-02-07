using System;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Task.Notify
{
    static class Program
    {
        private static string[] ProgramArgument;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ProgramArgument = args;

            if (ProgramArgument.Length == 0)
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form mainWindow = null;

            string type = ProgramArgument[0];
            if ("msg".Equals(type.ToLower()))
            {
                string title = "";
                string content = "";
                if (ProgramArgument.Length >= 2)
                    title = ProgramArgument[1];
                if (ProgramArgument.Length >= 3)
                    content = ProgramArgument[2];

                mainWindow = new Utils().ShowNotifyWindow(title, content);
                Application.Run(mainWindow);

            }
            if ("other".Equals(type.ToLower()))
            {
                int seconds = 30;

                if (ProgramArgument.Length >= 2)
                    seconds = Int32.Parse(ProgramArgument[1]);

                Application.Run(Utils.ShowOther(seconds));

            }
            else if ("lock".Equals(type.ToLower()))
            {
                int seconds = 30;
                string title = "";
                string content = "";
                if (ProgramArgument.Length >= 2)
                    seconds = Int32.Parse(ProgramArgument[1]);
                if (ProgramArgument.Length >= 3)
                    title = ProgramArgument[2];
                if (ProgramArgument.Length >= 4)
                    content = ProgramArgument[3];

                mainWindow = Utils.LockScreen(seconds, title, content);
                Application.Run(mainWindow);
            }
            else if ("shutdown".Equals(type.ToLower()))
            {
                string restartOption = "hibernate";
                if (ProgramArgument.Length >= 2)
                    restartOption = ProgramArgument[1];

                if ("logoff".Equals(restartOption.ToLower()))
                    Utils.ExitWindows(RestartOptions.LogOff, true);
                else if ("poweroff".Equals(restartOption.ToLower()))
                    Utils.ExitWindows(RestartOptions.PowerOff, true);
                else if ("suspend".Equals(restartOption.ToLower()))
                    Utils.ExitWindows(RestartOptions.Suspend, true);
                else if ("reboot".Equals(restartOption.ToLower()))
                    Utils.ExitWindows(RestartOptions.Reboot, true);
                else
                    Utils.ExitWindows(RestartOptions.Hibernate, true);

                return;
            }

        }
    }
}
