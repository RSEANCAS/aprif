using ApriF.Be;
using ApriF.Bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Aprif.Rest.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("obtenercliente")]
        public Cliente ObtenerCliente(string emisorId,string clienteId, string tipodocumentoId)
        {
            ClienteBl c = new ClienteBl();
            return c.ObtenerCliente(emisorId, clienteId, tipodocumentoId);
        }
    }
}
