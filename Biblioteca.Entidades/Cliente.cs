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
        public Cliente(int idcliente,string fechaAlta,bool activo,int id, string nombre, string apellido, string direccion, long telefono, string mail):base(id, nombre, apellido, direccion, telefono, mail)
        {
            this._idCliente = idcliente;
            this._fechaAlta = Convert.ToDateTime(fechaAlta);
            this._activo = activo; 
        }
    }
 
}

