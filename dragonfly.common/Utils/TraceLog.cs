using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Dragonfly.Common.Utils
{
    public sealed class TraceLog : IDisposable
    {
        public static TraceLog _instance = null;

        private TraceSource ts = new TraceSource("dragonfly",SourceLevels.All);

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
            FileStream logFile = new FileStream(fileName, FileMode.Append);
            TextWriterTraceListener logFileListener = new TextWriterTraceListener(logFile);

            ts.Listeners.Add(logFileListener);
        }

        public void Dispose()
        {
            ts.Close();
        }

        public static void info(string line)
        {
            Instance.ts.TraceInformation(string.Format("{0} - {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), line));
            Instance.ts.Flush();
        }

        public static void info(string format, params object[] list)
        {
            info(string.Format(format, list));
        }

        public static void info(object obj)
        {
            info(obj.ToString());
        }

        public static void error(string line)
        {
            Instance.ts.TraceData(TraceEventType.Error,1,string.Format("{0} - {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), line));
            Instance.ts.Flush();
        }

    }
}
