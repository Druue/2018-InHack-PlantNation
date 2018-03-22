using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantaLogic;
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
        //public void 
    }
}
