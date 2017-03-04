using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;

namespace Dragonfly.Updater
{
    class Program
    {
        // argument 0 - process ID
        // argument 1 - full path to EXE file for start app

        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length != 2)
                {
                    throw new Exception("missed parameters");
                }

                int processId;
                string appFullName = args[1];

                if (!Int32.TryParse(args[0], out processId) || !File.Exists(appFullName) || Path.GetExtension(appFullName) != ".exe")
                {
                    throw new Exception("invalid parameters");
                }

                var commands = new List<ICommand>
                {
                    new KillProcessCommand(processId),
                    new CopyContentCommand(),
                    new StartProcessCommand(appFullName)
                };

                commands.ForEach(x => x.Execute());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}