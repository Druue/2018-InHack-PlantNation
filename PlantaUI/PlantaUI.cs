using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantaModel;
using PlantaLogic;
using PlantaDAL;
using System.Windows.Forms;
using System.Drawing;
/// <summary>
/// Design and Control declarations
/// </summary>
namespace PlantaUI
{
    public class PlantaDisplay
    {
        //When asking for information from database, 2 things to keep in mind
        //When calling the db, You have to declare the method of the model and send it + the username if not more!
        //The db will fill the model method and then it is possible to grab that information from here using the Get model method.

        public PlantaLibrary.UserDashboard showDashboard(string fileName)
        {

            PlantaDatabase db = new PlantaDatabase();
            PlantaLibrary.UserDashboard lib = new PlantaLibrary.UserDashboard();
            PlantaCalc.UserDashboard logic = new PlantaCalc.UserDashboard();
            db.userPlants(fileName, lib);
            logic.PlantNameEmergency(lib);


            return lib;
        }
    }
}
