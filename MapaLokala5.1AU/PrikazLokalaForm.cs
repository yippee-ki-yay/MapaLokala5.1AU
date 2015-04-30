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
        public PrikazLokalaForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PrikazLokalaForm_Load(object sender, EventArgs e)
        {
            /*lokaliDataGrid.Rows.Clear();

            foreach(Lokal l in Program.listaLokala)
            {
                lokaliDataGrid.Rows.Add(new object[] { l.ime, l.id, l.opis, l.alkohol});
                lokaliDataGrid.Rows[lokaliDataGrid.Rows.Count-1].Tag = l;
            }*/

            string select = @"SELECT * FROM lokali";

            SQLiteDataReader r = MainForm.baza.Select(select);

            while (r.Read())
            {
                lokaliDataGrid.Rows.Add(new object[] { r["ime"], r["id"], r["opis"]});
            }

        }


    }
}
