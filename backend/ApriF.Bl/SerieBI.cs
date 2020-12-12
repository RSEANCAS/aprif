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
    public class SerieBI : ConexionBl
    {
        public Serie ListarSeriePorTipo(string emisorId, string tipocomprobanteId)
        {
            Serie serie = null;
            SerieDa serieDa = new SerieDa();
            try
            {
                cn.Open();
                serie = serieDa.ListarSeriePorTipo(emisorId, tipocomprobanteId, cn);
                cn.Close();
            }
            catch(Exception ex)
            {
                serie = null;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return serie;
        }
    }
}
