using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class Boleta
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
        public List<BoletaDetalle> ListaBoletaDetalle { get; set; }
    }
    
}
