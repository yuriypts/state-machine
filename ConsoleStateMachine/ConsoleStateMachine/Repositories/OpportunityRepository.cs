using ConsoleStateMachine.Entity;

namespace ConsoleStateMachine.Repositories;

public class OpportunityRepository
{
    public void Save(OpportunityLifeCycleEntity opportunityLifeCycleEntity, List<OpportunityLifeCycleEntity> opportunitiesLifeCycleDB)
    {
        if (opportunitiesLifeCycleDB.Any(x => x.OpportunityId == opportunityLifeCycleEntity.OpportunityId))
        {
            opportunitiesLifeCycleDB.RemoveAll(x => x.OpportunityId == opportunityLifeCycleEntity.OpportunityId);
            opportunitiesLifeCycleDB.Add(opportunityLifeCycleEntity);
        }
        else
        {
            opportunitiesLifeCycleDB.Add(opportunityLifeCycleEntity);
        }
    }
}
