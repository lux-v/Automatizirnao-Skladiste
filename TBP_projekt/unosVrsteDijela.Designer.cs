
namespace TBP_projekt
{
    partial class unosVrsteDijela
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxt_OpisVrste = new System.Windows.Forms.RichTextBox();
            this.btnIzadi = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnDodajNoviAuto = new System.Windows.Forms.Button();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 31;
            this.label2.Text = "Opis vrste:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Naziv vrste:";
            // 
            // rtxt_OpisVrste
            // 
            this.rtxt_OpisVrste.Font = new System.Drawing.Font("Arial", 11.5F);
            this.rtxt_OpisVrste.Location = new System.Drawing.Point(6, 184);
            this.rtxt_OpisVrste.Name = "rtxt_OpisVrste";
            this.rtxt_OpisVrste.Size = new System.Drawing.Size(323, 197);
            this.rtxt_OpisVrste.TabIndex = 29;
            this.rtxt_OpisVrste.Text = "";
            // 
            // btnIzadi
            // 
            this.btnIzadi.Font = new System.Drawing.Font("Arial", 11.5F);
            this.btnIzadi.Location = new System.Drawing.Point(195, 387);
            this.btnIzadi.Name = "btnIzadi";
            this.btnIzadi.Size = new System.Drawing.Size(134, 51);
            this.btnIzadi.TabIndex = 28;
            this.btnIzadi.Text = "Izađi";
            this.btnIzadi.UseVisualStyleBackColor = true;
            this.btnIzadi.Click += new System.EventHandler(this.btnIzadi_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 11.5F);
            this.richTextBox1.Location = new System.Drawing.Point(9, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(320, 56);
            this.richTextBox1.TabIndex = 27;
            this.richTextBox1.Text = "Vrsta proizboda nije pronađena u bazi. Želite li dodati novu vrstu proizvoda?";
            // 
            // btnDodajNoviAuto
            // 
            this.btnDodajNoviAuto.Font = new System.Drawing.Font("Arial", 11.5F);
            this.btnDodajNoviAuto.Location = new System.Drawing.Point(9, 387);
            this.btnDodajNoviAuto.Name = "btnDodajNoviAuto";
            this.btnDodajNoviAuto.Size = new System.Drawing.Size(134, 51);
            this.btnDodajNoviAuto.TabIndex = 26;
            this.btnDodajNoviAuto.Text = "Dodajte novu vrstu proizvoda";
            this.btnDodajNoviAuto.UseVisualStyleBackColor = true;
            this.btnDodajNoviAuto.Click += new System.EventHandler(this.btnDodajNoviAuto_Click);
            // 
            // txtNaziv
            // 
            this.txtNaziv.Enabled = false;
            this.txtNaziv.Font = new System.Drawing.Font("Arial", 11.5F);
            this.txtNaziv.Location = new System.Drawing.Point(6, 105);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(323, 25);
            this.txtNaziv.TabIndex = 25;
            this.txtNaziv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // unosVrsteDijela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(341, 448);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtxt_OpisVrste);
            this.Controls.Add(this.btnIzadi);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnDodajNoviAuto);
            this.Controls.Add(this.txtNaziv);
            this.Name = "unosVrsteDijela";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "unosVrsteDijela";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxt_OpisVrste;
        private System.Windows.Forms.Button btnIzadi;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnDodajNoviAuto;
        private System.Windows.Forms.TextBox txtNaziv;
    }
}