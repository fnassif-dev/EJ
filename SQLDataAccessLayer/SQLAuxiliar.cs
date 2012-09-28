using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using DataAccessLayer;
using Entities;

namespace SQLDataAccessLayer
{
    public class SQLAuxiliar : DataAccessLayerAuxiliar
    {
        #region Auxiliares

        //METODOS PRIVINCIAS
        public void InsertProvincia(Provincia pProvincia)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO Provincias VALUES (@Descripcion)";

                cmd.Parameters.Add(new SqlParameter("@Descripcion", pProvincia.Descripcion));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateProvincia(Provincia pProvincia)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "UPDATE Provincias SET Descripcion=@Descripcion";

                cmd.Parameters.Add(new SqlParameter("@Descripcion", pProvincia.Descripcion));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteProvincia(int pId)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "DELETE FROM Provincias WHERE Id = @Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pId));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Provincia> GetAllProvincias()
        {
            List<Provincia> listProvincias = null;
            
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT Id, Descripcion FROM Provincias";
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int descripcionIndex = dr.GetOrdinal("Descripcion");

                    listProvincias = new List<Provincia>();

                    while (dr.Read())
                    {
                        Provincia oProvincia = new Provincia();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oProvincia.Id = (int)values[idIndex];
                        oProvincia.Descripcion = (string)dr[descripcionIndex];

                        listProvincias.Add(oProvincia);
                    }
                }
            }
            return listProvincias;
        }

        //METODOS CIUDADES
        public void InsertCiudad(Ciudad pCiudad)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO Ciudades VALUES (@Descripcion, @Provincia)";

                cmd.Parameters.Add(new SqlParameter("@Descripcion", pCiudad.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@Provincia", pCiudad.Provincia));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateCiudad(Ciudad pCiudad)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "UPDATE Ciudades SET Descripcion=@Descripcion";

                cmd.Parameters.Add(new SqlParameter("@Descripcion", pCiudad.Descripcion));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteCiudad(int pId)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "DELETE FROM Ciudades WHERE Id = @Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pId));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Ciudad> GetAllCiudades()
        {
            List<Ciudad> listCiudades = null;

            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT Id, Descripcion, Provincia FROM Ciudades";
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int descripcionIndex = dr.GetOrdinal("Descripcion");
                    int provinciaIndex = dr.GetOrdinal("Provincia");

                    listCiudades = new List<Ciudad>();

                    while (dr.Read())
                    {
                        Ciudad oCiudad = new Ciudad();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oCiudad.Id = (int)values[idIndex];
                        oCiudad.Descripcion = (string)dr[descripcionIndex];
                        oCiudad.Provincia = (int)dr[provinciaIndex];

                        listCiudades.Add(oCiudad);
                    }
                }
            }
            return listCiudades;
        }
        public List<Ciudad> CiudadesPorProvincia(int pId)
        {
            List<Ciudad> listCiudades = null;

            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT Id, Descripcion, Provincia FROM Ciudades WHERE Provincia=@Provincia";

                cmd.Parameters.Add(new SqlParameter("@Provincia", pId));

                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int descripcionIndex = dr.GetOrdinal("Descripcion");
                    int provinciaIndex = dr.GetOrdinal("Provincia");

                    listCiudades = new List<Ciudad>();

                    while (dr.Read())
                    {
                        Ciudad oCiudad = new Ciudad();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oCiudad.Id = (int)values[idIndex];
                        oCiudad.Descripcion = (string)dr[descripcionIndex];
                        oCiudad.Provincia = (int)dr[provinciaIndex];

                        listCiudades.Add(oCiudad);
                    }
                }
            }
            return listCiudades;
        }

        //METODOS TIPOS DE DOCUMENTO
        public void InsertTipoDocumento(TipoDocumento pTipoDocumento)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO TipoDocumento VALUES (@Descripcion)";

                cmd.Parameters.Add(new SqlParameter("@Descripcion", pTipoDocumento.Descripcion));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateTipoDocumento(TipoDocumento pTipoDocumento)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "UPDATE TipoDocumento SET Descripcion=@Descripcion WHERE Id=@Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pTipoDocumento.Id));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", pTipoDocumento.Descripcion));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteTipoDocumento(int pId)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "DELETE FROM TipoDocumento WHERE Id = @Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pId));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<TipoDocumento> GetAllTiposDocumento()
        {
            List<TipoDocumento> listTiposDocumento = null;

            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT Id, Descripcion FROM TipoDocumento";
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int descripcionIndex = dr.GetOrdinal("Descripcion");

                    listTiposDocumento = new List<TipoDocumento>();

                    while (dr.Read())
                    {
                        TipoDocumento oTipoDocumento = new TipoDocumento();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oTipoDocumento.Id = (int)values[idIndex];
                        oTipoDocumento.Descripcion = (string)dr[descripcionIndex];

                        listTiposDocumento.Add(oTipoDocumento);
                    }
                }
            }
            return listTiposDocumento;
        }
        
        //METODOS ESTADOS CIVILES
        public void InsertEstadoCivil(EstadoCivil pEstadoCivil)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO EstadoCivil VALUES (@Descripcion)";
                
                cmd.Parameters.Add(new SqlParameter("@Descripcion", pEstadoCivil.Descripcion));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateEstadoCivil(EstadoCivil pEstadoCivil)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "UPDATE EstadoCivil SET Descripcion=@Descripcion";

                cmd.Parameters.Add(new SqlParameter("@Descripcion", pEstadoCivil.Descripcion));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteEstadoCivil(int pId)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "DELETE FROM EstadoCivil WHERE Id = @Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pId));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<EstadoCivil> GetAllEstadosCiviles()
        {
            List<EstadoCivil> listEstadosCiviles = null;

            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT Id, Descripcion FROM EstadoCivil";
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int descripcionIndex = dr.GetOrdinal("Descripcion");

                    listEstadosCiviles = new List<EstadoCivil>();

                    while (dr.Read())
                    {
                        EstadoCivil oEstadoCivil = new EstadoCivil();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oEstadoCivil.Id = (int)values[idIndex];
                        oEstadoCivil.Descripcion = (string)dr[descripcionIndex];

                        listEstadosCiviles.Add(oEstadoCivil);
                    }
                }
            }
            return listEstadosCiviles;
        }

        //METODOS JUZGADOS
        public void InsertJuzgado(Juzgado pJuzgado)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO Juzgados VALUES (@Nombre, @Juez, @Direccion, @Telefono)";

                cmd.Parameters.Add(new SqlParameter("@Nombre", pJuzgado.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Juez", pJuzgado.Juez));
                cmd.Parameters.Add(new SqlParameter("@Direccion", pJuzgado.Direccion));
                cmd.Parameters.Add(new SqlParameter("@Telefono", pJuzgado.Telefono));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateJuzgado(Juzgado pJuzgado)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "UPDATE Juzgados SET Nombre=@Nombre, Juez=@Juez, Direccion=@Direccion, Telefono=@Telefono";

                cmd.Parameters.Add(new SqlParameter("@Nombre", pJuzgado.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Juez", pJuzgado.Juez));
                cmd.Parameters.Add(new SqlParameter("@Direccion", pJuzgado.Direccion));
                cmd.Parameters.Add(new SqlParameter("@Telefono", pJuzgado.Telefono));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteJuzgado(int pId)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "DELETE FROM Juzgados WHERE Id = @Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pId));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Juzgado> GetAllJuzgados()
        {
            List<Juzgado> listJuzgados = null;

            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT Id, Nombre, Juez, Direccion, Telefono FROM Juzgados";
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int nombreIndex = dr.GetOrdinal("Nombre");
                    int juezIndex = dr.GetOrdinal("Juez");
                    int direccionIndex = dr.GetOrdinal("Direccion");
                    int telefonoIndex = dr.GetOrdinal("Telefono");

                    listJuzgados = new List<Juzgado>();

                    while (dr.Read())
                    {
                        Juzgado oJuzgado = new Juzgado();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oJuzgado.Id = (int)values[idIndex];
                        oJuzgado.Nombre = (string)dr[nombreIndex];
                        oJuzgado.Juez = (string)dr[juezIndex];
                        oJuzgado.Direccion = (string)dr[direccionIndex];
                        oJuzgado.Telefono = (int)dr[telefonoIndex];

                        listJuzgados.Add(oJuzgado);
                    }
                }
            }
            return listJuzgados;
        }

        //METODOS SECRCETARIAS
        public void InsertSecretaria(Secretaria pSecretaria)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO Secretarias VALUES (@Nombre, @Secretario, @Juzgado)";

                cmd.Parameters.Add(new SqlParameter("@Nombre", pSecretaria.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Secretario", pSecretaria.Secretario));
                cmd.Parameters.Add(new SqlParameter("@Juzgado", pSecretaria.Juzgado));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateSecretaria(Secretaria pSecretaria)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "UPDATE Secretarias SET Nombre=@Nombre, Secretario=@Secretario, Juzgado=@Juzgado";

                cmd.Parameters.Add(new SqlParameter("@Nombre", pSecretaria.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Secretario", pSecretaria.Secretario));
                cmd.Parameters.Add(new SqlParameter("@Juzgado", pSecretaria.Juzgado));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteSecretaria(int pId)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "DELETE FROM Secretarias WHERE Id = @Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pId));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Secretaria> GetAllSecretarias(int pJuzgado)
        {
            List<Secretaria> listSecretarias = null;

            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT Id, Nombre, Secretarios, Juzgado FROM Secretarias WHERE Juzgado=@Juzgado";

                cmd.Parameters.Add(new SqlParameter("@Juzgado", pJuzgado));

                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int nombreIndex = dr.GetOrdinal("Nombre");
                    int secretarioIndex = dr.GetOrdinal("Secretarios");
                    int juzgadoIndex = dr.GetOrdinal("Juzgado");

                    listSecretarias = new List<Secretaria>();

                    while (dr.Read())
                    {
                        Secretaria oSecretaria = new Secretaria();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oSecretaria.Id = (int)values[idIndex];
                        oSecretaria.Nombre = (string)dr[nombreIndex];
                        oSecretaria.Secretario = (string)dr[secretarioIndex];
                        oSecretaria.Juzgado = (int)dr[juzgadoIndex];

                        listSecretarias.Add(oSecretaria);
                    }
                }
            }
            return listSecretarias;
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