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
    [RoutePrefix("api/tipocomprobante")]
    public class TipoComprobanteController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("listartipocomprobante")]
        public List<TipoComprobante> ListarTipoComprobante()
        {
            TipoComprobanteBl e = new TipoComprobanteBl();
            return e.ListarTipoComprobante();
        }
    }
}
