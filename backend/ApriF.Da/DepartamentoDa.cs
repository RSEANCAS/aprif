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
    public class DepartamentoDa
    {
        public List<Departamento> ListarDepartamento(string paisId, SqlConnection cn)
        {
            List<Departamento> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Departamento_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@paisId", SqlParam.Value(paisId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<Departamento>();
                            while (dr.Read())
                            {
                                lista.Add(new Departamento
                                {
                                    PaisId = dr.GetValue<string>("PaisId"),
                                    DepartamentoId = dr.GetValue<int>("DepartamentoId"),
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
