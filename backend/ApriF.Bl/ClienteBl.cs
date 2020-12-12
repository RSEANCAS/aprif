using ApriF.Be;
using ApriF.Da;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ApriF.Bl
{
    public class ClienteBl: ConexionBl
    {
        public Cliente ObtenerCliente(string emisorId,string clienteId,string tipodocumentoId)
        {
            ClienteDa clienteDa = new ClienteDa();
            SucursalDa sucursalDa = new SucursalDa();
            Cliente respuesta = null;
            try
            {
                cn.Open();
                respuesta = clienteDa.ObtenerCliente(emisorId,clienteId,tipodocumentoId, cn);
                respuesta.ListaSucursal = sucursalDa.ListarSucursalCliente(emisorId,clienteId,tipodocumentoId, cn);
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
