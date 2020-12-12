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
    public class PerfilDa
    {
        public List<Perfil> ListarPerfilUsuarioSysPorPlataforma(string usuarioSysId, int plataformaId, SqlConnection cn)
        {
            List<Perfil> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_PerfilUsuarioSys_ListarPorPlataforma", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuarioSysId", SqlParam.Value(usuarioSysId));
                    cmd.Parameters.AddWithValue("@plataformaId", SqlParam.Value(plataformaId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<Perfil>();
                            if (dr.Read())
                            {
                                lista.Add(new Perfil
                                {
                                    PlataformaId = dr.GetValue<int>("PlataformaId"),
                                    PerfilId = dr.GetValue<int>("PerfilId"),
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
