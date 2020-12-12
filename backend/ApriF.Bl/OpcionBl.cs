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
    public class OpcionBl : ConexionBl
    {
        public bool MantenerOpcion(Opcion opcion)
        {
            OpcionDa opcionDa = new OpcionDa();
            bool respuesta = false;
            try
            {
                cn.Open();
                respuesta = opcionDa.MantenerOpcion(opcion, cn);
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

        public bool ActualizarOrdenOpcion(int plataformaId, int opcionId, int? opcionPadreId, bool accionOrden)
        {
            OpcionDa opcionDa = new OpcionDa();
            bool respuesta = false;
            try
            {
                cn.Open();
                respuesta = opcionDa.ActualizarOrdenOpcion(plataformaId, opcionId, opcionPadreId, accionOrden, cn);
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

        public List<Opcion> BuscarOpcion(int? plataformaId = null, int? opcionId = null, int? opcionPadreId = null, string nombre = null, string enlace = null, int? orden = null)
        {
            OpcionDa opcionDa = new OpcionDa();
            List<Opcion> respuesta = null;
            try
            {
                cn.Open();
                respuesta = opcionDa.BuscarOpcion(plataformaId, opcionId, opcionPadreId, nombre, enlace, orden, cn);
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

        public List<Opcion> ListarOpcion(int? plataformaId = null)
        {
            OpcionDa opcionDa = new OpcionDa();
            List<Opcion> respuesta = null;
            try
            {
                cn.Open();
                respuesta = opcionDa.ListarOpcion(plataformaId, cn);
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

        public Opcion ObtenerOpcion(int plataformaId, int opcionId)
        {
            OpcionDa opcionDa = new OpcionDa();
            Opcion respuesta = null;
            try
            {
                cn.Open();
                respuesta = opcionDa.ObtenerOpcion(plataformaId, opcionId, cn);
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

        public List<Opcion> ListarOpcionPorPerfilYOpcionPadre(int plataformaId, string listaPerfilIdString, int? opcionPadreId = null)
        {
            OpcionDa opcionDa = new OpcionDa();
            List<Opcion> respuesta = null;
            try
            {
                cn.Open();

                respuesta = opcionDa.ListarOpcionPorPerfilYOpcionPadre(plataformaId, listaPerfilIdString, opcionPadreId, cn);
                if (respuesta != null)
                {
                    foreach (Opcion item in respuesta)
                    {
                        item.ListaOpcionHijo = ListarOpcionPorPerfilYOpcionPadre(plataformaId, listaPerfilIdString, item.OpcionId);
                    }
                }

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
