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
        private int _id;
        private int _idCliente;
        private string _nombreCompletoCliente;
        private int _idEjemplar;
        private string _nombreEjemplar;
        private int _plazo; 
        private DateTime _fechaAlta;
        private DateTime _fechaBaja;
        private DateTime _fechaBajaReal;
  
        [DataMember]

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
        public bool EstaAbierto
        {
            get
            {
                if (this._fechaBajaReal == Convert.ToDateTime("01-01-1800"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

        public int IdEjemplar
        {
            get
            {
                return this._idEjemplar;
            }
            set
            {
                this._idEjemplar = value;
            }
        }

        [DataMember]

        public int Plazo
        {
            get
            {
                return this._plazo;
            }
            set
            {
                this._plazo = value;
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

        public DateTime FechaBaja
        {
            get
            {
                return this._fechaBaja;
            }
            set
            {
                this._fechaBaja = value;
            }
        }

        [DataMember]

        public DateTime FechaBajaReal
        {
            get
            {
                return this._fechaBajaReal;
            }

            set
            {
                this._fechaBajaReal = value;
            }
        }
        
        public Prestamo(int id, int idCliente, int idEjemplar, int plazo, string fechaAlta, string fechaBaja)
        {
            this._id = id;
            this._idCliente = idCliente;
            this._idEjemplar = idEjemplar;
            this._plazo = plazo;
            this._fechaAlta = Convert.ToDateTime(fechaAlta);
            this._fechaBaja = Convert.ToDateTime(fechaBaja);
            this._fechaBajaReal = Convert.ToDateTime("01-01-1800");

        }

        public string NombreCompletoCliente
        {
            get
            {
                return this._nombreCompletoCliente;
            }
            set
            {
                this._nombreCompletoCliente = value;
            }
        }

        public string NombreEjemplar
        {
            get
            {
                return this._nombreEjemplar;
            }
            set
            {
                this._nombreEjemplar = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Cliente: {0} | Plazo: {1} días | Titulo: {2} | Fecha Alta: {3} | Fecha Baja: {4}", _idCliente, _plazo, /*_idEjemplar*/ _nombreEjemplar, _fechaAlta, _fechaBaja);
        }





    }
}
