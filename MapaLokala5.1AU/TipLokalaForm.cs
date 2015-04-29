using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapaLokala5._1AU
{
    partial class TipLokalaForm : Form
    {
        /*Za svaki input box potencijalni alertovi*/


        private OpenFileDialog ikonicaDijalog = new OpenFileDialog();
        private TipLokala tipLokala = null;
        private ComboBox tipComboBox = null;
        private Image img = null;
        private string filename = null;

        public string tip_id
        {
            get;
            set;
        }

        public TipLokalaForm(TipLokala tipLokala, ComboBox tipComboBox)
        {
            this.tipLokala = tipLokala;
            this.tipComboBox = tipComboBox;
            InitializeComponent();
            ikonicaDijalog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d = ikonicaDijalog.ShowDialog();

            if (d == DialogResult.OK)
            {
                filename = ikonicaDijalog.FileName;
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

            tipComboBox.Items.Add(this.tipLokala.ime);
            tipComboBox.SelectedItem = this.tipLokala.ime;



            string insert = @"insert into tipovi
                                  (id,ime, opis, ikona)
                                  VALUES (@id, @ime, @opis, @ikona)";

            SQLiteCommand tableCreation = new SQLiteCommand(insert, MainForm.baza.dbConn);
            tableCreation.Parameters.AddWithValue("@id", idTextBox.Text);
            tableCreation.Parameters.AddWithValue("@opis", opisTextBox.Text);
            tableCreation.Parameters.AddWithValue("@ime", imeTextBox.Text);
            tableCreation.Parameters.AddWithValue("@ikona", filename);

            tableCreation.ExecuteNonQuery();

            this.tip_id = idTextBox.Text;

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
