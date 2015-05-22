﻿using System;
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
    partial class NovaEtiketaForm : Form
    {
        private ColorDialog colorDialog = new ColorDialog();
        private ListBox boxEtiketa = null;
        private string id;
        private string update_id;

        public NovaEtiketaForm()
        {
            InitializeComponent();
        }

        public NovaEtiketaForm(string update_id)
        {
            InitializeComponent();

            this.update_id = update_id;

            SQLiteDataReader r = MainForm.baza.Select("select * from etikete WHERE id=" + update_id);

            while (r.Read())
            {
                idTextBox.Text = r["id"].ToString();
                opisTextBox.Text = r["opis"].ToString();
                string colorCode = r["boja"].ToString();

                Int32 iColorInt = Convert.ToInt32(colorCode.Substring(1), 16);
                Color curveColor = System.Drawing.Color.FromArgb(iColorInt);

                pictureBox1.BackColor = System.Drawing.ColorTranslator.FromHtml(colorCode);

               // pictureBox1.BackColor = curveColor;
               
            }
        }

        public NovaEtiketaForm(ListBox boxEtiketa,string id)
        {
            this.id = id;
            this.boxEtiketa = boxEtiketa;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string sql;

            if (update_id != null)
            {
                sql = "update etikete "
                             + "set id='" + idTextBox.Text +
                              "',opis='" + opisTextBox.Text + "', boja='" + colorDialog.Color.ToArgb().ToString()
                             + "' WHERE id='" + update_id + "'";

                SQLiteCommand tableCreation = new SQLiteCommand(sql, MainForm.baza.dbConn);
                tableCreation.ExecuteNonQuery();
            }
            else
            {

                sql = @"insert into etikete
                                  (id,opis, boja)
                                  VALUES (@id, @opis, @boja)";

                SQLiteCommand tableCreation = new SQLiteCommand(sql, MainForm.baza.dbConn);
                tableCreation.Parameters.AddWithValue("@id", idTextBox.Text);
                tableCreation.Parameters.AddWithValue("@opis", opisTextBox.Text);
                tableCreation.Parameters.AddWithValue("@boja", System.Drawing.ColorTranslator.ToHtml(colorDialog.Color).ToString());

                tableCreation.ExecuteNonQuery();

                System.Console.WriteLine(System.Drawing.ColorTranslator.ToHtml(colorDialog.Color).ToString());
            }

            this.Close();
        }

        private void NovaEtiketaForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
