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
    [RoutePrefix("api/tipoafectacionigv")]
    public class TipoAfectacionIgvController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("listartipoafectacionigv")]
        public List<TipoAfectacionIgv> ListarTipoOperacion()
        {
            TipoAfectacionIgvBl tai = new TipoAfectacionIgvBl();
            return tai.ListarTipoAfectacionIgv();
        }
    }
}
