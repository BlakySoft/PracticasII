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

namespace CapaPresentacion
{
    public partial class FormVENTAS: Form
    {
        #region Declaraciones y cponexion
        public decimal Stock, Cantidad, Precio, Subtotal, Total, Resultado;
        public int IdCliente, VarMetodo;
        Conexion cn = new Conexion();
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
        #endregion 

        #region Metodo
        public FormVENTAS()
        {
            InitializeComponent();
            
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
                printPreview.ShowDialog();

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

            Font font = new Font("Arial", 9);
            Font fontBold = new Font("Arial", 9, FontStyle.Bold);
            Font fontHeader = new Font("Arial", 11, FontStyle.Bold);

            float margenIzquierdo = 10;
            float y = 20;
            float anchoTicket = 320;

                    string tienda = "Lis Showroom";
            SizeF anchoTienda = g.MeasureString(tienda, fontHeader);
            g.DrawString(tienda, fontHeader, Brushes.Black, (anchoTicket - anchoTienda.Width) / 2, y);
            y += 25;

            string titulo = "TICKET DE VENTA";
            SizeF anchoTitulo = g.MeasureString(titulo, fontBold);
            g.DrawString(titulo, fontBold, Brushes.Black, (anchoTicket - anchoTitulo.Width) / 2, y);
            y += 25;

            g.DrawString("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), font, Brushes.Black, margenIzquierdo, y);
            y += 25;

            
            float anchoProducto = 140;
            foreach (DataGridViewRow fila in Grilla.Rows)
            {
                if (fila.Cells[1].Value != null)
                {
                    string producto = fila.Cells[1].Value.ToString();
                    SizeF tamaño = g.MeasureString(producto, font);
                    if (tamaño.Width > anchoProducto) anchoProducto = Math.Min(tamaño.Width + 10, 180); // max 180 px
                }
            }

            float columnaPrecio = anchoProducto + 10;  
            float columnaCantidad = columnaPrecio + 60;   
            float columnaSubtotal = columnaCantidad + 60; 

            // --- Encabezados de columna ---
            g.DrawLine(Pens.Black, margenIzquierdo, y, anchoTicket, y);
            y += 5;

            g.DrawString("Producto", fontBold, Brushes.Black, margenIzquierdo, y);
            g.DrawString("Precio", fontBold, Brushes.Black, columnaPrecio, y);
            g.DrawString("Cantidad", fontBold, Brushes.Black, columnaCantidad, y);
            g.DrawString("Subtotal", fontBold, Brushes.Black, columnaSubtotal, y);
            y += 20;

            g.DrawLine(Pens.Black, margenIzquierdo, y, anchoTicket, y);
            y += 5;

            // --- Detalles de la venta ---
            StringFormat sfDerecha = new StringFormat();
            sfDerecha.Alignment = StringAlignment.Far;

            decimal totalVenta = 0;

            foreach (DataGridViewRow fila in Grilla.Rows)
            {
                if (fila.Cells[0].Value != null)
                {
                    string producto = fila.Cells[1].Value.ToString();
                    decimal precio = Convert.ToDecimal(fila.Cells[2].Value);
                    string cant = fila.Cells[3].Value.ToString();
                    decimal subtotal = Convert.ToDecimal(fila.Cells[4].Value);

                    totalVenta += subtotal;

                    // Producto
                    RectangleF rectProducto = new RectangleF(margenIzquierdo, y, anchoProducto, 20);
                    g.DrawString(producto, font, Brushes.Black, rectProducto);

                    // Columnas de números alineadas a la derecha
                    g.DrawString("$" + precio.ToString("N0"), font, Brushes.Black, columnaPrecio + 50, y, sfDerecha);
                    g.DrawString(cant, font, Brushes.Black, columnaCantidad + 50, y, sfDerecha);
                    g.DrawString("$" + subtotal.ToString("N0"), font, Brushes.Black, columnaSubtotal + 50, y, sfDerecha);

                    y += 20;
                }
            }

            y += 5;
            g.DrawLine(Pens.Black, margenIzquierdo, y, anchoTicket, y);
            y += 15;

            // --- Total general ---
            g.DrawString("TOTAL: $" + totalVenta.ToString("N0"), fontBold, Brushes.Black, columnaSubtotal + 50, y, sfDerecha);
            y += 25;

            g.DrawLine(Pens.Black, margenIzquierdo, y, anchoTicket, y);
            y += 20;

            // --- Pie de página centrado ---
            string gracias = "¡Gracias por su compra!";
            SizeF anchoGracias = g.MeasureString(gracias, font);
            g.DrawString(gracias, font, Brushes.Black, (anchoTicket - anchoGracias.Width) / 2, y);
            y += 20;

            string mensaje = "Vuelva pronto";
            SizeF anchoMensaje = g.MeasureString(mensaje, font);
            g.DrawString(mensaje, font, Brushes.Black, (anchoTicket - anchoMensaje.Width) / 2, y);

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
            }
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {

            #region Enabled yes
            //true
            CboIdMetodo.Enabled = true;
            BtnMetodo.Enabled = true;
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

        private void TxtIdProducto_TextChanged(object sender, EventArgs e)
        {

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
                        if (Grilla.Rows.Count > 15)
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
                            TxtIdProducto.Focus();
                            BtnGrabar.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El producto seleccionado ya fue ingresado.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarTextos();

                        TxtIdProducto.Focus();
                        return;
                    }
                }
            }
            if (e.KeyChar == (int)Keys.Escape)
            {
                LimpiarTextos();
                TxtCantidad.Enabled = false;
                TxtIdProducto.Focus();
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
        }
        #endregion
    }
}
