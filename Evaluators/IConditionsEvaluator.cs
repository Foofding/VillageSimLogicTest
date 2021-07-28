using VillageSimLogicTest.NPC;

namespace VillageSimLogicTest.Evaluators
{
    public interface IConditionsEvaluator
    {
        int TimerInterval { get; set; }
        bool CanSpawnNewHouse();
        bool CanSpawnNewVillager();
        bool CanCoupleHaveChild(VillagerCouple couple);
     
    }
}