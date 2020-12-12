using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class Departamento
    {
        public string PaisId { get; set; }
        public Pais Pais { get; set; }
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }
    }
}
