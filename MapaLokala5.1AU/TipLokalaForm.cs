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
    public partial class TipLokalaForm : Form
    {
        /*Za svaki input box potencijalni alertovi*/


        private OpenFileDialog ikonicaDijalog = new OpenFileDialog();
        private TipLokala tipLokala = null;
        private Image img = null;

        public TipLokalaForm(TipLokala tipLokala)
        {
            this.tipLokala = tipLokala;
            InitializeComponent();
            ikonicaDijalog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d = ikonicaDijalog.ShowDialog();

            if (d == DialogResult.OK)
            {
                string filename = ikonicaDijalog.FileName;
                img = new Bitmap(filename);
                pictureBox1.BackgroundImage = img;
                pictureBox1.Show();

            }
        }

        private void TipLokalaForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*Ovde bi trebali da imamo neku proveru da li je sve uneto*/
            this.tipLokala.id = idTextBox.Text;
            this.tipLokala.ime = imeTextBox.Text;
            this.tipLokala.opis = opisTextBox.Text;
            this.tipLokala.ikonica = img;

            this.Close();
        }
    }
}
