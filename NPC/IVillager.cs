using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageSimLogicTest.NPC
{
    interface IVillager
    {   
        /// <summary>
        /// A villager needs to have a FirstName, a gender (bool Male), an age, a hardiness rating, an indication of if they are single, 
        /// </summary>
        string Name { get; set; }
        bool Male { get; set; }
        ushort Age { get; set; }
        int Hardiness { get; set; }
        bool IsMarried { get; set; }
        Villager Spouse { get; set; }
        List<Villager> Descendants { get; set; }
        List<Villager> Parents { get; set; }
        VillagerCouple Relationship { get; set; }
        
    }
}
