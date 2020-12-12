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
    [RoutePrefix("api/provincia")]
    public class ProvinciaController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("listarprovincia")]
        public List<Provincia> ListarProvincia(string paisId = null, int? departamentoId = null)
        {
            ProvinciaBl e = new ProvinciaBl();
            return e.ListarProvincia(paisId, departamentoId);
        }
    }
}
