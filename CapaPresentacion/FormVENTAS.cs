using CapaDatos;
using CapaNegocio;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace CapaPresentacion
{
    public partial class FormVENTAS: Form
    {
        #region Declaraciones y conexion
        public decimal Stock, Cantidad, Precio, Subtotal, Total, Resultado;
        public int IdCliente, VarMetodo;
        bool exist;
        private bool mostrandoMensaje = false;
        private string nombreCajeroActual;
        private int  usuarioActual;

        Conexion cn = new Conexion();
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
        #endregion 

        #region Metodo
        public FormVENTAS(string cajero, Usuario Tipo)
        {
            InitializeComponent();
            Grilla.CellEndEdit += Grilla_CellEndEdit;
            this.nombreCajeroActual = cajero;
            this.usuarioActual = Tipo.TipoUsuario;
            CargarCbo();
            Fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            #region Enabled no
            //false
            CboIdMetodo.Enabled = false;
            BtnMetodo.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnAgregarCliente.Enabled = false;
            BtnBuscarCliente.Enabled = false;
            BtnAgregarProducto.Enabled = false;
            BtnBuscarProducto.Enabled = false;
            TxtCantidad.Enabled = false;
            TxtIdProducto.Enabled = false;

            if (usuarioActual == 2)
            {
                BtnMetodo.Visible = false;
                BtnAgregarProducto.Visible = false;
            }

            //true
            BtnNuevo.Enabled = true;
            Grilla.Visible = true;
            #endregion

            #region Limpiar
            TxtCliente.Text = "";
            TxtDescripcion.Text = "";
            TxtDetalle.Text = "";
            TxtPrecio.Text = "";
            TxtStock.Text = "";
            TxtSubTotal.Text = "";
            TxtTotal.Text = "";
            TxtCantidad.Text = "1";
            TxtIdProducto.Text = "";
            #endregion

            Grilla.Rows.Clear();
            Total = 0;
            BtnNuevo.Focus();
           
        }
        private void CargarCbo()
        {
            ConeMetododepago cone = new ConeMetododepago();

            CboIdMetodo.ValueMember = "IdMetodo";
            CboIdMetodo.DisplayMember = "Descripcion";
            CboIdMetodo.DataSource = cone.Listar();
            CboIdMetodo.SelectedIndex = 0;
            VarMetodo = int.Parse(CboIdMetodo.SelectedValue.ToString());
          
        }
        private void LimpiarTextos()
        {
            TxtDetalle.Text = "";
            TxtBarCode.Text = "";
            TxtIdProducto.Text = "";
            TxtCantidad.Text = "1";
            TxtDescripcion.Text = "";
            TxtStock.Text = "";
            TxtPrecio.Text = "";
        }
        #endregion

        #region Botones
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Grilla.Rows.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos un producto para realizar la venta.", "Liz Showroom", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BtnGrabar.Enabled = false;
                    return;
                }
                else
                {
                    BtnGrabar.Enabled = true;
                }

                if (string.IsNullOrEmpty(TxtCliente.Text))
                {
                    TxtCliente.Text = "Cliente Final";
                    LblCliente.Text = "23";
                    IdCliente = 23;
                }

                decimal totalVenta = 0;
                foreach (DataGridViewRow fila in Grilla.Rows)
                {
                    if (fila.Cells[0].Value != null)
                    {
                        decimal subtotal = Convert.ToDecimal(fila.Cells[4].Value);
                        totalVenta += subtotal;
                    }
                }
                TxtTotal.Text = totalVenta.ToString("0,0");

                ConeVentas cone = new ConeVentas();
                Venta nuevaVenta = new Venta
                {
                    IdCliente = IdCliente,
                    IdMetodo = VarMetodo,
                    Total = totalVenta
                };
                cone.AgregarPedido(nuevaVenta);

                int idVenta;
                using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
                {
                    con.Open();
                    using (OleDbCommand cmd = new OleDbCommand("SELECT MAX(IdVenta) FROM Ventas", con))
                    {
                        idVenta = (int)cmd.ExecuteScalar();
                    }
                    TxtPedido.Text = idVenta.ToString();


                    foreach (DataGridViewRow fila in Grilla.Rows)
                    {
                        if (fila.Cells[0].Value != null)
                        {
                            int idProducto = Convert.ToInt32(fila.Cells["Column1"].Value);
                            decimal precio = Convert.ToDecimal(fila.Cells["Column3"].Value);
                            int cantidad = Convert.ToInt32(fila.Cells["Column4"].Value);
                            decimal subtotal = Convert.ToDecimal(fila.Cells["Column5"].Value);

                            using (OleDbCommand cmdDetalle = new OleDbCommand(
                                "INSERT INTO DetalleVentas (IdVenta, IdProducto, PrecioVenta, Cantidad, Subtotal) VALUES (?, ?, ?, ?, ?)", con))
                            {
                                cmdDetalle.Parameters.AddWithValue("?", idVenta);
                                cmdDetalle.Parameters.AddWithValue("?", idProducto);
                                cmdDetalle.Parameters.AddWithValue("?", precio);
                                cmdDetalle.Parameters.AddWithValue("?", cantidad);
                                cmdDetalle.Parameters.AddWithValue("?", subtotal);
                                cmdDetalle.ExecuteNonQuery();
                            }

                            using (OleDbCommand cmdStock = new OleDbCommand(
                                "UPDATE Productos SET Stock = Stock - ? WHERE IdProducto = ?", con))
                            {
                                cmdStock.Parameters.AddWithValue("?", cantidad);
                                cmdStock.Parameters.AddWithValue("?", idProducto);
                                cmdStock.ExecuteNonQuery();
                            }
                        }
                    }

                    con.Close();
                }

                //Imprimir ticket
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(ImprimirGrilla);
                PrintPreviewDialog printPreview = new PrintPreviewDialog();
                printPreview.Document = pd;
                //printPreview.ShowDialog();
                pd.Print(); //imprimir
                MessageBox.Show("Venta realizada con éxito.", "Liz Showroom", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #region Limpiar y Enabled  yes/no
                TxtCliente.Text = "Cliente Final";
                LblCliente.Text = "23";
                IdCliente = 23;
                TxtDescripcion.Text = "";
                TxtPrecio.Text = "";
                TxtStock.Text = "";
                TxtSubTotal.Text = "";
                TxtTotal.Text = "";
                TxtCantidad.Text = "1";
                TxtIdProducto.Text = "";
                Grilla.Rows.Clear();
                TxtPedido.Text = "";

                BtnGrabar.Enabled = false;
                BtnCancelar.Enabled = false;
                BtnAgregarCliente.Enabled = false;
                BtnBuscarCliente.Enabled = false;
                BtnAgregarProducto.Enabled = false;
                BtnBuscarProducto.Enabled = false;
                TxtCantidad.Enabled = false;
                TxtIdProducto.Enabled = false;

                BtnNuevo.Enabled = true;
                Grilla.Visible = true;

                this.Tag = "none";
                #endregion
                BtnNuevo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la venta: " + ex.Message, "Liz Showroom", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ImprimirGrilla(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Font font = new Font("Arial", 7);
            Font fontBold = new Font("Arial", 7, FontStyle.Bold);
            Font fontHeader = new Font("Arial", 11, FontStyle.Bold);
            Font fontSmall = new Font("Arial", 6);

            float margenIzquierdo = 5;
            float y = 10;
            float anchoTicket = 188; 

            StringFormat sfDerecha = new StringFormat();
            sfDerecha.Alignment = StringAlignment.Far;

            string nombreCajero = this.nombreCajeroActual;
            decimal totalVenta = 0;
            int contadorArticulos = 0;
            float columnaCant = 135;
            float columnaSubtotal = anchoTicket - margenIzquierdo;
            float anchoProducto = 120; 


            string tienda = "Liz Showroom";
            SizeF anchoTienda = g.MeasureString(tienda, fontHeader);
            float xTienda = (anchoTicket - anchoTienda.Width) / 2;
            g.DrawString(tienda, fontHeader, Brushes.Black, xTienda, y);
            y += 25;

            g.DrawString("Dirección: Cipolletti Av. Los Andes 1605", font, Brushes.Black, margenIzquierdo, y);
            y += 15;
            g.DrawString("Tel: +54 9 299 510-4051", font, Brushes.Black, margenIzquierdo, y);
            y += 15;
            g.DrawString("Cajero: " + nombreCajero, font, Brushes.Black, margenIzquierdo, y);
            y += 15;
            g.DrawString("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), font, Brushes.Black, margenIzquierdo, y);
            y += 15;
            g.DrawLine(Pens.Black, margenIzquierdo, y, anchoTicket - margenIzquierdo, y);
            y += 15;

            g.DrawString("Descripción", fontBold, Brushes.Black, margenIzquierdo, y);
            g.DrawString("Cant.", fontBold, Brushes.Black, columnaCant, y, sfDerecha); 
            g.DrawString("Subtotal", fontBold, Brushes.Black, columnaSubtotal, y, sfDerecha);
            y += 15;


            g.DrawLine(Pens.Black, margenIzquierdo, y, anchoTicket - margenIzquierdo, y);
            y += 10;


            foreach (DataGridViewRow fila in Grilla.Rows)
            {
                if (fila.Cells[0].Value != null)
                {
                    string producto = fila.Cells[1].Value.ToString();
                    string cant = fila.Cells[3].Value.ToString();
                    decimal subtotal = Convert.ToDecimal(fila.Cells[4].Value);

                    totalVenta += subtotal;
                    contadorArticulos += Convert.ToInt32(cant);


                    RectangleF rectProducto = new RectangleF(margenIzquierdo, y, anchoProducto, 30);
                    g.DrawString(producto, font, Brushes.Black, rectProducto);

                    g.DrawString(cant, font, Brushes.Black, columnaCant, y, sfDerecha); 

                    g.DrawString("$" + subtotal.ToString("N0"), font, Brushes.Black, columnaSubtotal, y, sfDerecha);

                    y += 20;
                }
            }

            y += 5;
            g.DrawLine(Pens.Black, margenIzquierdo, y, anchoTicket - margenIzquierdo, y);
            y += 15;

            g.DrawString(contadorArticulos.ToString() + " artículo" + (contadorArticulos != 1 ? "s" : ""), font, Brushes.Black, margenIzquierdo, y);
            y += 15;

            float anchoTotal = g.MeasureString("TOTAL:", fontBold).Width;
            float xTotalEtiqueta = columnaSubtotal - anchoTotal - 50; 

            g.DrawString("TOTAL:", fontBold, Brushes.Black, xTotalEtiqueta, y);
            g.DrawString("$ " + totalVenta.ToString("N0"), fontBold, Brushes.Black, columnaSubtotal, y, sfDerecha);
            y += 20;





            g.DrawLine(Pens.Black, margenIzquierdo, y, anchoTicket - margenIzquierdo, y);
            y += 15;

            string p1 = "Se aceptan cambios en mercancia intacta ";
            string p2 = "dentro de los 3 dias siguientes a la compra,";
            string p3 = "presentando el ticket. No hay ";
            string p4 = "cambios en ropa interior ni trajes de baño.";

            g.DrawString(p1, fontSmall, Brushes.Black, (anchoTicket - g.MeasureString(p1, fontSmall).Width) / 2, y);
            y += 10;
            g.DrawString(p2, fontSmall, Brushes.Black, (anchoTicket - g.MeasureString(p2, fontSmall).Width) / 2, y);
            y += 10;
            g.DrawString(p3, fontSmall, Brushes.Black, (anchoTicket - g.MeasureString(p3, fontSmall).Width) / 2, y);
            y += 10;
            g.DrawString(p4, fontSmall, Brushes.Black, (anchoTicket - g.MeasureString(p4, fontSmall).Width) / 2, y);
            y += 20;
            g.DrawLine(Pens.Black, margenIzquierdo, y, anchoTicket - margenIzquierdo, y);
            y += 15;

            string gracias = "Gracias por su compra y vuelva pronto";
            float xGraciasMensaje = (anchoTicket - g.MeasureString(gracias, font).Width) / 2;
            g.DrawString(gracias, font, Brushes.Black, xGraciasMensaje, y);
            y += 20;

            g.DrawLine(Pens.Black, margenIzquierdo, y, anchoTicket - margenIzquierdo, y);
            y += 15;

        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            
            Close();
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
        "¿Está seguro de que desea cancelar la venta?",
        "Confirmar cancelación",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (resultado == DialogResult.Yes)
            {
                #region EnabledNO
                //false
                CboIdMetodo.Enabled = false;
                TxtBarCode.Enabled = false;
                BtnMetodo.Enabled = false;
                Fecha.Enabled = false;
                BtnGrabar.Enabled = false;
                BtnCancelar.Enabled = false;
                BtnAgregarProducto.Enabled = false;
                BtnBuscarProducto.Enabled = false;
                BtnAgregarProducto.Enabled = false;
                BtnBuscarProducto.Enabled = false;
                TxtCantidad.Enabled = false;
                panel3.Enabled = false;
                //true
                BtnNuevo.Enabled = true;
                Grilla.Visible = true;
                #endregion

                #region Limpiar
                TxtCliente.Text = "";
                TxtBarCode.Text = "";
                TxtDescripcion.Text = "";
                TxtDetalle.Text = "";
                TxtPrecio.Text = "";
                TxtStock.Text = "";
                TxtSubTotal.Text = "";
                TxtTotal.Text = "";
                TxtCantidad.Text = "1";
                #endregion

                Grilla.Rows.Clear();
                Total = 0;
                BtnNuevo.Focus();
                this.Tag = "none";
            }
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.Tag = "process";

            #region Enabled yes
            //true
            panel3.Enabled = true;  
            TxtCliente.Enabled = true;
            CboIdMetodo.Enabled = true;
            BtnMetodo.Enabled = true;
            TxtBarCode.Enabled = true;
            BtnGrabar.Enabled = true;
            BtnCancelar.Enabled = true;
            BtnAgregarCliente.Enabled = true;
            BtnBuscarCliente.Enabled = true;
            BtnAgregarProducto.Enabled = true;
            BtnBuscarProducto.Enabled = true;
            TxtCantidad.Enabled = true;
            TxtIdProducto.Enabled = true;
            Grilla.Visible = true;
            //false
            BtnNuevo.Enabled = false;
            #endregion

            #region Limpiar
            TxtCliente.Text = "Cliente Final";
            TxtDescripcion.Text = "";
            TxtDetalle.Text = "";
            TxtPrecio.Text = "";
            TxtStock.Text = "";
            TxtSubTotal.Text = "";
            TxtTotal.Text = "";
            TxtCantidad.Text = "1";    
            TxtIdProducto.Text = "";
            #endregion

            TxtBarCode.Focus();
            Grilla.Rows.Clear();
            Total = 0;
        }
        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            FormBuscarProducto form = new FormBuscarProducto();
            AddOwnedForm(form);
            form.ShowDialog();

            TxtCantidad.Enabled = true;
            TxtCantidad.Focus();
        }
        private void BtnBuscarProveedor_Click(object sender, EventArgs e)
        {

            FormBuscarCliente form = new FormBuscarCliente();
            AddOwnedForm(form);
            form.ShowDialog();
        }
        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            FormAgregarProducto form = new FormAgregarProducto();
            form.ShowDialog();
        }
        private void FormVENTAS_Load(object sender, EventArgs e)
        {
            TxtCliente.Text = "Cliente Final"; 
            LblCliente.Text = "23";          
            IdCliente = 23;                     

            Grilla.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Italic);
            Grilla.RowsDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Italic);

            Grilla.Columns[1].Width = 200;
        }
        private void TxtBarCode_TextChanged(object sender, EventArgs e)
        {
            if (TxtBarCode.Text.Length == 13)
            {

                

                ConeProductos vali = new ConeProductos();
                Productos bar = new Productos
                {
                    BarCode = Double.Parse(TxtBarCode.Text)
                };
                exist = vali.Validar(bar);

                if (exist == true)
                {
                    OleDbCommand cm = new OleDbCommand($"SELECT IdProducto, Descripcion, Detalle, Stock, PrecioVenta FROM Productos WHERE BarCode = {TxtBarCode.Text};", con);
                    con.Open();
                    OleDbDataReader dr = cm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            TxtIdProducto.Text = dr.GetInt32(0).ToString();
                            TxtDescripcion.Text = dr.GetString(1);
                            TxtDetalle.Text = dr.GetString(2);
                            TxtStock.Text = dr.GetInt32(3).ToString();
                            Precio = dr.GetDecimal(4);
                            TxtPrecio.Text = Precio.ToString("0,0");
                        }
                        TxtCantidad.Enabled = true;
                        //TxtCantidad.Focus();
                    }
                    dr.Close();
                    con.Close();

                    //Aumentar cantidad si el producto ya existe en la grilla
                    string valorBuscado = TxtIdProducto.Text;
                    foreach (DataGridViewRow fila in Grilla.Rows)
                    {
                        if (fila.IsNewRow)
                        {
                            continue;
                        }
                        
                        if (fila.Cells["Column1"].Value != null && fila.Cells["Column1"].Value.ToString() == valorBuscado)
                        {
                            //Se prepara para aumentar la cantidad
                            int filaIndex = fila.Index;
                            int pPlus = Int32.Parse(Grilla.Rows[filaIndex].Cells["Column4"].Value.ToString());
                            pPlus = pPlus + 1; //Cantidad + 1

                            //Verificar que el stock lo permita
                            int StockDisponible = vali.ObtenerStockDesdeDB(Int32.Parse(valorBuscado));
                            if (pPlus > StockDisponible)
                            {
                                pPlus = pPlus-1; //Revertir aumento
                                if (usuarioActual == 1)
                                {
                                    MessageBox.Show(
                                        $"El stock disponible: {StockDisponible} es menor a la cantidad que intenta vender = {pPlus+1}.\n" +
                                        $"La venta se realizara con el maximo stock disponible de ''{Grilla.Rows[filaIndex].Cells[1].Value}'' \n" +
                                        "(SE RECOMIENDA REVISAR LA BASE DE DATOS)",
                                        "Confirmar acción",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning
                                    );
                                    LimpiarTextos();
                                    TxtBarCode.Focus();
                                    //Ajustar cantidad al stock disponible
                                    Grilla.Rows[filaIndex].Cells["Column4"].Value = StockDisponible;

                                    //Recalcular subtotal
                                    Grilla.Rows[filaIndex].Cells["Column5"].Value = pPlus * Precio;
                                    



                                }
                                else if (usuarioActual == 2)
                                {
                                    MessageBox.Show($"Error inesperado, la base de datos registra un stock menor al que intenta vender \n" +
                                        $"Stock: {StockDisponible} \n" +
                                        $"Cantidad: {pPlus+1}\n" +
                                        $"Notifica al administrador correspondiente. La venta se realizara con el maximo stock disponible de ''{Grilla.Rows[filaIndex].Cells[1].Value}''",
                                    "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    LimpiarTextos();
                                    TxtBarCode.Focus();

                                    //Ajustar cantidad al stock disponible
                                    Grilla.Rows[filaIndex].Cells["Column4"].Value = StockDisponible;

                                    //Recalcular subtotal
                                    Grilla.Rows[filaIndex].Cells["Column5"].Value = pPlus * Precio;

                                }

                                

                            }
                            else 
                            {

                                //Aumentar cantidad
                                Grilla.Rows[filaIndex].Cells["Column4"].Value = pPlus;
                                //Recalcular subtotal
                                Grilla.Rows[filaIndex].Cells[4].Value = pPlus * Precio;

                                LimpiarTextos();
                                TxtBarCode.Focus();

                            }

                             
                        }
                        

                    }

                    decimal Suma = Grilla.Rows.OfType<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[4].Value));
                    Total = Suma;
                    TxtTotal.Text = String.Format("{0:0,0}", Suma);
                }
                else
                {
                    MessageBox.Show("El Código de Barras no existe. Le sugerimos que revise la base de datos ", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtBarCode.Clear();
                    TxtBarCode.Focus();
                    return;
                }
                



                    
                    
            }
        }
        private void TxtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                BtnCancelar.PerformClick();
            }
        }
        private void TxtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                BtnCancelar.PerformClick();
            }
        }

        private void BtnMetodo_Click(object sender, EventArgs e)
        {
            FormABMMetododepago frm = new FormABMMetododepago();
            frm.ShowDialog();
        }

        private void BtnAgregarProveedor_Click(object sender, EventArgs e)
        {
            FormAgregarCliente form = new FormAgregarCliente();
            form.ShowDialog();
        }
        #endregion

        #region Interaccion con formulario
        private void CboIdMetodo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VarMetodo = int.Parse(CboIdMetodo.SelectedValue.ToString());
        }
        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if (e.KeyChar == (int)Keys.Enter)
            {
                if (TxtCantidad.Text == "")
                {
                    MessageBox.Show("Ingrese correctamente la cantidad.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtCantidad.Text = "1";
                    TxtCantidad.Focus();
                    return;
                }
                else if (int.Parse(TxtCantidad.Text) <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a 0.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtCantidad.Text = "1";
                    TxtCantidad.Focus();
                    return;
                }
                else if (int.Parse(TxtCantidad.Text) > int.Parse(TxtStock.Text))
                {
                    MessageBox.Show("La cantidad no debe superar el stock.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtCantidad.Text = "1";
                    TxtCantidad.Focus();
                    return;
                }
                else
                {
                    Precio = Convert.ToDecimal(TxtPrecio.Text);
                    Cantidad = int.Parse(TxtCantidad.Text);
                    Subtotal = Cantidad * Precio;
                    Subtotal = (int.Parse(TxtCantidad.Text) * Precio);
                    TxtSubTotal.Text = Subtotal.ToString("0,0");

                    bool Existe = Grilla.Rows.Cast<DataGridViewRow>().Any(x => x.Cells["Column1"].Value.ToString() == TxtIdProducto.Text);
                  
                    if (!Existe)
                    {
                        if (Grilla.Rows.Count >50)
                        {
                            MessageBox.Show("Ha superado el número de productos.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BtnGrabar.Focus();
                            return;
                        }
                        else
                        {
                            Grilla.Rows.Add(TxtIdProducto.Text, TxtDescripcion.Text, TxtPrecio.Text, TxtCantidad.Text, Subtotal);

                            Total += Subtotal;
                            TxtTotal.Text = Total.ToString("0,0");
                            LimpiarTextos();
                            TxtBarCode.Focus();
                            BtnGrabar.Enabled = true;
                        }
                    }
                    
                }
            }
            if (e.KeyChar == (int)Keys.Escape)
            {
                LimpiarTextos();
                TxtCantidad.Enabled = false;
                TxtBarCode.Focus();
            }
        }
        private void TxtIdProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if (e.KeyChar == (int)Keys.Enter)
            {
                if (TxtIdProducto.Text == "")
                {
                    FormBuscarProducto form = new FormBuscarProducto();
                    AddOwnedForm(form);
                    form.ShowDialog();

                    TxtPrecio.Text = Precio.ToString("0,0");
                    TxtCantidad.Enabled = true;
                    TxtCantidad.Focus();
                }
                else
                {
                    OleDbCommand cm = new OleDbCommand($"SELECT Descripcion, Stock, PrecioVenta FROM Productos WHERE IdProducto = {TxtIdProducto.Text};", con);
                    con.Open();
                    OleDbDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            TxtDescripcion.Text = dr.GetString(0);
                            TxtStock.Text = dr.GetInt32(1).ToString();
                            Precio = dr.GetDecimal(2);
                            TxtPrecio.Text = Precio.ToString("0,0");

                        }
                        TxtCantidad.Enabled = true;
                        TxtCantidad.Focus();
                    }
                    dr.Close();
                    con.Close();
                }
            }
            if (e.KeyChar == (int)Keys.Escape)
            {
                LimpiarTextos();
            }
        }
        private void Grilla_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            Resultado = 0;

            if (Grilla.RowCount == 0)
            {
                TxtTotal.Text = "0";
                TxtSubTotal.Text = "0";
                BtnGrabar.Enabled = false;
                TxtIdProducto.Focus();
            }

            decimal Suma = Grilla.Rows.OfType<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[4].Value));
            Total = Suma;
            TxtTotal.Text = String.Format("{0:0,0}", Suma);
        }
        private void Grilla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (Grilla.Columns[e.ColumnIndex].Name == "Column4") 
            {
                int nuevaCantidad;
                var valor = Grilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (!int.TryParse(valor, out nuevaCantidad))
                {
                    MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Grilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                    return;
                }

                int idProducto = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells["Column1"].Value); 
                CapaDatos.ConeProductos datos = new CapaDatos.ConeProductos();
                int stockDisponible = datos.ObtenerStockDesdeDB(idProducto);

                if (nuevaCantidad > stockDisponible)
                {
                    MessageBox.Show($"No puede vender {nuevaCantidad} unidades. Solo hay {stockDisponible} disponibles.",
                        "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Grilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = stockDisponible; // ajustamos al stock
                    nuevaCantidad = stockDisponible;
                }
                else if (nuevaCantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Grilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                    nuevaCantidad = 1;
                }
            }


            Resultado = 0;

            if (Grilla.RowCount == 0)
            {
                TxtTotal.Text = "0";
            }

            Cantidad = Convert.ToDecimal(Grilla.Rows[e.RowIndex].Cells[2].Value);
            Precio = Convert.ToDecimal(Grilla.Rows[e.RowIndex].Cells[3].Value);
            Resultado = Precio * Cantidad;

            Grilla.Rows[e.RowIndex].Cells[4].Value = String.Format("{0:0,0}", Resultado);
            decimal Suma = Grilla.Rows.OfType<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[4].Value));
            Total = Suma;
            TxtTotal.Text = Suma.ToString("0,0");

            TxtBarCode.Focus();
        }
        #endregion
    }
}
