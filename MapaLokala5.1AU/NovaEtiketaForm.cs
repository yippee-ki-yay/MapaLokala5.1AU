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
    partial class NovaEtiketaForm : Form
    {
        private ColorDialog colorDialog = new ColorDialog();
        private List<Etiketa> listaEtiketa = null;
        private ListBox boxEtiketa = null;
        private string id;

        public NovaEtiketaForm(List<Etiketa> listaEtiketa, ListBox boxEtiketa,string id)
        {
            this.id = id;
            this.listaEtiketa = listaEtiketa;
            this.boxEtiketa = boxEtiketa;
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

            boxEtiketa.Items.Add(etiketa.id);

            string insert = @"insert into etikete
                                  (id,opis, boja, lokal_id)
                                  VALUES (@id, @opis, @boja, @lokal_id)";

            SQLiteCommand tableCreation = new SQLiteCommand(insert, MainForm.baza.dbConn);
            tableCreation.Parameters.AddWithValue("@id", idTextBox.Text);
            tableCreation.Parameters.AddWithValue("@opis", opisTextBox.Text);
            tableCreation.Parameters.AddWithValue("@boja", colorDialog.Color.GetHashCode());
            tableCreation.Parameters.AddWithValue("@lokal_id", id);

            tableCreation.ExecuteNonQuery();

            this.Close();
        }

        private void NovaEtiketaForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
