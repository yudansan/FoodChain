using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodChain
{
    class CreatureMgr
    {
        public List<List<Creature>> GL_List_Species = new List<List<Creature>>();
        public List<Creature> GL_List_Creature = new List<Creature>();

        public void CreateList(Creature var)
        {
            List<Creature> var_List = new List<Creature>();
            GL_List_Species.Add(var_List);
        }

        /// <summary>  
        /// Find_Food()  
        /// </summary>  
        /// <param></param>  
        /// <returns></returns>
        public Creature Find_Food(Creature var)
        {
            foreach (Creature food in this.GL_List_Creature)
            {
                if (var.EatAble(food))
                    return food;
            }
            return null;
        }

        /// <summary>  
        /// Have_A_Day()  
        /// </summary>  
        /// <param></param>  
        /// <returns></returns>
        public void Have_A_Day(Creature var)
        {
            var.Get_Old();
            //State = mature
            if (var.State == status.mature)
            {
                if (var.Energy >= var.Energy_Max * 0.8)
                    return;
                Creature food = this.Find_Food(var);
                if (food == null)
                { }
                else
                {
                    var.Eat(food);
                    food.State = status.death;
                    //GL_List_Creature.Remove(food);
                    //foreach (List<Creature> var_S in this.GL_List_Species)
                    //{
                    //    foreach (Creature var_C in var_S)
                    //    {
                    //        if (var_C == food)
                    //        {
                    //            var_S.Remove(food);
                    //            return;
                    //        }
                    //    }
                    //}
                }
            }
            //State = childhood
            else if (var.State == status.childhood)
            {
               
            }
        }

        public Species Create_Species(string Id, double Hungry_Ratio, int Age_Max, int Growth_To_Grow, int Growth_To_Reproduce, int Num_Max, int Energy_Max, double Energy_Growth)
        {
            Species var = new Species(Id, Hungry_Ratio, Age_Max, Growth_To_Grow, Growth_To_Reproduce, Num_Max, Energy_Max, Energy_Growth);
            return var;
        }

        public List<Creature> Create_Species_By_Num(Species var, int num)
        {
            if (num > 0)
            {
                List<Creature> var_L = new List<Creature>();
                for (int i = 0; i <= num; i++)
                {
                    Creature var_C = new Creature(var);
                    var_L.Add(var_C);
                    GL_List_Creature.Add(var_C);
                }
                GL_List_Species.Add(var_L);
                return var_L;
            }
            return null;
        }
    }
}
