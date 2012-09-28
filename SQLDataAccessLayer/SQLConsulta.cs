using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Entities;
using DataAccessLayer;

namespace SQLDataAccessLayer
{
    public class SQLConsulta : DataAccessLayerConsulta
    {
        #region Consulta

        public void Insert(Consulta pConsulta)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO Consultas " +
                                  "VALUES (@Cliente, @Abogado, @TemaConsulta, @Estado, @Fecha, @Descripcion)";

                cmd.Parameters.Add(new SqlParameter("@Cliente", pConsulta.Cliente.Id));
                cmd.Parameters.Add(new SqlParameter("@Abogado", pConsulta.Abogado.Id));
                cmd.Parameters.Add(new SqlParameter("@TemaConsulta", pConsulta.TemaConsulta.Id));
                cmd.Parameters.Add(new SqlParameter("@Estado", pConsulta.Estado));
                cmd.Parameters.Add(new SqlParameter("@Fecha", pConsulta.Fecha));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", pConsulta.Descripcion));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Consulta pConsulta)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "UPDATE Consultas " +
                                  "SET Descripcion=@Descripcion, Estado=@Estado, Fecha=@Fecha " +
                                  "WHERE Id=@Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pConsulta.Id));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", pConsulta.Descripcion));;
                cmd.Parameters.Add(new SqlParameter("@Estado", pConsulta.Estado));
                cmd.Parameters.Add(new SqlParameter("@Fecha", pConsulta.Fecha));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Consulta pConsulta)
        {
            Delete(pConsulta.Id);
        }

        public void Delete(int pId)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "DELETE FROM Consultas WHERE Id = @Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pId));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Cliente ClienteAsociado(int pId)
        {
            Cliente oCliente = null;
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT C.Id, C.Nombre, C.Apellido, C.TipoDocumento, TD.Descripcion as TDDesc, C.Documento, C.FechaNacimiento, C.EstadoCivil, " +
                                         "EC.Descripcion as ECDesc, C.Ocupacion, C.Sexo, C.Nacionalidad, C.Provincia, P.Descripcion as PDesc, C.Ciudad, " +
                                         "Cd.Descripcion as CDesc, Cd.Provincia as CProv, C.Direccion, C.Telefono, C.Celular, C.Observaciones " +
                                  "FROM Clientes C, TipoDocumento TD, EstadoCivil EC, Provincias P, Ciudades Cd, Consultas Cs " +
                                  "WHERE C.TipoDocumento = TD.Id and C.EstadoCivil = EC.Id and C.Provincia = P.Id and C.Ciudad = Cd.Id " +
                                        "and Cs.Cliente = C.Id and Cs.Id = @Consulta";

                cmd.Parameters.Add(new SqlParameter("@Consulta", pId));

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

        public Consulta LoadById(int pId)
        {
            Consulta oConsulta = null;
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT C.Id, C.Cliente, Cl.Nombre as NombreCl, Cl.Apellido as ApellidoCl, Cl.Direccion as DireccionCl, Cl.FechaNacimiento, Cl.Telefono, " +
                                         "C.Abogado, A.Nombre as NombreA, A.Apellido as ApellidoA, C.TemaConsulta, TC.Descripcion as TCDesc, C.Estado, C.Fecha, C.Descripcion " +
                                  "FROM Consultas C, Clientes Cl, Abogados A, TemasConsulta TC " +
                                  "WHERE C.Cliente = Cl.Id and C.Abogado = A.Id and C.TemaConsulta = TC.Id and C.Id = @Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pId));

                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int clienteIndex = dr.GetOrdinal("Cliente");
                    int clienteNombreIndex = dr.GetOrdinal("NombreCl");
                    int clienteApellidoIndex = dr.GetOrdinal("ApellidoCl");
                    int clienteDireccionIndex = dr.GetOrdinal("DireccionCl");
                    int clienteFechaNacimientoIndex = dr.GetOrdinal("FechaNacimiento");
                    int clienteTelefonoIndex = dr.GetOrdinal("Telefono");
                    int abogadoIndex = dr.GetOrdinal("Abogado");
                    int abogadoNombreIndex = dr.GetOrdinal("NombreA");
                    int abogadoApellidoIndex = dr.GetOrdinal("ApellidoA");
                    int temaConsultaIndex = dr.GetOrdinal("TemaConsulta");
                    int temaConsultaDescIndex = dr.GetOrdinal("TCDesc");
                    int estadoIndex = dr.GetOrdinal("Estado");
                    int fechaIndex = dr.GetOrdinal("Fecha");
                    int descripcionIndex = dr.GetOrdinal("Descripcion");

                    if (dr.Read())
                    {
                        Cliente oCliente = new Cliente();
                        oCliente.Id = (int)dr[clienteIndex];
                        oCliente.Nombre = (string)dr[clienteNombreIndex];
                        oCliente.Apellido = (string)dr[clienteApellidoIndex];
                        oCliente.Direccion = (string)dr[clienteDireccionIndex];
                        oCliente.FechaNacimiento = (DateTime)dr[clienteFechaNacimientoIndex];
                        oCliente.Telefono = (string)dr[clienteTelefonoIndex];

                        Abogado oAbogado = new Abogado();
                        oAbogado.Id = (int)dr[abogadoIndex];
                        oAbogado.Nombre = (string)dr[abogadoNombreIndex];
                        oAbogado.Apellido = (string)dr[abogadoApellidoIndex];

                        TemaConsulta oTemaconsulta = new TemaConsulta();
                        oTemaconsulta.Id = (int)dr[temaConsultaIndex];
                        oTemaconsulta.Descripcion = (string)dr[temaConsultaDescIndex];

                        oConsulta = new Consulta();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oConsulta.Id = (int)values[idIndex];
                        oConsulta.Cliente = oCliente;
                        oConsulta.Abogado = oAbogado;
                        oConsulta.TemaConsulta = oTemaconsulta;
                        oConsulta.Estado = (int)dr[estadoIndex];
                        oConsulta.Fecha = (DateTime)dr[fechaIndex];
                        oConsulta.Descripcion = (string)dr[descripcionIndex];
                    }
                }
            }
            return oConsulta;
        }

        public List<Consulta> SearchConsultas(string pCliente, string pAbogado, string pEstado, DateTime pFecha)
        {
            List<Consulta> listConsultas = null;
            string query = "SELECT C.Id, C.Cliente, Cl.Nombre as NombreCl, Cl.Apellido as ApellidoCl, C.Abogado, A.Nombre as NombreA, A.Apellido as ApellidoA,  " +
                                   "C.TemaConsulta, TC.Descripcion as TCDesc, C.Estado, C.Fecha, C.Descripcion " +
                            "FROM Consultas C, Clientes Cl, Abogados A, TemasConsulta TC " +
                            "WHERE C.Cliente = Cl.Id and C.Abogado = A.Id and C.TemaConsulta = TC.Id ";
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;

                if (!string.IsNullOrEmpty(pEstado))
                {
                    query += " and (C.Estado = 1 or C.Estado = 2 or C.Estado = 3 or C.Estado = 4)";
                }
                else if (string.IsNullOrEmpty(pEstado))
                {
                    query += " and C.Estado = 1";
                }
                else if (!string.IsNullOrEmpty(pCliente))
                {
                    query += " and (C.Nombre LIKE '%' + @Cliente + '%' OR C.Apellido LIKE '%' + @Cliente + '%')";
                    cmd.Parameters.Add(new SqlParameter("@Cliente", pCliente));
                }
                else if (!string.IsNullOrEmpty(pAbogado))
                {
                    query += " and (A.Nombre LIKE '%' + @Abogado + '%' OR A.Apellido LIKE '%' + @Abogado + '%')";
                    cmd.Parameters.Add(new SqlParameter("@Abogado", pAbogado));
                }
                /*
                else if (!string.IsNullOrEmpty(pFecha.ToString()))
                {
                    query += " and DAY(C.Fecha) = '@Dia' and MONTH(C.Fecha) = '@Mes' and YEAR(C.Fecha) = '@Año' ";
                    cmd.Parameters.Add(new SqlParameter("@Dia", pFecha));
                    cmd.Parameters.Add(new SqlParameter("@Mes", pFecha));
                    cmd.Parameters.Add(new SqlParameter("@Año", pFecha));
                }*/
                query += " ORDER BY C.Fecha DESC";

                cmd.CommandText = query;
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int clienteIndex = dr.GetOrdinal("Cliente");
                    int clienteNombreIndex = dr.GetOrdinal("NombreCl");
                    int clienteApellidoIndex = dr.GetOrdinal("ApellidoCl");
                    int abogadoIndex = dr.GetOrdinal("Abogado");
                    int abogadoNombreIndex = dr.GetOrdinal("NombreA");
                    int abogadoApellidoIndex = dr.GetOrdinal("ApellidoA");
                    int temaConsultaIndex = dr.GetOrdinal("TemaConsulta");
                    int temaConsultaDescIndex = dr.GetOrdinal("TCDesc");
                    int estadoIndex = dr.GetOrdinal("Estado");
                    int fechaIndex = dr.GetOrdinal("Fecha");
                    int descripcionIndex = dr.GetOrdinal("Descripcion");

                    listConsultas = new List<Consulta>();

                    while (dr.Read())
                    {
                        Cliente oCliente = new Cliente();
                        oCliente.Id = (int)dr[clienteIndex];
                        oCliente.Nombre = (string)dr[clienteNombreIndex];
                        oCliente.Apellido = (string)dr[clienteApellidoIndex];

                        Abogado oAbogado = new Abogado();
                        oAbogado.Id = (int)dr[abogadoIndex];
                        oAbogado.Nombre = (string)dr[abogadoNombreIndex];
                        oAbogado.Apellido = (string)dr[abogadoApellidoIndex];

                        TemaConsulta oTemaconsulta = new TemaConsulta();
                        oTemaconsulta.Id = (int)dr[temaConsultaIndex];
                        oTemaconsulta.Descripcion = (string)dr[temaConsultaDescIndex];
                        
                        Consulta oConsulta = new Consulta();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oConsulta.Id = (int)values[idIndex];
                        oConsulta.Cliente = oCliente;
                        oConsulta.Abogado = oAbogado;
                        oConsulta.TemaConsulta = oTemaconsulta;
                        oConsulta.Estado = (int)dr[estadoIndex];
                        oConsulta.Fecha = (DateTime)dr[fechaIndex];
                        oConsulta.Descripcion = (string)dr[descripcionIndex];

                        listConsultas.Add(oConsulta);
                    }
                }
            }
            return listConsultas;
        }

        public int Count()
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT COUNT(Id) FROM Consultas";
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