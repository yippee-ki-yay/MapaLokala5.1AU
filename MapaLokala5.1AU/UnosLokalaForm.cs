using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapaLokala5._1AU
{
    partial class UnosLokalaForm : Form
    {
        public Lokal noviLokal = new Lokal();
        private bool formIsValid = true;
        private Regex imeRex = null;
        private string tip_id;
        private string update_id;
        private int n;
        private bool etiketeUcitane = false;

        public UnosLokalaForm(string lokal_id)
        {
            InitializeComponent();

            this.ActiveControl = idTextBox;

            otvaranjeDate.Format = DateTimePickerFormat.Custom;
            otvaranjeDate.CustomFormat = "dd-MM-yyyy   hh:mm";

            this.update_id = lokal_id;

               SQLiteDataReader r = MainForm.baza.Select("select * from lokali WHERE id='"+update_id+"'");

                while (r.Read())
                {
                    idTextBox.Text = r["id"].ToString();
                    imeTextBox.Text = r["ime"].ToString();
                    opisLokalaArea.Text = r["opis"].ToString();
                    kapacitetNumber.Text =  r["kapacitet"].ToString();
                    string date = r["datum"].ToString();
                    otvaranjeDate.Value = Convert.ToDateTime(date);

                    if (((int)r["pusenje"]) == 1)
                        pusenjeBtn.Checked = true;
                    else
                        npusenjeBtn.Checked = true;

                    if (((int)r["rezervacija"]) == 1)
                        rezervacijeBtn.Checked = true;
                    else
                        nrezervacijeBtn.Checked = true;

                    if (((int)r["hendikepirane"]) == 1)
                        hendikepBtn.Checked = true;
                    else
                        nhendikepBtn.Checked = true;

                    //alkoholCombo.Items.Add("alkohola uvek");

                    alkoholCombo.SelectedItem = r["alkohol"].ToString();
                    //alkoholCombo.SelectedItem = "alkohola uvek";
                    ceneCombo.SelectedItem = r["cene"].ToString();
                    string ss = r["tip_id"].ToString();

                    populateTipovi();

                    tipComboBox.SelectedItem = r["tip_id"].ToString();

                }
                populateEtikete();
        }

        public UnosLokalaForm()
        {
            InitializeComponent();
            this.ActiveControl = idTextBox;
            imeRex = new Regex("^[A-Za-z_-][A-Za-z0-9_-]*$");
            populateEtikete();
            populateTipovi();
            otvaranjeDate.Format = DateTimePickerFormat.Custom;
            otvaranjeDate.CustomFormat = "dd-MM-yyyy   hh:mm";
        }

        private void populateEtikete()
        {
             SQLiteDataReader r = MainForm.baza.Select("select id from etikete");

             checkedListBox1.Items.Clear();

             bool update = false;

             //ako je update i chekiraj one etikete koje su kod tog lokala
             if (update_id != "" || update_id != null)
             {
                 update = true;
             }

             SQLiteDataReader rr;
             bool checks= false;

            //dok popunjavamo, ako je ta trenutna etiketa i u tabeli etiketalokala
            //i pripada nasem lokalu ona je chekiramo true
             int i = 0;
             while (r.Read())
             {
                 if (update)
                 {
                     rr = MainForm.baza.Select(@"SELECT etiketa_id FROM EtiketeZaLokale
                                                     WHERE lokal_id ='" + update_id + "'"
                                                     + "AND etiketa_id ='" + r["id"].ToString() + "'");
                     checks = rr.Read();
                 }

                 checkedListBox1.Items.Add(r["id"].ToString(), checks);
                 i++;
             }

             etiketeUcitane = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formIsValid = true;

            if (idTextBox.Text == "")
            {
                errorProvider.SetError(idTextBox, "Morate uneti oznaku lokala");
                formIsValid = false;
            }
            else if (update_id == null)
            {
                SQLiteDataReader r = MainForm.baza.Select
                  ("SELECT id FROM lokali WHERE id='" + idTextBox.Text + "'");

                //ako vec postoji sa ovim id
                if (r.Read())
                {
                    errorProvider.SetError(idTextBox, "Vec postoji lokal sa ovom oznakom, promenite naziv");
                    formIsValid = false;
                }
            }

            if (imeTextBox.Text == "")
            {
                errorIme.SetError(imeTextBox, "Morate uneti ime lokala");
                formIsValid = false;
            }

            if (tipComboBox.SelectedItem == null)
            {
                tipError.SetError(button3, "Morate izabrati tip lokala");
                formIsValid = false;
            }

            if (kapacitetNumber.Text == "")
            {
                kapacitetError.SetError(kapacitetNumber, "Morate uneti kapacitet lokala");
                formIsValid = false;
            }
            else if(!int.TryParse(kapacitetNumber.Text, out n))
            {
                kapacitetError.SetError(kapacitetNumber, "Morate uneti brojcanu vrednost");
                formIsValid = false; 
            }

            if (alkoholCombo.SelectedItem == null)
            {
                alkoholError.SetError(alkoholCombo, "Morate izabrati jednu od opcija");
                formIsValid = false;
            }

            if (ceneCombo.SelectedItem == null)
            {
                ceneError.SetError(ceneCombo, "Morate izabrati jednu od opcija");
                formIsValid = false;
            }

            if (!pusenjeBtn.Checked && !npusenjeBtn.Checked)
            {
                pusenjeError.SetError(groupPusenje, "Morate izabrati Da ili Ne");
                formIsValid = false;
            }

            if (!rezervacijeBtn.Checked && !nrezervacijeBtn.Checked)
            {
                rezervacijeError.SetError(groupBox3, "Morate izabrati Da ili Ne");
                formIsValid = false;
            }

            if (!hendikepBtn.Checked && !nhendikepBtn.Checked)
            {
                hendikepError.SetError(groupBox1, "Morate izabrati Da ili Ne");
                formIsValid = false;
            }

            string sql;

            if (formIsValid == true)
            {
                if (update_id != null)
                {
                    sql = "update lokali "
                                 + "set id='" + idTextBox.Text +
                                  "',opis='" + opisLokalaArea.Text + "', ime='" + imeTextBox.Text +
                                  "',kapacitet='" + (int)Convert.ToInt32(kapacitetNumber.Text) + "', datum='" + otvaranjeDate.Value.ToString()
                                 + "',pusenje='" + ((pusenjeBtn.Checked) ? 1 : 0) + "', rezervacija='" + ((rezervacijeBtn.Checked) ? 1 : 0)
                                 + "',hendikepirane='" + ((hendikepBtn.Checked) ? 1 : 0) + "', alkohol='" + alkoholCombo.SelectedItem.ToString()
                                   + "', cene='" + ceneCombo.SelectedItem.ToString() + "', tip_id='" + tipComboBox.SelectedItem.ToString()
                                 + "' WHERE id='" + update_id + "'";

                    SQLiteCommand tableCreation = new SQLiteCommand(sql, MainForm.baza.dbConn);
                    tableCreation.ExecuteNonQuery();

                    //updejt etikete
                }
                else
                {

                    saveEtikete();

                    sql = @"insert into lokali
                                  (id, opis, ime, kapacitet, datum, cene, alkohol, pusenje, rezervacija,
                                             hendikepirane, tip_id, X, Y)
                                  VALUES (@id, @opis, @ime, @kapacitet, @datum, @cene, 
                                         @alkohol, @pusenje, @rezervacija, @hendikepirane, @tip_id, @X, @Y)";




                    SQLiteCommand tableCreation = new SQLiteCommand(sql, MainForm.baza.dbConn);
                    tableCreation.Parameters.AddWithValue("@id", idTextBox.Text);
                    tableCreation.Parameters.AddWithValue("@opis", opisLokalaArea.Text);
                    tableCreation.Parameters.AddWithValue("@ime", imeTextBox.Text);
                    tableCreation.Parameters.AddWithValue("@kapacitet", n);
                    tableCreation.Parameters.AddWithValue("@datum", otvaranjeDate.Value.ToString());
                    tableCreation.Parameters.AddWithValue("@cene", ceneCombo.SelectedItem.ToString());
                    tableCreation.Parameters.AddWithValue("@tip_id", tipComboBox.SelectedItem.ToString());
                    tableCreation.Parameters.AddWithValue("@pusenje", (pusenjeBtn.Checked) ? 1 : 0);
                    tableCreation.Parameters.AddWithValue("@rezervacija", (rezervacijeBtn.Checked) ? 1 : 0);
                    tableCreation.Parameters.AddWithValue("@hendikepirane", (hendikepBtn.Checked) ? 1 : 0);
                    tableCreation.Parameters.AddWithValue("@alkohol", alkoholCombo.SelectedItem.ToString());
                    tableCreation.Parameters.AddWithValue("@X", -1); //kad napravimo novi lokal nema lokaciju
                    tableCreation.Parameters.AddWithValue("@Y", -1);
                    tableCreation.ExecuteNonQuery();



                }

                this.Close();
            }
        }


        /*
         * Sacuvamo u bazi sa kojim svim etiketama je povezan lokal
         */
        private void saveEtikete()
        {
            for (int i = 0; i < checkedListBox1.Items.Count; ++i)
            {
                //ako je ta etiketa cekirana povezi sa tim lokalom
                if (checkedListBox1.GetItemChecked(i))
                {

                    string sql = @"INSERT INTO EtiketeZaLokale
                                  (lokal_id, etiketa_id)
                                  VALUES (@lid, @eid)";

                    SQLiteCommand saveEtikete = new SQLiteCommand(sql, MainForm.baza.dbConn);
                    saveEtikete.Parameters.AddWithValue("@lid", idTextBox.Text);
                    saveEtikete.Parameters.AddWithValue("@eid", checkedListBox1.Items[i].ToString());
                    saveEtikete.ExecuteNonQuery();
                }
                    
            }
        }

        private void UnosLokalaForm_Load(object sender, EventArgs e)
        {
          //  populateTipovi();
         //   populateEtikete();
        }

        /*
         * Popunjava onaj combobox sa tipovima
         */
        private void populateTipovi()
        {
            //posto koristimo svaki put kad se nesto izmeni
            //obrisemo sve, pa onda dodamo nove podatke
            tipComboBox.Items.Clear();

            string select = @"select id FROM tipovi";

            SQLiteDataReader r = MainForm.baza.Select(select);

            while (r.Read())
            {
                tipComboBox.Items.Add(r["id"].ToString());
            }

            
        }


        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TipLokalaForm noviLokalForm = new TipLokalaForm(noviLokal.tipLokala, tipComboBox);
            var result = noviLokalForm.ShowDialog();
            tip_id = noviLokalForm.tip_id;
            populateTipovi();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            NovaEtiketaForm novaEtikaForm = new NovaEtiketaForm();
            novaEtikaForm.ShowDialog();
            populateEtikete();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {

        }



        private void idTextBox_Validating(object sender, CancelEventArgs e)
        {
      

        }

        private void imeTextBox_Validating(object sender, CancelEventArgs e)
        {
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void idTextBox_Leave(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                errorProvider.SetError(idTextBox, "");
                formIsValid = true;
            }
        }

        private void imeTextBox_Leave(object sender, EventArgs e)
        {
            if (imeTextBox.Text != "")
            {
                errorIme.SetError(imeTextBox, "");
                formIsValid = true;
            }
        }

        private void tipComboBox_Leave(object sender, EventArgs e)
        {
            if (tipComboBox.SelectedItem != null)
            {
                tipError.SetError(button3, "");
                formIsValid = true;
            }
        }

        private void kapacitetNumber_Leave(object sender, EventArgs e)
        {
            if (kapacitetNumber.Text != "")
            {
                kapacitetError.SetError(kapacitetNumber, "");
                formIsValid = true;
            }
        }

        private void alkoholCombo_Leave(object sender, EventArgs e)
        {
            if (alkoholCombo.SelectedItem != null)
            {
                alkoholError.SetError(alkoholCombo, "");
                formIsValid = true;
            }
        }

        private void ceneCombo_Leave(object sender, EventArgs e)
        {
            if (ceneCombo.SelectedItem != null)
            {
                ceneError.SetError(ceneCombo, "");
                formIsValid = true;
            }
        }

        private void groupPusenje_Leave(object sender, EventArgs e)
        {
            if (pusenjeBtn.Checked || npusenjeBtn.Checked)
            {
                pusenjeError.SetError(groupPusenje, "");
                formIsValid = true;
            }
        }

        private void groupBox3_Leave(object sender, EventArgs e)
        {
            if (rezervacijeBtn.Checked || nrezervacijeBtn.Checked)
            {
                rezervacijeError.SetError(groupBox3, "");
                formIsValid = true;
            }
        }

        private void groupBox1_Leave(object sender, EventArgs e)
        {
            if (hendikepBtn.Checked || nhendikepBtn.Checked)
            {
                hendikepError.SetError(groupBox1, "");
                formIsValid = true;
            }
        }

        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //ovo se poziva i kad iz koda ubacujem oznacene etikete
            //zato imam ovu proveru da mi se kod izvrsava samo kad korisnik dodatno odabere
            if (etiketeUcitane && update_id != null)
            {
                //naziv promenjenog checkboxa
                string currentItem = (string)this.checkedListBox1.Items[e.Index];

                string sql = "";

                //ako je chekiran ubacimo ga kao novu vezu u bazi
                if (e.NewValue == CheckState.Checked)
                {
                    sql = @"INSERT INTO EtiketeZaLokale
                                  (lokal_id, etiketa_id)
                                  VALUES (@lid, @eid)";

                    SQLiteCommand saveEtikete = new SQLiteCommand(sql, MainForm.baza.dbConn);
                    saveEtikete.Parameters.AddWithValue("@lid", idTextBox.Text);
                    saveEtikete.Parameters.AddWithValue("@eid", currentItem);
                    saveEtikete.ExecuteNonQuery();
                }
                //ako je odcekiran izbrisemo postojecu vezu iz baze
                else if (e.NewValue == CheckState.Unchecked)
                {
                    sql = @"DELETE FROM EtiketeZaLokale
                                  WHERE etiketa_id='" + currentItem + "'";
                    SQLiteCommand saveEtikete = new SQLiteCommand(sql, MainForm.baza.dbConn);
                    saveEtikete.ExecuteNonQuery();
                }

            }

          
        }


    }
}
