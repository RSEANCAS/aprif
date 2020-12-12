using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class Opcion
    {
        public int PlataformaId { get; set; }
        public Plataforma Plataforma { get; set; }
        public int? OpcionPadreId { get; set; }
        public Opcion OpcionPadre { get; set; }
        public int OpcionId { get; set; }
        public string Nombre { get; set; }
        public string Enlace { get; set; }
        public int Orden { get; set; }
        public List<Opcion> ListaOpcionHijo { get; set; }
    }
}
