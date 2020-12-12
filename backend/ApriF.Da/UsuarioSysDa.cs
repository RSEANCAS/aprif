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
    public class UsuarioSysDa
    {
        public UsuarioSys ObtenerUsuarioSys(string usuarioSysId, SqlConnection cn)
        {
            UsuarioSys usuario = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_UsuarioSys_Obtener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@usuarioSysId", SqlParam.Value(usuarioSysId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                usuario = new UsuarioSys
                                {
                                    UsuarioSysId = dr.GetValue<string>("UsuarioSysId"),
                                    Clave = dr.GetValue<byte[]>("Clave"),
                                    KeyAES = dr.GetValue<byte[]>("KeyAES"),
                                    IVAES = dr.GetValue<byte[]>("IVAES"),
                                    FlagResetearClave = dr.GetValue<bool>("FlagResetearClave"),
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                usuario = null;
            }

            return usuario;
        }
    }
}
