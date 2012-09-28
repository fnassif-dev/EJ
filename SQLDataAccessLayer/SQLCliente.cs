using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Entities;
using DataAccessLayer;

namespace SQLDataAccessLayer
{
    public class SQLCliente : DataAccessLayerCliente
    {
        #region Clientes

        public void Insert(Cliente pCliente)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO Clientes " +
                                  "VALUES (@Nombre, @Apellido, @TipoDocumento, @Documento, @FechaNacimiento, @EstadoCivil, @Ocupacion, " +
                                          "@Sexo, @Nacionalidad, @Provincia, @Ciudad, @Direccion, @Telefono, @Celular, @Observaciones)";

                cmd.Parameters.Add(new SqlParameter("@Nombre", pCliente.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Apellido", pCliente.Apellido));
                cmd.Parameters.Add(new SqlParameter("@TipoDocumento", pCliente.TipoDocumento.Id));
                cmd.Parameters.Add(new SqlParameter("@Documento", pCliente.Documento));
                cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", pCliente.FechaNacimiento));
                cmd.Parameters.Add(new SqlParameter("@EstadoCivil", pCliente.EstadoCivil.Id));
                cmd.Parameters.Add(new SqlParameter("@Ocupacion", pCliente.Ocupacion));
                cmd.Parameters.Add(new SqlParameter("@Sexo", pCliente.Sexo));
                cmd.Parameters.Add(new SqlParameter("@Nacionalidad", pCliente.Nacionalidad));
                cmd.Parameters.Add(new SqlParameter("@Provincia", pCliente.Provincia.Id));
                cmd.Parameters.Add(new SqlParameter("@Ciudad", pCliente.Ciudad.Id));
                cmd.Parameters.Add(new SqlParameter("@Direccion", pCliente.Direccion));
                cmd.Parameters.Add(new SqlParameter("@Telefono", pCliente.Telefono));
                cmd.Parameters.Add(new SqlParameter("@Celular", pCliente.Celular));
                cmd.Parameters.Add(new SqlParameter("@Observaciones", pCliente.Observaciones));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Cliente pCliente)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "UPDATE Clientes " +
                                  "SET Nombre=@Nombre, Apellido=@Apellido, TipoDocumento=@TipoDocumento, Documento=@Documento,  " +
                                      "FechaNacimiento=@FechaNacimiento, EstadoCivil=@EstadoCivil, Ocupacion=@Ocupacion, Sexo=@Sexo, " +
                                      "Nacionalidad=@Nacionalidad, Provincia=@Provincia, Ciudad=@Ciudad, Direccion=@Direccion, " +
                                      "Telefono=@Telefono, Celular=@Celular, Observaciones=@Observaciones " +
                                  "WHERE Id=@Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pCliente.Id));
                cmd.Parameters.Add(new SqlParameter("@Nombre", pCliente.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Apellido", pCliente.Apellido));
                cmd.Parameters.Add(new SqlParameter("@TipoDocumento", pCliente.TipoDocumento.Id));
                cmd.Parameters.Add(new SqlParameter("@Documento", pCliente.Documento));
                cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", pCliente.FechaNacimiento));
                cmd.Parameters.Add(new SqlParameter("@EstadoCivil", pCliente.EstadoCivil.Id));
                cmd.Parameters.Add(new SqlParameter("@Ocupacion", pCliente.Ocupacion));
                cmd.Parameters.Add(new SqlParameter("@Sexo", pCliente.Sexo));
                cmd.Parameters.Add(new SqlParameter("@Nacionalidad", pCliente.Nacionalidad));
                cmd.Parameters.Add(new SqlParameter("@Provincia", pCliente.Provincia.Id));
                cmd.Parameters.Add(new SqlParameter("@Ciudad", pCliente.Ciudad.Id));
                cmd.Parameters.Add(new SqlParameter("@Direccion", pCliente.Direccion));
                cmd.Parameters.Add(new SqlParameter("@Telefono", pCliente.Telefono));
                cmd.Parameters.Add(new SqlParameter("@Celular", pCliente.Celular));
                cmd.Parameters.Add(new SqlParameter("@Observaciones", pCliente.Observaciones));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Cliente pCliente)
        {
            Delete(pCliente.Id);
        }

        public void Delete(int pId)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "DELETE FROM Clientes WHERE Id = @Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pId));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Cliente LoadById(int pId)
        {
            Cliente oCliente = null;
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT C.Id, C.Nombre, C.Apellido, C.TipoDocumento, TD.Descripcion as TDDesc, C.Documento, C.FechaNacimiento, C.EstadoCivil, " +
                                        "EC.Descripcion as ECDesc, C.Ocupacion, C.Sexo, C.Nacionalidad, C.Provincia, P.Descripcion as PDesc, C.Ciudad, " +
                                        "Cd.Descripcion as CDesc, Cd.Provincia as CProv, C.Direccion, C.Telefono, C.Celular, C.Observaciones " +
                                  "FROM Clientes C, TipoDocumento TD, EstadoCivil EC, Provincias P, Ciudades Cd " +
                                  "WHERE C.Id = @Id and C.TipoDocumento = TD.Id and C.EstadoCivil = EC.Id and C.Provincia = P.Id and C.Ciudad = Cd.Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pId));

                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int nombreIndex = dr.GetOrdinal("Nombre");
                    int apellidoIndex = dr.GetOrdinal("Apellido");
                    int tipoDocuemtnoIndex = dr.GetOrdinal("TipoDocumento");
                    int tipoDocumentoDescIndex = dr.GetOrdinal("TDDesc");
                    int documentoIndex = dr.GetOrdinal("Documento");
                    int fechaNacimientoIndex = dr.GetOrdinal("FechaNacimiento");
                    int estadoCivilIndex = dr.GetOrdinal("EstadoCivil");
                    int estadoCivilDescIndex = dr.GetOrdinal("ECDesc");
                    int ocupacionIndex = dr.GetOrdinal("Ocupacion");
                    int sexoIndex = dr.GetOrdinal("Sexo");
                    int nacionalidadIndex = dr.GetOrdinal("Nacionalidad");
                    int provinciaIndex = dr.GetOrdinal("Provincia");
                    int provinciaDescIndex = dr.GetOrdinal("PDesc");
                    int ciudadIndex = dr.GetOrdinal("Ciudad");
                    int ciudadDescIndex = dr.GetOrdinal("CDesc");
                    int ciudadProvIndex = dr.GetOrdinal("CProv");
                    int direccionIndex = dr.GetOrdinal("Direccion");
                    int telefonoIndex = dr.GetOrdinal("Telefono");
                    int celularIndex = dr.GetOrdinal("Celular");
                    int observacionesIndex = dr.GetOrdinal("Observaciones");

                    if (dr.Read())
                    {
                        oCliente = new Cliente();
                        TipoDocumento oTipoDocumento = new TipoDocumento();
                        EstadoCivil oEstadoCivil = new EstadoCivil();
                        Provincia oProvincia = new Provincia();
                        Ciudad oCiudad = new Ciudad();

                        oTipoDocumento.Id = (int)dr[tipoDocuemtnoIndex];
                        oTipoDocumento.Descripcion = (string)dr[tipoDocumentoDescIndex];

                        oEstadoCivil.Id = (int)dr[estadoCivilIndex];
                        oEstadoCivil.Descripcion = (string)dr[estadoCivilDescIndex];

                        oProvincia.Id = (int)dr[provinciaIndex];
                        oProvincia.Descripcion = (string)dr[provinciaDescIndex];

                        oCiudad.Id = (int)dr[ciudadIndex];
                        oCiudad.Descripcion = (string)dr[ciudadDescIndex];
                        oCiudad.Provincia = (int)dr[ciudadProvIndex];

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oCliente.Id = (int)values[idIndex];
                        oCliente.Nombre = (string)dr[nombreIndex];
                        oCliente.Apellido = (string)dr[apellidoIndex];
                        oCliente.TipoDocumento = oTipoDocumento;
                        oCliente.Documento = (int)dr[documentoIndex];
                        oCliente.FechaNacimiento = (DateTime)dr[fechaNacimientoIndex];
                        oCliente.EstadoCivil = oEstadoCivil;
                        oCliente.Ocupacion = (string)dr[ocupacionIndex];
                        oCliente.Sexo = (string)dr[sexoIndex];
                        oCliente.Nacionalidad = (string)dr[nacionalidadIndex];
                        oCliente.Provincia = oProvincia;
                        oCliente.Ciudad = oCiudad;
                        oCliente.Direccion = (string)dr[direccionIndex];
                        oCliente.Telefono = (string)dr[telefonoIndex];
                        oCliente.Celular = (string)dr[celularIndex];
                        oCliente.Observaciones = (string)dr[observacionesIndex];
                    }
                }
            }
            return oCliente;
        }

