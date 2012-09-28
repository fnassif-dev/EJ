using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Entities;
using DataAccessLayer;

namespace SQLDataAccessLayer
{
    public class SQLAbogado : DataAccessLayerAbogado
    {
        #region Abogados
        
        public void Insert(Abogado pAbogado)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO Abogados " +
                                  "VALUES (@Nombre, @Apellido, @UserId, @TipoDocumento, @Documento, @FechaNacimiento, @EstadoCivil, @Provincia, @Ciudad, @Direccion, @Telefono, @Celular)";
                
                cmd.Parameters.Add(new SqlParameter("@Nombre", pAbogado.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Apellido", pAbogado.Apellido));
                cmd.Parameters.Add(new SqlParameter("@UserId", pAbogado.UserId));
                cmd.Parameters.Add(new SqlParameter("@TipoDocumento", pAbogado.TipoDocumento.Id));
                cmd.Parameters.Add(new SqlParameter("@Documento", pAbogado.Documento));
                cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", pAbogado.FechaNacimiento));
                cmd.Parameters.Add(new SqlParameter("@EstadoCivil", pAbogado.EstadoCivil.Id));
                cmd.Parameters.Add(new SqlParameter("@Provincia", pAbogado.Provincia.Id));
                cmd.Parameters.Add(new SqlParameter("@Ciudad", pAbogado.Ciudad.Id));
                cmd.Parameters.Add(new SqlParameter("@Direccion", pAbogado.Direccion));
                cmd.Parameters.Add(new SqlParameter("@Telefono", pAbogado.Telefono));
                cmd.Parameters.Add(new SqlParameter("@Celular", pAbogado.Celular));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Abogado pAbogado)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "UPDATE Abogados " +
                                  "SET Nombre=@Nombre, Apellido=@Apellido, TipoDocumento=@TipoDocumento, Documento=@Documento, " +
                                      "EstadoCivil=@EstadoCivil, Provincia=@Provincia, Ciudad=@Ciudad, Direccion=@Direccion, " +
                                      "Telefono=@Telefono, Celular=@Celular " +
                                  "WHERE Id=@Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pAbogado.Id));
                cmd.Parameters.Add(new SqlParameter("@Nombre", pAbogado.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Apellido", pAbogado.Apellido));
                cmd.Parameters.Add(new SqlParameter("@TipoDocumento", pAbogado.TipoDocumento.Id));
                cmd.Parameters.Add(new SqlParameter("@Documento", pAbogado.Documento));
                cmd.Parameters.Add(new SqlParameter("@EstadoCivil", pAbogado.EstadoCivil.Id));
                cmd.Parameters.Add(new SqlParameter("@Provincia", pAbogado.Provincia.Id));
                cmd.Parameters.Add(new SqlParameter("@Ciudad", pAbogado.Ciudad.Id));
                cmd.Parameters.Add(new SqlParameter("@Direccion", pAbogado.Direccion));
                cmd.Parameters.Add(new SqlParameter("@Telefono", pAbogado.Telefono));
                cmd.Parameters.Add(new SqlParameter("@Celular", pAbogado.Celular));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Abogado pAbogado)
        {
            Delete(pAbogado.Id);
        }

        public void Delete(int pId)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "DELETE FROM Abogados WHERE Id = @Id";
                
                cmd.Parameters.Add(new SqlParameter("@Id", pId));
                
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Abogado LoadByUserName(string pUserName)
        {
            Abogado oAbogado = null;
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT A.Id, A.Nombre, A.Apellido, A.TipoDocumento, TD.Descripcion as TDDesc, A.Documento, A.EstadoCivil, " +
                                       "EC.Descripcion as ECDesc, A.Provincia, P.Descripcion as PDesc, A.Ciudad, C.Provincia CProv, " +
                                       "C.Descripcion as CDesc, A.Direccion, A.Telefono, A.Celular " +
                                  "FROM Abogados A, TipoDocumento TD, EstadoCivil EC, Provincias P, Ciudades C, aspnet_Users U " +
                                  "WHERE A.TipoDocumento = TD.Id and A.EstadoCivil = EC.Id and A.Provincia = P.Id and A.Ciudad = C.Id and " + 
                                        "A.UserId = U.UserId and U.UserName = @UserName";

                cmd.Parameters.Add(new SqlParameter("@UserName", pUserName));
                
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int nombreIndex = dr.GetOrdinal("Nombre");
                    int apellidoIndex = dr.GetOrdinal("Apellido");
                    int tipoDocumentoIndex = dr.GetOrdinal("TipoDocumento");
                    int tipoDocumentoDescIndex = dr.GetOrdinal("TDDesc");
                    int documentoIndex = dr.GetOrdinal("Documento");
                    int estadoCivilIndex = dr.GetOrdinal("EstadoCivil");
                    int estadoCivilDescIndex = dr.GetOrdinal("ECDesc");
                    int provinciaIndex = dr.GetOrdinal("Provincia");
                    int provinciaDescIndex = dr.GetOrdinal("PDesc");
                    int ciudadIndex = dr.GetOrdinal("Ciudad");
                    int ciudadProvinciaIndex = dr.GetOrdinal("CProv");
                    int ciudadDescIndex = dr.GetOrdinal("CDesc");
                    int direccionIndex = dr.GetOrdinal("Direccion");
                    int telefonoIndex = dr.GetOrdinal("Telefono");
                    int celularIndex = dr.GetOrdinal("Celular");

                    if (dr.Read())
                    {
                        oAbogado = new Abogado();
                        TipoDocumento oTipoDocumento = new TipoDocumento();
                        EstadoCivil oEstadoCivil = new EstadoCivil();
                        Provincia oProvincia = new Provincia();
                        Ciudad oCiudad = new Ciudad();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oTipoDocumento.Id = (int)dr[tipoDocumentoIndex];
                        oTipoDocumento.Descripcion = (string)dr[tipoDocumentoDescIndex];

                        oEstadoCivil.Id = (int)dr[estadoCivilIndex];
                        oEstadoCivil.Descripcion = (string)dr[estadoCivilDescIndex];

                        oProvincia.Id = (int)dr[provinciaIndex];
                        oProvincia.Descripcion = (string)dr[provinciaDescIndex];

                        oCiudad.Id = (int)dr[ciudadIndex];
                        oCiudad.Provincia = (int)dr[ciudadProvinciaIndex];
                        oCiudad.Descripcion = (string)dr[ciudadDescIndex];

                        oAbogado.Id = (int)values[idIndex];
                        oAbogado.Nombre = (string)dr[nombreIndex];
                        oAbogado.Apellido = (string)dr[apellidoIndex];
                        oAbogado.TipoDocumento = oTipoDocumento;
                        oAbogado.Documento = (int)dr[documentoIndex];
                        oAbogado.EstadoCivil = oEstadoCivil;
                        oAbogado.Provincia = oProvincia;
                        oAbogado.Ciudad = oCiudad;
                        oAbogado.Direccion = (string)dr[direccionIndex];
                        oAbogado.Telefono = (string)dr[telefonoIndex];
                        oAbogado.Celular = (string)dr[celularIndex];
                    }
                }
            }
            return oAbogado;
        }

