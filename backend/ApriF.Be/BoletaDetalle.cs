using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class BoletaDetalle
    {
        public string EmisorId { get; set; }
        public string Serie { get; set; }
        public int Numero { get; set; }
        public int DetalleId { get; set; }
        public string CodigoId { get; set; }
        public string Descripcion { get; set; }
        public string UnidadMedidadId { get; set; }
        public UnidadMedida UnidadMedidad { get; set; }
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
