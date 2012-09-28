using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Provincia
    {
        private int id;
        private string descripcion;

        //CONSTRUCTORES
        public Provincia()
        {
            id = 0;
            descripcion = string.Empty;
        }
        public Provincia(int pId, string pDescripcion)
        {
            id = pId;
            descripcion = pDescripcion;
        }

        //PROPIEDADES GET Y SET
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        //METODOS GENERALES
        public string toString()
        {
            return "Id: " + id +
                   "\nDescripcion: " + descripcion;
        }
    }
}
