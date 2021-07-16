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
    public partial class form_Narudzbe : Form
    {

        Povezivanje_na_bazu database = new Povezivanje_na_bazu();
        int idOdabranog = 0;

        public form_Narudzbe()
        {
            InitializeComponent();
        }

        public void ucitajPodatke(NpgsqlConnection povezivanje)
        {
            string autodijelovi = " SELECT " +
           " \"Narudzba\".\"id_narudzba\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\", " +
           " \"Autodijelovi\".\"minimalna_kolicina\", \"Narudzba\".\"kolicina_narucivanja\"," +
           " \"Narudzba\".\"datum_narucivanja\", \"Narudzba\".\"opis\",\"Narudzba\".\"narudzba_zaprimljena\"" +
           "FROM" +
           "\"Autodijelovi\", \"Proizvodac\", \"Auto\",\"Narudzba\",\"Vrsta\"" +
           " WHERE " +
           "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
           "\"Autodijelovi\".\"sifra\" = \"Narudzba\".\"narudzbaAutodijelovi_id\" AND " +
           "\"Autodijelovi\".\"vrsta_id\" = \"Vrsta\".\"id\" AND " +
           "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\"  ORDER BY 1 DESC;";


            NpgsqlDataAdapter pridruzeniNarudzbe = new NpgsqlDataAdapter(autodijelovi, povezivanje);
            DataSet setNar = new DataSet();
            pridruzeniNarudzbe.Fill(setNar);

            dgvTrenutneNarudzbe.DataSource = setNar.Tables[0];
            dgvTrenutneNarudzbe.Columns[0].HeaderText = "Šifra";
            dgvTrenutneNarudzbe.Columns[1].HeaderText = "Naziv";
            dgvTrenutneNarudzbe.Columns[2].HeaderText = "Proizvodac";
            dgvTrenutneNarudzbe.Columns[3].HeaderText = "Automobil";
            dgvTrenutneNarudzbe.Columns[4].HeaderText = "Minimalna kol";
            dgvTrenutneNarudzbe.Columns[5].HeaderText = "Narucena kol";
            dgvTrenutneNarudzbe.Columns[6].HeaderText = "Datum narucivanja";
            dgvTrenutneNarudzbe.Columns[7].HeaderText = "Opis";
            dgvTrenutneNarudzbe.Columns[8].HeaderText = "Zaprimljen";

            this.dgvTrenutneNarudzbe.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTrenutneNarudzbe.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTrenutneNarudzbe.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTrenutneNarudzbe.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTrenutneNarudzbe.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTrenutneNarudzbe.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTrenutneNarudzbe.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTrenutneNarudzbe.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


            string povijestNarudzbi = " SELECT " +
           " \"PovijestNarudzbi\".\"id_povijestNarudzbi\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\", " +
           " \"PovijestNarudzbi\".\"pdatum_narucivanja\", \"PovijestNarudzbi\".\"pdatum_primitka\",\"PovijestNarudzbi\".\"pkolicina_narucivanja\"," +
           " \"PovijestNarudzbi\".\"popis\", \"PovijestNarudzbi\".\"pnarudzba_zaprimljena\"" +
           "FROM" +
           "\"Autodijelovi\", \"PovijestNarudzbi\", \"Auto\",\"Proizvodac\",\"Vrsta\"" +
           " WHERE " +
           "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
           "\"Autodijelovi\".\"vrsta_id\" = \"Vrsta\".\"id\" AND " +
           "\"PovijestNarudzbi\".\"pautodijelovi_id\" = \"Autodijelovi\".\"sifra\" AND " +
           "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\" ORDER BY 1 DESC;";

            NpgsqlDataAdapter pridruzeniPovijestNarudzbi = new NpgsqlDataAdapter(povijestNarudzbi, povezivanje);
            DataSet setPovijestNarudzbi = new DataSet();
            pridruzeniPovijestNarudzbi.Fill(setPovijestNarudzbi);
            dgvPovijestNarudzbi.DataSource = setPovijestNarudzbi.Tables[0];
            dgvPovijestNarudzbi.Columns[0].HeaderText = "Šifra";
            dgvPovijestNarudzbi.Columns[1].HeaderText = "Naziv";
            dgvPovijestNarudzbi.Columns[2].HeaderText = "Proizvodac";
            dgvPovijestNarudzbi.Columns[3].HeaderText = "Automobil";
            dgvPovijestNarudzbi.Columns[4].HeaderText = "Datum narucivanja";
            dgvPovijestNarudzbi.Columns[5].HeaderText = "Datum primitka";
            dgvPovijestNarudzbi.Columns[6].HeaderText = "Narucena kol";
            dgvPovijestNarudzbi.Columns[7].HeaderText = "Opis";
            dgvPovijestNarudzbi.Columns[8].HeaderText = "Zaprimljen";

            this.dgvPovijestNarudzbi.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestNarudzbi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestNarudzbi.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestNarudzbi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestNarudzbi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestNarudzbi.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestNarudzbi.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestNarudzbi.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void form_Narudzbe_Load(object sender, EventArgs e)
        {
            database.Spoji();
            ucitajPodatke(database.povezivanje);

            database.prekiniKonekciju();
        }

        private void btnPotvrdiPrimitak_Click(object sender, EventArgs e)
        {
            string Da = "Da";

            database.Spoji();
            string sql = "UPDATE \"Narudzba\" SET \"narudzba_zaprimljena\" = '" +Da+ "' WHERE \"id_narudzba\" = " + idOdabranog + ";";
            NpgsqlCommand command = new NpgsqlCommand(sql, database.povezivanje);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "UPOZORENJE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            database.prekiniKonekciju();
            ucitajPodatke(database.povezivanje);
        }

        private void dgvTrenutneNarudzbe_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idOdabranog = int.Parse(dgvTrenutneNarudzbe.CurrentRow.Cells[0].Value.ToString());

            }
            catch (Exception ex)
            {
                idOdabranog = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Ne = "Ne";

            database.Spoji();
            string sql = "UPDATE \"Narudzba\" SET \"narudzba_zaprimljena\" = '" + Ne + "' WHERE \"id_narudzba\" = " + idOdabranog + ";";
            NpgsqlCommand command = new NpgsqlCommand(sql, database.povezivanje);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "UPOZORENJE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            database.prekiniKonekciju();
            ucitajPodatke(database.povezivanje);
        }
    }
}
