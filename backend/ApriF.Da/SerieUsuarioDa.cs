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
    public class SerieUsuarioDa
    {
        public bool RelacionarSerieUsuario(SerieUsuario serieUsuario, SqlConnection cn)
        {
            bool respuesta = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_SerieUsuario_Relacionar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(serieUsuario.EmisorId));
                    cmd.Parameters.AddWithValue("@tipoComprobanteId", SqlParam.Value(serieUsuario.TipoComprobanteId));
                    cmd.Parameters.AddWithValue("@serieId", SqlParam.Value(serieUsuario.SerieId));
                    cmd.Parameters.AddWithValue("@usuarioId", SqlParam.Value(serieUsuario.UsuarioId));
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

        public bool LiberarSerieUsuario(string emisorId, SqlConnection cn)
        {
            bool respuesta = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_SerieUsuario_Liberar", cn))
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

        public List<SerieUsuario> ListarSerieUsuario(string emisorId, SqlConnection cn)
        {
            List<SerieUsuario> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_SerieUsuario_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<SerieUsuario>();
                            while (dr.Read())
                            {
                                lista.Add(new SerieUsuario
                                {
                                    Fila = dr.GetValue<int>("Fila"),
                                    EmisorId = dr.GetValue<string>("EmisorId"),
                                    Serie = new Serie
                                    {
                                        //Fila = dr.GetValue<int>("Fila"),
                                        EmisorId = dr.GetValue<string>("EmisorId"),
                                        TipoComprobanteId = dr.GetValue<string>("TipoComprobanteId"),
                                        TipoComprobante = new TipoComprobante
                                        {
                                            TipoComprobanteId = dr.GetValue<string>("TipoComprobanteId"),
                                            Descripcion = dr.GetValue<string>("TipoComprobanteDescripcion")
                                        },
                                        SerieId = dr.GetValue<string>("SerieId"),
                                        Inicial = dr.GetValue<int>("Inicial"),
                                        Final = dr.GetValue<int>("Final"),
                                        Actual = dr.GetValue<int>("Actual"),
                                        EsSerieFisica = dr.GetValue<bool>("EsSerieFisica")
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
