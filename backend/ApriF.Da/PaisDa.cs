using ApriF.Be;
using ApriF.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Da
{
    public class PaisDa
    {
        public List<Pais> ListarPais(SqlConnection cn)
        {
            List<Pais> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Pais_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<Pais>();
                            while (dr.Read())
                            {
                                lista.Add(new Pais
                                {
                                    PaisId = dr.GetValue<string>("PaisId"),
                                    Nombre = dr.GetValue<string>("Nombre")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lista = null;
            }

            return lista;
        }
    }
}
