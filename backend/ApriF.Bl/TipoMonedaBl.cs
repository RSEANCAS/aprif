﻿using ApriF.Be;
using ApriF.Da;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Bl
{
    public class TipoMonedaBl : ConexionBl
    {
        public List<TipoMoneda> ListarTipoMoneda()
        {
            TipoMonedaDa tipoMonedaDa = new TipoMonedaDa();
            List<TipoMoneda> respuesta = null;
            try
            {
                cn.Open();
                respuesta = tipoMonedaDa.ListarTipoMoneda(cn);
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
