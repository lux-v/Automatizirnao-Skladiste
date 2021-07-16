
namespace TBP_projekt
{
    partial class Autodijelovi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Autodijelovi = new System.Windows.Forms.DataGridView();
            this.lbl_prikazAutodijelova = new System.Windows.Forms.Label();
            this.lbl_vrsta = new System.Windows.Forms.Label();
            this.lbl_proizvodac = new System.Windows.Forms.Label();
            this.lbl_markaAutomobila = new System.Windows.Forms.Label();
            this.cmb_vrstaProizvoda = new System.Windows.Forms.ComboBox();
            this.cmb_proizvodac = new System.Windows.Forms.ComboBox();
            this.cmb_markaAutomobila = new System.Windows.Forms.ComboBox();
            this.txt_nazivProizvoda = new System.Windows.Forms.TextBox();
            this.lbl_nazivProizvoda = new System.Windows.Forms.Label();
            this.grpBox_pojedinacnoFiltriranje = new System.Windows.Forms.GroupBox();
            this.btn_primjeniSveFiltere = new System.Windows.Forms.Button();
            this.btn_obrisiSveFiltere = new System.Windows.Forms.Button();
            this.btn_dodajNoviDioUBazu = new System.Windows.Forms.Button();
            this.btnUProdaji = new System.Windows.Forms.Button();
            this.btnNijeUProdaji = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Autodijelovi)).BeginInit();
            this.grpBox_pojedinacnoFiltriranje.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Autodijelovi
            // 
            this.dgv_Autodijelovi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.dgv_Autodijelovi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Autodijelovi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Autodijelovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Autodijelovi.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Autodijelovi.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_Autodijelovi.Location = new System.Drawing.Point(11, 35);
            this.dgv_Autodijelovi.Name = "dgv_Autodijelovi";
            this.dgv_Autodijelovi.Size = new System.Drawing.Size(1162, 213);
            this.dgv_Autodijelovi.TabIndex = 0;
            this.dgv_Autodijelovi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Autodijelovi_CellContentClick);
            this.dgv_Autodijelovi.SelectionChanged += new System.EventHandler(this.dgv_Autodijelovi_SelectionChanged);
            // 
            // lbl_prikazAutodijelova
            // 
            this.lbl_prikazAutodijelova.AutoSize = true;
            this.lbl_prikazAutodijelova.Font = new System.Drawing.Font("Arial", 15F);
            this.lbl_prikazAutodijelova.ForeColor = System.Drawing.Color.White;
            this.lbl_prikazAutodijelova.Location = new System.Drawing.Point(-2, 7);
            this.lbl_prikazAutodijelova.Name = "lbl_prikazAutodijelova";
            this.lbl_prikazAutodijelova.Size = new System.Drawing.Size(179, 23);
            this.lbl_prikazAutodijelova.TabIndex = 1;
            this.lbl_prikazAutodijelova.Text = "Prikaz autodijelova:";
            // 
            // lbl_vrsta
            // 
            this.lbl_vrsta.AutoSize = true;
            this.lbl_vrsta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.lbl_vrsta.ForeColor = System.Drawing.Color.White;
            this.lbl_vrsta.Location = new System.Drawing.Point(106, 31);
            this.lbl_vrsta.Name = "lbl_vrsta";
            this.lbl_vrsta.Size = new System.Drawing.Size(47, 20);
            this.lbl_vrsta.TabIndex = 2;
            this.lbl_vrsta.Text = "Vrsta";
            // 
            // lbl_proizvodac
            // 
            this.lbl_proizvodac.AutoSize = true;
            this.lbl_proizvodac.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.lbl_proizvodac.ForeColor = System.Drawing.Color.White;
            this.lbl_proizvodac.Location = new System.Drawing.Point(64, 80);
            this.lbl_proizvodac.Name = "lbl_proizvodac";
            this.lbl_proizvodac.Size = new System.Drawing.Size(86, 20);
            this.lbl_proizvodac.TabIndex = 3;
            this.lbl_proizvodac.Text = "Proizvođač";
            // 
            // lbl_markaAutomobila
            // 
            this.lbl_markaAutomobila.AutoSize = true;
            this.lbl_markaAutomobila.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.lbl_markaAutomobila.ForeColor = System.Drawing.Color.White;
            this.lbl_markaAutomobila.Location = new System.Drawing.Point(17, 131);
            this.lbl_markaAutomobila.Name = "lbl_markaAutomobila";
            this.lbl_markaAutomobila.Size = new System.Drawing.Size(135, 20);
            this.lbl_markaAutomobila.TabIndex = 4;
            this.lbl_markaAutomobila.Text = "Marka automobila";
            // 
            // cmb_vrstaProizvoda
            // 
            this.cmb_vrstaProizvoda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.cmb_vrstaProizvoda.Font = new System.Drawing.Font("Arial", 11.5F);
            this.cmb_vrstaProizvoda.ForeColor = System.Drawing.Color.White;
            this.cmb_vrstaProizvoda.FormattingEnabled = true;
            this.cmb_vrstaProizvoda.Location = new System.Drawing.Point(158, 28);
            this.cmb_vrstaProizvoda.Name = "cmb_vrstaProizvoda";
            this.cmb_vrstaProizvoda.Size = new System.Drawing.Size(203, 25);
            this.cmb_vrstaProizvoda.TabIndex = 5;
            this.cmb_vrstaProizvoda.SelectedIndexChanged += new System.EventHandler(this.cmb_vrstaProizvoda_SelectedIndexChanged);
            // 
            // cmb_proizvodac
            // 
            this.cmb_proizvodac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.cmb_proizvodac.Font = new System.Drawing.Font("Arial", 11.5F);
            this.cmb_proizvodac.ForeColor = System.Drawing.Color.White;
            this.cmb_proizvodac.FormattingEnabled = true;
            this.cmb_proizvodac.Location = new System.Drawing.Point(158, 80);
            this.cmb_proizvodac.Name = "cmb_proizvodac";
            this.cmb_proizvodac.Size = new System.Drawing.Size(203, 25);
            this.cmb_proizvodac.TabIndex = 6;
            this.cmb_proizvodac.SelectedIndexChanged += new System.EventHandler(this.cmb_proizvodac_SelectedIndexChanged);
            // 
            // cmb_markaAutomobila
            // 
            this.cmb_markaAutomobila.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.cmb_markaAutomobila.Font = new System.Drawing.Font("Arial", 11.5F);
            this.cmb_markaAutomobila.ForeColor = System.Drawing.Color.White;
            this.cmb_markaAutomobila.FormattingEnabled = true;
            this.cmb_markaAutomobila.Location = new System.Drawing.Point(156, 131);
            this.cmb_markaAutomobila.Name = "cmb_markaAutomobila";
            this.cmb_markaAutomobila.Size = new System.Drawing.Size(205, 25);
            this.cmb_markaAutomobila.TabIndex = 7;
            this.cmb_markaAutomobila.SelectedIndexChanged += new System.EventHandler(this.cmb_markaAutomobila_SelectedIndexChanged);
            // 
            // txt_nazivProizvoda
            // 
            this.txt_nazivProizvoda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.txt_nazivProizvoda.Font = new System.Drawing.Font("Arial", 11.5F);
            this.txt_nazivProizvoda.ForeColor = System.Drawing.Color.White;
            this.txt_nazivProizvoda.Location = new System.Drawing.Point(180, 267);
            this.txt_nazivProizvoda.Name = "txt_nazivProizvoda";
            this.txt_nazivProizvoda.Size = new System.Drawing.Size(201, 25);
            this.txt_nazivProizvoda.TabIndex = 8;
            this.txt_nazivProizvoda.TextChanged += new System.EventHandler(this.txt_nazivProizvoda_TextChanged);
            // 
            // lbl_nazivProizvoda
            // 
            this.lbl_nazivProizvoda.AutoSize = true;
            this.lbl_nazivProizvoda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.lbl_nazivProizvoda.ForeColor = System.Drawing.Color.White;
            this.lbl_nazivProizvoda.Location = new System.Drawing.Point(46, 270);
            this.lbl_nazivProizvoda.Name = "lbl_nazivProizvoda";
            this.lbl_nazivProizvoda.Size = new System.Drawing.Size(119, 20);
            this.lbl_nazivProizvoda.TabIndex = 9;
            this.lbl_nazivProizvoda.Text = "Naziv proizvoda";
            // 
            // grpBox_pojedinacnoFiltriranje
            // 
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.lbl_vrsta);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.cmb_vrstaProizvoda);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.cmb_proizvodac);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.cmb_markaAutomobila);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.lbl_markaAutomobila);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.lbl_proizvodac);
            this.grpBox_pojedinacnoFiltriranje.Font = new System.Drawing.Font("Arial", 12F);
            this.grpBox_pojedinacnoFiltriranje.ForeColor = System.Drawing.Color.White;
            this.grpBox_pojedinacnoFiltriranje.Location = new System.Drawing.Point(14, 321);
            this.grpBox_pojedinacnoFiltriranje.Name = "grpBox_pojedinacnoFiltriranje";
            this.grpBox_pojedinacnoFiltriranje.Size = new System.Drawing.Size(367, 184);
            this.grpBox_pojedinacnoFiltriranje.TabIndex = 10;
            this.grpBox_pojedinacnoFiltriranje.TabStop = false;
            this.grpBox_pojedinacnoFiltriranje.Text = "Pojedinačno filtriranje";
            // 
            // btn_primjeniSveFiltere
            // 
            this.btn_primjeniSveFiltere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_primjeniSveFiltere.Font = new System.Drawing.Font("Arial", 11.5F, System.Drawing.FontStyle.Bold);
            this.btn_primjeniSveFiltere.ForeColor = System.Drawing.Color.White;
            this.btn_primjeniSveFiltere.Location = new System.Drawing.Point(407, 454);
            this.btn_primjeniSveFiltere.Name = "btn_primjeniSveFiltere";
            this.btn_primjeniSveFiltere.Size = new System.Drawing.Size(134, 51);
            this.btn_primjeniSveFiltere.TabIndex = 11;
            this.btn_primjeniSveFiltere.Text = "Primjeni sve odabrane filtere";
            this.btn_primjeniSveFiltere.UseVisualStyleBackColor = true;
            this.btn_primjeniSveFiltere.Click += new System.EventHandler(this.btn_primjeniSveFiltere_Click);
            // 
            // btn_obrisiSveFiltere
            // 
            this.btn_obrisiSveFiltere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_obrisiSveFiltere.Font = new System.Drawing.Font("Arial", 11.5F, System.Drawing.FontStyle.Bold);
            this.btn_obrisiSveFiltere.ForeColor = System.Drawing.Color.White;
            this.btn_obrisiSveFiltere.Location = new System.Drawing.Point(407, 335);
            this.btn_obrisiSveFiltere.Name = "btn_obrisiSveFiltere";
            this.btn_obrisiSveFiltere.Size = new System.Drawing.Size(134, 51);
            this.btn_obrisiSveFiltere.TabIndex = 12;
            this.btn_obrisiSveFiltere.Text = "Resetiraj filtere";
            this.btn_obrisiSveFiltere.UseVisualStyleBackColor = true;
            this.btn_obrisiSveFiltere.Click += new System.EventHandler(this.btn_obrisiSveFiltere_Click);
            // 
            // btn_dodajNoviDioUBazu
            // 
            this.btn_dodajNoviDioUBazu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dodajNoviDioUBazu.Font = new System.Drawing.Font("Arial", 11.5F, System.Drawing.FontStyle.Bold);
            this.btn_dodajNoviDioUBazu.ForeColor = System.Drawing.Color.White;
            this.btn_dodajNoviDioUBazu.Location = new System.Drawing.Point(1039, 454);
            this.btn_dodajNoviDioUBazu.Name = "btn_dodajNoviDioUBazu";
            this.btn_dodajNoviDioUBazu.Size = new System.Drawing.Size(134, 51);
            this.btn_dodajNoviDioUBazu.TabIndex = 13;
            this.btn_dodajNoviDioUBazu.Text = "Dodaj novi dio u bazu";
            this.btn_dodajNoviDioUBazu.UseVisualStyleBackColor = true;
            this.btn_dodajNoviDioUBazu.Click += new System.EventHandler(this.btn_dodajNoviDioUBazu_Click);
            // 
            // btnUProdaji
            // 
            this.btnUProdaji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUProdaji.Font = new System.Drawing.Font("Arial", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnUProdaji.ForeColor = System.Drawing.Color.White;
            this.btnUProdaji.Location = new System.Drawing.Point(6, 19);
            this.btnUProdaji.Name = "btnUProdaji";
            this.btnUProdaji.Size = new System.Drawing.Size(134, 51);
            this.btnUProdaji.TabIndex = 14;
            this.btnUProdaji.Text = "Proizvod je u prodaji";
            this.btnUProdaji.UseVisualStyleBackColor = true;
            this.btnUProdaji.Click += new System.EventHandler(this.btnUProdaji_Click);
            // 
            // btnNijeUProdaji
            // 
            this.btnNijeUProdaji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNijeUProdaji.Font = new System.Drawing.Font("Arial", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnNijeUProdaji.ForeColor = System.Drawing.Color.White;
            this.btnNijeUProdaji.Location = new System.Drawing.Point(195, 19);
            this.btnNijeUProdaji.Name = "btnNijeUProdaji";
            this.btnNijeUProdaji.Size = new System.Drawing.Size(134, 51);
            this.btnNijeUProdaji.TabIndex = 15;
            this.btnNijeUProdaji.Text = "Proizvod nije u prodaji";
            this.btnNijeUProdaji.UseVisualStyleBackColor = true;
            this.btnNijeUProdaji.Click += new System.EventHandler(this.btnNijeUProdaji_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUProdaji);
            this.groupBox1.Controls.Add(this.btnNijeUProdaji);
            this.groupBox1.Location = new System.Drawing.Point(844, 256);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 88);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // Autodijelovi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(1192, 538);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_dodajNoviDioUBazu);
            this.Controls.Add(this.btn_obrisiSveFiltere);
            this.Controls.Add(this.btn_primjeniSveFiltere);
            this.Controls.Add(this.grpBox_pojedinacnoFiltriranje);
            this.Controls.Add(this.lbl_nazivProizvoda);
            this.Controls.Add(this.txt_nazivProizvoda);
            this.Controls.Add(this.lbl_prikazAutodijelova);
            this.Controls.Add(this.dgv_Autodijelovi);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Autodijelovi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autodijelovi";
            this.Load += new System.EventHandler(this.form_Autodijelovi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Autodijelovi)).EndInit();
            this.grpBox_pojedinacnoFiltriranje.ResumeLayout(false);
            this.grpBox_pojedinacnoFiltriranje.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Autodijelovi;
        private System.Windows.Forms.Label lbl_prikazAutodijelova;
        private System.Windows.Forms.Label lbl_vrsta;
        private System.Windows.Forms.Label lbl_proizvodac;
        private System.Windows.Forms.Label lbl_markaAutomobila;
        private System.Windows.Forms.ComboBox cmb_vrstaProizvoda;
        private System.Windows.Forms.ComboBox cmb_proizvodac;
        private System.Windows.Forms.ComboBox cmb_markaAutomobila;
        private System.Windows.Forms.TextBox txt_nazivProizvoda;
        private System.Windows.Forms.Label lbl_nazivProizvoda;
        private System.Windows.Forms.GroupBox grpBox_pojedinacnoFiltriranje;
        private System.Windows.Forms.Button btn_primjeniSveFiltere;
        private System.Windows.Forms.Button btn_obrisiSveFiltere;
        private System.Windows.Forms.Button btn_dodajNoviDioUBazu;
        private System.Windows.Forms.Button btnUProdaji;
        private System.Windows.Forms.Button btnNijeUProdaji;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}