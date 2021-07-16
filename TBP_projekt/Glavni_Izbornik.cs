using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TBP_projekt
{
    public partial class Glavni_Izbornik : Form
    {
        public Glavni_Izbornik()
        {
            InitializeComponent();
        }

        private void btn_autodijelovi_Click(object sender, EventArgs e)
        {
            Autodijelovi formAutodijelovi = new Autodijelovi();
            formAutodijelovi.Show();
        }

        private void btnTrenutnoStanjeSkladista_Click(object sender, EventArgs e)
        {
            form_TrenutnoStanjeSkladista formTrenutnoStanjeSkladista = new form_TrenutnoStanjeSkladista();
            formTrenutnoStanjeSkladista.Show();
        }

        private void btnPopustiProizvoda_Click(object sender, EventArgs e)
        {
            form_PopustiProizvoda form_PopustiProizvoda = new form_PopustiProizvoda();
            form_PopustiProizvoda.ShowDialog();
        }

        private void btnNarudzbe_Click(object sender, EventArgs e)
        {
            form_Narudzbe form_Narudzbe = new form_Narudzbe();
            form_Narudzbe.ShowDialog();
        }

        private void btnPovijestEvidencijeSkladista_Click(object sender, EventArgs e)
        {
            form_PovijestEvidencijeSkladista form_PovijestEvidencijeSkladista = new form_PovijestEvidencijeSkladista();
            form_PovijestEvidencijeSkladista.ShowDialog();
        }

        private void btnPovijestNarudzbiAutodijelova_Click(object sender, EventArgs e)
        {
            form_PovijestNarudzbiAutodijelova form_PovijestNarudzbiAutodijelova = new form_PovijestNarudzbiAutodijelova();
            form_PovijestNarudzbiAutodijelova.ShowDialog();
        }
    }
}
