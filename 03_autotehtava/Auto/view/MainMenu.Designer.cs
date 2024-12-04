using System;
namespace Autokauppa.view
{
    partial class MainMenu
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
          
            this.btnUusitietue = new System.Windows.Forms.Button();
            this.btnTallenna = new System.Windows.Forms.Button();
            this.btnPoista = new System.Windows.Forms.Button();
            this.btnSeuraava = new System.Windows.Forms.Button();
            this.gbAuto = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPolttoaine = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbVari = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMalli = new System.Windows.Forms.ComboBox();
            this.dgvCars = new System.Windows.Forms.DataGridView();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.btnSearchByBrand = new System.Windows.Forms.Button();
            this.btnSearchByPrice = new System.Windows.Forms.Button();
            this.dtpPaiva = new System.Windows.Forms.DateTimePicker();
            this.tbMittarilukema = new System.Windows.Forms.TextBox();
            this.tbTilavuus = new System.Windows.Forms.TextBox();
            this.tbHinta = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMerkki = new System.Windows.Forms.ComboBox();
            this.btnEdellinen = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.testaaTietokantaaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLisaa = new System.Windows.Forms.Button();
            this.gbAuto.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            // 
            // btnSeuraava
            // 
            this.btnSeuraava.Location = new System.Drawing.Point(520, 360);
            this.btnSeuraava.Name = "btnSeuraava";
            this.btnSeuraava.Size = new System.Drawing.Size(89, 33);
            this.btnSeuraava.TabIndex = 17;
            this.btnSeuraava.Text = "Seuraava";
            this.btnSeuraava.UseVisualStyleBackColor = true;
            this.btnSeuraava.Click += new System.EventHandler(this.btnSeuraava_Click);
            // 
            // gbAuto
            // 
            this.gbAuto.Controls.Add(this.label4);
            this.gbAuto.Controls.Add(this.cbPolttoaine);
            this.gbAuto.Controls.Add(this.label3);
            this.gbAuto.Controls.Add(this.cbVari);
            this.gbAuto.Controls.Add(this.label2);
            this.gbAuto.Controls.Add(this.cbMalli);
            this.gbAuto.Controls.Add(this.dtpPaiva);
            this.gbAuto.Controls.Add(this.tbMittarilukema);
            this.gbAuto.Controls.Add(this.tbTilavuus);
            this.gbAuto.Controls.Add(this.tbHinta);
            this.gbAuto.Controls.Add(this.tbId);
            this.gbAuto.Controls.Add(this.label1);
            this.gbAuto.Controls.Add(this.cbMerkki);
            this.gbAuto.Location = new System.Drawing.Point(20, 40);
            this.gbAuto.Name = "gbAuto";
            this.gbAuto.Size = new System.Drawing.Size(350, 300);
            this.gbAuto.TabIndex = 18;
            this.gbAuto.TabStop = false;
            this.gbAuto.Text = "Auton tiedot";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Polttoaine";
            // 
            // cbPolttoaine
            // 
            this.cbPolttoaine.FormattingEnabled = true;
            this.cbPolttoaine.Location = new System.Drawing.Point(183, 213);
            this.cbPolttoaine.Name = "cbPolttoaine";
            this.cbPolttoaine.Size = new System.Drawing.Size(121, 24);
            this.cbPolttoaine.TabIndex = 28;
            cbMerkki.SelectedIndexChanged += new EventHandler(cbPolttoaine_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Väri";
            // 
            // cbVari
            // 
            this.cbVari.FormattingEnabled = true;
            this.cbVari.Location = new System.Drawing.Point(183, 156);
            this.cbVari.Name = "cbVari";
            this.cbVari.Size = new System.Drawing.Size(121, 24);
            this.cbVari.TabIndex = 26;
            cbMerkki.SelectedIndexChanged += new EventHandler(cbVari_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Malli";
            // 
            // cbMalli
            // 
            this.cbMalli.FormattingEnabled = true;
            this.cbMalli.Location = new System.Drawing.Point(183, 102);
            this.cbMalli.Name = "cbMalli";
            this.cbMalli.Size = new System.Drawing.Size(121, 24);
            this.cbMalli.TabIndex = 24;
            // 
            // dtpPaiva
            // 
            this.dtpPaiva.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPaiva.Location = new System.Drawing.Point(17, 128);
            this.dtpPaiva.Name = "dtpPaiva";
            this.dtpPaiva.Size = new System.Drawing.Size(116, 22);
            this.dtpPaiva.TabIndex = 23;
            // 
            // tbMittarilukema
            // 
            this.tbMittarilukema.Location = new System.Drawing.Point(17, 170);
            this.tbMittarilukema.Name = "tbMittarilukema";
            this.tbMittarilukema.Size = new System.Drawing.Size(116, 22);
            this.tbMittarilukema.TabIndex = 22;
            // 
            // tbTilavuus
            // 
            this.tbTilavuus.Location = new System.Drawing.Point(17, 210);
            this.tbTilavuus.Name = "tbTilavuus";
            this.tbTilavuus.Size = new System.Drawing.Size(116, 22);
            this.tbTilavuus.TabIndex = 21;
            // 
            // tbHinta
            // 
            this.tbHinta.Location = new System.Drawing.Point(17, 80);
            this.tbHinta.Name = "tbHinta";
            this.tbHinta.Size = new System.Drawing.Size(116, 22);
            this.tbHinta.TabIndex = 20;
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(17, 40);
            this.tbId.Name = "tbId";
            this.tbId.ReadOnly = true;
            this.tbId.Size = new System.Drawing.Size(116, 22);
            this.tbId.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Automerkki";
            // 
            // cbMerkki
            // 
            this.cbMerkki.FormattingEnabled = true;
            this.cbMerkki.Location = new System.Drawing.Point(181, 52);
            this.cbMerkki.Name = "cbMerkki";
            this.cbMerkki.Size = new System.Drawing.Size(121, 24);
            this.cbMerkki.TabIndex = 17;
            cbMerkki.SelectedIndexChanged += new EventHandler(cbMerkki_SelectedIndexChanged);
            // 
            // btnEdellinen
            // 
            this.btnEdellinen.Location = new System.Drawing.Point(20, 360);
            this.btnEdellinen.Name = "btnEdellinen";
            this.btnEdellinen.Size = new System.Drawing.Size(93, 33);
            this.btnEdellinen.TabIndex = 19;
            this.btnEdellinen.Text = "Edellinen";
            this.btnEdellinen.UseVisualStyleBackColor = true;
            this.btnEdellinen.Click += new System.EventHandler(this.btnEdellinen_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(652, 28);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.exitToolStripMenuItem.Text = "Tiedosto";

            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testaaTietokantaaToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.aboutToolStripMenuItem.Text = "Muuta...";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem1.Text = "Poistu";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // testaaTietokantaaToolStripMenuItem
            // 
            this.testaaTietokantaaToolStripMenuItem.Name = "testaaTietokantaaToolStripMenuItem";
            this.testaaTietokantaaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.testaaTietokantaaToolStripMenuItem.Text = "Testaa tietokantaa";
            this.testaaTietokantaaToolStripMenuItem.Click += new System.EventHandler(this.testaaTietokantaaToolStripMenuItem_Click);
            // 
            // btnLisaa
            // 
            this.btnLisaa.Location = new System.Drawing.Point(120, 360);
            this.btnLisaa.Name = "btnLisaa";
            this.btnLisaa.Size = new System.Drawing.Size(89, 33);
            this.btnLisaa.TabIndex = 21;
            this.btnLisaa.Text = "Lisää";
            this.btnLisaa.UseVisualStyleBackColor = true;
            this.btnLisaa.Click += new System.EventHandler(this.btnLisaa_Click);
            ///
            /// btnUusitietue
            ///
            this.btnUusitietue = new System.Windows.Forms.Button();
            this.btnUusitietue.Location = new System.Drawing.Point(220, 360);
            this.btnUusitietue.Name = "btnUusitietue";
            this.btnUusitietue.Size = new System.Drawing.Size(89, 33);
            this.btnUusitietue.Text = "Uusitietue";
            this.btnUusitietue.UseVisualStyleBackColor = true;
            this.btnUusitietue.Click += new System.EventHandler(this.btnUusitietue_Click);
            this.Controls.Add(this.btnUusitietue);
            ///
            /// btnTallenna
            ///
            this.btnTallenna = new System.Windows.Forms.Button();
            this.btnTallenna.Location = new System.Drawing.Point(320, 360);
            this.btnTallenna.Name = "btnTallenna";
            this.btnTallenna.Size = new System.Drawing.Size(89, 33);
            this.btnTallenna.Text = "Tallenna";
            this.btnTallenna.UseVisualStyleBackColor = true;
            this.btnTallenna.Click += new System.EventHandler(this.btnTallenna_Click);
            this.Controls.Add(this.btnTallenna);
            // 
            // btnPoista
            // 
            this.btnPoista.Location = new System.Drawing.Point(420, 360);
            this.btnPoista.Name = "btnPoista";
            this.btnPoista.Size = new System.Drawing.Size(89, 33);
            this.btnPoista.TabIndex = 2;
            this.btnPoista.Text = "Poista";
            this.btnPoista.UseVisualStyleBackColor = true;
            this.btnPoista.Click += new System.EventHandler(this.btnPoista_Click);
            // 
            // dgvCars
            // 
            this.dgvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCars.Location = new System.Drawing.Point(400, 40);
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.RowTemplate.Height = 24;
            this.dgvCars.Size = new System.Drawing.Size(450, 300);
            this.dgvCars.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(620, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Search Merkki:";
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(720, 365);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(150, 25);
            this.txtBrand.TabIndex = 12;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(620, 400);  
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(78, 17);
            this.labelPrice.TabIndex = 16;  
            this.labelPrice.Text = "Enter Hinta:";
            // 
            // txtPrice
            // 
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtPrice.Location = new System.Drawing.Point(720, 395);  
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(150, 25);
            this.txtPrice.TabIndex = 15;
            // 
            // btnSearchByBrand
            // 
            this.btnSearchByBrand.Location = new System.Drawing.Point(450, 400);
            this.btnSearchByBrand.Name = "btnSearchByBrand";
            this.btnSearchByBrand.Size = new System.Drawing.Size(100, 40);
            this.btnSearchByBrand.TabIndex = 13;
            this.btnSearchByBrand.Text = "Search by Brand";
            this.btnSearchByBrand.UseVisualStyleBackColor = true;
            this.btnSearchByBrand.Click += new System.EventHandler(this.btnSearchByBrand_Click);

            // 
            // btnSearchByPrice
            // 
            this.btnSearchByPrice.Location = new System.Drawing.Point(330, 400);
            this.btnSearchByPrice.Name = "btnSearchByPrice";
            this.btnSearchByPrice.Size = new System.Drawing.Size(100, 40);
            this.btnSearchByPrice.TabIndex = 14;
            this.btnSearchByPrice.Text = "Search by Price";
            this.btnSearchByPrice.UseVisualStyleBackColor = true;
            this.btnSearchByPrice.Click += new System.EventHandler(this.btnSearchByPrice_Click);

            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.btnLisaa);
            this.Controls.Add(this.btnEdellinen);
            this.Controls.Add(this.gbAuto);
            this.Controls.Add(this.btnSeuraava);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnPoista);
            this.Controls.Add(this.btnUusitietue);
            this.Controls.Add(this.btnSearchByPrice);
            this.Controls.Add(this.btnSearchByBrand);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.dgvCars);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainMenu";
            this.Text = "MainMenu";

            this.gbAuto.ResumeLayout(false);
            this.gbAuto.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Button btnSeuraava;
        private System.Windows.Forms.GroupBox gbAuto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPolttoaine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbVari;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMalli;
        private System.Windows.Forms.DateTimePicker dtpPaiva;
        private System.Windows.Forms.TextBox tbMittarilukema;
        private System.Windows.Forms.TextBox tbTilavuus;
        private System.Windows.Forms.TextBox tbHinta;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMerkki;
        private System.Windows.Forms.Button btnEdellinen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testaaTietokantaaToolStripMenuItem;
        private System.Windows.Forms.Button btnLisaa;
        private System.Windows.Forms.Button btnUusitietue;
        private System.Windows.Forms.Button btnTallenna;
        private System.Windows.Forms.Button btnPoista;
        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnSearchByBrand;
        private System.Windows.Forms.Button btnSearchByPrice;
    }
}