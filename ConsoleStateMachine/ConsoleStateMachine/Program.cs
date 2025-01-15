using ConsoleStateMachine.Converters;
using ConsoleStateMachine.Entity;
using ConsoleStateMachine.Logic;
using ConsoleStateMachine.Repositories;

namespace ConsoleStateMachine;

public class Program
{
    static List<OpportunityLifeCycleEntity> opportunitiesLifeCycleDB = new();
    static OpportunityLogic opportunityLogic = new();
    static OpportunityRepository opportunityRepository = new();

    static void Main(string[] args)
    {
        for (int i = 0; i < 2; i++)
        {
            int opportunityId = i + 1;
            
            // start opportunity
            opportunityLogic.Start(opportunityId, opportunitiesLifeCycleDB, opportunityRepository);


            Thread.Sleep(1000);

            // execute opportunity
            opportunityLogic.Execute(opportunityId, opportunitiesLifeCycleDB, opportunityRepository);
            
            Thread.Sleep(1000);

            if (opportunityId == 2)
            {
                // stop opportunity
                opportunityLogic.Reset(opportunityId, opportunitiesLifeCycleDB, opportunityRepository);
            }
            else
                // comlete Forecast/Price calculation
                opportunityLogic.Complete(opportunityId, opportunitiesLifeCycleDB, opportunityRepository);

            Thread.Sleep(1000);
        }

        Console.WriteLine("Count of opportunities - {0}", opportunitiesLifeCycleDB.Count);

        int secondOpportunity = 2;
        OpportunityLifeCycleEntity opportunity = opportunitiesLifeCycleDB.FirstOrDefault(x => x.OpportunityId == secondOpportunity)!;
        OpportunityLifeCyclePlan opportunityLifeCyclePlan = opportunity.ToLifeCyclePlan();

        opportunityLifeCyclePlan.State.Complete(opportunityLifeCyclePlan, "Complete");

        Console.WriteLine("End");
    }
}
