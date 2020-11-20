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
        private Cliente _cliente;
        private Ejemplar _ejemplar;
        private BibliotecaNegocio _biblioteca;

        public FormAltaPrestamo(BibliotecaNegocio biblioteca)
        {
            InitializeComponent();
            _biblioteca = biblioteca;
            try
            {
                foreach (Libro libro in _biblioteca.Libros)
                {
                    comboBox1.Items.Add(libro);
                }
                foreach (Cliente cliente in _biblioteca.Clientes)
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
            catch (SinClientesException ex)
            {
                FormException formException = new FormException("No hay clientes", ex.Message);
                formException.Owner = this;
                formException.Show();
                this.Enabled = false;
            }
            catch (SinLibrosException ex)
            {
                FormException formException = new FormException("No hay libros", ex.Message);
                formException.Owner = this;
                formException.Show();
                this.Enabled = false;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!comboBox1.Equals(null) & !comboBox2.Equals(null) & numericUpDown1.Value > 0 & dateTimePicker1.Value > DateTime.Now)
            {
                _biblioteca.IngresarPrestamo(_cliente.Id, _ejemplar.Id, Decimal.ToInt32(numericUpDown1.Value), DateTime.Now, dateTimePicker1.Value);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<bool> ejemplarDisponible = new List<bool>();
            _libro =  comboBox1.SelectedItem as Libro;
            int copiasPrestadas = 0;
            try
            {
                List<Ejemplar> lst = _biblioteca.BuscarEjemplaresByIdLibro(_libro.Id);
                foreach (Ejemplar ejemplar1 in lst)
                {
                    if (_biblioteca.Prestamos.Select(y => y.Id).ToList().Contains(ejemplar1.Id))
                    {
                        foreach (Prestamo prestamo1 in _biblioteca.Prestamos)
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
                        textBox4.Text = _libro.Autor;
                        textBox5.Text = _libro.Edicion.ToString();
                        textBox6.Text = _libro.Editorial;
                        textBox3.Text = _libro.Paginas.ToString();
                        textBox2.Text = _libro.Tema;
                        comboBox2.Enabled = true;
                        _ejemplar = ejemplar1;
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
            _cliente = comboBox2.SelectedItem as Cliente;
        }

        private void FormAltaPrestamo_Load(object sender, EventArgs e)
        {
            
            
        }
         
    }
}
