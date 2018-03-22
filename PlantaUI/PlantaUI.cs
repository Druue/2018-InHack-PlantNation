using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantaModel;
using PlantaLogic;
using PlantaDAL;
using System.Windows.Forms;
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
            journals = PlantaDatabase.DB_getJournal(filename);

            
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
    }
}
