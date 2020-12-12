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
    public class PlataformaBl : ConexionBl
    {
        public bool MantenerPlataforma(Plataforma plataforma)
        {
            PlataformaDa plataformaDa = new PlataformaDa();
            bool respuesta = false;
            try
            {
                cn.Open();
                respuesta = plataformaDa.MantenerPlataforma(plataforma, cn);
                cn.Close();
            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }

            return respuesta;
        }

        public List<Plataforma> BuscarPlataforma(int? plataformaId = null, string identificador = null, string nombre = null)
        {
            PlataformaDa plataformaDa = new PlataformaDa();
            List<Plataforma> respuesta = null;
            try
            {
                cn.Open();
                respuesta = plataformaDa.BuscarPlataforma(plataformaId, identificador, nombre, cn);
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

        public List<Plataforma> ListarPlataforma()
        {
            PlataformaDa plataformaDa = new PlataformaDa();
            List<Plataforma> respuesta = null;
            try
            {
                cn.Open();
                respuesta = plataformaDa.ListarPlataforma(cn);
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

        public Plataforma ObtenerPlataforma(int plataformaId)
        {
            PlataformaDa plataformaDa = new PlataformaDa();
            Plataforma respuesta = null;
            try
            {
                cn.Open();
                respuesta = plataformaDa.ObtenerPlataforma(plataformaId, cn);
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

        public Plataforma ObtenerPlataformaPorIdentificador(string identificador)
        {
            PlataformaDa plataformaDa = new PlataformaDa();
            Plataforma respuesta = null;
            try
            {
                cn.Open();
                respuesta = plataformaDa.ObtenerPlataformaPorIdentificador(identificador, cn);
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
