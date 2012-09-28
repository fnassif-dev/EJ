using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer;
using Entities;
using SQLDataAccessLayer;

namespace BussinessLayer
{
    public class Controller
    {
        #region Abogados

        //ABOGADOS
        public static void guardarAbogado(Abogado pAbogado, string pOperacion)
        {
            DataAccessLayerAbogado oDAL = new SQLAbogado();
            if (pOperacion == "Insert")
            {
                oDAL.Insert(pAbogado);
                
            }
            else if (pOperacion == "Update")
            {
                oDAL.Update(pAbogado);
            }
            else
            {
                throw new Exception();
            }
        }
        public static Abogado abogadoLogueado(string pUserId)
        {
            DataAccessLayerAbogado oDAL = new SQLAbogado();
            return oDAL.LoadByUserId(pUserId);
        }
        public static Abogado abogadoUserName(string pUserId)
        {
            DataAccessLayerAbogado oDAL = new SQLAbogado();
            return oDAL.LoadByUserName(pUserId);
        }
        public static List<Abogado> buscarAbogados(string pNombre, string pApellido, int pDocumento)
        {
            DataAccessLayerAbogado oDAL = new SQLAbogado();
            return oDAL.SerchAbogados(pNombre, pApellido, pDocumento);
        }
        public static void eliminarAbogado(int pId)
        {
            DataAccessLayerAbogado oDAL = new SQLAbogado();
            try
            {
                oDAL.Delete(pId);
            }
            catch(SqlException)
            {
                throw new AbogadoConExpedietesIniciados();
            }
        }
        public static void agregarEspecializacion(Especializacion pEspecializacion)
        {
            DataAccessLayerAbogado oDAL = new SQLAbogado();
            oDAL.InsertEspecializacion(pEspecializacion);
        }
        public static List<Especializacion> buscarEspecializaciones(int pId)
        {
            DataAccessLayerAbogado oDAL = new SQLAbogado();
            return oDAL.SearchEspecializaciones(pId);
        }

        #endregion


        #region Clientes

        //CLIENTES
        public static void guardarCliente(Cliente pCliente, string pOperacion)
        {
            DataAccessLayerCliente oDAL = new SQLCliente();
            if (pOperacion == "Insert")
            {
                oDAL.Insert(pCliente);
            }
            else if (pOperacion == "Update")
            {
                oDAL.Update(pCliente);
            }
            else
            {
                throw new Exception();
            }
        }
        public static List<Cliente> buscarClientes(string pNombre, string pApellido, int pDocuemtno)
        {
            DataAccessLayerCliente oDAL = new SQLCliente();
            return oDAL.SearchClientes(pNombre, pApellido, pDocuemtno);
        }
        public static void eliminarCliente(int pId)
        {
            DataAccessLayerCliente oDAL = new SQLCliente();
            try
            {
                oDAL.Delete(pId);
            }
            catch (SqlException)
            {
                throw new ClienteConExpedientes();
            }
        }
        public static Cliente traerClientePorId(int pId)
        {
            DataAccessLayerCliente oDAL = new SQLCliente();
            return oDAL.LoadById(pId);
        }

        #endregion


        #region Turnos

        //TURNOS
        public static void guardarTurno(Turno pTurno, string pOperacion)
        {
            DataAccessLayerTurnos oDAL = new SQLTurno();
            if (pOperacion == "Insert")
            {
                oDAL.Insert(pTurno);
            }
            else if (pOperacion == "Update")
            {
                oDAL.Update(pTurno);
            }
            else
            {
                throw new Exception();
            }
        }
        public static void eliminarTurno(int pId)
        {
            DataAccessLayerTurnos oDAL = new SQLTurno();
            try
            {
                oDAL.Delete(pId);
            }
            catch (SqlException)
            {
                throw new ConsultaVinculadaConExpediente();
            }
        }
        public static List<Turno> traerTurnos(int pId)
        {
            DataAccessLayerTurnos oDAL = new SQLTurno();
            return oDAL.GetAll(pId);
        }

        #endregion


