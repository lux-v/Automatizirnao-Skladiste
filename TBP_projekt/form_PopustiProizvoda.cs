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
    public partial class form_PopustiProizvoda : Form
    {

        int idOdabranog = 0;
        int idOdabranogPovijest = 0;
        string pocetni_datum = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string zavrsni_datum = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public form_PopustiProizvoda()
        {
            InitializeComponent();
        }

        Povezivanje_na_bazu database = new Povezivanje_na_bazu();


        private void ucitajPodatke(NpgsqlConnection povezivanje)
        {
            string povijestSvihPopusta;

            if (radioButton1.Checked == true)
            {

                povijestSvihPopusta = " SELECT " +
                "\"Popusti\".\"id\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\", " +
                " \"Popusti\".\"pocinje\", \"Popusti\".\"zavrsava\", " +
                "\"Autodijelovi\".\"cijena\", \"Popusti\".\"nova_cijena\" " +
                "FROM" +
                "\"Autodijelovi\", \"Proizvodac\", \"Auto\", \"Popusti\"" +
                " WHERE " +
                "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
                "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\" AND " +
                "\"Popusti\".\"autodijelovi_id\" = \"Autodijelovi\".\"sifra\" AND " +
                "\"Popusti\".\"pocinje\" <= CURRENT_DATE AND " +
                "\"Popusti\".\"zavrsava\" >= CURRENT_DATE  ORDER BY 1 DESC;";

            }
            else if(radioButton2.Checked == true)
            {
                povijestSvihPopusta = " SELECT " +
               " \"Popusti\".\"id\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\", " +
               " \"Popusti\".\"pocinje\", \"Popusti\".\"zavrsava\", " +
               "\"Autodijelovi\".\"cijena\", \"Popusti\".\"nova_cijena\" " +
                "FROM" +
                "\"Autodijelovi\", \"Proizvodac\", \"Auto\", \"Popusti\"" +
                " WHERE " +
                "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
                "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\" AND " +
                "\"Popusti\".\"autodijelovi_id\" = \"Autodijelovi\".\"sifra\" AND " +
                "(\"Popusti\".\"pocinje\" > CURRENT_DATE AND " +
                "\"Popusti\".\"zavrsava\" > CURRENT_DATE) OR (" +
                "\"Popusti\".\"pocinje\" < CURRENT_DATE AND " +
                "\"Popusti\".\"zavrsava\" < CURRENT_DATE)  ORDER BY 1 DESC;";
            }
            else 
            {
                //radi
                povijestSvihPopusta = " SELECT " +
                 " \"Popusti\".\"id\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\", " +
                 " \"Popusti\".\"pocinje\", \"Popusti\".\"zavrsava\", " +
                 "\"Autodijelovi\".\"cijena\", \"Popusti\".\"nova_cijena\" " +
                 "FROM" +
                 "\"Autodijelovi\", \"Proizvodac\", \"Auto\", \"Popusti\"" +
                 " WHERE " +
                 "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
                 "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\" AND " +
                 //"\"Autodijelovi\".\"sifra\" = \"Popusti\".\"autodijelovi_id\" AND " +
                 "\"Autodijelovi\".\"sifra\" = \"Popusti\".\"autodijelovi_id\" ORDER BY 1 DESC;";
            }

              
          //radi
            string autodijelovi = " SELECT " +
                " \"Autodijelovi\".\"sifra\", \"Autodijelovi\".\"naziv\", \"Proizvodac\".\"naziv\", \"Auto\".\"marka_automobila\", " +
                " \"Autodijelovi\".\"cijena\"" +
                "FROM" +
                "\"Autodijelovi\", \"Proizvodac\", \"Auto\"" +
                " WHERE " +
                "\"Autodijelovi\".\"proizvodac_id\" = \"Proizvodac\".\"id\" AND " +
                "\"Autodijelovi\".\"auto_id\" = \"Auto\".\"id\"  ORDER BY 1 DESC;";

            
            NpgsqlDataAdapter pridruzenoAutodijelovi = new NpgsqlDataAdapter(autodijelovi, povezivanje);
            NpgsqlDataAdapter pridruzeniPovijest = new NpgsqlDataAdapter(povijestSvihPopusta, povezivanje);

            DataSet setAutodijelovi = new DataSet();
            pridruzenoAutodijelovi.Fill(setAutodijelovi);
            imenaStupacaDGVAutodijelovi(setAutodijelovi);

            DataSet setPovijest = new DataSet();
            pridruzeniPovijest.Fill(setPovijest);
            imenaStupcaDGVPovijest(setPovijest);
            
        }

        private void imenaStupcaDGVPovijest(DataSet setPovijest)
        {
            dgvPovijestSvihPopusta.DataSource = setPovijest.Tables[0];
            dgvPovijestSvihPopusta.Columns[0].HeaderText = "Popust";
            dgvPovijestSvihPopusta.Columns[1].HeaderText = "Naziv dijela";
            dgvPovijestSvihPopusta.Columns[2].HeaderText = "Proizvođač";
            dgvPovijestSvihPopusta.Columns[3].HeaderText = "Marka auta";
            dgvPovijestSvihPopusta.Columns[4].HeaderText = "Pocinje";
            dgvPovijestSvihPopusta.Columns[5].HeaderText = "Zavrsava";
            dgvPovijestSvihPopusta.Columns[6].HeaderText = "Cijena(Kn)";
            dgvPovijestSvihPopusta.Columns[7].HeaderText = "Popust cijena(Kn)";

            this.dgvPovijestSvihPopusta.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        //    this.dgvPovijestSvihPopusta.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestSvihPopusta.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestSvihPopusta.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestSvihPopusta.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestSvihPopusta.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestSvihPopusta.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPovijestSvihPopusta.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void imenaStupacaDGVAutodijelovi(DataSet nekiSet)
        {
            dgvPopusti.DataSource = nekiSet.Tables[0];
            dgvPopusti.Columns[0].HeaderText = "Šifra";
            dgvPopusti.Columns[1].HeaderText = "Naziv dijela";
            dgvPopusti.Columns[2].HeaderText = "Proizvođač";
            dgvPopusti.Columns[3].HeaderText = "Marka auta";
            dgvPopusti.Columns[4].HeaderText = "Cijena(Kn)";

            this.dgvPopusti.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
         //   this.dgvPopusti.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPopusti.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPopusti.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPopusti.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }

        private void form_PopustiProizvoda_Load(object sender, EventArgs e)
        {
            database.Spoji();
            ucitajPodatke(database.povezivanje);

            database.prekiniKonekciju();
        }

        private void dgvPopusti_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idOdabranog = int.Parse(dgvPopusti.CurrentRow.Cells[0].Value.ToString());

            }
            catch (Exception ex)
            {
                idOdabranog = 0;
            }
        }

        private void btn_dodajNoviDioUBazu_Click(object sender, EventArgs e)
        {
            
            pocetni_datum = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            zavrsni_datum = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");

            database.Spoji();
            
            string upit = "INSERT INTO \"Popusti\" VALUES (DEFAULT ,'" + pocetni_datum + "' ,'" + zavrsni_datum + " ',CAST('" + txtCijena.Text + "'AS money)," + "" + idOdabranog + "); ";
            NpgsqlCommand command = new NpgsqlCommand(upit, database.povezivanje);
                command.ExecuteNonQuery();

                ucitajPodatke(database.povezivanje);
                database.prekiniKonekciju();
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ucitajPodatke(database.povezivanje);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ucitajPodatke(database.povezivanje);
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ucitajPodatke(database.povezivanje);
        }
        private void dgvPovijestSvihPopusta_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idOdabranogPovijest = int.Parse(dgvPovijestSvihPopusta.CurrentRow.Cells[0].Value.ToString());

            }
            catch (Exception ex)
            {
                idOdabranogPovijest = 0;
            }
            
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
                database.Spoji();
                string upit = "DELETE FROM \"Popusti\" WHERE \"Popusti\".\"id\" = " + idOdabranogPovijest+ " ;";

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

            ucitajPodatke(database.povezivanje);
        }
    }
}
