using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApriF.Util;
using System.Data;
using System.Data.SqlClient;

namespace ApriF.Da
{
    public class EmisorCorreoElectronicoDa
    {
        public bool MantenerEmisorCorreoElectronico(string emisorId, string correoelectronico, bool flagactivo, SqlConnection cn)
        {
            bool respuesta = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_EmisorCorreoElectronico_Mantener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));
                    cmd.Parameters.AddWithValue("@correoelectronico", SqlParam.Value(correoelectronico));
                    cmd.Parameters.AddWithValue("@flagactivo", SqlParam.Value(flagactivo));
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    respuesta = filasAfectadas != 0 && filasAfectadas != -1;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            return respuesta;
        }

    }
}
