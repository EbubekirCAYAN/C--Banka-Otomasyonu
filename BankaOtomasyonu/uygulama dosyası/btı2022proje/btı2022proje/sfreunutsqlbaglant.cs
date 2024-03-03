using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;


namespace btı2022proje
{
    class sfreunutsqlbaglant
    {
        public SqlConnection baglan()
        { 
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QTHG79F;Initial Catalog=bankauyg2022;User ID=sa;Password=123456789");
            baglanti.Open();
            return baglanti;

                }
    }
}
