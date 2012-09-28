using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Expediente
    {
        private int id;
        private string caratula;
        private string descripcion;
        private string actores;
        private Consulta consulta;
        private Juzgado juzgado;
        private Secretaria secretaria;
        private DateTime fechaInicio;

        //CONSTRUCTORES
        public Expediente()
        {
            id = 0;
            caratula = string.Empty;
            descripcion = string.Empty;
            actores = string.Empty;
            consulta = null;
            juzgado = null;
            secretaria = null;
            fechaInicio = DateTime.Now;
        }
        public Expediente(int pId, string pCaratula, string pDescripcion, string pActores, Consulta pConsulta, Juzgado pJuzgado, Secretaria pSecretaria, DateTime pFechaInicio)
        {
            id = pId;
            caratula = pCaratula;
            descripcion = pDescripcion;
            actores = pActores;
            consulta = pConsulta;
            juzgado = pJuzgado;
            secretaria = pSecretaria;
            fechaInicio = pFechaInicio;
        }

        //PROPIEDADES GET Y SET
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Caratula
        {
            get { return caratula; }
            set { caratula = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Actores
        {
            get { return actores; }
            set { actores = value; }
        }
        public Consulta Consulta
        {
            get { return consulta; }
            set { consulta = value; }
        }
        public Juzgado Juzgado
        {
            get { return juzgado; }
            set { juzgado = value; }
        }
        public Secretaria Secretaria
        {
            get { return secretaria; }
            set { secretaria = value; }
        }
        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        //METADOS ADICIONALES
        public string toString()
        {
            return "Id: " + id +
                   "\nCaratula: " + caratula +
                   "\nDescripcion: " + descripcion +
                   "\nActores: " + actores +
                   "\nConsulta: " + consulta +
                   "\nJuzgado: " + juzgado +
                   "\nSecretaria: " + secretaria +
                   "\nFechaInicio: " + fechaInicio;
        }
    }
}