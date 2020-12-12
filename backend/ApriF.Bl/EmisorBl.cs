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
    public class EmisorBl : ConexionBl
    {
        public bool MantenerEmisor(Emisor emisor)
        {
            EmisorDa emisorDa = new EmisorDa();
            UsuarioDa usuarioDa = new UsuarioDa();
            SucursalDa sucursalDa = new SucursalDa();
            SucursalUsuarioDa sucursalUsuarioDa = new SucursalUsuarioDa();
            SerieDa serieDa = new SerieDa();
            SerieUsuarioDa serieUsuarioDa = new SerieUsuarioDa();
            bool respuesta = false;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    cn.Open();
                    respuesta = emisorDa.MantenerEmisor(emisor, cn);
                    if (!respuesta) goto cerraConexion;

                    if (emisor.ListaUsuario != null)
                    {
                        foreach(Usuario usuario in emisor.ListaUsuario)
                        {
                            respuesta = usuarioDa.MantenerUsuario(usuario, cn);
                            if (!respuesta) goto cerraConexion;
                        }
                    }

                    if (emisor.ListaSucursal != null)
                    {
                        foreach (Sucursal sucursal in emisor.ListaSucursal)
                        {
                            respuesta = sucursalDa.MantenerSucursal(sucursal, cn);
                            if (!respuesta) goto cerraConexion;
                        }
                    }

                    if (emisor.ListaSucursalUsuario != null)
                    {
                        respuesta = sucursalUsuarioDa.LiberarSucursalUsuario(emisor.EmisorId, cn);
                        if (!respuesta) goto cerraConexion;

                        foreach (SucursalUsuario sucursalUsuario in emisor.ListaSucursalUsuario)
                        {
                            respuesta = sucursalUsuarioDa.RelacionarSucursalUsuario(sucursalUsuario, cn);
                            if (!respuesta) goto cerraConexion;
                        }
                    }

                    if (emisor.ListaSerie != null)
                    {
                        foreach(Serie serie in emisor.ListaSerie)
                        {
                            respuesta = serieDa.MantenerSerie(serie, cn);
                            if (!respuesta) goto cerraConexion;
                        }
                    }

                    if (emisor.ListaSerieUsuario != null)
                    {
                        respuesta = serieUsuarioDa.LiberarSerieUsuario(emisor.EmisorId, cn);
                        if (!respuesta) goto cerraConexion;

                        foreach (SerieUsuario serieUsuario in emisor.ListaSerieUsuario)
                        {
                            respuesta = serieUsuarioDa.RelacionarSerieUsuario(serieUsuario, cn);
                            if (!respuesta) goto cerraConexion;
                        }
                    }

                    scope.Complete();

                cerraConexion:
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                respuesta= false;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }

            return respuesta;
        }

        public List<Emisor> BuscarEmisor(string emisorId, string razonSocial, string nombreComercial, string eslogan, bool? debaja)
        {
            EmisorDa emisorDa = new EmisorDa();
            List<Emisor> respuesta = null;
            try
            {
                cn.Open();
                respuesta = emisorDa.BuscarEmisor(emisorId, razonSocial, nombreComercial, eslogan, debaja, cn);
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

        public Emisor ObtenerEmisor(string emisorId)
        {
            EmisorDa emisorDa = new EmisorDa();
            SucursalDa sucursalDa = new SucursalDa();
            SucursalUsuarioDa sucursalUsuarioDa = new SucursalUsuarioDa();
            SerieDa serieDa = new SerieDa();
            SerieUsuarioDa serieUsuarioDa = new SerieUsuarioDa();
            UsuarioDa usuarioDa = new UsuarioDa();
            Emisor respuesta = null;
            try
            {
                cn.Open();
                respuesta = emisorDa.ObtenerEmisor(emisorId, cn);
                respuesta.ListaSucursal = sucursalDa.ListarSucursal(emisorId, cn);
                respuesta.ListaSerie = serieDa.ListarSerie(emisorId, cn);
                respuesta.ListaUsuario = usuarioDa.ListarUsuario(emisorId, cn);
                respuesta.ListaSucursalUsuario = sucursalUsuarioDa.ListarSucursalUsuario(emisorId, cn);
                respuesta.ListaSerieUsuario = serieUsuarioDa.ListarSerieUsuario(emisorId, cn);
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

        public Emisor ObtenerSunatEmisor(string emisorId)
        {
            EmisorDa emisorDa = new EmisorDa();
            SucursalDa sucursalDa = new SucursalDa();
            Emisor respuesta = null;
            try
            {
                cn.Open();
                respuesta = emisorDa.ObtenerSunatEmisor(emisorId, cn);
                respuesta.ListaSucursal = sucursalDa.ListarSunatSucursal(emisorId, cn);
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

        public bool ExisteEmisor(string emisorId)
        {
            EmisorDa emisorDa = new EmisorDa();
            bool respuesta = false;
            try
            {
                cn.Open();
                respuesta = emisorDa.ExisteEmisor(emisorId, cn);
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

    }
}
