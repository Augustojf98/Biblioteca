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
    }
}
