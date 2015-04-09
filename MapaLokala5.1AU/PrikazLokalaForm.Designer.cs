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
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alkohol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lokaliDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lokaliDataGrid
            // 
            this.lokaliDataGrid.AllowUserToAddRows = false;
            this.lokaliDataGrid.AllowUserToDeleteRows = false;
            this.lokaliDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lokaliDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ime,
            this.Id,
            this.Opis,
            this.Alkohol});
            this.lokaliDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.lokaliDataGrid.Location = new System.Drawing.Point(1, 1);
            this.lokaliDataGrid.Name = "lokaliDataGrid";
            this.lokaliDataGrid.ReadOnly = true;
            this.lokaliDataGrid.Size = new System.Drawing.Size(344, 152);
            this.lokaliDataGrid.TabIndex = 0;
            this.lokaliDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Ime
            // 
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Opis
            // 
            this.Opis.HeaderText = "Opis";
            this.Opis.Name = "Opis";
            this.Opis.ReadOnly = true;
            // 
            // Alkohol
            // 
            this.Alkohol.HeaderText = "Alkohol";
            this.Alkohol.Name = "Alkohol";
            this.Alkohol.ReadOnly = true;
            // 
            // PrikazLokalaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 298);
            this.Controls.Add(this.lokaliDataGrid);
            this.Name = "PrikazLokalaForm";
            this.Text = "Tabela lokala";
            this.Load += new System.EventHandler(this.PrikazLokalaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lokaliDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView lokaliDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opis;
        private System.Windows.Forms.DataGridViewComboBoxColumn Alkohol;

    }
}