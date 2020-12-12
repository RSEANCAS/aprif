using ApriF.Be;
using ApriF.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Da
{
    public class ProductoDa
    {
        public Producto ObtenerProducto(string emisorId, string productoId, SqlConnection cn)
        {
            Producto registro = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Producto_Obtener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));
                    cmd.Parameters.AddWithValue("@ProductoId", SqlParam.Value(productoId));
                    
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                registro = new Producto
                                {
                                    ProductoId = dr.GetValue<string>("ProductoId"),
                                    Descripcion = dr.GetValue<string>("Descripcion"),
                                    CodigoSunat = dr.GetValue<string>("CodigoSunat"),
                                    UnidadMedidaId = dr.GetValue<string>("UnidadMedidaId"),
                                    AlmacenId = dr.GetValue<string>("AlmacenId"),
                                    TipoAfectacionIgvId = dr.GetValue<string>("TipoAfectacionIgvId"),
                                    TipoCalculo = dr.GetValue<string>("TipoCalculo"),
                                    Monto = dr.GetValue<decimal>("Monto"),
                                    StockActual = dr.GetValue<int>("StockActual"),
                                    StockMinimo = dr.GetValue<int>("StockMinimo")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                registro = null;
            }
            return registro;

        }

    }
}
