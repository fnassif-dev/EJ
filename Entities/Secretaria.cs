using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Secretaria
    {
        private int id;
        private string nombre;
        private string secretario;
        private int juzgado;

        //CONSTRUCTORES
        public Secretaria()
        {
            id = 0;
            nombre = string.Empty;
            secretario = string.Empty;
            juzgado = 0;
        }
        public Secretaria(int pId, string pNombre, string pSecretario, int pJuzgado)
        {
            id = pId;
            nombre = pNombre;
            secretario = pSecretario;
            juzgado = pJuzgado;
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
        public string Secretario
        {
            get { return secretario; }
            set { secretario = value; }
        }
        public int Juzgado
        {
            get { return juzgado; }
            set { juzgado = value; }
        }

        //METODOS ADICIONALES
        public string toString()
        {
            return "Id: " + id +
                   "\nNombre: " + nombre +
                   "\nSecretario: " + secretario +
                   "\nJuzgado: " + juzgado;
        }
    }
}