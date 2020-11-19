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
    public partial class FormAltaEjemplar : Form
    {
        private BibliotecaNegocio biblioteca;

        private int libroId;
        DateTime fechaAlta = DateTime.Now;


        public FormAltaEjemplar(BibliotecaNegocio bibliotecaNegocio)
        {
            InitializeComponent();
            this.biblioteca = bibliotecaNegocio;
            this.Refrescar();
            this.comboBox1.DataSource = biblioteca.GetLibros();
            
        }

        private void Refrescar()
        {
            this.CargarLibros(); 
        }

        private void CargarLibros()
        {
            List<Libro> lista = biblioteca.GetLibros();
           
        }

        private void clickGuardarEjemplar(object sender, EventArgs e)
        {
            try
            {
                Libro libroSeleccionado = (Libro)this.comboBox1.SelectedItem;

                libroId = libroSeleccionado.Id;
                fechaAlta.ToShortDateString();

                this.biblioteca.IngresarEjemplar(this.libroId, this.textBox5.Text, int.Parse(textBox6.Text),this.fechaAlta);
                MessageBox.Show(string.Format("Se registró con éxito el ejemplar del libro \"{0}\".", libroSeleccionado.Titulo));
                this.Owner.Enabled = true;
                this.Close(); 
            }
            catch (Exception ex)
            {
                FormException formException = new FormException("ERROR", ex.Message);
                formException.Owner = this;
                formException.Show();
                this.Enabled = false;
            }

        }

        private void clickCancelarEjemplar(object sender, EventArgs e)
        {
            this.Owner.Enabled = true;
            this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
