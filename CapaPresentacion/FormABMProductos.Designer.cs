namespace CapaPresentacion
{
    partial class FormABMProductos
    {

        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.BtnModificar = new FontAwesome.Sharp.IconButton();
            this.BtnEliminar = new FontAwesome.Sharp.IconButton();
            this.BtnGrabar = new FontAwesome.Sharp.IconButton();
            this.BtnNuevo = new FontAwesome.Sharp.IconButton();
            this.BtnCancelar = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.BtnPapelera = new FontAwesome.Sharp.IconButton();
            this.BtnImprimir = new FontAwesome.Sharp.IconButton();
            this.BtnSalir = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.TxtDetalle = new System.Windows.Forms.TextBox();
            this.TxtStock = new System.Windows.Forms.TextBox();
            this.TxtPrecioCompra = new System.Windows.Forms.TextBox();
            this.CboIdCat = new System.Windows.Forms.ComboBox();
            this.LblIdProducto = new System.Windows.Forms.Label();
            this.BtnCat = new FontAwesome.Sharp.IconButton();
            this.PanelDatos = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtPrecioVenta = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCol = new FontAwesome.Sharp.IconButton();
            this.CboIdMar = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnMar = new FontAwesome.Sharp.IconButton();
            this.CboIdCol = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.label7 = new System.Windows.Forms.Label();
            this.Imprimir = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.panel2.SuspendLayout();
            this.PanelDatos.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(17, 44);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "Buscar:";
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBuscar.Location = new System.Drawing.Point(99, 42);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(703, 26);
            this.TxtBuscar.TabIndex = 9;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // Grilla
            // 
            this.Grilla.AllowUserToAddRows = false;
            this.Grilla.AllowUserToDeleteRows = false;
            this.Grilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(216)))), ((int)(((byte)(228)))));
            this.Grilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grilla.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.Grilla.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(216)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grilla.ColumnHeadersHeight = 40;
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grilla.DefaultCellStyle = dataGridViewCellStyle2;
            this.Grilla.EnableHeadersVisualStyles = false;
            this.Grilla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(216)))), ((int)(((byte)(228)))));
            this.Grilla.Location = new System.Drawing.Point(240, 81);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grilla.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Grilla.RowHeadersVisible = false;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(871, 532);
            this.Grilla.TabIndex = 10;
            this.Grilla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grilla_CellClick);
            this.Grilla.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grilla_CellDoubleClick);
            this.Grilla.SelectionChanged += new System.EventHandler(this.Grilla_SelectionChanged);
            this.Grilla.SizeChanged += new System.EventHandler(this.Grilla_SizeChanged);
            this.Grilla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grilla_KeyDown);
            // 
            // BtnModificar
            // 
            this.BtnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.BtnModificar.Enabled = false;
            this.BtnModificar.FlatAppearance.BorderSize = 0;
            this.BtnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModificar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnModificar.IconChar = FontAwesome.Sharp.IconChar.Archive;
            this.BtnModificar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnModificar.Location = new System.Drawing.Point(-4, 140);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(157, 66);
            this.BtnModificar.TabIndex = 38;
            this.BtnModificar.Text = "&Modificar";
            this.BtnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnModificar.UseVisualStyleBackColor = false;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.BtnEliminar.FlatAppearance.BorderSize = 0;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashRestoreAlt;
            this.BtnEliminar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnEliminar.Location = new System.Drawing.Point(-1, 335);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(157, 66);
            this.BtnEliminar.TabIndex = 37;
            this.BtnEliminar.Text = "&Eliminar";
            this.BtnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.BtnGrabar.FlatAppearance.BorderSize = 0;
            this.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGrabar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGrabar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnGrabar.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            this.BtnGrabar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnGrabar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnGrabar.Location = new System.Drawing.Point(-1, 277);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(157, 66);
            this.BtnGrabar.TabIndex = 1;
            this.BtnGrabar.Text = "Grabar";
            this.BtnGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGrabar.UseVisualStyleBackColor = false;
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.BtnNuevo.FlatAppearance.BorderSize = 0;
            this.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNuevo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnNuevo.IconChar = FontAwesome.Sharp.IconChar.SquareCheck;
            this.BtnNuevo.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnNuevo.Location = new System.Drawing.Point(-4, 80);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(157, 66);
            this.BtnNuevo.TabIndex = 0;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnNuevo.UseVisualStyleBackColor = false;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.BtnCancelar.FlatAppearance.BorderSize = 0;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnCancelar.IconChar = FontAwesome.Sharp.IconChar.FileCircleXmark;
            this.BtnCancelar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnCancelar.Location = new System.Drawing.Point(1, 212);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(157, 66);
            this.BtnCancelar.TabIndex = 39;
            this.BtnCancelar.Text = "&Cancelar";
            this.BtnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.iconButton2);
            this.panel2.Controls.Add(this.BtnPapelera);
            this.panel2.Controls.Add(this.BtnCancelar);
            this.panel2.Controls.Add(this.BtnModificar);
            this.panel2.Controls.Add(this.BtnEliminar);
            this.panel2.Controls.Add(this.BtnGrabar);
            this.panel2.Controls.Add(this.BtnNuevo);
            this.panel2.Controls.Add(this.BtnImprimir);
            this.panel2.Controls.Add(this.BtnSalir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(1111, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(153, 613);
            this.panel2.TabIndex = 40;
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.TrashRestore;
            this.iconButton2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 42;
            this.iconButton2.Location = new System.Drawing.Point(-3, 398);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(159, 66);
            this.iconButton2.TabIndex = 47;
            this.iconButton2.Text = "Papelera";
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.BtnPapelera_Click);
            // 
            // BtnPapelera
            // 
            this.BtnPapelera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.BtnPapelera.FlatAppearance.BorderSize = 0;
            this.BtnPapelera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPapelera.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPapelera.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnPapelera.IconChar = FontAwesome.Sharp.IconChar.TrashRestore;
            this.BtnPapelera.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnPapelera.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnPapelera.IconSize = 42;
            this.BtnPapelera.Location = new System.Drawing.Point(-1, 407);
            this.BtnPapelera.Name = "BtnPapelera";
            this.BtnPapelera.Size = new System.Drawing.Size(159, 66);
            this.BtnPapelera.TabIndex = 47;
            this.BtnPapelera.Text = "Papelera";
            this.BtnPapelera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnPapelera.UseVisualStyleBackColor = false;
            this.BtnPapelera.Click += new System.EventHandler(this.BtnPapelera_Click);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnImprimir.FlatAppearance.BorderSize = 0;
            this.BtnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnImprimir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimir.ForeColor = System.Drawing.Color.White;
            this.BtnImprimir.IconChar = FontAwesome.Sharp.IconChar.Paperclip;
            this.BtnImprimir.IconColor = System.Drawing.Color.White;
            this.BtnImprimir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnImprimir.IconSize = 30;
            this.BtnImprimir.Location = new System.Drawing.Point(18, 543);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(115, 38);
            this.BtnImprimir.TabIndex = 47;
            this.BtnImprimir.Text = "&Imprimir";
            this.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnImprimir.UseVisualStyleBackColor = false;
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.IconChar = FontAwesome.Sharp.IconChar.X;
            this.BtnSalir.IconColor = System.Drawing.Color.White;
            this.BtnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnSalir.IconSize = 30;
            this.BtnSalir.Location = new System.Drawing.Point(109, 490);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(38, 33);
            this.BtnSalir.TabIndex = 49;
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(14, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripcion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(3, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Detalle:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(4, 427);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Precio Compra:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(1, 239);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Categoria:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 548);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Stock:";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDescripcion.Location = new System.Drawing.Point(3, 140);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(205, 26);
            this.TxtDescripcion.TabIndex = 0;
            this.TxtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDescripcion_KeyPress);
            // 
            // TxtDetalle
            // 
            this.TxtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDetalle.Location = new System.Drawing.Point(3, 201);
            this.TxtDetalle.Name = "TxtDetalle";
            this.TxtDetalle.Size = new System.Drawing.Size(205, 26);
            this.TxtDetalle.TabIndex = 1;
            this.TxtDetalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDetalle_KeyPress);
            // 
            // TxtStock
            // 
            this.TxtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtStock.Location = new System.Drawing.Point(5, 574);
            this.TxtStock.Name = "TxtStock";
            this.TxtStock.Size = new System.Drawing.Size(205, 26);
            this.TxtStock.TabIndex = 7;
            this.TxtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtStock_KeyPress);
            // 
            // TxtPrecioCompra
            // 
            this.TxtPrecioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPrecioCompra.Location = new System.Drawing.Point(5, 454);
            this.TxtPrecioCompra.Name = "TxtPrecioCompra";
            this.TxtPrecioCompra.Size = new System.Drawing.Size(205, 26);
            this.TxtPrecioCompra.TabIndex = 5;
            this.TxtPrecioCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecio_KeyPress);
            // 
            // CboIdCat
            // 
            this.CboIdCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboIdCat.FormattingEnabled = true;
            this.CboIdCat.Location = new System.Drawing.Point(3, 261);
            this.CboIdCat.Name = "CboIdCat";
            this.CboIdCat.Size = new System.Drawing.Size(169, 27);
            this.CboIdCat.TabIndex = 2;
            this.CboIdCat.SelectionChangeCommitted += new System.EventHandler(this.CboIdCat_SelectionChangeCommitted);
            this.CboIdCat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboIdCat_KeyPress);
            // 
            // LblIdProducto
            // 
            this.LblIdProducto.AutoSize = true;
            this.LblIdProducto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIdProducto.ForeColor = System.Drawing.Color.White;
            this.LblIdProducto.Location = new System.Drawing.Point(3, 8);
            this.LblIdProducto.Name = "LblIdProducto";
            this.LblIdProducto.Size = new System.Drawing.Size(18, 19);
            this.LblIdProducto.TabIndex = 13;
            this.LblIdProducto.Text = "0";
            // 
            // BtnCat
            // 
            this.BtnCat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnCat.FlatAppearance.BorderSize = 0;
            this.BtnCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCat.ForeColor = System.Drawing.Color.White;
            this.BtnCat.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassPlus;
            this.BtnCat.IconColor = System.Drawing.Color.White;
            this.BtnCat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnCat.IconSize = 20;
            this.BtnCat.Location = new System.Drawing.Point(180, 261);
            this.BtnCat.Name = "BtnCat";
            this.BtnCat.Size = new System.Drawing.Size(30, 27);
            this.BtnCat.TabIndex = 24;
            this.BtnCat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCat.UseVisualStyleBackColor = false;
            this.BtnCat.Click += new System.EventHandler(this.BtnCat_Click);
            // 
            // PanelDatos
            // 
            this.PanelDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.PanelDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelDatos.Controls.Add(this.label12);
            this.PanelDatos.Controls.Add(this.TxtPrecioVenta);
            this.PanelDatos.Controls.Add(this.label10);
            this.PanelDatos.Controls.Add(this.btnCol);
            this.PanelDatos.Controls.Add(this.CboIdMar);
            this.PanelDatos.Controls.Add(this.label11);
            this.PanelDatos.Controls.Add(this.BtnMar);
            this.PanelDatos.Controls.Add(this.CboIdCol);
            this.PanelDatos.Controls.Add(this.label9);
            this.PanelDatos.Controls.Add(this.BtnCat);
            this.PanelDatos.Controls.Add(this.LblIdProducto);
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
            this.PanelDatos.Controls.Add(this.label1);
            this.PanelDatos.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelDatos.Location = new System.Drawing.Point(0, 0);
            this.PanelDatos.Name = "PanelDatos";
            this.PanelDatos.Size = new System.Drawing.Size(219, 613);
            this.PanelDatos.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(2, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(161, 19);
            this.label12.TabIndex = 37;
            this.label12.Text = "Datos del producto:";
            // 
            // TxtPrecioVenta
            // 
            this.TxtPrecioVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPrecioVenta.Location = new System.Drawing.Point(6, 515);
            this.TxtPrecioVenta.Name = "TxtPrecioVenta";
            this.TxtPrecioVenta.Size = new System.Drawing.Size(205, 26);
            this.TxtPrecioVenta.TabIndex = 6;
            this.TxtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecioVenta_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(5, 488);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 19);
            this.label10.TabIndex = 34;
            this.label10.Text = "Precio Venta:";
            // 
            // btnCol
            // 
            this.btnCol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.btnCol.FlatAppearance.BorderSize = 0;
            this.btnCol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCol.ForeColor = System.Drawing.Color.White;
            this.btnCol.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassPlus;
            this.btnCol.IconColor = System.Drawing.Color.White;
            this.btnCol.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCol.IconSize = 20;
            this.btnCol.Location = new System.Drawing.Point(180, 388);
            this.btnCol.Name = "btnCol";
            this.btnCol.Size = new System.Drawing.Size(30, 27);
            this.btnCol.TabIndex = 33;
            this.btnCol.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCol.UseVisualStyleBackColor = false;
            this.btnCol.Click += new System.EventHandler(this.btnCol_Click);
            // 
            // CboIdMar
            // 
            this.CboIdMar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboIdMar.FormattingEnabled = true;
            this.CboIdMar.Location = new System.Drawing.Point(1, 328);
            this.CboIdMar.Name = "CboIdMar";
            this.CboIdMar.Size = new System.Drawing.Size(169, 27);
            this.CboIdMar.TabIndex = 3;
            this.CboIdMar.SelectionChangeCommitted += new System.EventHandler(this.CboIdMar_SelectionChangeCommitted);
            this.CboIdMar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboIdMar_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(3, 366);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 19);
            this.label11.TabIndex = 31;
            this.label11.Text = "Color:";
            // 
            // BtnMar
            // 
            this.BtnMar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnMar.FlatAppearance.BorderSize = 0;
            this.BtnMar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMar.ForeColor = System.Drawing.Color.White;
            this.BtnMar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassPlus;
            this.BtnMar.IconColor = System.Drawing.Color.White;
            this.BtnMar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnMar.IconSize = 20;
            this.BtnMar.Location = new System.Drawing.Point(180, 328);
            this.BtnMar.Name = "BtnMar";
            this.BtnMar.Size = new System.Drawing.Size(30, 27);
            this.BtnMar.TabIndex = 27;
            this.BtnMar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnMar.UseVisualStyleBackColor = false;
            this.BtnMar.Click += new System.EventHandler(this.BtnMar_Click);
            // 
            // CboIdCol
            // 
            this.CboIdCol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboIdCol.FormattingEnabled = true;
            this.CboIdCol.Location = new System.Drawing.Point(2, 388);
            this.CboIdCol.Name = "CboIdCol";
            this.CboIdCol.Size = new System.Drawing.Size(169, 27);
            this.CboIdCol.TabIndex = 4;
            this.CboIdCol.SelectionChangeCommitted += new System.EventHandler(this.CboIdCol_SelectionChangeCommitted);
            this.CboIdCol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboIdCol_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(-1, 306);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 19);
            this.label9.TabIndex = 25;
            this.label9.Text = "Marca:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.panel3.Controls.Add(this.iconButton1);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.TxtBuscar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(219, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(892, 81);
            this.panel3.TabIndex = 46;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(825, 40);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(29, 26);
            this.iconButton1.TabIndex = 50;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(17, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 19);
            this.label7.TabIndex = 37;
            this.label7.Text = "Buscar Producto:";
            // 
            // FormABMProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1264, 613);
            this.Controls.Add(this.Grilla);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PanelDatos);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormABMProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.Resize += new System.EventHandler(this.FormABMProductos_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.panel2.ResumeLayout(false);
            this.PanelDatos.ResumeLayout(false);
            this.PanelDatos.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.DataGridView Grilla;
        private FontAwesome.Sharp.IconButton BtnModificar;
        private FontAwesome.Sharp.IconButton BtnEliminar;
        private FontAwesome.Sharp.IconButton BtnGrabar;
        private FontAwesome.Sharp.IconButton BtnNuevo;
        private FontAwesome.Sharp.IconButton BtnCancelar;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton BtnPapelera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.TextBox TxtDetalle;
        private System.Windows.Forms.TextBox TxtStock;
        private System.Windows.Forms.TextBox TxtPrecioCompra;
        private System.Windows.Forms.ComboBox CboIdCat;
        private System.Windows.Forms.Label LblIdProducto;
        private FontAwesome.Sharp.IconButton BtnCat;
        private System.Windows.Forms.Panel PanelDatos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Drawing.Printing.PrintDocument Imprimir;
        private FontAwesome.Sharp.IconButton btnCol;
        private System.Windows.Forms.ComboBox CboIdMar;
        private System.Windows.Forms.Label label11;
        private FontAwesome.Sharp.IconButton BtnMar;
        private System.Windows.Forms.ComboBox CboIdCol;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconButton BtnImprimir;
        private FontAwesome.Sharp.IconButton BtnSalir;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.TextBox TxtPrecioVenta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
    }
}