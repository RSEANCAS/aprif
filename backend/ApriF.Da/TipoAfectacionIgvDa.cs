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
    public class TipoAfectacionIgvDa
    {
        public List<TipoAfectacionIgv> ListarTipoAfectacionIgv(SqlConnection cn)
        {
            List<TipoAfectacionIgv> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_TipoAfectacionIgv_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<TipoAfectacionIgv>();
                            while (dr.Read())
                            {
                                lista.Add(new TipoAfectacionIgv
                                {
                                    Id = dr.GetValue<string>("Id"),
                                    Descripcion = dr.GetValue<string>("Descripcion"),
                                    Codigo = dr.GetValue<string>("Codigo")
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
