using ApriF.Be;
using ApriF.Util;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Da
{
    public class ReporteVentaDa
    {
        public List<ReporteVenta> ListarReporteVenta(SqlConnection cn)
        {
            List<ReporteVenta> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_ReporteVenta_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmisorId", "");
                    cmd.Parameters.AddWithValue("@TipoComprobante", "");
                    cmd.Parameters.AddWithValue("@FechaInicio", DateTime.Now);
                    cmd.Parameters.AddWithValue("@FechaFin", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Serie", "");
                    cmd.Parameters.AddWithValue("@Numero", 0);
                    cmd.Parameters.AddWithValue("@ClienteId", "");
                    cmd.Parameters.AddWithValue("@ClienteNombre", "");

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<ReporteVenta>();
                            while (dr.Read())
                            {
                                lista.Add(new ReporteVenta
                                {
                                    TipoComprobanteId = dr.GetValue<string>("TipoComprobanteId"),
                                    SucursalId = dr.GetValue<int>("SucursalId"),
                                    TipoOperacion= dr.GetValue<string>("TipoOperacion"),
                                    ComprobanteInfo=dr.GetValue<string>("ComprobanteInfo"),
                                    Serie= dr.GetValue<string>("Serie"),
                                    Numero= dr.GetValue<int>("Numero"),
                                    FechaEmision= dr.GetValue<DateTime>("FechaEmision"),
                                    TipoMonedaId= dr.GetValue<string>("TipoMonedaId"),
                                    ClienteInfo=dr.GetValue<string>("ClienteInfo"),
                                    ClienteId= dr.GetValue<string>("ClienteId"),
                                    ClienteRazonSocial= dr.GetValue<string>("ClienteRazonSocial"),
                                    TotalImportePagar= dr.GetValue<decimal>("TotalImportePagar")
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
