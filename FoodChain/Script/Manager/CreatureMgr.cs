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
            if (var.State == status.mature)
            {
                Creature food = this.Find_Food(var);
                if (food == null)
                    var.AddHungry();
                else
                {
                    var.Eat(food);
                    GL_List_Creature.Remove(food);
                    foreach (List<Creature> var_S in this.GL_List_Species)
                    {
                        foreach (Creature var_C in var_S)
                        {
                            if (var_C == food)
                            {
                                var_S.Remove(food);
                                return;
                            }
                        }
                    }
                }
            }
        }

        public Species Create_Species(string Id, int Hungry_Max, int Age_Max, int Growth_To_Grow, int Num_Max)
        {
            Species var = new Species(Id, Hungry_Max, Age_Max, Growth_To_Grow, Num_Max);
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
