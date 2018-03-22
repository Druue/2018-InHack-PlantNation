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
        public Control AboutPlantNation()
        {
            string new_line = "\n";

            Label about = new Label();
            about.Height = 200;
            about.Width = 500;
            about.Text = "We, PlantNation, are a group of messengers sent by Gaia. " + new_line +
                "Our human names are Zeid, Kim, Nadia, Long, and Sophie" + new_line +
                "Plantkind has not been treated with the respect they deserve and so we have been sent here to bring Humanity into line. " + new_line +
                "We bring an app - consider this your first warning - that will assist you with staying in tune with your plants needs. ";

            about.Font = new Font("Segou UI Emoji", 12);

            return about;
        }
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
