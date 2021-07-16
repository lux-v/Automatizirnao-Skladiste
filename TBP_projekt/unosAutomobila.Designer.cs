
namespace TBP_projekt
{
    partial class unosAutomobila
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
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.btnDodajNoviAuto = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnIzadi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNaziv
            // 
            this.txtNaziv.Enabled = false;
            this.txtNaziv.Font = new System.Drawing.Font("Arial", 11.5F);
            this.txtNaziv.Location = new System.Drawing.Point(12, 65);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(323, 25);
            this.txtNaziv.TabIndex = 14;
            this.txtNaziv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDodajNoviAuto
            // 
            this.btnDodajNoviAuto.Font = new System.Drawing.Font("Arial", 11.5F);
            this.btnDodajNoviAuto.Location = new System.Drawing.Point(12, 112);
            this.btnDodajNoviAuto.Name = "btnDodajNoviAuto";
            this.btnDodajNoviAuto.Size = new System.Drawing.Size(134, 51);
            this.btnDodajNoviAuto.TabIndex = 15;
            this.btnDodajNoviAuto.Text = "Dodaj novi automobil";
            this.btnDodajNoviAuto.UseVisualStyleBackColor = true;
            this.btnDodajNoviAuto.Click += new System.EventHandler(this.btnDodajNoviAuto_Click_1);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 11.5F);
            this.richTextBox1.Location = new System.Drawing.Point(12, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(320, 56);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "Automobil nije pronađen u bazi. Želite li dodati automobil?";
            // 
            // btnIzadi
            // 
            this.btnIzadi.Font = new System.Drawing.Font("Arial", 11.5F);
            this.btnIzadi.Location = new System.Drawing.Point(198, 112);
            this.btnIzadi.Name = "btnIzadi";
            this.btnIzadi.Size = new System.Drawing.Size(134, 51);
            this.btnIzadi.TabIndex = 17;
            this.btnIzadi.Text = "Izađi";
            this.btnIzadi.UseVisualStyleBackColor = true;
            this.btnIzadi.Click += new System.EventHandler(this.btnIzadi_Click_1);
            // 
            // unosAutomobila
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(344, 175);
            this.Controls.Add(this.btnIzadi);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnDodajNoviAuto);
            this.Controls.Add(this.txtNaziv);
            this.Name = "unosAutomobila";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "unosAutomobila";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Button btnDodajNoviAuto;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnIzadi;
    }
}