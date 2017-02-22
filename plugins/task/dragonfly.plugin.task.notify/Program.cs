using Dragonfly.Task.Notify.Common;
using System;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Task.Notify
{
    static class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NomalLockScreenForm mainWindow = new NomalLockScreenForm();
            SealedProcessor.Main(mainWindow, args);
            Application.Run(mainWindow);
        }
    }
}
