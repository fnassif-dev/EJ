using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Escrito
    {
        private int id;
        private int expediente;
        private string descripcion;
        private DateTime fecha;

        //CONSTRUCTORES
        public Escrito()
        {
            id = 0;
            expediente = 0;
            descripcion = string.Empty;
            fecha = DateTime.Now;
        }
        public Escrito(int pId, int pExpediente, string pDescripcion, DateTime pFecha)
        {
            id = pId;
            expediente = pExpediente;
            descripcion = pDescripcion;
            fecha = pFecha;
        }

        //PROPIEDADES GET Y SET
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Expediente
        {
            get { return expediente; }
            set { expediente = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        //METODOS GENERALES
        public string toString()
        {
            return "Id: " + id +
                   "\nExpediente: " + expediente +
                   "\nDescripcion: " + descripcion +
                   "\nFecha: " + fecha;
        }
    }
}