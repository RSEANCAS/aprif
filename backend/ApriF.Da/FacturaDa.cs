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
    public class FacturaDa 
    {
        public string RegistraFactura(Factura factura, SqlConnection cn)
        {
            string retorno = "";
            int numero= 0;
            try
            {
                #region GRABA CABECERA
                using (SqlCommand cmd = new SqlCommand("dbApriFComprobante.dbo.usp_Factura_Guardar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SucursalId", factura.SucursalId);
                    cmd.Parameters.AddWithValue("@TipoOperacion", factura.TipoOperacion);
                    cmd.Parameters.AddWithValue("@Serie", factura.Serie);
                    //cmd.Parameters.AddWithValue("Numero", factura.Numero);
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@Numero", SqlDbType = SqlDbType.VarChar, Size = 8, Direction = ParameterDirection.Output, IsNullable = true });
                    cmd.Parameters.AddWithValue("@FechaEmision", factura.FechaEmision);
                    cmd.Parameters.AddWithValue("@FechaVencimiento", factura.FechaVencimiento);
                    cmd.Parameters.AddWithValue("@TipoMonedaId", factura.TipoMonedaId);
                    cmd.Parameters.AddWithValue("@EmisorTipoDocumentoIdentidad", factura.EmisorTipoDocumentoIdentidad);
                    cmd.Parameters.AddWithValue("@EmisorId", factura.EmisorId);
                    cmd.Parameters.AddWithValue("@EmisorRazonSocial", factura.EmisorRazonSocial);
                    cmd.Parameters.AddWithValue("@EmisorDireccion", factura.EmisorDireccion);
                    cmd.Parameters.AddWithValue("@EmisorUbigeoCodigo", factura.EmisorUbigeoCodigo);
                    cmd.Parameters.AddWithValue("@EmisorUbigeoDescripcion", factura.EmisorUbigeoDescripcion);
                    cmd.Parameters.AddWithValue("@EmisorCorreo", factura.EmisorCorreo);
                    cmd.Parameters.AddWithValue("@ClienteTipoDocumentoIdentidad", factura.ClienteTipoDocumentoIdentidad);
                    cmd.Parameters.AddWithValue("@ClienteId", factura.ClienteId);
                    cmd.Parameters.AddWithValue("@ClienteRazonSocial", factura.ClienteRazonSocial);
                    cmd.Parameters.AddWithValue("@ClienteDireccion", factura.ClienteDireccion);
                    cmd.Parameters.AddWithValue("@ClienteUbigeoCodigo", factura.ClienteUbigeoCodigo);
                    cmd.Parameters.AddWithValue("@ClienteUbigeoDescripcion", factura.ClienteUbigeoDescripcion);
                    cmd.Parameters.AddWithValue("@ClienteCorreo", factura.ClienteCorreo);
                    cmd.Parameters.AddWithValue("@TotalIgv", factura.TotalIgv);
                    cmd.Parameters.AddWithValue("@TotalIsc", factura.TotalIsc);
                    cmd.Parameters.AddWithValue("@TotalOtrosTributos", factura.TotalOtrosTributos);
                    cmd.Parameters.AddWithValue("@TotalOtrosCargos", factura.TotalOtrosCargos);
                    cmd.Parameters.AddWithValue("@TotalBaseImponible", factura.TotalBaseImponible);
                    cmd.Parameters.AddWithValue("@TotalDescuento", factura.TotalDescuento);
                    cmd.Parameters.AddWithValue("@TotalImporteVenta", factura.TotalImporteVenta);
                    cmd.Parameters.AddWithValue("@TotalImportePagar", factura.TotalImportePagar);
                    cmd.Parameters.AddWithValue("@TotalICBPER", factura.TotalICBPER);
                    cmd.Parameters.AddWithValue("@EsDetraccion", factura.EsDetraccion);
                    cmd.Parameters.AddWithValue("@EsExportacion", factura.EsExportacion);
                    cmd.Parameters.AddWithValue("@EsComprobanteFisico", factura.EsComprobanteFisico);
                    cmd.Parameters.AddWithValue("@CreadoPor", factura.CreadoPor);
                    cmd.Parameters.AddWithValue("@FechaCreacion", DateTime.Now);
                    cmd.Parameters.AddWithValue("@IpCreacion", factura.IpCreacion);
                    cmd.Parameters.AddWithValue("@ModificadoPor", factura.ModificadoPor);
                    cmd.Parameters.AddWithValue("@FechaModificacion", DateTime.Now);
                    cmd.Parameters.AddWithValue("@IpModificacion", factura.IpModificacion);

                    cmd.ExecuteNonQuery();

                    numero = Convert.ToInt32(cmd.Parameters["@Numero"].Value);
                }
#endregion

                #region GRABA DETALLE
                foreach (FacturaDetalle detalle in factura.ListaFacturaDetalle)
                    {
                        using (SqlCommand cmddetalle = new SqlCommand("dbApriFComprobante.dbo.usp_FacturaDetalle_Guardar", cn))
                        {
                            cmddetalle.CommandType = CommandType.StoredProcedure;

                            cmddetalle.Parameters.AddWithValue("EmisorId", factura.EmisorId);
                            cmddetalle.Parameters.AddWithValue("Serie", factura.Serie);
                            cmddetalle.Parameters.AddWithValue("Numero", numero);
                            cmddetalle.Parameters.AddWithValue("DetalleId", detalle.DetalleId);
                            cmddetalle.Parameters.AddWithValue("CodigoId", detalle.CodigoId);
                            cmddetalle.Parameters.AddWithValue("Descripcion", detalle.Descripcion);
                            cmddetalle.Parameters.AddWithValue("UnidadMedidadId", detalle.UnidadMedidadId);
                            cmddetalle.Parameters.AddWithValue("CodigoSunat", detalle.CodigoSunat);
                            cmddetalle.Parameters.AddWithValue("AfectacionIgvId", detalle.AfectacionIgvId);
                            cmddetalle.Parameters.AddWithValue("Concepto", detalle.Concepto);
                            cmddetalle.Parameters.AddWithValue("Cantidad", detalle.Cantidad);
                            cmddetalle.Parameters.AddWithValue("ValorUnitaro", detalle.ValorUnitaro);
                            cmddetalle.Parameters.AddWithValue("PrecioUnitario", detalle.PrecioUnitario);
                            cmddetalle.Parameters.AddWithValue("Descuento", detalle.Descuento);
                            cmddetalle.Parameters.AddWithValue("DescuentoPorcentaje", detalle.DescuentoPorcentaje);
                            cmddetalle.Parameters.AddWithValue("BaseImponible", detalle.BaseImponible);
                            cmddetalle.Parameters.AddWithValue("Isc", detalle.Isc);
                            cmddetalle.Parameters.AddWithValue("IscPorcentaje", detalle.IscPorcentaje);
                            cmddetalle.Parameters.AddWithValue("Igv", detalle.Igv);
                            cmddetalle.Parameters.AddWithValue("IgvPorcentaje", detalle.IgvPorcentaje);
                            cmddetalle.Parameters.AddWithValue("OtrosCargos", detalle.OtrosCargos);
                            cmddetalle.Parameters.AddWithValue("OtrosCargosPorcentaje", detalle.OtrosCargosPorcentaje);
                            cmddetalle.Parameters.AddWithValue("OtrosTributos", detalle.OtrosTributos);
                            cmddetalle.Parameters.AddWithValue("OtrosTributosPorcentaje", detalle.OtrosTributosPorcentaje);
                            cmddetalle.Parameters.AddWithValue("ICBPERCantidad", detalle.ICBPERCantidad);
                            cmddetalle.Parameters.AddWithValue("ICBPERMonto", detalle.ICBPERMonto);
                            cmddetalle.Parameters.AddWithValue("ICBPERTotal", detalle.ICBPERTotal);
                            cmddetalle.Parameters.AddWithValue("ImporteVenta", detalle.ImporteVenta);
                            cmddetalle.ExecuteNonQuery();
                        }
                    }
                #endregion
                retorno = "BIEN";
            }
            catch (Exception ex)
            {
                numero = 0;
                retorno = ex.Message.ToString();
            }
            return retorno;
        }
    }
}
