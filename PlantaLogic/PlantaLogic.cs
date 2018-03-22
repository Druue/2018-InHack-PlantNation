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
                    else if(difference - int.Parse(interval[i]) <0)
                    {
                        emergencyWater[countEmergency] = i;
                        countEmergency++;
                    }
                }
                lib.SetEmergencyList(emergencyWater);
                lib.SetWaterToday(needWater);     
            }
        }
    }
}
