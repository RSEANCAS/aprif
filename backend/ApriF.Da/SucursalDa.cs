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
    public class SucursalDa
    {
        public bool MantenerSucursal(Sucursal sucursal, SqlConnection cn)
        {
            bool respuesta = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Sucursal_Mantener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(sucursal.EmisorId));
                    cmd.Parameters.AddWithValue("@sucursalId", SqlParam.Value(sucursal.SucursalId));
                    cmd.Parameters.AddWithValue("@codigoSunat", SqlParam.Value(sucursal.CodigoSunat));
                    cmd.Parameters.AddWithValue("@nombre", SqlParam.Value(sucursal.Nombre));
                    cmd.Parameters.AddWithValue("@direccion", SqlParam.Value(sucursal.Direccion));
                    cmd.Parameters.AddWithValue("@referencia", SqlParam.Value(sucursal.Referencia));
                    cmd.Parameters.AddWithValue("@flagDireccionFiscal", SqlParam.Value(sucursal.FlagDireccionFiscal));
                    cmd.Parameters.AddWithValue("@paisId", SqlParam.Value(sucursal.PaisId));
                    cmd.Parameters.AddWithValue("@departamentoId", SqlParam.Value(sucursal.DepartamentoId));
                    cmd.Parameters.AddWithValue("@provinciaId", SqlParam.Value(sucursal.ProvinciaId));
                    cmd.Parameters.AddWithValue("@distritoId", SqlParam.Value(sucursal.DistritoId));
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

        public List<Sucursal> ListarSucursal(string emisorId, SqlConnection cn)
        {
            List<Sucursal> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Sucursal_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<Sucursal>();
                            while (dr.Read())
                            {
                                lista.Add(new Sucursal
                                {
                                    Fila = dr.GetValue<int>("Fila"),
                                    EmisorId = dr.GetValue<string>("EmisorId"),
                                    SucursalId = dr.GetValue<int>("SucursalId"),
                                    CodigoSunat = dr.GetValue<string>("CodigoSunat"),
                                    Nombre = dr.GetValue<string>("Nombre"),
                                    Direccion = dr.GetValue<string>("Direccion"),
                                    Referencia = dr.GetValue<string>("Referencia"),
                                    FlagDireccionFiscal = dr.GetValue<bool>("FlagDireccionFiscal"),
                                    PaisId = dr.GetValue<string>("PaisId"),
                                    DepartamentoId = dr.GetValue<string>("DepartamentoId"),
                                    ProvinciaId = dr.GetValue<string>("ProvinciaId"),
                                    DistritoId = dr.GetValue<string>("DistritoId")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lista = null;
            }

            return lista;

        }

        public List<Sucursal> ListarSunatSucursal(string emisorId, SqlConnection cn)
        {
            List<Sucursal> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Sucursal_ListarSunat", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<Sucursal>();
                            while (dr.Read())
                            {
                                lista.Add(new Sucursal
                                {
                                    Fila = dr.GetValue<int>("Fila"),
                                    EmisorId = dr.GetValue<string>("EmisorId"),
                                    SucursalId = dr.GetValue<int>("SucursalId"),
                                    CodigoSunat = dr.GetValue<string>("CodigoSunat"),
                                    Nombre = dr.GetValue<string>("Nombre"),
                                    Direccion = dr.GetValue<string>("Direccion"),
                                    Referencia = dr.GetValue<string>("Referencia"),
                                    FlagDireccionFiscal = dr.GetValue<bool>("FlagDireccionFiscal"),
                                    PaisId = dr.GetValue<string>("PaisId"),
                                    DepartamentoId = dr.GetValue<string>("DepartamentoId"),
                                    ProvinciaId = dr.GetValue<string>("ProvinciaId"),
                                    DistritoId = dr.GetValue<string>("DistritoId")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lista = null;
            }

            return lista;

        }

        public List<SucursalCliente> ListarSucursalCliente(string emisorId,string clienteId,string tipodocumentoId, SqlConnection cn)
        {
            List<SucursalCliente> lista = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Sucursal_ListarCliente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));
                    cmd.Parameters.AddWithValue("@clienteId", SqlParam.Value(clienteId));
                    cmd.Parameters.AddWithValue("@tipodocumentoId", SqlParam.Value(tipodocumentoId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lista = new List<SucursalCliente>();

                            while (dr.Read())
                            {
                                lista.Add(new SucursalCliente
                                {
                                    Fila = dr.GetValue<int>("Fila"),
                                    SucursalId = dr.GetValue<string>("SucursalId"),
                                    CodigoSunat = dr.GetValue<string>("CodigoSunat"),
                                    Nombre = dr.GetValue<string>("Nombre"),
                                    Direccion = dr.GetValue<string>("Direccion"),
                                    Referencia = dr.GetValue<string>("Referencia"),
                                    FlagDireccionFiscal = dr.GetValue<bool>("FlagDireccionFiscal"),
                                    PaisId = dr.GetValue<string>("PaisId"),
                                    DepartamentoId = dr.GetValue<string>("DepartamentoId"),
                                    ProvinciaId = dr.GetValue<string>("ProvinciaId"),
                                    DistritoId = dr.GetValue<string>("DistritoId"),
                                    Ubigeo = dr.GetValue<string>("UbigeoDescripcion")
                                }); ;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lista = null;
            }

            return lista;

        }

        public Sucursal ObtenerSucursal(string emisorId, string sucursalId, SqlConnection cn)
        {
            Sucursal registro = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("usp_Sucursal_Obtener", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@emisorId", SqlParam.Value(emisorId));
                    cmd.Parameters.AddWithValue("@sucursalId", SqlParam.Value(sucursalId));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                registro = new Sucursal
                                {
                                    EmisorId = dr.GetValue<string>("EmisorId"),
                                    SucursalId = dr.GetValue<int>("SucursalId"),
                                    CodigoSunat = dr.GetValue<string>("CodigoSunat"),
                                    Nombre = dr.GetValue<string>("Nombre"),
                                    Direccion = dr.GetValue<string>("Direccion"),
                                    Referencia = dr.GetValue<string>("Referencia"),
                                    FlagDireccionFiscal = dr.GetValue<bool>("FlagDireccionFiscal"),
                                    PaisId = dr.GetValue<string>("PaisId"),
                                    DepartamentoId = dr.GetValue<string>("DepartamentoId"),
                                    ProvinciaId = dr.GetValue<string>("ProvinciaId"),
                                    DistritoId = dr.GetValue<string>("DistritoId")
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