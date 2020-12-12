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
    public class UnidadMedidaBl : ConexionBl
    {
        public List<UnidadMedida> ListarUnidadMedida()
        {
            UnidadMedidaDa unidadMedidaDa = new UnidadMedidaDa();
            List<UnidadMedida> respuesta = null;
            try
            {
                cn.Open();
                respuesta = unidadMedidaDa.ListarUnidadMedida(cn);
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
