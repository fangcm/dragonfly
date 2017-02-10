using System;
using System.Collections.Generic;
using System.Text;
using FluentScheduler;

namespace Dragonfly.Plugin.Task
{
    internal class SchedulerRegistry : Registry
    {
        internal static readonly string JOB_NAME = "SchedulerRegistry";
        public SchedulerRegistry()
        {
            Schedule<NotifyJob>().WithName(JOB_NAME).NonReentrant().ToRunOnceAt(8, 10).AndEvery(2).Minutes();
        }

    }
}
