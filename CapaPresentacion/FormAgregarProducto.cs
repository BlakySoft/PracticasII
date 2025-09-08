using CapaDatos;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormAgregarProducto: Form
    {

        #region Metodos y declaraciones
        Boolean nuevo;
        int VarCat;
        int VarMar;
        int VarCol;
        public FormAgregarProducto()
        {
            InitializeComponent();
            PanelDatos.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;

            CargarCbo();
            LimpiarTextos();
        }
        private void CargarCbo()
        {
            ConeCategoria cone = new ConeCategoria();

            CboIdCat.ValueMember = "IdCat";
            CboIdCat.DisplayMember = "Descripcion";
            CboIdCat.DataSource = cone.ListarCat();
        }
        private void LimpiarTextos()
        {
            LblIdProducto.Text = "";
            TxtDescripcion.Clear();
            TxtStock.Clear();
            TxtPrecioCompra.Clear();
            TxtDetalle.Clear();
        }
        #endregion

        #region Botones
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;

            #region Enabled yes/no 
            //true
            BtnGrabar.Enabled = true;
            BtnCancelar.Enabled = true;
            PanelDatos.Enabled = true;
            //false
            BtnNuevo.Enabled = false;
            #endregion

            CargarCbo();
            LimpiarTextos();
            TxtDescripcion.Focus();
        }
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(TxtDescripcion.Text))
                {
                    MessageBox.Show("Ingrese la Descripción.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtDescripcion.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(TxtDetalle.Text))
                {
                    MessageBox.Show("Ingrese el detalle del producto.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtDetalle.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(TxtStock.Text))
                {
                    MessageBox.Show("Ingrese el Stock.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtStock.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(TxtPrecioCompra.Text))
                {
                    MessageBox.Show("Ingrese el Precio de Compra.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtPrecioCompra.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(TxtPrecioVenta.Text))
                {
                    MessageBox.Show("Ingrese el Precio de Venta.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtPrecioVenta.Focus();
                    return;
                }
                if (CboIdCat.SelectedValue == null || !int.TryParse(CboIdCat.SelectedValue.ToString(), out VarCat) || VarCat <= 0)
                {
                    MessageBox.Show("Seleccione una Categoría.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (CboIdMar.SelectedValue == null || !int.TryParse(CboIdMar.SelectedValue.ToString(), out VarMar) || VarMar <= 0)
                {
                    MessageBox.Show("Seleccione una Marca.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (CboIdCol.SelectedValue == null || !int.TryParse(CboIdCol.SelectedValue.ToString(), out VarCol) || VarCol <= 0)
                {
                    MessageBox.Show("Seleccione un Color.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                decimal precioCompra = Convert.ToDecimal(TxtPrecioCompra.Text);
                decimal precioVenta = Convert.ToDecimal(TxtPrecioVenta.Text);

                if (precioCompra > precioVenta)
                {
                    MessageBox.Show("El Precio de Compra no puede ser mayor que el Precio de Venta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtPrecioVenta.Focus();
                    return;
                }

                Productos producto = new Productos
                {
                    Descripcion = TxtDescripcion.Text.Trim(),
                    Detalle = TxtDetalle.Text.Trim(),
                    IdCat = VarCat,
                    IdMarca = VarMar,
                    IdColor = VarCol,
                    PrecioCompra = precioCompra,
                    PrecioVenta = precioVenta,
                    Stock = int.Parse(TxtStock.Text),
                };

                ConeProductos cone = new ConeProductos();

                if (nuevo)
                {
                    if (MessageBox.Show("¿Está seguro de agregar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cone.Agregar(producto);
                        MessageBox.Show("Producto agregado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else return;
                }
                else
                {
                    LimpiarTextos();
                    CboIdCat.SelectedIndex = -1;
                    CboIdMar.SelectedIndex = -1;
                    CboIdCol.SelectedIndex = -1;
                    VarCat = 0; VarMar = 0; VarCol = 0;


                    PanelDatos.Enabled = false;
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;
                    BtnNuevo.Enabled = true;
                    BtnNuevo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar el producto.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            #region Enabled yes/no
            //true 
            BtnNuevo.Enabled = true;
            //false
            PanelDatos.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            #endregion

            CargarCbo();
            BtnNuevo.Focus();
        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnCat_Click(object sender, EventArgs e)
        {
            FormABMCategoria form = new FormABMCategoria();
            form.ShowDialog();
            CargarCbo();
        }
        private void CboIdCat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VarCat = int.Parse(CboIdCat.SelectedValue.ToString());
        }

        #endregion

        #region Validadores
        private void TxtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                TxtDetalle.Focus();
            }
        }
        private void TxtDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                CboIdCat.Focus();
            }
        }
        private void CboIdCat_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // evita el sonido de Windows

                if (CboIdCat.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar una Categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CboIdCat.Focus();
                    return;
                }

                SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void CboIdMar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                if (CboIdMar.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar una Marca.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CboIdMar.Focus();
                    return;
                }

                SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void CboIdCol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                if (CboIdCol.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un Color.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CboIdCol.Focus();
                    return;
                }

                SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void TxtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                TxtPrecioVenta.Focus();
            }
        }
        private void TxtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                TxtStock.Focus();
            }
        }
        private void TxtStock_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && TxtPrecioCompra.Text.Contains("."))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnGrabar.Focus();
            }
        }
        #endregion
    }
}
