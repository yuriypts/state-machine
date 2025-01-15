using ConsoleStateMachine.Entity;
using ConsoleStateMachine.Enums;

namespace ConsoleStateMachine.OpportunityStatuses;

public class OpportunityReset : OpportunityLifeCycleState
{
    public override void Reset(OpportunityLifeCyclePlan opportunityLifeCycle, string message)
    {
        opportunityLifeCycle.State = new OpportunityStart();
        opportunityLifeCycle.ResetedAt = DateTime.Now;
        opportunityLifeCycle.ResetMessage = message;

        Console.WriteLine("OpportunityId - {0}, ResetedAt - {1}, ResetMessage - {2}", opportunityLifeCycle.OpportunityId, opportunityLifeCycle.ResetedAt, opportunityLifeCycle.ResetMessage);
    }
}
