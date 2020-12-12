using ApriF.Be;
using ApriF.Da;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Bl
{
    public class TipoOperacionBl : ConexionBl
    {
        public List<TipoOperacion> ListarTipoOperacion()
        {
            TipoOperacionDa tipoOperacionDa = new TipoOperacionDa();
            List<TipoOperacion> respuesta = null;
            try
            {
                cn.Open();
                respuesta = tipoOperacionDa.ListarTipoOperacion(cn);
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
