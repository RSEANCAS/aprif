using Aprif.Rest.Controllers.Jwt;
using Aprif.Rest.Models;
using ApriF.Be;
using ApriF.Bl;
using ApriF.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Aprif.Rest.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        EmisorBl emisorBl = new EmisorBl();
        UsuarioBl usuarioBl = new UsuarioBl();

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginModel login)
        {
            if (login == null) return Unauthorized();
            //throw new HttpResponseException(HttpStatusCode.BadRequest);

            bool isFieldEmpty = (login.ruc ?? "").Trim() == "" || (login.usuario ?? "").Trim() == "" || (login.contraseña ?? "").Trim() == "";

            List<string> message = null;

            if ((login.ruc ?? "").Trim() == "")
            {
                message = message ?? new List<string>();
                message.Add("ruc");
            }

            if ((login.usuario ?? "").Trim() == "")
            {
                message = message ?? new List<string>();
                message.Add("usuario");
            }

            if ((login.contraseña ?? "").Trim() == "")
            {
                message = message ?? new List<string>();
                message.Add("contraseña");
            }

            if (isFieldEmpty) throw new HttpRequestException($"Se encontraron los siguientes campos vacíos: {string.Join(", ", message.ToArray())}");

            Emisor emisor = emisorBl.ObtenerEmisor(login.ruc);

            if (emisor == null) throw new HttpRequestException($"No se encontró el ruc {login.ruc} ");

            Usuario usuario = usuarioBl.ObtenerUsuario(login.ruc, login.usuario);

            if (usuario == null) throw new HttpRequestException($"No se encontró el usuario {login.usuario} ");

            string claveBinaryText = string.Join("", usuario.Clave.Select(x => x.ToString("x2")).ToArray());

            bool isCredentialValid = login.contraseña.ToLower() == claveBinaryText.ToLower();

            if (isCredentialValid) throw new HttpRequestException($"La contraseña es incorrecta");

            //TODO: Validate credentials Correctly, this code is only for demo !!
            if (isCredentialValid)
            {
                string tokenUser = $"{login.ruc}{login.usuario}";
                string token = TokenGenerator.GenerateTokenJwt(tokenUser);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
