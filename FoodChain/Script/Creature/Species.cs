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
        public int Hungry_Max = 0;
        //The Max Age To Die
        public int Age_Max = 5;
        //The Max Growth To Get GrowUp
        public int Growth_To_Grow = 3;
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
            this.Hungry_Max = 0;
            this.Age_Max = 0;
            this.Growth_To_Grow = 0;
        }

        /// <summary>  
        /// Species()  
        /// </summary>  
        /// <param></param>  
        /// <returns></returns>
        public Species(string Id, int Hungry_Max, int Age_Max, int Growth_To_Grow, int Num_Max)
        {
            this.Id = Id;
            this.Hungry_Max = Hungry_Max;
            this.Age_Max = Age_Max;
            this.Growth_To_Grow = Growth_To_Grow;
            this.Num_Max = Num_Max;
        }

        public bool EatAble (Species food)
        {
            //if (this.FoodList.Contains((Species)food))
            //    return true;
            //else
            //    return false;
            foreach (Species var in this.FoodList)
            {
                if(var.Id == food.Id)
                    return true;
            }
            return false;
        }
    }
}
