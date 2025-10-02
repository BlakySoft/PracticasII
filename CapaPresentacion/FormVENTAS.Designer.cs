using System.Windows.Forms;

namespace CapaPresentacion
{
    partial class FormVENTAS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelBotones = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtTotal = new System.Windows.Forms.Label();
            this.TxtDetalle = new System.Windows.Forms.Label();
            this.lb = new System.Windows.Forms.Label();
            this.BtnMetodo = new FontAwesome.Sharp.IconButton();
            this.TxtSubTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbsub = new System.Windows.Forms.Label();
            this.CboIdMetodo = new System.Windows.Forms.ComboBox();
            this.LbCom = new System.Windows.Forms.Label();
            this.TxtPedido = new System.Windows.Forms.Label();
            this.LblIdProducto = new System.Windows.Forms.Label();
            this.TxtIdProducto = new System.Windows.Forms.TextBox();
            this.TxtDescripcion = new System.Windows.Forms.Label();
            this.TxtPrecio = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnBuscarProducto = new FontAwesome.Sharp.IconButton();
            this.BtnAgregarProducto = new FontAwesome.Sharp.IconButton();
            this.LblTitlePrecio = new System.Windows.Forms.Label();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.TxtStock = new System.Windows.Forms.Label();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.LblTitleStock = new System.Windows.Forms.Label();
            this.Fecha = new System.Windows.Forms.Label();
            this.LblFecha = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.BtnCancelar = new FontAwesome.Sharp.IconButton();
            this.BtnGrabar = new FontAwesome.Sharp.IconButton();
            this.BtnNuevo = new FontAwesome.Sharp.IconButton();
            this.LblTitleApellidoNombre = new System.Windows.Forms.Label();
            this.BtnAgregarCliente = new FontAwesome.Sharp.IconButton();
            this.BtnBuscarCliente = new FontAwesome.Sharp.IconButton();
            this.TxtCliente = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LblCliente = new System.Windows.Forms.Label();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelBotones.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelBotones
            // 
            this.PanelBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.PanelBotones.Controls.Add(this.label7);
            this.PanelBotones.Controls.Add(this.TxtTotal);
            this.PanelBotones.Controls.Add(this.TxtDetalle);
            this.PanelBotones.Controls.Add(this.lb);
            this.PanelBotones.Controls.Add(this.BtnMetodo);
            this.PanelBotones.Controls.Add(this.TxtSubTotal);
            this.PanelBotones.Controls.Add(this.label3);
            this.PanelBotones.Controls.Add(this.lbsub);
            this.PanelBotones.Controls.Add(this.CboIdMetodo);
            this.PanelBotones.Controls.Add(this.LbCom);
            this.PanelBotones.Controls.Add(this.TxtPedido);
            this.PanelBotones.Controls.Add(this.LblIdProducto);
            this.PanelBotones.Controls.Add(this.TxtIdProducto);
            this.PanelBotones.Controls.Add(this.TxtDescripcion);
            this.PanelBotones.Controls.Add(this.TxtPrecio);
            this.PanelBotones.Controls.Add(this.label2);
            this.PanelBotones.Controls.Add(this.BtnBuscarProducto);
            this.PanelBotones.Controls.Add(this.BtnAgregarProducto);
            this.PanelBotones.Controls.Add(this.LblTitlePrecio);
            this.PanelBotones.Controls.Add(this.LblCantidad);
            this.PanelBotones.Controls.Add(this.TxtStock);
            this.PanelBotones.Controls.Add(this.TxtCantidad);
            this.PanelBotones.Controls.Add(this.LblTitleStock);
            this.PanelBotones.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelBotones.ForeColor = System.Drawing.Color.Black;
            this.PanelBotones.Location = new System.Drawing.Point(0, 0);
            this.PanelBotones.Name = "PanelBotones";
            this.PanelBotones.Size = new System.Drawing.Size(260, 613);
            this.PanelBotones.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(14, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 19);
            this.label7.TabIndex = 48;
            this.label7.Text = "VENTAS:";
            // 
            // TxtTotal
            // 
            this.TxtTotal.BackColor = System.Drawing.Color.White;
            this.TxtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TxtTotal.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.ForeColor = System.Drawing.Color.Red;
            this.TxtTotal.Location = new System.Drawing.Point(88, 470);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(121, 25);
            this.TxtTotal.TabIndex = 39;
            // 
            // TxtDetalle
            // 
            this.TxtDetalle.BackColor = System.Drawing.Color.White;
            this.TxtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TxtDetalle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDetalle.ForeColor = System.Drawing.Color.Black;
            this.TxtDetalle.Location = new System.Drawing.Point(3, 124);
            this.TxtDetalle.Name = "TxtDetalle";
            this.TxtDetalle.Size = new System.Drawing.Size(229, 25);
            this.TxtDetalle.TabIndex = 47;
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb.ForeColor = System.Drawing.Color.Black;
            this.lb.Location = new System.Drawing.Point(3, 470);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(52, 19);
            this.lb.TabIndex = 38;
            this.lb.Text = "Total:";
            // 
            // BtnMetodo
            // 
            this.BtnMetodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnMetodo.FlatAppearance.BorderSize = 0;
            this.BtnMetodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMetodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMetodo.ForeColor = System.Drawing.Color.White;
            this.BtnMetodo.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassPlus;
            this.BtnMetodo.IconColor = System.Drawing.Color.White;
            this.BtnMetodo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnMetodo.IconSize = 20;
            this.BtnMetodo.Location = new System.Drawing.Point(208, 302);
            this.BtnMetodo.Name = "BtnMetodo";
            this.BtnMetodo.Size = new System.Drawing.Size(25, 25);
            this.BtnMetodo.TabIndex = 44;
            this.BtnMetodo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnMetodo.UseVisualStyleBackColor = false;
            // 
            // TxtSubTotal
            // 
            this.TxtSubTotal.BackColor = System.Drawing.Color.White;
            this.TxtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSubTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TxtSubTotal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSubTotal.ForeColor = System.Drawing.Color.Black;
            this.TxtSubTotal.Location = new System.Drawing.Point(88, 436);
            this.TxtSubTotal.Name = "TxtSubTotal";
            this.TxtSubTotal.Size = new System.Drawing.Size(135, 24);
            this.TxtSubTotal.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 46;
            this.label3.Text = "Detalle:";
            // 
            // lbsub
            // 
            this.lbsub.AutoSize = true;
            this.lbsub.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsub.ForeColor = System.Drawing.Color.Black;
            this.lbsub.Location = new System.Drawing.Point(3, 441);
            this.lbsub.Name = "lbsub";
            this.lbsub.Size = new System.Drawing.Size(79, 19);
            this.lbsub.TabIndex = 31;
            this.lbsub.Text = "Subtotal:";
            // 
            // CboIdMetodo
            // 
            this.CboIdMetodo.BackColor = System.Drawing.Color.White;
            this.CboIdMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboIdMetodo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboIdMetodo.FormattingEnabled = true;
            this.CboIdMetodo.Location = new System.Drawing.Point(3, 303);
            this.CboIdMetodo.Name = "CboIdMetodo";
            this.CboIdMetodo.Size = new System.Drawing.Size(194, 27);
            this.CboIdMetodo.TabIndex = 43;
            this.CboIdMetodo.SelectionChangeCommitted += new System.EventHandler(this.CboIdMetodo_SelectionChangeCommitted);
            // 
            // LbCom
            // 
            this.LbCom.AutoSize = true;
            this.LbCom.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbCom.ForeColor = System.Drawing.Color.Black;
            this.LbCom.Location = new System.Drawing.Point(3, 408);
            this.LbCom.Name = "LbCom";
            this.LbCom.Size = new System.Drawing.Size(58, 19);
            this.LbCom.TabIndex = 40;
            this.LbCom.Text = "Venta:";
            // 
            // TxtPedido
            // 
            this.TxtPedido.BackColor = System.Drawing.Color.White;
            this.TxtPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TxtPedido.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPedido.ForeColor = System.Drawing.Color.Black;
            this.TxtPedido.Location = new System.Drawing.Point(88, 403);
            this.TxtPedido.Name = "TxtPedido";
            this.TxtPedido.Size = new System.Drawing.Size(38, 24);
            this.TxtPedido.TabIndex = 41;
            // 
            // LblIdProducto
            // 
            this.LblIdProducto.AutoSize = true;
            this.LblIdProducto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIdProducto.ForeColor = System.Drawing.Color.Black;
            this.LblIdProducto.Location = new System.Drawing.Point(3, 44);
            this.LblIdProducto.Name = "LblIdProducto";
            this.LblIdProducto.Size = new System.Drawing.Size(86, 19);
            this.LblIdProducto.TabIndex = 4;
            this.LblIdProducto.Text = "Producto:";
            // 
            // TxtIdProducto
            // 
            this.TxtIdProducto.BackColor = System.Drawing.Color.White;
            this.TxtIdProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtIdProducto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIdProducto.ForeColor = System.Drawing.Color.Black;
            this.TxtIdProducto.Location = new System.Drawing.Point(88, 39);
            this.TxtIdProducto.Name = "TxtIdProducto";
            this.TxtIdProducto.Size = new System.Drawing.Size(102, 22);
            this.TxtIdProducto.TabIndex = 45;
            this.TxtIdProducto.TextChanged += new System.EventHandler(this.TxtIdProducto_TextChanged);
            this.TxtIdProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtIdProducto_KeyPress);
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.BackColor = System.Drawing.Color.White;
            this.TxtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDescripcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TxtDescripcion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.TxtDescripcion.Location = new System.Drawing.Point(3, 72);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(189, 25);
            this.TxtDescripcion.TabIndex = 35;
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.BackColor = System.Drawing.Color.White;
            this.TxtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TxtPrecio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrecio.ForeColor = System.Drawing.Color.Black;
            this.TxtPrecio.Location = new System.Drawing.Point(3, 363);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(227, 25);
            this.TxtPrecio.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 19);
            this.label2.TabIndex = 42;
            this.label2.Text = "Metodo de pago:";
            // 
            // BtnBuscarProducto
            // 
            this.BtnBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnBuscarProducto.FlatAppearance.BorderSize = 0;
            this.BtnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarProducto.ForeColor = System.Drawing.Color.White;
            this.BtnBuscarProducto.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassArrowRight;
            this.BtnBuscarProducto.IconColor = System.Drawing.Color.White;
            this.BtnBuscarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnBuscarProducto.IconSize = 20;
            this.BtnBuscarProducto.Location = new System.Drawing.Point(198, 71);
            this.BtnBuscarProducto.Name = "BtnBuscarProducto";
            this.BtnBuscarProducto.Size = new System.Drawing.Size(25, 25);
            this.BtnBuscarProducto.TabIndex = 40;
            this.BtnBuscarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnBuscarProducto.UseVisualStyleBackColor = false;
            this.BtnBuscarProducto.Click += new System.EventHandler(this.BtnBuscarProducto_Click);
            // 
            // BtnAgregarProducto
            // 
            this.BtnAgregarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnAgregarProducto.FlatAppearance.BorderSize = 0;
            this.BtnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarProducto.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarProducto.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            this.BtnAgregarProducto.IconColor = System.Drawing.Color.White;
            this.BtnAgregarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnAgregarProducto.IconSize = 20;
            this.BtnAgregarProducto.Location = new System.Drawing.Point(229, 71);
            this.BtnAgregarProducto.Name = "BtnAgregarProducto";
            this.BtnAgregarProducto.Size = new System.Drawing.Size(25, 25);
            this.BtnAgregarProducto.TabIndex = 41;
            this.BtnAgregarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAgregarProducto.UseVisualStyleBackColor = false;
            this.BtnAgregarProducto.Click += new System.EventHandler(this.BtnAgregarProducto_Click);
            // 
            // LblTitlePrecio
            // 
            this.LblTitlePrecio.AutoSize = true;
            this.LblTitlePrecio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitlePrecio.ForeColor = System.Drawing.Color.Black;
            this.LblTitlePrecio.Location = new System.Drawing.Point(3, 334);
            this.LblTitlePrecio.Name = "LblTitlePrecio";
            this.LblTitlePrecio.Size = new System.Drawing.Size(64, 19);
            this.LblTitlePrecio.TabIndex = 29;
            this.LblTitlePrecio.Text = "Precio:";
            // 
            // LblCantidad
            // 
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCantidad.ForeColor = System.Drawing.Color.Black;
            this.LblCantidad.Location = new System.Drawing.Point(3, 155);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(84, 19);
            this.LblCantidad.TabIndex = 27;
            this.LblCantidad.Text = "Cantidad:";
            // 
            // TxtStock
            // 
            this.TxtStock.BackColor = System.Drawing.Color.White;
            this.TxtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TxtStock.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtStock.ForeColor = System.Drawing.Color.Black;
            this.TxtStock.Location = new System.Drawing.Point(3, 240);
            this.TxtStock.Name = "TxtStock";
            this.TxtStock.Size = new System.Drawing.Size(230, 25);
            this.TxtStock.TabIndex = 36;
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.BackColor = System.Drawing.Color.White;
            this.TxtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCantidad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCantidad.ForeColor = System.Drawing.Color.Black;
            this.TxtCantidad.Location = new System.Drawing.Point(3, 179);
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(230, 26);
            this.TxtCantidad.TabIndex = 28;
            this.TxtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCantidad_KeyPress);
            // 
            // LblTitleStock
            // 
            this.LblTitleStock.AutoSize = true;
            this.LblTitleStock.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitleStock.ForeColor = System.Drawing.Color.Black;
            this.LblTitleStock.Location = new System.Drawing.Point(3, 210);
            this.LblTitleStock.Name = "LblTitleStock";
            this.LblTitleStock.Size = new System.Drawing.Size(59, 19);
            this.LblTitleStock.TabIndex = 6;
            this.LblTitleStock.Text = "Stock:";
            // 
            // Fecha
            // 
            this.Fecha.AutoSize = true;
            this.Fecha.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha.ForeColor = System.Drawing.Color.Black;
            this.Fecha.Location = new System.Drawing.Point(50, 24);
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(86, 19);
            this.Fecha.TabIndex = 48;
            this.Fecha.Text = "Producto:";
            // 
            // LblFecha
            // 
            this.LblFecha.AutoSize = true;
            this.LblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFecha.ForeColor = System.Drawing.Color.Tan;
            this.LblFecha.Location = new System.Drawing.Point(70, 25);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Size = new System.Drawing.Size(54, 18);
            this.LblFecha.TabIndex = 0;
            this.LblFecha.Text = "Fecha";
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButton1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.X;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 40;
            this.iconButton1.Location = new System.Drawing.Point(69, 546);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(56, 44);
            this.iconButton1.TabIndex = 18;
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.BtnCancelar.FlatAppearance.BorderSize = 0;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.Black;
            this.BtnCancelar.IconChar = FontAwesome.Sharp.IconChar.X;
            this.BtnCancelar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnCancelar.IconSize = 60;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnCancelar.Location = new System.Drawing.Point(21, 414);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(155, 99);
            this.BtnCancelar.TabIndex = 17;
            this.BtnCancelar.Text = " Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnGrabar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.BtnGrabar.FlatAppearance.BorderSize = 0;
            this.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGrabar.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGrabar.ForeColor = System.Drawing.Color.Black;
            this.BtnGrabar.IconChar = FontAwesome.Sharp.IconChar.FileCircleCheck;
            this.BtnGrabar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnGrabar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnGrabar.IconSize = 60;
            this.BtnGrabar.Location = new System.Drawing.Point(17, 291);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(155, 99);
            this.BtnGrabar.TabIndex = 16;
            this.BtnGrabar.Text = "Grabar";
            this.BtnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnGrabar.UseVisualStyleBackColor = false;
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.BtnNuevo.FlatAppearance.BorderSize = 0;
            this.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNuevo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevo.ForeColor = System.Drawing.Color.Black;
            this.BtnNuevo.IconChar = FontAwesome.Sharp.IconChar.SquareCheck;
            this.BtnNuevo.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnNuevo.IconSize = 60;
            this.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnNuevo.Location = new System.Drawing.Point(17, 182);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(155, 99);
            this.BtnNuevo.TabIndex = 15;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnNuevo.UseVisualStyleBackColor = false;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // LblTitleApellidoNombre
            // 
            this.LblTitleApellidoNombre.AutoSize = true;
            this.LblTitleApellidoNombre.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitleApellidoNombre.ForeColor = System.Drawing.Color.Black;
            this.LblTitleApellidoNombre.Location = new System.Drawing.Point(18, 45);
            this.LblTitleApellidoNombre.Name = "LblTitleApellidoNombre";
            this.LblTitleApellidoNombre.Size = new System.Drawing.Size(68, 19);
            this.LblTitleApellidoNombre.TabIndex = 2;
            this.LblTitleApellidoNombre.Text = "Cliente:";
            // 
            // BtnAgregarCliente
            // 
            this.BtnAgregarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAgregarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnAgregarCliente.FlatAppearance.BorderSize = 0;
            this.BtnAgregarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarCliente.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarCliente.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            this.BtnAgregarCliente.IconColor = System.Drawing.Color.White;
            this.BtnAgregarCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnAgregarCliente.IconSize = 26;
            this.BtnAgregarCliente.Location = new System.Drawing.Point(723, 41);
            this.BtnAgregarCliente.Name = "BtnAgregarCliente";
            this.BtnAgregarCliente.Size = new System.Drawing.Size(30, 27);
            this.BtnAgregarCliente.TabIndex = 24;
            this.BtnAgregarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAgregarCliente.UseVisualStyleBackColor = false;
            this.BtnAgregarCliente.Click += new System.EventHandler(this.BtnAgregarProveedor_Click);
            // 
            // BtnBuscarCliente
            // 
            this.BtnBuscarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnBuscarCliente.FlatAppearance.BorderSize = 0;
            this.BtnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarCliente.ForeColor = System.Drawing.Color.White;
            this.BtnBuscarCliente.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassArrowRight;
            this.BtnBuscarCliente.IconColor = System.Drawing.Color.White;
            this.BtnBuscarCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnBuscarCliente.IconSize = 20;
            this.BtnBuscarCliente.Location = new System.Drawing.Point(687, 41);
            this.BtnBuscarCliente.Name = "BtnBuscarCliente";
            this.BtnBuscarCliente.Size = new System.Drawing.Size(30, 27);
            this.BtnBuscarCliente.TabIndex = 23;
            this.BtnBuscarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnBuscarCliente.UseVisualStyleBackColor = false;
            this.BtnBuscarCliente.Click += new System.EventHandler(this.BtnBuscarProveedor_Click);
            // 
            // TxtCliente
            // 
            this.TxtCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtCliente.BackColor = System.Drawing.Color.White;
            this.TxtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TxtCliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCliente.ForeColor = System.Drawing.Color.Black;
            this.TxtCliente.Location = new System.Drawing.Point(100, 39);
            this.TxtCliente.Name = "TxtCliente";
            this.TxtCliente.Size = new System.Drawing.Size(569, 25);
            this.TxtCliente.TabIndex = 34;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.panel1.Controls.Add(this.Fecha);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.BtnNuevo);
            this.panel1.Controls.Add(this.BtnGrabar);
            this.panel1.Controls.Add(this.LblFecha);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1071, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 613);
            this.panel1.TabIndex = 42;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.BtnAgregarCliente);
            this.panel3.Controls.Add(this.TxtCliente);
            this.panel3.Controls.Add(this.BtnBuscarCliente);
            this.panel3.Controls.Add(this.LblTitleApellidoNombre);
            this.panel3.Controls.Add(this.LblCliente);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(260, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(811, 81);
            this.panel3.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 19);
            this.label1.TabIndex = 36;
            this.label1.Text = "Datos del Cliente:";
            // 
            // LblCliente
            // 
            this.LblCliente.AutoSize = true;
            this.LblCliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCliente.ForeColor = System.Drawing.Color.Black;
            this.LblCliente.Location = new System.Drawing.Point(178, 8);
            this.LblCliente.Name = "LblCliente";
            this.LblCliente.Size = new System.Drawing.Size(18, 19);
            this.LblCliente.TabIndex = 35;
            this.LblCliente.Text = "0";
            // 
            // Grilla
            // 
            this.Grilla.AllowUserToAddRows = false;
            this.Grilla.AllowUserToResizeColumns = false;
            this.Grilla.AllowUserToResizeRows = false;
            this.Grilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(216)))), ((int)(((byte)(228)))));
            this.Grilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grilla.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.Grilla.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(216)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grilla.ColumnHeadersHeight = 50;
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Grilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grilla.DefaultCellStyle = dataGridViewCellStyle4;
            this.Grilla.EnableHeadersVisualStyles = false;
            this.Grilla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(216)))), ((int)(((byte)(228)))));
            this.Grilla.Location = new System.Drawing.Point(260, 81);
            this.Grilla.MultiSelect = false;
            this.Grilla.Name = "Grilla";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grilla.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Grilla.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.Grilla.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(811, 532);
            this.Grilla.TabIndex = 44;
            this.Grilla.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grilla_CellEndEdit);
            this.Grilla.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.Grilla_RowsRemoved);
            // 
            // Column1
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(216)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Código";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(216)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "Descripción";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Precio";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Cantidad";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Subtotal";
            this.Column5.Name = "Column5";
            // 
            // FormVENTAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1264, 613);
            this.Controls.Add(this.Grilla);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PanelBotones);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVENTAS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.FormVENTAS_Load);
            this.PanelBotones.ResumeLayout(false);
            this.PanelBotones.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelBotones;
        private System.Windows.Forms.Label LblFecha;
        private FontAwesome.Sharp.IconButton BtnNuevo;
        private FontAwesome.Sharp.IconButton BtnCancelar;
        private FontAwesome.Sharp.IconButton BtnGrabar;
        private System.Windows.Forms.Label LblIdProducto;
        private System.Windows.Forms.Label LblTitleStock;
        private System.Windows.Forms.Label LblTitleApellidoNombre;
        private FontAwesome.Sharp.IconButton BtnAgregarCliente;
        private FontAwesome.Sharp.IconButton BtnBuscarCliente;
        private System.Windows.Forms.Label LblCantidad;
        private System.Windows.Forms.TextBox TxtCantidad;
        private System.Windows.Forms.Label LblTitlePrecio;
        private System.Windows.Forms.Label lbsub;
        public System.Windows.Forms.Label TxtCliente;
        public System.Windows.Forms.Label TxtPrecio;
        public System.Windows.Forms.Label TxtStock;
        public System.Windows.Forms.Label TxtDescripcion;
        public System.Windows.Forms.Label TxtSubTotal;
        public System.Windows.Forms.Label TxtTotal;
        private System.Windows.Forms.Label lb;
        public System.Windows.Forms.Label TxtPedido;
        private System.Windows.Forms.Label LbCom;
        private FontAwesome.Sharp.IconButton BtnBuscarProducto;
        private FontAwesome.Sharp.IconButton BtnAgregarProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CboIdMetodo;
        private FontAwesome.Sharp.IconButton BtnMetodo;
        private FontAwesome.Sharp.IconButton iconButton1;
        public System.Windows.Forms.Label TxtDetalle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblCliente;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TxtIdProducto;
        private System.Windows.Forms.Label Fecha;
        private System.Windows.Forms.DataGridView Grilla;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Label label7;
    }
}