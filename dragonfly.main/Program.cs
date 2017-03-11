using Dragonfly.Common.Utils;
using System;
using System.Windows.Forms;

namespace Dragonfly.Main
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TraceLog.info("application starting ...");
            if (!SingleApplication.IsAlreadyRunning())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ApplicationExit += Application_ApplicationExit;
                Application.Run(new CustomApplicationContext());
            }
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            TraceLog.info("application exit");
            TraceLog.Instance.Dispose();

        }
    }
}
