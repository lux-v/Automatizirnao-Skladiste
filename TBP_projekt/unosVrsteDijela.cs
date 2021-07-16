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
    public partial class unosVrsteDijela : Form
    {

        private int id_vrsta;
        public int MyProperty {
            get
            {
                return this.id_vrsta;
            }
        }

        public unosVrsteDijela(string nazivVrste, int vrstaID)
        {
            InitializeComponent();
            txtNaziv.Text = nazivVrste;
            id_vrsta = vrstaID;
        }

        Povezivanje_na_bazu database = new Povezivanje_na_bazu();

        private void btnDodajNoviAuto_Click(object sender, EventArgs e)
        {
            database.Spoji();

            string upit = "INSERT INTO \"Vrsta\" VALUES (DEFAULT ,'" + txtNaziv.Text + "','" + rtxt_OpisVrste.Text + "') returning id; ";

            NpgsqlCommand command = new NpgsqlCommand(upit, database.povezivanje);
      
            try
            {
                //execute nonquery ne vraca vrijendost
                id_vrsta = int.Parse(command.ExecuteScalar().ToString());
                Close();
                MessageBox.Show("Uspješno dodana vrsta: " + txtNaziv.Text);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Upozorenje!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();

            }
            database.prekiniKonekciju();
        }

        private void btnIzadi_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
