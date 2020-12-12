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
    [RoutePrefix("api/serie")]
    public class SerieController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("obtenerserie")]
        public Serie ObtenerSerie(string emisorId, string tipoComprobanteId, string serieId)
        {
            SerieBl e = new SerieBl();
            return e.ObtenerSerie(emisorId, tipoComprobanteId, serieId);
        }

        [HttpGet]
        [HttpPost]
        [Route("listarserieportipo")]
        public List<Serie> ListarSeriePorTipo(string emisorId, string tipoComprobanteId)
        {
            SerieBl s = new SerieBl();
            return s.ListarSeriePorTipo(emisorId,tipoComprobanteId);
        }
    }
}
