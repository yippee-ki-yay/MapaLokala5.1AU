namespace MapaLokala5._1AU
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lokaliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviLokalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelaLokalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaEtiketaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelaLokalaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelaTipovaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelaEtiketaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomoćToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drvo = new System.Windows.Forms.TreeView();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.mapaPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.lokaliToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.pomoćToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(647, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.fileToolStripMenuItem.Text = "Datoteka";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Sačuvaj";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.loadToolStripMenuItem.Text = "Učitaj";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.quitToolStripMenuItem.Text = "Izadji";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // lokaliToolStripMenuItem
            // 
            this.lokaliToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noviLokalToolStripMenuItem,
            this.tabelaLokalaToolStripMenuItem,
            this.novaEtiketaToolStripMenuItem});
            this.lokaliToolStripMenuItem.Name = "lokaliToolStripMenuItem";
            this.lokaliToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.lokaliToolStripMenuItem.Text = "Dodaj";
            // 
            // noviLokalToolStripMenuItem
            // 
            this.noviLokalToolStripMenuItem.Name = "noviLokalToolStripMenuItem";
            this.noviLokalToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.noviLokalToolStripMenuItem.Text = "Novi lokal";
            this.noviLokalToolStripMenuItem.Click += new System.EventHandler(this.noviLokalToolStripMenuItem_Click);
            // 
            // tabelaLokalaToolStripMenuItem
            // 
            this.tabelaLokalaToolStripMenuItem.Name = "tabelaLokalaToolStripMenuItem";
            this.tabelaLokalaToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.tabelaLokalaToolStripMenuItem.Text = "Novi tip";
            this.tabelaLokalaToolStripMenuItem.Click += new System.EventHandler(this.tabelaLokalaToolStripMenuItem_Click);
            // 
            // novaEtiketaToolStripMenuItem
            // 
            this.novaEtiketaToolStripMenuItem.Name = "novaEtiketaToolStripMenuItem";
            this.novaEtiketaToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.novaEtiketaToolStripMenuItem.Text = "Nova etiketa";
            this.novaEtiketaToolStripMenuItem.Click += new System.EventHandler(this.novaEtiketaToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabelaLokalaToolStripMenuItem1,
            this.tabelaTipovaToolStripMenuItem,
            this.tabelaEtiketaToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.helpToolStripMenuItem.Text = "Prikaži";
            // 
            // tabelaLokalaToolStripMenuItem1
            // 
            this.tabelaLokalaToolStripMenuItem1.Name = "tabelaLokalaToolStripMenuItem1";
            this.tabelaLokalaToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.tabelaLokalaToolStripMenuItem1.Text = "Tabela lokala";
            this.tabelaLokalaToolStripMenuItem1.Click += new System.EventHandler(this.tabelaLokalaToolStripMenuItem1_Click);
            // 
            // tabelaTipovaToolStripMenuItem
            // 
            this.tabelaTipovaToolStripMenuItem.Name = "tabelaTipovaToolStripMenuItem";
            this.tabelaTipovaToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.tabelaTipovaToolStripMenuItem.Text = "Tabela tipova";
            this.tabelaTipovaToolStripMenuItem.Click += new System.EventHandler(this.tabelaTipovaToolStripMenuItem_Click);
            // 
            // tabelaEtiketaToolStripMenuItem
            // 
            this.tabelaEtiketaToolStripMenuItem.Name = "tabelaEtiketaToolStripMenuItem";
            this.tabelaEtiketaToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.tabelaEtiketaToolStripMenuItem.Text = "Tabela etiketa";
            this.tabelaEtiketaToolStripMenuItem.Click += new System.EventHandler(this.tabelaEtiketaToolStripMenuItem_Click);
            // 
            // pomoćToolStripMenuItem
            // 
            this.pomoćToolStripMenuItem.Name = "pomoćToolStripMenuItem";
            this.pomoćToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomoćToolStripMenuItem.Text = "Pomoć";
            // 
            // drvo
            // 
            this.drvo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drvo.Location = new System.Drawing.Point(487, 30);
            this.drvo.Name = "drvo";
            this.drvo.ShowRootLines = false;
            this.drvo.Size = new System.Drawing.Size(148, 399);
            this.drvo.TabIndex = 4;
            this.drvo.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.drvo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.drvo_MouseDoubleClick);
            this.drvo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drvo_MouseDown);
            this.drvo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drvo_MouseMove);
            // 
            // mapaPanel
            // 
            this.mapaPanel.AllowDrop = true;
            this.mapaPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mapaPanel.BackgroundImage")));
            this.mapaPanel.Location = new System.Drawing.Point(0, 27);
            this.mapaPanel.Name = "mapaPanel";
            this.mapaPanel.Size = new System.Drawing.Size(471, 402);
            this.mapaPanel.TabIndex = 5;
            this.mapaPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.mapaPanel_DragDrop);
            this.mapaPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.mapaPanel_DragEnter);
            this.mapaPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapaPanel_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 455);
            this.Controls.Add(this.mapaPanel);
            this.Controls.Add(this.drvo);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Evidencija lokala";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lokaliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviLokalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabelaLokalaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TreeView drvo;
        private System.Windows.Forms.ToolStripMenuItem pomoćToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaEtiketaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabelaLokalaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tabelaTipovaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabelaEtiketaToolStripMenuItem;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Panel mapaPanel;
    }
}

