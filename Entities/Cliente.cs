using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Cliente
    {
        private int id;
        private string nombre;
        private string apellido;
        private TipoDocumento tipoDocumento;
        private int documento;
        private DateTime fechaNacimiento;
        private EstadoCivil estadoCivil;
        private string ocupacion;
        private string sexo;
        private string nacionalidad;
        private Provincia provincia;
        private Ciudad ciudad;
        private string direccion;
        private string telefono;
        private string celular;
        private string observaciones;

        //CONSTRUCTORES
        public Cliente()
        {
            id = 0;
            nombre = string.Empty;
            apellido = string.Empty;
            tipoDocumento = null;
            documento = 0;
            fechaNacimiento = DateTime.Now;
            estadoCivil = null;
            ocupacion = string.Empty;
            sexo = string.Empty;
            nacionalidad = string.Empty;
            provincia = null;
            ciudad = null;
            direccion = string.Empty;
            telefono = string.Empty;
            celular = string.Empty;
            observaciones = string.Empty;
        }
        public Cliente(int pId, string pNombre, string pApellido, TipoDocumento pTipoDocumento, int pDocumento, DateTime pFechaNacimiento, 
                       EstadoCivil pEstadoCivil, string pSexo, string pOcupacion, Provincia pProvincia, Ciudad pCiudad, 
                       string pDireccion, string pTelefono, string pCelular, string pObservaciones)
        {
            id = pId;
            nombre = pNombre;
            apellido = pApellido;
            tipoDocumento = pTipoDocumento;
            documento = pDocumento;
            fechaNacimiento = pFechaNacimiento;
            estadoCivil = pEstadoCivil;
            ocupacion = pOcupacion;
            sexo = pSexo;
            provincia = pProvincia;
            ciudad = pCiudad;
            direccion = pDireccion;
            telefono = pTelefono;
            celular = pCelular;
            observaciones = pObservaciones;
        }

        //PROPIEDADES GET Y SET
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public TipoDocumento TipoDocumento
        {
            get { return tipoDocumento; }
            set { tipoDocumento = value; }
        }
        public int Documento
        {
            get { return documento; }
            set { documento = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        public EstadoCivil EstadoCivil
        {
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }
        public string Ocupacion
        {
            get { return ocupacion; }
            set { ocupacion = value; }
        }
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public string Nacionalidad
        {
            get { return nacionalidad; }
            set { nacionalidad = value; }
        }
        public Provincia Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }
        public Ciudad Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }
        public string ApellidoNombre
        {
            get { return apellido.ToUpper() + ", " + nombre; }
        }

        //METODOS
        public string toString()
        {
            return "Id: " + id +
                   "\nNombre: " + nombre +
                   "\nApellido: " + apellido +
                   "\nTipo de Dcoumento: " + this.TipoDocumento.Descripcion +
                   "\nDocumento: " + documento +
                   "\nFecha de Nacimiento: " + fechaNacimiento +
                   "\nEstado Civil: " + this.EstadoCivil.Descripcion +
                   "\nOcupacion: " + ocupacion +
                   "\nSexo: " + sexo +
                   "\nProvincia: " + this.Provincia.Descripcion +
                   "\nCiudad: " + this.Ciudad.Descripcion +
                   "\nDireccion: " + direccion +
                   "\nTelefono: " + telefono +
                   "\nCelular: " + celular;
        }
    }
}