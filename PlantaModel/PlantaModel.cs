using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Library of things, Communication between the layers done here! Set-Get methods!
/// </summary>
namespace PlantaModel
{
    public class PlantaLibrary
    {
        //Public class NAME
        //SetName
        //GetName
        public class UserDashboard
        {
            List<string> plantNick = new List<string>();
            List<string> plantName = new List<string>();
            List<string> plantDays = new List<string>();
            List<string> plantLastWatered = new List<string>();
            List<string> plantIconNr = new List<string>();
            List<int> waterEmergency = new List<int>();
            List<int> waterToday = new List<int>();
 
            public void SetNick(string name)
            {
                plantNick.Add(name);
            }
            public List<string> GetNick()
            {
                return plantNick;
            }

            public void SetName(string name)
            {
                plantNick.Add(name);
            }
            public List<string> GetName()
            {
                return plantName;
            }

            public void SetInterval(string interval)
            {
                plantDays.Add(interval);
            }
            public List<string> GetDays()
            {
                return plantDays;
            }

            public void SetLastWatered(string lastWatered)
            {
                plantLastWatered.Add(lastWatered);
            }
            public List<string> GetLastWatered()
            {
                return plantLastWatered;
            }

            public void SetIconNr(string nr)
            {
                plantIconNr.Add(nr);
            }
            public List<string> GetIconNr()
            {
                return plantIconNr;
            }

            public void SetEmergencyList(List<int> id)
            {
                waterEmergency = id;
            }
            public List<int> GetWaterEmergency()
            {
                return waterEmergency;
            }

            public void SetWaterToday(List<int> id)
            {
                waterToday = id;
            }
            public List<int> GetWaterToday()
            {
                return waterToday;
            }
        }
    }
}
