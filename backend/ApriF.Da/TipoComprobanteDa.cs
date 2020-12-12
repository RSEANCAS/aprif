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
    public class TipoComprobanteDa
    {
        public List<TipoComprobante> ListarTipoComprobante(SqlConnection cn)
        {
            List<TipoComprobante> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_TipoComprobante_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<TipoComprobante>();
                            while (dr.Read())
                            {
                                lista.Add(new TipoComprobante
                                {
                                    TipoComprobanteId = dr.GetValue<string>("TipoComprobanteId"),
                                    Descripcion = dr.GetValue<string>("Descripcion")
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
