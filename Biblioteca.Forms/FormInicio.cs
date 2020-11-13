using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.CargarClientes();
            this.CargarLibros();
            this.CargarEjemplares();
            this.CargarPrestamos();
            this.comboBox1.DataSource = biblioteca.GetLibros();

            if(biblioteca.GetLibros().Count == 0)
            {
                this.comboBox1.Items.Add("No hay libros cargados");
                this.comboBox1.Enabled = false;
            }
        }

        private void CargarClientes()
        {
            this.checkedListBox1.Items.Clear();
            List<Cliente> lista = biblioteca.GetClientes();
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
            //var clientesEliminados = this.checkedListBox1.CheckedItems.OfType<Cliente>();

            //List<Cliente> clientes = clientesEliminados.ToList();

            //foreach (Cliente cliente in clientes)
            //{
            //    this.checkedListBox1.Items.Remove(cliente);
            //    biblioteca.EliminarCliente(cliente);
            //}

            //this.CargarClientes();
            FormException formException = new FormException("Función en desarrollo", "Próximamente esta función será habilitada");
            formException.Owner = this;
            formException.Show();
            this.Enabled = false;
        }
    }
}
