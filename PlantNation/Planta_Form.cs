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
            Panel_menu.Enabled = false;
            //creation the label with "Welcome button"
            Label authorization = new Label();
            authorization.Visible = true;
            authorization.Enabled = true;
            authorization.Text = "Welcome to The Plant nation!\n Enter your name.\n If you are here for the first time 'create a new account'.";
            authorization.Font = new Font("Segoe UI Emoji", 12, FontStyle.Bold);
            authorization.ForeColor = Color.Black;
            authorization.AutoSize = true;
            authorization.TextAlign = ContentAlignment.MiddleCenter;
            authorization.Location = new Point(60, 20);
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
                string filename = "..\\..\\..\\" + name + ".txt";
                PlantaDatabase db = new PlantaDatabase();
                bool is_exist = db.Create_new_user(filename);

                if (is_exist)
                {
                    MessageBox.Show("The user with this name already exist. Try another name", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //the file was created with this name
                    Panel_menu.Enabled = true;
                   
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
                string filename = "..\\..\\..\\" + name + ".txt";

                PlantaDatabase db = new PlantaDatabase();
                bool is_exist = db.Log_new_user(filename);

                if (is_exist)
                {
                    Panel_menu.Enabled = true;
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
            this.lbl_currentTab.Text = "Dashboard";
        }


        private TextBox txt_nickname = new TextBox();
        private ComboBox combobox = new ComboBox();

        //ADD PLANTS
        private void lbl_add_Click(object sender, EventArgs e)
        {
            this.Panel_content.Controls.Clear();
            this.lbl_currentTab.Text = "Add plants";
            string username = lbl_username.Text;

            PlantaDisplay dis = new PlantaDisplay();
            this.Panel_content.Controls.Add(dis.AddPlant(username, combobox));

            Button btn_confirm = new Button();
            btn_confirm.Click += new EventHandler(btn_confirm_Clicked);
            this.Panel_content.Controls.Add(dis.showConfirmButton(btn_confirm));

            Label lbl_addBoxTitle = new Label();
            this.Panel_content.Controls.Add(dis.showBoxTitle(lbl_addBoxTitle));

            Label lbl_NicknameTitle = new Label();
            this.Panel_content.Controls.Add(dis.showNicknameTitle(lbl_NicknameTitle));

            this.Panel_content.Controls.Add(dis.showNicknameBox(txt_nickname));
        }

        private void btn_confirm_Clicked(object sender, EventArgs e)
        {
            PlantaDatabase db = new PlantaDatabase();
            string plantname = combobox.Text;
            string nickname = txt_nickname.Text;
            string username = lbl_username.Text;
            bool exists = db.nicknameExists(nickname, username);

            if (exists)
            {
                MessageBox.Show("This already exists");
                return;
            }

            try
            {
                db.AddUserPlant(plantname, nickname, username);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "An error has occured (╯°□°）╯︵ ┻━┻", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Plant has been added");
        }

        private void lbl_delete_Click(object sender, EventArgs e)
        {
            this.Panel_content.Controls.Clear();
            this.lbl_currentTab.Text = "Delete plant";
            string username = lbl_username.Text;

            PlantaDisplay dis = new PlantaDisplay();
            this.Panel_content.Controls.Add(dis.DeletePlant(username, combobox));

            Label lbl_addBoxTitle = new Label();
            this.Panel_content.Controls.Add(dis.showBoxTitle(lbl_addBoxTitle));

            Button btn_delete = new Button();
            btn_delete.Click += new EventHandler(btn_delete_Clicked);
            this.Panel_content.Controls.Add(dis.showConfirmButton(btn_delete));
        }

        private void btn_delete_Clicked(object sender, EventArgs e)
        {
            PlantaDatabase db = new PlantaDatabase();
            string plantnickname = combobox.Text;
            string username = lbl_username.Text;

            try
            {
                db.DeleteUserPlant(plantnickname, username);
            }

            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "An error has occured (╯°□°）╯︵ ┻━┻", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Plant has been deleted");
            combobox.DataSource = null;
            PlantaDisplay dis = new PlantaDisplay();
            this.Panel_content.Controls.Add(dis.DeletePlant(username, combobox));
        }
        private string groupboxIndex1;
        private string groupboxIndex2;
        private string groupboxIndex3;
        private void showDashboard()
        {
            this.Panel_content.Controls.Clear();
            this.lbl_currentTab.Text = "Dashboard";
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
            labelPlant1.Location = new Point(105, 45);
            labelPlant2.Location = new Point(105, 45);
            labelPlant3.Location = new Point(105, 45);
            labelPlant1.Font = new Font("Segou UI Emoji", 14);
            labelPlant2.Font = new Font("Segou UI Emoji", 14);
            labelPlant3.Font = new Font("Segou UI Emoji", 14);
            PictureBox picBox1 = new PictureBox();
            PictureBox picBox2 = new PictureBox();
            PictureBox picBox3 = new PictureBox();
            picBox1.Location = new Point(5, 40);
            picBox2.Location = new Point(5, 40);
            picBox3.Location = new Point(5, 40);
            Button button1 = new Button();
            Button button2 = new Button();
            Button button3 = new Button();
            button1.Location = new Point(430, 27);
            button2.Location = new Point(430, 43);
            button3.Location = new Point(430, 43);
            button1.Text = "Water me pls";
            button2.Text = "Water me pls";
            button3.Text = "Water me pls";
            button1.Size = new Size(100,50);
            button2.Size = new Size(100, 50);
            button3.Size = new Size(100, 50);
            button1.BackColor = Color.LightSkyBlue;
            button2.BackColor = Color.LightSkyBlue;
            button3.BackColor = Color.LightSkyBlue;
            button1.Click += new EventHandler(button1_Clicked);
            button2.Click += new EventHandler(button2_Clicked);
            button3.Click += new EventHandler(button3_Clicked);
            int boxLimit = 0;
            int count = 0;
            bool isEmpty = !waterEmergency.Any();

            if (!isEmpty)
            {
                for (int i = 0; i < plantNick.Count; i++)
                {
                    if (waterEmergency[count] == i && count < 1)
                    {
                        labelPlant1.Text = plantNick[i];
                        groupbox1.Controls.Add(labelPlant1);
                        //picBox1.Image = Properties.Resources.;
                        groupbox1.Controls.Add(picBox1);
                        groupbox1.Controls.Add(button1);
                        groupboxIndex1 = plantNick[i];
                        count++;
                    }
                }
            }

            count = 0;
            isEmpty = !waterToday.Any();
            if (!isEmpty)
            {
                for (int i = 0; i < plantNick.Count; i++)
                {
                    if (waterToday[count] == i && boxLimit < 1)
                    {
                        labelPlant2.Text = plantNick[i];
                        groupbox2.Controls.Add(labelPlant2);
                        //picBox2.Image = Properties.Resources.;
                        groupbox2.Controls.Add(picBox2);
                        groupbox2.Controls.Add(button2);
                        groupboxIndex2 = plantNick[i];
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
                        groupboxIndex3 = plantNick[i];
                        boxLimit++;
                        continue;
                    }
                }
            }


            this.Panel_content.Controls.Add(groupbox1);
            this.Panel_content.Controls.Add(groupbox2);
            this.Panel_content.Controls.Add(groupbox3);
        }

        private void button3_Clicked(object sender, EventArgs e)
        {
            PlantaDatabase db = new PlantaDatabase();
            string filename = "..\\..\\..\\" + lbl_username.Text + ".txt";
            db.plantWatered(groupboxIndex3, filename);
        }

        private void button2_Clicked(object sender, EventArgs e)
        {
            PlantaDatabase db = new PlantaDatabase();
            string filename = "..\\..\\..\\" + lbl_username.Text + ".txt";
            db.plantWatered(groupboxIndex2, filename);
        }

        private void button1_Clicked(object sender, EventArgs e)
        {
            PlantaDatabase db = new PlantaDatabase();
            string filename = "..\\..\\..\\" + lbl_username.Text + ".txt";
            db.plantWatered(groupboxIndex1, filename); 

        }

        private void lbl_about_Click(object sender, EventArgs e)
        {
            this.Panel_content.Controls.Clear();
            this.lbl_currentTab.Text = "About";
            PlantaDisplay display = new PlantaDisplay();
            this.Panel_content.Controls.Add(display.AboutPlantNation());
            this.Panel_content.Location = new System.Drawing.Point(200, 150);
        }
        private void lbl_ranks_Click(object sender, EventArgs e)
        {
            Panel_content.Controls.Clear();
            this.lbl_currentTab.Text = "Journal";
            string filename = lbl_username.Text + ".txt";
            Panel_content.Controls.Add(PlantaDisplay.ShowJournal(filename));


        }

        private void lbl_journal_Click(object sender, EventArgs e)
        {
            Panel_content.Controls.Clear();
            Panel_content.Controls.Add(PlantaDisplay.ShowRanks());
            

        }

        private void gradientPanel_background_Paint(object sender, PaintEventArgs e)
        {
           gradientPanel_background.SendToBack();
        }
    }
}

