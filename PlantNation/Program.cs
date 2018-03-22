using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantNation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Planta_Form());
         //userAuth();



            //..string fileName = txtbox.Text
            //..To Db
            //..Db asks does this filename exist?
            //..return bool?

            //..User accepted
            //Send username to .form
            //.form writes username in a label.
            //After writing, the same method will run all the Form methods, and publish the information needed into the control
            //The username from the Label will always be read and sent whenever a user edits/requests/adds information to the .txt
            //Therefore all this.panel.Controls.Add(PlantaUI(username)); username is a string
        }
    }
}
