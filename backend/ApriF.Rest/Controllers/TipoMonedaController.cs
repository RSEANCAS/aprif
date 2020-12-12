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
    [RoutePrefix("api/tipomoneda")]
    public class TipoMonedaController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("listartipomoneda")]
        public List<TipoMoneda> ListarTipoMoneda()
        {
            TipoMonedaBl tm = new TipoMonedaBl();
            return tm.ListarTipoMoneda();
        }

    }
}
