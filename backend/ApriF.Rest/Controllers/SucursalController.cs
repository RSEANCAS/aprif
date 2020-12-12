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
    [RoutePrefix("api/sucursal")]
    public class SucursalController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("obtenersucursal")]
        public Sucursal ObtenerSucursal(string emisorId, string sucursalId)
        {
            SucursalBl e = new SucursalBl();
            return e.ObtenerSucursal(emisorId, sucursalId);
        }
        [HttpGet]
        [HttpPost]
        [Route("listarsucursal")]
        public List<Sucursal> ListarSucursal(string emisorId)
        {
            SucursalBl s = new SucursalBl();
            return s.ListarSucursal(emisorId);
        }
    }
}
