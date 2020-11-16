using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    [DataContract]
    public class Ejemplar
    {
        private int _id;
        private int _idLibro;
        private string _nombreLibro;
        private string _observaciones;
        private double _precio;
        private DateTime _fechaAlta;
      

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

        public int IdLibro
        {
            get
            {
                return this._idLibro; 
            }
            set
            {
                this._idLibro = value; 
            }
        }

        [DataMember]
        public string Observaciones
        {
            get
            {
                return this._observaciones; 
            }
            set
            {
                this._observaciones = value; 
            }
        }

        [DataMember]

        public double Precio
        {
            get
            {
                return this._precio; 
            }
            set
            {
                this._precio = value; 
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

        public Ejemplar(int id, int idLibro,string observaciones, double precio, string fechaAlta)
        {
            this._id = id;
            this._idLibro = idLibro;
            this._observaciones = observaciones;
            this._precio = precio;
            this._fechaAlta = Convert.ToDateTime(fechaAlta);
        }

        public string NombreLibro
        {
            get
            {
                return this._nombreLibro;
            }
            set
            {
                this._nombreLibro = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} | {1} | $ {2} | {3}", _nombreLibro?.ToUpper(), _observaciones, _precio, _fechaAlta);
        }
    }

}
