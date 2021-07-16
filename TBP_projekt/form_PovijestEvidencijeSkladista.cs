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
    public partial class form_PovijestEvidencijeSkladista : Form
    {
        int idOdabranogPovijest = 0;
        Povezivanje_na_bazu database = new Povezivanje_na_bazu();
        public form_PovijestEvidencijeSkladista()
        {
            InitializeComponent();
        }



        private void dgv_PovijestEvidencijeSkladista_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idOdabranogPovijest = int.Parse(dgv_PovijestEvidencijeSkladista.CurrentRow.Cells[0].Value.ToString());

            }
            catch (Exception ex)
            {
                idOdabranogPovijest = 0;
            }
        }


        public void ucitajPodatke(NpgsqlConnection povezivanje)
        {
            string povijestNarudzbi = " SELECT " +
           " \"Informacije_Skladista\".\"id\",\"Autodijelovi\".\"sifra\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\", " +
           " \"Informacije_Skladista\".\"datum_evidencije\", \"Informacije_Skladista\".\"stara_kolicina\",\"Informacije_Skladista\".\"nova_kolicina\"," +
           " \"Informacije_Skladista\".\"opis\"" +
           "FROM" +
           "\"Autodijelovi\", \"Informacije_Skladista\", \"Auto\",\"Proizvodac\",\"Vrsta\"" +
           " WHERE " +
           "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
           "\"Autodijelovi\".\"vrsta_id\" = \"Vrsta\".\"id\" AND " +
           "\"Informacije_Skladista\".\"autodijelovi_id\" = \"Autodijelovi\".\"sifra\" AND " +
           "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\" ORDER BY 1 DESC;";

            NpgsqlDataAdapter pridruzeniPovijestNarudzbi = new NpgsqlDataAdapter(povijestNarudzbi, povezivanje);
            DataSet setPovijestNarudzbi = new DataSet();
            pridruzeniPovijestNarudzbi.Fill(setPovijestNarudzbi);
            dgv_PovijestEvidencijeSkladista.DataSource = setPovijestNarudzbi.Tables[0];
            dgv_PovijestEvidencijeSkladista.Columns[0].HeaderText = "ID";
            dgv_PovijestEvidencijeSkladista.Columns[1].HeaderText = "Šifra";
            dgv_PovijestEvidencijeSkladista.Columns[2].HeaderText = "Naziv";
            dgv_PovijestEvidencijeSkladista.Columns[3].HeaderText = "Proizvodac";
            dgv_PovijestEvidencijeSkladista.Columns[4].HeaderText = "Automobil";
            dgv_PovijestEvidencijeSkladista.Columns[5].HeaderText = "Datum evidencije";
            dgv_PovijestEvidencijeSkladista.Columns[6].HeaderText = "Stara količina";
            dgv_PovijestEvidencijeSkladista.Columns[7].HeaderText = "Nova količina";
            dgv_PovijestEvidencijeSkladista.Columns[8].HeaderText = "Opis";

            this.dgv_PovijestEvidencijeSkladista.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_PovijestEvidencijeSkladista.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //this.dgv_PovijestEvidencijeSkladista.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_PovijestEvidencijeSkladista.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_PovijestEvidencijeSkladista.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_PovijestEvidencijeSkladista.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_PovijestEvidencijeSkladista.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_PovijestEvidencijeSkladista.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_PovijestEvidencijeSkladista.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }

        private void form_PovijestEvidencijeSkladista_Load(object sender, EventArgs e)
        {
            database.Spoji();
            ucitajPodatke(database.povezivanje);

            database.prekiniKonekciju();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                database.Spoji();
                string upit = "DELETE FROM \"Informacije_Skladista\" WHERE \"Informacije_Skladista\".\"id\" = " + idOdabranogPovijest + " ;";

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
    }
}
