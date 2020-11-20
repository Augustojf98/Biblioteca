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
    public partial class FormGestionarPrestamo : Form
    {
        private BibliotecaNegocio biblioteca;
        private Prestamo prestamo;
        public FormGestionarPrestamo(Prestamo prestamoOrigen, BibliotecaNegocio bibliotecaNegocio)
        {
            InitializeComponent();

            biblioteca = bibliotecaNegocio;
            prestamo = prestamoOrigen;

            textBox1.Text = prestamo.Id.ToString();
            textBox4.Text = prestamo.IdCliente.ToString();
            textBox2.Text = prestamo.NombreEjemplar;
            textBox3.Text = prestamo.NombreCompletoCliente;
            textBox5.Text = prestamo.Plazo.ToString();
            textBox6.Text = prestamo.FechaAlta.ToShortDateString();
            textBox7.Text = prestamo.FechaBaja.ToShortDateString();
            textBox8.Text = prestamo.FechaBajaReal.ToShortDateString();


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Enabled = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker2.Text != "")
                {
                    MessageBox.Show("El ejemplar ya fue devuelto");
                }
                else if (DateTime.Now <= dateTimePicker2.Value)
                {
                    this.biblioteca.ActualizarPrestamo(prestamo);
                    MessageBox.Show("Prestamo modificado");
                    this.Owner.Enabled = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La fecha de devolucion debe ser mayor a la fecha actual");
                }
            }
            catch (Exception d)
            {
                FormException formException = new FormException("Error en las fechas ingresadas", d.Message);
                formException.Owner = this;
                formException.Show();
                this.Enabled = false;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.biblioteca.EliminarPrestamo(prestamo);
            MessageBox.Show("Prestamo eliminado");
            this.Owner.Enabled = true;
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
