using Dragonfly.Common.Utils;
using Dragonfly.Plugin.Task.Utils;
using FluentScheduler;


namespace Dragonfly.Plugin.Task
{
    internal class AdjustmentJob : IJob
    {
        void IJob.Execute()
        {
            AdjustmentCondition con = SelfAdjusting.CheckAccumulatedCondition();
            if (con == null)
            {
                Logger.info("AdjustmentJob", "CheckAccumulatedCondition: NULL");
                return;
            }

            int adjustmentSeconds = con.SpanSeconds;

            Logger.info("AdjustmentJob", "CheckAccumulatedCondition:", con.Title, ",adjustmentSeconds:", adjustmentSeconds);
            LoggerUtil.Log(LoggType.Other, "Accumulated condition:" + con.Title + ",adjustmentSeconds:" + adjustmentSeconds);

            if (adjustmentSeconds <= 0)
            {
                return;
            }
            SchedulerRegistry.AdjustingDelaySeconds(0 - adjustmentSeconds);
        }

    }

}