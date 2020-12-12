using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class Usuario : InformacionRegistro
    {
        public string EmisorId { get; set; }
        public string UsuarioId { get; set; }
        public byte[] Clave { get; set; }
        public byte[] KeyAES { get; set; }
        public byte[] IVAES { get; set; }
        public bool FlagResetearClave { get; set; }
        public bool FlagUsuarioSistema { get; set; }
        public bool FlagBaja { get; set; }
        public int SucursalesAsignadas { get; set; }
    }
}