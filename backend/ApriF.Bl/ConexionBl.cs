using ApriF.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Bl
{
    public class ConexionBl
    {
        static string nameConnection = AppSettings.Get<string>("nameConnection");
        static string cnText = ConfigurationManager.ConnectionStrings[nameConnection].ConnectionString;
        protected SqlConnection cn = new SqlConnection(cnText);
    }
}