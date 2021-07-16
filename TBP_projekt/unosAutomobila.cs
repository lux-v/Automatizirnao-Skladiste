using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace TBP_projekt
{
    public partial class unosAutomobila : Form
    {

        private int marka;
        public int MyProperty
        {
            get
            {
                return this.marka;
            }
        }

        public unosAutomobila(string nazivAuta, int markaID)
        {
            InitializeComponent();
            txtNaziv.Text = nazivAuta;
            marka = markaID;
        }
                
        Povezivanje_na_bazu database = new Povezivanje_na_bazu();
        

        private void btnDodajNoviAuto_Click_1(object sender, EventArgs e)
        {
            database.Spoji();

            // string upit = "INSERT INTO 'Auto'(id, marka_automobila) VALUES (DEFAULT," + txtNaziv.Text + ");";

            string upit = "INSERT INTO \"Auto\" VALUES (DEFAULT ,'" + txtNaziv.Text + "') returning id; ";

            NpgsqlCommand command = new NpgsqlCommand(upit, database.povezivanje);

            try
            {
                marka = int.Parse(command.ExecuteScalar().ToString());
                Close();
                MessageBox.Show("Uspješno dodan automobil: " + txtNaziv.Text);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Upozorenje!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();

            }
            database.prekiniKonekciju();
        }

        private void btnIzadi_Click_1(object sender, EventArgs e)
        {
            Close();
        }

    }
}
