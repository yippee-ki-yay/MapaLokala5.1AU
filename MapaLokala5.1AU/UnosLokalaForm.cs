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
        public Lokal noviLokal = new Lokal();

        public UnosLokalaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /**Popuni ovde sve podatke*/
            this.noviLokal.id = idTextBox.Text;
            this.noviLokal.opis = opisLokalaArea.Text;
            this.noviLokal.kapacitet = (int)kapacitetNumber.Value;
            this.noviLokal.datum = otvaranjeDate.Value;
            this.noviLokal.cene = ceneCombo.SelectedText;

            //tip etikete i jos jes i no opcije

            Program.listaLokala.Add(noviLokal);
            this.Close();
        }

        private void UnosLokalaForm_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TipLokalaForm noviLokalForm = new TipLokalaForm(noviLokal.tipLokala);
            noviLokalForm.Parent = this;
            noviLokalForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NovaEtiketaForm novaEtikaForm = new NovaEtiketaForm(noviLokal.listaEtiketa);
            novaEtikaForm.Parent = this;
            novaEtikaForm.Show();
        }


    }
}
