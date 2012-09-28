using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace DataAccessLayer
{
    public interface DataAccessLayerConsulta
    {
        void Insert(Consulta pConsulta);

        void Update(Consulta pConsulta);

        void Delete(int pId);

        Cliente ClienteAsociado(int pId);

        Consulta LoadById(int pId);

        List<Consulta> SearchConsultas(string pCliente, string pAbogado, string pEstado, DateTime pFecha);

        int Count();
    }
}
