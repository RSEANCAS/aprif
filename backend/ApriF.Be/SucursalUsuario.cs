using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class SucursalUsuario : InformacionRegistro
    {
        public string EmisorId { get; set; }
        public string SucursalId { get; set; }
        public string UsuarioId { get; set; }
        public Sucursal Sucursal { get; set; }
        public Usuario Usuario { get; set; }
    }
}
