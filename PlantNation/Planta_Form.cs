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
        private TextBox txt_nickname = new TextBox();
        private ComboBox combobox = new ComboBox();

        //ADD PLANTS
        private void lbl_add_Click(object sender, EventArgs e)
        {
            this.Panel_content.Controls.Clear();
            this.lbl_currentTab.Text = "Add plants";
            string username = lbl_username.Text;

            // combobox.SelectedIndexChanged += new EventHandler(addBox_SelectedIndexChanged);

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
            string username = "Kim";//lbl_username.Text;
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

        private void lbl_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            string username = "Kim";//lbl_username.Text;

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
    }

}

