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
        private BibliotecaNegocio biblioteca;

        public FormAltaPrestamo(BibliotecaNegocio bibliotecaNegocio)
        {
            InitializeComponent();
            this.biblioteca = bibliotecaNegocio;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Prestamo prestamo = new Prestamo(textBox1_TextChanged.selected(), );
                MessageBox.Show(string.Format("Se registró con éxito el préstamo."));
            }
            catch
            {

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
            Libro libro =  comboBox1.SelectedItem as Libro;
        }

        private void FormAltaPrestamo_Load(object sender, EventArgs e)
        {
            List<Libro> lst = biblioteca.GetLibros();
            foreach (Libro libro in lst)
            {
                comboBox1.Items.Add(libro);
            }
            
        }
    }
}
