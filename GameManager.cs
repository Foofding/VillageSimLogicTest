using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using VillageSimLogicTest.Evaluators;
using VillageSimLogicTest.NPC;


namespace VillageSimLogicTest
{
   public class GameManager
    {
        private const int DefaultAgeInterval = 10;
        private Timer _timer;
        private IConditionsEvaluator _evaluator;
        private Village _village;       
        public Village Village { get { return _village; } }

        public int timerAge = 0;
        public int timerPregnancy = 0;

        public GameManager()
        {
            InitializeGame();
        }

        public void InitializeGame()
        {
            _village = new Village(20, 3);
        }

        public void Run(IConditionsEvaluator evaluator)
        {
            _evaluator = evaluator;
            _timer = new Timer();
            
            _timer.Interval = _evaluator.TimerInterval;
            _timer.Elapsed += _timer_Elapsed;                      
            _timer.Start();

            foreach (var villager in _village.Villagers)
            {
                if(villager.Male)
                Console.WriteLine("Male: " + villager.FirstName + " " + villager.LastName + ", Age: " + villager.Age + ", Hardiness: " + villager.Hardiness + "\n") ;
                else Console.WriteLine("Female: " + villager.FirstName + " " + villager.LastName +  ", Age: " + villager.Age + ", Hardiness: " + villager.Hardiness + "\n");
            }
            Console.ReadLine();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timerAge++;
            Village.CoupleVillagers();       
                     

            //foreach(Villager s in _village.Villagers)
            //{
            //    if ((s.Created - DateTime.Now).TotalSeconds > DefaultAgeInterval)
            //    {
            //        s.Age++;
            //        s.Created = DateTime.Now;
            //    }
            //}

            if (_evaluator.CanSpawnNewVillager())
            {
                var villagerCouples = _village.VillagerCouples.ToList();

                foreach (var couple in villagerCouples)
                {
                    lock (Village.Villagers)
                    {
                        if (_evaluator.CanCoupleHaveChild(couple))
                        {
                            couple.VillagerBirth();
                        }
                    }                    
                }               
                //Console.WriteLine(villager.FirstName + " age: " + villager.Age + "| Hardiness " + villager.Hardiness);
            }

            if (_evaluator.CanSpawnNewHouse())
            {
                Console.WriteLine("Creating new house");
            }                      
            _village.PrintCouples();
        }      
    }
}
