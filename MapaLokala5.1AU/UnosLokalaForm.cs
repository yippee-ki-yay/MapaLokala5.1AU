using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapaLokala5._1AU
{
    partial class UnosLokalaForm : Form
    {
        public Lokal noviLokal = new Lokal();
        private bool formIsValid = true;
        private Regex imeRex = null;

        public UnosLokalaForm()
        {

            InitializeComponent();
            imeRex = new Regex("^[A-Za-z_-][A-Za-z0-9_-]*$");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formIsValid = true;
            this.ValidateChildren();


            if (formIsValid == true)
            {

                /**Popuni ovde sve podatke*/
                this.noviLokal.id = idTextBox.Text;
                this.noviLokal.opis = opisLokalaArea.Text;
                this.noviLokal.ime = imeTextBox.Text;
                this.noviLokal.kapacitet = (int)kapacitetNumber.Value;
                this.noviLokal.datum = otvaranjeDate.Value;
                this.noviLokal.cene = ceneCombo.SelectedText;

                //tip etikete i jos jes i no opcije

                Program.listaLokala.Add(noviLokal);
                this.Close();
            }
           
        }

        private void UnosLokalaForm_Load(object sender, EventArgs e)
        {
            foreach(TipLokala t in Program.listaTipova)
            {
                tipComboBox.Items.Add(t.ime);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TipLokalaForm noviLokalForm = new TipLokalaForm(noviLokal.tipLokala, tipComboBox);
            noviLokalForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NovaEtiketaForm novaEtikaForm = new NovaEtiketaForm(noviLokal.listaEtiketa, listaEtiketa);
            novaEtikaForm.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {

        }



        private void idTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (idTextBox.Text == "")
            {
                formIsValid = false;
                errorProvider.SetError(idTextBox, "Morate uneti id");
            }
            else
            {
                errorProvider.SetError(idTextBox, "");
            }
         

        }

        private void imeTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (imeRex.Match(imeTextBox.Text).Success)
            {
                errorIme.SetError(imeTextBox, "");
            }
            else
            {
                errorIme.SetError(imeTextBox, "Ime mora poceti sa slovom");
                formIsValid = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }


    }
}
