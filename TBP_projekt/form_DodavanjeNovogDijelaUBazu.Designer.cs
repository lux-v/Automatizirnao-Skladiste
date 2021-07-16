
namespace TBP_projekt
{
    partial class form_DodavanjeNovogDijelaUBazu
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
            this.btn_dodajNoviDioUBazu = new System.Windows.Forms.Button();
            this.grpBox_pojedinacnoFiltriranje = new System.Windows.Forms.GroupBox();
            this.txtCijena = new System.Windows.Forms.TextBox();
            this.txtNarucenaKolicina = new System.Windows.Forms.TextBox();
            this.txtVrsta = new System.Windows.Forms.TextBox();
            this.txtMarkaAutomobila = new System.Windows.Forms.TextBox();
            this.txtMinimalnaKolicina = new System.Windows.Forms.TextBox();
            this.txtProizvodac = new System.Windows.Forms.TextBox();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.lblCijena = new System.Windows.Forms.Label();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.lblMinimalnaKolicina = new System.Windows.Forms.Label();
            this.lblNarucenaKolicina = new System.Windows.Forms.Label();
            this.lbl_vrsta = new System.Windows.Forms.Label();
            this.lbl_markaAutomobila = new System.Windows.Forms.Label();
            this.lbl_proizvodac = new System.Windows.Forms.Label();
            this.grpBox_pojedinacnoFiltriranje.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_dodajNoviDioUBazu
            // 
            this.btn_dodajNoviDioUBazu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dodajNoviDioUBazu.Font = new System.Drawing.Font("Arial", 11.5F);
            this.btn_dodajNoviDioUBazu.Location = new System.Drawing.Point(390, 375);
            this.btn_dodajNoviDioUBazu.Name = "btn_dodajNoviDioUBazu";
            this.btn_dodajNoviDioUBazu.Size = new System.Drawing.Size(134, 51);
            this.btn_dodajNoviDioUBazu.TabIndex = 14;
            this.btn_dodajNoviDioUBazu.Text = "Dodaj novi dio u bazu";
            this.btn_dodajNoviDioUBazu.UseVisualStyleBackColor = true;
            this.btn_dodajNoviDioUBazu.Click += new System.EventHandler(this.btn_dodajNoviDioUBazu_Click);
            // 
            // grpBox_pojedinacnoFiltriranje
            // 
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.txtCijena);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.txtNarucenaKolicina);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.txtVrsta);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.txtMarkaAutomobila);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.txtMinimalnaKolicina);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.txtProizvodac);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.txtNaziv);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.lblCijena);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.lblNaziv);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.lblMinimalnaKolicina);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.lblNarucenaKolicina);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.lbl_vrsta);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.lbl_markaAutomobila);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.lbl_proizvodac);
            this.grpBox_pojedinacnoFiltriranje.Font = new System.Drawing.Font("Arial", 12F);
            this.grpBox_pojedinacnoFiltriranje.ForeColor = System.Drawing.Color.White;
            this.grpBox_pojedinacnoFiltriranje.Location = new System.Drawing.Point(12, 12);
            this.grpBox_pojedinacnoFiltriranje.Name = "grpBox_pojedinacnoFiltriranje";
            this.grpBox_pojedinacnoFiltriranje.Size = new System.Drawing.Size(372, 414);
            this.grpBox_pojedinacnoFiltriranje.TabIndex = 15;
            this.grpBox_pojedinacnoFiltriranje.TabStop = false;
            this.grpBox_pojedinacnoFiltriranje.Text = "Unesite sve potrebne stavke";
            // 
            // txtCijena
            // 
            this.txtCijena.Font = new System.Drawing.Font("Arial", 11.5F);
            this.txtCijena.Location = new System.Drawing.Point(149, 362);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(203, 25);
            this.txtCijena.TabIndex = 18;
            // 
            // txtNarucenaKolicina
            // 
            this.txtNarucenaKolicina.Font = new System.Drawing.Font("Arial", 11.5F);
            this.txtNarucenaKolicina.Location = new System.Drawing.Point(149, 307);
            this.txtNarucenaKolicina.Name = "txtNarucenaKolicina";
            this.txtNarucenaKolicina.Size = new System.Drawing.Size(203, 25);
            this.txtNarucenaKolicina.TabIndex = 17;
            // 
            // txtVrsta
            // 
            this.txtVrsta.Font = new System.Drawing.Font("Arial", 11.5F);
            this.txtVrsta.Location = new System.Drawing.Point(151, 100);
            this.txtVrsta.Name = "txtVrsta";
            this.txtVrsta.Size = new System.Drawing.Size(203, 25);
            this.txtVrsta.TabIndex = 13;
            // 
            // txtMarkaAutomobila
            // 
            this.txtMarkaAutomobila.Font = new System.Drawing.Font("Arial", 11.5F);
            this.txtMarkaAutomobila.Location = new System.Drawing.Point(149, 200);
            this.txtMarkaAutomobila.Name = "txtMarkaAutomobila";
            this.txtMarkaAutomobila.Size = new System.Drawing.Size(203, 25);
            this.txtMarkaAutomobila.TabIndex = 15;
            // 
            // txtMinimalnaKolicina
            // 
            this.txtMinimalnaKolicina.Font = new System.Drawing.Font("Arial", 11.5F);
            this.txtMinimalnaKolicina.Location = new System.Drawing.Point(151, 259);
            this.txtMinimalnaKolicina.Name = "txtMinimalnaKolicina";
            this.txtMinimalnaKolicina.Size = new System.Drawing.Size(203, 25);
            this.txtMinimalnaKolicina.TabIndex = 16;
            // 
            // txtProizvodac
            // 
            this.txtProizvodac.Font = new System.Drawing.Font("Arial", 11.5F);
            this.txtProizvodac.Location = new System.Drawing.Point(151, 151);
            this.txtProizvodac.Name = "txtProizvodac";
            this.txtProizvodac.Size = new System.Drawing.Size(203, 25);
            this.txtProizvodac.TabIndex = 14;
            // 
            // txtNaziv
            // 
            this.txtNaziv.Font = new System.Drawing.Font("Arial", 11.5F);
            this.txtNaziv.Location = new System.Drawing.Point(149, 52);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(203, 25);
            this.txtNaziv.TabIndex = 12;
            // 
            // lblCijena
            // 
            this.lblCijena.AutoSize = true;
            this.lblCijena.Font = new System.Drawing.Font("Arial", 11.5F);
            this.lblCijena.Location = new System.Drawing.Point(86, 362);
            this.lblCijena.Name = "lblCijena";
            this.lblCijena.Size = new System.Drawing.Size(53, 18);
            this.lblCijena.TabIndex = 11;
            this.lblCijena.Text = "Cijena";
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Font = new System.Drawing.Font("Arial", 11.5F);
            this.lblNaziv.Location = new System.Drawing.Point(95, 52);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(46, 18);
            this.lblNaziv.TabIndex = 8;
            this.lblNaziv.Text = "Naziv";
            // 
            // lblMinimalnaKolicina
            // 
            this.lblMinimalnaKolicina.AutoSize = true;
            this.lblMinimalnaKolicina.Font = new System.Drawing.Font("Arial", 11.5F);
            this.lblMinimalnaKolicina.Location = new System.Drawing.Point(3, 258);
            this.lblMinimalnaKolicina.Name = "lblMinimalnaKolicina";
            this.lblMinimalnaKolicina.Size = new System.Drawing.Size(136, 18);
            this.lblMinimalnaKolicina.TabIndex = 10;
            this.lblMinimalnaKolicina.Text = "Minimalna kolicina";
            // 
            // lblNarucenaKolicina
            // 
            this.lblNarucenaKolicina.AutoSize = true;
            this.lblNarucenaKolicina.Font = new System.Drawing.Font("Arial", 11.5F);
            this.lblNarucenaKolicina.Location = new System.Drawing.Point(7, 317);
            this.lblNarucenaKolicina.Name = "lblNarucenaKolicina";
            this.lblNarucenaKolicina.Size = new System.Drawing.Size(132, 18);
            this.lblNarucenaKolicina.TabIndex = 9;
            this.lblNarucenaKolicina.Text = "Naručena količina";
            // 
            // lbl_vrsta
            // 
            this.lbl_vrsta.AutoSize = true;
            this.lbl_vrsta.Font = new System.Drawing.Font("Arial", 11.5F);
            this.lbl_vrsta.Location = new System.Drawing.Point(95, 100);
            this.lbl_vrsta.Name = "lbl_vrsta";
            this.lbl_vrsta.Size = new System.Drawing.Size(44, 18);
            this.lbl_vrsta.TabIndex = 2;
            this.lbl_vrsta.Text = "Vrsta";
            // 
            // lbl_markaAutomobila
            // 
            this.lbl_markaAutomobila.AutoSize = true;
            this.lbl_markaAutomobila.Font = new System.Drawing.Font("Arial", 11.5F);
            this.lbl_markaAutomobila.Location = new System.Drawing.Point(8, 203);
            this.lbl_markaAutomobila.Name = "lbl_markaAutomobila";
            this.lbl_markaAutomobila.Size = new System.Drawing.Size(133, 18);
            this.lbl_markaAutomobila.TabIndex = 4;
            this.lbl_markaAutomobila.Text = "Marka automobila";
            // 
            // lbl_proizvodac
            // 
            this.lbl_proizvodac.AutoSize = true;
            this.lbl_proizvodac.Font = new System.Drawing.Font("Arial", 11.5F);
            this.lbl_proizvodac.Location = new System.Drawing.Point(55, 148);
            this.lbl_proizvodac.Name = "lbl_proizvodac";
            this.lbl_proizvodac.Size = new System.Drawing.Size(86, 18);
            this.lbl_proizvodac.TabIndex = 3;
            this.lbl_proizvodac.Text = "Proizvođač";
            // 
            // form_DodavanjeNovogDijelaUBazu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(534, 442);
            this.Controls.Add(this.grpBox_pojedinacnoFiltriranje);
            this.Controls.Add(this.btn_dodajNoviDioUBazu);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "form_DodavanjeNovogDijelaUBazu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodaj novi automobil";
            this.grpBox_pojedinacnoFiltriranje.ResumeLayout(false);
            this.grpBox_pojedinacnoFiltriranje.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_dodajNoviDioUBazu;
        private System.Windows.Forms.GroupBox grpBox_pojedinacnoFiltriranje;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.Label lblMinimalnaKolicina;
        private System.Windows.Forms.Label lblNarucenaKolicina;
        private System.Windows.Forms.Label lbl_vrsta;
        private System.Windows.Forms.Label lbl_markaAutomobila;
        private System.Windows.Forms.Label lbl_proizvodac;
        private System.Windows.Forms.TextBox txtMarkaAutomobila;
        private System.Windows.Forms.TextBox txtProizvodac;
        private System.Windows.Forms.TextBox txtVrsta;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label lblCijena;
        private System.Windows.Forms.TextBox txtMinimalnaKolicina;
        private System.Windows.Forms.TextBox txtCijena;
        private System.Windows.Forms.TextBox txtNarucenaKolicina;
    }
}