﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapaLokala5._1AU
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
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
    }
}