using ApriF.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApriF.Web.Admin.Util
{
    public static class AppSettingsWeb
    {
        public static class Login
        {
            public static bool isAutentication { get { return AppSettings.Get<bool>("login.isAutentication"); } }
            public static string usuario { get { return AppSettings.Get<string>("login.usuario"); } }
            public static string clave { get { return AppSettings.Get<string>("login.clave"); } }
        }
    }
}