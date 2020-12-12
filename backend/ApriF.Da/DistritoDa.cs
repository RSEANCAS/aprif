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
    public class DistritoDa
    {
        public List<Distrito> ListarDistrito(string paisId, int? departamentoId, int? provinciaId, SqlConnection cn)
        {
            List<Distrito> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Distrito_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@paisId", SqlParam.Value(paisId));
                    cmd.Parameters.AddWithValue("@departamentoId", SqlParam.Value(departamentoId));
                    cmd.Parameters.AddWithValue("@provinciaId", SqlParam.Value(provinciaId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<Distrito>();
                            while (dr.Read())
                            {
                                lista.Add(new Distrito
                                {
                                    PaisId = dr.GetValue<string>("PaisId"),
                                    DepartamentoId = dr.GetValue<int>("DepartamentoId"),
                                    ProvinciaId = dr.GetValue<int>("ProvinciaId"),
                                    DistritoId = dr.GetValue<int>("DistritoId"),
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
        /*public Distrito ObtenerDistrito(string distritoId, SqlConnection cn)
        {
            Distrito lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Distrito_Obtener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@distritoId", SqlParam.Value(distritoId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new Distrito();
                            while (dr.Read())
                            {
                                lista.Add(new Distrito
                                {
                                    PaisId = dr.GetValue<string>("PaisId"),
                                    DepartamentoId = dr.GetValue<int>("DepartamentoId"),
                                    ProvinciaId = dr.GetValue<int>("ProvinciaId"),
                                    DistritoId = dr.GetValue<int>("DistritoId"),
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

        }*/
    }
}
