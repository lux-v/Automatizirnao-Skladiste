
namespace TBP_projekt
{
    partial class form_TrenutnoStanjeSkladista
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_TrenutnoStanjeSkladista = new System.Windows.Forms.DataGridView();
            this.lbl_TrenutnoStanjeSkladista = new System.Windows.Forms.Label();
            this.btn_dodajNoviDioUBazu = new System.Windows.Forms.Button();
            this.btnAzuriraj = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.grpBox_pojedinacnoFiltriranje = new System.Windows.Forms.GroupBox();
            this.cmbProizvodID = new System.Windows.Forms.ComboBox();
            this.txtProiztvodId = new System.Windows.Forms.TextBox();
            this.lbl_vrsta = new System.Windows.Forms.Label();
            this.cmbRed = new System.Windows.Forms.ComboBox();
            this.cmbDio = new System.Windows.Forms.ComboBox();
            this.lbl_markaAutomobila = new System.Windows.Forms.Label();
            this.lbl_proizvodac = new System.Windows.Forms.Label();
            this.txtKolicina = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TrenutnoStanjeSkladista)).BeginInit();
            this.grpBox_pojedinacnoFiltriranje.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_TrenutnoStanjeSkladista
            // 
            this.dgv_TrenutnoStanjeSkladista.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.dgv_TrenutnoStanjeSkladista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_TrenutnoStanjeSkladista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_TrenutnoStanjeSkladista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_TrenutnoStanjeSkladista.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_TrenutnoStanjeSkladista.Location = new System.Drawing.Point(11, 35);
            this.dgv_TrenutnoStanjeSkladista.Name = "dgv_TrenutnoStanjeSkladista";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_TrenutnoStanjeSkladista.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_TrenutnoStanjeSkladista.Size = new System.Drawing.Size(739, 213);
            this.dgv_TrenutnoStanjeSkladista.TabIndex = 0;
            this.dgv_TrenutnoStanjeSkladista.SelectionChanged += new System.EventHandler(this.dgv_TrenutnoStanjeSkladista_SelectionChanged);
            // 
            // lbl_TrenutnoStanjeSkladista
            // 
            this.lbl_TrenutnoStanjeSkladista.AutoSize = true;
            this.lbl_TrenutnoStanjeSkladista.Font = new System.Drawing.Font("Arial", 15F);
            this.lbl_TrenutnoStanjeSkladista.ForeColor = System.Drawing.Color.White;
            this.lbl_TrenutnoStanjeSkladista.Location = new System.Drawing.Point(12, 9);
            this.lbl_TrenutnoStanjeSkladista.Name = "lbl_TrenutnoStanjeSkladista";
            this.lbl_TrenutnoStanjeSkladista.Size = new System.Drawing.Size(233, 23);
            this.lbl_TrenutnoStanjeSkladista.TabIndex = 2;
            this.lbl_TrenutnoStanjeSkladista.Text = "Trenutno stanje skladišta:";
            // 
            // btn_dodajNoviDioUBazu
            // 
            this.btn_dodajNoviDioUBazu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_dodajNoviDioUBazu.Font = new System.Drawing.Font("Arial", 11.5F);
            this.btn_dodajNoviDioUBazu.ForeColor = System.Drawing.Color.White;
            this.btn_dodajNoviDioUBazu.Location = new System.Drawing.Point(182, 75);
            this.btn_dodajNoviDioUBazu.Name = "btn_dodajNoviDioUBazu";
            this.btn_dodajNoviDioUBazu.Size = new System.Drawing.Size(122, 76);
            this.btn_dodajNoviDioUBazu.TabIndex = 15;
            this.btn_dodajNoviDioUBazu.Text = "Evidentiraj u skladište";
            this.btn_dodajNoviDioUBazu.UseVisualStyleBackColor = true;
            this.btn_dodajNoviDioUBazu.Click += new System.EventHandler(this.btn_dodajNoviDioUBazu_Click);
            // 
            // btnAzuriraj
            // 
            this.btnAzuriraj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAzuriraj.Font = new System.Drawing.Font("Arial", 11.5F);
            this.btnAzuriraj.ForeColor = System.Drawing.Color.White;
            this.btnAzuriraj.Location = new System.Drawing.Point(194, 50);
            this.btnAzuriraj.Name = "btnAzuriraj";
            this.btnAzuriraj.Size = new System.Drawing.Size(122, 76);
            this.btnAzuriraj.TabIndex = 16;
            this.btnAzuriraj.Text = "Unesi";
            this.btnAzuriraj.UseVisualStyleBackColor = true;
            this.btnAzuriraj.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Arial", 11.5F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(628, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 76);
            this.button2.TabIndex = 17;
            this.button2.Text = "Obriši iz skladišta";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // grpBox_pojedinacnoFiltriranje
            // 
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.cmbProizvodID);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.txtProiztvodId);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.lbl_vrsta);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.cmbRed);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.cmbDio);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.lbl_markaAutomobila);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.btn_dodajNoviDioUBazu);
            this.grpBox_pojedinacnoFiltriranje.Controls.Add(this.lbl_proizvodac);
            this.grpBox_pojedinacnoFiltriranje.Font = new System.Drawing.Font("Arial", 12F);
            this.grpBox_pojedinacnoFiltriranje.Location = new System.Drawing.Point(16, 264);
            this.grpBox_pojedinacnoFiltriranje.Name = "grpBox_pojedinacnoFiltriranje";
            this.grpBox_pojedinacnoFiltriranje.Size = new System.Drawing.Size(375, 168);
            this.grpBox_pojedinacnoFiltriranje.TabIndex = 18;
            this.grpBox_pojedinacnoFiltriranje.TabStop = false;
            // 
            // cmbProizvodID
            // 
            this.cmbProizvodID.Font = new System.Drawing.Font("Arial", 11.5F);
            this.cmbProizvodID.FormattingEnabled = true;
            this.cmbProizvodID.Location = new System.Drawing.Point(101, 31);
            this.cmbProizvodID.Name = "cmbProizvodID";
            this.cmbProizvodID.Size = new System.Drawing.Size(203, 25);
            this.cmbProizvodID.TabIndex = 11;
            this.cmbProizvodID.SelectedIndexChanged += new System.EventHandler(this.cmbProizvodID_SelectedIndexChanged);
            // 
            // txtProiztvodId
            // 
            this.txtProiztvodId.Enabled = false;
            this.txtProiztvodId.Location = new System.Drawing.Point(310, 31);
            this.txtProiztvodId.Name = "txtProiztvodId";
            this.txtProiztvodId.Size = new System.Drawing.Size(57, 26);
            this.txtProiztvodId.TabIndex = 10;
            // 
            // lbl_vrsta
            // 
            this.lbl_vrsta.AutoSize = true;
            this.lbl_vrsta.Font = new System.Drawing.Font("Arial", 11.5F);
            this.lbl_vrsta.ForeColor = System.Drawing.Color.White;
            this.lbl_vrsta.Location = new System.Drawing.Point(16, 31);
            this.lbl_vrsta.Name = "lbl_vrsta";
            this.lbl_vrsta.Size = new System.Drawing.Size(73, 18);
            this.lbl_vrsta.TabIndex = 2;
            this.lbl_vrsta.Text = "Proizvod:";
            // 
            // cmbRed
            // 
            this.cmbRed.Font = new System.Drawing.Font("Arial", 11.5F);
            this.cmbRed.FormattingEnabled = true;
            this.cmbRed.Location = new System.Drawing.Point(101, 75);
            this.cmbRed.Name = "cmbRed";
            this.cmbRed.Size = new System.Drawing.Size(69, 25);
            this.cmbRed.TabIndex = 6;
            // 
            // cmbDio
            // 
            this.cmbDio.Font = new System.Drawing.Font("Arial", 11.5F);
            this.cmbDio.FormattingEnabled = true;
            this.cmbDio.Location = new System.Drawing.Point(99, 126);
            this.cmbDio.Name = "cmbDio";
            this.cmbDio.Size = new System.Drawing.Size(71, 25);
            this.cmbDio.TabIndex = 7;
            // 
            // lbl_markaAutomobila
            // 
            this.lbl_markaAutomobila.AutoSize = true;
            this.lbl_markaAutomobila.Font = new System.Drawing.Font("Arial", 11.5F);
            this.lbl_markaAutomobila.ForeColor = System.Drawing.Color.White;
            this.lbl_markaAutomobila.Location = new System.Drawing.Point(46, 133);
            this.lbl_markaAutomobila.Name = "lbl_markaAutomobila";
            this.lbl_markaAutomobila.Size = new System.Drawing.Size(37, 18);
            this.lbl_markaAutomobila.TabIndex = 4;
            this.lbl_markaAutomobila.Text = "Dio:";
            // 
            // lbl_proizvodac
            // 
            this.lbl_proizvodac.AutoSize = true;
            this.lbl_proizvodac.Font = new System.Drawing.Font("Arial", 11.5F);
            this.lbl_proizvodac.ForeColor = System.Drawing.Color.White;
            this.lbl_proizvodac.Location = new System.Drawing.Point(46, 82);
            this.lbl_proizvodac.Name = "lbl_proizvodac";
            this.lbl_proizvodac.Size = new System.Drawing.Size(41, 18);
            this.lbl_proizvodac.TabIndex = 3;
            this.lbl_proizvodac.Text = "Red:";
            // 
            // txtKolicina
            // 
            this.txtKolicina.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKolicina.Location = new System.Drawing.Point(194, 15);
            this.txtKolicina.Name = "txtKolicina";
            this.txtKolicina.Size = new System.Drawing.Size(122, 26);
            this.txtKolicina.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 11.5F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Količina nakon prodaje:";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 11.5F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(628, 504);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 76);
            this.button1.TabIndex = 19;
            this.button1.Text = "Povijest evidencije skladišta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAzuriraj);
            this.groupBox1.Controls.Add(this.txtKolicina);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 445);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 135);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // form_TrenutnoStanjeSkladista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(760, 590);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpBox_pojedinacnoFiltriranje);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbl_TrenutnoStanjeSkladista);
            this.Controls.Add(this.dgv_TrenutnoStanjeSkladista);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "form_TrenutnoStanjeSkladista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trenutno stanje skladista";
            this.Load += new System.EventHandler(this.form_TrenutnoStanjeSkladista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TrenutnoStanjeSkladista)).EndInit();
            this.grpBox_pojedinacnoFiltriranje.ResumeLayout(false);
            this.grpBox_pojedinacnoFiltriranje.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_TrenutnoStanjeSkladista;
        private System.Windows.Forms.Label lbl_TrenutnoStanjeSkladista;
        private System.Windows.Forms.Button btn_dodajNoviDioUBazu;
        private System.Windows.Forms.Button btnAzuriraj;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox grpBox_pojedinacnoFiltriranje;
        private System.Windows.Forms.TextBox txtKolicina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_vrsta;
        private System.Windows.Forms.ComboBox cmbRed;
        private System.Windows.Forms.ComboBox cmbDio;
        private System.Windows.Forms.Label lbl_markaAutomobila;
        private System.Windows.Forms.Label lbl_proizvodac;
        private System.Windows.Forms.TextBox txtProiztvodId;
        private System.Windows.Forms.ComboBox cmbProizvodID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}