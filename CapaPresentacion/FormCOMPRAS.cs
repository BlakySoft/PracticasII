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
            #region EnabledNO
            //false
            BtnMetodo.Enabled = false;
            CboIdMetodo.Enabled = false;
            FechaActual.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnAgregarProveedor.Enabled = false;
            BtnBuscarProveedor.Enabled = false;
            BtnAgregarProducto.Enabled = false;
            BtnBuscarProducto.Enabled = false;
            TxtIdMateria.Enabled = false;
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
            TxtSubTotal.Text = "";
            TxtTotal.Text = "";
            TxtCantidad.Text = "1";
            TxtIdMateria.Text = "";
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
            TxtIdMateria.Text = "";
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
            FechaActual.Enabled = true;
            BtnGrabar.Enabled = true;
            BtnCancelar.Enabled = true;
            TxtIdMateria.Enabled = true;
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
            TxtSubTotal.Text = "";
            TxtTotal.Text = "";
            TxtCantidad.Text = "1";
            TxtIdMateria.Text = "";
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
                    TxtCompra.Text = compra.IdCompra.ToString();
                }

                conecta.Close();

                if (Grilla.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in Grilla.Rows)
                    {
                        OleDbCommand comando1 = new OleDbCommand
                        {
                            CommandType = CommandType.Text,
                            CommandText = "insert into DetalleCompras (IdCompra, IdMateria, Descripcion, Cantidad, PrecioCompra, Subtotal) values (@IdCompra, @IdMateria, @Descripcion, @Cantidad, @PrecioCompra, @Subtotal)",
                            Connection = conecta
                        };

                        comando1.Parameters.AddWithValue("@IdCompra", Convert.ToString(TxtCompra.Text));
                        comando1.Parameters.AddWithValue("@IdMateria", Convert.ToInt32(row.Cells["Column1"].Value));
                        comando1.Parameters.AddWithValue("@Descripcion", Convert.ToString(row.Cells["Column2"].Value));
                        comando1.Parameters.AddWithValue("@Cantidad", Convert.ToDecimal(row.Cells["Column3"].Value));
                        comando1.Parameters.AddWithValue("@Precio", Convert.ToDecimal(row.Cells["Column4"].Value));
                        comando1.Parameters.AddWithValue("@Subtotal", Convert.ToDecimal(row.Cells["Column5"].Value));


                        int IdArti = Convert.ToInt32(row.Cells["Column1"].Value);
                        Cantidad = Convert.ToInt32(row.Cells["Column3"].Value);

                        conecta.Open();
                        comando1.ExecuteNonQuery();
                        conecta.Close();

                        comando.CommandText = $"Select Stock from Materias where IdMateria = {IdArti}";
                        comando.Connection = conecta;
                        conecta.Open();
                        lector = comando.ExecuteReader();

                        if (lector.Read())
                        {
                            Materia materia = new Materia
                            {
                                Stock = lector.GetInt32(0)
                            };
                            Stock = materia.Stock;
                            Stock += Cantidad;
                            conecta.Close();

                            OleDbCommand com = new OleDbCommand
                            {
                                CommandType = CommandType.Text,

                                CommandText = $"update Materias set Stock = {Stock} where IdMateria = {IdArti}",
                                Connection = con
                            };
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                MessageBox.Show("Compra realizada con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #region EnabledNO
                //false
                FechaActual.Enabled = false;
                BtnGrabar.Enabled = false;
                BtnCancelar.Enabled = false;
                BtnAgregarProveedor.Enabled = false;
                BtnBuscarProveedor.Enabled = false;
                BtnAgregarProducto.Enabled = false;
                BtnBuscarProducto.Enabled = false;
                TxtIdMateria.Enabled = false;
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
                TxtSubTotal.Text = "";
                TxtTotal.Text = "";
                TxtCantidad.Text = "1";
                TxtIdMateria.Text = "";
                #endregion

                Grilla.Rows.Clear();
                Total = 0;
                BtnNuevo.Focus();
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            #region EnabledNO
            //false
            CboIdMetodo.Enabled = false;
            BtnMetodo.Enabled = false;
            FechaActual.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnAgregarProveedor.Enabled = false;
            BtnBuscarProveedor.Enabled = false;
            BtnAgregarProducto.Enabled = false;
            BtnBuscarProducto.Enabled = false;
            TxtIdMateria.Enabled = false;
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
            TxtSubTotal.Text = "";
            TxtTotal.Text = "";
            TxtCantidad.Text = "1";
            TxtIdMateria.Text = "";
            #endregion

            Grilla.Rows.Clear();
            Total = 0;
            BtnNuevo.Focus();
            Grilla.Rows.Clear();
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
        }
        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            FormBuscarMaterias form = new FormBuscarMaterias();
            AddOwnedForm(form);
            form.ShowDialog();
            TxtCantidad.Enabled = true;
            TxtCantidad.Focus();
        }
        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            FormAgregarMateria form = new FormAgregarMateria();
            form.ShowDialog();
        }
        private void BtnMetodo_Click(object sender, EventArgs e)
        {
            FormABMMetododepago form = new FormABMMetododepago();
            form.ShowDialog();
        }    
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CboIdBarrio_Click(object sender, EventArgs e)
        {
            CargarCbo();
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
                    TxtSubTotal.Text = Subtotal.ToString("0,0");

                    bool Existe = Grilla.Rows.Cast<DataGridViewRow>().Any(x => x.Cells["Column1"].Value.ToString() == TxtIdMateria.Text);

                    if (!Existe)
                    {
                        if (Grilla.Rows.Count > 15)
                        {
                            MessageBox.Show("Ha superado el número de materia prima.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BtnGrabar.Focus();
                            return;
                        }
                        else
                        {
                            Grilla.Rows.Add(TxtIdMateria.Text, TxtDescripcion.Text, TxtCantidad.Text, TxtPrecio.Text, TxtSubTotal.Text);

                            Total += Subtotal;
                            TxtTotal.Text = Total.ToString("0,0");

                            LimpiarTextos();

                            TxtIdMateria.Focus();
                            BtnGrabar.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El producto seleccionado ya fue ingresado.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarTextos();

                        TxtIdMateria.Focus();
                        return;
                    }
                }
            }
            if (e.KeyChar == (int)Keys.Escape)
            {
                LimpiarTextos();
                TxtCantidad.Enabled = false;
                TxtIdMateria.Focus();
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
        private void TxtIdMateria_KeyPress(object sender, KeyPressEventArgs e)
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
                if (TxtIdMateria.Text == "")
                {
                    FormBuscarMaterias form = new FormBuscarMaterias();
                    AddOwnedForm(form);
                    form.ShowDialog();

                    TxtPrecio.Text = Precio.ToString("0,0");
                    TxtCantidad.Enabled = true;
                    TxtCantidad.Focus();
                }
                else
                {
                    OleDbCommand cm = new OleDbCommand($"SELECT Descripcion, Stock, Precio FROM Materias WHERE IdMateria = {TxtIdMateria.Text}", con);
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
                TxtIdMateria.Focus();
            }

            decimal Suma = Grilla.Rows.OfType<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[4].Value));
            Total = Suma;
            TxtTotal.Text = String.Format("{0:0,0}", Suma);
        }
        #endregion


    }
}
