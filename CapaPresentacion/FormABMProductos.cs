using CapaDatos;
using CapaNegocio;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace CapaPresentacion
{
    public partial class FormABMProductos : Form
    {
        #region Metodos y declaraciones
        Boolean nuevo;
        int VarCat;
        int VarMar;
        int VarCol;
        public FormABMProductos()
        {
            InitializeComponent();

            BtnModificar.Enabled = false;
            PanelDatos.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;
            TxtBuscar.Enabled = true;
            CargarCbo();
            CargarCbo1();
            CargarCbo2();
            LimpiarTextos();
            ListarProducto();

        }
        public void ListarProducto()
        {
            ConeProductos listar = new ConeProductos();
            Grilla.DataSource = listar.ListarINNERJOIN();
            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[3].Visible = false;
            Grilla.Columns[4].Visible = false;
            Grilla.Columns[5].Visible = false;
            Grilla.Columns[11].Visible = false;

            Grilla.Columns[0].Width = 83;
            Grilla.Columns[1].Width = 140;
            Grilla.Columns[2].Width = 110;
            Grilla.Columns[6].Width = 110;
            Grilla.Columns[7].Width = 110;
            Grilla.Columns[8].Width = 130;
        }
        private void CargarCbo2()
        {
            ConeColores cone = new ConeColores();

            CboIdCol.ValueMember = "IdColor";
            CboIdCol.DisplayMember = "Descripcion";
            CboIdCol.DataSource = cone.ListarColor();
        }
        private void CargarCbo1()
        {
            ConeMarca cone = new ConeMarca();

            CboIdMar.ValueMember = "IdMarca";
            CboIdMar.DisplayMember = "Descripcion";
            CboIdMar.DataSource = cone.ListarMarca();
        }
        private void CargarCbo()
        {
            ConeCategoria cone = new ConeCategoria ();

            CboIdCat.ValueMember = "IdCat";
            CboIdCat.DisplayMember = "Descripcion";
            CboIdCat.DataSource = cone.ListarCat();
        }
        private void LimpiarTextos()
        {
            LblIdProducto.Text = "";
            TxtDescripcion.Clear();
            TxtStock.Clear();
            TxtPrecio.Clear();
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
            BtnEliminar.Enabled = false;
            TxtBuscar.Enabled = false;
            Grilla.Enabled = false;
            BtnNuevo.Enabled = false;
            BtnPapelera.Enabled = false;
            #endregion
            CboIdCat.SelectedIndex = -1;
            CboIdMar.SelectedIndex = -1;
            CboIdCol.SelectedIndex = -1;
            LimpiarTextos();
            TxtDescripcion.Focus();
        }
        private void BtnGrabar_Click(object sender, EventArgs e)
        { 
            try
            {
                // Validar campos obligatorios
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
                if (string.IsNullOrWhiteSpace(TxtPrecio.Text))
                {
                    MessageBox.Show("Ingrese el Precio.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtPrecio.Focus();
                    return;
                }

                // Tomar valores actuales de los combos
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

                // Crear objeto producto
                Productos producto = new Productos
                {
                    Descripcion = TxtDescripcion.Text.Trim(),
                    Detalle = TxtDetalle.Text.Trim(),
                    IdCat = VarCat,
                    IdMarca = VarMar,
                    IdColor = VarCol,
                    Stock = int.Parse(TxtStock.Text),
                    Precio = Convert.ToDecimal(TxtPrecio.Text)
                };

                ConeProductos cone = new ConeProductos();

                if (nuevo)
                {
                    // Confirmación
                    if (MessageBox.Show("¿Está seguro de agregar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cone.Agregar(producto);
                        MessageBox.Show("Producto agregado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else return;
                }
                else
                {
                    // Actualizar producto existente
                    producto.IdProducto = int.Parse(LblIdProducto.Text);

                    if (MessageBox.Show("¿Está seguro de actualizar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cone.Actualizar(producto);
                        MessageBox.Show("Producto actualizado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else return;
                }

                // Refrescar grilla y limpiar formulario
                ListarProducto();
                LimpiarTextos();
                CboIdCat.SelectedIndex = -1;
                CboIdMar.SelectedIndex = -1;
                CboIdCol.SelectedIndex = -1;
                VarCat = 0; VarMar = 0; VarCol = 0;

                // Habilitar/deshabilitar botones
                PanelDatos.Enabled = false;
                BtnGrabar.Enabled = false;
                BtnCancelar.Enabled = false;
                BtnNuevo.Enabled = true;
                Grilla.Enabled = true;
                BtnEliminar.Enabled = false;
                TxtBuscar.Enabled = true;
                BtnNuevo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar el producto.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ConeProductos cone = new ConeProductos();
            Productos Borrar = new Productos
            {
                IdProducto = int.Parse(LblIdProducto.Text)
            };

            cone.Borrar(Borrar);

            try
            {
                MessageBox.Show("El Producto se eliminó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarTextos();
                ListarProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.ToString()}");
                throw;
            }

            #region Enabled yes/no 
            //true 
            BtnNuevo.Enabled = true;
            //false
            BtnModificar.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;
            #endregion

            BtnNuevo.Focus();
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            nuevo = false;

            #region Enabled yes/no 
            //true
            PanelDatos.Enabled = true;
            BtnGrabar.Enabled = true;
            BtnCancelar.Enabled = true;

            //false
            Grilla.Enabled = false;
            BtnNuevo.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnModificar.Enabled = false;
            #endregion

        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            #region Enabled yes/no
            //true 
            TxtBuscar.Enabled = true;
            Grilla.Enabled = true;
            BtnNuevo.Enabled = true;
            BtnPapelera.Enabled = true;
            //false
            PanelDatos.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;
            #endregion

            LimpiarTextos();

            CargarCbo();
            CargarCbo1();
            CargarCbo2();

            ListarProducto();
            BtnNuevo.Focus();
        }
        private void BtnPapelera_Click(object sender, EventArgs e)
        {
            using (FormPAPELERAProductos form = new FormPAPELERAProductos())
            {

                if(form.ShowDialog() == DialogResult.OK)
                {
                    ListarProducto();
                }

            };
         
        }
        private void BtnCat_Click(object sender, EventArgs e)
        {
            FormABMCategoria form = new FormABMCategoria();
            form.ShowDialog();
            CargarCbo();

        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnMar_Click(object sender, EventArgs e)
        {
            FormABMMarca form = new FormABMMarca();
            form.ShowDialog();
            CargarCbo1();


        }
        private void btnCol_Click(object sender, EventArgs e)
        {

            FormABMColor form = new FormABMColor();
            form.ShowDialog();;
            CargarCbo2();



        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            TxtBuscar.Clear();
        }
        #endregion

        #region Interaccion con Formulario

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text != "")
            {
                ConeProductos cone = new ConeProductos();
                Productos Buscar = new Productos
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.Buscar(Buscar.Descripcion);

            }
            else
            {
                ListarProducto();
            }
        }
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            LblIdProducto.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDescripcion.Text = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtDetalle.Text = Grilla.Rows[e.RowIndex].Cells[2].Value.ToString();
            VarCat = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[3].Value);
            VarMar = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[4].Value);
            VarCol = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[5].Value);
            TxtPrecio.Text = Grilla.Rows[e.RowIndex].Cells[9].Value.ToString();
            TxtStock.Text = Grilla.Rows[e.RowIndex].Cells[10].Value.ToString();

            // **Asignar valores a combos sin recargar DataSource**
            CboIdCat.SelectedValue = VarCat;
            CboIdMar.SelectedValue = VarMar;
            CboIdCol.SelectedValue = VarCol;

            // Habilitar botones
            BtnCancelar.Enabled = true;
            BtnEliminar.Enabled = true;
            BtnModificar.Enabled = true;
        }
        private void Grilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                LblIdProducto.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtDescripcion.Text = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtDetalle.Text = Grilla.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtPrecio.Text = Grilla.Rows[e.RowIndex].Cells[6].Value.ToString();
                TxtStock.Text = Grilla.Rows[e.RowIndex].Cells[7].Value.ToString();

                // IDs
                VarCat = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[3].Value);
                VarMar = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[4].Value);
                VarCol = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[5].Value);

                nuevo = false;

                #region Enables yes/no
                //true
                BtnGrabar.Enabled = true;
                BtnCancelar.Enabled = true;
                PanelDatos.Enabled = true;
                //false
                BtnEliminar.Enabled = false;
                Grilla.Enabled = false;
                BtnNuevo.Enabled = false;
                #endregion 

                CargarCbo();
                CargarCbo1();
                CargarCbo2();
                TxtDescripcion.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Imposible seleccionar desde la cabecera.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void CboIdCat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VarCat = int.Parse(CboIdCat.SelectedValue.ToString());
        }
        private void CboIdMar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VarMar = int.Parse(CboIdMar.SelectedValue.ToString());
        }
        private void CboIdCol_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VarCol = int.Parse(CboIdCol.SelectedValue.ToString());
        }
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
                TxtDetalle.Focus();
            }
        }
        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                TxtPrecio.Focus();
            }
        }
        private void TxtStock_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && TxtPrecio.Text.Contains("."))
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





