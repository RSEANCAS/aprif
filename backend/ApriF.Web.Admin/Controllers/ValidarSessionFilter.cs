using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ApriF.Web.Admin.Controllers
{
    public class ValidarSessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            if (session != null && session["usuario"] == null)
            {
                if (!filterContext.Controller.TempData.ContainsKey("isReturnUrl")) filterContext.Controller.TempData.Remove("isReturnUrl");
                filterContext.Controller.TempData.Add("isReturnUrl", true);
                if (!filterContext.Controller.TempData.ContainsKey("action")) filterContext.Controller.TempData.Remove("action");
                filterContext.Controller.TempData.Add("action", filterContext.ActionDescriptor.ActionName);
                if (!filterContext.Controller.TempData.ContainsKey("controller")) filterContext.Controller.TempData.Remove("controller");
                filterContext.Controller.TempData.Add("controller", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "Controller", "Login" }, { "Action", "Index" } });
            }
        }
    }
}