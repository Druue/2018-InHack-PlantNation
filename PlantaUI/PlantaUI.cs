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
        public static Control ShowJournal(string filename)
        {
            List<Journal> journals = new List<Journal>();
            PlantaDatabase db = new PlantaDatabase();
            journals = db.DB_getJournal(filename);

            
            ListView journalListView = new ListView();
            journalListView.Height = 370;
            journalListView.Width = 370;
            journalListView.View = View.Details;
            journalListView.FullRowSelect = true;

            
            journalListView.Columns.Add("Water Day               ", -2, HorizontalAlignment.Left);
            journalListView.Columns.Add("Nickname                ", -2, HorizontalAlignment.Left);
            journalListView.Columns.Add("Plant name              ", -2, HorizontalAlignment.Left);
            ListViewItem entryListItem = new ListViewItem();

            // store data to the list view
            foreach (Journal journal in journals)
            {
                TimeSpan span = journal.getDate().Subtract(DateTime.Now);
                string date = "";
                if (span.Days > 1)
                {
                    date = String.Format("In {0} days", span.Days);
                }
                else if (span.Days < 0)
                {
                    date = String.Format("{0} days ago", span.Duration().Days);
                }
                if (span.Days == 0)
                {entryListItem = journalListView.Items.Add("Today"); }
                else if (span.Days == 1)
                { entryListItem = journalListView.Items.Add("Tomorrow"); }
                else
                { entryListItem = journalListView.Items.Add(date); }

                entryListItem.SubItems.Add(journal.getNickname().ToString());
                entryListItem.SubItems.Add(journal.getPlantname().ToString());
            }

            
            return journalListView;

        }

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
            boxTitle.Font = new Font("Segoe UI Emoji", 12, FontStyle.Bold);
            boxTitle.ForeColor = Color.Black;
            boxTitle.AutoSize = true;
            boxTitle.Location = new Point(45, 30);
            return boxTitle;
        }

        public Control showNicknameTitle(Label nickname)
        {
            nickname.Text = "Write a nickname";
            nickname.Font = new Font("Segoe UI Emoji", 12, FontStyle.Bold);
            nickname.ForeColor = Color.Black;
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

            about.Font = new Font("Segou UI Emoji", 12, FontStyle.Bold);
            about.ForeColor = Color.Black;

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
