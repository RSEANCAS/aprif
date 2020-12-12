using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class ReporteVenta
    {
        public string TipoComprobanteId { get; set; }
        public int SucursalId { get; set; }
        public string TipoOperacion { get; set; }
        public string ComprobanteInfo { get; set; }
        public string Serie { get; set; }
        public int Numero { get; set; }
        public DateTime FechaEmision { get; set; }
        public string TipoMonedaId { get; set; }
        public string ClienteInfo { get; set; }
        public string ClienteId { get; set; }
        public string ClienteRazonSocial { get; set; }
        public decimal TotalImportePagar { get; set; }

    }
}
