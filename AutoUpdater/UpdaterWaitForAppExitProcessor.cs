using System;
using System.Collections.Generic;
using System.Text;

namespace Dragonfly.Chalk
{
    internal class UpdaterWaitForAppExitProcessor
    {
        private UpdaterTask task;

        public string ExtraCommand { get { return extraCommand; } set { extraCommand = value; } }

        #region IActivationProcessor Members

        void IActivationProcessor.Init(UpdaterTask newTask)
        {
            this.task = newTask;
        }

        void IActivationProcessor.PrepareExecution()
        {
        }

        private const string exeName = "DotUpdater.WaitExec.exe";
        private const string resourceName = "DotUpdater.Resources.DotUpdater.WaitExec.exe";
        private string extraCommand = "";

        private static readonly Dictionary<string, bool> processesStarted = new Dictionary<string, bool>();

        void IActivationProcessor.Execute()
        {
            string fullExeName = Path.Combine(Utility.TempBasePath, exeName);
            string fullMsiName = Path.Combine(task.DownloadFilesBase, task.Files[0]);
            string commandArgs = string.Format("{0} msiexec /qb /i \\\"{1}\\\" REINSTALL=ALL REINSTALLMODE=vomus",
                CurrentPid, fullMsiName);

            if (processesStarted.ContainsKey(fullExeName + commandArgs))
            {
                //Logging.Warning("Attempt to double-start an application");
                return;
            }

            Utility.ExtractResourceStream(resourceName, fullExeName);

            CheckFiles(fullMsiName, fullExeName);

            bool nextProcess = !string.IsNullOrEmpty(extraCommand);
            StartProcess(fullExeName, commandArgs, nextProcess);
            if (nextProcess) StartProcess(extraCommand, "", false);

            processesStarted[fullExeName + commandArgs] = true;
        }

        protected virtual int CurrentPid { get { return Process.GetCurrentProcess().Id; } }

        protected virtual void CheckFiles(string fullMsiName, string fullExeName)
        {
            if (!File.Exists(fullExeName) || !File.Exists(fullMsiName)) throw new InvalidOperationException("Failed to start self-update");
        }

        protected virtual void StartProcess(string paramName, string args)
        {
            StartProcess(paramName, args, false);
        }

        protected virtual void StartProcess(string paramName, string args, bool waitForExit)
        {
            using (var installUtilProcess = new Process())
            {
                installUtilProcess.StartInfo.FileName = paramName;
                installUtilProcess.StartInfo.Arguments = args;
                installUtilProcess.Start();
                if (waitForExit) installUtilProcess.WaitForExit();
            }
        }

        void IActivationProcessor.OnError()
        {
        }

        #endregion

    }
}
