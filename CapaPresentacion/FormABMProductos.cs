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
        Timer scanTimer;
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
            Grilla.Columns[0].HeaderText = "ID";
            Grilla.Columns[1].HeaderText = "Código de Barras";
            Grilla.Columns[2].HeaderText = "Descripcion";
            Grilla.Columns[3].HeaderText = "Detalle";
            Grilla.Columns[7].HeaderText = "Categoria";
            Grilla.Columns[8].HeaderText = "Marca";
            Grilla.Columns[9].HeaderText = "Color";
            Grilla.Columns[10].HeaderText = "Precio Compra";
            Grilla.Columns[11].HeaderText = "Precio Venta";
            Grilla.Columns[12].HeaderText = "Stock";

            Grilla.Columns[0].Visible = false;
            Grilla.Columns[1].Visible = false;
            Grilla.Columns[4].Visible = false;
            Grilla.Columns[5].Visible = false;
            Grilla.Columns[6].Visible = false;
            Grilla.Columns[13].Visible = false;
            Grilla.Columns[1].Width = 175;
            Grilla.Columns[2].Width = 190;
            Grilla.Columns[3].Width = 85;
            Grilla.Columns[4].Width = 0;
            Grilla.Columns[5].Width = 0;
            Grilla.Columns[6].Width = 110;
            Grilla.Columns[7].Width = 100;
            Grilla.Columns[8].Width = 80;
            Grilla.Columns[9].Width = 85;
            Grilla.Columns[10].Width = 85;
            Grilla.Columns[11].Width = 65;
            Grilla.Columns[12].Width = 65;
        }
        
        private void CargarCbo2()
        {
            ConeColores cone = new ConeColores(); //Colores

            CboIdCol.ValueMember = "IdColor";
            CboIdCol.DisplayMember = "Descripcion";
            CboIdCol.DataSource = cone.ListarColor();
            CboIdCol.SelectedIndex = -1;
        }
        private void CargarCbo1() //Marcas
        {
            ConeMarca cone = new ConeMarca();

            CboIdMar.ValueMember = "IdMarca";
            CboIdMar.DisplayMember = "Descripcion";
            CboIdMar.DataSource = cone.ListarMarca();
            CboIdMar.SelectedIndex = -1;
        }
        private void CargarCbo() //Categorias
        {
            ConeCategoria cone = new ConeCategoria ();

            CboIdCat.ValueMember = "IdCat";
            CboIdCat.DisplayMember = "Descripcion";
            CboIdCat.DataSource = cone.ListarCat();
            CboIdCat.SelectedIndex = -1;
        }
        private void LimpiarTextos()
        {
            LblIdProducto.Text = "";
            TxtBarCode.Clear();
            TxtDescripcion.Clear();
            TxtStock.Clear();
            TxtPrecioCompra.Clear();
            TxtPrecioVenta.Clear();
            TxtDetalle.Clear();
        }
        #endregion

        #region Botones
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;
            this.Tag = "process";

            #region Enabled yes/no 
            //true
            BtnGrabar.Enabled = true;
            BtnCancelar.Enabled = true;
            PanelDatos.Enabled = true;
            //false
            BtnEliminar.Enabled = false;
            BtnPapelera.Enabled = false;
            BtnModificar.Enabled = false;
            TxtBuscar.Enabled = false;
            Grilla.Enabled = false;
            BtnNuevo.Enabled = false;
            BtnPapelera.Enabled = false;
            #endregion
            CboIdCat.SelectedIndex = -1;
            CboIdMar.SelectedIndex = -1;
            CboIdCol.SelectedIndex = -1;
            LimpiarTextos();
            TxtBarCode.Focus();
        }
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(TxtBarCode.Text))
                {
                    MessageBox.Show("Ingrese el Código de Barras.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtBarCode.Focus();
                    return;
                }
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
                    BarCode = Int64.Parse(TxtBarCode.Text),
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
                    producto.IdProducto = int.Parse(LblIdProducto.Text);

                    if (MessageBox.Show("¿Está seguro de actualizar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cone.Actualizar(producto);
                        MessageBox.Show("Producto actualizado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else return;
                }

                this.Tag = "none";
                ListarProducto();
                LimpiarTextos();
                CboIdCat.SelectedIndex = -1;
                CboIdMar.SelectedIndex = -1;
                CboIdCol.SelectedIndex = -1;
                VarCat = 0; VarMar = 0; VarCol = 0;

 
                PanelDatos.Enabled = false;
                BtnGrabar.Enabled = false;
                BtnCancelar.Enabled = false;
                BtnNuevo.Enabled = true;
                Grilla.Enabled = true;
                BtnEliminar.Enabled = false;
                TxtBuscar.Enabled = true;
                BtnPapelera.Enabled = true;
                BtnNuevo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar el producto.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Pregunta de confirmación
            DialogResult result = MessageBox.Show(
                "¿Está seguro de eliminar este cliente?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question

            );

            if (result == DialogResult.Yes)
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
            }else return;


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
            this.Tag = "process";
            #region Enabled yes/no 
            //true
            PanelDatos.Enabled = true;
            BtnGrabar.Enabled = true;
            BtnCancelar.Enabled = true;

            //false
            Grilla.Enabled = false;
            BtnNuevo.Enabled = false;
            BtnPapelera.Enabled = false;
            BtnPapelera.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnModificar.Enabled = false;
            #endregion
            TxtDescripcion.Focus();

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
            this.Tag = "none";
            LimpiarTextos();

            CargarCbo();
            CargarCbo1();
            CargarCbo2();
           
            BtnNuevo.Focus();

            scanTimer = new Timer();
            scanTimer.Interval = 3000;
            scanTimer.Start();
            scanTimer.Tick += (s, args) =>
            {
                Grilla.Focus();
                scanTimer.Stop();
            };


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
        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                iconButton1.PerformClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                Grilla.Focus();
            }
        }
        private void Grilla_KeyDown(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.Handled = false; 

                BtnModificar.Enabled = true;
                BtnEliminar.Enabled = true;

            }
            else if (e.KeyCode == Keys.Enter)
            {
                BtnModificar.PerformClick(); 
                e.Handled = true; 
            }
            else if(e.KeyCode == Keys.Delete)
            {
                BtnEliminar.PerformClick(); 
            }
            else
            {
                e.Handled = true; 
            }
        }
        private void FormABMProductos_Load(object sender, EventArgs e)
        {
            Grilla.CellFormatting += Grilla_CellFormatting;

            Grilla.Focus();
        }
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
            try
            {
                if (e.RowIndex < 0) return; 

                LblIdProducto.Text = Grilla.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                TxtBarCode.Text = Grilla.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                TxtDescripcion.Text = Grilla.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";
                TxtDetalle.Text = Grilla.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? "";
                VarCat = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[4].Value);
                VarMar = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[5].Value);
                VarCol = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[6].Value);
                TxtPrecioCompra.Text = Grilla.Rows[e.RowIndex].Cells[10].Value?.ToString() ?? "";
                TxtPrecioVenta.Text = Grilla.Rows[e.RowIndex].Cells[11].Value?.ToString() ?? "";
                TxtStock.Text = Grilla.Rows[e.RowIndex].Cells[12].Value?.ToString() ?? "";


                CboIdCat.SelectedValue = VarCat;
                CboIdMar.SelectedValue = VarMar;
                CboIdCol.SelectedValue = VarCol;


                BtnCancelar.Enabled = true;
                BtnEliminar.Enabled = true;
                BtnModificar.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al seleccionar la fila: " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Grilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                LblIdProducto.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtBarCode.Text = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtDescripcion.Text = Grilla.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtDetalle.Text = Grilla.Rows[e.RowIndex].Cells[3].Value.ToString();
                TxtPrecioCompra.Text = Grilla.Rows[e.RowIndex].Cells[7].Value.ToString();
                TxtPrecioVenta.Text = Grilla.Rows[e.RowIndex].Cells[8].Value.ToString();
                TxtStock.Text = Grilla.Rows[e.RowIndex].Cells[9].Value.ToString();

                // IDs
                VarCat = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[4].Value);
                VarMar = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[5].Value);
                VarCol = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[6].Value);

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
            try
            {
                VarCat = int.Parse(CboIdCat.SelectedValue.ToString());
            }
            catch(Exception)
            {

            }

        }
        private void CboIdMar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                VarMar = int.Parse(CboIdMar.SelectedValue.ToString());
            }
            catch(Exception) { }
        
        }
        private void CboIdCol_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                VarCol = int.Parse(CboIdCol.SelectedValue.ToString());
            } catch(Exception) { }
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
                e.Handled = true;
                TxtDetalle.Focus();
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                BtnCancelar.PerformClick();
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
                e.Handled = true;
                CboIdCat.Focus();
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                BtnCancelar.PerformClick();
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

            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                BtnCancelar.PerformClick();
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

            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                BtnCancelar.PerformClick();
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
            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                BtnCancelar.PerformClick();
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
                e.Handled = true;
                TxtPrecioVenta.Focus();
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                BtnCancelar.PerformClick();
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
                e.Handled = true;   
                TxtStock.Focus();
            }

            if (e.KeyChar == (char)Keys.Escape)
            { 
                e.Handled = true;
                BtnCancelar.PerformClick();
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
                e.Handled = true;
                BtnGrabar.Focus(); 
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                BtnCancelar.PerformClick();
            }
        }

        private void Grilla_SelectionChanged(object sender, EventArgs e)
        {
            if (Grilla.CurrentCell != null)
            {
                var rowIndex = Grilla.CurrentCell.RowIndex;

                LblIdProducto.Text = Grilla.Rows[rowIndex].Cells[0].Value?.ToString() ?? "";
                TxtBarCode.Text = Grilla.Rows[rowIndex].Cells[1].Value?.ToString() ?? "";
                TxtDescripcion.Text = Grilla.Rows[rowIndex].Cells[2].Value?.ToString() ?? "";
                TxtDetalle.Text = Grilla.Rows[rowIndex].Cells[3].Value?.ToString() ?? "";
                VarCat = Convert.ToInt32(Grilla.Rows[rowIndex].Cells[4].Value);
                VarMar = Convert.ToInt32(Grilla.Rows[rowIndex].Cells[5].Value);
                VarCol = Convert.ToInt32(Grilla.Rows[rowIndex].Cells[6].Value);
                TxtPrecioCompra.Text = Grilla.Rows[rowIndex].Cells[10].Value?.ToString() ?? "";
                TxtPrecioVenta.Text = Grilla.Rows[rowIndex].Cells[11].Value?.ToString() ?? "";
                TxtStock.Text = Grilla.Rows[rowIndex].Cells[12].Value?.ToString() ?? "";

                // Asignar valores a combos sin recargar DataSource
                CboIdCat.SelectedValue = VarCat;
                CboIdMar.SelectedValue = VarMar;
                CboIdCol.SelectedValue = VarCol;

            }
        }

        private void TxtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bool exist;
                ConeProductos vali = new ConeProductos();
                Productos bar = new Productos
                {
                    BarCode = Double.Parse(TxtBarCode.Text)
                };
                exist = vali.Validar(bar);

                if (exist == true)
                {
                    MessageBox.Show("El Código de Barras ya existe. Ingrese otro.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtBarCode.Clear();
                    TxtBarCode.Focus();
                    return;
                }
                TxtDescripcion.Focus();
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                BtnCancelar.PerformClick();
            }
        }
        #endregion

        #region Comportamiento visual
        private void Grilla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int limiteAlerta = Properties.Settings.Default.LimiteAlertaStock;

            if (Grilla.Columns[e.ColumnIndex].Name == "Stock")
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int stockActual))
                {
                    if (stockActual == 0)
                    {
                        Grilla.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Black;
                        Grilla.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (stockActual <= limiteAlerta)
                    {
                        Grilla.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                        Grilla.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        Grilla.Rows[e.RowIndex].DefaultCellStyle.BackColor = Grilla.DefaultCellStyle.BackColor;
                        Grilla.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Grilla.DefaultCellStyle.ForeColor;
                    }
                }
            }
        }

        #endregion

        private void iconButton3_Click(object sender, EventArgs e)
        {
            using (FormConfiguracion form = new FormConfiguracion())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ListarProducto();
                }
            }
        }
    }
}





