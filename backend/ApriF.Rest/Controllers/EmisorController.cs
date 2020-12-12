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
    [RoutePrefix("api/emisor")]
    public class EmisorController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("manteneremisor")]
        public bool MantenerEmisor(Emisor emisor)
        {
            EmisorBl e = new EmisorBl();
            return e.MantenerEmisor(emisor);
        }

        [HttpGet]
        [HttpPost]
        [Route("buscaremisor")]
        public List<Emisor> BuscarEmisor(string emisorId = null, string razonSocial = null, string nombreComercial = null, string eslogan = null, bool? debaja = null)
        {
            EmisorBl e = new EmisorBl();
            return e.BuscarEmisor(emisorId, razonSocial, nombreComercial, eslogan, debaja);
        }

        [HttpGet]
        [HttpPost]
        [Route("obteneremisor")]
        public Emisor ObtenerEmisor(string emisorId = null)
        {
            EmisorBl e = new EmisorBl();
            return e.ObtenerEmisor(emisorId);
        }

        [HttpGet]
        [HttpPost]
        [Route("obtenersunatemisor")]
        public Emisor ObtenerSunatEmisor(string emisorId = null)
        {
            EmisorBl e = new EmisorBl();
            return e.ObtenerSunatEmisor(emisorId);
        }

        [HttpGet]
        [HttpPost]
        [Route("existeemisor")]
        public bool ExisteEmisor(string emisorId = null)
        {
            EmisorBl e = new EmisorBl();
            return e.ExisteEmisor(emisorId);
        }
    }
}
