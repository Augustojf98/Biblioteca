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
        protected int _id;
        protected string _nombre;
        protected int? _dni;
        protected string _apellido;
        protected string _direccion;
        protected string _telefono;
        protected string _mail;

        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        [DataMember]
        public int? DNI
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
        public string Mail
        {
            get
            {
                return this._mail;
            }
            set
            {
                this._mail = value;
            }
        }



    }
}
