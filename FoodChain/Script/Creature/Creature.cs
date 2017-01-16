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
        //Age
        public int Age;
        //Sexual Maturity
        public bool Maturity;
        //Individual Energy
        public double Energy;

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
            Age = 0;
            Energy = 0;
            Maturity = false;
        }

        /// <summary>  
        /// Creature() init
        /// </summary>  
        /// <returns></returns> 
        public Creature(Species var)
        {
            this.Id = var.Id;
            this.Hungry_Ratio = var.Hungry_Ratio;
            this.Age_Max = var.Age_Max;
            this.Age_To_Grow = var.Age_To_Grow;
            this.Age_To_Reproduce = var.Age_To_Reproduce;
            this.FoodList = var.FoodList;
            this.Num_Max = var.Num_Max;
            this.Energy_Growth = var.Energy_Growth;
            this.Energy_Max = var.Energy_Max;

            Birth = GlobalFunction.GetTimeString();
            sexual[] sexs = Enum.GetValues(typeof(sexual)) as sexual[];
            Random random = new Random();
            Sex = sexs[random.Next(0, sexs.Length)];
            State = status.childhood;
            Age = 0;
            Energy = 0;
            Maturity = false;
        }

        /// <summary>  
        /// Get_Old() by time
        /// </summary>  
        /// <returns></returns> 
        public void Get_Old()
        {
            switch (this.State)
            {
                case status.childhood: this.Energy += GlobalFunction.GetRandom() * this.Energy_Max * this.Energy_Growth; break;
                case status.mature: this.Energy -= GlobalFunction.GetRandom() * this.Energy_Max * this.Hungry_Ratio; break;
                case status.death: this.Energy -= GlobalFunction.GetRandom() * this.Energy_Max * this.Energy_Blet; break;
            }
            if (this.Energy <= 0)
            {
                this.State = status.death;
                return;
            }
            Age++;
            if (Age >= this.Age_To_Reproduce)
            {
                this.Maturity = true;
            }
            if (Age >= this.Age_To_Grow)
            {
                this.State = status.mature;
            }
            if (Age >= this.Age_Max)
            {
                this.State = status.death;
            }
        }

        /// <summary>  
        /// Eat food
        /// </summary>  
        /// <returns></returns> 
        public void Eat(Creature food)
        {
            foreach (Species var in this.FoodList)
            {
                if (var.Id == food.Id)
                {
                    if (food.Energy >= 0)
                    { 
                        this.Energy += GlobalFunction.GetRandom() * food.Energy;
                        return;
                    }
                }
            }
        }

        /// <summary>  
        /// Give_Birth()  
        /// </summary>  
        /// <param></param>  
        /// <returns></returns>
        public Creature Give_Birth()
        {
            //Creature var_New_Individual = new Creature();
            Creature var_New_Individual = new Creature((Species)this);

            var_New_Individual.Energy = GlobalFunction.GetRandom() * 0.4 * this.Energy;
            this.Energy = this.Energy * 0.6;
            
            /*
             * Copy the basic property the Species has
             */
            /*var_New_Individual.Id = this.Id;
            var_New_Individual.Hungry_Max = this.Hungry_Max;
            var_New_Individual.Age_Max = this.Age_Max;
            var_New_Individual.Growth_To_Grow = this.Growth_To_Grow;
            var_New_Individual.Growth_To_Reproduce = this.Growth_To_Reproduce;
            var_New_Individual.FoodList = this.FoodList;*/

            return var_New_Individual;
        }
    }
}
