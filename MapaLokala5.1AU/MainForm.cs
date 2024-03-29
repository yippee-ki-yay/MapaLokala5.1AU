﻿using System;
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
        private TreeNode dragNode = null;
        private Rectangle selekcioniProzor;
        private Point offset;

        private List<Ikonica> listaIkonica = new List<Ikonica>();
        private Ikonica selektovan;
        private Ikonica dragIkonica;
        private ToolTip imeIkonice = new ToolTip();

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
                               X INT,
                               Y INT,
                               FOREIGN KEY(tip_id) REFERENCES tipovi(id))");

            baza.createTable(@"create table if not exists etikete 
                              (id TEXT PRIMARY KEY, 
                               boja TEXT,
                               opis TEXT
                             )");

            baza.createTable(@"create table if not exists tipovi 
                              (id TEXT PRIMARY KEY,
                               ime TEXT, 
                               ikona TEXT,
                               opis TEXT
                               )");
            
            baza.createTable(@"CREATE TABLE IF NOT EXISTS EtiketeZaLokale
                               (id INTEGER PRIMARY KEY,
                               lokal_id TEXT,
                               etiketa_id TEXT,
                               FOREIGN KEY(lokal_id) REFERENCES lokali(id),
                               FOREIGN KEY(etiketa_id) REFERENCES etikete(id)
                                )");

           // baza.Add("insert into highscores (name, score) values ('Me', 3000)");

            populateTree();
            populateMap();

        }
        /*
         * Popunjavamo drvo lokala, prolazimo kroz sve tiove i za svaki dodajemo lokale tog tipa
         */
        public void populateTree()
        {
            drvo.Nodes.Clear();

            //popunimo listu slika, prodjemo koroz sve tipove i uzmemo ikonice
            ImageList listImg = new ImageList();
            SQLiteDataReader slike = MainForm.baza.Select("SELECT id,ikona, ime FROM tipovi");

            //dodamo nultu defaultnu sliku u listu
            listImg.Images.Add(Image.FromFile(@"C:\Users\korisnik\Desktop\icon.png"));

            int i = 1;
            while (slike.Read())
            {
                string str = slike["ikona"].ToString();

                listImg.Images.Add(Image.FromFile(slike["ikona"].ToString()));

                //svi lokali koji su tog tipa
                SQLiteDataReader r = MainForm.baza.Select("SELECT ime,X,Y FROM lokali WHERE tip_id='"
                                                                              +slike["id"].ToString()+"'");
                List<TreeNode> listaLokala = new List<TreeNode>();

                while (r.Read())
                {
                    TreeNode t = new TreeNode(r["ime"].ToString());
                    t.ImageIndex = 0;
                    t.Name = r["ime"].ToString();

                    //ako je prevuceno na mapi onda je sivo
                    if (((int)r["X"]) != -1 && ((int)r["Y"]) != -1)
                        t.ForeColor = Color.Gray;

                    t.SelectedImageIndex = t.ImageIndex;
                    listaLokala.Add(t);
                }

                //ubacimo ime tipa i sve njegove lokale koji su subnodovi tog tipa
                TreeNode tmp = new TreeNode(slike["ime"].ToString(), listaLokala.ToArray());
                tmp.ImageIndex = i;
                tmp.Expand();
                tmp.SelectedImageIndex = tmp.ImageIndex; //iskljucimo da se menja kad selektujemo
                drvo.Nodes.Add(tmp);
                i++;

            }

            drvo.ImageList = listImg;

        }

        /*
         * Kad se program pokrene, postavimo sve lokale na njihovoj poziciji na mapi
         */
        private void populateMap()
        {
            SQLiteDataReader r = MainForm.baza.Select("SELECT ime, X,Y, tip_id FROM lokali");

            while (r.Read())
            {
                int x = (int)r["X"];
                int y = (int)r["Y"];

                if (x != -1 && y != -1) //ako su mu x,y -1 znaci da lokal nije prikazan na mapi
                {
                    //uzmemo iz tabele tipovi ikonu, koja je povezana sa nasim lokalom da mozemo prikazati sliku lokala
                    string sql = "SELECT ikona FROM tipovi WHERE id=@tip_id";
                    SQLiteCommand tipCommand = new SQLiteCommand(sql, MainForm.baza.dbConn);
                    tipCommand.Parameters.AddWithValue("@tip_id", r["tip_id"].ToString());

                    SQLiteDataReader tipReader = tipCommand.ExecuteReader();

                    string putanja = tipReader["ikona"].ToString();

                    nacrtajSliku(putanja, (int)x, (int)y, r["ime"].ToString()); //ako je dosao ovde nije null, zato kastujem u int
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UnosLokalaForm newForm = new UnosLokalaForm();
            newForm.ShowDialog();
            populateTree();
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
            newForm.ShowDialog();
            populateTree();
        }

        private void tabelaLokalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TipLokalaForm().ShowDialog();
            populateTree();
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
            new FilterBtn().ShowDialog();
            populateTree();
        }

        private void tabelaEtiketaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TabelaEtiketa().Show();
        }

        private void novaEtiketaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NovaEtiketaForm().Show();
        }
        /// <summary>
        /// Kada selektujemo node na tree, prodjemo kroz listu ikonica i sleketujemo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string ime = e.Node.Name;

            foreach (Ikonica i in listaIkonica)
            {
                if (i.ime.Equals(ime))
                {
                    if (selektovan != null)
                        selektovan.BorderStyle = BorderStyle.None;

                    i.BorderStyle = BorderStyle.FixedSingle;
                    selektovan = i;
                }
            }
        }

        private void nacrtajSliku(string putanja, int x, int y, string ime)
        {
            Image img = Image.FromFile(putanja);

            Ikonica picture = new Ikonica();
            picture.SizeMode = PictureBoxSizeMode.AutoSize;
            picture.Image = img;

            //postavljamo poziciju i oduzimamo tako da nam slika bude na centru x,y poz
            picture.Location = new Point(x - picture.Width/2,y-picture.Height/2);
            picture.Show();
            picture.ime = ime;

            //dodajemo ovde rucno evenove sta se desi kad korisnik klikne na ikonice
            picture.MouseClick += new MouseEventHandler(klikNaIkonicu);
            picture.MouseDoubleClick += new MouseEventHandler(dupliKlikNaIkonicu);

            picture.MouseDown += new MouseEventHandler(drzimoNaIkonicu);
            picture.MouseMove += new MouseEventHandler(zapoceoDrag);

            picture.MouseHover += new EventHandler((s, e) =>
            {
                ToolTip tt = new ToolTip();
                tt.SetToolTip(picture, ime);
            });

            listaIkonica.Add(picture);

            this.Controls.Add(picture); //kada programski dodajemo kontrole moramo ih ubaciti u Controls listu
            this.Controls.SetChildIndex(picture, 0);  //postavimo ga na front, da se iscrtava ispred mape
        }

        private void drzimoNaIkonicu(object sender, MouseEventArgs e)
        {
            dragIkonica = (Ikonica)sender; //nasli node na toj lokaciji

            if (dragIkonica != null) //ako smo uboli neki node
            {
              Size dragVelicina = SystemInformation.DragSize;
              selekcioniProzor = new Rectangle(new Point(e.X - (dragVelicina.Width / 2), e.Y - (dragVelicina.Height / 2)), dragVelicina);
            }
        }

        private void zapoceoDrag(object sender, MouseEventArgs e)
        {
            Ikonica s = (Ikonica)sender;

            //korisnik je kliknuo i sad drzi levi taster misa
            if (e.Button == MouseButtons.Left)
            {
                //prva provera da li je uopste dobar node krenuo da povlaci
                if ((selekcioniProzor != Rectangle.Empty) &&
                    (!selekcioniProzor.Contains(e.X, e.Y))) //druga da li je izasao iz "mrtve zone"
                {
                    offset = SystemInformation.WorkingArea.Location;

                    DragDropEffects efekti = s.DoDragDrop(dragIkonica, DragDropEffects.Copy);
                }
            }
        }


        /*
         * Ovo se poziva kada spustimo node na mapu
         */
        private void mapaPanel_DragDrop(object sender, DragEventArgs e)
        {
            Type t = new TreeNode().GetType(); //nadjemo tip preko ovog izvalacimo sta smo preneli
            Type ikonicaTip = new Ikonica().GetType();
            TreeNode prevuceni;
            Ikonica pomerena;
            selekcioniProzor = Rectangle.Empty;

            if (e.Data.GetDataPresent(t)) //proverimo da li smo povukli te podatke
            {
                prevuceni = (TreeNode)e.Data.GetData(t); //uzmemo nas prevuceni node

                if (prevuceni.ForeColor.Equals(Color.Gray))
                    return;
               
                //Sada imamo koj node smo stavili na mapu, preko imena izvucemo iz baze njegovu sliku

                SQLiteDataReader r = MainForm.baza.Select("SELECT ikona FROM tipovi WHERE ime= '" + prevuceni.Parent.Text + "'");

                int x = e.X - this.Left - 4;
                int y = e.Y - this.Top - menuStrip1.Height-4;

                //pozivamo pomocnu metodu za crtanje, ubacujemo x,y poz uz mali offset zbog menia i paddinga izmedju
                nacrtajSliku(r["ikona"].ToString(), x, y, prevuceni.Text);

                //Napomena: postavimo da je node siv, na drugim mestima vrsimo prvere ako je siv da ne moze da se doda
                prevuceni.ForeColor = Color.Gray;
                

                string sql = @"UPDATE lokali SET X = @xxx, Y = @yyy
                              WHERE ime='" + prevuceni.Name + "'";
                SQLiteCommand pozicijeCommand = new SQLiteCommand(sql, MainForm.baza.dbConn);
                pozicijeCommand.Parameters.AddWithValue("@xxx", x);
                pozicijeCommand.Parameters.AddWithValue("@yyy", y);
                pozicijeCommand.ExecuteReader();


            }
            else if(e.Data.GetDataPresent(ikonicaTip))
            {
                pomerena = (Ikonica)e.Data.GetData(ikonicaTip);

                int x = e.X - this.Left - 4;
                int y = e.Y - this.Top - menuStrip1.Height - 4;

                pomerena.Location = new Point(x,y);

                string sql = @"UPDATE lokali SET X = @xxx, Y = @yyy
                              WHERE ime='" + pomerena.ime + "'";
                SQLiteCommand pozicijeCommand = new SQLiteCommand(sql, MainForm.baza.dbConn);
                pozicijeCommand.Parameters.AddWithValue("@xxx", x);
                pozicijeCommand.Parameters.AddWithValue("@yyy", y);
                pozicijeCommand.ExecuteReader();
            }
        }

        private void mapaPanel_DragEnter(object sender, DragEventArgs e)
        {
            Type type = new TreeNode().GetType();
            Type t = new Ikonica().GetType();

            if(e.Data.GetDataPresent(type) || e.Data.GetDataPresent(t))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void drvo_MouseMove(object sender, MouseEventArgs e)
        {
            //korisnik je kliknuo i sad drzi levi taster misa
            if (e.Button == MouseButtons.Left)
            {
                //prva provera da li je uopste dobar node krenuo da povlaci
                if((selekcioniProzor != Rectangle.Empty) && 
                    (!selekcioniProzor.Contains(e.X, e.Y))) //druga da li je izasao iz "mrtve zone"
                {
                    offset = SystemInformation.WorkingArea.Location;

                    DragDropEffects efekti = drvo.DoDragDrop(dragNode, DragDropEffects.Copy);
                }
            }
        }

        private void drvo_MouseDown(object sender, MouseEventArgs e)
        {
            dragNode = drvo.GetNodeAt(e.Location); //nasli node na toj lokaciji

            if (dragNode != null) //ako smo uboli neki node
            {
                if (dragNode.ForeColor.Equals(Color.Gray))
                    return;

                drvo.SelectedNode = dragNode; //postavi da je taj node selektovan

                int leaf = dragNode.Level;

                if(leaf == 1) //uzimamo samo node lokale
                {
                    Size dragVelicina = SystemInformation.DragSize;
                    selekcioniProzor = new Rectangle(new Point(e.X - (dragVelicina.Width / 2), e.Y - (dragVelicina.Height / 2)), dragVelicina);
                }
                else
                {
                    selekcioniProzor = Rectangle.Empty;
                }
            }
        }

        /*
         * Kad uradis dupli klik na drvo da se otvori azuriranje toga
         */
        private void drvo_MouseDoubleClick(object sender, MouseEventArgs e)
        {  
             dragNode = drvo.GetNodeAt(e.Location); //nasli node na toj lokaciji

             if (dragNode != null && dragNode.Level == 1)
             {
                 SQLiteDataReader r = MainForm.baza.Select("SELECT id FROM lokali WHERE ime='" + dragNode.Text + "'");
                 new UnosLokalaForm(r["id"].ToString()).ShowDialog();
                 populateTree();
             }
             else if (dragNode != null && dragNode.Level == 0)
             {
                 SQLiteDataReader r = MainForm.baza.Select("SELECT id FROM tipovi WHERE ime='" + dragNode.Text + "'");
                 new TipLokalaForm(r["id"].ToString()).ShowDialog();
                 populateTree();
             }
        }

        private void klikNaIkonicu(object sender, MouseEventArgs e)
        {
            Ikonica s = (Ikonica)sender;
            if(!s.Equals(selektovan))
            if (e.Clicks == 1)
            {
                //koristimo selektovan objekat da imamo samo 1 selektovan uvek
                if (selektovan != null)
                    selektovan.BorderStyle = BorderStyle.None;

                s.BorderStyle = BorderStyle.FixedSingle;
                selektovan = s;

                //nadjemo node kliknute ikonice i njega oznacimo, ako ih ima vise oznacimo prvi [0]
                TreeNode[] nodes = drvo.Nodes.Find(s.ime, true);

                if (nodes.Length > 0)
                {
                    drvo.SelectedNode = nodes[0];
                }
            }

        }

        private void dupliKlikNaIkonicu(object sender, MouseEventArgs e)
        {
            Ikonica s = (Ikonica)sender;
            SQLiteDataReader r = MainForm.baza.Select("SELECT id FROM lokali WHERE ime='"+s.ime+"'");
            new UnosLokalaForm(r["id"].ToString()).ShowDialog();
            populateTree();
        }

        private void mapaPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (selektovan != null)
            {
                selektovan.BorderStyle = BorderStyle.None;
                selektovan = null;
            }
            
        }

        private class Ikonica : PictureBox
        {
            public string ime
            {
                get;
                set;
            }
           
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.E)
            {

                selektovan.Location = new Point(-300, -400);
                selektovan.Refresh();
            }
        }

        private void pomoćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "help.chm");
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.E)
            {

            }
        }

        private void drvo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (selektovan != null)
                {
                    selektovan.Location = new Point(-300, -300);
                    selektovan.Refresh();

                    int x = -1, y = -1;

                    string sql = @"UPDATE lokali SET X = @xxx, Y = @yyy
                            WHERE ime = '" + selektovan.ime + "'";
                    SQLiteCommand pozicijeCommand = new SQLiteCommand(sql, MainForm.baza.dbConn);
                    pozicijeCommand.Parameters.AddWithValue("@xxx", x);
                    pozicijeCommand.Parameters.AddWithValue("@yyy", y);
                    pozicijeCommand.ExecuteReader();
                    populateTree();
                   // populateMap();

                }
            }
        }

        private void mapaPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
