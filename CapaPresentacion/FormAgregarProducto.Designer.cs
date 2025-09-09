namespace CapaPresentacion
{
    partial class FormAgregarProducto
    { /// <summary>
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
            this.TxtPrecioVenta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.CboIdCol = new System.Windows.Forms.ComboBox();
            this.CboIdMar = new System.Windows.Forms.ComboBox();
            this.BtnCat = new FontAwesome.Sharp.IconButton();
            this.CboIdCat = new System.Windows.Forms.ComboBox();
            this.TxtPrecioCompra = new System.Windows.Forms.TextBox();
            this.TxtStock = new System.Windows.Forms.TextBox();
            this.TxtDetalle = new System.Windows.Forms.TextBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblIdProducto = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.PanelDatos.Controls.Add(this.TxtPrecioVenta);
            this.PanelDatos.Controls.Add(this.label8);
            this.PanelDatos.Controls.Add(this.label7);
            this.PanelDatos.Controls.Add(this.label1);
            this.PanelDatos.Controls.Add(this.iconButton2);
            this.PanelDatos.Controls.Add(this.iconButton1);
            this.PanelDatos.Controls.Add(this.CboIdCol);
            this.PanelDatos.Controls.Add(this.CboIdMar);
            this.PanelDatos.Controls.Add(this.BtnCat);
            this.PanelDatos.Controls.Add(this.CboIdCat);
            this.PanelDatos.Controls.Add(this.TxtPrecioCompra);
            this.PanelDatos.Controls.Add(this.TxtStock);
            this.PanelDatos.Controls.Add(this.TxtDetalle);
            this.PanelDatos.Controls.Add(this.TxtDescripcion);
            this.PanelDatos.Controls.Add(this.label6);
            this.PanelDatos.Controls.Add(this.label5);
            this.PanelDatos.Controls.Add(this.label4);
            this.PanelDatos.Controls.Add(this.label3);
            this.PanelDatos.Controls.Add(this.label2);
            this.PanelDatos.Controls.Add(this.LblIdProducto);
            this.PanelDatos.Controls.Add(this.panel1);
            this.PanelDatos.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelDatos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelDatos.Location = new System.Drawing.Point(0, 0);
            this.PanelDatos.Name = "PanelDatos";
            this.PanelDatos.Size = new System.Drawing.Size(218, 470);
            this.PanelDatos.TabIndex = 40;
            // 
            // TxtPrecioVenta
            // 
            this.TxtPrecioVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPrecioVenta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrecioVenta.Location = new System.Drawing.Point(13, 372);
            this.TxtPrecioVenta.Name = "TxtPrecioVenta";
            this.TxtPrecioVenta.Size = new System.Drawing.Size(191, 26);
            this.TxtPrecioVenta.TabIndex = 66;
            this.TxtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecioVenta_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(9, 350);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 19);
            this.label8.TabIndex = 65;
            this.label8.Text = "Precio Venta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(8, 232);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 19);
            this.label7.TabIndex = 64;
            this.label7.Text = "Color:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 171);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 63;
            this.label1.Text = "Marca:";
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.Color.White;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassPlus;
            this.iconButton2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 20;
            this.iconButton2.Location = new System.Drawing.Point(170, 257);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(30, 27);
            this.iconButton2.TabIndex = 62;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassPlus;
            this.iconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 20;
            this.iconButton1.Location = new System.Drawing.Point(172, 198);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(30, 27);
            this.iconButton1.TabIndex = 61;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // CboIdCol
            // 
            this.CboIdCol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboIdCol.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboIdCol.FormattingEnabled = true;
            this.CboIdCol.Location = new System.Drawing.Point(9, 257);
            this.CboIdCol.Name = "CboIdCol";
            this.CboIdCol.Size = new System.Drawing.Size(155, 27);
            this.CboIdCol.TabIndex = 60;
            this.CboIdCol.SelectionChangeCommitted += new System.EventHandler(this.CboIdCol_SelectionChangeCommitted);
            this.CboIdCol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboIdCol_KeyPress);
            // 
            // CboIdMar
            // 
            this.CboIdMar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboIdMar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboIdMar.FormattingEnabled = true;
            this.CboIdMar.Location = new System.Drawing.Point(9, 197);
            this.CboIdMar.Name = "CboIdMar";
            this.CboIdMar.Size = new System.Drawing.Size(155, 27);
            this.CboIdMar.TabIndex = 59;
            this.CboIdMar.SelectionChangeCommitted += new System.EventHandler(this.CboIdMar_SelectionChangeCommitted);
            this.CboIdMar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboIdMar_KeyPress);
            // 
            // BtnCat
            // 
            this.BtnCat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.BtnCat.FlatAppearance.BorderSize = 0;
            this.BtnCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCat.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCat.ForeColor = System.Drawing.Color.White;
            this.BtnCat.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassPlus;
            this.BtnCat.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnCat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnCat.IconSize = 20;
            this.BtnCat.Location = new System.Drawing.Point(173, 138);
            this.BtnCat.Name = "BtnCat";
            this.BtnCat.Size = new System.Drawing.Size(30, 27);
            this.BtnCat.TabIndex = 58;
            this.BtnCat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCat.UseVisualStyleBackColor = false;
            this.BtnCat.Click += new System.EventHandler(this.BtnCat_Click);
            // 
            // CboIdCat
            // 
            this.CboIdCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboIdCat.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboIdCat.FormattingEnabled = true;
            this.CboIdCat.Location = new System.Drawing.Point(9, 136);
            this.CboIdCat.Name = "CboIdCat";
            this.CboIdCat.Size = new System.Drawing.Size(155, 27);
            this.CboIdCat.TabIndex = 57;
            this.CboIdCat.SelectionChangeCommitted += new System.EventHandler(this.CboIdCat_SelectionChangeCommitted);
            this.CboIdCat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboIdCat_KeyPress);
            // 
            // TxtPrecioCompra
            // 
            this.TxtPrecioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPrecioCompra.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrecioCompra.Location = new System.Drawing.Point(9, 319);
            this.TxtPrecioCompra.Name = "TxtPrecioCompra";
            this.TxtPrecioCompra.Size = new System.Drawing.Size(191, 26);
            this.TxtPrecioCompra.TabIndex = 56;
            this.TxtPrecioCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecioCompra_KeyPress);
            // 
            // TxtStock
            // 
            this.TxtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtStock.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtStock.Location = new System.Drawing.Point(12, 432);
            this.TxtStock.Name = "TxtStock";
            this.TxtStock.Size = new System.Drawing.Size(191, 26);
            this.TxtStock.TabIndex = 55;
            this.TxtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtStock_KeyPress);
            // 
            // TxtDetalle
            // 
            this.TxtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDetalle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDetalle.Location = new System.Drawing.Point(9, 85);
            this.TxtDetalle.Name = "TxtDetalle";
            this.TxtDetalle.Size = new System.Drawing.Size(191, 26);
            this.TxtDetalle.TabIndex = 54;
            this.TxtDetalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDetalle_KeyPress);
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDescripcion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescripcion.Location = new System.Drawing.Point(9, 34);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(191, 26);
            this.TxtDescripcion.TabIndex = 53;
            this.TxtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDescripcion_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(8, 410);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 19);
            this.label6.TabIndex = 52;
            this.label6.Text = "Stock:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 114);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 19);
            this.label5.TabIndex = 51;
            this.label5.Text = "Categoria:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 297);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 19);
            this.label4.TabIndex = 50;
            this.label4.Text = "Precio Compra:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 49;
            this.label3.Text = "Detalle:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 19);
            this.label2.TabIndex = 48;
            this.label2.Text = "Descripcion:";
            // 
            // LblIdProducto
            // 
            this.LblIdProducto.AutoSize = true;
            this.LblIdProducto.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIdProducto.ForeColor = System.Drawing.Color.White;
            this.LblIdProducto.Location = new System.Drawing.Point(215, 9);
            this.LblIdProducto.Name = "LblIdProducto";
            this.LblIdProducto.Size = new System.Drawing.Size(16, 18);
            this.LblIdProducto.TabIndex = 47;
            this.LblIdProducto.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(249, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 281);
            this.panel1.TabIndex = 14;
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
            this.PanelBotones.Size = new System.Drawing.Size(374, 470);
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
            this.BtnVolver.Location = new System.Drawing.Point(281, 228);
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
            this.BtnCancelar.Location = new System.Drawing.Point(232, 122);
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
            this.BtnGrabar.Location = new System.Drawing.Point(232, 70);
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
            this.BtnNuevo.Location = new System.Drawing.Point(232, 17);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(129, 41);
            this.BtnNuevo.TabIndex = 33;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnNuevo.UseVisualStyleBackColor = false;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // FormAgregarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(374, 470);
            this.Controls.Add(this.PanelDatos);
            this.Controls.Add(this.PanelBotones);
            this.Name = "FormAgregarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Producto";
            this.PanelDatos.ResumeLayout(false);
            this.PanelDatos.PerformLayout();
            this.PanelBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelDatos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelBotones;
        private FontAwesome.Sharp.IconButton BtnCancelar;
        private FontAwesome.Sharp.IconButton BtnGrabar;
        private FontAwesome.Sharp.IconButton BtnNuevo;
        private FontAwesome.Sharp.IconButton BtnVolver;
        private System.Windows.Forms.Label LblIdProducto;
        private FontAwesome.Sharp.IconButton BtnCat;
        private System.Windows.Forms.ComboBox CboIdCat;
        private System.Windows.Forms.TextBox TxtPrecioCompra;
        private System.Windows.Forms.TextBox TxtStock;
        private System.Windows.Forms.TextBox TxtDetalle;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.ComboBox CboIdCol;
        private System.Windows.Forms.ComboBox CboIdMar;
        private System.Windows.Forms.TextBox TxtPrecioVenta;
        private System.Windows.Forms.Label label8;
    }
}