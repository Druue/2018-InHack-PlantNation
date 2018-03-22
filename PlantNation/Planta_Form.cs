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

                    ShowDashboard();
                    lbl_username.Text = name;
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

                    ShowDashboard();
                    lbl_username.Text = name;
                }
                else
                {
                    MessageBox.Show("There is no user with this name. Try again or create a new account!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

}

