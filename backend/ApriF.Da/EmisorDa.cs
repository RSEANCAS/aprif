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
    public class EmisorDa
    {
        public bool MantenerEmisor(Emisor emisor, SqlConnection cn)
        {
            bool respuesta=false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Emisor_Mantener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisor.EmisorId));
                    cmd.Parameters.AddWithValue("@razonsocial", SqlParam.Value(emisor.RazonSocial));
                    cmd.Parameters.AddWithValue("@nombreComercial",SqlParam.Value(emisor.NombreComercial));
                    cmd.Parameters.AddWithValue("@eslogan",SqlParam.Value(emisor.Eslogan));
                    cmd.Parameters.AddWithValue("@deBaja",SqlParam.Value(emisor.DeBaja));
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

        //public List<Emisor> ListarEmisor(string emisorId, string razonSocial, string nombreComercial, string eslogan, bool? debaja, SqlConnection cn)
        //{
        //    List<Emisor> lista = null;
        //    try
        //    {
        //        using (SqlCommand cmd = new SqlCommand("usp_Emisor_Listar", cn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));
        //            cmd.Parameters.AddWithValue("@razonSocial", SqlParam.Value(razonSocial));
        //            cmd.Parameters.AddWithValue("@nombreComercial", SqlParam.Value(nombreComercial));
        //            cmd.Parameters.AddWithValue("@eslogan", SqlParam.Value(eslogan));
        //            cmd.Parameters.AddWithValue("@debaja", SqlParam.Value(debaja));

        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                {
        //                    lista = new List<Emisor>();
        //                    if (dr.Read())
        //                    {
        //                        lista.Add(new Emisor
        //                        {
        //                            EmisorId = dr.GetValue<string>("EmisorId"),
        //                            RazonSocial = dr.GetValue<string>("RazonSocial"),
        //                            NombreComercial = dr.GetValue<string>("NombreComercial"),
        //                            Eslogan = dr.GetValue<string>("Eslogan"),
        //                            DeBaja = dr.GetValue<bool>("DeBaja")
        //                        });
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lista = null;
        //    }

        //    return lista;

        //}

        public List<Emisor> BuscarEmisor(string emisorId, string razonSocial, string nombreComercial, string eslogan, bool? debaja, SqlConnection cn)
        {
            List<Emisor> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Emisor_Buscar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));
                    cmd.Parameters.AddWithValue("@razonSocial", SqlParam.Value(razonSocial));
                    cmd.Parameters.AddWithValue("@nombreComercial", SqlParam.Value(nombreComercial));
                    cmd.Parameters.AddWithValue("@eslogan", SqlParam.Value(eslogan));
                    cmd.Parameters.AddWithValue("@debaja", SqlParam.Value(debaja));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<Emisor>();
                            while (dr.Read())
                            {
                                lista.Add(new Emisor
                                {
                                    EmisorId = dr.GetValue<string>("EmisorId"),
                                    RazonSocial = dr.GetValue<string>("RazonSocial"),
                                    NombreComercial = dr.GetValue<string>("NombreComercial"),
                                    Eslogan = dr.GetValue<string>("Eslogan"),
                                    DeBaja = dr.GetValue<bool>("DeBaja")
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

        public Emisor ObtenerEmisor(string emisorId, SqlConnection cn)
        {
            Emisor registro = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Emisor_Obtener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                registro = new Emisor
                                {
                                    EmisorId = dr.GetValue<string>("EmisorId"),
                                    RazonSocial = dr.GetValue<string>("RazonSocial"),
                                    NombreComercial = dr.GetValue<string>("NombreComercial"),
                                    Eslogan = dr.GetValue<string>("Eslogan"),
                                    DeBaja = dr.GetValue<bool>("DeBaja")
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

        public Emisor ObtenerSunatEmisor(string emisorId, SqlConnection cn)
        {
            Emisor registro = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Emisor_ObtenerSunat", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                registro = new Emisor
                                {
                                    EmisorId = dr.GetValue<string>("EmisorId"),
                                    RazonSocial = dr.GetValue<string>("RazonSocial"),
                                    NombreComercial = dr.GetValue<string>("NombreComercial"),
                                    Eslogan = dr.GetValue<string>("Eslogan"),
                                    DeBaja = dr.GetValue<bool>("DeBaja")
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

        public bool ExisteEmisor(string emisorId, SqlConnection cn)
        {
            bool existe = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Emisor_Existe", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));

                    existe = (bool)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                existe = false;
            }

            return existe;

        }
    }
}
