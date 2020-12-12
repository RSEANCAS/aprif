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
    public class OpcionDa
    {
        public bool MantenerOpcion(Opcion opcion, SqlConnection cn)
        {
            bool respuesta = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Opcion_Mantener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@plataformaId", SqlParam.Value(opcion.PlataformaId));
                    cmd.Parameters.AddWithValue("@opcionId", SqlParam.Value(opcion.OpcionId));
                    cmd.Parameters.AddWithValue("@opcionPadreId", SqlParam.Value(opcion.OpcionPadreId));
                    cmd.Parameters.AddWithValue("@nombre", SqlParam.Value(opcion.Nombre));
                    cmd.Parameters.AddWithValue("@enlace", SqlParam.Value(opcion.Enlace));
                    //cmd.Parameters.AddWithValue("@orden", SqlParam.Value(opcion.Orden));
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

        public bool ActualizarOrdenOpcion(int plataformaId, int opcionId, int? opcionPadreId, bool accionOrden, SqlConnection cn)
        {
            bool respuesta = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Opcion_ActualizarOrden", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@plataformaId", SqlParam.Value(plataformaId));
                    cmd.Parameters.AddWithValue("@opcionId", SqlParam.Value(opcionId));
                    cmd.Parameters.AddWithValue("@opcionPadreId", SqlParam.Value(opcionPadreId));
                    cmd.Parameters.AddWithValue("@accionOrden", SqlParam.Value(accionOrden));
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

        public List<Opcion> BuscarOpcion(int? plataformaId, int? opcionId, int ? opcionPadreId, string nombre, string enlace, int? orden, SqlConnection cn)
        {
            List<Opcion> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Opcion_Buscar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@plataformaId", SqlParam.Value(plataformaId));
                    cmd.Parameters.AddWithValue("@opcionId", SqlParam.Value(opcionId));
                    cmd.Parameters.AddWithValue("@opcionPadreId", SqlParam.Value(opcionPadreId));
                    cmd.Parameters.AddWithValue("@nombre", SqlParam.Value(nombre));
                    cmd.Parameters.AddWithValue("@enlace", SqlParam.Value(enlace));
                    cmd.Parameters.AddWithValue("@orden", SqlParam.Value(orden));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<Opcion>();
                            while (dr.Read())
                            {
                                lista.Add(new Opcion
                                {
                                    PlataformaId = dr.GetValue<int>("PlataformaId"),
                                    Plataforma = new Plataforma { 
                                        PlataformaId = dr.GetValue<int>("PlataformaId"),
                                        Identificador = dr.GetValue<string>("PlataformaIdentificador"),
                                        Nombre = dr.GetValue<string>("PlataformaNombre")
                                    },
                                    OpcionId = dr.GetValue<int>("OpcionId"),
                                    OpcionPadreId = dr.GetValue<int?>("OpcionPadreId"),
                                    OpcionPadre = dr.GetValue<int?>("OpcionPadreId") == null ? null : new Opcion {
                                        OpcionId = dr.GetValue<int>("OpcionPadreId"),
                                        Nombre = dr.GetValue<string>("OpcionPadreNombre")
                                    },
                                    Nombre = dr.GetValue<string>("Nombre"),
                                    Enlace = dr.GetValue<string>("Enlace"),
                                    Orden = dr.GetValue<int>("Orden")
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

        public List<Opcion> ListarOpcion(int? plataformaId, SqlConnection cn)
        {
            List<Opcion> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Opcion_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@plataformaId", SqlParam.Value(plataformaId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<Opcion>();
                            while (dr.Read())
                            {
                                lista.Add(new Opcion
                                {
                                    PlataformaId = dr.GetValue<int>("PlataformaId"),
                                    OpcionId = dr.GetValue<int>("OpcionId"),
                                    OpcionPadreId = dr.GetValue<int?>("OpcionPadreId"),
                                    Nombre = dr.GetValue<string>("Nombre"),
                                    Enlace = dr.GetValue<string>("Enlace"),
                                    Orden = dr.GetValue<int>("Orden")
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

        public Opcion ObtenerOpcion(int plataformaId, int opcionId, SqlConnection cn)
        {
            Opcion opcion = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Opcion_Obtener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@plataformaId", plataformaId);
                    cmd.Parameters.AddWithValue("@opcionId", opcionId);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            opcion = new Opcion();
                            if (dr.Read())
                            {
                                opcion = new Opcion
                                {
                                    PlataformaId = dr.GetValue<int>("PlataformaId"),
                                    OpcionId = dr.GetValue<int>("OpcionId"),
                                    OpcionPadreId = dr.GetValue<int?>("OpcionPadreId"),
                                    Nombre = dr.GetValue<string>("Nombre"),
                                    Enlace = dr.GetValue<string>("Enlace"),
                                    Orden = dr.GetValue<int>("Orden")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                opcion = null;
            }

            return opcion;
        }

        public List<Opcion> ListarOpcionPorPerfilYOpcionPadre(int plataformaId, string listaPerfilIdString, int? opcionPadreId, SqlConnection cn)
        {
            List<Opcion> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Perfil_ListarPorPerfilYOpcionPadre", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@plataformaId", SqlParam.Value(plataformaId));
                    cmd.Parameters.AddWithValue("@perfilId", SqlParam.Value(listaPerfilIdString));
                    cmd.Parameters.AddWithValue("@opcionPadreId", SqlParam.Value(opcionPadreId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<Opcion>();
                            while (dr.Read())
                            {
                                lista.Add(new Opcion
                                {
                                    PlataformaId = dr.GetValue<int>("PlataformaId"),
                                    OpcionId = dr.GetValue<int>("OpcionId"),
                                    OpcionPadreId = dr.GetValue<int?>("OpcionPadreId"),
                                    Nombre = dr.GetValue<string>("Nombre"),
                                    Enlace = dr.GetValue<string>("Enlace"),
                                    Orden = dr.GetValue<int>("Orden")
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
