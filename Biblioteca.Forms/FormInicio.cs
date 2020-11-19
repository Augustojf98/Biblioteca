﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
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
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

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
            this.CargarLibros();
            this.CargarEjemplares();
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
            try
            {
                List<Cliente> clientes = this.checkedListBox1.CheckedItems.OfType<Cliente>().ToList();

                foreach (Cliente cliente in clientes)
                {
                    biblioteca.EliminarCliente(cliente);
                    this.checkedListBox1.Items.Remove(cliente);
                }
            }
            catch (Exception ex)
            {
                FormException formException = new FormException("Error", ex.Message);
                formException.Owner = this;
                formException.Show();
                this.Enabled = false;
            }

            //FormException formException = new FormException("Función en desarrollo", "Próximamente esta función será habilitada");
            //formException.Owner = this;
            //formException.Show();
            //this.Enabled = false;
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
        }

        private void FormAltaEjemplar_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.CargarArrays();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkedListBox4.SelectedItems.Count == 1)
            {
                FormGestionarPrestamo formGestionarPrestamo = new FormGestionarPrestamo(checkedListBox4.SelectedItem as Prestamo, biblioteca);
                formGestionarPrestamo.Owner = this;
                formGestionarPrestamo.Show();
                this.Enabled = false;
                formGestionarPrestamo.FormClosed += FormAltaPrestamo_FormClosed;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un solo prestamo...");
            }
        }

        private void FormAltaPrestamo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.CargarArrays();
        }

        private void ExportFile(string tipoExport, List<Cliente> clientes, List<Libro> libros, List<Ejemplar> ejemplares, List<Prestamo> prestamos)
        {
            List<string> lista = new List<string>();

            if(tipoExport == "Clientes")
            {
                foreach(Cliente cliente in clientes)
                {
                    lista.Add(cliente.ToString());
                }
            }
            if (tipoExport == "Libros")
            {
                foreach (Libro libro in libros)
                {
                    lista.Add(libro.ToString());
                }
            }
            if (tipoExport == "Ejemplares")
            {
                foreach (Ejemplar ejemplar in ejemplares)
                {
                    lista.Add(ejemplar.ToString());
                }
            }
            if (tipoExport == "Prestamos")
            {
                foreach (Prestamo prestamo in prestamos)
                {
                    lista.Add(prestamo.ToString());
                }
            }
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, string.Format("Export{0}.csv", tipoExport))))
            {
                foreach (string line in lista)
                    outputFile.WriteLine(line);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            List<Cliente> clientes = checkedListBox1.Items.OfType<Cliente>().ToList();
            ExportFile("Clientes", clientes, new List<Libro>(), new List<Ejemplar>(), new List<Prestamo>());
            MessageBox.Show("Ya se descargó el reporte en \"C:\\MyDocuments\\ExportClientes\"");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            List<Libro> libros = checkedListBox2.Items.OfType<Libro>().ToList();
            ExportFile("Libros", new List<Cliente>(), libros, new List<Ejemplar>(), new List<Prestamo>());
            MessageBox.Show("Ya se descargó el reporte en \"C:\\MyDocuments\\ExportLibros\"");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            List<Ejemplar> ejemplares = checkedListBox3.Items.OfType<Ejemplar>().ToList();
            ExportFile("Ejemplares", new List<Cliente>(), new List<Libro>(), ejemplares, new List<Prestamo>());
            MessageBox.Show("Ya se descargó el reporte en \"C:\\MyDocuments\\ExportEjemplares\"");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            List<Prestamo> prestamos = checkedListBox4.Items.OfType<Prestamo>().ToList();
            ExportFile("Prestamos", new List<Cliente>(), new List<Libro>(), new List<Ejemplar>(), prestamos);
            MessageBox.Show("Ya se descargó el reporte en \"C:\\MyDocuments\\ExportPrestamos\"");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            FormAltaPrestamo altaPrestamo = new FormAltaPrestamo(Biblioteca);
            altaPrestamo.Owner = this;
            altaPrestamo.Show();
            this.Enabled = false;
            altaPrestamo.FormClosed += FormAltaEjemplar_FormClosed;
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox12.Text);
            Cliente cliente = comboBox3.SelectedValue as Cliente;
            Ejemplar ejemplar = comboBox2.SelectedValue as Ejemplar;
            foreach (Prestamo prestamo in biblioteca.Prestamos)
            {
                checkedListBox4.Items.Add(prestamo);
            }

            if (!textBox12.Equals(null))
            {
                checkedListBox4.Items.Cast<Prestamo>().Where(x => (x.Id == id));
            }
            if (!comboBox3.SelectedValue.Equals(null))
            {
                checkedListBox4.Items.Cast<Prestamo>().Where(x => (x.IdCliente == cliente.Id));
            }
            if (!comboBox2.SelectedItem.Equals(null))
            {
                checkedListBox4.Items.Cast<Prestamo>().Where(x =>(x.IdEjemplar == ejemplar.Id));
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            string nombre = textBox2.Text;
            string apellido = textBox3.Text;
            foreach (Cliente cliente in biblioteca.Clientes)
            {
                checkedListBox1.Items.Add(cliente);
            }

            if (!textBox1.Equals(null))
            {
                checkedListBox1.Items.Cast<Cliente>().Where(x => (x.Id == id));
            }
            if (!textBox2.Text.Equals(null))
            {
                checkedListBox1.Items.Cast<Cliente>().Where(x => (x.Nombre.ToLower() == nombre.ToLower()));
            }
            if (!textBox3.Text.Equals(null))
            {
                checkedListBox1.Items.Cast<Cliente>().Where(x => (x.Apellido.ToLower() == apellido.ToLower()));
            }
        }

        public BibliotecaNegocio Biblioteca
        {
            get
            {
                return biblioteca;
            }
            set
            {
                biblioteca = value;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox9.Text);
            Libro libro = comboBox1.SelectedValue as Libro;
            int precio = int.Parse(textBox9.Text);
            foreach (Ejemplar ejemplar in biblioteca.Ejemplares)
            {
                checkedListBox3.Items.Add(ejemplar);
            }

            if (!textBox9.Equals(null))
            {
                checkedListBox3.Items.Cast<Ejemplar>().Where(x => (x.Id == id));
            }
            if (!comboBox3.SelectedValue.Equals(null))
            {
                checkedListBox3.Items.Cast<Ejemplar>().Where(x => (x.IdLibro == libro.Id));
            }
            if (!comboBox2.SelectedItem.Equals(null))
            {
                checkedListBox3.Items.Cast<Ejemplar>().Where(x => (x.Precio == precio));
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox6.Text);
            string nombre = textBox5.Text;
            string autor = textBox4.Text;
            foreach (Libro libro in biblioteca.Libros)
            {
                checkedListBox2.Items.Add(libro);
            }

            if (!textBox6.Equals(null))
            {
                checkedListBox2.Items.Cast<Libro>().Where(x => (x.Id == id));
            }
            if (!textBox5.Text.Equals(null))
            {
                checkedListBox2.Items.Cast<Libro>().Where(x => (x.Titulo.ToLower() == nombre.ToLower()));
            }
            if (!textBox4.Text.Equals(null))
            {
                checkedListBox2.Items.Cast<Libro>().Where(x => (x.Autor.ToLower() == autor.ToLower()));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
