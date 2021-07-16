
namespace TBP_projekt
{
    partial class form_PovijestNarudzbiAutodijelova
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
            this.lbl_PovijestNarudzbiDijelova = new System.Windows.Forms.Label();
            this.dgvPovijestNarudzbiDijelova = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPovijestNarudzbiDijelova)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_PovijestNarudzbiDijelova
            // 
            this.lbl_PovijestNarudzbiDijelova.AutoSize = true;
            this.lbl_PovijestNarudzbiDijelova.Font = new System.Drawing.Font("Arial", 15F);
            this.lbl_PovijestNarudzbiDijelova.ForeColor = System.Drawing.Color.White;
            this.lbl_PovijestNarudzbiDijelova.Location = new System.Drawing.Point(13, 10);
            this.lbl_PovijestNarudzbiDijelova.Name = "lbl_PovijestNarudzbiDijelova";
            this.lbl_PovijestNarudzbiDijelova.Size = new System.Drawing.Size(266, 23);
            this.lbl_PovijestNarudzbiDijelova.TabIndex = 22;
            this.lbl_PovijestNarudzbiDijelova.Text = "Povijest narudžbi autodijelova";
            // 
            // dgvPovijestNarudzbiDijelova
            // 
            this.dgvPovijestNarudzbiDijelova.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.dgvPovijestNarudzbiDijelova.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPovijestNarudzbiDijelova.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPovijestNarudzbiDijelova.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPovijestNarudzbiDijelova.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPovijestNarudzbiDijelova.Location = new System.Drawing.Point(12, 36);
            this.dgvPovijestNarudzbiDijelova.Name = "dgvPovijestNarudzbiDijelova";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPovijestNarudzbiDijelova.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPovijestNarudzbiDijelova.Size = new System.Drawing.Size(1083, 501);
            this.dgvPovijestNarudzbiDijelova.TabIndex = 21;
            this.dgvPovijestNarudzbiDijelova.SelectionChanged += new System.EventHandler(this.dgv_PovijestEvidencijeSkladista_SelectionChanged);
            // 
            // form_PovijestNarudzbiAutodijelova
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(1107, 557);
            this.Controls.Add(this.lbl_PovijestNarudzbiDijelova);
            this.Controls.Add(this.dgvPovijestNarudzbiDijelova);
            this.Name = "form_PovijestNarudzbiAutodijelova";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Povijest narudžbi";
            this.Load += new System.EventHandler(this.form_PovijestNarudzbiAutodijelova_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPovijestNarudzbiDijelova)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_PovijestNarudzbiDijelova;
        private System.Windows.Forms.DataGridView dgvPovijestNarudzbiDijelova;
    }
}