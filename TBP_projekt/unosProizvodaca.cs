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
    public partial class unosProizvodaca : Form
    {

        private int proizvodacID;
        public int MyProperty
        {
            get
            {
                return this.proizvodacID;
            }
        }

        public unosProizvodaca(string imeProizvodaca, int id_proizvodaca)
        {
            InitializeComponent();
            txtNaziv.Text = imeProizvodaca;
            proizvodacID = id_proizvodaca;
        }


        Povezivanje_na_bazu database = new Povezivanje_na_bazu();
        private void btnDodajNoviAuto_Click(object sender, EventArgs e)
        {
            database.Spoji();

            string upit = "INSERT INTO \"Proizvodac\" VALUES (DEFAULT ,'" + txtNaziv.Text +"','"+rtxt_OpisProizvodaca.Text+"') returning id; ";

            NpgsqlCommand command = new NpgsqlCommand(upit, database.povezivanje);

            try
            {
                proizvodacID = int.Parse(command.ExecuteScalar().ToString());
                Close();
                MessageBox.Show("Uspješno dodan proizvođač: " + txtNaziv.Text);

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
