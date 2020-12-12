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
    public class DepartamentoBl : ConexionBl
    {
        public List<Departamento> ListarDepartamento(string paisId = null)
        {
            DepartamentoDa departamentoDa = new DepartamentoDa();
            List<Departamento> respuesta = null;
            try
            {
                cn.Open();
                respuesta = departamentoDa.ListarDepartamento(paisId, cn);
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
