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
    public partial class FormAltaLibro : Form
    {
        private BibliotecaNegocio biblioteca;
        public FormAltaLibro(BibliotecaNegocio bibliotecaNegocio)
        {
            InitializeComponent();
            this.biblioteca = bibliotecaNegocio;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Owner.Enabled = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.biblioteca.IngresarLibro(this.textBox1.Text, this.textBox2.Text, int.Parse(this.textBox3.Text), this.textBox4.Text, int.Parse(this.textBox5.Text), this.textBox6.Text);
                MessageBox.Show(string.Format("Se registró con éxito el libro \"{0}\".", this.textBox1.Text));
                this.Owner.Enabled = true;
                this.Close();
            }
            catch(Exception ex)
            {
                FormException formException = new FormException("ERROR", ex.Message);
                formException.Owner = this;
                formException.Show();
                this.Enabled = false;
            }
        }
    }
}
