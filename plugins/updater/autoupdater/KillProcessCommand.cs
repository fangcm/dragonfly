using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace Dragonfly.Updater
{
    internal sealed class KillProcessCommand : ICommand
    {
        private readonly int _processId;

        public KillProcessCommand(int processId)
        {
            _processId = processId;
        }

        public void Execute()
        {
            Process.GetProcessById(_processId).Kill();

            Mutex waitMutex = new Mutex(true, string.Format(CultureInfo.InvariantCulture, "WaitApplication_{0}", _processId));
            waitMutex.WaitOne();

            try
            {
                Process processToWait = Process.GetProcessById(_processId);
                processToWait.WaitForExit();
            }
            catch
            {
            }

            waitMutex.ReleaseMutex();
        }
    }
}
