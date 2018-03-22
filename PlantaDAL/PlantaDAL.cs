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

        public bool Create_new_user(string filename)
        {
            //check if the name already exists
            if (File.Exists(filename))
            {
                return true;
            }

            //if not create a new file with this name
            File.Create(filename);
            return false;
        }

        public bool Log_new_user(string filename)
        {
            //check if the name already exists
            if (File.Exists(filename))
            {
                return true;
            }
            return false;
        }

        //..GetList(..) = Main reader, Reads the .txt of everything
        //..SetList(..) = Main writer, Writes the .txt of user
        List<string> allFiles = new List<string>();
        public void userPlants(string fileName, PlantaLibrary.UserDashboard lib)
        {
            GetList("..\\..\\"+fileName+".txt");
            for (int i = 0; i < allFiles.Count; i++)
            {
                string[] files = allFiles.ToArray();
                string[] userPlants = files[i].Split('+');
                lib.SetNick(userPlants[0]);
                lib.SetName(userPlants[1]);
                lib.SetInterval(userPlants[2]);
                lib.SetLastWatered(userPlants[3]);
                lib.SetIconNr(userPlants[4]);
            }

        }
        public void GetList(string filename)
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
    }
}
