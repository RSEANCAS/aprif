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
    public class BoletaBl : ConexionBl
    {
        public int RegistraBoleta(Boleta boleta)
        {
            BoletaDa boletaDa = new BoletaDa();
            int respuesta = 0;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    cn.Open();
                    respuesta = boletaDa.RegistraBoleta(boleta, cn);
                    if (respuesta==0) goto cerraConexion;

                    scope.Complete();

                cerraConexion:
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                respuesta = 0;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return respuesta;
        }

    }
}
