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
    public class BoletaDa
    {
        public int RegistraBoleta(Boleta boleta, SqlConnection cn)
        {
            int numero = 0;
            try
            {
                #region GRABA CABECERA
                using (SqlCommand cmd = new SqlCommand("dbApriFComprobante.dbo.usp_Boleta_Guardar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SucursalId", boleta.SucursalId);
                    cmd.Parameters.AddWithValue("@TipoOperacion", boleta.TipoOperacion);
                    cmd.Parameters.AddWithValue("Serie", boleta.Serie);
                    cmd.Parameters.Add(new SqlParameter {ParameterName= "@Numero",SqlDbType=SqlDbType.VarChar,Size=8,Direction=ParameterDirection.Output,IsNullable=true });
                    cmd.Parameters.AddWithValue("@FechaEmision", boleta.FechaEmision);
                    cmd.Parameters.AddWithValue("@FechaVencimiento", boleta.FechaVencimiento);
                    cmd.Parameters.AddWithValue("@TipoMonedaId", boleta.TipoMonedaId);
                    cmd.Parameters.AddWithValue("@EmisorTipoDocumentoIdentidad", boleta.EmisorTipoDocumentoIdentidad);
                    cmd.Parameters.AddWithValue("@EmisorId", boleta.EmisorId);
                    cmd.Parameters.AddWithValue("@EmisorRazonSocial", boleta.EmisorRazonSocial);
                    cmd.Parameters.AddWithValue("@EmisorDireccion", boleta.EmisorDireccion);
                    cmd.Parameters.AddWithValue("@EmisorUbigeoCodigo", boleta.EmisorUbigeoCodigo);
                    cmd.Parameters.AddWithValue("@EmisorUbigeoDescripcion", boleta.EmisorUbigeoDescripcion);
                    cmd.Parameters.AddWithValue("@EmisorCorreo", boleta.EmisorCorreo);
                    cmd.Parameters.AddWithValue("@ClienteTipoDocumentoIdentidad", boleta.ClienteTipoDocumentoIdentidad);
                    cmd.Parameters.AddWithValue("@ClienteId", boleta.ClienteId);
                    cmd.Parameters.AddWithValue("@ClienteRazonSocial", boleta.ClienteRazonSocial);
                    cmd.Parameters.AddWithValue("@ClienteDireccion", boleta.ClienteDireccion);
                    cmd.Parameters.AddWithValue("@ClienteUbigeoCodigo", boleta.ClienteUbigeoCodigo);
                    cmd.Parameters.AddWithValue("@ClienteUbigeoDescripcion", boleta.ClienteUbigeoDescripcion);
                    cmd.Parameters.AddWithValue("@ClienteCorreo", boleta.ClienteCorreo);
                    cmd.Parameters.AddWithValue("@TotalIgv", boleta.TotalIgv);
                    cmd.Parameters.AddWithValue("@TotalIsc", boleta.TotalIsc);
                    cmd.Parameters.AddWithValue("@TotalOtrosTributos", boleta.TotalOtrosTributos);
                    cmd.Parameters.AddWithValue("@TotalOtrosCargos", boleta.TotalOtrosCargos);
                    cmd.Parameters.AddWithValue("@TotalBaseImponible", boleta.TotalBaseImponible);
                    cmd.Parameters.AddWithValue("@TotalDescuento", boleta.TotalDescuento);
                    cmd.Parameters.AddWithValue("@TotalImporteVenta", boleta.TotalImporteVenta);
                    cmd.Parameters.AddWithValue("@TotalImportePagar", boleta.TotalImportePagar);
                    cmd.Parameters.AddWithValue("@TotalICBPER", boleta.TotalICBPER);
                    cmd.Parameters.AddWithValue("@EsDetraccion", boleta.EsDetraccion);
                    cmd.Parameters.AddWithValue("@EsExportacion", boleta.EsExportacion);
                    cmd.Parameters.AddWithValue("@EsComprobanteFisico", boleta.EsComprobanteFisico);
                    cmd.Parameters.AddWithValue("@CreadoPor", boleta.CreadoPor);
                    cmd.Parameters.AddWithValue("@FechaCreacion", DateTime.Now);
                    cmd.Parameters.AddWithValue("@IpCreacion", boleta.IpCreacion);
                    cmd.Parameters.AddWithValue("@ModificadoPor" , boleta.ModificadoPor);
                    cmd.Parameters.AddWithValue("@FechaModificacion" , DateTime.Now);
                    cmd.Parameters.AddWithValue("@IpModificacion" , boleta.IpModificacion);

                    cmd.ExecuteNonQuery();
                    numero = Convert.ToInt32(cmd.Parameters["@Numero"].Value);

                }
                #endregion

                #region GRABA DETALLE
                foreach (BoletaDetalle detalle in boleta.ListaBoletaDetalle)
                {
                    using (SqlCommand cmddetalle = new SqlCommand("dbApriFComprobante.dbo.usp_BoletaDetalle_Guardar", cn))
                    {
                        cmddetalle.CommandType = CommandType.StoredProcedure;
                        cmddetalle.Parameters.AddWithValue("@EmisorId", boleta.EmisorId);
                        cmddetalle.Parameters.AddWithValue("@Serie", boleta.Serie);
                        cmddetalle.Parameters.AddWithValue("@Numero", numero);
                        cmddetalle.Parameters.AddWithValue("@DetalleId", detalle.DetalleId);
                        cmddetalle.Parameters.AddWithValue("@CodigoId", detalle.CodigoId);
                        cmddetalle.Parameters.AddWithValue("@Descripcion", detalle.Descripcion);
                        cmddetalle.Parameters.AddWithValue("@UnidadMedidadId", detalle.UnidadMedidadId);
                        cmddetalle.Parameters.AddWithValue("@CodigoSunat", detalle.CodigoSunat);
                        cmddetalle.Parameters.AddWithValue("@AfectacionIgvId", detalle.AfectacionIgvId);
                        cmddetalle.Parameters.AddWithValue("@Concepto", detalle.Concepto);
                        cmddetalle.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                        cmddetalle.Parameters.AddWithValue("@ValorUnitaro", detalle.ValorUnitaro);
                        cmddetalle.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
                        cmddetalle.Parameters.AddWithValue("@Descuento", detalle.Descuento);
                        cmddetalle.Parameters.AddWithValue("@DescuentoPorcentaje", detalle.DescuentoPorcentaje);
                        cmddetalle.Parameters.AddWithValue("@BaseImponible", detalle.BaseImponible);
                        cmddetalle.Parameters.AddWithValue("@Isc", detalle.Isc);
                        cmddetalle.Parameters.AddWithValue("@IscPorcentaje", detalle.IscPorcentaje);
                        cmddetalle.Parameters.AddWithValue("@Igv", detalle.Igv);
                        cmddetalle.Parameters.AddWithValue("@IgvPorcentaje", detalle.IgvPorcentaje);
                        cmddetalle.Parameters.AddWithValue("@OtrosCargos", detalle.OtrosCargos);
                        cmddetalle.Parameters.AddWithValue("@OtrosCargosPorcentaje", detalle.OtrosCargosPorcentaje);
                        cmddetalle.Parameters.AddWithValue("@OtrosTributos", detalle.OtrosTributos);
                        cmddetalle.Parameters.AddWithValue("@OtrosTributosPorcentaje", detalle.OtrosTributosPorcentaje);
                        cmddetalle.Parameters.AddWithValue("@ICBPERCantidad", detalle.ICBPERCantidad);
                        cmddetalle.Parameters.AddWithValue("@ICBPERMonto", detalle.ICBPERMonto);
                        cmddetalle.Parameters.AddWithValue("@ICBPERTotal", detalle.ICBPERTotal);
                        cmddetalle.Parameters.AddWithValue("@ImporteVenta", detalle.ImporteVenta);
                        cmddetalle.ExecuteNonQuery();
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                numero = 0;
            }
            return numero;
        }
    }
}
