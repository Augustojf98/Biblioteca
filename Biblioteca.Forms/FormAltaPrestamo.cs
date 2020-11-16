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
    }
}
