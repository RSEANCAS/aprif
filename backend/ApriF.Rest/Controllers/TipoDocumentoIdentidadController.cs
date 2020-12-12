using ApriF.Bl;
using ApriF.Be;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Aprif.Rest.Controllers
{
    [RoutePrefix("api/tipodocumentoidentidad")]
    public class TipoDocumentoIdentidadController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("listartipodocumentoidentidad")]
        public List<TipoDocumentoIdentidad> ListarTipoDocumentoIdentidad()
        {
            TipoDocumentoIdentidadBl tdi = new TipoDocumentoIdentidadBl();
            return tdi.ListarTipoDocumentoIdentidad();
        }
    }
}
