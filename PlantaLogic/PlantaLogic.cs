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
    public class PlantaCalc
    {
        public class UserDashboard
        {
            public void PlantNameEmergency(PlantaLibrary.UserDashboard lib)
            {
                string date = DateTime.Today.DayOfYear.ToString();
                List<string> lastWatered = lib.GetLastWatered();
                List<string> nickName = lib.GetNick();
                List<string> interval = lib.GetDays();
                List<int> needWater = new List<int>();
                List<int> emergencyWater = new List<int>();
                int countWaterToday = 0;
                int countEmergency = 0;
                for (int i = 0; i < nickName.Count; i++)
                {
                    DateTime watered = DateTime.Parse(lastWatered[i]);
                    int difference = watered.DayOfYear - DateTime.Today.DayOfYear;
                    if (difference - int.Parse(interval[i]) == 0)
                    {
                        needWater[countWaterToday] = i;
                        countWaterToday++;
                    }
                    else if (difference - int.Parse(interval[i]) < 0)
                    {
                        emergencyWater[countEmergency] = i;
                        countEmergency++;
                    }
                }
                lib.SetEmergencyList(emergencyWater);
                lib.SetWaterToday(needWater);
            }
        }
        //Finish with UI layer, connect to db.
        /*
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
                    int watering_interval = ;

                    //short interval plants
                    if (watering_interval <= 4)
                    {
                        isdead[i] = shortInterval(last_watered, watering_interval);

                        if (isdead[i])
                        {
                            dead_count++;
                            points += points_death;
                        }
                    }
                    //long interval plants
                    else
                    {
                        isdead[i] = longInterval(last_watered, watering_interval);
                        if (isdead[i])
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
                int today = DateTime.Today.DayOfYear;

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

                int today = DateTime.Today.DayOfYear;

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
        }*/
    }
}
