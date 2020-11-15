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

        public FormAltaEjemplar(BibliotecaNegocio bibliotecaNegocio)
        {
            InitializeComponent();
            this.biblioteca = bibliotecaNegocio;
        }
    }
}
