using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace TBP_projekt
{
    class Povezivanje_na_bazu
    {
        public NpgsqlConnection povezivanje;


        public void Spoji()
        {

            string ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password = medn4Ye8;Database = Projekt; ";

            povezivanje = new NpgsqlConnection(ConnectionString);
            povezivanje.Open();

        }

        public void prekiniKonekciju()
        {
            povezivanje.Close();
        }
    }
}
