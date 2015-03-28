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
    public partial class NovaEtiketaForm : Form
    {
        private ColorDialog colorDialog = new ColorDialog();
        private List<Etiketa> listaEtiketa = null;

        public NovaEtiketaForm(List<Etiketa> listaEtiketa)
        {
            this.listaEtiketa = listaEtiketa;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Etiketa etiketa = new Etiketa();

            etiketa.id = idTextBox.Text;
            etiketa.opis = opisTextBox.Text;
            etiketa.color = colorDialog.Color;

            this.listaEtiketa.Add(etiketa);

            this.Close();
        }

        private void NovaEtiketaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
