using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace keep.alive
{
    class Program
    {
        static bool isRunning = false;

        [STAThread]
        public static void Main(string[] args)
        {
            StartChecking(verbose, 1000, 10000, cmd["n"], cmd["r"]);
        }

        static void Log(string text)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] {text}");
        }

        static void StartChecking(bool verbose, int checkInterval, int waitInterval, string processName, string processToRun)
        {
            isRunning = true;

            Log($"KYMA (Keep Your Miner Alive) {appVersion}");
            Log($"");
            Log($"Watching for: {processName}");
            Log($"If dead, will run: {processToRun}");
            Log($"");

            bool alive;
            bool lastAlive = false;
            while (isRunning)
            {
                Thread.Sleep(checkInterval);
                alive = Check(processName);
                if (alive)
                {
                    if (verbose && lastAlive != alive)
                        Log("Alive.");
                }
                else
                {
                    lastAlive = false;
                    if (verbose)
                        Log($"Dead! Waiting {waitInterval / 1000}s to revive...");
                    Thread.Sleep(waitInterval);
                    alive = Check(processName);
                    if (alive)
                    {
                        if (verbose)
                            Log("Oops, it's alive now. Nothing to do.");
                    }
                    else
                    {
                        Spawn(processToRun);
                        if (verbose)
                            Log($"{processToRun} spawned!");
                    }
                }
                lastAlive = alive;
            }
        }


        static bool Check(string processName)
        {
            bool alive = false;
            foreach (Process p in Process.GetProcesses())
                try
                {
                    if (new FileInfo(p.MainModule.FileName).Name.ToLowerInvariant().Trim() == processName.ToLowerInvariant().Trim())
                        alive = true;
                }
                catch { }
            return alive;
        }

        static void Spawn(string filepath)
        {
            FileInfo fi = new FileInfo(filepath);
            ProcessStartInfo pi = new ProcessStartInfo()
            {
                FileName = fi.Name,
                WorkingDirectory = fi.Directory.FullName
            };
            Process.Start(pi);
        }
    }
}
