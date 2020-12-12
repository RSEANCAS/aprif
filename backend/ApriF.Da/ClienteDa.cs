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
    public class ClienteDa
    {
        public Cliente ObtenerCliente(string emisorId,string clienteId,string tipodocumentoId, SqlConnection cn)
        {
            Cliente registro = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Cliente_Obtener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));
                    cmd.Parameters.AddWithValue("@clienteId", SqlParam.Value(clienteId));
                    cmd.Parameters.AddWithValue("@tipodocumentoId", SqlParam.Value(tipodocumentoId)); 

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                registro = new Cliente
                                {
                                    EmisorId = dr.GetValue<string>("EmisorId"),
                                    TipoDocumentoIdentidad = dr.GetValue<string>("TipoDocumentoIdentidad"),
                                    ClienteId = dr.GetValue<string>("ClienteId"),
                                    Nombre = dr.GetValue<string>("Nombre"),
                                    Correo=dr.GetValue<string>("Correo")
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
