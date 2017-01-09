using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodChain
{
    /// <summary>  
    /// sexual:male,female
    /// </summary>  
    /// <returns></returns> 
    enum sexual : byte　　//显示指定枚举的底层数据类型
    {
        male,
        female,
    }

    /// <summary>  
    /// status:childhood,mature,death
    /// </summary>  
    /// <returns></returns> 
    enum status : byte　　//显示指定枚举的底层数据类型
    {
        childhood,
        mature,
        death,
    }

    /// <summary>  
    /// Creature
    /// </summary>
    [Serializable]
    class Creature : Species
    {
        /*
         * This is the trends property the Individual has
         */
        //Time When Born
        public string Birth;
        public sexual Sex;
        public status State;
        //How Hungry
        public int Hungry;
        //Age
        public int Age;
        //Growth
        public int Growth;

        /// <summary>  
        /// Creature() init
        /// </summary>  
        /// <returns></returns> 
        public Creature()
        {
            Birth = GlobalFunction.GetTimeString();
            sexual[] sexs = Enum.GetValues(typeof(sexual)) as sexual[];
            Random random = new Random();
            Sex = sexs[random.Next(0, sexs.Length)];
            State = status.childhood;
            Hungry = 0;
            Age = 0;
            Growth = 0;
        }

        /// <summary>  
        /// Creature() init
        /// </summary>  
        /// <returns></returns> 
        public Creature(Species var)
        {
            this.Id = var.Id;
            this.Hungry_Max = var.Hungry_Max;
            this.Age_Max = var.Age_Max;
            this.Growth_To_Grow = var.Growth_To_Grow;
            this.FoodList = var.FoodList;
            this.Num_Max = var.Num_Max;

            Birth = GlobalFunction.GetTimeString();
            sexual[] sexs = Enum.GetValues(typeof(sexual)) as sexual[];
            Random random = new Random();
            Sex = sexs[random.Next(0, sexs.Length)];
            State = status.childhood;
            Hungry = 0;
            Age = 0;
            Growth = 0;
        }

        /// <summary>  
        /// Get_Old() by time
        /// </summary>  
        /// <returns></returns> 
        public void Get_Old()
        {
            Age++;
            if (Age >= this.Growth_To_Grow)
                this.State = status.mature;
            if (Age >= this.Age_Max)
            {
                this.State = status.death;
                return;
            }
        }

        /// <summary>  
        /// Eat food
        /// </summary>  
        /// <returns></returns> 
        public void Eat(Creature food)
        {
            if (this.FoodList.Contains(food))
            {
                if (food.State == status.mature)
                { 
                    this.Growth++;
                    return;
                }
            }
            this.Hungry++;
            if (this.Hungry >= Hungry_Max)
                this.State = status.death;
        }

        /// <summary>  
        /// Add Hungry
        /// </summary>  
        /// <returns></returns> 
        public void AddHungry()
        {
            this.Hungry++;
            if (this.Hungry >= Hungry_Max)
                this.State = status.death;
        }

        /// <summary>  
        /// Give_Birth()  
        /// </summary>  
        /// <param></param>  
        /// <returns></returns>
        public Creature Give_Birth()
        {
            Creature var_New_Individual = new Creature();

            /*
             * Copy the basic property the Species has
             */
            var_New_Individual.Id = this.Id;
            var_New_Individual.Hungry_Max = this.Hungry_Max;
            var_New_Individual.Age_Max = this.Age_Max;
            var_New_Individual.Growth_To_Grow = this.Growth_To_Grow;
            var_New_Individual.FoodList = this.FoodList;

            return var_New_Individual;
        }
    }
}
