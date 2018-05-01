using System;
using System.Diagnostics;

namespace Dragonfly.Service
{
    public static class Logger
    {
        private const string logSource = "MainService";
        private const string logType = "Application";

        public static void info(params object[] messages)
        {
            log(EventLogEntryType.Information, messages);
        }

        public static void error(params object[] messages)
        {
            log(EventLogEntryType.Error, messages);
        }

        public static void warn(params object[] messages)
        {
            log(EventLogEntryType.Warning, messages);
        }

        public static void log(EventLogEntryType eventType, params object[] messages)
        {
            log(eventType, string.Join(", ", messages));
        }

        public static void log(EventLogEntryType eventType, string message)
        {

            try
            {
                //.NET EventLog Class
                if (!EventLog.SourceExists(logSource))
                    EventLog.CreateEventSource(logSource, logType);

                EventLog.WriteEntry(logSource, message, eventType);

            }
            catch (Exception e)
            {
                Trace.WriteLine(message);
                Trace.WriteLine(e.Message);
            }


        }

    }

}
