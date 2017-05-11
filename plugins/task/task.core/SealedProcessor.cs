using System;

namespace Dragonfly.Task.Core
{
    public class SealedProcessor
    {
        public static bool Main(LockScreenForm mainWindow, string[] args)
        {
            var arguments = CommandLineArgumentParser.Parse(args);

            int lockMinutes = 0;

            if (arguments.Has("-lockminutes"))
            {
                var arg = arguments.Get("-lockminutes").Next;
                if (arg != null)
                {
                    lockMinutes = Convert.ToInt32(arg.ToString());
                }
            }
            if (arguments.Has("-recovery"))
            {
                var arg = arguments.Get("-recovery").Next;
                if (arg != null)
                {
                    NotifySetting setting = NotifySetting.LoadFromFile();
                    if (setting != null && setting.EndTriggerTime != null)
                    {
                        DateTime now = DateTime.Now;
                        if (now.CompareTo(setting.EndTriggerTime) < 0)
                        {
                            lockMinutes = Convert.ToInt32((setting.EndTriggerTime - now).TotalMinutes);
                        }
                    }
                }
                Logger.info("SealedProcessor", "recovery:" + lockMinutes);
            }

            Logger.info("SealedProcessor", "lockMinutes:", lockMinutes);

            if (lockMinutes > 0)
            {
                mainWindow.Description = "健康是生命之本，保护视力，从娃娃开始！";
                mainWindow.IntervalSeconds = lockMinutes * 60;
            }

            return true;
        }
    }
}