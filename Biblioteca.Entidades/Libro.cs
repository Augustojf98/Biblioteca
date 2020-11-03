using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    [DataContract]
    public class Libro
    {
        private long _ISBN;
        private string _titulo;
        private string _autor;
        private int _edicion;
        private string _editorial;
        private int _cantPaginas;
        private string _tema;
        private int _stockPermanente;
        private int _stockDisponible;

       [DataMember]

       public long ISBN
        {
            get
            {
                return this._ISBN;
            }
            set
            {
                this._ISBN = value; 
            }
        }

        [DataMember]

        public string Titulo
        {
            get 
            {
                return this._titulo;
            }
            set
            {
                this._titulo = value; 
            }
        }

        [DataMember]

        public string Autor
        {
            get
            {
                return this._autor; 
            }
            set
            {
                this._autor = value; 
            }
        }

        [DataMember]

        public int Edicion
        {
            get
            {
                return this._edicion;
            }
            set
            {
                this._edicion = value; 
            }
        }

        [DataMember]
        public string Editorial
        {
            get
            {
                return this._editorial; 
            }
            set
            {
                this._editorial = value; 
            }
        }
        [DataMember]

        public int CantPaginas
        {
            get
            {
                return this._cantPaginas; 
            }
            set
            {
                this._cantPaginas = value; 
            }
        }

        [DataMember]

        public string Tema
        {
            get
            {
                return this._tema; 
            }
            set
            {
                this._tema = value; 
            }
        }

        [DataMember]

        public int StockPermanente
        {
            get
            {
                return this._stockPermanente; 
            }
            set
            {
                this._stockPermanente = value; 
            }
        }

        [DataMember]

        public int StockDisponible
        {
            get
            {
                return this._stockDisponible; 
            }
            set
            {
                this._stockDisponible = value; 
            }
        }
    }
}
