using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class Factura

    {
        public int SucursalId { get; set; }
        public string TipoOperacion { get; set; }
        public string Serie { get; set; }
        public int Numero { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string TipoMonedaId { get; set; }
        public string EmisorTipoDocumentoIdentidad { get; set; }
        public string EmisorId { get; set; }
        public string EmisorRazonSocial { get; set; }
        public string EmisorDireccion { get; set; }
        public string EmisorUbigeoCodigo { get; set; }
        public string EmisorUbigeoDescripcion { get; set; }
        public string EmisorCorreo { get; set; }
        public string ClienteTipoDocumentoIdentidad { get; set; }
        public string ClienteId { get; set; }
        public string ClienteRazonSocial { get; set; }
        public string ClienteDireccion { get; set; }
        public string ClienteUbigeoCodigo { get; set; }
        public string ClienteUbigeoDescripcion { get; set; }
        public string ClienteCorreo { get; set; }
        public double TotalIgv { get; set; }
        public double TotalIsc { get; set; }
        public double TotalOtrosTributos { get; set; }
        public double TotalOtrosCargos { get; set; }
        public double TotalBaseImponible { get; set; }
        public double TotalDescuento { get; set; }
        public double TotalImporteVenta { get; set; }
        public double TotalImportePagar { get; set; }
        public double TotalICBPER { get; set; }
        public bool EsDetraccion { get; set; }
        public bool EsExportacion { get; set; }
        public bool EsComprobanteFisico { get; set; }
        public string CreadoPor { get; set; }
        public string FechaCreacion { get; set; }
        public string IpCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public string FechaModificacion { get; set; }
        public string IpModificacion { get; set; }
        public List<FacturaDetalle> ListaFacturaDetalle {get;set;}


    }
    public class FacturaDetalle
    {
        public string EmisorId { get; set; }
        public string Serie { get; set; }
        public int Numero { get; set; }
        public int DetalleId { get; set; }
        public string CodigoId { get; set; }
        public string Descripcion { get; set; }
        public string UnidadMedidadId { get; set; }
        public string CodigoSunat { get; set; }
        public string AfectacionIgvId { get; set; }
        public string Concepto { get; set; }
        public double Cantidad { get; set; }
        public double ValorUnitaro { get; set; }
        public double PrecioUnitario { get; set; }
        public double Descuento { get; set; }
        public double DescuentoPorcentaje { get; set; }
        public double BaseImponible { get; set; }
        public double Isc { get; set; }
        public double IscPorcentaje { get; set; }
        public double Igv { get; set; }
        public double IgvPorcentaje { get; set; }
        public double OtrosCargos { get; set; }
        public double OtrosCargosPorcentaje { get; set; }
        public double OtrosTributos { get; set; }
        public double OtrosTributosPorcentaje { get; set; }
        public double ICBPERCantidad { get; set; }
        public double ICBPERMonto { get; set; }
        public double ICBPERTotal { get; set; }
        public double ImporteVenta { get; set; }
    }
}
