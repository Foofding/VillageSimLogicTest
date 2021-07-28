using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VillageSimLogicTest.NPC
{
     public class Villager
    {
        //private static Random random = new Random(DateTime.Now.Millisecond);
        private const int DefaultAgeInterval = 10;
        private static Random random = new Random(1);
        private int _age;

        //basics
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Male { get; set; }       
        public int Age
        {
            get
            {
                return (_age += (int)(DateTime.Now - Created).TotalSeconds / DefaultAgeInterval);
            }
            set
            {
                _age = value;
            }
        }
        public DateTime Birthday { get; set; }
        public DateTime Created { get; set; }
        public int Hardiness { get; set; }  
        public bool IsMarried { get; set; }
        public Villager Spouse { get; set; }
        public List<Villager> Descendants { get; set; }
        public VillagerCouple Parents { get; set; }
        public List<Villager> Siblings { get; set; }

        //public List<Villager> Cousins { get; set; }
        //public List<Villager> Grandparents { get; set; }

        public VillagerCouple Relationship { get; set; }
        public enum Profession { Jobless, Lumberjack, Builder, Produce_Farmer, Wheat_Farmer, Baker, }

        //advanced
        public int health;
        public double defense;
        public double attack;

        public Villager(bool startOfGame = false)
        {
            Created = DateTime.Now;
            Male = (random.Next(0, 100) > 50);
            IsMarried = false;

            var lines = File.ReadAllLines("resources\\LastNames.txt");
            LastName = lines[random.Next(0, lines.Length - 1)];

            //if the game is just starting, the beginning villagers will be between ages 15-26
            if (startOfGame)
            {
                Age = random.Next(15, 26);
            }
            else Age = 0;
              
            if (Male != true)
            {                
                lines = File.ReadAllLines("resources\\FemaleFirstNames.txt");
                FirstName = lines[random.Next(0, lines.Length - 1)];
                Hardiness = random.Next(70, 90);
            }
            else if (Male == true)
            {
                lines = File.ReadAllLines("resources\\MaleFirstNames.txt");
                FirstName = lines[random.Next(0, lines.Length - 1)];
                Hardiness = random.Next(81, 96);
            }  
        }

        //for when a new villager is spawned by parents:
        public Villager(VillagerCouple parents)
        {
            Parents = parents;
            Male = (random.Next(0, 101) > 50);
            Age = 0;
            LastName = parents.FamilyName;

            if (Male != true)
            {
                var lines = File.ReadAllLines("resources\\FemaleFirstNames.txt");
                FirstName = lines[random.Next(0, lines.Length - 1)];                
            }
            else if (Male == true)
            {
                var lines = File.ReadAllLines("resources\\MaleFirstNames.txt");
                FirstName = lines[random.Next(0, lines.Length - 1)];                
            }          
                IsMarried = false;
                Hardiness = random.Next(1, 8);
        }

       
        public override string ToString()
        {
            var virtualAge = Age;
            return FirstName + " " + LastName + ", Age: " + virtualAge + (Male ? ", Male" : ", Female");
        }

        public Villager VillagerAdultRandom()
        {
           
            return new Villager { Age = random.Next(15, 26), FirstName = Path.GetRandomFileName(), Male = (random.Next(0, 101) > 50) };
        }

        public Villager VillagerAdultMale()
        {
            
            return new Villager { Age = random.Next(15, 26), FirstName = Path.GetRandomFileName(), Male = true, Hardiness = random.Next(80, 96)};
        }

        public Villager VillagerAdultFemale()
        {
           
            return new Villager { Age = random.Next(15, 26), FirstName = Path.GetRandomFileName(), Male = true, Hardiness = random.Next(85, 91) };
        }
    }   
}
