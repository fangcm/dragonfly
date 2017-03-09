using FluentScheduler;


namespace Dragonfly.Plugin.Task
{
    internal class AdjustmentJob : IJob
    {
        void IJob.Execute()
        {
            int adjustmentMinutes = 60;// SelfAdjusting.CaculateAdjustmentSeconds();
            if (adjustmentMinutes <= 0)
            {
                return;
            }

            SchedulerRegistry.AdjustingDelaySeconds(0 - adjustmentMinutes);

        }

    }

}