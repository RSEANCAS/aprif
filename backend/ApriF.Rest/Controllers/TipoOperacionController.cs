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
    [RoutePrefix("api/tipooperacion")]
    public class TipoOperacionController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("listartipooperacion")]
        public List<TipoOperacion> ListarTipoOperacion()
        {
            TipoOperacionBl e = new TipoOperacionBl();
            return e.ListarTipoOperacion();
        }
    }
}
