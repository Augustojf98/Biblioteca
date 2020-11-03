using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Biblioteca.Entidades 
{
    [DataContract]

    public class Prestamo
    {
        private int _numeroOperacion;
        private int _idCliente;
        private DateTime _fechaHoraPrestamo;
        private DateTime _fechaDevolucionTentativa;
        private DateTime _fechaDevolucionReal;
        private Cliente _cliente;
        private Ejemplar _ejemplar; 

        [DataMember]

        public int NumeroOperacion
        {
            get
            {
                return this._numeroOperacion;
            }
            set
            {
                this._numeroOperacion = value;
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

        public DateTime FechaHoraPrestamo
        {
            get
            {
                return this._fechaHoraPrestamo;
            }
            set
            {
                this._fechaHoraPrestamo = value;
            }
        }

        [DataMember]

        public DateTime FechaDevolucionTentativa
        {
            get
            {
                return this._fechaDevolucionTentativa;
            }
            set
            {
                this._fechaDevolucionTentativa = value;
            }
        }

        [DataMember]

        public DateTime FechaDevolucionReal
        {
            get
            {
                return this._fechaDevolucionReal;
            }

            set
            {
                this._fechaDevolucionReal = value;
            }
        }

        //no estoy seguro como hacer el get set de un cliente y ejemplar. 
        
       

        



    }
}
