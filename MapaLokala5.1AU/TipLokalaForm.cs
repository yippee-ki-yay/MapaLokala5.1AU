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
        private OpenFileDialog ikonicaDijalog = new OpenFileDialog();
        private TipLokala tipLokala = null;
        private ComboBox tipComboBox = null;
        private Image img = null;
        private string filename = null;
        private string update_id;
        private bool isValid = true;
        private bool iconLoad = false;

        public string tip_id
        {
            get;
            set;
        }

        public TipLokalaForm(string id)
        {
            InitializeComponent();
            ikonicaDijalog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";

            update_id = id;

                SQLiteDataReader r = MainForm.baza.Select("select * from tipovi WHERE id='"+id+"'");

                while (r.Read())
                {
                    idTextBox.Text = r["id"].ToString();
                    imeTextBox.Text = r["ime"].ToString();
                    opisTextBox.Text = r["id"].ToString();
                    filename = r["ikona"].ToString();
                    pictureBox1.Load(filename);
                }
            
        }

        public TipLokalaForm()
        {
            InitializeComponent();
            ikonicaDijalog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
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
                iconLoad = true;

            }
        }

        private void TipLokalaForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;

            if (idTextBox.Text == "")
            {
                idError.SetError(idTextBox, "Morate uneti oznaku tipa");
                isValid = false;
            }
            else if (update_id == null)
            {
                SQLiteDataReader r = MainForm.baza.Select
                         ("SELECT id FROM tipovi WHERE id='" + idTextBox.Text + "'");

                //ako vec postoji sa ovim id
                if (r.Read())
                {
                    idError.SetError(idTextBox, "Vec postoji tip sa ovom oznakom, promenite naziv");
                    isValid = false;
                }
            }

            if (imeTextBox.Text == "")
            {
                idError.SetError(imeTextBox, "Morate uneti ime tipa");
                isValid = false;
            }

            //default vrednost ikonice
            if (iconLoad == false)
            {
                filename = @"C:\\Users\\korisnik\\Documents\\Visual Studio 2012\\Projects\\MapaLokala5.1AU\\MapaLokala5.1AU\\tipIcons\\1.png";
            }

            if (isValid == true)
            {
                if (update_id != null)
                {
                    sql = "update tipovi "
                                 + "set id='" + idTextBox.Text + "', ime='" + imeTextBox.Text
                                  + "',opis='" + opisTextBox.Text + "', ikona='" + filename
                                 + "' WHERE id='" + update_id + "'";

                    SQLiteCommand tableCreation = new SQLiteCommand(sql, MainForm.baza.dbConn);
                    tableCreation.ExecuteNonQuery();
                }
                else
                {
                    sql = @"insert into tipovi
                                  (id,ime, opis, ikona)
                                  VALUES (@id, @ime, @opis, @ikona)";

                    SQLiteCommand tableCreation = new SQLiteCommand(sql, MainForm.baza.dbConn);
                    tableCreation.Parameters.AddWithValue("@id", idTextBox.Text);
                    tableCreation.Parameters.AddWithValue("@opis", opisTextBox.Text);
                    tableCreation.Parameters.AddWithValue("@ime", imeTextBox.Text);
                    tableCreation.Parameters.AddWithValue("@ikona", filename);

                    tableCreation.ExecuteNonQuery();
                }
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void idTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idTextBox.Text))
            {
                isValid = false;
                idError.SetError(idTextBox, "Morate uneti id");
            }
            else
                idError.SetError(idTextBox, "");
        }

        private bool isIdUneto()
        {
            if (string.IsNullOrWhiteSpace(idTextBox.Text))
            {
                isValid = false;
                idError.SetError(idTextBox, "Morate uneti id");
                return false;
            }
            else
            {
                idError.SetError(idTextBox, "");
                return true;
            }
        }

        private bool isImeUneto()
        {
            if (string.IsNullOrWhiteSpace(imeTextBox.Text))
            {
                isValid = false;
                imeError.SetError(imeTextBox, "Morate uneti ime");
                return false;
            }
            else
            {
                imeError.SetError(imeTextBox, "");
                return true;
            }
        }

        private void idTextBox_Leave(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                idError.SetError(idTextBox, "");
                isValid = true;
            }
        }

        private void imeTextBox_Leave(object sender, EventArgs e)
        {
            if (imeTextBox.Text != "")
            {
                imeError.SetError(imeTextBox, "");
                isValid = true;
            }
        }
    }
}
