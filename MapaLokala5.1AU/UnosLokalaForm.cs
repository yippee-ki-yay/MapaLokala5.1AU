using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapaLokala5._1AU
{
    public partial class UnosLokalaForm : Form
    {
        Lokal noviLokal = new Lokal();

        public UnosLokalaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            noviLokal.tip = tipLokalaBox.Text;

            Program.listaLokala.Add(noviLokal);
        }

        private void UnosLokalaForm_Load(object sender, EventArgs e)
        {

        }


    }
}
