using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Negocio;
using Biblioteca.Entidades;

namespace Biblioteca.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            BibliotecaNegocio biblioteca = new BibliotecaNegocio();

            try
            {
                //biblioteca.IngresarCliente("pedro", "perez", "asd 123", 12345678, "asdasd@asd", true);
                //biblioteca.IngresarLibro("asd", "jorge", 2,"rouler", 212, "qweq");

                List<Cliente> libros = biblioteca.GetClientes();

                foreach (Cliente l in libros)
                {
                    Console.WriteLine(l.ToString());
                }

            }
            catch (SinClientesException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