        public List<Cliente> SearchClientes(string pNombre, string pApellido, int pDocumento)
        {
            List<Cliente> listClientes = null;
            string query = "SELECT C.Id, C.Nombre, C.Apellido, C.TipoDocumento, TD.Descripcion as TDDesc, C.Documento, C.FechaNacimiento, C.EstadoCivil, " +
                                  "EC.Descripcion as ECDesc, C.Ocupacion, C.Sexo, C.Nacionalidad, C.Provincia, P.Descripcion as PDesc, C.Ciudad, " +
                                  "Cd.Descripcion as CDesc, Cd.Provincia as CProv, C.Direccion, C.Telefono, C.Celular, C.Observaciones " +
                           "FROM Clientes C, TipoDocumento TD, EstadoCivil EC, Provincias P, Ciudades Cd " +
                           "WHERE C.Id = C.Id and C.TipoDocumento = TD.Id and C.EstadoCivil = EC.Id and C.Provincia = P.Id and C.Ciudad = Cd.Id";

            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;

                if (!string.IsNullOrEmpty(pNombre))
                {
                    query += " and C.Nombre LIKE '%' + @Nombre + '%'";
                    cmd.Parameters.Add(new SqlParameter("@Nombre", pNombre));
                }
                else if (!string.IsNullOrEmpty(pApellido))
                {
                    query += " and C.Apellido LIKE '%' + @Apellido + '%'";
                    cmd.Parameters.Add(new SqlParameter("@Apellido", pApellido));
                }
                else if (pDocumento != 0)
                {
                    query += " and C.Documento = @Documento";
                    cmd.Parameters.Add(new SqlParameter("@Documento", pDocumento));
                }

                cmd.CommandText = query;
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int nombreIndex = dr.GetOrdinal("Nombre");
                    int apellidoIndex = dr.GetOrdinal("Apellido");
                    int tipoDocuemtnoIndex = dr.GetOrdinal("TipoDocumento");
                    int tipoDocumentoDescIndex = dr.GetOrdinal("TDDesc");
                    int documentoIndex = dr.GetOrdinal("Documento");
                    int fechaNacimientoIndex = dr.GetOrdinal("FechaNacimiento");
                    int estadoCivilIndex = dr.GetOrdinal("EstadoCivil");
                    int estadoCivilDescIndex = dr.GetOrdinal("ECDesc");
                    int ocupacionIndex = dr.GetOrdinal("Ocupacion");
                    int sexoIndex = dr.GetOrdinal("Sexo");
                    int nacionalidadIndex = dr.GetOrdinal("Nacionalidad");
                    int provinciaIndex = dr.GetOrdinal("Provincia");
                    int provinciaDescIndex = dr.GetOrdinal("PDesc");
                    int ciudadIndex = dr.GetOrdinal("Ciudad");
                    int ciudadDescIndex = dr.GetOrdinal("CDesc");
                    int ciudadProvIndex = dr.GetOrdinal("CProv");
                    int direccionIndex = dr.GetOrdinal("Direccion");
                    int telefonoIndex = dr.GetOrdinal("Telefono");
                    int celularIndex = dr.GetOrdinal("Celular");
                    int observacionesIndex = dr.GetOrdinal("Observaciones");

                    listClientes = new List<Cliente>();

                    while (dr.Read())
                    {
                        Cliente oCliente = new Cliente();
                        TipoDocumento oTipoDocumento = new TipoDocumento();
                        EstadoCivil oEstadoCivil = new EstadoCivil();
                        Provincia oProvincia = new Provincia();
                        Ciudad oCiudad = new Ciudad();

                        oTipoDocumento.Id = (int)dr[tipoDocuemtnoIndex];
                        oTipoDocumento.Descripcion = (string)dr[tipoDocumentoDescIndex];

                        oEstadoCivil.Id = (int)dr[estadoCivilIndex];
                        oEstadoCivil.Descripcion = (string)dr[estadoCivilDescIndex];

                        oProvincia.Id = (int)dr[provinciaIndex];
                        oProvincia.Descripcion = (string)dr[provinciaDescIndex];

                        oCiudad.Id = (int)dr[ciudadIndex];
                        oCiudad.Descripcion = (string)dr[ciudadDescIndex];
                        oCiudad.Provincia = (int)dr[ciudadProvIndex];

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oCliente.Id = (int)values[idIndex];
                        oCliente.Nombre = (string)dr[nombreIndex];
                        oCliente.Apellido = (string)dr[apellidoIndex];
                        oCliente.TipoDocumento = oTipoDocumento;
                        oCliente.Documento = (int)dr[documentoIndex];
                        oCliente.FechaNacimiento = (DateTime)dr[fechaNacimientoIndex];
                        oCliente.EstadoCivil = oEstadoCivil;
                        oCliente.Ocupacion = (string)dr[ocupacionIndex];
                        oCliente.Sexo = (string)dr[sexoIndex];
                        oCliente.Nacionalidad = (string)dr[nacionalidadIndex];
                        oCliente.Provincia = oProvincia;
                        oCliente.Ciudad = oCiudad;
                        oCliente.Direccion = (string)dr[direccionIndex];
                        oCliente.Telefono = (string)dr[telefonoIndex];
                        oCliente.Celular = (string)dr[celularIndex];
                        oCliente.Observaciones = (string)dr[observacionesIndex];

                        listClientes.Add(oCliente);
                    }
                }
            }
            return listClientes;
        }

        public int Count()
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT COUNT(Id) FROM Clientes";
                cnn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        #endregion


        #region Metodos Adicionales

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        }

        #endregion
    }
}