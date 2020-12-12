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
    public class UsuarioBl : ConexionBl
    {
       public Usuario ObtenerUsuario(string emisorId, string usuarioId)
        {
            Usuario usuario = null;
            UsuarioDa usuarioDa = new UsuarioDa();

            try
            {
                cn.Open();

                usuario = usuarioDa.ObtenerUsuario(emisorId, usuarioId, cn);

                cn.Close();
            }
            catch(Exception ex)
            {
                usuario = null;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }

            return usuario;
        }
    }
}
