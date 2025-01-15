using ConsoleStateMachine.Entity;

namespace ConsoleStateMachine.OpportunityStatuses;

public abstract class OpportunityLifeCycleState
{
    public virtual void Start(OpportunityLifeCyclePlan opportunityLifeCycle, string message)
    {
        Console.WriteLine("Start is invalid for current state");
    }

    public virtual void Execute(OpportunityLifeCyclePlan opportunityLifeCycle, string message)
    {
        Console.WriteLine("Execute is invalid for current state");
    }

    public virtual void Complete(OpportunityLifeCyclePlan opportunityLifeCycle, string message)
    {
        Console.WriteLine("Complete is invalid for current state");
    }

    public virtual void Reset(OpportunityLifeCyclePlan opportunityLifeCycle, string message)
    {
        Console.WriteLine("Reset is invalid for current state");
    }
}

