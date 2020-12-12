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
    [RoutePrefix("api/reporteventa")]
    public class ReporteVentaController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("listarreporteventa")]
        public List<ReporteVenta> ListarReporteVenta()
        {
            ReporteVentaBl rv = new ReporteVentaBl();
            return rv.ListarReporteVenta();
        }
    }
}
