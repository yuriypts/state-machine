using ConsoleStateMachine.Entity;

namespace ConsoleStateMachine.OpportunityStatuses;

public class OpportunityExecute : OpportunityLifeCycleState
{
    public override void Execute(OpportunityLifeCyclePlan opportunityLifeCycle, string message)
    {
        opportunityLifeCycle.State = new OpportunityComplete();
        opportunityLifeCycle.ExecutedAt = DateTime.Now;
        opportunityLifeCycle.ExecutedMessage = message;

        Console.WriteLine("OpportunityId - {0}, ExecutedAt - {1}, ExecutedMessage - {2}", opportunityLifeCycle.OpportunityId, opportunityLifeCycle.ExecutedAt, opportunityLifeCycle.ExecutedMessage);
    }

    public override void Reset(OpportunityLifeCyclePlan opportunityLifeCycle, string message)
    {
        opportunityLifeCycle.State = new OpportunityStart();
        opportunityLifeCycle.ResetedAt = DateTime.Now;
        opportunityLifeCycle.ResetMessage = message;

        Console.WriteLine("OpportunityId - {0}, ResetedAt - {1}, ResetMessage - {2}", opportunityLifeCycle.OpportunityId, opportunityLifeCycle.ResetedAt, opportunityLifeCycle.ResetMessage);
    }
}
