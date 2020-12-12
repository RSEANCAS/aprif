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
    [RoutePrefix("api/unidadmedida")]
    public class UnidadMedidaController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("listarunidadmedida")]
        public List<UnidadMedida> ListarUnidadMedida()
        {
            UnidadMedidaBl um = new UnidadMedidaBl();
            return um.ListarUnidadMedida();
        }
    }
}
