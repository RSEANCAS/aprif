using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class Emisor
    {
        public string EmisorId { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string Eslogan { get; set; }
        public bool DeBaja { get; set; }
        public List<Usuario> ListaUsuario { get; set; }
        public List<Serie> ListaSerie { get; set; }
        public List<SerieUsuario> ListaSerieUsuario { get; set; }
        public List<Sucursal> ListaSucursal { get; set; }
        public List<SucursalUsuario> ListaSucursalUsuario { get; set; }
    }
}
