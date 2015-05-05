namespace MapaLokala5._1AU
{
    partial class PrikazLokalaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lokaliDataGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kapacitet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cene = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alkohol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rezervacije = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dodajBtn = new System.Windows.Forms.Button();
            this.obrisiBtn = new System.Windows.Forms.Button();
            this.izmeniBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lokaliDataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lokaliDataGrid
            // 
            this.lokaliDataGrid.AllowUserToAddRows = false;
            this.lokaliDataGrid.AllowUserToDeleteRows = false;
            this.lokaliDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lokaliDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Ime,
            this.Kapacitet,
            this.Cene,
            this.alkohol,
            this.rezervacije});
            this.lokaliDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.lokaliDataGrid.Location = new System.Drawing.Point(1, 0);
            this.lokaliDataGrid.Name = "lokaliDataGrid";
            this.lokaliDataGrid.ReadOnly = true;
            this.lokaliDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lokaliDataGrid.Size = new System.Drawing.Size(645, 220);
            this.lokaliDataGrid.TabIndex = 0;
            this.lokaliDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.lokaliDataGrid.SelectionChanged += new System.EventHandler(this.lokaliDataGrid_SelectionChanged);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Ime
            // 
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Kapacitet
            // 
            this.Kapacitet.HeaderText = "Kapacitet";
            this.Kapacitet.Name = "Kapacitet";
            this.Kapacitet.ReadOnly = true;
            // 
            // Cene
            // 
            this.Cene.HeaderText = "Cene";
            this.Cene.Name = "Cene";
            this.Cene.ReadOnly = true;
            // 
            // alkohol
            // 
            this.alkohol.HeaderText = "Služe alkohol";
            this.alkohol.Name = "alkohol";
            this.alkohol.ReadOnly = true;
            // 
            // rezervacije
            // 
            this.rezervacije.HeaderText = "Rezervacije";
            this.rezervacije.Name = "rezervacije";
            this.rezervacije.ReadOnly = true;
            // 
            // dodajBtn
            // 
            this.dodajBtn.Location = new System.Drawing.Point(19, 30);
            this.dodajBtn.Name = "dodajBtn";
            this.dodajBtn.Size = new System.Drawing.Size(127, 37);
            this.dodajBtn.TabIndex = 1;
            this.dodajBtn.Text = "Dodaj";
            this.dodajBtn.UseVisualStyleBackColor = true;
            this.dodajBtn.Click += new System.EventHandler(this.dodajBtn_Click);
            // 
            // obrisiBtn
            // 
            this.obrisiBtn.Location = new System.Drawing.Point(350, 30);
            this.obrisiBtn.Name = "obrisiBtn";
            this.obrisiBtn.Size = new System.Drawing.Size(127, 37);
            this.obrisiBtn.TabIndex = 2;
            this.obrisiBtn.Text = "Obrisi";
            this.obrisiBtn.UseVisualStyleBackColor = true;
            this.obrisiBtn.Click += new System.EventHandler(this.obrisiBtn_Click);
            // 
            // izmeniBtn
            // 
            this.izmeniBtn.Location = new System.Drawing.Point(184, 30);
            this.izmeniBtn.Name = "izmeniBtn";
            this.izmeniBtn.Size = new System.Drawing.Size(127, 37);
            this.izmeniBtn.TabIndex = 3;
            this.izmeniBtn.Text = "Izmeni";
            this.izmeniBtn.UseVisualStyleBackColor = true;
            this.izmeniBtn.Click += new System.EventHandler(this.izmeniBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dodajBtn);
            this.groupBox1.Controls.Add(this.obrisiBtn);
            this.groupBox1.Controls.Add(this.izmeniBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 238);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 101);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ažuriraj";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(12, 354);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(634, 78);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtriraj";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "sve",
            "id",
            "ime",
            "opis"});
            this.comboBox1.Location = new System.Drawing.Point(237, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(85, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(166, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(350, 38);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 29);
            this.button4.TabIndex = 0;
            this.button4.Text = "Filtriraj";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // PrikazLokalaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 444);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lokaliDataGrid);
            this.Name = "PrikazLokalaForm";
            this.Text = "Tabela lokala";
            this.Load += new System.EventHandler(this.PrikazLokalaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lokaliDataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView lokaliDataGrid;
        private System.Windows.Forms.Button dodajBtn;
        private System.Windows.Forms.Button obrisiBtn;
        private System.Windows.Forms.Button izmeniBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kapacitet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cene;
        private System.Windows.Forms.DataGridViewTextBoxColumn alkohol;
        private System.Windows.Forms.DataGridViewTextBoxColumn rezervacije;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;

    }
}