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
    public class ReporteVentaBl:ConexionBl
    {
        public List<ReporteVenta> ListarReporteVenta()
        {
            ReporteVentaDa ReporteVentaDa = new ReporteVentaDa();
            List<ReporteVenta> respuesta = null;
            try
            {
                cn.Open();
                respuesta = ReporteVentaDa.ListarReporteVenta(cn);
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
