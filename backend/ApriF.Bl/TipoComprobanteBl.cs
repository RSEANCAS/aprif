using ApriF.Be;
using ApriF.Da;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Bl
{
    public class TipoComprobanteBl : ConexionBl
    {
        public List<TipoComprobante> ListarTipoComprobante()
        {
            TipoComprobanteDa tipoComprobanteDa = new TipoComprobanteDa();
            List<TipoComprobante> respuesta = null;
            try
            {
                cn.Open();
                respuesta = tipoComprobanteDa.ListarTipoComprobante(cn);
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
