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

        public Cliente BuscarClienteById(int id)
        {
            List<Cliente> clientes = GetClientes();
            foreach(Cliente c in clientes)
            {
                if(c.IdCliente == id)
                {
                    return c;
                }
            }
            return null;
        }

        public Libro BuscarLibroById(int id)
        {
            List<Libro> libros = GetLibros();
            foreach (Libro l in libros)
            {
                if (l.Id == id)
                {
                    return l;
                }
            }
            return null;
        }

        public Prestamo BuscarPrestamoById(int id)
        {
            List<Prestamo> prestamos = GetPrestamos();
            foreach (Prestamo p in prestamos)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }
            return null;
        }

        public Ejemplar BuscarEjemplarById(int id)
        {
            List<Ejemplar> ejemplares = GetEjemplares();
            foreach (Ejemplar e in ejemplares)
            {
                if (e.Id == id)
                {
                    return e;
                }
            }
            return null;
        }

        public List<Ejemplar> BuscarEjemplaresByIdLibro(int id)
        {

            List<Ejemplar> ejemplares = ejemplarMapper.TraerPorLibro(id);
            if(ejemplares.Count == 0)
            {
                throw new SinEjemplaresException(id);
            }
            else
            {
                return ejemplares;
            }
        }

        public void IngresarCliente(string nombre, string apellido, string direccion, long telefono, string mail, bool activo)
        {
            int idNuevoCliente = this.UltimoCodCliente() + 1;
            Cliente cliente = new Cliente(idNuevoCliente, DateTime.Now.ToShortDateString(), activo, idNuevoCliente, nombre, apellido, direccion, telefono, mail);
            clienteMapper.Insert(cliente);
        }

        private int UltimoCodCliente()
        {
            List <Cliente> clientes = this.GetClientes();
            if(clientes.Count == 0)
            {
                return 0;
            }
            else
            {
                return clientes.LastOrDefault().IdCliente;
            }
        }

        private int UltimoCodLibro()
        {
            List<Libro> libros = this.GetLibros();
            if (libros.Count == 0)
            {
                return 0;
            }
            else
            {
                return libros.LastOrDefault().Id;
            }
        }

        private int UltimoCodEjemplar()
        {
            List<Ejemplar> ejemplares = this.GetEjemplares();
            if (ejemplares.Count == 0)
            {
                return 0;
            }
            else
            {
                return ejemplares.LastOrDefault().Id;
            }
        }

        private int UltimoCodPrestamo()
        {
            List<Prestamo> prestamos = this.GetPrestamos();
            if (prestamos.Count == 0)
            {
                return 0;
            }
            else
            {
                return prestamos.LastOrDefault().Id;
            }
        }

    }
}
