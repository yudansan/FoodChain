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
        //define log
        static List<List<int>> Log_Species;

        static void Main(string[] args)
        {
            run(50000);
        }

        static void run(int times)
        {
            int i = times;

            //Add Species
            Species S_Wolf = new Species("Wolf", 0.01, 200, 50, 80, 100, 10, 0.015);
            Species S_Sheep = new Species("Sheep", 0.012, 120, 30, 70, 100, 8, 0.015);
            Species S_Grass = new Species("Grass", 0, 100, 30, 20, 100, 6, 0.03);

            //Init Foodchain
            S_Wolf.FoodList.Add(S_Sheep);
            S_Sheep.FoodList.Add(S_Grass);

            CreatureMgr GL_Mgr = new CreatureMgr();

            //Add Creature
            GL_Mgr.Create_Species_By_Num(S_Wolf, 1);
            GL_Mgr.Create_Species_By_Num(S_Sheep, 10);
            GL_Mgr.Create_Species_By_Num(S_Grass, 80);
            //Init log
            Debug_Log_Init(GL_Mgr);

            while (i-- > 0)
            {
                foreach (List<Creature> var_S in GL_Mgr.GL_List_Species)
                {
                    List<Creature> List_Death = new List<Creature>();
                    List<Creature> List_Birth = new List<Creature>();
                    foreach (Creature var_C in var_S)
                    {
                        //Get older
                        GL_Mgr.Have_A_Day(var_C);
                        //Who is to die
                        if (var_C.State == status.death && var_C.Energy <= 0)
                        {
                            List_Death.Add(var_C);
                            continue;
                        }
                        //Who is to have a baby
                        if (var_C.Generative(List_Birth.Count + var_S.Count) && var_C.Maturity && var_C.Energy >= var_C.Energy_Max * 0.8)
                            List_Birth.Add(var_C.Give_Birth());
                    }
                    //Remove who is dead
                    foreach (Creature var_C in List_Death)
                    {
                        var_S.Remove(var_C);
                        GL_Mgr.GL_List_Creature.Remove(var_C);
                    }
                    //Add who is born
                    foreach (Creature var_C in List_Birth)
                    {
                        var_S.Add(var_C);
                        GL_Mgr.GL_List_Creature.Add(var_C);
                    }
                }
                System.Threading.Thread.Sleep(50);
                //Output Log
                String log = String.Format("Day : {0}, Wolf : {1}, Sheep : {2}, Grass : {3}", times - i, GL_Mgr.GL_List_Species[0].Count, GL_Mgr.GL_List_Species[1].Count, GL_Mgr.GL_List_Species[2].Count);
                Console.WriteLine(log);

                //Read log
                Debug_Log_Read(GL_Mgr);
                if ((times - i) % 10 == 0)
                {
                    string Line_L = "var initialLabel = [";
                    string Line_W = "var wolfData = [";
                    string Line_S = "var sheepData = [";
                    string Line_G = "var grassData = [";
                    int localTimes = (times - i) / 10;

                    while (localTimes > 0)
                    {
                        Line_L += localTimes.ToString() + ",";
                        Line_W += Log_Species[0][(localTimes) * 10 -1] + ",";
                        Line_S += Log_Species[1][(localTimes) * 10 -1] + ",";
                        Line_G += Log_Species[2][(localTimes) * 10 -1] + ",";
                        //localTimes -= (times - i) / 10;
                        localTimes -= 1;
                    }
                    Line_L += "]\n";
                    Line_W += "]\n";
                    Line_S += "]\n";
                    Line_G += "]\n";

                    log_Write(Line_L + Line_W + Line_S + Line_G);
                }
            }
         }

        static void Debug_Log_Init(CreatureMgr GL_Mgr)
        {
            Log_Species = new List<List<int>>();
            foreach (List<Creature> var_S in GL_Mgr.GL_List_Species)
            {
                List<int> var_List = new List<int>();
                Log_Species.Add(var_List);
            }
        }

        static void Debug_Log_Read(CreatureMgr GL_Mgr)
        {
            int num = 0;
            foreach (List<Creature> var_S in GL_Mgr.GL_List_Species)
            {
                Log_Species[num].Add(var_S.Count);
                num++;
            }
        }

        static void log_Write(string log)
        {
            string path = "InitialData.js";
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(log);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
    }
}
