using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace MapaLokala5._1AU
{
    public partial class MainForm : Form
    {
        public static SQLiteHelper baza = null;

        public MainForm()
        {
            InitializeComponent();
            
            baza = new SQLiteHelper("baza.sqlite");

            baza.createTable(@"create table if not exists lokali 
                              (id TEXT PRIMARY KEY, 
                               ime TEXT,
                               kapacitet INT,
                               datum TEXT,
                               opis TEXT,
                               alkohol TEXT,
                               cene TEXT,
                               pusenje INT,
                               rezervacija INT,
                               hendikepirane INT,
                               tip_id TEXT,
                               FOREIGN KEY(tip_id) REFERENCES tipovi(id))");

            baza.createTable(@"create table if not exists etikete 
                              (id TEXT PRIMARY KEY, 
                               boja TEXT,
                               opis TEXT,
                               lokal_id TEXT,
                               FOREIGN KEY(lokal_id) REFERENCES lokali(id))");

            baza.createTable(@"create table if not exists tipovi 
                              (id TEXT PRIMARY KEY,
                               ime TEXT, 
                               ikona TEXT,
                               opis TEXT
                               )");

           // baza.Add("insert into highscores (name, score) values ('Me', 3000)");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UnosLokalaForm newForm = new UnosLokalaForm();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrikazLokalaForm prikazLokala = new PrikazLokalaForm();
            prikazLokala.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void noviLokalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnosLokalaForm newForm = new UnosLokalaForm();
            newForm.Show();
        }

        private void tabelaLokalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TipLokalaForm().Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabelaLokalaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new PrikazLokalaForm().Show();
        }

        private void tabelaTipovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FilterBtn().Show();
        }

        private void tabelaEtiketaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TabelaEtiketa().Show();
        }

        private void novaEtiketaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NovaEtiketaForm().Show();
        }
    }
}
