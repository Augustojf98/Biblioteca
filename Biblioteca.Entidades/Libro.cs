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
        private long _id;
        private string _titulo;
        private string _autor;
        private int _edicion;
        private string _editorial;
        private int _paginas;
        private string _tema;
       
       [DataMember]

       public long Id
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

        public int Paginas
        {
            get
            {
                return this._paginas; 
            }
            set
            {
                this._paginas = value; 
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

       public Libro(int id, string titulo, string autor, int edicion, string editorial,int paginas, string tema)
        {
            this._id = id;
            this._titulo = titulo;
            this._autor = autor;
            this._edicion = edicion;
            this._editorial = editorial;
            this._paginas = paginas;
            this._tema = tema; 
        }

        
    }
}
