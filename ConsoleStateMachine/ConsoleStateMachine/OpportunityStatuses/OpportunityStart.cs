using ConsoleStateMachine.Entity;

namespace ConsoleStateMachine.OpportunityStatuses;

public class OpportunityStart : OpportunityLifeCycleState
{
    public override void Start(OpportunityLifeCyclePlan opportunityLifeCycle, string message)
    {
        opportunityLifeCycle.State = new OpportunityExecute();
        opportunityLifeCycle.StartedAt = DateTime.Now;
        opportunityLifeCycle.StartedMessage = message;

        Console.WriteLine("OpportunityId - {0}, StartedAt - {1}, StartedMessage - {2}", opportunityLifeCycle.OpportunityId, opportunityLifeCycle.StartedAt, opportunityLifeCycle.StartedMessage);
    }
}
