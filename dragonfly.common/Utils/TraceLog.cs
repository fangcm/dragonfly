using System;
using System.Diagnostics;
using System.IO;

namespace Dragonfly.Common.Utils
{
    public sealed class TraceLog : IDisposable
    {
        public static TraceLog _instance = null;

        private TraceSource ts = new TraceSource("dragonfly");

        private TraceLog()
        {
        }

        public static TraceLog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TraceLog();
                    _instance.Initialize();
                }
                return _instance;

            }
        }

        public void Initialize()
        {
            SourceSwitch sourceSwitch = new SourceSwitch("dragonfly", "Information");
            ts.Switch = sourceSwitch;

            string fileName = Path.Combine(AppConfig.LogsPath, DateTime.Now.ToString("yyyyMMdd") + ".trace.log");
            FileStream logFile = new FileStream(fileName, FileMode.OpenOrCreate);
            TextWriterTraceListener logFileListener = new TextWriterTraceListener(logFile);
            logFileListener.TraceOutputOptions = TraceOptions.DateTime;

            ts.Listeners.Add(logFileListener);
        }

        public void Dispose()
        {
            ts.Close();
        }

        public void WriteLine(string line)
        {
            ts.TraceInformation(string.Format("{0} - {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), line));
            ts.Flush();
        }

        public void WriteLine(string format, params object[] list)
        {
            WriteLine(string.Format(format, list));
        }

        public void WriteLine(object obj)
        {
            WriteLine(obj.ToString());
        }


    }
}
