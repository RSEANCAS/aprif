using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class Cliente:InformacionRegistro
    {
        public string EmisorId { get; set; }
        public string TipoDocumentoIdentidad { get; set; }
        public string ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string UbigeoCodigo { get; set; }
        public string UbigeoDescripcion { get; set; }
        public string Correo { get; set; }
        public List<SucursalCliente> ListaSucursal { get; set; }

    }
}
