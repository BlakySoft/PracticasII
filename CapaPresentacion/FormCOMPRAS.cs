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
    public partial class FormCOMPRAS: Form
    {
        #region Declaraciones y conexion
        public string IdProveedorCompra;
        public decimal Stock, Cantidad, Precio, Subtotal, Total, Resultado;
        public int VarMetodo;

        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");

        #endregion

        #region Metodos
        public FormCOMPRAS()
        {
            InitializeComponent();
            CargarCbo();
            Fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            #region EnabledNO
            //false
            BtnMetodo.Enabled = false;
            CboIdMetodo.Enabled = false;
            Fecha.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnAgregarProveedor.Enabled = false;
            BtnBuscarProveedor.Enabled = false;
            BtnAgregarProducto.Enabled = false;
            BtnBuscarProducto.Enabled = false;
            TxtCantidad.Enabled = false;
            //true
            BtnNuevo.Enabled = true;
            Grilla.Visible = true;
            #endregion

            #region Limpiar
            TxtRazon.Text = "";
            TxtDescripcion.Text = "";
            TxtDetalle.Text = "";
            TxtPrecio.Text = "";
            TxtStock.Text = "";
            TxtSubtotall.Text = "";
            TxtTotall.Text = "";
            TxtCantidad.Text = "1";
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
            TxtCantidad.Text = "1";
            TxtDescripcion.Text = "";
            TxtStock.Text = "";
            TxtPrecio.Text = "";
        }
        #endregion

        #region Botones
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            #region EnabledYES
            //false
            BtnNuevo.Enabled = false;
            //true
            BtnMetodo.Enabled = true;
            CboIdMetodo.Enabled = true;
            Fecha.Enabled = true;
            BtnGrabar.Enabled = true;
            BtnCancelar.Enabled = true;
            Grilla.Visible = true;
            BtnAgregarProveedor.Enabled = true;
            BtnBuscarProveedor.Enabled = true;
            BtnAgregarProducto.Enabled = true;
            BtnBuscarProducto.Enabled = true;
            TxtCantidad.Enabled = true;
            #endregion

            #region Limpiar
            TxtRazon.Text = "";
            TxtDescripcion.Text = "";
            TxtDetalle.Text = "";
            TxtPrecio.Text = "";
            TxtStock.Text = "";
            TxtSubtotall.Text = "";
            TxtTotall.Text = "";
            TxtCantidad.Text = "1";
            #endregion

            Grilla.Rows.Clear();
            Total = 0;
        }
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (TxtRazon.Text == "")
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (TxtTotal.Text == "0" || TxtTotal.Text == "")
            {
                MessageBox.Show("El monto de la compra debe ser mayor a 0", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                decimal Suma = Grilla.Rows.OfType<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[4].Value));
                TxtTotal.Text = Suma.ToString("0,0");

                ConeCompras cone = new ConeCompras();
                Compra Agregar = new Compra
                {
                    IdProveedor = Convert.ToInt32(IdProveedorCompra),
                    IdMetodo = VarMetodo,
                    Total = Suma
                };

                cone.Agregar(Agregar);

                OleDbConnection conecta = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
                OleDbCommand comando = new OleDbCommand();
                OleDbDataReader lector;

                comando.CommandText = "Select max(IdCompra) as IdCompra from Compras";
                comando.Connection = conecta;
                conecta.Open();

                lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    Compra compra = new Compra
                    {
                        IdCompra = lector.GetInt32(0)
                    };
                    TxtCompras.Text = compra.IdCompra.ToString();
                }

                conecta.Close();

                if (Grilla.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in Grilla.Rows)
                    {
                        if (row.IsNewRow) continue; // Ignorar la fila vacía al final

                        // Obtener valores de forma segura
                        object valIdProducto = row.Cells["Column1"].Value;
                        object valCantidad = row.Cells["Column3"].Value;

                        if (valIdProducto == null || valCantidad == null) continue; // Saltar si hay null

                        int idProducto = 0;
                        int cantidadComprada = 0;

                        if (!int.TryParse(valIdProducto.ToString(), out idProducto)) continue;
                        if (!int.TryParse(valCantidad.ToString(), out cantidadComprada)) continue;

                        // Insertar detalle (ya lo tenés)
                        OleDbCommand comando1 = new OleDbCommand
                        {
                            CommandType = CommandType.Text,
                            CommandText = "insert into DetalleCompras (IdCompra, IdProducto, Descripcion, Cantidad, PrecioCompra, Subtotal) values (@IdCompra, @IdProducto, @Descripcion, @Cantidad, @PrecioCompra, @Subtotal)",
                            Connection = conecta
                        };

                        comando1.Parameters.AddWithValue("@IdCompra", TxtCompras.Text);
                        comando1.Parameters.AddWithValue("@IdProducto", idProducto);
                        comando1.Parameters.AddWithValue("@Descripcion", row.Cells["Column2"].Value?.ToString() ?? "");
                        comando1.Parameters.AddWithValue("@Cantidad", cantidadComprada);
                        comando1.Parameters.AddWithValue("@PrecioCompra", Convert.ToDecimal(row.Cells["Column4"].Value));
                        comando1.Parameters.AddWithValue("@Subtotal", Convert.ToDecimal(row.Cells["Column5"].Value));

                        conecta.Open();
                        comando1.ExecuteNonQuery();

                        // Actualizar stock de forma segura
                        OleDbCommand actualizarStock = new OleDbCommand
                        {
                            Connection = conecta,
                            CommandText = "UPDATE Productos SET Stock = Stock + @Cantidad WHERE IdProducto = @IdProducto"
                        };
                        actualizarStock.Parameters.AddWithValue("@Cantidad", cantidadComprada);
                        actualizarStock.Parameters.AddWithValue("@IdProducto", idProducto);
                        actualizarStock.ExecuteNonQuery();

                        conecta.Close();
                    }
                }

                MessageBox.Show("Compra realizada con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #region EnabledNO
                //false
                Fecha.Enabled = false;
                BtnGrabar.Enabled = false;
                BtnCancelar.Enabled = false;
                BtnAgregarProveedor.Enabled = false;
                BtnBuscarProveedor.Enabled = false;
                BtnAgregarProducto.Enabled = false;
                BtnBuscarProducto.Enabled = false;
                TxtCantidad.Enabled = false;
                //true
                BtnNuevo.Enabled = true;
                Grilla.Visible = true;
                #endregion

                #region Limpiar
                TxtRazon.Text = "";
                TxtDescripcion.Text = "";
                TxtDetalle.Text = "";
                TxtPrecio.Text = "";
                TxtStock.Text = "";
                TxtSubtotall.Text = "";
                TxtTotall.Text = "";
                TxtCantidad.Text = "1";
                #endregion

                Grilla.Rows.Clear();
                Total = 0;
                BtnNuevo.Focus();
            }

        }       
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
                      DialogResult resultado = MessageBox.Show(
                 "¿Está seguro de que desea cancelar la compra?",
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
                BtnAgregarProveedor.Enabled = false;
                BtnBuscarProveedor.Enabled = false;
                BtnAgregarProducto.Enabled = false;
                BtnBuscarProducto.Enabled = false;
                TxtCantidad.Enabled = false;
                //true
                BtnNuevo.Enabled = true;
                Grilla.Visible = true;
                #endregion

                #region Limpiar
                TxtRazon.Text = "";
                TxtDescripcion.Text = "";
                TxtDetalle.Text = "";
                TxtPrecio.Text = "";
                TxtStock.Text = "";
                TxtSubtotall.Text = "";
                TxtTotall.Text = "";
                TxtCantidad.Text = "1";
                #endregion

                Grilla.Rows.Clear();
                Total = 0;
                BtnNuevo.Focus();
            }
        }
        private void BtnBuscarProveedor_Click(object sender, EventArgs e)
        {
            FormBuscarProveedor form = new FormBuscarProveedor();
            AddOwnedForm(form);
            form.ShowDialog();
        }
        private void BtnAgregarProveedor_Click(object sender, EventArgs e)
        {
            FormAgregarProveedor form = new FormAgregarProveedor();
            form.ShowDialog();
            TxtCantidad.Focus();
        }
        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            FormBuscarProductosCOMPRAS form = new FormBuscarProductosCOMPRAS();
            AddOwnedForm(form);
            form.ShowDialog();

            TxtCantidad.Enabled = true;
            TxtCantidad.Focus();
        }
        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            FormAgregarProducto form = new FormAgregarProducto();
            form.ShowDialog();
        }
        private void BtnMetodo_Click(object sender, EventArgs e)
        {
            FormABMMetododepago form = new FormABMMetododepago();
            form.ShowDialog();
        }
        private void FormCOMPRAS_Load(object sender, EventArgs e)
        {
            // Cambiar fuente de los encabezados de columna
            Grilla.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Italic);

            // Cambiar fuente de las filas
            Grilla.RowsDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Italic);

            Grilla.Columns[1].Width = 200;
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }


        #endregion

        #region Interaccion con Formulario
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
                else
                {
                    Cantidad = int.Parse(TxtCantidad.Text);
                    Subtotal = Cantidad * Precio;
                    TxtSubtotall.Text = Subtotal.ToString("0,0");

                    bool Existe = Grilla.Rows.Cast<DataGridViewRow>().Any(x => x.Cells["Column1"].Value.ToString() == TxtIdProducto
                    .Text);

                    if (!Existe)
                    {
                        if (Grilla.Rows.Count > 15)
                        {
                            MessageBox.Show("Ha superado el número del Producto.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BtnGrabar.Focus();
                            return;
                        }
                        else
                        {
                            Grilla.Rows.Add(TxtIdProducto.Text, TxtDescripcion.Text, TxtCantidad.Text, TxtPrecio.Text, TxtSubtotall.Text);
                          

                            Total += Subtotal;
                            TxtTotal.Text = Total.ToString("0,0");

                            LimpiarTextos();

                            BtnGrabar.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El producto seleccionado ya fue ingresado.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarTextos();

                        return;
                    }
                }
            }
            if (e.KeyChar == (int)Keys.Escape)
            {
                LimpiarTextos();
                TxtCantidad.Enabled = false;
            }
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
        #endregion


    }
}
