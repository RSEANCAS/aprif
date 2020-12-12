using ApriF.Be;
using ApriF.Bl;
using ApriF.Util;
using ApriF.Web.Admin.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApriF.Web.Admin.Controllers
{
    public class LoginController : Controller
    {
        UsuarioSysBl usuarioSysBl = new UsuarioSysBl();
        PlataformaBl plataformaBl = new PlataformaBl();
        OpcionBl opcionBl = new OpcionBl();
        PerfilBl perfilBl = new PerfilBl();

        // GET: Login
        public ActionResult Index()
        {
            bool isReturnUrl = TempData["isReturnUrl"] == null ? false : (bool)TempData["isReturnUrl"];
            string action = TempData["action"] == null ? "" : TempData["action"].ToString();
            string controller = TempData["controller"] == null ? "" : TempData["controller"].ToString();

            if(Session["usuario"] != null)
            {
                if (isReturnUrl) return RedirectToAction(action, controller);
                return RedirectToAction("Index", "Dashboard");
            }

            bool isAutentication = AppSettingsWeb.Login.isAutentication;
            string usuario = AppSettingsWeb.Login.usuario;
            string clave = AppSettingsWeb.Login.clave;

            if (isAutentication)
            {
                TempData["isReturnUrl"] = isReturnUrl;
                TempData["action"] = action;
                TempData["controller"] = controller;
                return RedirectToAction("Validar", "Login", new { usuarioSysId = usuario, clave });
            }

            return View();
        }

        public ActionResult Validar(string usuarioSysId, string clave)
        {
            UsuarioSys usuarioSys = usuarioSysBl.ObtenerUsuarioSys(usuarioSysId);

            if (usuarioSys == null)
            {
                TempData["errorMensajeLogin"] = "Usuario no existe";
                return RedirectToAction("Index", "Login");
            }

            string claveDesencriptada = Encriptacion.Decrypt_AES(usuarioSys.Clave, usuarioSys.KeyAES, usuarioSys.IVAES);

            if(clave != claveDesencriptada)
            {
                TempData["errorMensajeLogin"] = "Contraseña incorrecta";
                return RedirectToAction("Index", "Login");
            }

            string guidProject = AppSettings.Get<string>("project.guid");

            Plataforma plataforma = plataformaBl.ObtenerPlataformaPorIdentificador(guidProject);
            List<Perfil> listaPerfil = perfilBl.ListarPerfilUsuarioSysPorPlataforma(usuarioSys.UsuarioSysId, plataforma.PlataformaId);
            string listaPerfilstring = string.Join(",", listaPerfil.Select(x => x.PerfilId.ToString()));
            usuarioSys.ListaOpcion = opcionBl.ListarOpcionPorPerfilYOpcionPadre(plataforma.PlataformaId, listaPerfilstring);

            Session["usuario"] = usuarioSys;

            bool isReturnUrl = TempData["isReturnUrl"] == null ? false : (bool)TempData["isReturnUrl"];
            string action = TempData["action"] == null ? "" : TempData["action"].ToString();
            string controller = TempData["controller"] == null ? "" : TempData["controller"].ToString();

            if (isReturnUrl) return RedirectToAction(action, controller);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}