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
    public class ProvinciaDa
    {
        public List<Provincia> ListarProvincia(string paisId, int? departamentoId, SqlConnection cn)
        {
            List<Provincia> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Provincia_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@paisId", SqlParam.Value(paisId));
                    cmd.Parameters.AddWithValue("@departamentoId", SqlParam.Value(departamentoId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<Provincia>();
                            while (dr.Read())
                            {
                                lista.Add(new Provincia
                                {
                                    PaisId = dr.GetValue<string>("PaisId"),
                                    DepartamentoId = dr.GetValue<int>("DepartamentoId"),
                                    ProvinciaId = dr.GetValue<int>("ProvinciaId"),
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
