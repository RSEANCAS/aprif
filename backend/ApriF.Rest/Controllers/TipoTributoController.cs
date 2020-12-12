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
    [RoutePrefix("api/tipotributo")]
    public class TipoTributoController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("listartipotributo")]
        public List<TipoTributo> ListarTipoTributo ()
        {
            TipoTributoBl tt = new TipoTributoBl();
            return tt.ListarTipoTributo();
        }
    }
}
