using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Entities;
using DataAccessLayer;

namespace SQLDataAccessLayer
{
    public class SQLExpediente : DataAccessLayerExpediente
    {
        #region Expedientes

        public void Insert(Expediente pExpediente)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO Expedientes " +
                                  "VALUES (@Caratula, @Descripcion, @Actores, @Consulta, @Juzgado, @Secretaria, @FechaInicio)";

                cmd.Parameters.Add(new SqlParameter("@Caratula", pExpediente.Caratula));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", pExpediente.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@Actores", pExpediente.Actores));
                cmd.Parameters.Add(new SqlParameter("@Consulta", pExpediente.Consulta.Id));
                cmd.Parameters.Add(new SqlParameter("@Juzgado", pExpediente.Juzgado.Id));
                cmd.Parameters.Add(new SqlParameter("@Secretaria", pExpediente.Secretaria.Id));
                cmd.Parameters.Add(new SqlParameter("@FechaInicio", pExpediente.FechaInicio));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Expediente pExpediente)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "UPDATE Expedientes " +
                                  "SET Caratula=@Caratula, Descripcion=@Descripcion, Actores=@Actores, Consulta=@Consulta, Juzgado=@Juzgado, " + 
                                      "Secretaria=@Secretaria, FechaInicio=@FechaInicio " +
                                  "WHERE Id=@Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pExpediente.Id));
                cmd.Parameters.Add(new SqlParameter("@Caratula", pExpediente.Caratula));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", pExpediente.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@Actores", pExpediente.Actores));
                cmd.Parameters.Add(new SqlParameter("@Consulta", pExpediente.Consulta.Id));
                cmd.Parameters.Add(new SqlParameter("@Juzgado", pExpediente.Juzgado.Id));
                cmd.Parameters.Add(new SqlParameter("@Secretaria", pExpediente.Secretaria.Id));
                cmd.Parameters.Add(new SqlParameter("@FechaInicio", pExpediente.FechaInicio));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Expediente pExpediente)
        {
            Delete(pExpediente.Id);
        }

        public void Delete(int pId)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "DELETE FROM Expedientes WHERE Id = @Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pId));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Consulta ConsultaAsociada(int pId)
        {
            Consulta oConsulta = null;
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT C.Id, C.Cliente, Cl.Nombre as ClienteNombre, C.Abogado, A.Nombre as AbogadoNombre, C.TemaConsulta, TC.Descripcion as TCDesc, " +
                                         "C.Estado, C.Fecha, C.Descripcion " +
                                  "FROM Consultas C, Expedientes E, Clientes Cl, Abogados A, TemasConsulta TC " +
                                  "WHERE C.Id = E.Consulta and C.Cliente = Cl.Id and C.Abogado = A.Id and E.Id = @Expediente";

                cmd.Parameters.Add(new SqlParameter("@Expediente", pId));

                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int clienteIndex = dr.GetOrdinal("Cliente");
                    int clientenombreIndex = dr.GetOrdinal("ClienteNombre");
                    int abogadoIndex = dr.GetOrdinal("Abogado");
                    int abogadoNombreIndex = dr.GetOrdinal("AbogadoNombre");
                    int temaConsultaIndex = dr.GetOrdinal("TemaConsulta");
                    int temaConsultaDescIndex = dr.GetOrdinal("TCDesc");
                    int estadoIndex = dr.GetOrdinal("Estado");
                    int fechaIndex = dr.GetOrdinal("Fecha");
                    int descripcionIndex = dr.GetOrdinal("Descripcion");

                    if (dr.Read())
                    {
                        Cliente oCliente = new Cliente();
                        oCliente.Id = (int)dr[clienteIndex];
                        oCliente.Nombre = (string)dr[clientenombreIndex];

                        Abogado oAbogado = new Abogado();
                        oAbogado.Id = (int)dr[abogadoIndex];
                        oAbogado.Nombre = (string)dr[abogadoNombreIndex];

                        TemaConsulta oTemaConsulta = new TemaConsulta();
                        oTemaConsulta.Id = (int)dr[temaConsultaIndex];
                        oTemaConsulta.Descripcion = (string)dr[temaConsultaDescIndex];
                        
                        oConsulta = new Consulta();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oConsulta.Id = (int)values[idIndex];
                        oConsulta.Cliente = oCliente;
                        oConsulta.Abogado = oAbogado;
                        oConsulta.TemaConsulta = oTemaConsulta;
                        oConsulta.Estado = (int)dr[estadoIndex];
                        oConsulta.Descripcion = (string)dr[descripcionIndex];
                    }
                }
            }
            return oConsulta;
        }

        public Expediente LoadById(int pId)
        {
            Expediente oExpediente = null;
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT Id, Caratula, Descripcion, Consulta, Juzgado, Secretaria, FechaInicio " +
                                  "FROM Expedientes" +
                                  "WHERE Id = @Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pId));

                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int caratulaIndex = dr.GetOrdinal("Caratula");
                    int descripcionIndex = dr.GetOrdinal("Descripcion");
                    int consultaIndex = dr.GetOrdinal("Consulta");
                    int juzgadoIndex = dr.GetOrdinal("Juzgado");
                    int secretariaIndex = dr.GetOrdinal("Secretaria");
                    int fechaInicioIndex = dr.GetOrdinal("FechaInicio");

                    if (dr.Read())
                    {
                        oExpediente = new Expediente();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oExpediente.Id = (int)values[idIndex];
                        oExpediente.Caratula = (string)dr[caratulaIndex];
                        oExpediente.Descripcion = (string)dr[descripcionIndex];
                        oExpediente.Juzgado.Id = (int)dr[juzgadoIndex];
                        oExpediente.Secretaria.Id = (int)dr[secretariaIndex];
                        oExpediente.FechaInicio = (DateTime)dr[fechaInicioIndex];
                    }
                }
            }
            return oExpediente;
        }

        public List<Expediente> SearchExpedientes(string pAbogado, string pJuzgado)
        {
            List<Expediente> listExpedientes = null;
            string query = "SELECT E.Id, E.Caratula, E.Descripcion, E.Actores, E.Consulta, C.Abogado as AbogadoId, A.Nombre as AbogadoNombre, A.Apellido as AbogadoApellido, " +
                                "E.Juzgado, J.Nombre as JuzgadoNombre, E.Secretaria, S.Nombre as SecretariaNombre, E.FechaInicio " +
                           "FROM Expedientes E, Consultas C, Abogados A, Juzgados J, Secretarias S " +
                           "WHERE E.Consulta = C.Id and C.Abogado = A.Id and E.Juzgado = J.Id and E.Secretaria = S.Id and E.Id not in (SELECT Expediente FROM ExpedientesCerrados)";

            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;

                if (!string.IsNullOrEmpty(pAbogado))
                {
                    query += " and (A.Nombre LIKE '%' + @Abogado + '%' OR A.Apellido LIKE '%' + @Abogado + '%')";
                    cmd.Parameters.Add(new SqlParameter("@Abogado", pAbogado));
                }
                else if (!string.IsNullOrEmpty(pJuzgado))
                {
                    query += " and J.Nombre LIKE '%' + @Juzgado + '%'";
                    cmd.Parameters.Add(new SqlParameter("@Juzgado", pJuzgado));
                }

                cmd.CommandText = query;
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int caratulaIndex = dr.GetOrdinal("Caratula");
                    int descripcionIndex = dr.GetOrdinal("Descripcion");
                    int actoresIndex = dr.GetOrdinal("Actores");
                    int consultaIndex = dr.GetOrdinal("Consulta");
                    int abogadoIdIndex = dr.GetOrdinal("AbogadoId");
                    int abogadoNombreIndex = dr.GetOrdinal("AbogadoNombre");
                    int abogadoApellidoIndex = dr.GetOrdinal("AbogadoApellido");
                    int juzgadoIndex = dr.GetOrdinal("Juzgado");
                    int juzgadoNombreIndex = dr.GetOrdinal("JuzgadoNombre");
                    int secretariaIndex = dr.GetOrdinal("Secretaria");
                    int secretariaNombreIndex = dr.GetOrdinal("SecretariaNombre");
                    int fechaInicioIndex = dr.GetOrdinal("FechaInicio");

                    listExpedientes = new List<Expediente>();

                    while (dr.Read())
                    {
                        Abogado oAbogado = new Abogado();
                        oAbogado.Id = (int)dr[abogadoIdIndex];
                        oAbogado.Nombre = (string)dr[abogadoNombreIndex];
                        oAbogado.Apellido = (string)dr[abogadoApellidoIndex];
                        
                        Consulta oConsulta = new Consulta();
                        oConsulta.Id = (int)dr[consultaIndex];
                        oConsulta.Abogado = oAbogado;

                        Juzgado oJuzgado = new Juzgado();
                        oJuzgado.Id = (int)dr[juzgadoIndex];
                        oJuzgado.Nombre = (string)dr[juzgadoNombreIndex];

                        Secretaria oSecretaria = new Secretaria();
                        oSecretaria.Id = (int)dr[secretariaIndex];
                        oSecretaria.Nombre = (string)dr[secretariaNombreIndex];
                        
                        
                        Expediente oExpediente = new Expediente();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oExpediente.Id = (int)values[idIndex];
                        oExpediente.Caratula = (string)dr[caratulaIndex];
                        oExpediente.Descripcion = (string)dr[descripcionIndex];
                        oExpediente.Actores = (string)dr[actoresIndex];
                        oExpediente.Consulta = oConsulta;
                        oExpediente.Juzgado = oJuzgado;
                        oExpediente.Secretaria = oSecretaria;
                        oExpediente.FechaInicio = (DateTime)dr[fechaInicioIndex];

                        listExpedientes.Add(oExpediente);
                    }
                }
            }
            return listExpedientes;
        }

        public void Close(Expediente pExpediente)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO ExpedientesCerrados " +
                                  "VALUES (@Expediente, @FechaCierre)";

                cmd.Parameters.Add(new SqlParameter("@Expediente", pExpediente.Id));
                cmd.Parameters.Add(new SqlParameter("@FechaCierre", DateTime.Now));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public int Count()
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT COUNT(Id) FROM Expedientes";
                cnn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        #endregion


        #region Expedientes Cerrados

        public ExpedienteCerrado LoadCloseById(int pId)
        {
            ExpedienteCerrado oExpedienteCerrado = null;
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT Id, Expediente, FechaCierre " +
                                  "FROM ExpedientesCerrados" +
                                  "WHERE Id = @Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pId));

                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int expedienteIndex = dr.GetOrdinal("Expediente");
                    int fechaCierreIndex = dr.GetOrdinal("FechaCierre");

                    if (dr.Read())
                    {
                        oExpedienteCerrado = new ExpedienteCerrado();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oExpedienteCerrado.Id = (int)values[idIndex];
                        oExpedienteCerrado.Expediente.Id = (int)dr[expedienteIndex];
                        oExpedienteCerrado.FechaCierre = (DateTime)dr[fechaCierreIndex];
                    }
                }
            }
            return oExpedienteCerrado;
        }

        public List<Expediente> SearchExpedientesCerrados(string pAbogado, string pJuzgado)
        {
            List<Expediente> listExpedientes = null;
            string query = "SELECT E.Id, E.Caratula, E.Descripcion, E.Actores, E.Consulta, C.Abogado as AbogadoId, A.Nombre as AbogadoNombre, A.Apellido as AbogadoApellido, " +
                                "E.Juzgado, J.Nombre as JuzgadoNombre, E.Secretaria, S.Nombre as SecretariaNombre, E.FechaInicio " +
                           "FROM Expedientes E, Consultas C, Abogados A, Juzgados J, Secretarias S, ExpedientesCerrados EC " +
                           "WHERE E.Consulta = C.Id and C.Abogado = A.Id and E.Juzgado = J.Id and E.Secretaria = S.Id and E.Id = EC.Expediente";
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;

                if (!string.IsNullOrEmpty(pAbogado))
                {
                    query += " and (A.Nombre LIKE '%' + @Abogado + '%' OR A.Apellido LIKE '%' + @Abogado + '%')";
                    cmd.Parameters.Add(new SqlParameter("@Abogado", pAbogado));
                }
                else if (!string.IsNullOrEmpty(pJuzgado))
                {
                    query += " and J.Nombre LIKE '%' + @Juzgado + '%'";
                    cmd.Parameters.Add(new SqlParameter("@Juzgado", pJuzgado));
                }

                cmd.CommandText = query;
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int caratulaIndex = dr.GetOrdinal("Caratula");
                    int descripcionIndex = dr.GetOrdinal("Descripcion");
                    int actoresIndex = dr.GetOrdinal("Actores");
                    int consultaIndex = dr.GetOrdinal("Consulta");
                    int abogadoIdIndex = dr.GetOrdinal("AbogadoId");
                    int abogadoNombreIndex = dr.GetOrdinal("AbogadoNombre");
                    int abogadoApellidoIndex = dr.GetOrdinal("AbogadoApellido");
                    int juzgadoIndex = dr.GetOrdinal("Juzgado");
                    int juzgadoNombreIndex = dr.GetOrdinal("JuzgadoNombre");
                    int secretariaIndex = dr.GetOrdinal("Secretaria");
                    int secretariaNombreIndex = dr.GetOrdinal("SecretariaNombre");
                    int fechaInicioIndex = dr.GetOrdinal("FechaInicio");

                    listExpedientes = new List<Expediente>();

                    while (dr.Read())
                    {
                        Abogado oAbogado = new Abogado();
                        oAbogado.Id = (int)dr[abogadoIdIndex];
                        oAbogado.Nombre = (string)dr[abogadoNombreIndex];
                        oAbogado.Apellido = (string)dr[abogadoApellidoIndex];

                        Consulta oConsulta = new Consulta();
                        oConsulta.Id = (int)dr[consultaIndex];
                        oConsulta.Abogado = oAbogado;

                        Juzgado oJuzgado = new Juzgado();
                        oJuzgado.Id = (int)dr[juzgadoIndex];
                        oJuzgado.Nombre = (string)dr[juzgadoNombreIndex];

                        Secretaria oSecretaria = new Secretaria();
                        oSecretaria.Id = (int)dr[secretariaIndex];
                        oSecretaria.Nombre = (string)dr[secretariaNombreIndex];


                        Expediente oExpediente = new Expediente();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oExpediente.Id = (int)values[idIndex];
                        oExpediente.Caratula = (string)dr[caratulaIndex];
                        oExpediente.Descripcion = (string)dr[descripcionIndex];
                        oExpediente.Actores = (string)dr[actoresIndex];
                        oExpediente.Consulta = oConsulta;
                        oExpediente.Juzgado = oJuzgado;
                        oExpediente.Secretaria = oSecretaria;
                        oExpediente.FechaInicio = (DateTime)dr[fechaInicioIndex];

                        listExpedientes.Add(oExpediente);
                    }
                }
            }
            return listExpedientes;
        }

        public List<ExpedienteCerrado> GetAllClosers()
        {
            List<ExpedienteCerrado> listExpedientesCerrados = null;
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT Id, Expediente, FechaCierre " +
                                  "FROM ExpedientesCerrados";
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int expedienteIndex = dr.GetOrdinal("Expeiente");
                    int fechaCierreIndex = dr.GetOrdinal("FechaCierre");

                    listExpedientesCerrados = new List<ExpedienteCerrado>();

                    while (dr.Read())
                    {
                        ExpedienteCerrado oExpedienteCerrado = new ExpedienteCerrado();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oExpedienteCerrado.Id = (int)values[idIndex];
                        oExpedienteCerrado.Expediente.Id = (int)dr[expedienteIndex];
                        oExpedienteCerrado.FechaCierre = (DateTime)dr[fechaCierreIndex];

                        listExpedientesCerrados.Add(oExpedienteCerrado);
                    }
                }
            }
            return listExpedientesCerrados;
        }

        public int CountClosers()
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT COUNT(Id) FROM ExpedientesCerrados";
                cnn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        #endregion


        #region Escritos

        public void AddEscrito(Escrito pEscritos)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO Escritos " +
                                  "VALUES (@Expediente, @Descripcion, @Fecha)";

                cmd.Parameters.Add(new SqlParameter("@Expediente", pEscritos.Expediente));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", pEscritos.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@Fecha", pEscritos.Fecha));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Escrito> GetAllEscritos(int pId)
        {
            List<Escrito> listEscritos = null;
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT Id, Expediente, Descripcion " +
                                  "FROM Escritos " +
                                  "WHERE Expediente=@Expediente";

                cmd.Parameters.Add(new SqlParameter("@Expediente", pId));

                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int expedienteIndex = dr.GetOrdinal("Expediente");
                    int descripcionIndex = dr.GetOrdinal("Descripcion");

                    listEscritos = new List<Escrito>();

                    while (dr.Read())
                    {
                        Escrito oEscrito = new Escrito();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oEscrito.Id = (int)values[idIndex];
                        oEscrito.Expediente = (int)dr[expedienteIndex];
                        oEscrito.Descripcion = (string)dr[descripcionIndex];

                        listEscritos.Add(oEscrito);
                    }
                }
            }
            return listEscritos;
        }

        public int CountEscritos(int pId)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT COUNT(Id) FROM Escritos WHERE Expediente=@Expediente";
                cmd.Parameters.Add(new SqlParameter("@expediente", pId));
                cnn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        #endregion


        #region Metodos Adicinales

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        }

        #endregion
    }
}