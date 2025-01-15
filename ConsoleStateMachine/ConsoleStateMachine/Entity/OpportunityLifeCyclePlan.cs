using ConsoleStateMachine.Enums;
using ConsoleStateMachine.OpportunityStatuses;

namespace ConsoleStateMachine.Entity;

public class OpportunityLifeCyclePlan
{
    public OpportunityLifeCycleState State { get; set; }

    public static OpportunityLifeCyclePlan Start(int opportunityId)
    {
        OpportunityLifeCyclePlan opportunityLifeCycle = new()
        {
            OpportunityId = opportunityId,
            State = new OpportunityStart()
        };
        
        return opportunityLifeCycle;
    }

    public int OpportunityId { get; set; }

    public DateTime StartedAt { get; set; }
    public string StartedMessage { get; set; }

    public DateTime ExecutedAt { get; set; }
    public string ExecutedMessage { get; set; }

    public DateTime CompletedAt { get; set; }
    public string CompletedMessage { get; set; }

    public DateTime ResetedAt { get; set; }
    public string ResetMessage { get; set; }

    public ForecastEnum ForecastStatus { get; set; }
}
