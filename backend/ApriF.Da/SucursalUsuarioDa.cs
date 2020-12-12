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
    public class SucursalUsuarioDa
    {
        public bool RelacionarSucursalUsuario(SucursalUsuario sucursalUsuario, SqlConnection cn)
        {
            bool respuesta = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_SucursalUsuario_Relacionar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(sucursalUsuario.EmisorId));
                    cmd.Parameters.AddWithValue("@sucursalId", SqlParam.Value(sucursalUsuario.SucursalId));
                    cmd.Parameters.AddWithValue("@usuarioId", SqlParam.Value(sucursalUsuario.UsuarioId));
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

        public bool LiberarSucursalUsuario(string emisorId, SqlConnection cn)
        {
            bool respuesta = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_SucursalUsuario_Liberar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    respuesta = filasAfectadas != -1;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            return respuesta;
        }

        public List<SucursalUsuario> ListarSucursalUsuario(string emisorId, SqlConnection cn)
        {
            List<SucursalUsuario> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_SucursalUsuario_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<SucursalUsuario>();
                            while (dr.Read())
                            {
                                lista.Add(new SucursalUsuario
                                {
                                    Fila = dr.GetValue<int>("Fila"),
                                    EmisorId = dr.GetValue<string>("EmisorId"),
                                    Sucursal = new Sucursal
                                    {
                                        //Fila = dr.GetValue<int>("Fila"),
                                        EmisorId = dr.GetValue<string>("EmisorId"),
                                        SucursalId = dr.GetValue<int>("SucursalId"),
                                        CodigoSunat = dr.GetValue<string>("CodigoSunat"),
                                        Nombre = dr.GetValue<string>("Nombre"),
                                        Direccion = dr.GetValue<string>("Direccion"),
                                        Referencia = dr.GetValue<string>("Referencia"),
                                        FlagDireccionFiscal = dr.GetValue<bool>("FlagDireccionFiscal"),
                                        PaisId = dr.GetValue<string>("PaisId"),
                                        DepartamentoId = dr.GetValue<string>("DepartamentoId"),
                                        ProvinciaId = dr.GetValue<string>("ProvinciaId"),
                                        DistritoId = dr.GetValue<string>("DistritoId")
                                    },
                                    Usuario = new Usuario
                                    {
                                        //Fila = dr.GetValue<int>("Fila"),
                                        EmisorId = dr.GetValue<string>("EmisorId"),
                                        UsuarioId = dr.GetValue<string>("UsuarioId"),
                                        FlagResetearClave = dr.GetValue<bool>("FlagResetearClave"),
                                        FlagUsuarioSistema = dr.GetValue<bool>("FlagUsuarioSistema"),
                                        FlagBaja = dr.GetValue<bool>("FlagBaja"),
                                        //SucursalesAsignadas = dr.GetValue<int>("SucursalesAsignadas")
                                    }
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
