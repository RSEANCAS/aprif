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
    [RoutePrefix("api/departamento")]
    public class DepartamentoController : ApiController
    {
        [HttpGet]
        [HttpPost]
        [Route("listardepartamento")]
        public List<Departamento> ListarDepartamento(string paisId = null)
        {
            DepartamentoBl e = new DepartamentoBl();
            return e.ListarDepartamento(paisId);
        }
    }
}
