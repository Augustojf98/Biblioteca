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
        private Cliente _cliente;
        private BibliotecaNegocio _biblioteca;

        public FormAltaPrestamo(BibliotecaNegocio biblioteca)
        {
            InitializeComponent();
            _biblioteca = biblioteca;
            try
            {
                foreach (Ejemplar ejemplar in _biblioteca.Ejemplares)
                {
                    if(ejemplar.Prestado == false && ejemplar.IdLibro != 0)
                    {
                        comboBox1.Items.Add(ejemplar);
                    }
                    
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
            try
            {
                if ((comboBox1.SelectedItem as Ejemplar) !=null && (comboBox2.SelectedItem as Cliente) != null && numericUpDown1.Value > 0 && dateTimePicker1.Value > DateTime.Now)
                {
                    _biblioteca.IngresarPrestamo(_cliente.Id, (comboBox1.SelectedItem as Ejemplar).Id, Decimal.ToInt32(numericUpDown1.Value), DateTime.Now, dateTimePicker1.Value);
                    MessageBox.Show("Prestamo creado");
                    this.Owner.Enabled = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe completar los campos antes de continuar");
                }
            }
            catch (Exception ex)
            {
                FormException formException = new FormException("Error", ex.Message);
                formException.Owner = this;
                formException.Show();
                this.Enabled = false;
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
            Ejemplar _ejemplar =  comboBox1.SelectedItem as Ejemplar;
            Libro _libro = _biblioteca.BuscarLibroById(_ejemplar.IdLibro);
            try
            {
                //List<Ejemplar> lst = _biblioteca.BuscarEjemplaresByIdLibro(_libro.Id);
                //foreach (Ejemplar ejemplar1 in lst)
                //{
                //    if (_biblioteca.Prestamos.Select(y => y.Id).ToList().Contains(ejemplar1.Id))
                //    {
                //        foreach (Prestamo prestamo1 in _biblioteca.Prestamos)
                //        {
                //            if (prestamo1.IdEjemplar == ejemplar1.Id && prestamo1.EstaAbierto)
                //            {
                //                copiasPrestadas += 1;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        _ejemplar = ejemplar1;
                //    }
                //    if (copiasPrestadas < (lst.IndexOf(ejemplar1) + 1))
                //    {
                //        MessageBox.Show(string.Format("Ejemplar disponible"));
                textBox4.Text = !string.IsNullOrEmpty(_libro.Autor) ? _libro.Autor:"";
                textBox5.Text = !string.IsNullOrEmpty(_libro.Edicion.ToString()) ? _libro.Edicion.ToString():"";
                textBox6.Text = !string.IsNullOrEmpty(_libro.Editorial) ? _libro.Editorial:"";
                textBox3.Text = !string.IsNullOrEmpty(_libro.Paginas.ToString()) ? _libro.Paginas.ToString():"";
                textBox2.Text = !string.IsNullOrEmpty(_libro.Tema) ? _libro.Tema:"";
                comboBox2.Enabled = true;
                //        _ejemplar = ejemplar1;
                //        break;
                //    }
                    
                //}
                //if (copiasPrestadas >= lst.Count)
                //{
                //    MessageBox.Show(string.Format("No hay ejemplares disponibles del libro seleccionado"));
                //    comboBox2.ResetText();
                //}
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.numericUpDown1.Value = (dateTimePicker1.Value - DateTime.Now).Days+1;
            }
            catch
            {
                MessageBox.Show("La fecha elegida es inválida");
            }
        }
    }
}
