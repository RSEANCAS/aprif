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
    public class EmisorCorreoElectronicoBl:ConexionBl
    {
        public bool MantenerEmisorCorreoElectronico(string emisorId, string correoelectronico, bool flagactivo)
        {
            EmisorCorreoElectronicoDa emisorcorreoelectronicoDa = new EmisorCorreoElectronicoDa();
            bool respuesta = false;
            try
            {
                cn.Open();
                respuesta = emisorcorreoelectronicoDa.MantenerEmisorCorreoElectronico(emisorId, correoelectronico, flagactivo, cn);
                cn.Close();
            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }

            return respuesta;
        }
    }
}
