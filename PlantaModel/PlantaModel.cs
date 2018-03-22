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
    public class PlantaModel
    {
        //Public class NAME
        //SetName
        //GetName

       
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

}
