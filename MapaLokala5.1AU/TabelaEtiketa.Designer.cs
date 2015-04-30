namespace MapaLokala5._1AU
{
    partial class TabelaEtiketa
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
            this.etiketeTabela = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Boja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.izmeniBtn = new System.Windows.Forms.Button();
            this.dodajBtn = new System.Windows.Forms.Button();
            this.obrisiBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.filterBtn = new System.Windows.Forms.Button();
            this.filterCombo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.etiketeTabela)).BeginInit();
            this.GroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // etiketeTabela
            // 
            this.etiketeTabela.AllowUserToAddRows = false;
            this.etiketeTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.etiketeTabela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Boja,
            this.Opis});
            this.etiketeTabela.Location = new System.Drawing.Point(3, 3);
            this.etiketeTabela.Name = "etiketeTabela";
            this.etiketeTabela.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.etiketeTabela.Size = new System.Drawing.Size(343, 221);
            this.etiketeTabela.TabIndex = 0;
            this.etiketeTabela.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.etiketeTabela_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // Boja
            // 
            this.Boja.HeaderText = "Boja";
            this.Boja.Name = "Boja";
            // 
            // Opis
            // 
            this.Opis.HeaderText = "Opis";
            this.Opis.Name = "Opis";
            // 
            // GroupBox
            // 
            this.GroupBox.Controls.Add(this.izmeniBtn);
            this.GroupBox.Controls.Add(this.dodajBtn);
            this.GroupBox.Controls.Add(this.obrisiBtn);
            this.GroupBox.Location = new System.Drawing.Point(365, 15);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(142, 208);
            this.GroupBox.TabIndex = 1;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Ažuriraj";
            // 
            // izmeniBtn
            // 
            this.izmeniBtn.Location = new System.Drawing.Point(16, 88);
            this.izmeniBtn.Name = "izmeniBtn";
            this.izmeniBtn.Size = new System.Drawing.Size(99, 29);
            this.izmeniBtn.TabIndex = 2;
            this.izmeniBtn.Text = "Izmeni";
            this.izmeniBtn.UseVisualStyleBackColor = true;
            this.izmeniBtn.Click += new System.EventHandler(this.izmeniBtn_Click);
            // 
            // dodajBtn
            // 
            this.dodajBtn.Location = new System.Drawing.Point(16, 36);
            this.dodajBtn.Name = "dodajBtn";
            this.dodajBtn.Size = new System.Drawing.Size(99, 29);
            this.dodajBtn.TabIndex = 1;
            this.dodajBtn.Text = "Dodaj";
            this.dodajBtn.UseVisualStyleBackColor = true;
            // 
            // obrisiBtn
            // 
            this.obrisiBtn.Location = new System.Drawing.Point(16, 141);
            this.obrisiBtn.Name = "obrisiBtn";
            this.obrisiBtn.Size = new System.Drawing.Size(99, 29);
            this.obrisiBtn.TabIndex = 0;
            this.obrisiBtn.Text = "Izbriši";
            this.obrisiBtn.UseVisualStyleBackColor = true;
            this.obrisiBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.filterBtn);
            this.groupBox2.Controls.Add(this.filterCombo);
            this.groupBox2.Location = new System.Drawing.Point(3, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(501, 66);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtriraj";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 20);
            this.textBox1.TabIndex = 3;
            // 
            // filterBtn
            // 
            this.filterBtn.Location = new System.Drawing.Point(308, 23);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(69, 27);
            this.filterBtn.TabIndex = 2;
            this.filterBtn.Text = "Filtriraj";
            this.filterBtn.UseVisualStyleBackColor = true;
            // 
            // filterCombo
            // 
            this.filterCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterCombo.FormattingEnabled = true;
            this.filterCombo.Items.AddRange(new object[] {
            "sve",
            "id",
            "ime",
            "ikona",
            "opis"});
            this.filterCombo.Location = new System.Drawing.Point(202, 26);
            this.filterCombo.Name = "filterCombo";
            this.filterCombo.Size = new System.Drawing.Size(90, 21);
            this.filterCombo.TabIndex = 4;
            // 
            // TabelaEtiketa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 294);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GroupBox);
            this.Controls.Add(this.etiketeTabela);
            this.Name = "TabelaEtiketa";
            this.Text = "TabelaEtiketa";
            this.Load += new System.EventHandler(this.TabelaEtiketa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.etiketeTabela)).EndInit();
            this.GroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView etiketeTabela;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Boja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opis;
        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.Button izmeniBtn;
        private System.Windows.Forms.Button dodajBtn;
        private System.Windows.Forms.Button obrisiBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button filterBtn;
        private System.Windows.Forms.ComboBox filterCombo;
    }
}