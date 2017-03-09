using FluentScheduler;


namespace Dragonfly.Plugin.Task
{
    internal class AdjustmentJob : IJob
    {
        void IJob.Execute()
        {
            int adjustmentSeconds = SelfAdjusting.CaculateAdjustmentSeconds();
            if (adjustmentSeconds <= 0)
            {
                return;
            }

            SchedulerRegistry.AdjustingDelaySeconds(0 - adjustmentSeconds);

        }

    }

}