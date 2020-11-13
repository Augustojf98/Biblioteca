using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.Negocio;

namespace Biblioteca.Forms
{
    public partial class FormInicio : Form
    {
        private BibliotecaNegocio biblioteca;

        public FormInicio()
        {
            InitializeComponent();
            biblioteca = new BibliotecaNegocio();
            this.comboBox1.DataSource = biblioteca.GetLibros();
        }
    }
}
