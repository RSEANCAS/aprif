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
    public class UsuarioSysBl : ConexionBl
    {
        public UsuarioSys ObtenerUsuarioSys(string usuarioSysId)
        {
            UsuarioSys usuario = null;
            UsuarioSysDa usuarioDa = new UsuarioSysDa();

            try
            {
                cn.Open();

                usuario = usuarioDa.ObtenerUsuarioSys(usuarioSysId, cn);

                cn.Close();
            }
            catch (Exception ex)
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
