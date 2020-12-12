using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class UsuarioSys
    {
        public string UsuarioSysId { get; set; }
        public byte[] Clave { get; set; }
        public byte[] KeyAES { get; set; }
        public byte[] IVAES { get; set; }
        public bool FlagResetearClave { get; set; }
        public List<Opcion> ListaOpcion { get; set; }
    }
}
