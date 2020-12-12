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
    public class UnidadMedidaDa
    {
        public List<UnidadMedida> ListarUnidadMedida(SqlConnection cn)
        {
            List<UnidadMedida> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_UnidadMedida_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<UnidadMedida>();
                            while (dr.Read())
                            {
                                lista.Add(new UnidadMedida
                                {
                                    Id = dr.GetValue<string>("Id"),
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