        #region Consultas

        //CONSULTAS
        public static void guardarConsulta(Consulta pConsulta, string pOperacion)
        {
            DataAccessLayerConsulta oDAL = new SQLConsulta();
            if (pOperacion == "Insert")
            {
                oDAL.Insert(pConsulta);
            }
            else if (pOperacion == "Update")
            {
                oDAL.Update(pConsulta);
            }
            else
            {
                throw new Exception();
            }
        }
        public static List<Consulta> buscarConsultas(string pCliente, string pAbogado, string pEstado, DateTime pFecha)
        {
            DataAccessLayerConsulta oDAL = new SQLConsulta();
            return oDAL.SearchConsultas(pCliente, pAbogado, pEstado, pFecha);
        }
        public static void eliminarConsulta(int pId)
        {
            DataAccessLayerConsulta oDAL = new SQLConsulta();
            try
            {
                oDAL.Delete(pId);
            }
            catch (SqlException)
            {
                throw new ConsultaVinculadaConExpediente();
            }
        }
        public static Consulta consultaPorId(int pId)
        {
            DataAccessLayerConsulta oDAL = new SQLConsulta();
            return oDAL.LoadById(pId);
        }
        public static Cliente traerClienteAsociado(int pId)
        {
            DataAccessLayerConsulta oDAL = new SQLConsulta();
            return oDAL.ClienteAsociado(pId);
        }

        #endregion


        #region Expedientes

        //EXPEDIENTES
        public static void guardarExpediente(Expediente pExpediente, string pOperacion)
        {
            DataAccessLayerExpediente oDAL = new SQLExpediente();
            if (pOperacion == "Insert")
            {
                oDAL.Insert(pExpediente);
            }
            else if (pOperacion == "Update")
            {
                oDAL.Update(pExpediente);
            }
            else
            {
                throw new Exception();
            }
        }
        public static List<Expediente> buscarExpedientes(string pAbogado, string pJuzgado)
        {
            DataAccessLayerExpediente oDAL = new SQLExpediente();
            return oDAL.SearchExpedientes(pAbogado, pJuzgado);
        }
        public static void agregarEscrito(Escrito pEscrito)
        {
            DataAccessLayerExpediente oDAL = new SQLExpediente();
            oDAL.AddEscrito(pEscrito);
        }
        public static List<Escrito> traerEscritos(int pId)
        {
            DataAccessLayerExpediente oDAL = new SQLExpediente();
            return oDAL.GetAllEscritos(pId);
        }
        public static void eliminarExpediente(int pId)
        {
            DataAccessLayerExpediente oDAL = new SQLExpediente();
            try
            {
                oDAL.Delete(pId);
            }
            catch (SqlException)
            {

            }
        }
        public static void cerrarExpediente(Expediente pExpediente)
        {
            DataAccessLayerExpediente oDAL = new SQLExpediente();
            oDAL.Close(pExpediente);
        }
        public static List<Expediente> buscarExpedientesCerrados(string pAbogado, string pJuzgado)
        {
            DataAccessLayerExpediente oDAL = new SQLExpediente();
            return oDAL.SearchExpedientesCerrados(pAbogado, pJuzgado);
        }
        public static Consulta traerConsultaAsociada(int pId)
        {
            DataAccessLayerExpediente oDAL = new SQLExpediente();
            return oDAL.ConsultaAsociada(pId);
        }

        #endregion


        #region Auxiliares

        //PROVINCIAS
        public static void guardarProvincia(Provincia pProvincia, string pOperacion)
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();

