using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class TemaConsulta
    {
        private int id;
        private string descripcion;

        //CONSTRUCTORES
        public TemaConsulta()
        {
            id = 0;
            descripcion = string.Empty;
        }
        public TemaConsulta(int pId, string pDesccripcion)
        {
            id = pId;
            descripcion = pDesccripcion;
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

        //METODOS
        public string toString()
        {
            return "Id: " + id +
                   "Descripcion: " + descripcion;
        }
    }
}
