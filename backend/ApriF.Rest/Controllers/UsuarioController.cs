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
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("obtenerusuario")]
        public Usuario ObtenerUsuario(string emisorId, string usuarioId)
        {
            UsuarioBl U = new UsuarioBl();

            //return new UsuarioBl().ObtenerUsuario(emisorId,usuarioId);
            return U.ObtenerUsuario(emisorId, usuarioId);
        }

    }
}
