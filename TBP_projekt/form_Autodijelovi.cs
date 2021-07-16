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
    public partial class Autodijelovi : Form
    {
        Povezivanje_na_bazu database = new Povezivanje_na_bazu();
        int idOdabranog = 0;

        public Autodijelovi()
        {
            InitializeComponent();
            
        }

        private void ucitajPodatke(NpgsqlConnection povezivanje)
        {

            string upit = " SELECT " +
                " \"Autodijelovi\".\"sifra\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\", " +
                "\"Vrsta\".\"naziv\", \"Karakteristike\".\"namjena\", " +
                " \"Karakteristike\".\"pakiranje\", \"Autodijelovi\".\"cijena\" ,\"Autodijelovi\".\"vrijedi_od\", \"Autodijelovi\".\"ne_vrijedi_od\"" +
                "FROM" +
                "\"Autodijelovi\", \"Proizvodac\", \"Auto\", \"Vrsta\",\"Karakteristike\"" +
                " WHERE " +
                "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
                "\"Autodijelovi\".\"vrsta_id\" = \"Vrsta\".\"id\" AND " +
                "\"Autodijelovi\".\"karakteristike_id\" = \"Karakteristike\". \"id\" AND " +
                "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\" ORDER BY 1 DESC;";

            /*
            string upit = " SELECT " +
                " \"Autodijelovi\".\"sifra\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\", " +
                "\"Vrsta\".\"naziv\", \"Karakteristike\".\"namjena\", \"Karakteristike\".\"duzina\", \"Karakteristike\".\"sirina\"," +
                " \"Karakteristike\".\"pakiranje\", \"Autodijelovi\".\"cijena\"" +
                "FROM" +
                "\"Autodijelovi\", \"Proizvodac\", \"Auto\", \"Vrsta\",\"Karakteristike\"" +
                " WHERE " +
                "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
                "\"Autodijelovi\".\"vrsta_id\" = \"Vrsta\".\"id\" AND " +
                "\"Autodijelovi\".\"karakteristike_id\" = \"Karakteristike\". \"id\" AND " +
                "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\" ;";
            */
            NpgsqlDataAdapter pridruzeno = new NpgsqlDataAdapter(upit, povezivanje);

            DataSet setAutodijelovi = new DataSet();
            pridruzeno.Fill(setAutodijelovi);
            imenaStupacaDGV(setAutodijelovi);
        }

        private void form_Autodijelovi_Load(object sender, EventArgs e)
        {
            database.Spoji();
            
            ucitajVrstaProizvoda(database.povezivanje);
            ucitajProizvodac(database.povezivanje);
            ucitajMarkuAutomobila(database.povezivanje);
            ucitajPodatke(database.povezivanje);
            txt_nazivProizvoda.Text = null;

            database.prekiniKonekciju();
        }

        private void ucitajMarkuAutomobila(NpgsqlConnection povezivanje)
        {
            string upit = "SELECT \"Auto\".\"marka_automobila\" FROM \"Auto\" ";

            NpgsqlDataAdapter pridruzeno = new NpgsqlDataAdapter(upit, povezivanje);
            DataSet setAuto = new DataSet();
            pridruzeno.Fill(setAuto);

            cmb_markaAutomobila.DataSource = setAuto.Tables[0];
            cmb_markaAutomobila.DisplayMember = setAuto.Tables[0].Columns[0].ToString();
        }

        private void ucitajProizvodac(NpgsqlConnection povezivanje)
        {
            string upit = "SELECT \"Proizvodac\".\"naziv\" FROM \"Proizvodac\" ";
            
            NpgsqlDataAdapter pridruzeno = new NpgsqlDataAdapter(upit, povezivanje);
            DataSet setProizvodac = new DataSet();
            pridruzeno.Fill(setProizvodac);

            cmb_proizvodac.DataSource = setProizvodac.Tables[0];
            cmb_proizvodac.DisplayMember = setProizvodac.Tables[0].Columns[0].ToString();
        }




        public void ucitajVrstaProizvoda(NpgsqlConnection povezivanje)
        {
            string upit = "SELECT \"Vrsta\".\"naziv\" FROM \"Vrsta\" ";

            NpgsqlDataAdapter pridruzeno = new NpgsqlDataAdapter(upit, povezivanje);
            DataSet setVrstaProizvoda = new DataSet();
            pridruzeno.Fill(setVrstaProizvoda);

            cmb_vrstaProizvoda.DataSource = setVrstaProizvoda.Tables[0];
            cmb_vrstaProizvoda.DisplayMember = setVrstaProizvoda.Tables[0].Columns[0].ToString();
        }

        private void cmb_vrstaProizvoda_SelectedIndexChanged(object sender, EventArgs e)
        {

            string upit = " SELECT " +
             " \"Autodijelovi\".\"sifra\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\", " +
             "\"Vrsta\".\"naziv\", \"Karakteristike\".\"namjena\", " +
             " \"Karakteristike\".\"pakiranje\", \"Autodijelovi\".\"cijena\" ,\"Autodijelovi\".\"vrijedi_od\", \"Autodijelovi\".\"ne_vrijedi_od\"" +
             "FROM" +
             "\"Autodijelovi\", \"Proizvodac\", \"Auto\", \"Vrsta\",\"Karakteristike\"" +
             " WHERE " +
             "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
             "\"Autodijelovi\".\"vrsta_id\" = \"Vrsta\".\"id\" AND " +
             "\"Autodijelovi\".\"karakteristike_id\" = \"Karakteristike\". \"id\" AND " +
             "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\"  AND" +
             "\"Vrsta\".\"naziv\" LIKE '" + cmb_vrstaProizvoda.Text + "' ORDER BY 1 DESC; ";
            /*
            string upit = " SELECT " +
            " \"Autodijelovi\".\"sifra\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\"," +
            "\"Vrsta\".\"naziv\", \"Karakteristike\".\"namjena\", \"Karakteristike\".\"duzina\", \"Karakteristike\".\"sirina\"," +
            " \"Karakteristike\".\"pakiranje\", \"Autodijelovi\".\"cijena\"" +
            "FROM" +
            "\"Autodijelovi\", \"Proizvodac\", \"Auto\", \"Vrsta\",\"Karakteristike\"" +
            " WHERE " +
            "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
            "\"Autodijelovi\".\"vrsta_id\" = \"Vrsta\".\"id\" AND " +
            "\"Autodijelovi\".\"karakteristike_id\" = \"Karakteristike\". \"id\" AND " +
            "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\" AND" +
            "\"Vrsta\".\"naziv\" LIKE '" + cmb_vrstaProizvoda.Text + "' ORDER BY 1 ;";
            */
            NpgsqlDataAdapter pridruzeno = new NpgsqlDataAdapter(upit, database.povezivanje);

            DataSet setAutodijelovi = new DataSet();
            pridruzeno.Fill(setAutodijelovi);
            imenaStupacaDGV(setAutodijelovi);
        }

        private void cmb_proizvodac_SelectedIndexChanged(object sender, EventArgs e)
        {

            string upit = " SELECT " +
               " \"Autodijelovi\".\"sifra\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\"," +
               "\"Vrsta\".\"naziv\", \"Karakteristike\".\"namjena\", " +
               " \"Karakteristike\".\"pakiranje\", \"Autodijelovi\".\"cijena\" ,\"Autodijelovi\".\"vrijedi_od\", \"Autodijelovi\".\"ne_vrijedi_od\"" +
              "FROM" +
               "\"Autodijelovi\", \"Proizvodac\", \"Auto\", \"Vrsta\",\"Karakteristike\"" +
               " WHERE " +
               "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
                "\"Autodijelovi\".\"vrsta_id\" = \"Vrsta\".\"id\" AND " +
               "\"Autodijelovi\".\"karakteristike_id\" = \"Karakteristike\". \"id\" AND " +
               "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\"  AND" +
               "\"Proizvodac\".\"naziv\" LIKE '" + cmb_proizvodac.Text + "' ORDER BY 1 DESC; ";
            /*
            string upit = " SELECT " +
                " \"Autodijelovi\".\"sifra\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\"," +
                "\"Vrsta\".\"naziv\", \"Karakteristike\".\"namjena\", \"Karakteristike\".\"duzina\", \"Karakteristike\".\"sirina\"," +
                " \"Karakteristike\".\"pakiranje\", \"Autodijelovi\".\"cijena\"" +
                "FROM" +
                "\"Autodijelovi\", \"Proizvodac\", \"Auto\", \"Vrsta\",\"Karakteristike\"" +
                " WHERE " +
                "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
                "\"Autodijelovi\".\"vrsta_id\" = \"Vrsta\".\"id\" AND " +
                "\"Autodijelovi\".\"karakteristike_id\" = \"Karakteristike\". \"id\" AND " +
                "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\" AND" +
                "\"Proizvodac\".\"naziv\" LIKE '" + cmb_proizvodac.Text + "'  ORDER BY 1 ;";
            */
            NpgsqlDataAdapter pridruzeno = new NpgsqlDataAdapter(upit, database.povezivanje);

            DataSet setAutodijelovi = new DataSet();
            pridruzeno.Fill(setAutodijelovi);
            
            imenaStupacaDGV(setAutodijelovi);
        }

        private void cmb_markaAutomobila_SelectedIndexChanged(object sender, EventArgs e)
        {

            string upit = " SELECT " +
                " \"Autodijelovi\".\"sifra\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\", " +
                "\"Vrsta\".\"naziv\", \"Karakteristike\".\"namjena\", " +
                " \"Karakteristike\".\"pakiranje\", \"Autodijelovi\".\"cijena\" ,\"Autodijelovi\".\"vrijedi_od\", \"Autodijelovi\".\"ne_vrijedi_od\"" +
                "FROM" +
                "\"Autodijelovi\", \"Proizvodac\", \"Auto\", \"Vrsta\",\"Karakteristike\"" +
                " WHERE " +
                "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
                "\"Autodijelovi\".\"vrsta_id\" = \"Vrsta\".\"id\" AND " +
                "\"Autodijelovi\".\"karakteristike_id\" = \"Karakteristike\". \"id\" AND " +
                "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\"  AND" +
                "\"Auto\".\"marka_automobila\" LIKE '" + cmb_markaAutomobila.Text + "' ORDER BY 1 DESC;";

            /*
            string upit = " SELECT " +
                " \"Autodijelovi\".\"sifra\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\"," +
                "\"Vrsta\".\"naziv\", \"Karakteristike\".\"namjena\", \"Karakteristike\".\"duzina\", \"Karakteristike\".\"sirina\"," +
                " \"Karakteristike\".\"pakiranje\", \"Autodijelovi\".\"cijena\"" +
                "FROM" +
                "\"Autodijelovi\", \"Proizvodac\", \"Auto\", \"Vrsta\",\"Karakteristike\"" +
                " WHERE " +
                "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
                "\"Autodijelovi\".\"vrsta_id\" = \"Vrsta\".\"id\" AND " +
                "\"Autodijelovi\".\"karakteristike_id\" = \"Karakteristike\". \"id\" AND " +
                "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\" AND" +
                "\"Auto\".\"marka_automobila\" LIKE '" + cmb_markaAutomobila.Text + "' ORDER BY 1 ;";
            */
            NpgsqlDataAdapter pridruzeno = new NpgsqlDataAdapter(upit, database.povezivanje);

            DataSet setAutodijelovi = new DataSet();
            pridruzeno.Fill(setAutodijelovi);

            imenaStupacaDGV(setAutodijelovi);

        }

        private void btn_primjeniSveFiltere_Click(object sender, EventArgs e)
        {


            string upit = " SELECT " +
                " \"Autodijelovi\".\"sifra\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\", " +
                "\"Vrsta\".\"naziv\", \"Karakteristike\".\"namjena\", " +
                " \"Karakteristike\".\"pakiranje\", \"Autodijelovi\".\"cijena\" ,\"Autodijelovi\".\"vrijedi_od\", \"Autodijelovi\".\"ne_vrijedi_od\"" +
                "FROM" +
                "\"Autodijelovi\", \"Proizvodac\", \"Auto\", \"Vrsta\",\"Karakteristike\"" +
                " WHERE " +
                "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
                "\"Autodijelovi\".\"vrsta_id\" = \"Vrsta\".\"id\" AND " +
                "\"Autodijelovi\".\"karakteristike_id\" = \"Karakteristike\". \"id\" AND " +
                "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\"  AND" +
                "\"Proizvodac\".\"naziv\" LIKE '" + cmb_proizvodac.Text + "' AND" +
                "\"Vrsta\".\"naziv\" LIKE '" + cmb_vrstaProizvoda.Text + "' AND " +
                "\"Auto\".\"marka_automobila\" LIKE '" + cmb_markaAutomobila.Text + "' ORDER BY 1 DESC;";
            /*
            string upit = " SELECT " +
                  " \"Autodijelovi\".\"sifra\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\"," +
                  "\"Vrsta\".\"naziv\", \"Karakteristike\".\"namjena\", \"Karakteristike\".\"duzina\", \"Karakteristike\".\"sirina\"," +
                  " \"Karakteristike\".\"pakiranje\", \"Autodijelovi\".\"cijena\"" +
                  "FROM" +
                  "\"Autodijelovi\", \"Proizvodac\", \"Auto\", \"Vrsta\",\"Karakteristike\"" +
                  " WHERE " +
                  "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
                  "\"Autodijelovi\".\"vrsta_id\" = \"Vrsta\".\"id\" AND " +
                  "\"Autodijelovi\".\"karakteristike_id\" = \"Karakteristike\". \"id\" AND " +
                  "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\" AND" +
                  "\"Proizvodac\".\"naziv\" LIKE '" + cmb_proizvodac.Text + "' AND" +
                  "\"Vrsta\".\"naziv\" LIKE '" + cmb_vrstaProizvoda.Text + "' AND " +
                  "\"Auto\".\"marka_automobila\" LIKE '" + cmb_markaAutomobila.Text + "' ORDER BY 1 ;";
            */
            NpgsqlDataAdapter pridruzeno = new NpgsqlDataAdapter(upit, database.povezivanje);

            DataSet setSviFilteri = new DataSet();
            pridruzeno.Fill(setSviFilteri);

            imenaStupacaDGV(setSviFilteri);
        }
        
        private void btn_obrisiSveFiltere_Click(object sender, EventArgs e)
        {
            cmb_markaAutomobila.Text = null;
            cmb_proizvodac.Text = null;
            cmb_vrstaProizvoda.Text = null;
            txt_nazivProizvoda.Text = null;
            ucitajPodatke(database.povezivanje);
        }

        private void txt_nazivProizvoda_TextChanged(object sender, EventArgs e)
        {

            string upit = " SELECT " +
                " \"Autodijelovi\".\"sifra\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\", " +
                "\"Vrsta\".\"naziv\", \"Karakteristike\".\"namjena\", " +
                " \"Karakteristike\".\"pakiranje\", \"Autodijelovi\".\"cijena\" ,\"Autodijelovi\".\"vrijedi_od\", \"Autodijelovi\".\"ne_vrijedi_od\"" +
                "FROM" +
                "\"Autodijelovi\", \"Proizvodac\", \"Auto\", \"Vrsta\",\"Karakteristike\"" +
                " WHERE " +
                "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
                "\"Autodijelovi\".\"vrsta_id\" = \"Vrsta\".\"id\" AND " +
                "\"Autodijelovi\".\"karakteristike_id\" = \"Karakteristike\". \"id\" AND " +
                "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\"  AND" +
                "\"Autodijelovi\".\"naziv\" LIKE'%" + txt_nazivProizvoda.Text + "%' ORDER BY 1 DESC;";
            /*
            string upit = " SELECT " +
                 " \"Autodijelovi\".\"sifra\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\"," +
                 "\"Vrsta\".\"naziv\", \"Karakteristike\".\"namjena\", \"Karakteristike\".\"duzina\", \"Karakteristike\".\"sirina\"," +
                 " \"Karakteristike\".\"pakiranje\", \"Autodijelovi\".\"cijena\"" +
                 "FROM" +
                 "\"Autodijelovi\", \"Proizvodac\", \"Auto\", \"Vrsta\",\"Karakteristike\"" +
                 " WHERE " +
                 "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
                 "\"Autodijelovi\".\"vrsta_id\" = \"Vrsta\".\"id\" AND " +
                 "\"Autodijelovi\".\"karakteristike_id\" = \"Karakteristike\". \"id\" AND " +
                 "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\" AND" +
                 "\"Autodijelovi\".\"naziv\" LIKE'%" + txt_nazivProizvoda.Text + "%' ORDER BY 1;";
            */
            NpgsqlDataAdapter pridruzeno = new NpgsqlDataAdapter(upit, database.povezivanje);

            DataSet setSviFilteri = new DataSet();
            pridruzeno.Fill(setSviFilteri);

            imenaStupacaDGV(setSviFilteri);
        }

        public void imenaStupacaDGV(DataSet nekiSet)
        {

            dgv_Autodijelovi.DataSource = nekiSet.Tables[0];
            dgv_Autodijelovi.Columns[0].HeaderText = "Šifra";
            dgv_Autodijelovi.Columns[1].HeaderText = "Naziv dijela";
            dgv_Autodijelovi.Columns[2].HeaderText = "Proizvođač";
            dgv_Autodijelovi.Columns[3].HeaderText = "Marka auta";
            dgv_Autodijelovi.Columns[4].HeaderText = "Vrsta";
            dgv_Autodijelovi.Columns[5].HeaderText = "Namjena";
            dgv_Autodijelovi.Columns[6].HeaderText = "Pakiranje";
            dgv_Autodijelovi.Columns[7].HeaderText = "Cijena(Kn)";
            dgv_Autodijelovi.Columns[8].HeaderText = "U prodaji od";
            dgv_Autodijelovi.Columns[9].HeaderText = "Nije u prodaji od";

            this.dgv_Autodijelovi.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
         //   this.dgv_Autodijelovi.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_Autodijelovi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_Autodijelovi.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_Autodijelovi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_Autodijelovi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_Autodijelovi.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_Autodijelovi.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_Autodijelovi.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_Autodijelovi.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            /*
            dgv_Autodijelovi.DataSource = nekiSet.Tables[0];
            dgv_Autodijelovi.Columns[0].HeaderText = "Šifra";
            dgv_Autodijelovi.Columns[1].HeaderText = "Naziv dijela";
            dgv_Autodijelovi.Columns[2].HeaderText = "Proizvođač";
            dgv_Autodijelovi.Columns[3].HeaderText = "Marka auta";
            dgv_Autodijelovi.Columns[4].HeaderText = "Vrsta";
            dgv_Autodijelovi.Columns[5].HeaderText = "Namjena";
            dgv_Autodijelovi.Columns[6].HeaderText = "Dužina(mm)";
            dgv_Autodijelovi.Columns[7].HeaderText = "Sirina(mm)";
            dgv_Autodijelovi.Columns[8].HeaderText = "Pakiranje";
            dgv_Autodijelovi.Columns[9].HeaderText = "Cijena(Kn)";
            */
        }

        private void btn_dodajNoviDioUBazu_Click(object sender, EventArgs e)
        {
            form_DodavanjeNovogDijelaUBazu nova = new form_DodavanjeNovogDijelaUBazu();
            nova.ShowDialog();
        }

        private void btnUProdaji_Click(object sender, EventArgs e)
        {
            if (idOdabranog > 0)
            {
                database.Spoji();
                //UPDATE "Autodijelovi" SET ne_vrijedi_od = CURRENT_TIMESTAMP WHERE sifra = new.sifra;
                string upit = "UPDATE \"Autodijelovi\" SET \"ne_vrijedi_od\" = NULL WHERE \"Autodijelovi\".\"sifra\" = " + idOdabranog + " ;";

                NpgsqlCommand command = new NpgsqlCommand(upit, database.povezivanje);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "UPOZORENJE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ucitajPodatke(database.povezivanje);
                database.prekiniKonekciju();
            }
            else
            {
                MessageBox.Show("Odaberite koji proizvod želite izmjeniti", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_Autodijelovi_SelectionChanged(object sender, EventArgs e)
        {
            /*
            try
            {
                idOdabranog = int.Parse(dgv_Autodijelovi.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {

                idOdabranog = 0;
            }
            lbl_markaAutomobila.Text = idOdabranog.ToString();
            */
            try
            {
                idOdabranog = int.Parse(dgv_Autodijelovi.CurrentRow.Cells[0].Value.ToString());

                
            }
            catch (Exception ex)
            {

                idOdabranog = 0;
            }
        }

        private void dgv_Autodijelovi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            database.Spoji();
            string upit = "SELECT \"Autodijelovi\".\"vrijedi_od\", \"Autodijelovi\".\"ne_vrijedi_od\" FROM \"Autodijelovi\" WHERE \"Autodijelovi\".\"sifra\" = " + idOdabranog + ";";
            NpgsqlCommand command = new NpgsqlCommand(upit, database.povezivanje);
            NpgsqlDataReader dr = command.ExecuteReader();

            if (dr[0].ToString() == null)
            {
                lblDatumVrijediOd.Text = "-";
                lblDatumNeVrijediOd.Text = dr[1].ToString();
                btnUProdaji.Enabled = false;
            }
            if (dr[1].ToString() == null)
            {
                lblDatumNeVrijediOd.Text = "-";
                lblDatumVrijediOd.Text = dr[0].ToString();
                btnNijeUProdaji.Enabled = false;
            }
            database.prekiniKonekciju();

            lbl_markaAutomobila.Text = idOdabranog.ToString();
            */
        }

        private void btnNijeUProdaji_Click(object sender, EventArgs e)
        {
            if (idOdabranog > 0)
            {
                database.Spoji();
                //UPDATE "Autodijelovi" SET ne_vrijedi_od = CURRENT_TIMESTAMP WHERE sifra = new.sifra;
                string upit = "UPDATE \"Autodijelovi\" SET \"vrijedi_od\" = NULL WHERE \"Autodijelovi\".\"sifra\" = " + idOdabranog + " ;";

                NpgsqlCommand command = new NpgsqlCommand(upit, database.povezivanje);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "UPOZORENJE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ucitajPodatke(database.povezivanje);
                database.prekiniKonekciju();
            }
            else
            {
                MessageBox.Show("Odaberite koji proizvod želite izmjeniti", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
