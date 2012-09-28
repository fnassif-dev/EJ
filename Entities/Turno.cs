using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Turno
    {
        private int id;
        private Cliente cliente;
        private Abogado abogado;
        private DateTime fechaTurno;
        private string descripcion;
        private bool ausente;
        private bool atendido;

        //CONSTRUCTORES
        public Turno()
        {
            id = 0;
            cliente = null;
            abogado = null;
            fechaTurno = DateTime.Now;
            descripcion = string.Empty;
            ausente = false;
            atendido = false;
        }
        public Turno(int pId, Cliente pCliente, Abogado pAbogado, DateTime pFechaTurno, string pDescripcion, bool pAusente, bool pAtendido)
        {
            id = pId;
            cliente = pCliente;
            abogado = pAbogado;
            fechaTurno = pFechaTurno;
            descripcion = pDescripcion;
            ausente = pAusente;
            atendido = pAtendido;
        }

        //PROPIEDADES
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        public Abogado Abogado
        {
            get { return abogado; }
            set { abogado = value; }
        }
        public DateTime FechaTurno
        {
            get { return fechaTurno; }
            set { fechaTurno = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public bool Ausente
        {
            get { return ausente; }
            set { ausente = value; }
        }
        public bool Atendido
        {
            get { return atendido; }
            set { atendido = value; }
        }
        public string Hora
        {
            get { return fechaTurno.ToLongTimeString(); }
        }

        //METODOS ADICIONALES
        public string toString()
        {
            return "Id: " + id +
                   "\nCliente: " + Cliente.toString() +
                   "\nAbogado: " + Abogado.toString() +
                   "\nDescripcion: " + descripcion +
                   "\nTurno: " + fechaTurno +
                   "\nAusente: " + ausente +
                   "\nAtendido :" + atendido;
        }
    }
}