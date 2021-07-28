using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageSimLogicTest.NPC;

namespace VillageSimLogicTest.Evaluators
{
    public class AdvancedConditionsEvaluator : IConditionsEvaluator
    {

        private Village _village;
        private DateTime _lastCreatedHouse = DateTime.Now;
        private DateTime _lastCreatedVillager = DateTime.Now;
        public int _timerInterval;

        public int TimerInterval { get { return _timerInterval; } set { TimerInterval = _timerInterval; } }



        public bool CanSpawnNewHouse()
        {
            if (_lastCreatedHouse < DateTime.Now.AddSeconds(-8))
            {
                _lastCreatedHouse = DateTime.Now;
                return true;
            }
            //if (_village.Villagers.Count > 5)
            //    return true;
            return false;
        }

        public bool CanSpawnNewVillager()
        {
            return false;
        }


        public bool CanCoupleHaveChild(VillagerCouple couple)
        {
            if (couple.CohesionScale >= 60 && couple.Husband.Age <= 65 && couple.Wife.Age <= 45 )
                return true;
            return false;
        }
    }
}
