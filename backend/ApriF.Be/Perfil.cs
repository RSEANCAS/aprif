using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class Perfil
    {
        public int PlataformaId { get; set; }
        public Plataforma Plataforma { get; set; }
        public int PerfilId { get; set; }
        public string Nombre { get; set; }
    }
}
