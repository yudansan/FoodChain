using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FoodChain
{
    class Program
    {
        static void Main(string[] args)
        {
            run(50000);
        }

        //static void run(int times)
        //{
        //    int i = times;
        //    List<Creature> sheep_List = new List<Creature>();
        //    Creature sheep = new Creature();
        //    Creature grass = new Creature();
        //    sheep.FoodList.Add(grass);
        //    sheep_List.Add(sheep);
        //    while (i-- > 0)
        //    {
        //        List<Creature> sheep_List_Death = new List<Creature>();
        //        List<Creature> sheep_List_Birth = new List<Creature>();
        //        foreach (Creature var in sheep_List)
        //        {
        //            var.Get_Old();
        //            var.Eat(grass);
        //            if (var.State == status.death)
        //                sheep_List_Death.Add(var);
        //            if (var.State == status.mature)
        //                sheep_List_Birth.Add(var.Give_Birth());
        //        }
        //        foreach (Creature var in sheep_List_Death)
        //        {
        //            sheep_List.Remove(var);
        //        }
        //        foreach (Creature var in sheep_List_Birth)
        //        {
        //            sheep_List.Add(var);
        //        }
        //        String log = String.Format("Num : {0}", sheep_List.Count);
        //        Console.WriteLine(log);
        //        System.Threading.Thread.Sleep(500);
        //    }
        //}

        static void run(int times)
        {
            int i = times;
            Species S_Sheep = new Species("Sheep", 3, 10, 5, 500);
            Species S_Grass = new Species("Grass", 10, 10, 5, 500);
            S_Sheep.FoodList.Add(S_Grass);

            CreatureMgr GL_Mgr = new CreatureMgr();

            GL_Mgr.Create_Species_By_Num(S_Sheep, 20);
            GL_Mgr.Create_Species_By_Num(S_Grass, 60);

            while (i-- > 0)
            {
                foreach (List<Creature> var_S in GL_Mgr.GL_List_Species)
                {
                    List<Creature> List_Death = new List<Creature>();
                    List<Creature> List_Birth = new List<Creature>();
                    foreach (Creature var_C in var_S)
                    {
                        GL_Mgr.Have_A_Day(var_C);
                        if (var_C.State == status.death)
                        {
                            List_Death.Add(var_C);
                            break;
                        }
                        if (var_C.State == status.mature && var_S.Count < var_C.Num_Max)
                            List_Birth.Add(var_C.Give_Birth());
                    }

                    foreach (Creature var_C in List_Death)
                    {
                        var_S.Remove(var_C);
                        GL_Mgr.GL_List_Creature.Remove(var_C);
                    }
                    foreach (Creature var_C in List_Birth)
                    {
                        var_S.Add(var_C);
                        GL_Mgr.GL_List_Creature.Add(var_C);
                    }

                }
                System.Threading.Thread.Sleep(20);
                String log = String.Format("Day : {0}, Sheep : {1}, Grass : {2}", times - i, GL_Mgr.GL_List_Species[0].Count, GL_Mgr.GL_List_Species[1].Count);
                Console.WriteLine(log);
            }
            //String log = String.Format("Day : {0}, Sheep : {1}, Grass : {2}", times - i, GL_Mgr.GL_List_Species[0].Count, GL_Mgr.GL_List_Species[1].Count);
            //Console.WriteLine(log);
        }
    }
}
