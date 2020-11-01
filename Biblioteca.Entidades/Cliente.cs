using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    [DataContract]
    public class Cliente : Persona
    {
        private int _idCliente;
        private DateTime _fechaAlta;
        private bool _activo;

        [DataMember]
        public int IdPersona
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
        public int IdCliente
        {
            get
            {
                return this._idCliente;
            }
            set
            {
                this._idCliente = value;
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
        public long Telefono
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
        public DateTime FechaAlta
        {
            get
            {
                return this._fechaAlta;
            }
            set
            {
                this._fechaAlta = value;
            }
        }

        [DataMember]
        public bool Activo
        {
            get
            {
                return this._activo;
            }
            set
            {
                this._activo = value;
            }
        }
    }
}
