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
        private int _codigo;
        private int _codigoLibro;
        private string _descripcion;
        private double _precio;
        private DateTime _fechaAlta;
        private Libro _libro; 

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

        public int CodigoLibro
        {
            get
            {
                return this._codigoLibro; 
            }
            set
            {
                this._codigoLibro = value; 
            }
        }

        [DataMember]
        public string Descripcion
        {
            get
            {
                return this._descripcion; 
            }
            set
            {
                this._descripcion = value; 
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
        //falta libro. 
    }

}
