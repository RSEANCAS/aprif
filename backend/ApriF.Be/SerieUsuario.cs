using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class SerieUsuario : InformacionRegistro
    {
        public string EmisorId { get; set; }
        public string TipoComprobanteId { get; set; }
        public string SerieId { get; set; }
        public string UsuarioId { get; set; }
        public Serie Serie { get; set; }
        public Usuario Usuario { get; set; }
    }
}
