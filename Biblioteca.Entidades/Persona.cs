using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Biblioteca.Entidades
{
    [DataContract]
    public class Persona
    {
        protected int _dni;
        protected string _nombre;
        protected string _apellido;
        protected string _direccion;
        protected string _telefono;
        protected string _email;
        protected DateTime _fechaNacimiento;

        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = value;
            }
        }

        [DataMember]
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }

        [DataMember]
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = value;
            }
        }

        [DataMember]
        public string Direccion
        {
            get
            {
                return this._direccion;
            }
            set
            {
                this._direccion = value;
            }
        }

        [DataMember]
        public string Telefono
        {
            get
            {
                return this._telefono;
            }
            set
            {
                this._telefono = value;
            }
        }

        [DataMember]
        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
            }
        }

        [DataMember]
        public DateTime FechaNacimiento
        {
            get
            {
                return this._fechaNacimiento;
            }
            set
            {
                this._fechaNacimiento = value;
            }
        }


    }
}
