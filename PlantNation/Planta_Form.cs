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
        public Planta_Form()
        {
            InitializeComponent();
            //Reduce windows form flicker
            this.DoubleBuffered = true;
            enableDoubleBuff(Panel_content);
        }
    }
    public static void enableDoubleBuff(Control cont)
    {
        System.Reflection.PropertyInfo DemoProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",
        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        DemoProp.SetValue(cont, true, null);
    }
}

