using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageSimLogicTest.NPC;
using VillageSimLogicTest.Structure;
using System.IO;
using System.Timers;
using System.Diagnostics;

namespace VillageSimLogicTest
{
    public class Village
    {
        public List<Villager> Villagers { get; set; }
        public List<House> Houses { get; set; }
        public List<VillagerCouple> VillagerCouples { get; set; }

        //To test couples:
        //public Village(int singleVillagers, int houses, int couples)
        //{

        //    Villagers = new List<Villager>();
        //    for (int i = 0; i <= singleVillagers; i++)
        //    {
        //        var villager = new Villager();
        //        Villagers.Add(villager);
        //    }

        //    VillagerCouples = new List<VillagerCouple>();
        //    for (int i = 0; i < couples; i++)
        //    {
        //        var couple = new VillagerCouple(this);
        //        couple.Husband = new Villager();
        //        couple.Wife = new Villager();
        //        couple.Husband.Male = true;
        //        couple.Wife.Male = false;
        //        VillagerCouples.Add(couple);

        //    }
        //}

        public Village(int singleVillagers, int houses)
        {
            VillagerCouples = new List<VillagerCouple>();

            Villagers = new List<Villager>();
            for (int i = 0; i < singleVillagers; i++)
            {
                var villager = new Villager(true);
                Villagers.Add(villager);
            }
            var gameWatch = Stopwatch.StartNew();
            CoupleVillagers();
            gameWatch.Stop();
            Console.WriteLine(gameWatch.ElapsedMilliseconds);
        }

        public void CoupleVillagers()
        {           
            lock(Villagers)
            {
                var villagers = Villagers.ToList();
                foreach (var villager in Villagers)
                {
                    if (!villager.IsMarried && villager.Age > 15)
                    {
                        if (villager.Male && villager.Age > 15)
                        {
                            //for Male Villagers
                            var wife = villagers.FirstOrDefault(p => !p.IsMarried && !p.Male);
                            if (wife == null)
                                return;
                            var couple = new VillagerCouple(this)
                            {
                                Husband = villager,
                                Wife = wife,
                                FamilyName = villager.LastName,                                
                            };
                            couple.Fertile = couple.IsFertile();
                            wife.IsMarried = true;
                            villager.IsMarried = true;
                            VillagerCouples.Add(couple);
                            villager.Relationship = couple;
                            wife.Relationship = couple;
                            villager.Spouse = wife;
                            wife.Spouse = villager;
                            wife.LastName = villager.LastName;                            
                        }
                        else if (!villager.Male && villager.Age > 15)
                        {
                            //for Female Villagers
                            var husband = villagers.FirstOrDefault(p => !p.IsMarried && p.Male);
                            if (husband == null)
                                return;
                            var couple = new VillagerCouple(this)
                            {
                                Wife = villager,
                                Husband = husband,                                
                                FamilyName = husband.LastName
                            };                           
                            husband.IsMarried = true;
                            VillagerCouples.Add(couple);
                            villager.IsMarried = true;
                            villager.Relationship = couple;
                            husband.Relationship = couple;
                            villager.Spouse = husband;
                            villager.LastName = husband.LastName;
                            husband.Spouse = villager;
                            couple.FamilyName = husband.LastName;
                        }
                    }
                }
            }
           
        }
               
        public void PrintCouples()
        {
            Console.WriteLine(VillagerCouples.Count());
            foreach(var couple in VillagerCouples)
            {
                Console.WriteLine(couple.Husband.FirstName + " and " + couple.Wife.FirstName + " " + couple.FamilyName + "- " + couple.CohesionScale);

                foreach(var child in couple.Decendents)
                {
                    Console.WriteLine("\t -" + child);
                }
            }
            

        }
              

        //public void VillageStart(int males, int females)
        //{
        //    Villagers = new List<Villager>();
        //    for (int i = 0; 0 < males; i++)
        //    {
        //        Villagers.Add(VillagerMale());
        //    }

        //    for (int i = 0; 0 < females; i++)
        //    {
        //        Villagers.Add(VillagerFemale());
        //    }
        //}

        //static void VillageStatus()
        //{
        //    Console.WriteLine("Your village has: \n" + houses.Count() + " houses \n" + villagers.Count() + " villagers");
        //}
    }

   

}
