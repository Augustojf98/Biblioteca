using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Windows.Forms;
using Biblioteca.Negocio;
using Biblioteca.Entidades;

namespace Biblioteca.Forms
{
    public partial class FormInicio : Form
    {
        private BibliotecaNegocio biblioteca;

        public FormInicio()
        {
            InitializeComponent();
            biblioteca = new BibliotecaNegocio();
            this.Refrescar();
            this.comboBox1.DataSource = biblioteca.GetLibros();

            if(biblioteca.GetLibros().Count == 0)
            {
                this.comboBox1.Items.Add("No hay libros cargados");
                this.comboBox1.Enabled = false;
            }
        }

        private void Refrescar()
        {
            this.CargarClientes();
            this.CargarEjemplares();
            this.CargarLibros();
            this.CargarPrestamos();
        }

        private void CargarClientes()
        {

            //this.checkedListBox1.Items.Clear();
            List<Cliente> lista = biblioteca.GetClientes();

            //string value;
            //value = Program.Cache[CLIENTES_CACHE_KEY] as string;
            //if (value == null)
            //{
            //    value = biblioteca.GetClientes().ToString();
            //}
            //else
            //{
            //    Program.Cache.Insert(
            //    CLIENTES_CACHE_KEY,
            //    value,
            //    null,
            //    Cache.NoAbsoluteExpiration,
            //    TimeSpan.FromSeconds(60));
            //}

            //lista = value;

            foreach (Cliente cliente in lista)
            {
                this.checkedListBox1.Items.Add(cliente);
            }

        }

        private void CargarLibros()
        {
            List<Libro> lista = biblioteca.GetLibros();
            foreach (Libro libro in lista)
            {
                this.checkedListBox2.Items.Add(libro);
            }
        }

        private void CargarEjemplares()
        {
            List<Ejemplar> lista = biblioteca.GetEjemplares();
            foreach (Ejemplar ejemplar in lista)
            {
                this.checkedListBox2.Items.Add(ejemplar);
            }
        }

        private void CargarPrestamos()
        {
            List<Prestamo> lista = biblioteca.GetPrestamos();
            foreach (Prestamo prestamo in lista)
            {
                this.checkedListBox4.Items.Add(prestamo);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //List<Cliente> clientes = this.checkedListBox1.CheckedItems.OfType<Cliente>().ToList();

            //foreach (Cliente cliente in clientes)
            //{
            //    biblioteca.EliminarCliente(cliente);
            //    this.checkedListBox1.Items.Remove(cliente);
            //}

            //this.CargarClientes();
            FormException formException = new FormException("Función en desarrollo", "Próximamente esta función será habilitada");
            formException.Owner = this;
            formException.Show();
            this.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAltaLibro formAltaLibro = new FormAltaLibro(biblioteca);
            formAltaLibro.Owner = this;
            formAltaLibro.Show();
            this.Enabled = false;
            this.Refrescar();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAltaCliente formAltaCliente = new FormAltaCliente(biblioteca);
            formAltaCliente.Owner = this;
            formAltaCliente.Show();
            this.Enabled = false;
            this.Refrescar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAltaEjemplar formAltaEjemplar = new FormAltaEjemplar(biblioteca);
            formAltaEjemplar.Owner = this;
            formAltaEjemplar.Show();
            this.Enabled = false;
            this.Refrescar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormAltaPrestamo formAltaPrestamo = new FormAltaPrestamo(biblioteca);
            formAltaPrestamo.Owner = this;
            formAltaPrestamo.Show();
            this.Enabled = false;
            this.Refrescar();
        }
    }
}
