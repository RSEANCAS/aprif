using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class Serie : InformacionRegistro
    {
        public string EmisorId { get; set; }
        public TipoComprobante TipoComprobante { get; set; }
        public string TipoComprobanteId { get; set; }
        public string SerieId { get; set; }
        public int Inicial { get; set; }
        public int Final { get; set; }
        public int Actual { get; set; }
        public bool EsSerieFisica { get; set; }
    }
}
