using System.Collections.Generic;
using Entities;

namespace DataAccessLayer
{
    public interface DataAccessLayerExpediente
    {
        //EXPEIENTES
        void Insert(Expediente pExpediente);

        void Update(Expediente pExpediente);

        void Delete(int pId);

        Consulta ConsultaAsociada(int pId);

        Expediente LoadById(int pId);

        List<Expediente> SearchExpedientes(string pAbogado, string pJuzgado);

        void Close(Expediente pExpediente);

        int Count();

        //EXPEDIENTES CERRADOS
        ExpedienteCerrado LoadCloseById(int pId);

        List<Expediente> SearchExpedientesCerrados(string pAbogado, string pJuzgado);

        List<ExpedienteCerrado> GetAllClosers();

        int CountClosers();

        //ESCRITOS
        void AddEscrito(Escrito pEscritos);

        List<Escrito> GetAllEscritos(int pId);

        int CountEscritos(int pId);
    }
}