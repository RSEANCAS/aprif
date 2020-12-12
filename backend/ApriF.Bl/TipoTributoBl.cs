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
    public class TipoTributoBl : ConexionBl
    {
        public List<TipoTributo> ListarTipoTributo()
        {
            TipoTributoDa tipoTributoDa = new TipoTributoDa();
            List<TipoTributo> respuesta = null;
            try
            {
                cn.Open();
                respuesta = tipoTributoDa.ListarTipoTributo(cn);
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
