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
    [RoutePrefix("api/distrito")]
    public class DistritoController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("listardistrito")]
        public List<Distrito> ListarDistrito(string paisId = null, int? departamentoId = null, int? provinciaId = null)
        {
            DistritoBl e = new DistritoBl();
            return e.ListarDistrito(paisId, departamentoId, provinciaId);
        }
    }
}
