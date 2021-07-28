using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageSimLogicTest.Structure;
using VillageSimLogicTest.Evaluators;


namespace VillageSimLogicTest
{
   
    class Program
    {
      
        static void Main(string[] args)
        {
            

            ///<summary>
            ///When GameManager starts, it creates a Village with set number of starting villagers and houses.
            ///</summar>
            var gameManager = new GameManager();

            ///<summary>
            ///ConditionsEvaluator takes in village in question and determines new outcomes like whether a new
            ///villager can be created or not. 
            /// </summary>
            var evaluator = new ConditionsEvaluator(gameManager);
            //var evaluator = new AdvancedConditionsEvaluator();

            ///<summary>
            ///gameManager.Run(evaluator) takes in  IConditionsEvaluator object and uses stuff like evaluator's timer interval setting,
            ///and what ever else might effect evaluations.
            /// </summary>
            gameManager.Run(evaluator);

            #region MyRegion
            //int maleVilStartCount;
            //int femaleVilStartCount;
            //Console.WriteLine("Set the starting conditions for your village...\n" +
            //    "How many male villagers will your village start with?:");
            //maleVilStartCount = Convert.ToInt32(Console.ReadLine());  
            //Console.Write("How many female villagers?:");
            //femaleVilStartCount = Convert.ToInt32(Console.ReadLine()); 
            #endregion

        }
    }
}
