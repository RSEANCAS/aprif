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
    public class EmisorCorreoElectronicoController : ApiController
    {
        [HttpGet]
        public bool GetEmisorCorreoElectronico(string emisorId, string correoelectronico, bool flagactivo)
        {
            EmisorCorreoElectronicoBl ece = new EmisorCorreoElectronicoBl();
            return ece.MantenerEmisorCorreoElectronico(emisorId, correoelectronico, flagactivo);
        }
    }
}
