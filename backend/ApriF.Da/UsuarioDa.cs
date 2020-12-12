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
    public class UsuarioDa
    {
        public bool MantenerUsuario(Usuario usuario, SqlConnection cn)
        {
            bool respuesta = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Usuario_Mantener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(usuario.EmisorId));
                    cmd.Parameters.AddWithValue("@usuarioId", SqlParam.Value(usuario.UsuarioId));
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@clave", SqlDbType = SqlDbType.VarBinary, Value = SqlParam.Value(usuario.Clave) });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@keyAES", SqlDbType = SqlDbType.VarBinary, Value = SqlParam.Value(usuario.KeyAES) });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@ivAES", SqlDbType = SqlDbType.VarBinary, Value = SqlParam.Value(usuario.IVAES) });
                    cmd.Parameters.AddWithValue("@flagUsuarioSistema", SqlParam.Value(usuario.FlagUsuarioSistema));
                    cmd.Parameters.AddWithValue("@flagBaja", SqlParam.Value(usuario.FlagBaja));
                    cmd.Parameters.AddWithValue("@modificadoPor", SqlParam.Value(usuario.ModificadoPor));
                    cmd.Parameters.AddWithValue("@ipModificacion", SqlParam.Value(usuario.IpModificacion));
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    respuesta = filasAfectadas != 0 && filasAfectadas != -1;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            return respuesta;
        }

        public Usuario ObtenerUsuario(string emisorId, string usuarioId, SqlConnection cn)
        {
            Usuario usuario = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Usuario_Obtener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));
                    cmd.Parameters.AddWithValue("@usuarioId", SqlParam.Value(usuarioId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                usuario = new Usuario
                                {
                                    EmisorId = dr.GetValue<string>("EmisorId"),
                                    UsuarioId = dr.GetValue<string>("UsuarioId"),
                                    Clave = dr.GetValue<byte[]>("Clave"),
                                    KeyAES = dr.GetValue<byte[]>("KeyAES"),
                                    IVAES = dr.GetValue<byte[]>("IVAES"),
                                    FlagUsuarioSistema = dr.GetValue<bool>("FlagUsuarioSistema"),
                                    FlagBaja = dr.GetValue<bool>("FlagBaja"),
                                    SucursalesAsignadas = dr.GetValue<int>("SucursalesAsignadas")
                                };
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                usuario = null;
            }

            return usuario;
        }

        public List<Usuario> ListarUsuario(string emisorId, SqlConnection cn)
        {
            List<Usuario> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Usuario_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<Usuario>();
                            while (dr.Read())
                            {
                                lista.Add(new Usuario
                                {
                                    Fila = dr.GetValue<int>("Fila"),
                                    EmisorId = dr.GetValue<string>("EmisorId"),
                                    UsuarioId = dr.GetValue<string>("UsuarioId"),
                                    FlagResetearClave = dr.GetValue<bool>("FlagResetearClave"),
                                    FlagUsuarioSistema = dr.GetValue<bool>("FlagUsuarioSistema"),
                                    FlagBaja = dr.GetValue<bool>("FlagBaja"),
                                    SucursalesAsignadas = dr.GetValue<int>("SucursalesAsignadas")
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
