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
    [RoutePrefix("api/factura")]
    public class FacturaController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("registrafactura")]
        public string RegistraFactura(Factura factura)
        {
            FacturaBl f = new FacturaBl();
            return f.RegistraFactura(factura);
        }
    }
}
