using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageSimLogicTest;

namespace VillageSimLogicTest.NPC
{
    public class VillagerCouple
    {
        private Village _village;
        private static Random _random = new Random();
        public Villager Husband { get; set; }
        public Villager Wife { get; set; }
        public string FamilyName { get; set; }
        public DateTime MarriageDate { get; set; }
        public int CohesionScale { get; set; }
        public List<Villager> Decendents { get; set; }
        public bool Fertile { get; set; }


        public VillagerCouple(Village village)
        {            
            _village = village;
            Decendents = new List<Villager>();
            CohesionScale = _random.Next(30, 90);            
        }       

        public Villager VillagerBirth()
        {
            var villager = new Villager();
            _village.Villagers.Add(villager);
            Decendents.Add(villager);
            CohesionScale -= _random.Next(-20, 20);
            return villager;
        }

        public bool IsFertile()
        {
            if (CohesionScale > 40 && Wife.Age < 45 && Husband.Age < 65)
            {
                return true;
            }
            else return false;
        }

        public override string ToString()
        {
            return $"{FamilyName}";            
        }

    }


}
