namespace MapaLokala5._1AU
{
    partial class FilterBtn
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
            this.tipoviTabela = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ikonica = new System.Windows.Forms.DataGridViewImageColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.izbrisiBtn = new System.Windows.Forms.Button();
            this.azurirajBtn = new System.Windows.Forms.Button();
            this.dodajBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.filterCombo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tipoviTabela)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tipoviTabela
            // 
            this.tipoviTabela.AllowUserToAddRows = false;
            this.tipoviTabela.AllowUserToDeleteRows = false;
            this.tipoviTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tipoviTabela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Ime,
            this.Ikonica,
            this.Opis});
            this.tipoviTabela.Location = new System.Drawing.Point(0, 0);
            this.tipoviTabela.Name = "tipoviTabela";
            this.tipoviTabela.ReadOnly = true;
            this.tipoviTabela.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tipoviTabela.Size = new System.Drawing.Size(444, 223);
            this.tipoviTabela.TabIndex = 0;
            this.tipoviTabela.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.tipoviTabela.SelectionChanged += new System.EventHandler(this.tipoviTabela_SelectionChanged);
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
            // Ikonica
            // 
            this.Ikonica.HeaderText = "Ikonica";
            this.Ikonica.Name = "Ikonica";
            this.Ikonica.ReadOnly = true;
            this.Ikonica.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ikonica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Opis
            // 
            this.Opis.HeaderText = "Opis";
            this.Opis.Name = "Opis";
            this.Opis.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.izbrisiBtn);
            this.groupBox1.Controls.Add(this.azurirajBtn);
            this.groupBox1.Controls.Add(this.dodajBtn);
            this.groupBox1.Location = new System.Drawing.Point(450, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 214);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ažuriraj";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // izbrisiBtn
            // 
            this.izbrisiBtn.Location = new System.Drawing.Point(32, 159);
            this.izbrisiBtn.Name = "izbrisiBtn";
            this.izbrisiBtn.Size = new System.Drawing.Size(119, 40);
            this.izbrisiBtn.TabIndex = 2;
            this.izbrisiBtn.Text = "Izbriši";
            this.izbrisiBtn.UseVisualStyleBackColor = true;
            this.izbrisiBtn.Click += new System.EventHandler(this.izbrisiBtn_Click);
            // 
            // azurirajBtn
            // 
            this.azurirajBtn.Location = new System.Drawing.Point(32, 88);
            this.azurirajBtn.Name = "azurirajBtn";
            this.azurirajBtn.Size = new System.Drawing.Size(119, 39);
            this.azurirajBtn.TabIndex = 1;
            this.azurirajBtn.Text = "Ažuriraj";
            this.azurirajBtn.UseVisualStyleBackColor = true;
            this.azurirajBtn.Click += new System.EventHandler(this.azurirajBtn_Click);
            // 
            // dodajBtn
            // 
            this.dodajBtn.Location = new System.Drawing.Point(32, 19);
            this.dodajBtn.Name = "dodajBtn";
            this.dodajBtn.Size = new System.Drawing.Size(119, 39);
            this.dodajBtn.TabIndex = 0;
            this.dodajBtn.Text = "Dodaj";
            this.dodajBtn.UseVisualStyleBackColor = true;
            this.dodajBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(284, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "Filtriraj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 20);
            this.textBox1.TabIndex = 3;
            // 
            // filterCombo
            // 
            this.filterCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterCombo.FormattingEnabled = true;
            this.filterCombo.Items.AddRange(new object[] {
            " ",
            "id",
            "ime",
            "opis"});
            this.filterCombo.Location = new System.Drawing.Point(182, 26);
            this.filterCombo.Name = "filterCombo";
            this.filterCombo.Size = new System.Drawing.Size(80, 21);
            this.filterCombo.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.filterCombo);
            this.groupBox2.Location = new System.Drawing.Point(19, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(618, 66);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtriraj";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(374, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "Osveži";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FilterBtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 304);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tipoviTabela);
            this.Name = "FilterBtn";
            this.Text = "TabelaTipovi";
            this.Load += new System.EventHandler(this.TabelaTipovi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tipoviTabela)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tipoviTabela;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button izbrisiBtn;
        private System.Windows.Forms.Button azurirajBtn;
        private System.Windows.Forms.Button dodajBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox filterCombo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewImageColumn Ikonica;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opis;
        private System.Windows.Forms.Button button2;
    }
}