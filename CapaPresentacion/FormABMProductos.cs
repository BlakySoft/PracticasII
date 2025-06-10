using CapaDatos;
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

namespace CapaPresentacion
{
    public partial class FormABMProductos: Form
    {
        #region Metodos y declaraciones
        Boolean nuevo;
        int VarCat;
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
            LimpiarTextos();
            ListarProducto();
        }
        public void ListarProducto() 
        {
            ConeProductos listar = new ConeProductos();
            Grilla.DataSource = listar.Listar();
            Grilla.Columns[0].HeaderText = "Codigo";
            Grilla.Columns[0].Width = 70;
            Grilla.Columns[1].Width = 140;
            Grilla.Columns[2].Width = 100;
            Grilla.Columns[3].Width = 60;
            Grilla.Columns[4].Width = 60;
            Grilla.Columns[5].Width = 60;
            Grilla.Columns[1].HeaderText = "Descripcion";
            Grilla.Columns[2].HeaderText = "Detalle";
            Grilla.Columns[3].HeaderText = "Categoria";
            Grilla.Columns[4].HeaderText = "Precio";
            Grilla.Columns[5].HeaderText = "Stock";
            Grilla.Columns[6].Visible = false;

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

            CargarCbo();
            LimpiarTextos();
            TxtDescripcion.Focus();
        }
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtDescripcion.Text == "")
                {
                    MessageBox.Show("Ingrese la Descripción.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtDescripcion.Focus();
                }
                else if (TxtDetalle.Text == "")
                {
                    MessageBox.Show("Ingrese el detalle del producto.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtDetalle.Focus();
                }
                else if (TxtStock.Text == "")
                {
                    MessageBox.Show("Ingrese el Stock.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtStock.Focus();
                }
                else if (TxtPrecio.Text == "")
                {
                    MessageBox.Show("Ingrese el Precio.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtPrecio.Focus();
                }
                else if (nuevo == true)
                {

                    ConeProductos cone = new ConeProductos();
                    Productos Agregar = new Productos
                    {
                        Descripcion = TxtDescripcion.Text,
                        Detalle = TxtDetalle.Text,
                        IdCat = VarCat,     
                        Precio = Convert.ToDecimal(TxtPrecio.Text),
                         Stock = int.Parse(TxtStock.Text),
                    };

                    cone.Agregar(Agregar);

                    #region Enabled yes/no
                    //true
                    Grilla.Enabled = true;
                    BtnNuevo.Enabled = true;
                    //false
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;
                    PanelDatos.Enabled = false;
                    #endregion

                    LimpiarTextos();
                    ListarProducto();
                    BtnNuevo.Focus();
                }
                else
                {
                    ConeProductos cone = new ConeProductos();
                    Productos Actualizar = new Productos
                    {
                        IdProducto = int.Parse(LblIdProducto.Text),
                        Descripcion = TxtDescripcion.Text,
                        Detalle = TxtDetalle.Text,
                        IdCat = VarCat,
                        Stock = int.Parse(TxtStock.Text),
                        Precio = Convert.ToDecimal(TxtPrecio.Text)
                    };

                    cone.Actualizar(Actualizar);

                    #region Enabled yes/no
                    //true 
                    Grilla.Enabled = true;
                    BtnNuevo.Enabled = true;
                    //false
                    PanelDatos.Enabled = false;
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;
                    #endregion

                    LimpiarTextos();
                    ListarProducto();
                    BtnNuevo.Focus();
                }
            }
            finally
            {
                //#region Enabled yes/no
                ////true 
                //TxtBuscar.Enabled = true;
                //Grilla.Enabled = true;
                //BtnNuevo.Enabled = true;
                ////false
                //PanelDatos.Enabled = false;
                //BtnGrabar.Enabled = false;
                //BtnCancelar.Enabled = false;
                //BtnEliminar.Enabled = false;
                //#endregion

                //LimpiarTextos();
                //ListarProducto();
                //BtnNuevo.Focus();
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
            CargarCbo();

            CboIdCat.SelectedValue = VarCat;
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
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ListarProducto();
            CargarCbo();
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
            VarCat = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[3].Value.ToString());
            TxtPrecio.Text = Grilla.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtStock.Text = Grilla.Rows[e.RowIndex].Cells[5].Value.ToString();

            ConeCategoria cone = new ConeCategoria();

            _ = new Categoria
            {
                IdCat = VarCat
            };

            CboIdCat.ValueMember = "IdCat";
            CboIdCat.DisplayMember = "Descripcion";
            CboIdCat.DataSource = cone.BuscarIdCat(VarCat);

            #region Enabled yes/no

            BtnCancelar.Enabled = true;
            BtnEliminar.Enabled = true;
            BtnModificar.Enabled = true;
            #endregion
        }
        private void Grilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LblIdProducto.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtDescripcion.Text = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtDetalle.Text = Grilla.Rows[e.RowIndex].Cells[2].Value.ToString();
                VarCat = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[3].Value.ToString());
                TxtPrecio.Text = Grilla.Rows[e.RowIndex].Cells[4].Value.ToString();
                TxtStock.Text = Grilla.Rows[e.RowIndex].Cells[5].Value.ToString();

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
        #endregion

        #region Informe
        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Landscape = false;
            printDoc.PrintPage += new PrintPageEventHandler(Imprimir_PrintPage);
            printDoc.Print();
        }
        private void Imprimir_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fuenteTitulo = new Font("Arial", 12, FontStyle.Bold);
            Font fuenteDetalle = new Font("Arial", 10);

            int margenIzquierdo = 40;
            int margenSuperior = 40;
            int espacioEntreLineas = 20;

            e.Graphics.DrawString("Informe de Productos", fuenteTitulo, Brushes.Black, margenIzquierdo, margenSuperior);
            int lineaY = margenSuperior + 30;
            e.Graphics.DrawLine(Pens.Black, margenIzquierdo, lineaY, 770, lineaY);

      
            e.Graphics.DrawString("Código", fuenteTitulo, Brushes.Black, margenIzquierdo, lineaY + espacioEntreLineas);
            e.Graphics.DrawString("Descripción", fuenteTitulo, Brushes.Black, margenIzquierdo + 80, lineaY + espacioEntreLineas);
            e.Graphics.DrawString("Precio", fuenteTitulo, Brushes.Black, margenIzquierdo + 300, lineaY + espacioEntreLineas);
            e.Graphics.DrawString("Stock", fuenteTitulo, Brushes.Black, margenIzquierdo + 450, lineaY + espacioEntreLineas);
            e.Graphics.DrawString("Stock Valorizado", fuenteTitulo, Brushes.Black, margenIzquierdo + 540, lineaY + espacioEntreLineas);

 
            lineaY += espacioEntreLineas + 20;

   
            ConeProductos listar = new ConeProductos();
            List<Productos> productos = listar.Listar();

            decimal stockValorizadoTotal = 0;

      
            foreach (var prod in productos)
            {
                e.Graphics.DrawString(prod.IdProducto.ToString(), fuenteDetalle, Brushes.Black, margenIzquierdo, lineaY);
                e.Graphics.DrawString(prod.Descripcion, fuenteDetalle, Brushes.Black, margenIzquierdo + 80, lineaY);
                e.Graphics.DrawString(prod.Precio.ToString("C"), fuenteDetalle, Brushes.Black, margenIzquierdo + 300, lineaY); // Formateamos el precio como moneda
                e.Graphics.DrawString(prod.Stock.ToString(), fuenteDetalle, Brushes.Black, margenIzquierdo + 450, lineaY);
                e.Graphics.DrawString((prod.Precio * prod.Stock).ToString("C"), fuenteDetalle, Brushes.Black, margenIzquierdo + 540, lineaY); // Stock valorizado

                stockValorizadoTotal += prod.Precio * prod.Stock;

                lineaY += espacioEntreLineas;
            }
            e.Graphics.DrawLine(Pens.Black, margenIzquierdo, lineaY, 770, lineaY);
            lineaY += 10; 
            e.Graphics.DrawString("Stock Valorizado Total:", fuenteTitulo, Brushes.Black, margenIzquierdo, lineaY);
            e.Graphics.DrawString(stockValorizadoTotal.ToString("C"), fuenteTitulo, Brushes.Black, margenIzquierdo + 540, lineaY);

    
            lineaY += espacioEntreLineas;

            if (lineaY > e.MarginBounds.Height)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }
        #endregion

    }
}
