using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlantaDAL;
using PlantaUI;
using PlantaModel;
using PlantaLogic;

namespace PlantNation
{
    public partial class Planta_Form : Form
    {
        private static Planta_Form instance;
        public Planta_Form()
        {
            InitializeComponent();
            //Reduce windows form flicker
            this.DoubleBuffered = true;
            enableDoubleBuff(Panel_content);
        }
        public static void enableDoubleBuff(Control cont)
        {
            System.Reflection.PropertyInfo DemoProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DemoProp.SetValue(cont, true, null);
        }

        private void lbl_Dashboard_Click(object sender, EventArgs e)
        {
            showDashboard();
        }

        private void showDashboard()
        {
            this.Panel_content.Controls.Clear();
            string fileName = lbl_username.Text;
            PlantaDisplay ui = new PlantaDisplay();

            GroupBox groupbox1 = new GroupBox();
            GroupBox groupbox2 = new GroupBox();
            GroupBox groupbox3 = new GroupBox();
            PlantaLibrary.UserDashboard lib = ui.showDashboard(fileName);

            List<int> waterEmergency = lib.GetWaterEmergency();
            List<int> waterToday = lib.GetWaterToday();
            List<string> plantNick = lib.GetNick();

            Label labelPlant1 = new Label();
            Label labelPlant2 = new Label();
            int countEmergency = 0;
            int countToday = 0;
            for (int i = 0; i < plantNick.Count; i++)
            {
                if (waterEmergency[countEmergency] == i)
                {
                    labelPlant1.Text = plantNick[i];
                    groupbox1.Controls.Add(labelPlant1);
                }
                else if(waterToday[countToday] == i)
                {
                    labelPlant2.Text = plantNick[i];
                    groupbox2.Controls.Add(labelPlant2);
                }
            }
            this.Panel_content.Controls.Add(groupbox1);
            this.Panel_content.Controls.Add(groupbox2);
            this.Panel_content.Controls.Add(groupbox3);
        }
    }

}

