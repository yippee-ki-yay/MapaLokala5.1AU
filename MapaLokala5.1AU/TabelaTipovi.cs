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
    public partial class FilterBtn : Form
    {
        private string idTipa;
        private int idx;

        public FilterBtn()
        {
            InitializeComponent();
        }

        private void TabelaTipovi_Load(object sender, EventArgs e)
        {
            filterCombo.SelectedText = "ime";
            reload();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TabelaTipovi_Load_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new TipLokalaForm().Show();
            reload();
        }

        private void izbrisiBtn_Click(object sender, EventArgs e)
        {
            string sqlDelete = "delete from tipovi where id="+idTipa;

            SQLiteCommand tableCreation = new SQLiteCommand(sqlDelete, MainForm.baza.dbConn);
            tableCreation.ExecuteNonQuery();

            tipoviTabela.Rows.RemoveAt(idx);
        }

        private void azurirajBtn_Click(object sender, EventArgs e)
        {
            if (idTipa != null)
            {
                TipLokalaForm t =  new TipLokalaForm(idTipa);
                t.ShowDialog();
                reload();
            }

        }

        private void tipoviTabela_SelectionChanged(object sender, EventArgs e)
        {
            idx = tipoviTabela.CurrentCell.RowIndex;
            if(idx < tipoviTabela.Rows.Count)
                 idTipa = tipoviTabela.Rows[idx].Cells["id"].Value.ToString();
        }

        private void reload()
        {
            string select = @"SELECT * FROM tipovi";

            SQLiteDataReader r = MainForm.baza.Select(select);

            tipoviTabela.Rows.Clear();  //izbrisi prethodne redove, da posle dodas updejtovane

            while (r.Read())
            {
                tipoviTabela.Rows.Add(new object[] { r["id"], r["ime"], r["ikona"], r["opis"] });
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string id = filterCombo.SelectedItem.ToString();

            string select = "SELECT * FROM tipovi"+ " WHERE " 
                +id+"=" + "'"+textBox1.Text+"'";

            SQLiteDataReader r = MainForm.baza.Select(select);

            tipoviTabela.Rows.Clear();  //izbrisi prethodne redove, da posle dodas updejtovane

            tipoviTabela.Rows.Add(new object[] { r["id"], r["ime"], r["ikona"], r["opis"] });
            
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
