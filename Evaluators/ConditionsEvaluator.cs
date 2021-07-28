using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageSimLogicTest.NPC;
using VillageSimLogicTest.Structure;

namespace VillageSimLogicTest.Evaluators
{
    public class ConditionsEvaluator : IConditionsEvaluator
    {
        private Village _village;
        private DateTime _lastCreatedHouse = DateTime.Now;
        private DateTime _lastCreatedVillager = DateTime.Now;
        private int _timerInterval = 2000;
        public int TimerInterval { get { return _timerInterval; } set { TimerInterval = _timerInterval; } }


        public ConditionsEvaluator(GameManager gameManager)
        {
            _village = gameManager.Village;
        }


        public bool CanSpawnNewVillager()
        {
        //if housing is available
        //if there is a couple available OR someone moves to village
           if(_village.VillagerCouples.Count > 1)
               return true;
            return false;
        }
        

        public bool CanSpawnNewHouse()
        {
            //is there a source for wood? 
            //is there a need for more house?
            if (_lastCreatedHouse < DateTime.Now.AddSeconds(-30))
            {
                _lastCreatedHouse = DateTime.Now;
                return true;
            }
            //if (_village.Villagers.Count > 5)
            //    return true;
            return false;
        }


        public bool CanCoupleHaveChild(VillagerCouple couple)
        {
            if (couple.IsFertile())
                return true;
            return false;
        }


        //public bool VillagerLookingForMate(Villager male, Villager Female)
        //{
            
            
        //}


    }
}
