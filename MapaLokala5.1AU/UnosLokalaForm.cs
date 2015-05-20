﻿using System;
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
                        radioButton3.Checked = true;

                    if (((int)r["rezervacija"]) == 1)
                        rezervacijeBtn.Checked = true;
                    else
                        radioButton5.Checked = true;

                    if (((int)r["hendikepirane"]) == 1)
                        hendikepBtn.Checked = true;
                    else
                        radioButton2.Checked = true;

                    alkoholCombo.SelectedItem = r["alkohol"].ToString();
                    ceneCombo.SelectedItem = r["cene"].ToString();
                    string ss = r["tip_id"].ToString();
                    
                //    otvaranjeDate.Text = r["datum"].ToString();

                }
        }

        public UnosLokalaForm()
        {
            InitializeComponent();
            this.ActiveControl = idTextBox;
            imeRex = new Regex("^[A-Za-z_-][A-Za-z0-9_-]*$");
            populateEtikete();
            otvaranjeDate.Format = DateTimePickerFormat.Custom;
            otvaranjeDate.CustomFormat = "dd-MM-yyyy   hh:mm";
        }

        private void populateEtikete()
        {
             SQLiteDataReader r = MainForm.baza.Select("select id from etikete");

             checkedListBox1.Items.Clear();

             while (r.Read())
             {
                 checkedListBox1.Items.Add(r["id"], false);
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formIsValid = true;
            this.ValidateChildren();

            string sql;

            if (update_id != null)
            {
                sql = "update lokali "
                             + "set id='" + idTextBox.Text +
                              "',opis='" + opisLokalaArea.Text + "', ime='" + imeTextBox.Text +
                              "',kapacitet='" + (int)Convert.ToInt32(kapacitetNumber.Text)+ "', datum='" + otvaranjeDate.Value.ToString()
                             + "',pusenje='" + ((pusenjeBtn.Checked) ? 1 : 0) + "', rezervacija='" + ((rezervacijeBtn.Checked) ? 1 : 0)
                             + "',hendikepirane='" + ((hendikepBtn.Checked) ? 1 : 0) + "', alkohol='" + alkoholCombo.SelectedItem.ToString()
                            //   + "', cene='" + ceneCombo.SelectedItem.ToString()
                             + "' WHERE id='" + update_id + "'";

                SQLiteCommand tableCreation = new SQLiteCommand(sql, MainForm.baza.dbConn);
                tableCreation.ExecuteNonQuery();
            }
            else
            {
                if (formIsValid == true)
                {

                    sql = @"insert into lokali
                                  (id, opis, ime, kapacitet, datum, cene, alkohol, pusenje, rezervacija,
                                             hendikepirane, tip_id)
                                  VALUES (@id, @opis, @ime, @kapacitet, @datum, @cene, 
                                         @alkohol, @pusenje, @rezervacija, @hendikepirane, @tip_id)";

                    SQLiteCommand tableCreation = new SQLiteCommand(sql, MainForm.baza.dbConn);
                    tableCreation.Parameters.AddWithValue("@id", idTextBox.Text);
                    tableCreation.Parameters.AddWithValue("@opis", opisLokalaArea.Text);
                    tableCreation.Parameters.AddWithValue("@ime", imeTextBox.Text);
                    tableCreation.Parameters.AddWithValue("@kapacitet", Convert.ToInt32(kapacitetNumber.Text));
                    tableCreation.Parameters.AddWithValue("@datum", otvaranjeDate.Value.ToString());
                    tableCreation.Parameters.AddWithValue("@cene", ceneCombo.SelectedItem.ToString());
                    tableCreation.Parameters.AddWithValue("@tip_id", tipComboBox.SelectedItem.ToString());
                    tableCreation.Parameters.AddWithValue("@pusenje", (pusenjeBtn.Checked) ? 1 : 0);
                    tableCreation.Parameters.AddWithValue("@rezervacija", (rezervacijeBtn.Checked) ? 1 : 0);
                    tableCreation.Parameters.AddWithValue("@hendikepirane", (hendikepBtn.Checked) ? 1 : 0);
                    tableCreation.Parameters.AddWithValue("@alkohol", alkoholCombo.SelectedItem.ToString());
                    tableCreation.ExecuteNonQuery();

                }
                
            }

            this.Close();
        }

        private void UnosLokalaForm_Load(object sender, EventArgs e)
        {
            string select = @"select id FROM tipovi";

            SQLiteDataReader r = MainForm.baza.Select(select);

            while (r.Read())
            {
                tipComboBox.Items.Add(r["id"]);
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
            if (idTextBox.Text == "")
            {
                formIsValid = false;
                errorProvider.SetError(idTextBox, "Morate uneti id");
            }
            else
            {
                errorProvider.SetError(idTextBox, "");
            }
         

        }

        private void imeTextBox_Validating(object sender, CancelEventArgs e)
        {
          /*  if (imeRex.Match(imeTextBox.Text).Success)
            {
                errorIme.SetError(imeTextBox, "");
            }
            else
            {
                errorIme.SetError(imeTextBox, "Ime mora poceti sa slovom");
                formIsValid = false;
            }*/
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


    }
}
