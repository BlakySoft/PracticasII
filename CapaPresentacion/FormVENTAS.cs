using CapaDatos;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
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
            
                if (TxtCliente.Text == "")
                {
                    MessageBox.Show("Debe seleccionar un cliente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    decimal Suma = Grilla.Rows.OfType<DataGridViewRow>().Sum(x => Convert.ToInt32(x.Cells[4].Value));
                    TxtTotal.Text = Suma.ToString("0,0");

                    ConeVentas cone = new ConeVentas();
                    Venta Agregar = new Venta
                    {
                        IdCliente = IdCliente,
                        IdMetodo = VarMetodo,
                        IdVenta = 1,
                        Total = Suma
                    };

                    cone.AgregarPedido(Agregar);

                    OleDbCommand comando = new OleDbCommand();
                    OleDbDataReader reader;

                    comando.CommandText = "Select max(IdVenta) as IdVenta from Ventas";
                    comando.Connection = con;
                    con.Open();
                    reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        Venta pedido = new Venta();
                        pedido.IdVenta = reader.GetInt32(0);
                        TxtPedido.Text = pedido.IdVenta.ToString();
                    }

                    con.Close();

                    if (Grilla.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in Grilla.Rows)
                        {
                            OleDbCommand cm = new OleDbCommand();
                            cm.CommandType = CommandType.Text;
                            cm.CommandText = "insert into DetalleVentas (IdVenta, IdProducto, PrecioVenta, Cantidad, Subtotal) values (@IdVenta, @IdProducto, @PrecioVenta, @Cantidad, @Subtotal)";
                            cm.Connection = con;


                            cm.Parameters.AddWithValue("@IdVenta", Convert.ToString(TxtPedido.Text));
                            cm.Parameters.AddWithValue("@IdProducto", Convert.ToInt32(row.Cells["Column1"].Value));
                            cm.Parameters.AddWithValue("@PrecioVenta", Convert.ToDecimal(row.Cells["Column3"].Value));
                            cm.Parameters.AddWithValue("@Cantidad", Convert.ToDecimal(row.Cells["Column4"].Value));
                            cm.Parameters.AddWithValue("@Subtotal", Convert.ToDecimal(row.Cells["Column5"].Value));

                            int IdArti = Convert.ToInt32(row.Cells["Column1"].Value);
                            Cantidad = Convert.ToInt32(row.Cells["Column4"].Value);

                            con.Open();
                            cm.ExecuteNonQuery();
                            con.Close();


                            comando.CommandText = $"Select Stock from Productos where IdProducto =" + IdArti;
                            comando.Connection = con;
                            con.Open();
                            reader = comando.ExecuteReader();

                            if (reader.Read())
                            {
                                Productos producto = new Productos();

                                producto.Stock = reader.GetInt32(0);
                                Stock = producto.Stock;
                                Stock = Stock - Cantidad;
                                con.Close();

                                OleDbCommand com = new OleDbCommand();

                                com.CommandType = CommandType.Text;
                                com.CommandText = $"update Productos set Stock = {Stock} where IdProducto = {IdArti}";
                                com.Connection = con;

                                con.Open();
                                com.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                    MessageBox.Show("Venta realizada con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #region Enabled

                    //false
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

                    TxtCliente.Text = "";
                    TxtDescripcion.Text = "";
                    TxtPrecio.Text = "";
                    TxtStock.Text = "";
                    TxtSubTotal.Text = "";
                    TxtTotal.Text = "";
                    TxtCantidad.Text = "1";
                    TxtIdProducto.Text = "";
                    Grilla.Rows.Clear();


                    Total = 0;

                    BtnNuevo.Focus();
                }
          
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

            // Cambiar fuente de los encabezados de columna
            Grilla.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Italic);

            // Cambiar fuente de las filas
            Grilla.RowsDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Italic);

            Grilla.Columns[1].Width = 200;
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
