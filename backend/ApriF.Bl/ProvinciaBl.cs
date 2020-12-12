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
    public class ProvinciaBl : ConexionBl
    {
        public List<Provincia> ListarProvincia(string paisId = null, int? departamentoId = null)
        {
            ProvinciaDa provinciaDa = new ProvinciaDa();
            List<Provincia> respuesta = null;
            try
            {
                cn.Open();
                respuesta = provinciaDa.ListarProvincia(paisId, departamentoId, cn);
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
