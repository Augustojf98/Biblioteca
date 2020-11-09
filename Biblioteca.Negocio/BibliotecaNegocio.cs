using Biblioteca.Datos;
using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio
{
    public class BibliotecaNegocio
    {
        private ClienteMapper clienteMapper;
        private LibroMapper libroMapper;
        private PrestamoMapper prestamoMapper;
        private EjemplarMapper ejemplarMapper;

        public BibliotecaNegocio()
        {
            clienteMapper = new ClienteMapper();
            libroMapper = new LibroMapper();
            ejemplarMapper = new EjemplarMapper();
            prestamoMapper = new PrestamoMapper();
        }

        public List<Cliente> GetClientes()
        {
            List<Cliente> clientes = this.clienteMapper.TraerTodos();
            if(clientes.Count == 0)
            {
                throw new SinClientesException();
            }
            else
            {
                return clientes;
            }
        }

        public List<Libro> GetLibros()
        {
            List<Libro> libros = this.libroMapper.TraerTodos();
            if (libros.Count == 0)
            {
                throw new SinLibrosException();
            }
            else
            {
                return libros;
            }
        }

        public List<Ejemplar> GetEjemplares()
        {
            List<Ejemplar> ejemplares = this.ejemplarMapper.TraerTodos();
            if (ejemplares.Count == 0)
            {
                throw new SinEjemplaresException();
            }
            else
            {
                return ejemplares;
            }
        }

        public List<Prestamo> GetPrestamos()
        {
            List<Prestamo> prestamos = this.prestamoMapper.TraerTodos();
            if (prestamos.Count == 0)
            {
                throw new SinPrestamosException();
            }
            else
            {
                return prestamos;
            }
        }

        public void IngresarCliente(string nombre, string apellido, string direccion, long telefono, string mail, bool activo)
        {

        }

    }
}
