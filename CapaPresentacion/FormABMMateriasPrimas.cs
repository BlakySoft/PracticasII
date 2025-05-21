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
    public partial class FormABMMateriasPrimas: Form
    {
        #region Metodos y declaraciones
        Boolean nuevo;
        public FormABMMateriasPrimas()
        {
            InitializeComponent();
            LimpiarTextos();
            Listar();
            BtnModificar.Enabled = false;
            PanelDatos.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;
            TxtBuscar.Enabled = true;
        }
        private void LimpiarTextos()
        {
            LblIdMateria.Text = "";
            TxtDescripcion.Clear();
            TxtDetalle.Clear();
            TxtPrecio.Clear();
            TxtStock.Clear();
        }
        private void Listar()
        {
            ConeMateria cone = new ConeMateria();
            Grilla.DataSource = cone.Listar();

            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Descripcion";
            Grilla.Columns[2].HeaderText = "Detalle";
            Grilla.Columns[3].HeaderText = "Precio";
            Grilla.Columns[4].HeaderText = "Stock";        
            Grilla.Columns[5].Visible = false;
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
            #endregion

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
                }
                else if (TxtDetalle.Text == "")
                {
                    MessageBox.Show("Ingrese el detalle de la Materia Prima.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (TxtStock.Text == "")
                {
                    MessageBox.Show("Ingrese el Stock.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (TxtPrecio.Text == "")
                {
                    MessageBox.Show("Ingrese el Precio.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (nuevo == true)
                {

                    ConeMateria cone = new ConeMateria();
                    Materia Agregar = new Materia
                    {
                        Descripcion = TxtDescripcion.Text,
                        Detalle = TxtDetalle.Text,
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
                    Listar();
                    BtnNuevo.Focus();
                }
                else
                {
                    ConeMateria cone = new ConeMateria();
                    Materia Actualizar = new Materia
                    {
                        IdMateria = int.Parse(LblIdMateria.Text),
                        Descripcion = TxtDescripcion.Text,
                        Detalle = TxtDetalle.Text,
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
                    Listar();
                    BtnNuevo.Focus();
                }
            }
            finally
            {
                #region Enabled yes/no
                //true 
                TxtBuscar.Enabled = true;
                Grilla.Enabled = true;
                BtnNuevo.Enabled = true;
                //false
                PanelDatos.Enabled = false;
                BtnGrabar.Enabled = false;
                BtnCancelar.Enabled = false;
                BtnEliminar.Enabled = false;
                #endregion

                LimpiarTextos();
                Listar();
                BtnNuevo.Focus();
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ConeMateria cone = new ConeMateria();
            Materia Borrar = new Materia
            {
                IdMateria = int.Parse(LblIdMateria.Text)
            };

            cone.Borrar(Borrar);

            try
            {
                MessageBox.Show("La materia prima se eliminó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarTextos();
                Listar();
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
            //false
            BtnModificar.Enabled = false;
            PanelDatos.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;
            #endregion
            LimpiarTextos();
            Listar();
            BtnNuevo.Focus();
        }
        private void BtnPapelera_Click(object sender, EventArgs e)
        {
            FormPAPELERAMateriaprima form = new FormPAPELERAMateriaprima();
            form.ShowDialog();
        }
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Interaccion con formulario
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text != "")
            {
                ConeMateria cone = new ConeMateria();
                Materia Buscar = new Materia
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.Buscar(Buscar.Descripcion);

            }
            else
            {
                Listar();
            }
        }
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblIdMateria.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDescripcion.Text = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtDetalle.Text = Grilla.Rows[e.RowIndex].Cells[2].Value.ToString();      
            TxtPrecio.Text = Grilla.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtStock.Text = Grilla.Rows[e.RowIndex].Cells[4].Value.ToString();

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

                LblIdMateria.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtDescripcion.Text = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtDetalle.Text = Grilla.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtPrecio.Text = Grilla.Rows[e.RowIndex].Cells[3].Value.ToString();
                TxtStock.Text = Grilla.Rows[e.RowIndex].Cells[4].Value.ToString();

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

                TxtDescripcion.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Imposible seleccionar desde la cabecera.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion
    }
}