            if (pOperacion == "Insert")
            {
                oDAL.InsertProvincia(pProvincia);
            }
            else if (pOperacion == "Update")
            {
                oDAL.UpdateProvincia(pProvincia);
            }
            else
            {
                throw new Exception();
            }
        }
        public static void eliminarProvincia(int pId)
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();
            oDAL.DeleteProvincia(pId);
        }
        public static List<Provincia> traerProvincias()
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();
            return oDAL.GetAllProvincias();
        }

        //CIUDADES
        public static void guardarCiudad(Ciudad pCiudad, string pOperacion)
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();
            
            if (pOperacion == "Insert")
            {
                oDAL.InsertCiudad(pCiudad);
            }
            else if (pOperacion == "Update")
            {
                oDAL.UpdateCiudad(pCiudad);
            }
            else
            {
                throw new Exception();
            }
        }
        public static void eliminarCiudad(int pId)
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();
            oDAL.DeleteCiudad(pId);
        }
        public static List<Ciudad> traerCiudades()
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();
            return oDAL.GetAllCiudades();
        }
        public static List<Ciudad> traerCiudadesPorProvincia(int pId)
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();
            return oDAL.CiudadesPorProvincia(pId);
        }

        //TIPOS DE DOCUMENTO
        public static void guardarTipoDocumento(TipoDocumento pTipoDocumento, string pOperacion)
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();
            
            if (pOperacion == "Insert")
            {
                oDAL.InsertTipoDocumento(pTipoDocumento);
            }
            else if (pOperacion == "Update")
            {
                oDAL.UpdateTipoDocumento(pTipoDocumento);
            }
            else
            {
                throw new Exception();
            }
        }
        public static void eliminarTipoDocumento(int pId)
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();
            oDAL.DeleteTipoDocumento(pId);
        }
        public static List<TipoDocumento> traerTiposDocumento()
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();
            return oDAL.GetAllTiposDocumento();
        }

        //ESTADOS CIVILES
        public static void guardarEstadoCivil(EstadoCivil pEstadoCivil, string pOperacion)
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();
            
            if (pOperacion == "Insert")
            {
                oDAL.InsertEstadoCivil(pEstadoCivil);
            }
            else if (pOperacion == "Update")
            {
                oDAL.UpdateEstadoCivil(pEstadoCivil);
            }
            else
            {
                throw new Exception();
            }
        }
        public static void eliminarEstadoCivil(int pId)
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();
            oDAL.DeleteEstadoCivil(pId);
        }
        public static List<EstadoCivil> traerEstadosCiviles()
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();
            return oDAL.GetAllEstadosCiviles();
        }

        //JUZGADOS
        public static void guardarJuzgado(Juzgado pJuzgado, string pOperacion)
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();

            if (pOperacion == "Insert")
            {
                oDAL.InsertJuzgado(pJuzgado);
            }
            else if (pOperacion == "Update")
            {
                oDAL.UpdateJuzgado(pJuzgado);
            }
            else
            {
                throw new Exception();
            }
        }
        public static void eliminarJuzgado(int pId)
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();
            try
            {
                oDAL.DeleteJuzgado(pId);
            }
            catch (SqlException e)
            {
                if (e.ErrorCode == -2146232060)
                {
                    throw new JuzgadoConSecretariasException();
                }
            }
        }
        public static List<Juzgado> traerJuzgados()
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();
            return oDAL.GetAllJuzgados();
        }

        //SECRETARÍAS
        public static void guardarSecretaria(Secretaria pSecretaria, string pOperacion)
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();

            if (pOperacion == "Insert")
            {
                oDAL.InsertSecretaria(pSecretaria);
            }
            else if (pOperacion == "Update")
            {
                oDAL.UpdateSecretaria(pSecretaria);
            }
            else
            {
                throw new Exception();
            }
        }
        public static void eliminarSecretaria(int pId)
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();
            oDAL.DeleteSecretaria(pId);
        }
        public static List<Secretaria> traerSecretarias(int pJuzgado)
        {
            DataAccessLayerAuxiliar oDAL = new SQLAuxiliar();
            return oDAL.GetAllSecretarias(pJuzgado);
        }

        #endregion


        #region Metodos Adicionales

        //OTROS METODOS
        public class ClienteConExpedientes : Exception { }

        public class AbogadoConExpedietesIniciados : Exception { }

        public class ConsultaVinculadaConExpediente : Exception { }

        public class InsufficientPrivilegeException : Exception { }

        public class JuzgadoConSecretariasException : Exception { }

        #endregion
    }
}