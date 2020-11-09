using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class SinLibrosException : Exception
    {
        public SinLibrosException() : base("No hay libros cargados")
        {

        }
    }

    public class SinPrestamosException : Exception
    {
        public SinPrestamosException() : base("No hay préstamos cargados")
        {

        }
    }

    public class SinEjemplaresException : Exception
    {
        public SinEjemplaresException() : base("No hay ejemplares cargados")
        {

        }
        public SinEjemplaresException(int idLibro) : base(string.Format("No hay ejemplares cargados para el libro de código \"{0}\".", idLibro))
        {

        }
    }

    public class SinClientesException : Exception
    {
        public SinClientesException() : base("No hay clientes cargados")
        {

        }
    }
}
