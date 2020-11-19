using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.Entidades;
using Biblioteca.Negocio;

namespace Biblioteca.Forms
{
    public partial class FormAltaPrestamo : Form
    {
        private Libro _libro;
        private Ejemplar _ejemplar;
        private Cliente _cliente;
        List<Prestamo> _listaPrestamos;
        private BibliotecaNegocio _biblioteca;

        public FormAltaPrestamo(BibliotecaNegocio biblioteca)
        {
            InitializeComponent();
            _biblioteca = biblioteca;
            this.ListaPrestamos = _biblioteca.GetPrestamos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!comboBox1.Equals(null) & !comboBox2.Equals(null) & numericUpDown1.Value > 0 & dateTimePicker1.Value > DateTime.Now)
            {
                _biblioteca.IngresarPrestamo(Cliente.Id, Ejemplar.Id, Decimal.ToInt32(numericUpDown1.Value), DateTime.Now, dateTimePicker1.Value);
                MessageBox.Show("Prestamo creado...");
                this.Owner.Enabled = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe completar los campos antes de continuar...");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Owner.Enabled = true;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<bool> ejemplarDisponible = new List<bool>();
            Libro =  comboBox1.SelectedItem as Libro;
            int copiasPrestadas = 0;
            try
            {
                List<Ejemplar> lst = _biblioteca.BuscarEjemplaresByIdLibro(Libro.Id);
                foreach (Ejemplar ejemplar1 in lst)
                {
                    if (this.ListaPrestamos.Select(y => y.Id).ToList().Contains(ejemplar1.Id))
                    {
                        foreach (Prestamo prestamo1 in ListaPrestamos)
                        {
                            if (prestamo1.IdEjemplar == ejemplar1.Id & prestamo1.FechaBajaReal.Equals(null))
                            {
                                copiasPrestadas += 1;
                            }
                        }
                    }
                    if (copiasPrestadas < (lst.IndexOf(ejemplar1) + 1))
                    {
                        MessageBox.Show(string.Format("Ejemplar disponible"));
                        textBox4.Text = Libro.Autor;
                        textBox5.Text = Libro.Edicion.ToString();
                        textBox6.Text = Libro.Editorial;
                        textBox3.Text = Libro.Paginas.ToString();
                        textBox2.Text = Libro.Tema;
                        comboBox2.Enabled = true;
                        Ejemplar = ejemplar1;
                        break;
                    }
                }
                if (copiasPrestadas == lst.Count)
                {
                    MessageBox.Show(string.Format("No hay ejemplares disponibles del libro seleccionado..."));
                    comboBox2.ResetText();
                }
            }
            catch (SinEjemplaresException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
            
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente = comboBox2.SelectedItem as Cliente;
        }

        private void FormAltaPrestamo_Load(object sender, EventArgs e)
        {
            List<Libro> lstLibros = _biblioteca.GetLibros();
            List<Cliente> lstCliente = _biblioteca.GetClientes();
            foreach (Libro libro in lstLibros)
            {
                comboBox1.Items.Add(libro);
            }
            foreach (Cliente cliente in lstCliente)
            {
                if (cliente.Activo)
                {
                    comboBox2.Items.Add(cliente);
                }
                
            }
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            //comboBox1.Enabled = false;
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public Ejemplar Ejemplar
        {
            get
            {
                return _ejemplar;
            }
            set
            {
                _ejemplar = value;
            }
        }
        public List<Prestamo> ListaPrestamos
        {
            get
            {
                return _listaPrestamos;
            }
            set
            {
                _listaPrestamos = value;
            }
        }

        public Libro Libro
        {
            get
            {
                return _libro;
            }
            set
            {
                _libro = value;
            }
        }

        public Cliente Cliente
        {
            get
            {
                return _cliente;
            }
            set
            {
                _cliente = value;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
