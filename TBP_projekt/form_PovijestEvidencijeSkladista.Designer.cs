
namespace TBP_projekt
{
    partial class form_PovijestEvidencijeSkladista
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl_PovijestEvidencije = new System.Windows.Forms.Label();
            this.dgv_PovijestEvidencijeSkladista = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PovijestEvidencijeSkladista)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 11.5F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(979, 542);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 51);
            this.button2.TabIndex = 20;
            this.button2.Text = "Obriši iz povijesti";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl_PovijestEvidencije
            // 
            this.lbl_PovijestEvidencije.AutoSize = true;
            this.lbl_PovijestEvidencije.Font = new System.Drawing.Font("Arial", 15F);
            this.lbl_PovijestEvidencije.ForeColor = System.Drawing.Color.White;
            this.lbl_PovijestEvidencije.Location = new System.Drawing.Point(12, 9);
            this.lbl_PovijestEvidencije.Name = "lbl_PovijestEvidencije";
            this.lbl_PovijestEvidencije.Size = new System.Drawing.Size(258, 23);
            this.lbl_PovijestEvidencije.TabIndex = 19;
            this.lbl_PovijestEvidencije.Text = "Povijest evidencije skladišta:";
            // 
            // dgv_PovijestEvidencijeSkladista
            // 
            this.dgv_PovijestEvidencijeSkladista.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.dgv_PovijestEvidencijeSkladista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PovijestEvidencijeSkladista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_PovijestEvidencijeSkladista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_PovijestEvidencijeSkladista.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_PovijestEvidencijeSkladista.Location = new System.Drawing.Point(11, 35);
            this.dgv_PovijestEvidencijeSkladista.Name = "dgv_PovijestEvidencijeSkladista";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PovijestEvidencijeSkladista.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_PovijestEvidencijeSkladista.Size = new System.Drawing.Size(1102, 501);
            this.dgv_PovijestEvidencijeSkladista.TabIndex = 18;
            this.dgv_PovijestEvidencijeSkladista.SelectionChanged += new System.EventHandler(this.dgv_PovijestEvidencijeSkladista_SelectionChanged);
            // 
            // form_PovijestEvidencijeSkladista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(1117, 599);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbl_PovijestEvidencije);
            this.Controls.Add(this.dgv_PovijestEvidencijeSkladista);
            this.Name = "form_PovijestEvidencijeSkladista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evidencija skladišta";
            this.Load += new System.EventHandler(this.form_PovijestEvidencijeSkladista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PovijestEvidencijeSkladista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_PovijestEvidencije;
        private System.Windows.Forms.DataGridView dgv_PovijestEvidencijeSkladista;
    }
}