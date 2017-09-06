using Dragonfly.Task.Core;
using System;
using System.Windows.Forms;

namespace Dragonfly.Questions.Notify
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainWindow = new MainForm();
            TaskApplicationContext context = new TaskApplicationContext(mainWindow, args);
            Application.Run(context);
        }
    }
}
