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
    public class PlataformaDa
    {
        public bool MantenerPlataforma(Plataforma plataforma, SqlConnection cn)
        {
            bool respuesta = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Plataforma_Mantener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@plataformaId", SqlParam.Value(plataforma.PlataformaId));
                    cmd.Parameters.AddWithValue("@identificador", SqlParam.Value(plataforma.Identificador));
                    cmd.Parameters.AddWithValue("@nombre", SqlParam.Value(plataforma.Nombre));
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

        public List<Plataforma> BuscarPlataforma(int? plataformaId, string identificador, string nombre, SqlConnection cn)
        {
            List<Plataforma> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Plataforma_Buscar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@plataformaId", SqlParam.Value(plataformaId));
                    cmd.Parameters.AddWithValue("@identificador", SqlParam.Value(identificador));
                    cmd.Parameters.AddWithValue("@nombre", SqlParam.Value(nombre));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<Plataforma>();
                            while (dr.Read())
                            {
                                lista.Add(new Plataforma
                                {
                                    PlataformaId = dr.GetValue<int>("PlataformaId"),
                                    Identificador = dr.GetValue<string>("Identificador"),
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

        public List<Plataforma> ListarPlataforma(SqlConnection cn)
        {
            List<Plataforma> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Plataforma_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<Plataforma>();
                            while (dr.Read())
                            {
                                lista.Add(new Plataforma
                                {
                                    PlataformaId = dr.GetValue<int>("PlataformaId"),
                                    Identificador = dr.GetValue<string>("Identificador"),
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

        public Plataforma ObtenerPlataforma(int plataformaId, SqlConnection cn)
        {
            Plataforma plataforma = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Plataforma_Obtener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@plataformaId", plataformaId);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            plataforma = new Plataforma();
                            if (dr.Read())
                            {
                                plataforma = new Plataforma
                                {
                                    PlataformaId = dr.GetValue<int>("PlataformaId"),
                                    Identificador = dr.GetValue<string>("Identificador"),
                                    Nombre = dr.GetValue<string>("Nombre")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                plataforma = null;
            }

            return plataforma;
        }

        public Plataforma ObtenerPlataformaPorIdentificador(string identificador, SqlConnection cn)
        {
            Plataforma plataforma = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Plataforma_ObtenerPorIdentificador", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@identificador", identificador);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            plataforma = new Plataforma();
                            if (dr.Read())
                            {
                                plataforma = new Plataforma
                                {
                                    PlataformaId = dr.GetValue<int>("PlataformaId"),
                                    Identificador = dr.GetValue<string>("Identificador"),
                                    Nombre = dr.GetValue<string>("Nombre")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                plataforma = null;
            }

            return plataforma;
        }
    }
}
