using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class Sucursal : InformacionRegistro
    {
        public string EmisorId { get; set; }
        public Emisor Emisor { get; set; }
        public int SucursalId { get; set; }
        public string CodigoSunat { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Referencia { get; set; }
        public bool FlagDireccionFiscal { get; set; }
        public string PaisId { get; set; }
        public string DepartamentoId { get; set; }
        public string ProvinciaId { get; set; }
        public string DistritoId { get; set; }
        public Distrito Distrito { get; set; }
    }
}
