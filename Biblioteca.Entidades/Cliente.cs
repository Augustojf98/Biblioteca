using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    [DataContract]
    public class Cliente 
    {
        private int _codigo;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private long _telefono;
        private string _mail; 
       

 

        [DataMember]
        public int Codigo
        {
            get
            {
                return this._codigo;
            }
            set
            {
                this._codigo = value;
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

      
     
    }
 
}

