using ApriF.Be;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ApriF.Rest
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUsuarioRest" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuarioRest
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/UsuarioObtener/{emisorId}/{usuarioId}")]
        dynamic UsuarioObtener(string emisorId, string usuarioId);
            
    }
}
