using ApriF.Be;
using ApriF.Util;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Da
{
    public class TipoMonedaDa
    {
        public List<TipoMoneda> ListarTipoMoneda(SqlConnection cn)
        {
            List<TipoMoneda> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_TipoMoneda_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<TipoMoneda>();
                            while (dr.Read())
                            {
                                lista.Add(new TipoMoneda
                                {
                                    Id = dr.GetValue<string>("Id"),
                                    Descripcion = dr.GetValue<string>("Descripcion"),
                                    Simbolo = dr.GetValue<string>("Simbolo"),
                                    Pais = dr.GetValue<string>("Pais"),
                                    IdNumero = dr.GetValue<int>("IdNumero")
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
