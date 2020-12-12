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
    [RoutePrefix("api/opcion")]
    public class OpcionController : ApiController
    {
        OpcionBl opcionBl = new OpcionBl();

        [HttpGet]
        [HttpPost]
        [Route("manteneropcion")]
        public bool MantenerOpcion(Opcion opcion)
        {
            return opcionBl.MantenerOpcion(opcion);
        }

        [HttpGet]
        [HttpPost]
        [Route("actualizarordenopcion")]
        public bool ActualizarOrdenOpcion(int plataformaId, int opcionId, int? opcionPadreId, bool accionOrden)
        {
            return opcionBl.ActualizarOrdenOpcion(plataformaId, opcionId, opcionPadreId, accionOrden);
        }

        [HttpGet]
        [HttpPost]
        [Route("buscaropcion")]
        public List<Opcion> BuscarOpcion(int? plataformaId = null, int? opcionId = null, int? opcionPadreId = null, string nombre = null, string enlace = null, int? orden = null)
        {
            return opcionBl.BuscarOpcion(plataformaId, opcionId, opcionPadreId, nombre, enlace, orden);
        }

        [HttpGet]
        [HttpPost]
        [Route("listaropcion")]
        public List<Opcion> ListarOpcion(int? plataformaId = null)
        {
            return opcionBl.ListarOpcion(plataformaId);
        }

        [HttpGet]
        [HttpPost]
        [Route("obteneropcion")]
        public Opcion ObtenerOpcion(int plataformaId, int opcionId)
        {
            return opcionBl.ObtenerOpcion(plataformaId, opcionId);
        }

        [HttpGet]
        [HttpPost]
        [Route("listaropcionporperfilyopcionpadre")]
        public List<Opcion> ListarOpcionPorPerfilYOpcionPadre(int plataformaId, string perfilId, int? opcionPadreId = null)
        {
            return opcionBl.ListarOpcionPorPerfilYOpcionPadre(plataformaId, perfilId, opcionPadreId);
        }
    }
}
