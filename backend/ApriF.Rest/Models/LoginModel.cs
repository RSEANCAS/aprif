using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aprif.Rest.Models
{
    public class LoginModel
    {
        public string ruc { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
    }
}