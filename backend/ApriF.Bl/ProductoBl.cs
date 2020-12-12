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
    public class ProductoBl : ConexionBl
    {
        public Producto ObtenerProducto(string emisorId, string productoId)
        {
            ProductoDa productoDa = new ProductoDa();
            
            Producto respuesta = null;
            try
            {
                cn.Open();
                respuesta = productoDa.ObtenerProducto(emisorId, productoId,cn);
                
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
