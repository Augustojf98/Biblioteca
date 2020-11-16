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
        private List<Cliente> _clientes;
        private List<Libro> _libros;
        private List<Ejemplar> _ejemplares;
        private List<Prestamo> _prestamos;

        public List<Cliente> Clientes
        {
            get
            {
                return this._clientes;
            }
            set
            {
                this._clientes = value;
            }
        }

        public List<Libro> Libros
        {
            get
            {
                return this._libros;
            }
            set
            {
                this._libros = value;
            }
        }

        public List<Ejemplar> Ejemplares
        {
            get
            {
                return this._ejemplares;
            }
            set
            {
                this._ejemplares = value;
            }
        }

        public List<Prestamo> Prestamos
        {
            get
            {
                return this._prestamos;
            }
            set
            {
                this._prestamos = value;
            }
        }

        public BibliotecaNegocio()
        {
            clienteMapper = new ClienteMapper();
            libroMapper = new LibroMapper();
            ejemplarMapper = new EjemplarMapper();
            prestamoMapper = new PrestamoMapper();
            _clientes = new List<Cliente>();
            _libros = new List<Libro>();
            _ejemplares = new List<Ejemplar>();
            _prestamos = new List<Prestamo>();
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
                this._clientes = clientes;
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
                this._libros = libros;
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
                this._ejemplares = ejemplares;
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
                this._prestamos = prestamos;
                return prestamos;
            }
        }

        public Cliente BuscarClienteById(int id)
        {
            //List<Cliente> clientes = GetClientes();
            foreach(Cliente c in this._clientes)
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
            //List<Libro> libros = GetLibros();
            foreach (Libro l in this._libros)
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
            //List<Prestamo> prestamos = GetPrestamos();
            foreach (Prestamo p in this._prestamos)
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
            //List<Ejemplar> ejemplares = GetEjemplares();
            foreach (Ejemplar e in this._ejemplares)
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

        public int EliminarCliente(Cliente cliente)
        {
            TransactionResult result = clienteMapper.Delete(cliente);

            if (result.IsOk)
            {
                return result.Id;
            }
            else
            {
                throw new Exception(string.Format("Ocurrió un error en el servidor. Detalle: \"{0}\"", result.Error));
            }
        }

        public int IngresarCliente(string nombre, string apellido, string direccion, string telefono, string mail, bool activo)
        {
            List<Cliente> clientes = this.GetClientes();
            int idNuevoCliente = this.UltimoCodCliente() + 1;

            Cliente cliente = new Cliente(idNuevoCliente, DateTime.Now.ToShortDateString(), activo, idNuevoCliente, nombre, apellido, direccion, telefono, mail);

            foreach (Cliente c in clientes)
            {
                if(c.Nombre.ToUpper() == cliente.Nombre.ToUpper() && c.Apellido.ToUpper() == cliente.Apellido.ToUpper())
                {
                    throw new Exception(string.Format("Ya existe un cliente llamado \"{0} {1}\"", nombre, apellido));
                }
                if (c.Telefono == cliente.Telefono || c.Mail.ToUpper() == cliente.Mail.ToUpper())
                {
                    throw new Exception(string.Format("El email \"{0}\" o el teléfono \"{1}\" se encuentran ya registrados.", mail, telefono));
                }
            }

            TransactionResult result = clienteMapper.Insert(cliente);

            if (result.IsOk)
            {
                this._clientes.Add(cliente);
                return result.Id;
            }
            else
            {
                throw new Exception(string.Format("Ocurrió un error en el servidor. Detalle: \"{0}\"", result.Error));
            }

        }

        public int IngresarLibro(string titulo, string autor, int edicion, string editorial, int paginas, string tema)
        {
            List<Libro> libros = this.GetLibros();
            int idNuevoLibro = this.UltimoCodLibro() + 1;

            Libro libro = new Libro(idNuevoLibro, titulo, autor, edicion, editorial, paginas, tema);

            foreach (Libro l in libros)
            {
                if (l.ToString() == libro.ToString())
                {
                    throw new Exception(string.Format("Ya existe el libro"));
                }
            }

            TransactionResult result = libroMapper.Insert(libro);

            if (result.IsOk)
            {
                this._libros.Add(libro);
                return result.Id;
            }
            else
            {
                throw new Exception(string.Format("Ocurrió un error en el servidor. Detalle: \"{0}\"", result.Error));
            }

        }

        public int IngresarPrestamo(int idCliente, int idEjemplar, int plazo, DateTime fechaAlta, DateTime fechaBaja, string tema)
        {
            List<Prestamo> prestamos = this.GetPrestamos();
            int idNuevoPrestamo = this.UltimoCodPrestamo() + 1;

            Prestamo prestamo = new Prestamo(idNuevoPrestamo, idCliente, idEjemplar, plazo, fechaAlta.ToShortDateString(), fechaBaja.ToShortDateString(), string.Empty);

            foreach (Prestamo p in prestamos)
            {
                if (p.ToString() == prestamo.ToString())
                {
                    throw new Exception(string.Format("Ya existe el prestamo"));
                }
            }

            TransactionResult result = prestamoMapper.Insert(prestamo);

            if (result.IsOk)
            {
                this._prestamos.Add(prestamo);
                return result.Id;
            }
            else
            {
                throw new Exception(string.Format("Ocurrió un error en el servidor. Detalle: \"{0}\"", result.Error));
            }

        }

        public int IngresarEjemplar(int idLibro, string observaciones, double precio, DateTime fechaAlta)
        {
            List<Ejemplar> ejemplares = this.GetEjemplares();
            int idNuevoEjemplar = this.UltimoCodEjemplar() + 1;

            Ejemplar ejemplar = new Ejemplar(idNuevoEjemplar, idLibro, observaciones, precio, fechaAlta.ToShortDateString());

            foreach (Ejemplar e in ejemplares)
            {
                if (e.ToString() == ejemplar.ToString())
                {
                    throw new Exception(string.Format("Ya existe el ejemplar."));
                }
            }

            TransactionResult result = ejemplarMapper.Insert(ejemplar);

            if (result.IsOk)
            {
                this._ejemplares.Add(ejemplar);
                return result.Id;
            }
            else
            {
                throw new Exception(string.Format("Ocurrió un error en el servidor. Detalle: \"{0}\"", result.Error));
            }

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
