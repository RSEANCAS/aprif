using ApriF.Be;
using ApriF.Da;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ApriF.Bl
{
    public class FacturaBl : ConexionBl
    {
        public string RegistraFactura(Factura factura)
        {
            FacturaDa facturaDa = new FacturaDa();
            string respuesta = "";
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    cn.Open();
                    respuesta = facturaDa.RegistraFactura(factura, cn);
                    if (respuesta != "BIEN") goto cerrarConexion;

                    scope.Complete();
                    respuesta = "BIEN";
                cerrarConexion:
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message.ToString();
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return respuesta;
        }

    }
}
