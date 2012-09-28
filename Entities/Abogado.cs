using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Abogado
    {
        private int id;
        private string nombre;
        private string apellido;
        private string userId;
        private TipoDocumento tipoDocumento;
        private int documento;
        private DateTime fechaNacimiento;
        private EstadoCivil estadocivil;
        private Provincia provincia;
        private Ciudad ciudad;
        private string direccion;
        private string telefono;
        private string celular;

        //CONSTRUCTORES
        public Abogado()
        {
            id = 0;
            nombre = string.Empty;
            apellido = string.Empty;
            userId = string.Empty;
            tipoDocumento = null;
            documento = 0;
            fechaNacimiento = DateTime.Now;
            estadocivil = null;
            provincia = null;
            ciudad = null;
            direccion = string.Empty;
            telefono = string.Empty;
            celular = string.Empty;
        }
        public Abogado(int pId, string pNombre, string pApellido, string pUserId, TipoDocumento pTipoDcoumento, int pDocumento, DateTime pFechaNacimiento,
                       EstadoCivil pEstadoCivil, Provincia pProvincia, Ciudad pCiudad, string pDireccion, string pTelefono, string pCelular)
        {
            id = pId;
            nombre = pNombre;
            apellido = pApellido;
            userId = pUserId;
            tipoDocumento = pTipoDcoumento;
            documento = pDocumento;
            fechaNacimiento = pFechaNacimiento;
            estadocivil = pEstadoCivil;
            provincia = pProvincia;
            ciudad = pCiudad;
            direccion = pDireccion;
            telefono = pTelefono;
            celular = pCelular;
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
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
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
            get { return estadocivil; }
            set { estadocivil = value; }
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
                   "\nUser ID: " + userId +
                   "\nTipo de Documento: " + this.TipoDocumento.Descripcion +
                   "\nDocumento: " + documento +
                   "\nFecha de Nacimiento: " + fechaNacimiento +
                   "\nEstado Civil: " + this.EstadoCivil.Descripcion +
                   "\nProvincia: " + this.provincia.Descripcion +
                   "\nCiudad: " + this.Ciudad.Descripcion +
                   "\nDireccion: " + direccion +
                   "\nTelefono: " + telefono +
                   "\nCelular: " + celular;
        }
    }
}