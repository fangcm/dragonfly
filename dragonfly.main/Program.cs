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
            if (!SingleApplication.IsAlreadyRunning())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new CustomApplicationContext());
            }
        }
    }
}
