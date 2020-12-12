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
    public class TipoOperacionDa
    {
        public List<TipoOperacion> ListarTipoOperacion(SqlConnection cn)
        {
            List<TipoOperacion> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_TipoOperacion_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<TipoOperacion>();
                            while (dr.Read())
                            {
                                lista.Add(new TipoOperacion
                                {
                                    Id = dr.GetValue<string>("Id"),
                                    Descripcion = dr.GetValue<string>("Descripcion"),
                                    Comprobante = dr.GetValue<string>("Comprobante")
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
