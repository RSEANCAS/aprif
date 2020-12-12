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
    public class PerfilBl : ConexionBl
    {
        public List<Perfil> ListarPerfilUsuarioSysPorPlataforma(string usuarioSysId, int plataformaId)
        {
            PerfilDa perfilDa = new PerfilDa();
            List<Perfil> respuesta = null;
            try
            {
                cn.Open();
                respuesta = perfilDa.ListarPerfilUsuarioSysPorPlataforma(usuarioSysId, plataformaId, cn);
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
