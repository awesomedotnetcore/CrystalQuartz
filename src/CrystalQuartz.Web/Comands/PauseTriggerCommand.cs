﻿using CrystalQuartz.Core;
using CrystalQuartz.Core.SchedulerProviders;
using CrystalQuartz.Web.Comands.Inputs;
using CrystalQuartz.Web.Comands.Outputs;
using Quartz;

namespace CrystalQuartz.Web.Comands
{
    public class PauseTriggerCommand : AbstractSchedulerCommand<TriggerInput, TriggerDataOutput>
    {
        public PauseTriggerCommand(ISchedulerProvider schedulerProvider, ISchedulerDataProvider schedulerDataProvider) : base(schedulerProvider, schedulerDataProvider)
        {
        }

        protected override void InternalExecute(TriggerInput input, TriggerDataOutput output)
        {
            var triggerKey = new TriggerKey(input.Trigger, input.Group);
            Scheduler.PauseTrigger(triggerKey);

            output.Trigger = SchedulerDataProvider.GetTriggerData(triggerKey);
        }
    }
}