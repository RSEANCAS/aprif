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
    public class DistritoBl : ConexionBl
    {
        public List<Distrito> ListarDistrito(string paisId = null, int? departamentoId = null, int? provinciaId = null)
        {
            DistritoDa distritoDa = new DistritoDa();
            List<Distrito> respuesta = null;
            try
            {
                cn.Open();
                respuesta = distritoDa.ListarDistrito(paisId, departamentoId, provinciaId, cn);
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
