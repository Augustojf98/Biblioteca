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
            textBox3.Text = prestamo.NombreEjemplar;
            textBox2.Text = prestamo.NombreCompletoCliente;
            textBox5.Text = prestamo.Plazo.ToString();
            dateTimePicker1.Value = prestamo.FechaAlta;
            dateTimePicker3.Value = prestamo.FechaBaja;


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Enabled = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dateTimePicker2.Text != "")
            {
                MessageBox.Show("El ejemplar ya fue devuelto");
            }
            else if (dateTimePicker2.Value > DateTime.Now)
            {
                this.biblioteca.ActualizarPrestamo(prestamo);
                MessageBox.Show("Prestamo modificado...");
                this.Owner.Enabled = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("La fecha de devolucion debe ser mayor a la fecha actual");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.biblioteca.EliminarPrestamo(prestamo);
            MessageBox.Show("Prestamo eliminado...");
            this.Owner.Enabled = true;
            this.Close();
        }
    }
}
