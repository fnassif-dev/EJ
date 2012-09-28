using System.Collections.Generic;
using Entities;

namespace DataAccessLayer
{
    public interface DataAccessLayerAuxiliar
    {
        //Provincias
        void InsertProvincia(Provincia pProvincia);

        void UpdateProvincia(Provincia pProvincia);

        void DeleteProvincia(int pId);

        List<Provincia> GetAllProvincias();
        

        //Ciudades
        void InsertCiudad(Ciudad pCiudad);

        void UpdateCiudad(Ciudad pCiudad);

        void DeleteCiudad(int pId);

        List<Ciudad> GetAllCiudades();

        List<Ciudad> CiudadesPorProvincia(int pId);

        
        //Tipos de Documento
        void InsertTipoDocumento(TipoDocumento pTipoDocumento);

        void UpdateTipoDocumento(TipoDocumento pTipoDocumento);

        void DeleteTipoDocumento(int pId);

        List<TipoDocumento> GetAllTiposDocumento();

        
        //Estados Civiles
        void InsertEstadoCivil(EstadoCivil pEstadoCivil);

        void UpdateEstadoCivil(EstadoCivil pEstadoCivil);

        void DeleteEstadoCivil(int pId);

        List<EstadoCivil> GetAllEstadosCiviles();


        //Juzgados
        void InsertJuzgado(Juzgado pJuzgado);

        void UpdateJuzgado(Juzgado pJuzgado);

        void DeleteJuzgado(int pId);

        List<Juzgado> GetAllJuzgados();


        //Secretarias
        void InsertSecretaria(Secretaria pSecretaria);

        void UpdateSecretaria(Secretaria pSecretaria);

        void DeleteSecretaria(int pId);

        List<Secretaria> GetAllSecretarias(int pJuzgado);
    }
}