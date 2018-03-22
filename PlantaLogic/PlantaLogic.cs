using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantaModel;
/// <summary>
/// All calculations done here!
/// </summary>
namespace PlantaLogic
{
    class PlantaLogic
    {
        public class isDead
        {
            bool[] isdead = new bool[5];
            int last_watered;
            int dead_count = 0;

            //the points system
            int points = 0;
            int points_watered = 50;
            int points_missed = -25;
            int points_death = -100;

            public bool deadPlants()
            {
                for (int i = 0; i < isdead.Length; i++)
                {

                    string[] split = isdead[i].Split("€");
                    int watering_interval = Int32.Parse(split[2]);

                    //short interval plants
                    if (watering_interval <= 4)
                    {
                        isdead[i] = shortInterval(last_watered, watering_interval);

                        if (isdead)
                        {
                            dead_count++;
                            points += points_death;
                        }
                    }
                    //long interval plants
                    else
                    {
                        isdead[i] = longInterval(last_watered, watering_interval);
                        if (isdead)
                        {

                            dead_count++;
                            points += points_death;

                        }
                    }
                }
            }

            public bool shortInterval(int last_watered, int interval)
            {
                //maximum days without watering
                int max_days = interval * 4;

                //determining the time
                DateTime today = DateTime.Today;
                int time_lastWater = today - last_watered;

                //dead
                if (time_lastWater > max_days)
                {
                    return true;
                }
                //alive
                else
                {
                    return false;
                }
            }

            public bool longInterval(int last_watered, int interval)
            {
                //maximum days without watering
                int max_days = interval * 2;

                //determining the time
                DateTime today = DateTime.Today;
                int time_lastWater = today - last_watered;

                //dead
                if (time_lastWater > max_days)
                {
                    return true;
                }
                //alive
                else
                {
                    return false;
                }
            }
        }
    }
}
