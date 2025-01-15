using ConsoleStateMachine.Entity;
using ConsoleStateMachine.Enums;
using ConsoleStateMachine.OpportunityStatuses;

namespace ConsoleStateMachine.Converters;

public static class OpportunityLifeCycleConverter
{
    public static OpportunityLifeCyclePlan ToLifeCyclePlan(this OpportunityLifeCycleEntity opportunityLifeCycle)
    {
        OpportunityLifeCyclePlan opportunityLifeCyclePlan = new()
        {
            OpportunityId = opportunityLifeCycle.OpportunityId,
            StartedAt = opportunityLifeCycle.StartedAt,
            StartedMessage = opportunityLifeCycle.StartedMessage,
            CompletedAt = opportunityLifeCycle.CompletedAt,
            CompletedMessage = opportunityLifeCycle.StartedMessage,
            ResetedAt = opportunityLifeCycle.ResetedAt,
            ResetMessage = opportunityLifeCycle.ResetMessage,
            State = opportunityLifeCycle.StateEnum switch
            {
                OpportunityLifeCycleStateEnum.Start => new OpportunityStart(),
                OpportunityLifeCycleStateEnum.Execute => new OpportunityExecute(),
                OpportunityLifeCycleStateEnum.Complete => new OpportunityComplete(),
                OpportunityLifeCycleStateEnum.Reset => new OpportunityReset(),
                _ => throw new Exception("Opportunity sate was not recognized"),
            }
        };

        return opportunityLifeCyclePlan;
    }

    public static OpportunityLifeCycleEntity ToLifeCycle(this OpportunityLifeCyclePlan opportunityLifeCyclePlan)
    {
        OpportunityLifeCycleEntity opportunityLifeCycle = new()
        {
            OpportunityId = opportunityLifeCyclePlan.OpportunityId,
            StartedAt = opportunityLifeCyclePlan.StartedAt,
            StartedMessage = opportunityLifeCyclePlan.StartedMessage,
            CompletedAt = opportunityLifeCyclePlan.CompletedAt,
            CompletedMessage = opportunityLifeCyclePlan.CompletedMessage,
            ResetedAt = opportunityLifeCyclePlan.ResetedAt,
            ResetMessage = opportunityLifeCyclePlan.ResetMessage,
            StateEnum = opportunityLifeCyclePlan.State switch
            {
                OpportunityStart => OpportunityLifeCycleStateEnum.Start,
                OpportunityExecute => OpportunityLifeCycleStateEnum.Execute,
                OpportunityComplete => OpportunityLifeCycleStateEnum.Complete,
                OpportunityReset => OpportunityLifeCycleStateEnum.Reset,
                _ => throw new Exception("Opportunity sate was not recognized"),
            }
        };

        return opportunityLifeCycle;
    }
}
