
namespace TBP_projekt
{
    partial class unosProizvodaca
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
            this.btnIzadi = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnDodajNoviAuto = new System.Windows.Forms.Button();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.rtxt_OpisProizvodaca = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIzadi
            // 
            this.btnIzadi.Font = new System.Drawing.Font("Arial", 11.5F);
            this.btnIzadi.Location = new System.Drawing.Point(198, 383);
            this.btnIzadi.Name = "btnIzadi";
            this.btnIzadi.Size = new System.Drawing.Size(134, 51);
            this.btnIzadi.TabIndex = 21;
            this.btnIzadi.Text = "Izađi";
            this.btnIzadi.UseVisualStyleBackColor = true;
            this.btnIzadi.Click += new System.EventHandler(this.btnIzadi_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 11.5F);
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(320, 56);
            this.richTextBox1.TabIndex = 20;
            this.richTextBox1.Text = "Prozvođač nije pronađen u bazi. Želite li dodati proizvođača?";
            // 
            // btnDodajNoviAuto
            // 
            this.btnDodajNoviAuto.Font = new System.Drawing.Font("Arial", 11.5F);
            this.btnDodajNoviAuto.Location = new System.Drawing.Point(12, 383);
            this.btnDodajNoviAuto.Name = "btnDodajNoviAuto";
            this.btnDodajNoviAuto.Size = new System.Drawing.Size(134, 51);
            this.btnDodajNoviAuto.TabIndex = 19;
            this.btnDodajNoviAuto.Text = "Dodaj novog proizvođača";
            this.btnDodajNoviAuto.UseVisualStyleBackColor = true;
            this.btnDodajNoviAuto.Click += new System.EventHandler(this.btnDodajNoviAuto_Click);
            // 
            // txtNaziv
            // 
            this.txtNaziv.Enabled = false;
            this.txtNaziv.Font = new System.Drawing.Font("Arial", 11.5F);
            this.txtNaziv.Location = new System.Drawing.Point(9, 101);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(323, 25);
            this.txtNaziv.TabIndex = 18;
            this.txtNaziv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rtxt_OpisProizvodaca
            // 
            this.rtxt_OpisProizvodaca.Font = new System.Drawing.Font("Arial", 11.5F);
            this.rtxt_OpisProizvodaca.Location = new System.Drawing.Point(9, 180);
            this.rtxt_OpisProizvodaca.Name = "rtxt_OpisProizvodaca";
            this.rtxt_OpisProizvodaca.Size = new System.Drawing.Size(323, 197);
            this.rtxt_OpisProizvodaca.TabIndex = 22;
            this.rtxt_OpisProizvodaca.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "Ime proizvođača:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Opis proizvođača:";
            // 
            // unosProizvodaca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(345, 452);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtxt_OpisProizvodaca);
            this.Controls.Add(this.btnIzadi);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnDodajNoviAuto);
            this.Controls.Add(this.txtNaziv);
            this.Name = "unosProizvodaca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "unosProizvodaca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIzadi;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnDodajNoviAuto;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.RichTextBox rtxt_OpisProizvodaca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}