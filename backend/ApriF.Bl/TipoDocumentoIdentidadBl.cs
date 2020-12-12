using ApriF.Be;
using ApriF.Da;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Bl
{
    public class TipoDocumentoIdentidadBl : ConexionBl
    {
        public List<TipoDocumentoIdentidad> ListarTipoDocumentoIdentidad()
        {
            TipoDocumentoIdentidadDa tipoDocumentoIdentidadDa = new TipoDocumentoIdentidadDa();
            List<TipoDocumentoIdentidad> respuesta = null;
            try
            {
                cn.Open();
                respuesta = tipoDocumentoIdentidadDa.ListarTipoDocumentoIdentidad(cn);
                cn.Close();
            }
            catch (Exception ex)
            {
                respuesta = null;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return respuesta;
        }
    }
}
