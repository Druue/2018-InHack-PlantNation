using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantaLogic;
using PlantaModel;
using System.IO;
/// <summary>
/// Connection to the .txt files
/// </summary>
namespace PlantaDAL
{
    public class PlantaDatabase
    {
        public static void GetList(string filename)
        {
            if (File.Exists(filename))
            {
                int row_count = 0;

                StreamReader reader = new StreamReader(filename);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    allFiles.Add(line);
                    row_count++;
                }
                reader.Close();
            }
        }

        static List<string> allFiles = new List<string>();

        public static List<Journal> DB_getJournal(string filename)
        {
            List<Journal> journal = new List<Journal>();

            GetList(filename);
            string[] list_from_file = allFiles.ToArray();

            for (int i = 0; i < list_from_file.Length; i++)
            {
                Journal j = new Journal();
                string[] splitted = list_from_file[i].Split('+');
                j.setNickname(splitted[0]);
                j.setPlantname(splitted[1]);
                DateTime watering_date = Convert.ToDateTime(splitted[3]).AddDays(int.Parse(splitted[2]) + 1);
                j.setDate(watering_date);
                journal.Add(j);
            }

            journal.Sort((x, y) => x.getDate().CompareTo(y.getDate()));


            return journal;

        }
        //..GetList(..) = Main reader, Reads the .txt of everything
        //..SetList(..) = Main writer, Writes the .txt of user
    }
}
