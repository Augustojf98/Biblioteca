﻿using System;
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
        private int _idEjemplar;
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

        public bool EstaAbierto()
        {
            if(this._fechaBajaReal == null)
            {
                return true;
            }
            else
            {
                return false;
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
        //que onda el plazo? deberia ser un calculo no? 
        public Prestamo(int id, int idCliente, int idEjemplar, int plazo, string fechaAlta, string fechaBaja, string fechaBajaReal)
        {
            this._id = id;
            this._idCliente = idCliente;
            this._plazo = plazo;
            this._fechaAlta = Convert.ToDateTime(fechaAlta);
            this._fechaBaja = Convert.ToDateTime(fechaBaja);
            this._fechaBajaReal = Convert.ToDateTime(fechaBajaReal);

        }
        
       

        



    }
}
