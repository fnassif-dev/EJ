using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Ciudad
    {
        private int id;
        private int provincia;
        private string descripcion;

        //CONSTRUCTORES
        public Ciudad()
        {
            id = 0;
            provincia = 0;
            descripcion = string.Empty;
        }
        public Ciudad(int pId, int pProvincia, string pDescripcion)
        {
            id = pId;
            provincia = pProvincia;
            descripcion = pDescripcion;
        }

        //PROPIEDADES GET Y SET
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Provincia
        {
            get { return provincia; }
            set { provincia = value; }
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
                   "\nProvincia: " + provincia +
                   "\nDescripcion: " + descripcion;
        }
    }
}