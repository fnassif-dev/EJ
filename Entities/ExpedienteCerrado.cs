using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class ExpedienteCerrado
    {
        private int id;
        private Expediente expediente;
        private DateTime fechaCierre;

        //CONSTRUCTORES
        public ExpedienteCerrado()
        {
            id = 0;
            expediente = null;
            fechaCierre = DateTime.Now;
        }
        public ExpedienteCerrado(int pId, Expediente pExpediente, DateTime pFechaCierre)
        {
            id = pId;
            expediente = pExpediente;
            fechaCierre = pFechaCierre;
        }

        //PROPIEDADES GET Y SET
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Expediente Expediente
        {
            get { return expediente; }
            set { expediente = value; }
        }
        public DateTime FechaCierre
        {
            get { return fechaCierre; }
            set { fechaCierre = value; }
        }

        //METODOS GENERALES
        public string toString()
        {
            return "Id: " + id +
                   "\nExpediente: " + expediente.toString() +
                   "\nFecha de Cierre: " + fechaCierre;
        }
    }
}