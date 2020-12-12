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
    public class PaisBl : ConexionBl
    {
        public List<Pais> ListarPais()
        {
            PaisDa paisDa = new PaisDa();
            List<Pais> respuesta = null;
            try
            {
                cn.Open();
                respuesta = paisDa.ListarPais(cn);
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
