using System;

namespace Dragonfly.Task.Core
{
    public class SealedProcessor
    {
        public static bool Main(LockScreenForm mainWindow, string[] args)
        {
            var arguments = CommandLineArgumentParser.Parse(args);

            bool bLock = false;
            int lockMinutes = 0;
            int cmd = 0;
            string desc = string.Empty;

            if (arguments.Has("-lock"))
            {
                var arg = arguments.Get("-lock").Next;
                if (arg != null)
                {
                    bLock = Convert.ToBoolean(arg.ToString());
                }
            }
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
            if (arguments.Has("-cmd"))
            {
                var arg = arguments.Get("-cmd").Next;
                if (arg != null)
                {
                    cmd = Convert.ToInt32(arg.ToString());
                }
            }
            if (arguments.Has("-desc"))
            {
                var arg = arguments.Get("-desc").Next;
                if (arg != null)
                {
                    desc = arg.ToString();
                }
            }
            Logger.info("SealedProcessor", "lock:", bLock, ",lockMinutes:", lockMinutes, ",cmd:", cmd);
            if (bLock == false && cmd == 0)
            {
                return false;
            }

            if (bLock && lockMinutes > 0)
            {
                mainWindow.Description = desc;
                mainWindow.IntervalSeconds = lockMinutes * 60;
            }

            switch (cmd)
            {
                case 1:
                    RestartUtil.ExitWindows(RestartOptions.PowerOff, true);
                    break;
                case 2:
                    RestartUtil.ExitWindows(RestartOptions.Hibernate, true);
                    break;
            }
            return true;
        }
    }
}