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
    public partial class form_TrenutnoStanjeSkladista : Form
    {
        public form_TrenutnoStanjeSkladista()
        {
            InitializeComponent();
        }


        int idOdabranog = 0;
        int kolicinaOdabranog = 0;
        string redOdabranog;
        string nazivOdabranog;
        int dioOdabranog = 0;
        int minimalna_kolicina_proizvoda = 0;
        int id_odabranog_minimalna_kolicina_proizvoda = 0;

        Povezivanje_na_bazu database = new Povezivanje_na_bazu();

        public void ucitajPodatke(NpgsqlConnection povezivanje)
        {
            string upit = "SELECT" +
                " \"Stanje_Skladista\".\"autodijelovi_id\",\"Autodijelovi\".\"naziv\",\"Stanje_Skladista\".\"kolicina\"," +
                "\"Autodijelovi\".\"minimalna_kolicina\",\"Stanje_Skladista\".\"red\", \"Stanje_Skladista\".\"dio\", \"Stanje_Skladista\".\"za_sortiranje\"" +
                " FROM " +
                "\"Stanje_Skladista\",\"Autodijelovi\" WHERE \"Stanje_Skladista\".\"autodijelovi_id\" = \"Autodijelovi\".\"sifra\" ORDER BY 7 DESC";

            NpgsqlDataAdapter pridruzeno = new NpgsqlDataAdapter(upit, povezivanje);
            DataSet setStanjeSkladista = new DataSet();

            pridruzeno.Fill(setStanjeSkladista);
            dgv_TrenutnoStanjeSkladista.DataSource = setStanjeSkladista.Tables[0];
            dgv_TrenutnoStanjeSkladista.Columns[0].HeaderText = "Šifra";
            dgv_TrenutnoStanjeSkladista.Columns[1].HeaderText = "Naziv";
            dgv_TrenutnoStanjeSkladista.Columns[2].HeaderText = "Na raspolaganju(kom)";
            dgv_TrenutnoStanjeSkladista.Columns[3].HeaderText = "Minimalna količina(kom)";
            dgv_TrenutnoStanjeSkladista.Columns[4].HeaderText = "Red";
            dgv_TrenutnoStanjeSkladista.Columns[5].HeaderText = "Dio";

            this.dgv_TrenutnoStanjeSkladista.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
          //  this.dgv_TrenutnoStanjeSkladista.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_TrenutnoStanjeSkladista.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_TrenutnoStanjeSkladista.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgv_TrenutnoStanjeSkladista.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }

        private void form_TrenutnoStanjeSkladista_Load(object sender, EventArgs e)
        {
            database.Spoji();
            ucitajPodatke(database.povezivanje);
            ucitajRed(database.povezivanje);
            ucitajDio(database.povezivanje);
            ucitajNaziv(database.povezivanje);
            database.prekiniKonekciju();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (int.Parse(txtProiztvodId.Text) > 0)
            {
                database.Spoji();
                string upit = "DELETE FROM \"Stanje_Skladista\" WHERE " +
                    "\"Stanje_Skladista\".\"autodijelovi_id\" = " + int.Parse(txtProiztvodId.Text) + " ;";

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
                MessageBox.Show("Molim Vas odaberite dio kojeg želite obrisati", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_TrenutnoStanjeSkladista_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_TrenutnoStanjeSkladista.Rows[0].Cells[0].Selected == true)
                {
                    idOdabranog = int.Parse(dgv_TrenutnoStanjeSkladista.CurrentRow.Cells[0].Value.ToString());
                    id_odabranog_minimalna_kolicina_proizvoda = int.Parse(dgv_TrenutnoStanjeSkladista.CurrentRow.Cells[3].Value.ToString());
                }
                kolicinaOdabranog = int.Parse(dgv_TrenutnoStanjeSkladista.CurrentRow.Cells[2].Value.ToString());
                redOdabranog = dgv_TrenutnoStanjeSkladista.CurrentRow.Cells[4].Value.ToString();
                nazivOdabranog = dgv_TrenutnoStanjeSkladista.CurrentRow.Cells[1].Value.ToString();
                dioOdabranog = int.Parse(dgv_TrenutnoStanjeSkladista.CurrentRow.Cells[5].Value.ToString());

                
            }
            catch (Exception ex)
            {

                idOdabranog = 0;
            }
            txtProiztvodId.Text = idOdabranog.ToString();
            txtKolicina.Text = kolicinaOdabranog.ToString();
            cmbRed.Text = redOdabranog;
            cmbProizvodID.Text = nazivOdabranog;
            cmbDio.Text = dioOdabranog.ToString();

        }

        private void ucitajRed(NpgsqlConnection povezivanje)
        {
            database.Spoji();
            string upit = "SELECT DISTINCT \"Stanje_Skladista\".\"red\" FROM \"Stanje_Skladista\" ";

            NpgsqlDataAdapter pridruzeno = new NpgsqlDataAdapter(upit, povezivanje);
            DataSet setRed = new DataSet();
            pridruzeno.Fill(setRed);

            database.prekiniKonekciju();

            cmbRed.DataSource = setRed.Tables[0];
            cmbRed.DisplayMember = setRed.Tables[0].Columns[0].ToString();
        }
        private void ucitajDio(NpgsqlConnection povezivanje)
        {
            database.Spoji();
            string upit = "SELECT DISTINCT \"Stanje_Skladista\".\"dio\" FROM \"Stanje_Skladista\" ";

            NpgsqlDataAdapter pridruzeno = new NpgsqlDataAdapter(upit, povezivanje);
            DataSet setDio = new DataSet();
            pridruzeno.Fill(setDio);

            database.prekiniKonekciju();

            cmbDio.DataSource = setDio.Tables[0];
            cmbDio.DisplayMember = setDio.Tables[0].Columns[0].ToString();
        }
        private void ucitajNaziv(NpgsqlConnection povezivanje)
        {
            database.Spoji();
            string upit = "SELECT DISTINCT \"Autodijelovi\".\"naziv\" FROM \"Autodijelovi\"";

            NpgsqlDataAdapter pridruzeno = new NpgsqlDataAdapter(upit, povezivanje);
            DataSet setNaziv = new DataSet();
            pridruzeno.Fill(setNaziv);

            database.prekiniKonekciju();

            cmbProizvodID.DataSource = setNaziv.Tables[0];
            cmbProizvodID.DisplayMember = setNaziv.Tables[0].Columns[0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.Spoji();
 
            string sql = "UPDATE \"Stanje_Skladista\" SET \"kolicina\" = " + int.Parse(txtKolicina.Text) + " WHERE \"autodijelovi_id\" = '" + int.Parse(txtProiztvodId.Text) + "';";
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
            ucitajDio(database.povezivanje);
            ucitajRed(database.povezivanje);

        }

        private void btn_dodajNoviDioUBazu_Click(object sender, EventArgs e)
        {

            if (true)
            {

            }

            if (int.Parse(txtKolicina.Text) >= 0 && int.Parse(txtProiztvodId.Text) > 0)
            {
                database.Spoji();
                int kolicina_kod_novog_unosa = 0;

                string upit = "INSERT INTO \"Stanje_Skladista\" VALUES (" + int.Parse(txtProiztvodId.Text) + "," + kolicina_kod_novog_unosa + ", '" + cmbRed.Text + "', '"+ int.Parse(cmbDio.Text) + "',NULL,'" + minimalna_kolicina_proizvoda + "');";
                NpgsqlCommand command = new NpgsqlCommand(upit, database.povezivanje);
                command.ExecuteNonQuery();

                ucitajPodatke(database.povezivanje);
                ucitajDio(database.povezivanje);
                ucitajRed(database.povezivanje);
                database.prekiniKonekciju();
            }
            else
            {
                MessageBox.Show("Količina mora biti veća od 0", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProizvodID_SelectedIndexChanged(object sender, EventArgs e)
        {
            database.Spoji();
            string upit = "SELECT \"Autodijelovi\".\"naziv\",\"Autodijelovi\".\"sifra\", \"Autodijelovi\".\"minimalna_kolicina\" FROM  \"Autodijelovi\" ";

            NpgsqlCommand command = new NpgsqlCommand(upit, database.povezivanje);
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                if (dr[0].ToString() == cmbProizvodID.Text)
                {
                    txtProiztvodId.Text = dr[1].ToString();
                    minimalna_kolicina_proizvoda = int.Parse(dr[2].ToString());
                }
            }
            database.prekiniKonekciju();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            form_PovijestEvidencijeSkladista form_PovijestEvidencijeSkladista = new form_PovijestEvidencijeSkladista();
            form_PovijestEvidencijeSkladista.ShowDialog();
        }
    }
}
