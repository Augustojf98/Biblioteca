namespace Biblioteca.Forms
{
    partial class FormAltaEjemplar
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
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelarCliente = new System.Windows.Forms.Button();
            this.btnGuardarEjemplar = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 69);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Precio";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(88, 69);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(209, 20);
            this.textBox6.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Observaciones";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Libro";
            // 
            // btnCancelarCliente
            // 
            this.btnCancelarCliente.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarCliente.Location = new System.Drawing.Point(8, 124);
            this.btnCancelarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelarCliente.Name = "btnCancelarCliente";
            this.btnCancelarCliente.Size = new System.Drawing.Size(137, 26);
            this.btnCancelarCliente.TabIndex = 20;
            this.btnCancelarCliente.Text = "Cancelar";
            this.btnCancelarCliente.UseVisualStyleBackColor = true;
            this.btnCancelarCliente.Click += new System.EventHandler(this.clickCancelarEjemplar);
            // 
            // btnGuardarEjemplar
            // 
            this.btnGuardarEjemplar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGuardarEjemplar.Location = new System.Drawing.Point(159, 124);
            this.btnGuardarEjemplar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarEjemplar.Name = "btnGuardarEjemplar";
            this.btnGuardarEjemplar.Size = new System.Drawing.Size(137, 26);
            this.btnGuardarEjemplar.TabIndex = 19;
            this.btnGuardarEjemplar.Text = "Guardar";
            this.btnGuardarEjemplar.UseVisualStyleBackColor = true;
            this.btnGuardarEjemplar.Click += new System.EventHandler(this.clickGuardarEjemplar);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(89, 40);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(208, 20);
            this.textBox5.TabIndex = 18;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(45, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(252, 21);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // FormAltaEjemplar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(306, 158);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelarCliente);
            this.Controls.Add(this.btnGuardarEjemplar);
            this.Controls.Add(this.textBox5);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormAltaEjemplar";
            this.Text = "Alta ejemplar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelarCliente;
        private System.Windows.Forms.Button btnGuardarEjemplar;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}