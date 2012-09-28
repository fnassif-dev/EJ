using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Entities;
using DataAccessLayer;

namespace SQLDataAccessLayer
{
    public class SQLTurno : DataAccessLayerTurnos
    {
        public void Insert(Turno pTurno)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO Turnos " +
                                  "VALUES (@Cliente, @Abogado, @Descripcion, @Turno, @Ausente, @Atendido)";

                cmd.Parameters.Add(new SqlParameter("@Cliente", pTurno.Cliente.Id));
                cmd.Parameters.Add(new SqlParameter("@Abogado", pTurno.Abogado.Id));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", pTurno.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@Turno", pTurno.FechaTurno));
                cmd.Parameters.Add(new SqlParameter("@Ausente", pTurno.Ausente));
                cmd.Parameters.Add(new SqlParameter("@Atendido", pTurno.Atendido));
              

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Turno pTurno)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "UPDATE Turnos " +
                                  "SET Ausente=@Ausente, Atendido=@Atendido " +
                                  "WHERE Id=@Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pTurno.Id));
                cmd.Parameters.Add(new SqlParameter("@Ausente", pTurno.Ausente));
                cmd.Parameters.Add(new SqlParameter("@Atendido", pTurno.Atendido));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Turno pTurno)
        {
            Delete(pTurno.Id);
        }

        public void Delete(int pId)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "DELETE FROM Turnos WHERE Id = @Id";

                cmd.Parameters.Add(new SqlParameter("@Id", pId));

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Turno> GetAll(int pId)
        {
            List<Turno> listTurnos = null;
            
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT T.Id, T.Cliente as ClienteId, C.Nombre as Nombrecliente, C.Apellido as ApellidoCliente, T.Abogado as AbogadoId, " +
                                         "A.Nombre as NombreAbogado, A.Apellido as ApellidoAbogado, T.Descripcion, T.Turno, T.Ausente, T.Atendido " +
                                  "FROM Turnos T, Clientes C, Abogados A " +
                                  "WHERE T.Cliente = C.Id and T.Abogado = A.Id and T.Ausente = 'false' and T.Atendido = 'false' " +
                                        "and T.Abogado = @Abogado and DAY(Turno)=@Dia and MONTH(Turno)=@Mes and YEAR(Turno)=@Año " +
                                  "ORDER BY T.Turno ASC";

                cmd.Parameters.Add(new SqlParameter("@Abogado", pId));
                cmd.Parameters.Add(new SqlParameter("@Dia", DateTime.Now.Day));
                cmd.Parameters.Add(new SqlParameter("@Mes", DateTime.Now.Month));
                cmd.Parameters.Add(new SqlParameter("@Año", DateTime.Now.Year));

                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null && dr.HasRows)
                {
                    int idIndex = dr.GetOrdinal("Id");
                    int clienteIdIndex = dr.GetOrdinal("ClienteId");
                    int clienteNombreIndex = dr.GetOrdinal("NombreCliente");
                    int clienteApellidoIndex = dr.GetOrdinal("ApellidoCliente");
                    int abogadoIdIndex = dr.GetOrdinal("AbogadoId");
                    int abogadoNombreIndex = dr.GetOrdinal("NombreAbogado");
                    int abogadoApellidoIndex = dr.GetOrdinal("ApellidoAbogado");
                    int descripcionIndex = dr.GetOrdinal("Descripcion");
                    int turnoIndex = dr.GetOrdinal("Turno");
                    int ausenteIndex = dr.GetOrdinal("Ausente");
                    int atendidoIndex = dr.GetOrdinal("Atendido");

                    listTurnos = new List<Turno>();

                    while (dr.Read())
                    {
                        Cliente oCliente = new Cliente();
                        Abogado oAbogado = new Abogado();
                        Turno oTurno = new Turno();

                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        oCliente.Id = (int)dr[clienteIdIndex];
                        oCliente.Nombre = (string)dr[clienteNombreIndex];
                        oCliente.Apellido = (string)dr[clienteApellidoIndex];

                        oAbogado.Id = (int)dr[abogadoIdIndex];
                        oAbogado.Nombre = (string)dr[abogadoNombreIndex];
                        oAbogado.Apellido = (string)dr[abogadoApellidoIndex];

                        oTurno.Id = (int)dr[idIndex];
                        oTurno.Cliente = oCliente;
                        oTurno.Abogado = oAbogado;
                        oTurno.Descripcion = (string)dr[descripcionIndex];
                        oTurno.FechaTurno = (DateTime)dr[turnoIndex];
                        oTurno.Ausente = (bool)dr[ausenteIndex];
                        oTurno.Atendido = (bool)dr[atendidoIndex];
   
                        listTurnos.Add(oTurno);
                    }
                }
            }
            return listTurnos;
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        }
    }    
}