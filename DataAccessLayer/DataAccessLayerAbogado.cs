using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace DataAccessLayer
{
    public interface DataAccessLayerAbogado
    {
        void Insert(Abogado pAbogado);

        void Update(Abogado pAbogado);

        void Delete(int pId);

        Abogado LoadByUserId(string pUserId);

        Abogado LoadByUserName(string pUserName);

        List<Abogado> SerchAbogados(string pNombre, string pApellido, int pDocumento);

        void InsertEspecializacion(Especializacion pEspecilizacion);

        List<Especializacion> SearchEspecializaciones(int pId);

        int Count();
    }
}