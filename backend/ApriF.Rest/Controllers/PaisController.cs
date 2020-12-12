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
    [RoutePrefix("api/pais")]
    public class PaisController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("listarpais")]
        public List<Pais> ListarPais()
        {
            PaisBl e = new PaisBl();
            return e.ListarPais();
        }
    }
}
