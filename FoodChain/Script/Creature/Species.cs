using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodChain
{
    class Species : Element
    {
        /*
        * This is the basic property the Species has
        */
        //Species Id
        public string Id = "";
        //The Max Hungry To Die
        public double Hungry_Ratio = 0;
        //The Max Age To Die
        public int Age_Max = 5;
        //The Max Growth To Get GrowUp
        public int Age_To_Grow = 3;
        //The Growth To Give A Bbaby
        public int Age_To_Reproduce = 4;
        //The Individual Energy To Have
        public double Energy_Max = 5.0;
        //Energy To Groth
        public double Energy_Growth = 1.0;
        //
        public double Energy_Blet = 0.2;
        //Food
        public List<Species> FoodList = new List<Species>();
        //Species Max Num
        public int Num_Max = 50;

        /// <summary>  
        /// Species()  
        /// </summary>  
        /// <param></param>  
        /// <returns></returns>
        public Species()
        {
            this.Id = "";
            this.Hungry_Ratio = 0;
            this.Age_Max = 0;
            this.Age_To_Grow = 0;
            this.Age_To_Reproduce = 0;
            this.Energy_Max = 0;
            this.Energy_Growth = 0;
        }

        /// <summary>  
        /// Species()  
        /// </summary>  
        /// <param></param>  
        /// <returns></returns>
        public Species(string Id, double Hungry_Ratio, int Age_Max, int Age_To_Grow, int Age_To_Reproduce, int Num_Max, int Energy_Max, double Energy_Growth)
        {
            this.Id = Id;
            this.Hungry_Ratio = Hungry_Ratio;
            this.Age_Max = Age_Max;
            this.Age_To_Grow = Age_To_Grow;
            this.Age_To_Reproduce = Age_To_Reproduce;
            this.Num_Max = Num_Max;
            this.Energy_Max = Energy_Max;
            this.Energy_Growth = Energy_Growth;
        }

        public bool EatAble (Creature food)
        {
            //if (this.FoodList.Contains((Species)food))
            //    return true;
            //else
            //    return false;
            foreach (Species var in this.FoodList)
            {
                //if(var.Id == food.Id & food.State == status.mature)
                //    return true;
                if (var.Id == food.Id & food.Energy >= 0 & food.State != status.childhood)
                    return true;
            }
            return false;
        }
    }
}
