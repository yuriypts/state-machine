using ConsoleStateMachine.Converters;
using ConsoleStateMachine.Entity;
using ConsoleStateMachine.Repositories;

namespace ConsoleStateMachine.Logic;

public class OpportunityLogic
{
    public OpportunityLifeCyclePlan Start(int opportunityId, List<OpportunityLifeCycleEntity> opportunitiesLifeCycleDB, OpportunityRepository opportunityRepository)
    {
        // get opportunity from database
        OpportunityLifeCycleEntity opportunityLifeCycle = opportunitiesLifeCycleDB.FirstOrDefault(x => x.OpportunityId == opportunityId);

        if (opportunityLifeCycle is null)
        {
            OpportunityLifeCyclePlan opportunityLifeCyclePlan = OpportunityLifeCyclePlan.Start(opportunityId);

            opportunityLifeCyclePlan.State.Start(opportunityLifeCyclePlan, "Start");

            // save opportunities into database
            opportunityRepository.Save(opportunityLifeCyclePlan.ToLifeCycle(), opportunitiesLifeCycleDB);

            return opportunityLifeCyclePlan;
        }
        else
        {
            // already started
            return opportunityLifeCycle.ToLifeCyclePlan();
        }
        
    }

    public OpportunityLifeCyclePlan Execute(int opportunityId, List<OpportunityLifeCycleEntity> opportunitiesLifeCycleDB, OpportunityRepository opportunityRepository)
    {
        // get opportunity from database
        OpportunityLifeCycleEntity opportunityLifeCycle = opportunitiesLifeCycleDB.FirstOrDefault(x => x.OpportunityId == opportunityId)!;

        OpportunityLifeCyclePlan opportunityLifeCyclePlan = opportunityLifeCycle.ToLifeCyclePlan();

        opportunityLifeCyclePlan.State.Execute(opportunityLifeCyclePlan, "Execute");

        // save opportunities into database
        opportunityRepository.Save(opportunityLifeCyclePlan.ToLifeCycle(), opportunitiesLifeCycleDB);

        return opportunityLifeCyclePlan;
    }

    public OpportunityLifeCyclePlan Complete(int opportunityId, List<OpportunityLifeCycleEntity> opportunitiesLifeCycleDB, OpportunityRepository opportunityRepository)
    {
        // get opportunity from database
        OpportunityLifeCycleEntity opportunityLifeCycle = opportunitiesLifeCycleDB.FirstOrDefault(x => x.OpportunityId == opportunityId)!;

        OpportunityLifeCyclePlan opportunityLifeCyclePlan = opportunityLifeCycle.ToLifeCyclePlan();

        opportunityLifeCyclePlan.State.Complete(opportunityLifeCyclePlan, "Complete");

        // save opportunities into database
        opportunityRepository.Save(opportunityLifeCyclePlan.ToLifeCycle(), opportunitiesLifeCycleDB);

        return opportunityLifeCyclePlan;
    }

    public OpportunityLifeCyclePlan Reset(int opportunityId, List<OpportunityLifeCycleEntity> opportunitiesLifeCycleDB, OpportunityRepository opportunityRepository)
    {
        // get opportunity from database
        OpportunityLifeCycleEntity opportunityLifeCycle = opportunitiesLifeCycleDB.FirstOrDefault(x => x.OpportunityId == opportunityId)!;

        OpportunityLifeCyclePlan opportunityLifeCyclePlan = opportunityLifeCycle.ToLifeCyclePlan();

        opportunityLifeCyclePlan.State.Reset(opportunityLifeCyclePlan, "Reset");

        // save opportunities into database
        opportunityRepository.Save(opportunityLifeCyclePlan.ToLifeCycle(), opportunitiesLifeCycleDB);

        return opportunityLifeCyclePlan;
    }
}
