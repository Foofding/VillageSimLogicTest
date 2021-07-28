using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageSimLogicTest.NPC;

namespace VillageSimLogicTest.Structure
{ 

    public class House
    {
        public int tier;
        //condition 1-5. 1 being broken down, 5 being prestine.
        public int condition;
        public List<Villager> Occupants;
        public bool AtMaxCapacity { get; set; }

        public House()
        {
            condition = 100;
            tier = 1;
        }

    }
}
