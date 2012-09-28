using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Especializacion
    {
        public int id;
        public Abogado abogado;
        public string descripcion;
        public string fecha;
 
        //CONSTRUCTORES
        public Especializacion()
        {
            id = 0;
            abogado = null;
            descripcion = string.Empty;
            fecha = string.Empty;
        }
        public Especializacion(int pId, Abogado pAbogado, string pDescripcion, string pFecha)
        {
            id = pId;
            abogado = pAbogado;
            descripcion = pDescripcion;
            fecha = pFecha;
        }

        //PROPIEDADES GET Y SET
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Abogado Abogado
        {
            get { return abogado; }
            set { abogado = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        //METODOS GENERALES
        public string toString()
        {
            return "Id: " + id +
                   "\nAbogado: " + this.Abogado.toString() +
                   "\nDescripcion: " + descripcion;
        }
    }
}