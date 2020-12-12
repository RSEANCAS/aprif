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
    [RoutePrefix("api/plataforma")]
    public class PlataformaController : ApiController
    {
        PlataformaBl plataformaBl = new PlataformaBl();

        [HttpGet]
        [HttpPost]
        [Route("buscarplataforma")]
        public List<Plataforma> BuscarPlataforma(int? plataformaId = null, string identificador = null, string nombre = null)
        {
            return plataformaBl.BuscarPlataforma(plataformaId, identificador, nombre);
        }

        [HttpGet]
        [HttpPost]
        [Route("listarplataforma")]
        public List<Plataforma> ListarPlataforma()
        {
            return plataformaBl.ListarPlataforma();
        }

        [HttpGet]
        [HttpPost]
        [Route("obtenerplataforma")]
        public Plataforma ObtenerPlataforma(int plataformaId)
        {
            return plataformaBl.ObtenerPlataforma(plataformaId);
        }

        [HttpGet]
        [HttpPost]
        [Route("mantenerplataforma")]
        public bool MantenerPlataforma(Plataforma plataforma)
        {
            return plataformaBl.MantenerPlataforma(plataforma);
        }
    }
}
