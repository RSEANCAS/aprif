using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApriF.Web.Admin.Controllers
{
    public class DashboardController : Controller
    {
        [ValidarSessionFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}