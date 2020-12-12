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
    public class SerieBl : ConexionBl
    {
        public Serie ObtenerSerie(string emisorId, string tipoComprobanteId, string serieId)
        {
            SerieDa serieDa = new SerieDa();
            Serie respuesta = null;
            try
            {
                cn.Open();
                respuesta = serieDa.ObtenerSerie(emisorId, tipoComprobanteId, serieId, cn);
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
        public List<Serie> ListarSeriePorTipo(string emisorId, string tipoComprobanteId)
        {
            SerieDa serieDa = new SerieDa();
            List<Serie> respuesta = null;
            try
            {
                cn.Open();
                respuesta = serieDa.ListarSeriePorTipo(emisorId, tipoComprobanteId, cn);
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
