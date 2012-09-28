using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class TipoDocumento
    {
        private int id;
        private string descripcion;

        //CONSTRUCTORES
        public TipoDocumento()
        {
            id = 0;
            descripcion = string.Empty;
        }
        public TipoDocumento(int pId, string pDescripcion)
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
                   "\nDesccripcion: " + descripcion;
        }
    }
}
