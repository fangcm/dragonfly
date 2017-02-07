using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace Dragonfly.WaitExec
{
    class Program
    {
        /// <summary>
        /// Usage: {this application} {pid to wait for} {command to execute}
        /// </summary>
        /// <param name="args"></param>

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length < 2) return;

            int pid = int.Parse(args[0]);

            Mutex waitMutex = new Mutex(true, String.Format(CultureInfo.InvariantCulture,
                "WaitApplication_{0}", pid));

            waitMutex.WaitOne();

            try
            {
                Process processToWait = Process.GetProcessById(pid);
                processToWait.WaitForExit();
            }
            catch
            {
                //return;
            }

            waitMutex.ReleaseMutex();

            string arguments = string.Join(" ", args, 2, args.Length - 2);
            using (Process installUtilProcess = new Process())
            {
                installUtilProcess.StartInfo.FileName = args[1];
                installUtilProcess.StartInfo.Arguments = arguments;
                installUtilProcess.Start();
            }
        }
    }
}
