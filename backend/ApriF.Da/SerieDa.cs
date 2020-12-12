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
    public class SerieDa
    {
        public List<Serie> ListarSeriePorTipo(string emisorId,string tipoComprobanteId, SqlConnection cn)
        {
            List<Serie> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Serie_Listar_PorTipo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));
                    cmd.Parameters.AddWithValue("@TipoComprobanteId", SqlParam.Value(tipoComprobanteId));
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<Serie>();
                            while (dr.Read())
                            {
                                lista.Add(new Serie
                                {
                                    
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

        public bool MantenerSerie(Serie serie, SqlConnection cn)
        {
            bool respuesta = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Serie_Mantener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(serie.EmisorId));
                    cmd.Parameters.AddWithValue("@tipoComprobanteId", SqlParam.Value(serie.TipoComprobanteId));
                    cmd.Parameters.AddWithValue("@serieId", SqlParam.Value(serie.SerieId));
                    cmd.Parameters.AddWithValue("@inicial", SqlParam.Value(serie.Inicial));
                    cmd.Parameters.AddWithValue("@final", SqlParam.Value(serie.Final));
                    cmd.Parameters.AddWithValue("@actual", SqlParam.Value(serie.Actual));
                    cmd.Parameters.AddWithValue("@esSerieFisica", SqlParam.Value(serie.EsSerieFisica));
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

        public List<Serie> ListarSerie(string emisorId, SqlConnection cn)
        {
            List<Serie> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Serie_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<Serie>();
                            while (dr.Read())
                            {
                                lista.Add(new Serie
                                {
                                    Fila = dr.GetValue<int>("Fila"),
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

        public Serie ObtenerSerie(string emisorId, string tipoComprobanteId, string serieId, SqlConnection cn)
        {
            Serie registro = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Serie_Obtener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));
                    cmd.Parameters.AddWithValue("@tipoComprobanteId", SqlParam.Value(tipoComprobanteId));
                    cmd.Parameters.AddWithValue("@serieId", SqlParam.Value(serieId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            registro = new Serie();
                            if (dr.Read())
                            {
                                registro = new Serie
                                {
                                    EmisorId = dr.GetValue<string>("EmisorId"),
                                    TipoComprobanteId = dr.GetValue<string>("TipoComprobanteId"),
                                    SerieId = dr.GetValue<string>("SerieId"),
                                    Inicial = dr.GetValue<int>("Inicial"),
                                    Final = dr.GetValue<int>("Final"),
                                    Actual = dr.GetValue<int>("Actual"),
                                    EsSerieFisica = dr.GetValue<bool>("EsSerieFisica")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                registro = null;
            }

            return registro;

        }
    }
}
