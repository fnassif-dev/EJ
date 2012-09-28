using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class EstadoCivil
    {
        public int id;
        public string descripcion;

        //CONSTRUCTORES
        public EstadoCivil()
        {
            id = 0;
            descripcion = string.Empty;
        }
        public EstadoCivil(int pId, string pDescripcion)
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

        //METODOS ADICIONALES
        public string toString()
        {
            return "Id: " + id +
                   "\nDescripcion: " + descripcion;
        }
    }
}