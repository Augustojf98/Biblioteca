using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public abstract class Persona
    {
        protected int _id;
        protected string _nombre;
        protected string _apellido;
        protected string _direccion;
        protected string _mail;
        protected long _telefono;
    }
}
