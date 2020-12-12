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
    [RoutePrefix("api/boleta")]
    public class BoletaController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("registraboleta")]
        public int RegistraBoleta(Boleta boleta)
        {
            BoletaBl b = new BoletaBl();
            return b.RegistraBoleta(boleta);
        }


    }
}
