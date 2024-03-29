﻿using System;
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
    public partial class FormAltaCliente : Form
    {
        private BibliotecaNegocio biblioteca;

        bool activo; 
        public FormAltaCliente(BibliotecaNegocio bibliotecaNegocio)
        {
            InitializeComponent();
            this.biblioteca = bibliotecaNegocio;
        }

        private void clickGuardar(object sender, EventArgs e)
        {
            try
            {
                activo = true;
                this.biblioteca.IngresarCliente(this.txtboxNombre.Text, this.txtboxApellido.Text, DateTime.Parse(this.dateTimePicker1.Text), this.txtboxDirec.Text, this.txtboxTel.Text,this.txtboxMail.Text,this.activo, int.Parse(this.textBox1.Text));
                MessageBox.Show(string.Format("Se registró con éxito el cliente \"{0} {1}\".", this.txtboxNombre.Text, this.txtboxApellido.Text));
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

        private void clickCancelarCliente(object sender, EventArgs e)
        {
            this.Owner.Enabled = true;
            this.Close(); 
        }

        private void txtboxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtboxTel_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
