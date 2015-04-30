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

        }

        private void izmeniBtn_Click(object sender, EventArgs e)
        {

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
    }
}
