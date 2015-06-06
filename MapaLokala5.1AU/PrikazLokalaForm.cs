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
    public partial class PrikazLokalaForm : Form
    {
        private string idTipa;
        private int idx;

        public PrikazLokalaForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PrikazLokalaForm_Load(object sender, EventArgs e)
        {
            reload();

        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            new UnosLokalaForm().ShowDialog();
            reload();
        }

        private void izmeniBtn_Click(object sender, EventArgs e)
        {
            new UnosLokalaForm(idTipa).ShowDialog();
            reload();
        }

        private void obrisiBtn_Click(object sender, EventArgs e)
        {
            string sqlDelete = "delete from lokali where id=" + idTipa;

            SQLiteCommand tableCreation = new SQLiteCommand(sqlDelete, MainForm.baza.dbConn);
            tableCreation.ExecuteNonQuery();

            lokaliDataGrid.Rows.RemoveAt(idx);
        }

        private void reload()
        {
            string select = @"SELECT id, ime, kapacitet, cene, alkohol, rezervacija
                            FROM lokali";

            SQLiteDataReader r = MainForm.baza.Select(select);

            lokaliDataGrid.Rows.Clear();  //izbrisi prethodne redove, da posle dodas updejtovane

            while (r.Read())
            {
                //why u make me do dis
                string rerz = (((int)r["rezervacija"]) == 0) ? "Da": "Ne";

                lokaliDataGrid.Rows.Add(new object[] { r["id"], r["ime"], r["kapacitet"], r["cene"], r["alkohol"], rerz});
            }
        }

        private void lokaliDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            idx = lokaliDataGrid.CurrentCell.RowIndex;
            if (idx < lokaliDataGrid.Rows.Count)
                idTipa = lokaliDataGrid.Rows[idx].Cells["id"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = comboBox1.SelectedItem.ToString();

            string select;

            if (textBox1.Text != "")
            {
                if (id.Equals(" "))
                {

                    select = "SELECT * FROM lokali WHERE"
                         + " id =" + "'" + textBox1.Text + "' OR"
                         + " ime =" + "'" + textBox1.Text + "' OR"
                         + " kapacitet =" + "'" + textBox1.Text + "' OR"
                         + " alkohol =" + "'" + textBox1.Text + "' OR"
                         + " cene =" + "'" + textBox1.Text + "'";
                }
                else
                {
                    select = "SELECT * FROM lokali" + " WHERE "
                    + id + "=" + "'" + textBox1.Text + "'";
                }

                SQLiteDataReader r = MainForm.baza.Select(select);

                lokaliDataGrid.Rows.Clear();  //izbrisi prethodne redove, da posle dodas updejtovane

                while (r.Read())
                {
                    //why u make me do dis
                    string rerz = (((int)r["rezervacija"]) == 0) ? "Da" : "Ne";

                    lokaliDataGrid.Rows.Add(new object[] { r["id"], r["ime"], r["kapacitet"], r["cene"], r["alkohol"], rerz });
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string select = "SELECT * FROM lokali";

            SQLiteDataReader r = MainForm.baza.Select(select);

            comboBox1.SelectedIndex = 0;
            textBox1.Text = "";

            lokaliDataGrid.Rows.Clear();  //izbrisi prethodne redove, da posle dodas updejtovane

            while (r.Read())
            {
                //why u make me do dis
                string rerz = (((int)r["rezervacija"]) == 0) ? "Da" : "Ne";

                lokaliDataGrid.Rows.Add(new object[] { r["id"], r["ime"], r["kapacitet"], r["cene"], r["alkohol"], rerz });
            }
        }

    }
}
