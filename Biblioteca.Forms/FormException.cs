using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca.Forms
{
    public partial class FormException : Form
    {
        public FormException(string titulo, string descripcion)
        {
            InitializeComponent();
            this.textBox1.Text = titulo;
            this.textBox2.Text = descripcion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Enabled = true;
            this.Close();
        }
    }
}
