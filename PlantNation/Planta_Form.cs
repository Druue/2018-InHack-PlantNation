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
using System.IO;

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
            userAuth();
        }
        public static void enableDoubleBuff(Control cont)
        {
            System.Reflection.PropertyInfo DemoProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DemoProp.SetValue(cont, true, null);
        }

        private void lbl_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private TextBox name_auth = new TextBox();
        public void userAuth()
        {
            Panel_content.Controls.Clear();

            //creation the label with "Welcome button"
            Label authorization = new Label();
            authorization.Visible = true;
            authorization.Enabled = true;
            authorization.Text = "Welcome to The Plant nation! Enter your name. If you are here for the first time 'create a new account'.";
            authorization.AutoSize = true;
            authorization.Location = new Point(100, 100);
            Panel_content.Controls.Add(authorization);

            //making visible the textbox
            name_auth.Location = new Point(150, 150);
            name_auth.Size = new Size(200, 200);
            name_auth.Visible = true;
            name_auth.Enabled = true;
            Panel_content.Controls.Add(name_auth);

            //creation the Button  "Log in"
            Button log_in = new Button();
            log_in.Visible = true;
            log_in.Enabled = true;
            log_in.Location = new Point(150, 200);
            log_in.Text = "Log in";
            Panel_content.Controls.Add(log_in);
            log_in.Click += new EventHandler(log_in_clicked);

            //creation the Button  "Create a new account"
            Button create_new = new Button();
            create_new.Visible = true;
            create_new.Enabled = true;
            create_new.Location = new Point(250, 200);
            create_new.Text = "Create a new account";
            create_new.AutoSize = true;
            Panel_content.Controls.Add(create_new);
            create_new.Click += new EventHandler(create_new_clicked);


        }

        private void create_new_clicked(object sender, EventArgs e)
        {
            //check if the box is not empty
            if (name_auth.Text == "")
            {
                MessageBox.Show("You didn't enter your name. Please, enter your name!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string name = name_auth.Text;
                string filename = name + ".txt";
                PlantaDatabase db = new PlantaDatabase();
                bool is_exist = db.Create_new_user(filename);

                if (is_exist)
                {
                    MessageBox.Show("The user with this name already exist. Try another name", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //the file was created with this name
                    lbl_username.Text = name;
                    showDashboard();
                }
            }
        }

        private void log_in_clicked(object sender, EventArgs e)
        {
            //check if the box is not empty
            if (name_auth.Text == "")
            {
                MessageBox.Show("You didn't enter your name. Please, enter your name!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                string name = name_auth.Text;
                string filename = name + ".txt";

                PlantaDatabase db = new PlantaDatabase();
                bool is_exist = db.Log_new_user(filename);

                if (is_exist)
                {
                    lbl_username.Text = name;
                    showDashboard();
                }
                else
                {
                    MessageBox.Show("There is no user with this name. Try again or create a new account!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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


            PlantaLibrary.UserDashboard lib = ui.showDashboard(fileName);

            List<int> waterEmergency = lib.GetWaterEmergency();
            List<int> waterToday = lib.GetWaterToday();
            List<string> plantNick = lib.GetNick();
            GroupBox groupbox1 = new GroupBox();
            GroupBox groupbox2 = new GroupBox();
            GroupBox groupbox3 = new GroupBox();
            groupbox1.Location = new Point(10, 10);
            groupbox2.Location = new Point(10, 80);
            groupbox3.Location = new Point(10, 160);

            groupbox1.Size = new Size(600, 100);
            groupbox2.Size = new Size(600, 120);
            groupbox3.Size = new Size(600, 140);
            Label labelPlant1 = new Label();
            Label labelPlant2 = new Label();
            Label labelPlant3 = new Label();
            labelPlant1.Location = new Point(45, 45);
            labelPlant2.Location = new Point(45, 45);
            labelPlant3.Location = new Point(45, 45);
            PictureBox picBox1 = new PictureBox();
            PictureBox picBox2 = new PictureBox();
            PictureBox picBox3 = new PictureBox();
            picBox1.Location = new Point(5, 40);
            picBox2.Location = new Point(5, 40);
            picBox3.Location = new Point(5, 40);
            Button button1 = new Button();
            Button button2 = new Button();
            Button button3 = new Button();
            button1.Location = new Point(10, 10);
            button2.Location = new Point(300, 100);
            button3.Location = new Point(300, 100);
            int boxLimit = 0;
            int count = 0;
            for (int i = 0; i < plantNick.Count; i++)
            {
                if (waterEmergency[count] == i && count < 1)
                {
                    labelPlant1.Text = plantNick[i];
                    groupbox1.Controls.Add(labelPlant1);
                    //picBox1.Image = Properties.Resources.;
                    groupbox1.Controls.Add(picBox1);
                    groupbox1.Controls.Add(button1);
                    count++;
                }
            }
            count = 0;
            for (int i = 0; i < plantNick.Count; i++)
            {
                if (waterToday[count] == i && boxLimit < 1)
                {
                    labelPlant2.Text = plantNick[i];
                    groupbox2.Controls.Add(labelPlant2);
                    //picBox2.Image = Properties.Resources.;
                    groupbox2.Controls.Add(picBox2);
                    groupbox2.Controls.Add(button2);
                    boxLimit++;
                    continue;
                }
                if (waterToday[count] == i && boxLimit < 1)
                {
                    labelPlant3.Text = plantNick[i];
                    groupbox3.Controls.Add(labelPlant3);
                    //picBox3.Image = Properties.Resources.;
                    groupbox3.Controls.Add(picBox3);
                    groupbox3.Controls.Add(button3);
                    boxLimit++;
                    continue;
                }
            }

            this.Panel_content.Controls.Add(groupbox1);
            this.Panel_content.Controls.Add(groupbox2);
            this.Panel_content.Controls.Add(groupbox3);
        }
        private void lbl_about_Click(object sender, EventArgs e)
        {
            this.Panel_content.Controls.Clear();
            PlantaDisplay display = new PlantaDisplay();
            this.Panel_content.Controls.Add(display.AboutPlantNation());
            this.Panel_content.Location = new System.Drawing.Point(200, 150);
        }
    }
}