        public Abogado LoadByUserId(string pUserNameId)
        {
            Abogado oAbogado = null;
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT A.Id, A.Nombre, A.Apellido, A.UserId, A.TipoDocumento, TD.Descripcion as TDDesc, A.Documento, A.EstadoCivil, " +
                                       "EC.Descripcion as ECDesc, A.Provincia, P.Descripcion as PDesc, A.Ciudad, C.Provincia CProv, " +
                                       "C.Descripcion as CDesc, A.Direccion, A.Telefono, A.Celular " +
                                  "FROM Abogados A, TipoDocumento TD, EstadoCivil EC, Provincias P, Ciudades C " +
                                  "WHERE A.TipoDocumento = TD.Id and A.EstadoCivil = EC.Id and A.Provincia = P.Id and A.Ciudad = C.Id and UserId = @UserId";

                cmd.Parameters.Add(new SqlParameter("@UserId", pUserNameId));

                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int nombreIndex = dr.GetOrdinal("Nombre");
                    int apellidoIndex = dr.GetOrdinal("Apellido");
                    int userIdIndex = dr.GetOrdinal("UserId");
                    int tipoDocumentoIndex = dr.GetOrdinal("TipoDocumento");
                    int tipoDocumentoDescIndex = dr.GetOrdinal("TDDesc");
                    int documentoIndex = dr.GetOrdinal("Documento");
                    int estadoCivilIndex = dr.GetOrdinal("EstadoCivil");
                    int estadoCivilDescIndex = dr.GetOrdinal("ECDesc");
                    int provinciaIndex = dr.GetOrdinal("Provincia");
                    int provinciaDescIndex = dr.GetOrdinal("PDesc");
                    int ciudadIndex = dr.GetOrdinal("Ciudad");
                    int ciudadProvinciaIndex = dr.GetOrdinal("CProv");
                    int ciudadDescIndex = dr.GetOrdinal("CDesc");
                    int direccionIndex = dr.GetOrdinal("Direccion");
                    int telefonoIndex = dr.GetOrdinal("Telefono");
                    int celularIndex = dr.GetOrdinal("Celular");

                    if (dr.Read())
                    {
                        oAbogado = new Abogado();
                        TipoDocumento oTipoDocumento = new TipoDocumento();
                        EstadoCivil oEstadoCivil = new EstadoCivil();
                        Provincia oProvincia = new Provincia();
                        Ciudad oCiudad = new Ciudad();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oTipoDocumento.Id = (int)dr[tipoDocumentoIndex];
                        oTipoDocumento.Descripcion = (string)dr[tipoDocumentoDescIndex];

                        oEstadoCivil.Id = (int)dr[estadoCivilIndex];
                        oEstadoCivil.Descripcion = (string)dr[estadoCivilDescIndex];

                        oProvincia.Id = (int)dr[provinciaIndex];
                        oProvincia.Descripcion = (string)dr[provinciaDescIndex];

                        oCiudad.Id = (int)dr[ciudadIndex];
                        oCiudad.Provincia = (int)dr[ciudadProvinciaIndex];
                        oCiudad.Descripcion = (string)dr[ciudadDescIndex];

                        oAbogado.Id = (int)values[idIndex];
                        oAbogado.Nombre = (string)dr[nombreIndex];
                        oAbogado.Apellido = (string)dr[apellidoIndex];
                        oAbogado.UserId = Convert.ToString(dr[userIdIndex]);
                        oAbogado.TipoDocumento = oTipoDocumento;
                        oAbogado.Documento = (int)dr[documentoIndex];
                        oAbogado.EstadoCivil = oEstadoCivil;
                        oAbogado.Provincia = oProvincia;
                        oAbogado.Ciudad = oCiudad;
                        oAbogado.Direccion = (string)dr[direccionIndex];
                        oAbogado.Telefono = (string)dr[telefonoIndex];
                        oAbogado.Celular = (string)dr[celularIndex];
                    }
                }
            }
            return oAbogado;
        }

        public List<Abogado> SerchAbogados(string pNombre, string pApellido, int pDocumento)
        {
            List<Abogado> listAbogados = null;
            string consulta = "SELECT A.Id, A.Nombre, A.Apellido, A.TipoDocumento, TD.Descripcion as TDDesc, A.Documento, A.EstadoCivil, " +
                                    "EC.Descripcion as ECDesc, A.Provincia, P.Descripcion as PDesc, A.Ciudad, C.Provincia CProv, " +
                                    "C.Descripcion as CDesc, A.Direccion, A.Telefono, A.Celular " +
                              "FROM Abogados A, TipoDocumento TD, EstadoCivil EC, Provincias P, Ciudades C " +
                              "WHERE A.TipoDocumento = TD.Id and A.EstadoCivil = EC.Id and A.Provincia = P.Id and A.Ciudad = C.Id "; 

            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;

                if (!string.IsNullOrEmpty(pNombre))
                {
                    consulta += " and A.Nombre LIKE '%' + @Nombre + '%'";
                    cmd.Parameters.Add(new SqlParameter("@Nombre", pNombre));
                }
                else if (!string.IsNullOrEmpty(pApellido))
                {
                    consulta += " and A.Apellido LIKE '%' + @Apellido + '%'";
                    cmd.Parameters.Add(new SqlParameter("@Apellido", pApellido));
                }
                else if (pDocumento != 0)
                {
                    consulta += " and A.Documento = @Documento";
                    cmd.Parameters.Add(new SqlParameter("@Documento", pDocumento));
                }

                cmd.CommandText = consulta;
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int nombreIndex = dr.GetOrdinal("Nombre");
                    int apellidoIndex = dr.GetOrdinal("Apellido");
                    int tipoDocumentoIndex = dr.GetOrdinal("TipoDocumento");
                    int tipoDocumentoDescIndex = dr.GetOrdinal("TDDesc");
                    int documentoIndex = dr.GetOrdinal("Documento");
                    int estadoCivilIndex = dr.GetOrdinal("EstadoCivil");
                    int estadoCivilDescIndex = dr.GetOrdinal("ECDesc");
                    int provinciaIndex = dr.GetOrdinal("Provincia");
                    int provinciaDescIndex = dr.GetOrdinal("PDesc");
                    int ciudadIndex = dr.GetOrdinal("Ciudad");
                    int ciudadProvinciaIndex = dr.GetOrdinal("CProv");
                    int ciudadDescIndex = dr.GetOrdinal("CDesc");
                    int direccionIndex = dr.GetOrdinal("Direccion");
                    int telefonoIndex = dr.GetOrdinal("Telefono");
                    int celularIndex = dr.GetOrdinal("Celular");

                    listAbogados = new List<Abogado>();

                    while (dr.Read())
                    {
                        Abogado oAbogado = new Abogado();
                        TipoDocumento oTipoDocumento = new TipoDocumento();
                        EstadoCivil oEstadoCivil = new EstadoCivil();
                        Provincia oProvincia = new Provincia();
                        Ciudad oCiudad = new Ciudad();

                        //object[] values = new object[dr.FieldCount];
                        //dr.GetValues(values);

                        oTipoDocumento.Id = (int)dr[tipoDocumentoIndex];
                        oTipoDocumento.Descripcion = (string)dr[tipoDocumentoDescIndex];

                        oEstadoCivil.Id = (int)dr[estadoCivilIndex];
                        oEstadoCivil.Descripcion = (string)dr[estadoCivilDescIndex];

                        oProvincia.Id = (int)dr[provinciaIndex];
                        oProvincia.Descripcion = (string)dr[provinciaDescIndex];

                        oCiudad.Id = (int)dr[ciudadIndex];
                        oCiudad.Provincia = (int)dr[ciudadProvinciaIndex];
                        oCiudad.Descripcion = (string)dr[ciudadDescIndex];

                        oAbogado.Id = (int)dr[idIndex];
                        oAbogado.Nombre = (string)dr[nombreIndex];
                        oAbogado.Apellido = (string)dr[apellidoIndex];
                        oAbogado.TipoDocumento = oTipoDocumento;
                        oAbogado.Documento = (int)dr[documentoIndex];
                        oAbogado.EstadoCivil = oEstadoCivil;
                        oAbogado.Provincia = oProvincia;
                        oAbogado.Ciudad = oCiudad;
                        oAbogado.Direccion = (string)dr[direccionIndex];
                        oAbogado.Telefono = (string)dr[telefonoIndex];
                        oAbogado.Celular = (string)dr[celularIndex];

                        listAbogados.Add(oAbogado);
                    }
                }
            }
            return listAbogados;
        }

        public void InsertEspecializacion(Especializacion pEspecializacion)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO Especializacion " +
                                  "VALUES (@Abogado, @Descripcion, @Fecha)";

                cmd.Parameters.Add(new SqlParameter("@Abogado", pEspecializacion.Abogado.Id));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", pEspecializacion.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@Fecha", pEspecializacion.Fecha));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Especializacion> SearchEspecializaciones(int pId)
        {
            List<Especializacion> listEspecializaciones = null;
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT E.Id, E.Abogado, A.Nombre, A.Apellido, E.Descripcion " +
                                  "FROM Especializacion E, Abogados A " +
                                  "WHERE E.Abogado = A.Id and E.Abogado = @Id ";

                cmd.Parameters.Add(new SqlParameter("@Id", pId));
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int idAbogadoIndex = dr.GetOrdinal("Abogado");
                    int nombreAbogadoIndex = dr.GetOrdinal("Nombre");
                    int apellidoAbogadoIndex = dr.GetOrdinal("Apellido");
                    int descripcionIndex = dr.GetOrdinal("Descripcion");

                    listEspecializaciones = new List<Especializacion>();

                    while (dr.Read())
                    {
                        Abogado oAbogado = new Abogado();
                        Especializacion oEspecializacion = new Especializacion();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oAbogado.Id = (int)dr[idAbogadoIndex];
                        oAbogado.Nombre = (string)dr[nombreAbogadoIndex];
                        oAbogado.Apellido = (string)dr[apellidoAbogadoIndex];

                        oEspecializacion.Id = (int)dr[idIndex];
                        oEspecializacion.Abogado = (Abogado)oAbogado;
                        oEspecializacion.Descripcion = (string)dr[descripcionIndex];

                        listEspecializaciones.Add(oEspecializacion);
                    }
                }
            }
            return listEspecializaciones;
        }

        public int Count()
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT COUNT(Id) FROM Abogados";
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