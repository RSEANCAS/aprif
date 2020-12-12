using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ApriF.Be;
using ApriF.Bl;
using Newtonsoft.Json;

namespace ApriF.Rest
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UsuarioRest" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UsuarioRest.svc o UsuarioRest.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UsuarioRest : IUsuarioRest
    {
        public dynamic UsuarioObtener(string emisorId, string usuarioId)
        {
            string usuarioJson = null;
            Usuario usuario = new UsuarioBl().ObtenerUsuario(emisorId, usuarioId);
            usuarioJson = usuario == null ? null : JsonConvert.SerializeObject(new 
            {
                EmisorId = usuario.EmisorId,
                UsuarioId = usuario.UsuarioId,
                Clave = usuario.Clave == null ? null : Convert.ToBase64String(usuario.Clave),
                KeyAES = usuario.KeyAES == null ? null : Convert.ToBase64String(usuario.KeyAES),
                IVAES = usuario.IVAES == null ? null : Convert.ToBase64String(usuario.IVAES),
                FlagUsuarioSistema = usuario.FlagUsuarioSistema,
                FlagBaja = usuario.FlagBaja
            });
            return (usuarioJson);
        }
    }
}
