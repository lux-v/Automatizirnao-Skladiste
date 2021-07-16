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
    public partial class form_DodavanjeNovogDijelaUBazu : Form
    {

        Povezivanje_na_bazu database = new Povezivanje_na_bazu();

        public form_DodavanjeNovogDijelaUBazu()
        {
            InitializeComponent();
            AutoCompleteVrsta(database.povezivanje);
            AutoCompleteProizvodac(database.povezivanje);
            AutoCompleteMarkaAutomobila(database.povezivanje);
        }

        int markaID = 0;
        int proizvodacID = 0;
        int vrstaID = 0; 

        private void AutoCompleteMarkaAutomobila(NpgsqlConnection povezivanje)
        {
            txtMarkaAutomobila.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtMarkaAutomobila.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            database.Spoji();

            NpgsqlCommand command = new NpgsqlCommand("SELECT \"Auto\".\"marka_automobila\" FROM \"Auto\" ", database.povezivanje);
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                coll.Add(dr[0].ToString());
            }
            
            txtMarkaAutomobila.AutoCompleteCustomSource = coll;
            database.prekiniKonekciju();
        }

        private void AutoCompleteProizvodac(NpgsqlConnection povezivanje)
        {
            txtProizvodac.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtProizvodac.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            database.Spoji();
            NpgsqlCommand command = new NpgsqlCommand("SELECT \"Proizvodac\".\"naziv\" FROM \"Proizvodac\" ", database.povezivanje);
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                coll.Add(dr[0].ToString());
            }

            txtProizvodac.AutoCompleteCustomSource = coll;
            database.prekiniKonekciju();
        }

        void AutoCompleteVrsta(NpgsqlConnection povezivanje) {

            txtVrsta.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtVrsta.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            database.Spoji();
            NpgsqlCommand command = new NpgsqlCommand("SELECT \"Vrsta\".\"naziv\" FROM \"Vrsta\" ", database.povezivanje);
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                coll.Add(dr[0].ToString());
            }

            txtVrsta.AutoCompleteCustomSource = coll;
            database.prekiniKonekciju();
        }

        private void btn_dodajNoviDioUBazu_Click(object sender, EventArgs e)
        {
            string txtkarateristike = "1";
            if (txtCijena.Text == "" || txtNarucenaKolicina.Text=="" || txtMinimalnaKolicina.Text=="" || txtNaziv.Text =="" || txtProizvodac.Text=="" || txtVrsta.Text=="" || txtMarkaAutomobila.Text=="")
            {
                MessageBox.Show("Unesite sve podatke", "Upozorenje!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                markaID=postojiLiMarkaAutomobila();
                proizvodacID = postojiLiProizvodac();
                vrstaID = postojiLiVrstaProizvoda();

                if (markaID>0 || proizvodacID>0 || vrstaID>0)
                {
                    string upit = "INSERT INTO \"Autodijelovi\" VALUES (DEFAULT ,'" + txtNaziv.Text + "' ,'" + int.Parse(txtNarucenaKolicina.Text) + " ','" + int.Parse(txtMinimalnaKolicina.Text) + "' ,CAST('" + txtCijena.Text + "'AS money) ," + "" + int.Parse(txtkarateristike) + "," + vrstaID + ", " + proizvodacID + ", " + markaID + "); ";
                    database.Spoji();
                    NpgsqlCommand command = new NpgsqlCommand(upit, database.povezivanje);

                    try
                    {
                        command.ExecuteNonQuery();
                        unosUspjesan();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Upozorenje!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    database.prekiniKonekciju();

                }
                else
                {
                    MessageBox.Show("Unos nije uspio!");
                }
            }
        }

        private int postojiLiVrstaProizvoda()
        {
            database.Spoji();

            NpgsqlCommand command = new NpgsqlCommand("SELECT \"Vrsta\".\"id\", \"Vrsta\".\"naziv\" FROM \"Vrsta\" ", database.povezivanje);
            NpgsqlDataReader dr = command.ExecuteReader();
            unosVrsteDijela forma = new unosVrsteDijela(txtVrsta.Text, vrstaID);

            while (dr.Read())
            {
                if (dr[1].ToString() == txtVrsta.Text)
                {
                    vrstaID = int.Parse(dr[0].ToString());

                    return vrstaID;
                }
            }
            database.prekiniKonekciju();

            if (vrstaID == 0)
            {
                forma.ShowDialog();
            }
            return forma.MyProperty;
        }

        private int postojiLiProizvodac()
        {
            database.Spoji();

            NpgsqlCommand command = new NpgsqlCommand("SELECT \"Proizvodac\".\"id\", \"Proizvodac\".\"naziv\" FROM \"Proizvodac\" ", database.povezivanje);
            NpgsqlDataReader dr = command.ExecuteReader();
            unosProizvodaca forma = new unosProizvodaca(txtProizvodac.Text, proizvodacID);

            while (dr.Read())
            {
                if (dr[1].ToString() == txtProizvodac.Text)
                {
                    proizvodacID = int.Parse(dr[0].ToString());
                    return proizvodacID;
                }
            }
            database.prekiniKonekciju();

            if (proizvodacID == 0)
            {
                forma.ShowDialog();
            }
            return forma.MyProperty;
        }

        private void unosUspjesan()
        {
            markaID = 0;
            proizvodacID = 0;
            txtCijena.Text = "";
            txtMarkaAutomobila.Text = "";
            txtMinimalnaKolicina.Text = "";
            txtNarucenaKolicina.Text = "";
            txtNaziv.Text = "";
            txtProizvodac.Text = "";
            txtVrsta.Text = "";
            MessageBox.Show("Uspješno dodan novi dio!");
        }

        private int postojiLiMarkaAutomobila()
        {
            database.Spoji();

            NpgsqlCommand command = new NpgsqlCommand("SELECT \"Auto\".\"id\", \"Auto\".\"marka_automobila\" FROM \"Auto\" ", database.povezivanje);
            NpgsqlDataReader dr = command.ExecuteReader();
            unosAutomobila forma = new unosAutomobila(txtMarkaAutomobila.Text, markaID);

            while (dr.Read())
            {
                if (dr[1].ToString() == txtMarkaAutomobila.Text)
                {
                    markaID = int.Parse(dr[0].ToString());
               //TEST     MessageBox.Show("Marka: " + markaID);

                    return markaID;
                }
            }
            database.prekiniKonekciju();

            if (markaID == 0)
            {
                forma.ShowDialog();
            }
            return forma.MyProperty;
        }
    }
}
