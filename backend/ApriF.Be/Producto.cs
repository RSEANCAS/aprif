using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class Producto
    {
        public string ProductoId { get; set; }
        public string Descripcion { get; set; }
        public string CodigoSunat { get; set; }
        public string UnidadMedidaId { get; set; }
        public string AlmacenId { get; set; }
        public string TipoAfectacionIgvId { get; set; }
        public string TipoCalculo { get; set; }
        public decimal Monto { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
    }
}
