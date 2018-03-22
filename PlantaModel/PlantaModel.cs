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
                plantName.Add(name);
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

        //PLANT DELETE
        public class DeletePlant
        {
            List<string> plantNicknames = new List<string>();

            public void SetPlantNickname(string plantnickname)
            {
                plantNicknames.Add(plantnickname);
            }
            public List<string> GetPlantNickname()
            {
                return plantNicknames;
            }
        }
        //PLANT ADD
        public class AllPlantNames
        {
            List<string> plantNames = new List<string>();

            public void SetPlantName(string plantname)
            {
                plantNames.Add(plantname);
            }
            public List<string> GetPlantName()
            {
                return plantNames;
            }
        }
    }

       
    }
    public class Journal
    {
        //Day to be watered – nickname – plantname

        DateTime date;
        string nickname;
        string plantname;

        public void setDate(DateTime date_s)
        {
            date = date_s;
        }
        public void setNickname(string name)
        {
            nickname = name;
        }
        public void setPlantname(string plant)
        {
            plantname = plant;
        }
        public DateTime getDate()
        {
            return date;
        }

        public string getNickname()
        {
            return nickname;
        }
        public string getPlantname()
        {
            return plantname;
        }
    }

    public class JournalList
    {
        List<Journal> journalList = new List<Journal>();

        public void addList(Journal record)
        {
            journalList.Add(record);
        }

        public List<Journal> getList()
        {
            return journalList;
        }
    }


