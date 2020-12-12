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
    [RoutePrefix("api/producto")]
    public class ProductoController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("obtenerproducto")]
        public Producto ObtenerProducto(string emisorId, string productoId)
        {
            ProductoBl c = new ProductoBl();
            return c.ObtenerProducto(emisorId, productoId);
        }
    }
}
