namespace Biblioteca.Forms
{
    partial class FormAltaCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.txtboxTel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnGuardarCliente = new System.Windows.Forms.Button();
            this.txtboxDirec = new System.Windows.Forms.TextBox();
            this.txtboxApellido = new System.Windows.Forms.TextBox();
            this.txtboxNombre = new System.Windows.Forms.TextBox();
            this.txtboxMail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Telefono";
            // 
            // txtboxTel
            // 
            this.txtboxTel.Location = new System.Drawing.Point(72, 78);
            this.txtboxTel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtboxTel.Name = "txtboxTel";
            this.txtboxTel.Size = new System.Drawing.Size(323, 22);
            this.txtboxTel.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Direccion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Apellido";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nombre";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(11, 153);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 32);
            this.button2.TabIndex = 20;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.clickCancelarCliente);
            // 
            // btnGuardarCliente
            // 
            this.btnGuardarCliente.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGuardarCliente.Location = new System.Drawing.Point(212, 153);
            this.btnGuardarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardarCliente.Name = "btnGuardarCliente";
            this.btnGuardarCliente.Size = new System.Drawing.Size(183, 32);
            this.btnGuardarCliente.TabIndex = 19;
            this.btnGuardarCliente.Text = "Guardar";
            this.btnGuardarCliente.UseVisualStyleBackColor = true;
            this.btnGuardarCliente.Click += new System.EventHandler(this.clickGuardar);
            // 
            // txtboxDirec
            // 
            this.txtboxDirec.Location = new System.Drawing.Point(72, 55);
            this.txtboxDirec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtboxDirec.Name = "txtboxDirec";
            this.txtboxDirec.Size = new System.Drawing.Size(323, 22);
            this.txtboxDirec.TabIndex = 18;
            // 
            // txtboxApellido
            // 
            this.txtboxApellido.Location = new System.Drawing.Point(72, 32);
            this.txtboxApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtboxApellido.Name = "txtboxApellido";
            this.txtboxApellido.Size = new System.Drawing.Size(323, 22);
            this.txtboxApellido.TabIndex = 17;
            // 
            // txtboxNombre
            // 
            this.txtboxNombre.Location = new System.Drawing.Point(72, 9);
            this.txtboxNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtboxNombre.Name = "txtboxNombre";
            this.txtboxNombre.Size = new System.Drawing.Size(323, 22);
            this.txtboxNombre.TabIndex = 16;
            // 
            // txtboxMail
            // 
            this.txtboxMail.Location = new System.Drawing.Point(72, 102);
            this.txtboxMail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtboxMail.Name = "txtboxMail";
            this.txtboxMail.Size = new System.Drawing.Size(323, 22);
            this.txtboxMail.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Mail";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 126);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 30;
            // 
            // FormAltaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(408, 194);
            this.ControlBox = false;
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtboxMail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtboxTel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnGuardarCliente);
            this.Controls.Add(this.txtboxDirec);
            this.Controls.Add(this.txtboxApellido);
            this.Controls.Add(this.txtboxNombre);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormAltaCliente";
            this.Text = "Nuevo cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtboxTel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnGuardarCliente;
        private System.Windows.Forms.TextBox txtboxDirec;
        private System.Windows.Forms.TextBox txtboxApellido;
        private System.Windows.Forms.TextBox txtboxNombre;
        private System.Windows.Forms.TextBox txtboxMail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}