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
    public class SucursalBl : ConexionBl
    {
        public Sucursal ObtenerSucursal(string emisorId, string sucursalId)
        {
            SucursalDa serieDa = new SucursalDa();
            Sucursal respuesta = null;
            try
            {
                cn.Open();
                respuesta = serieDa.ObtenerSucursal(emisorId, sucursalId, cn);
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

        public List<Sucursal> ListarSucursal(string emisorId)
        {
            SucursalDa sucursalDa = new SucursalDa();
            List<Sucursal> respuesta = null;
            try
            {
                cn.Open();
                respuesta = sucursalDa.ListarSucursal(emisorId, cn);
            }
            catch (Exception EX)
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
