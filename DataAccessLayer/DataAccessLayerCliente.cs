using System.Collections.Generic;
using Entities;

namespace DataAccessLayer
{
    public interface DataAccessLayerCliente
    {
        void Insert(Cliente pCliente);

        void Update(Cliente pCliente);

        void Delete(int pId);

        Cliente LoadById(int pId);

        List<Cliente> SearchClientes(string pNombre, string pApellido, int pDocumento);

        int Count();
    }
}