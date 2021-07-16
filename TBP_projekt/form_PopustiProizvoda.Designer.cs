
namespace TBP_projekt
{
    partial class form_PopustiProizvoda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPopusti = new System.Windows.Forms.DataGridView();
            this.btn_dodajNoviDioUBazu = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.lblPopisAutodijelova = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCijena = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvPovijestSvihPopusta = new System.Windows.Forms.DataGridView();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.btnObrisi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopusti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPovijestSvihPopusta)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPopusti
            // 
            this.dgvPopusti.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.dgvPopusti.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPopusti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPopusti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPopusti.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPopusti.Location = new System.Drawing.Point(12, 30);
            this.dgvPopusti.Name = "dgvPopusti";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPopusti.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPopusti.Size = new System.Drawing.Size(569, 265);
            this.dgvPopusti.TabIndex = 0;
            this.dgvPopusti.SelectionChanged += new System.EventHandler(this.dgvPopusti_SelectionChanged);
            // 
            // btn_dodajNoviDioUBazu
            // 
            this.btn_dodajNoviDioUBazu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dodajNoviDioUBazu.Font = new System.Drawing.Font("Arial", 11.5F);
            this.btn_dodajNoviDioUBazu.ForeColor = System.Drawing.Color.White;
            this.btn_dodajNoviDioUBazu.Location = new System.Drawing.Point(699, 244);
            this.btn_dodajNoviDioUBazu.Name = "btn_dodajNoviDioUBazu";
            this.btn_dodajNoviDioUBazu.Size = new System.Drawing.Size(134, 51);
            this.btn_dodajNoviDioUBazu.TabIndex = 15;
            this.btn_dodajNoviDioUBazu.Text = "Potvrdi popust";
            this.btn_dodajNoviDioUBazu.UseVisualStyleBackColor = true;
            this.btn_dodajNoviDioUBazu.Click += new System.EventHandler(this.btn_dodajNoviDioUBazu_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(664, 72);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 16;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(664, 136);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 17;
            // 
            // lblPopisAutodijelova
            // 
            this.lblPopisAutodijelova.AutoSize = true;
            this.lblPopisAutodijelova.Font = new System.Drawing.Font("Arial", 15F);
            this.lblPopisAutodijelova.ForeColor = System.Drawing.Color.White;
            this.lblPopisAutodijelova.Location = new System.Drawing.Point(8, 4);
            this.lblPopisAutodijelova.Name = "lblPopisAutodijelova";
            this.lblPopisAutodijelova.Size = new System.Drawing.Size(174, 23);
            this.lblPopisAutodijelova.TabIndex = 18;
            this.lblPopisAutodijelova.Text = "Popis autodijelova:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(680, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 23);
            this.label1.TabIndex = 20;
            this.label1.Text = "Početak popusta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(680, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 23);
            this.label2.TabIndex = 21;
            this.label2.Text = "Završetak popusta";
            // 
            // txtCijena
            // 
            this.txtCijena.Font = new System.Drawing.Font("Arial", 11.5F);
            this.txtCijena.Location = new System.Drawing.Point(664, 197);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(200, 25);
            this.txtCijena.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(695, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 23);
            this.label3.TabIndex = 23;
            this.label3.Text = "Popust cijena:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Arial", 11.5F);
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(12, 553);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(105, 22);
            this.radioButton1.TabIndex = 25;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Na popustu";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Arial", 11.5F);
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(141, 553);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(133, 22);
            this.radioButton2.TabIndex = 26;
            this.radioButton2.Text = "Nije na popustu";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 15F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 23);
            this.label5.TabIndex = 27;
            this.label5.Text = "Povijest svih popusta:";
            // 
            // dgvPovijestSvihPopusta
            // 
            this.dgvPovijestSvihPopusta.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.dgvPovijestSvihPopusta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPovijestSvihPopusta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvPovijestSvihPopusta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPovijestSvihPopusta.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvPovijestSvihPopusta.Location = new System.Drawing.Point(12, 361);
            this.dgvPovijestSvihPopusta.Name = "dgvPovijestSvihPopusta";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 11.5F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPovijestSvihPopusta.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPovijestSvihPopusta.Size = new System.Drawing.Size(906, 183);
            this.dgvPovijestSvihPopusta.TabIndex = 28;
            this.dgvPovijestSvihPopusta.SelectionChanged += new System.EventHandler(this.dgvPovijestSvihPopusta_SelectionChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Arial", 11.5F);
            this.radioButton3.ForeColor = System.Drawing.Color.White;
            this.radioButton3.Location = new System.Drawing.Point(297, 553);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(102, 22);
            this.radioButton3.TabIndex = 29;
            this.radioButton3.Text = "Prikaži sve";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // btnObrisi
            // 
            this.btnObrisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObrisi.Font = new System.Drawing.Font("Arial", 11.5F);
            this.btnObrisi.ForeColor = System.Drawing.Color.White;
            this.btnObrisi.Location = new System.Drawing.Point(784, 553);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(134, 51);
            this.btnObrisi.TabIndex = 30;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // form_PopustiProizvoda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(928, 613);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.dgvPovijestSvihPopusta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCijena);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPopisAutodijelova);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btn_dodajNoviDioUBazu);
            this.Controls.Add(this.dgvPopusti);
            this.Name = "form_PopustiProizvoda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Popusti";
            this.Load += new System.EventHandler(this.form_PopustiProizvoda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopusti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPovijestSvihPopusta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPopusti;
        private System.Windows.Forms.Button btn_dodajNoviDioUBazu;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label lblPopisAutodijelova;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCijena;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvPovijestSvihPopusta;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button btnObrisi;
    }
}