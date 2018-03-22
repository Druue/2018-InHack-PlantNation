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

        //Delete plant
        public Control DeletePlant(string username, ComboBox combobox)
        {
            //Declaration of all classes
            PlantaDatabase db = new PlantaDatabase();
            PlantaLibrary.DeletePlant model = new PlantaLibrary.DeletePlant();
            //connect to the DAL
            try
            {
                Cursor.Current = Cursors.AppStarting;
                db.DeletePlant(model, username);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "\nErrorLog.txt has been has been saved in the bin folder", "An error has occured (╯°□°）╯︵ ┻━┻", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return c;
            }

            //collect all the date
            List<string> allUserPlantNicknames = model.GetPlantNickname();
            combobox.DataSource = allUserPlantNicknames;
            combobox.Location = new Point(50, 60);
            return combobox;
        }

        //ADD PLANT
        public Control AddPlant(string username, ComboBox combobox)
        {
            //Declaration of all classes
            PlantaDatabase db = new PlantaDatabase();
            PlantaLibrary.AllPlantNames model = new PlantaLibrary.AllPlantNames();
            string filename = "..\\..\\..\\Plant_Wiki.txt";

            //connect to the DAL
            try
            {
                Cursor.Current = Cursors.AppStarting;
                db.AddPlantNames(model, filename);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "\nErrorLog.txt has been has been saved in the bin folder", "An error has occured (╯°□°）╯︵ ┻━┻", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return c;
            }

            //collect all the date
            List<string> allPlantsNames = model.GetPlantName();
            combobox.DataSource = allPlantsNames;
            combobox.Location = new Point(50, 60);
            return combobox;
        }

        //Design add plant
        public Control showConfirmButton(Button confirm)
        {
            confirm.Text = "Confirm";
            confirm.BackColor = Color.LightGreen;
            confirm.AutoSize = true;
            confirm.Location = new Point(300, 200);
            return confirm;
        }

        public Control showBoxTitle(Label boxTitle)
        {
            boxTitle.Text = "Choose a plant";
            boxTitle.Font = new Font("Segoe UI Emoji", 12);
            boxTitle.AutoSize = true;
            boxTitle.Location = new Point(45, 30);
            return boxTitle;
        }

        public Control showNicknameTitle(Label nickname)
        {
            nickname.Text = "Write a nickname";
            nickname.Font = new Font("Segoe UI Emoji", 12);
            nickname.AutoSize = true;
            nickname.Location = new Point(250, 30);
            return nickname;
        }

        public Control showNicknameBox(TextBox nicknameBox)
        {
            nicknameBox.Font = new Font("Segoe UI Emoji", 12);
            nicknameBox.Width = 150;
            nicknameBox.Location = new Point(255, 60);
            return nicknameBox;
        }
    }


}
