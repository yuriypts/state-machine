using ConsoleStateMachine.Entity;

namespace ConsoleStateMachine.OpportunityStatuses;

public class OpportunityComplete : OpportunityLifeCycleState
{
    public override void Complete(OpportunityLifeCyclePlan opportunityLifeCycle, string message)
    {
        opportunityLifeCycle.CompletedAt = DateTime.Now;
        opportunityLifeCycle.CompletedMessage = message;

        Console.WriteLine("OpportunityId - {0}, CompletedAt - {1}, CompletedMessage - {2}", opportunityLifeCycle.OpportunityId, opportunityLifeCycle.CompletedAt, opportunityLifeCycle.CompletedMessage);
    }

    public override void Reset(OpportunityLifeCyclePlan opportunityLifeCycle, string message)
    {
        opportunityLifeCycle.State = new OpportunityStart();
        opportunityLifeCycle.ResetedAt = DateTime.Now;
        opportunityLifeCycle.ResetMessage = message;

        Console.WriteLine("OpportunityId - {0}, ResetedAt - {1}, ResetMessage - {2}", opportunityLifeCycle.OpportunityId, opportunityLifeCycle.ResetedAt, opportunityLifeCycle.ResetMessage);
    }
}
