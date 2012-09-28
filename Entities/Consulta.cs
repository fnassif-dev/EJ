using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Consulta
    {
        private int id;
        private string descripcion;
        private Cliente cliente;
        private Abogado abogado;
        private TemaConsulta temaConsulta;
        private int estado;
        private DateTime fecha;

        //CONSTRUCTORES
        public Consulta()
        {
            id = 0;
            descripcion = string.Empty;
            cliente = null;
            abogado = null;
            temaConsulta = null;
            estado = 0;
            fecha = DateTime.Now;
        }
        public Consulta(int pId, string pDescripcion, Cliente pCliente, Abogado pAbogado, TemaConsulta pTemaConsulta, int pEstado, DateTime pFecha)
        {
            id = pId;
            descripcion = pDescripcion;
            cliente = pCliente;
            abogado = pAbogado;
            temaConsulta = pTemaConsulta;
            estado = pEstado;
            fecha = pFecha;
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
        public TemaConsulta TemaConsulta
        {
            get { return temaConsulta; }
            set { temaConsulta = value; }
        }
        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        //METODOS
        public string toString()
        {
            return "Id: " + id +
                   "\nDescripcion: " + descripcion +
                   "\nCliente: " + this.Cliente.toString() +
                   "\nAbogado: " + this.Abogado.toString() +
                   "\nTema de Consulta: " + this.TemaConsulta.toString() +
                   "\nEstado: " + estado +
                   "\nFecha: " + fecha;
        }
    }
}
