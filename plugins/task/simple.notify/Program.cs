using Dragonfly.Task.Core;
using System;
using System.Windows.Forms;

namespace Dragonfly.Simple.Notify
{
    static class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NomalLockScreenForm mainWindow = new NomalLockScreenForm();
            bool ok = SealedProcessor.Main(mainWindow, args);
            if (ok)
            {
                Application.Run(mainWindow);
            }
        }
    }
}
