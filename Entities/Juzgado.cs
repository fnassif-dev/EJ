using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Juzgado
    {
        private int id;
        private string nombre;
        private string juez;
        private string direccion;
        private int telefono;

        //CONSTRUCTORES
        public Juzgado()
        {
            id = 0;
            nombre = string.Empty;
            juez = string.Empty;
            direccion = string.Empty;
            telefono = 0;
        }
        public Juzgado(int pId, string pNombre, string pJuez, string pDireccion, int pTelefono)
        {
            id = pId;
            nombre = pNombre;
            juez = pJuez;
            direccion = pDireccion;
            telefono = pTelefono;
        }

        //PROPIEDADES GET Y SET
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Juez
        {
            get { return juez; }
            set { juez = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        //METODOS
        public string toString()
        {
            return "Id: " + id +
                   "\nNombre: " + nombre +
                   "\nJuez: " + juez +
                   "\nDireccion: " + direccion +
                   "\nTelefono: " + telefono;
        }
    }
}
