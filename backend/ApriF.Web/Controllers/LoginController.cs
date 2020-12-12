using ApriF.Be;
using ApriF.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ApriF.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Validar(string emisorId, string usuarioId, string clave)
        {
            WebClient webClient = new WebClient();
            string usuarioString = webClient.DownloadString($"http://localhost/aprif.rest/UsuarioRest.svc/UsuarioObtener/{emisorId}/{usuarioId}");

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(usuarioString);

            bool existsUsuario = usuario != null;

            if(!existsUsuario)
            {
                TempData["login_validar_msg_error"] = "Usuario no existe";
                return RedirectToAction("Index", "Login");
            }

            if (usuario.FlagBaja)
            {
                TempData["login_validar_msg_error"] = "Usuario ha sido dado de baja";
                return RedirectToAction("Index", "Login");
            }

            string claveDesencriptar = Encriptacion.Decrypt_AES(usuario.Clave, usuario.KeyAES, usuario.IVAES);

            if(clave != claveDesencriptar)
            {
                TempData["login_validar_msg_error"] = "Contraseña incorrecta";
                return RedirectToAction("Index", "Login");
            }

            Session["usuario"] = usuario;
            return RedirectToAction("Index", "Dashboard");
        }
    }
}