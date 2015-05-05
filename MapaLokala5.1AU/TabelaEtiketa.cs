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
    public partial class TabelaEtiketa : Form
    {
        private string idTipa;
        private int idx;

        public TabelaEtiketa()
        {
            InitializeComponent();
        }

        private void TabelaEtiketa_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlDelete = "delete from etikete where id=" + idTipa;

            SQLiteCommand tableCreation = new SQLiteCommand(sqlDelete, MainForm.baza.dbConn);
            tableCreation.ExecuteNonQuery();

            etiketeTabela.Rows.RemoveAt(idx);
        }

        private void izmeniBtn_Click(object sender, EventArgs e)
        {
            new NovaEtiketaForm(idTipa).ShowDialog();
            reload();
        }

        private void reload()
        {
            string select = @"SELECT * FROM etikete";

            SQLiteDataReader r = MainForm.baza.Select(select);

            etiketeTabela.Rows.Clear();  //izbrisi prethodne redove, da posle dodas updejtovane

            while (r.Read())
            {
                etiketeTabela.Rows.Add(new object[] { r["id"], r["boja"], r["opis"] });
            }
        }

        private void etiketeTabela_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            new NovaEtiketaForm().ShowDialog();
            reload();
        }

        private void etiketeTabela_SelectionChanged(object sender, EventArgs e)
        {
            idx = etiketeTabela.CurrentCell.RowIndex;
            if (idx < etiketeTabela.Rows.Count)
                idTipa = etiketeTabela.Rows[idx].Cells["id"].Value.ToString();
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            string id = filterCombo.SelectedItem.ToString();

            string select;

            if (id.Equals("sve"))
            {
                select = "SELECT * FROM etikete";
            }
            else
            {
                select = "SELECT * FROM etikete" + " WHERE "
                + id + "=" + "'" + textBox1.Text + "'";
            }

            SQLiteDataReader r = MainForm.baza.Select(select);

            etiketeTabela.Rows.Clear();  //izbrisi prethodne redove, da posle dodas updejtovane

            while(r.Read())
                etiketeTabela.Rows.Add(new object[] { r["id"], r["boja"], r["opis"] });
            
        }
    }
}
