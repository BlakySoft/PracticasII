namespace CapaPresentacion
{
    partial class FormAgregarCliente
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
            this.PanelDatos = new System.Windows.Forms.Panel();
            this.TxtApellido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblIdCliente = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtDomicilio = new System.Windows.Forms.TextBox();
            this.LblDireccion = new System.Windows.Forms.Label();
            this.TxtTelefono = new System.Windows.Forms.TextBox();
            this.LblTelefono = new System.Windows.Forms.Label();
            this.TxtDocumento = new System.Windows.Forms.TextBox();
            this.LblApellido = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LblNombre = new System.Windows.Forms.Label();
            this.PanelBotones = new System.Windows.Forms.Panel();
            this.BtnVolver = new FontAwesome.Sharp.IconButton();
            this.BtnCancelar = new FontAwesome.Sharp.IconButton();
            this.BtnGrabar = new FontAwesome.Sharp.IconButton();
            this.BtnNuevo = new FontAwesome.Sharp.IconButton();
            this.PanelDatos.SuspendLayout();
            this.PanelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelDatos
            // 
            this.PanelDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.PanelDatos.Controls.Add(this.TxtApellido);
            this.PanelDatos.Controls.Add(this.label1);
            this.PanelDatos.Controls.Add(this.LblIdCliente);
            this.PanelDatos.Controls.Add(this.panel1);
            this.PanelDatos.Controls.Add(this.TxtDomicilio);
            this.PanelDatos.Controls.Add(this.LblDireccion);
            this.PanelDatos.Controls.Add(this.TxtTelefono);
            this.PanelDatos.Controls.Add(this.LblTelefono);
            this.PanelDatos.Controls.Add(this.TxtDocumento);
            this.PanelDatos.Controls.Add(this.LblApellido);
            this.PanelDatos.Controls.Add(this.TxtNombre);
            this.PanelDatos.Controls.Add(this.LblNombre);
            this.PanelDatos.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelDatos.Location = new System.Drawing.Point(0, 0);
            this.PanelDatos.Name = "PanelDatos";
            this.PanelDatos.Size = new System.Drawing.Size(243, 291);
            this.PanelDatos.TabIndex = 40;
            // 
            // TxtApellido
            // 
            this.TxtApellido.BackColor = System.Drawing.Color.White;
            this.TxtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtApellido.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtApellido.ForeColor = System.Drawing.Color.Black;
            this.TxtApellido.Location = new System.Drawing.Point(8, 34);
            this.TxtApellido.Name = "TxtApellido";
            this.TxtApellido.Size = new System.Drawing.Size(205, 25);
            this.TxtApellido.TabIndex = 4;
            this.TxtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtApellido_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 48;
            this.label1.Text = "Apellido:";
            // 
            // LblIdCliente
            // 
            this.LblIdCliente.AutoSize = true;
            this.LblIdCliente.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIdCliente.ForeColor = System.Drawing.Color.White;
            this.LblIdCliente.Location = new System.Drawing.Point(215, 9);
            this.LblIdCliente.Name = "LblIdCliente";
            this.LblIdCliente.Size = new System.Drawing.Size(16, 18);
            this.LblIdCliente.TabIndex = 47;
            this.LblIdCliente.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(249, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 281);
            this.panel1.TabIndex = 9;
            // 
            // TxtDomicilio
            // 
            this.TxtDomicilio.BackColor = System.Drawing.Color.White;
            this.TxtDomicilio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDomicilio.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDomicilio.ForeColor = System.Drawing.Color.Black;
            this.TxtDomicilio.Location = new System.Drawing.Point(7, 248);
            this.TxtDomicilio.Name = "TxtDomicilio";
            this.TxtDomicilio.Size = new System.Drawing.Size(205, 25);
            this.TxtDomicilio.TabIndex = 8;
            this.TxtDomicilio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDomicilio_KeyPress);
            // 
            // LblDireccion
            // 
            this.LblDireccion.AutoSize = true;
            this.LblDireccion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDireccion.ForeColor = System.Drawing.Color.White;
            this.LblDireccion.Location = new System.Drawing.Point(4, 226);
            this.LblDireccion.Name = "LblDireccion";
            this.LblDireccion.Size = new System.Drawing.Size(86, 19);
            this.LblDireccion.TabIndex = 12;
            this.LblDireccion.Text = "Domicilio:";
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.BackColor = System.Drawing.Color.White;
            this.TxtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTelefono.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTelefono.ForeColor = System.Drawing.Color.Black;
            this.TxtTelefono.Location = new System.Drawing.Point(8, 198);
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(205, 25);
            this.TxtTelefono.TabIndex = 7;
            this.TxtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTelefono_KeyPress);
            // 
            // LblTelefono
            // 
            this.LblTelefono.AutoSize = true;
            this.LblTelefono.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTelefono.ForeColor = System.Drawing.Color.White;
            this.LblTelefono.Location = new System.Drawing.Point(4, 172);
            this.LblTelefono.Name = "LblTelefono";
            this.LblTelefono.Size = new System.Drawing.Size(75, 19);
            this.LblTelefono.TabIndex = 6;
            this.LblTelefono.Text = "Teléfono";
            // 
            // TxtDocumento
            // 
            this.TxtDocumento.BackColor = System.Drawing.Color.White;
            this.TxtDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDocumento.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDocumento.ForeColor = System.Drawing.Color.Black;
            this.TxtDocumento.Location = new System.Drawing.Point(7, 140);
            this.TxtDocumento.Name = "TxtDocumento";
            this.TxtDocumento.Size = new System.Drawing.Size(205, 25);
            this.TxtDocumento.TabIndex = 6;
            this.TxtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDocumento_KeyPress);
            // 
            // LblApellido
            // 
            this.LblApellido.AutoSize = true;
            this.LblApellido.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblApellido.ForeColor = System.Drawing.Color.White;
            this.LblApellido.Location = new System.Drawing.Point(3, 115);
            this.LblApellido.Name = "LblApellido";
            this.LblApellido.Size = new System.Drawing.Size(98, 19);
            this.LblApellido.TabIndex = 4;
            this.LblApellido.Text = "Documento";
            // 
            // TxtNombre
            // 
            this.TxtNombre.BackColor = System.Drawing.Color.White;
            this.TxtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNombre.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.ForeColor = System.Drawing.Color.Black;
            this.TxtNombre.Location = new System.Drawing.Point(8, 87);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(205, 25);
            this.TxtNombre.TabIndex = 5;
            this.TxtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNombre_KeyPress);
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombre.ForeColor = System.Drawing.Color.White;
            this.LblNombre.Location = new System.Drawing.Point(4, 66);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(76, 19);
            this.LblNombre.TabIndex = 2;
            this.LblNombre.Text = "Nombre:";
            // 
            // PanelBotones
            // 
            this.PanelBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.PanelBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelBotones.Controls.Add(this.BtnVolver);
            this.PanelBotones.Controls.Add(this.BtnCancelar);
            this.PanelBotones.Controls.Add(this.BtnGrabar);
            this.PanelBotones.Controls.Add(this.BtnNuevo);
            this.PanelBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBotones.Location = new System.Drawing.Point(0, 0);
            this.PanelBotones.Name = "PanelBotones";
            this.PanelBotones.Size = new System.Drawing.Size(391, 291);
            this.PanelBotones.TabIndex = 41;
            // 
            // BtnVolver
            // 
            this.BtnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnVolver.FlatAppearance.BorderSize = 0;
            this.BtnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVolver.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVolver.ForeColor = System.Drawing.Color.White;
            this.BtnVolver.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.BtnVolver.IconColor = System.Drawing.Color.White;
            this.BtnVolver.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnVolver.IconSize = 30;
            this.BtnVolver.Location = new System.Drawing.Point(327, 237);
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.Size = new System.Drawing.Size(51, 41);
            this.BtnVolver.TabIndex = 46;
            this.BtnVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnVolver.UseVisualStyleBackColor = false;
            this.BtnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnCancelar.FlatAppearance.BorderSize = 0;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.IconChar = FontAwesome.Sharp.IconChar.FileCircleXmark;
            this.BtnCancelar.IconColor = System.Drawing.Color.White;
            this.BtnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnCancelar.IconSize = 30;
            this.BtnCancelar.Location = new System.Drawing.Point(249, 117);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(129, 41);
            this.BtnCancelar.TabIndex = 35;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnGrabar.FlatAppearance.BorderSize = 0;
            this.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGrabar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGrabar.ForeColor = System.Drawing.Color.White;
            this.BtnGrabar.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            this.BtnGrabar.IconColor = System.Drawing.Color.White;
            this.BtnGrabar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnGrabar.IconSize = 30;
            this.BtnGrabar.Location = new System.Drawing.Point(249, 65);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(129, 41);
            this.BtnGrabar.TabIndex = 34;
            this.BtnGrabar.Text = "Grabar";
            this.BtnGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGrabar.UseVisualStyleBackColor = false;
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnNuevo.FlatAppearance.BorderSize = 0;
            this.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNuevo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevo.ForeColor = System.Drawing.Color.White;
            this.BtnNuevo.IconChar = FontAwesome.Sharp.IconChar.SquareCheck;
            this.BtnNuevo.IconColor = System.Drawing.Color.White;
            this.BtnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnNuevo.IconSize = 30;
            this.BtnNuevo.Location = new System.Drawing.Point(249, 12);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(129, 41);
            this.BtnNuevo.TabIndex = 33;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnNuevo.UseVisualStyleBackColor = false;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // FormAgregarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(391, 291);
            this.Controls.Add(this.PanelDatos);
            this.Controls.Add(this.PanelBotones);
            this.Name = "FormAgregarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar clientes";
            this.PanelDatos.ResumeLayout(false);
            this.PanelDatos.PerformLayout();
            this.PanelBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelDatos;
        private System.Windows.Forms.TextBox TxtDomicilio;
        private System.Windows.Forms.Label LblDireccion;
        private System.Windows.Forms.TextBox TxtTelefono;
        private System.Windows.Forms.Label LblTelefono;
        private System.Windows.Forms.TextBox TxtDocumento;
        private System.Windows.Forms.Label LblApellido;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelBotones;
        private FontAwesome.Sharp.IconButton BtnCancelar;
        private FontAwesome.Sharp.IconButton BtnGrabar;
        private FontAwesome.Sharp.IconButton BtnNuevo;
        private FontAwesome.Sharp.IconButton BtnVolver;
        private System.Windows.Forms.Label LblIdCliente;
        private System.Windows.Forms.TextBox TxtApellido;
        private System.Windows.Forms.Label label1;
    }
}