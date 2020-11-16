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
            this.CargaInicial();
            this.CargarArrays();
            this.comboBox1.DataSource = biblioteca.GetLibros();

            if(biblioteca.GetLibros().Count == 0)
            {
                this.comboBox1.Items.Add("No hay libros cargados");
                this.comboBox1.Enabled = false;
            }
        }

        public void CargarArrays()
        {
            if(biblioteca.Clientes.Count > 0)
            {
                this.checkedListBox1.Enabled = true;
                foreach (Cliente cliente in biblioteca.Clientes)
                {
                    this.checkedListBox1.Items.Add(cliente);
                }
            }
            else
            {
                this.checkedListBox1.Items.Add("No hay clientes guardados");
                this.checkedListBox1.Enabled = false;
            }
            if (biblioteca.Libros.Count > 0)
            {
                this.checkedListBox2.Enabled = true;
                foreach (Libro libro in biblioteca.Libros)
                {
                    this.checkedListBox2.Items.Add(libro);
                }
            }
            else
            {
                this.checkedListBox2.Items.Add("No hay libros guardados");
                this.checkedListBox2.Enabled = false;
            }
            if (biblioteca.Ejemplares.Count > 0)
            {
                this.checkedListBox3.Enabled = true;
                foreach (Ejemplar ejemplar in biblioteca.Ejemplares)
                {
                    this.checkedListBox3.Items.Add(ejemplar);
                }
            }
            else
            {
                this.checkedListBox3.Items.Add("No hay ejemplares guardados");
                this.checkedListBox3.Enabled = false;
            }
            if (biblioteca.Prestamos.Count > 0)
            {
                this.checkedListBox4.Enabled = true;
                foreach (Prestamo prestamo in biblioteca.Prestamos)
                {
                    this.checkedListBox4.Items.Add(prestamo);
                }
            }
            else
            {
                this.checkedListBox4.Items.Add("No hay préstamos registrados");
                this.checkedListBox4.Enabled = false;
            }
        }

        private void CargaInicial()
        {
            this.CargarClientes();
            this.CargarEjemplares();
            this.CargarLibros();
            this.CargarPrestamos();
        }

        private void CargarClientes()
        {
            biblioteca.Clientes = biblioteca.GetClientes();
        }

        private void CargarLibros()
        {
            biblioteca.Libros = biblioteca.GetLibros();
        }

        private void CargarEjemplares()
        {
            biblioteca.Ejemplares = biblioteca.GetEjemplares();
        }

        private void CargarPrestamos()
        {
            biblioteca.Prestamos = biblioteca.GetPrestamos();
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
            formAltaLibro.FormClosed += FormAltaLibro_FormClosed;
        }

        private void FormAltaLibro_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.CargarArrays();
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
            formAltaCliente.FormClosed += FormAltaCliente_FormClosed;
            //this.Refrescar();
        }

        private void FormAltaCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.CargarArrays();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAltaEjemplar formAltaEjemplar = new FormAltaEjemplar(biblioteca);
            formAltaEjemplar.Owner = this;
            formAltaEjemplar.Show();
            this.Enabled = false;
            formAltaEjemplar.FormClosed += FormAltaEjemplar_FormClosed;
            //this.Refrescar();
        }

        private void FormAltaEjemplar_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.CargarArrays();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormAltaPrestamo formAltaPrestamo = new FormAltaPrestamo(biblioteca);
            formAltaPrestamo.Owner = this;
            formAltaPrestamo.Show();
            this.Enabled = false;
            formAltaPrestamo.FormClosed += FormAltaPrestamo_FormClosed;
            //this.Refrescar();
        }

        private void FormAltaPrestamo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.CargarArrays();
        }
    }
}
