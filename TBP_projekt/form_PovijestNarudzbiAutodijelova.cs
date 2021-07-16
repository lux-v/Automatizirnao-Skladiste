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
    public partial class form_PovijestNarudzbiAutodijelova : Form
    {

        int idOdabranogPovijest = 0;

        Povezivanje_na_bazu database = new Povezivanje_na_bazu();
        public form_PovijestNarudzbiAutodijelova()
        {
            InitializeComponent();
        }

        private void dgv_PovijestEvidencijeSkladista_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idOdabranogPovijest = int.Parse(dgvPovijestNarudzbiDijelova.CurrentRow.Cells[0].Value.ToString());

            }
            catch (Exception ex)
            {
                idOdabranogPovijest = 0;
            }
        }

        public void ucitajPodatke(NpgsqlConnection povezivanje)
        {
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
            dgvPovijestNarudzbiDijelova.DataSource = setPovijestNarudzbi.Tables[0];
            dgvPovijestNarudzbiDijelova.Columns[0].HeaderText = "ID";
            dgvPovijestNarudzbiDijelova.Columns[1].HeaderText = "Naziv";
            dgvPovijestNarudzbiDijelova.Columns[2].HeaderText = "Proizvodac";
            dgvPovijestNarudzbiDijelova.Columns[3].HeaderText = "Automobil";
            dgvPovijestNarudzbiDijelova.Columns[4].HeaderText = "Datum narucivanja";
            dgvPovijestNarudzbiDijelova.Columns[5].HeaderText = "Datum primitka";
            dgvPovijestNarudzbiDijelova.Columns[6].HeaderText = "Narucena kol";
            dgvPovijestNarudzbiDijelova.Columns[7].HeaderText = "Opis";
            dgvPovijestNarudzbiDijelova.Columns[8].HeaderText = "Zaprimljen";


            this.dgvPovijestNarudzbiDijelova.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //  this.dgv_TrenutnoStanjeSkladista.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestNarudzbiDijelova.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestNarudzbiDijelova.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestNarudzbiDijelova.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestNarudzbiDijelova.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestNarudzbiDijelova.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestNarudzbiDijelova.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestNarudzbiDijelova.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void form_PovijestNarudzbiAutodijelova_Load(object sender, EventArgs e)
        {
            database.Spoji();
            ucitajPodatke(database.povezivanje);

            database.prekiniKonekciju();
        }
    }
}
