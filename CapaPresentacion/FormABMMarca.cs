using CapaDatos;
using CapaNegocio;
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
    public partial class FormABMMarca: Form
    {
        #region Metodos
        Boolean nuevo;
        public FormABMMarca()
        {
            InitializeComponent();
            BtnModificar.Enabled = false;
            TxtDescripcion.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;

            LimpiarTextos();
            Listar();
        }
        private void LimpiarTextos()
        {
            LblIdMarca.Text = "";
            TxtDescripcion.Clear();
        }
        private void Listar()
        {
            ConeMarca cone = new ConeMarca();
            Grilla.DataSource = cone.ListarMarca();
            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Marcas";
            Grilla.Columns[2].Visible = false;
        }
        #endregion

        #region Botones
        private void iconButton1_Click(object sender, EventArgs e)
        {
            TxtBuscar.Clear();
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            #region Enabled yes/no
            //true
            nuevo = true;
            TxtDescripcion.Enabled = true;
            BtnGrabar.Enabled = true;
            BtnCancelar.Enabled = true;
            //false
            TxtBuscar.Enabled = false;
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
                    MessageBox.Show("Ingrese la Marca", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (nuevo == true)
                {
                    ConeMarca cone = new ConeMarca();
                    Marca Agregar = new Marca
                    {
                        Descripcion = TxtDescripcion.Text
                    };

                    cone.Agregar(Agregar);

                    #region Enabled yes/no 
                    BtnNuevo.Enabled = true;
                    TxtDescripcion.Enabled = false;
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;
                    #endregion

                    LimpiarTextos();
                    Listar();
                    BtnNuevo.Focus();
                }
                else
                {
                    ConeMarca cone = new ConeMarca();
                    Marca Actualizar = new Marca
                    {
                        IdMarca = int.Parse(LblIdMarca.Text),
                        Descripcion = TxtDescripcion.Text
                    };

                    cone.Actualizar(Actualizar);

                    #region Enabled yes/no
                    TxtDescripcion.Enabled = false;
                    BtnNuevo.Enabled = true;
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;
                    #endregion

                    LimpiarTextos();
                    Listar();
                    BtnNuevo.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                #region Enabled yes/no
                TxtBuscar.Enabled = true;
                BtnNuevo.Enabled = true;
                BtnGrabar.Enabled = false;
                BtnCancelar.Enabled = false;
                BtnEliminar.Enabled = false;
                TxtDescripcion.Enabled = false;
                #endregion

                LimpiarTextos();
                Listar();
                BtnNuevo.Focus();
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            #region Enabled yes/no
            TxtBuscar.Enabled = true;
            BtnNuevo.Enabled = true;
            BtnModificar.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;
            TxtDescripcion.Enabled = false;
            #endregion

            Listar();
            BtnNuevo.Focus();
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {

            #region Enabled yes/no
            PnlBarraLateral.Enabled = true;
            BtnGrabar.Enabled = true;
            Grilla.Enabled = false;
            BtnNuevo.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnModificar.Enabled = false;
            #endregion
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ConeMarca cone = new ConeMarca();
            Marca Eliminar = new Marca
            {
                IdMarca = int.Parse(LblIdMarca.Text)
            };

            cone.Borrar(Eliminar);

            try
            {
                MessageBox.Show("La Marca se eliminó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            BtnNuevo.Focus();
            #endregion
        }
        private void BtnPapelera_Click(object sender, EventArgs e)
        {
            using (FormPAPELERAMarca form = new FormPAPELERAMarca())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Listar();
                }
            }

        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Interacciones con el formulario
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblIdMarca.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDescripcion.Text = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();

            #region Enabled yes/no
            nuevo = false;
            BtnNuevo.Enabled = false;
            TxtDescripcion.Enabled = true;
            BtnGrabar.Enabled = true;
            BtnCancelar.Enabled = true;
            BtnEliminar.Enabled = true;
            BtnModificar.Enabled = true;
            #endregion

            TxtDescripcion.Focus();
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {

            if (TxtBuscar.Text == "")
            {
                Listar();
            }
            else
            {
                ConeMarca cone = new ConeMarca();
                Marca Buscar = new Marca
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarMarca(Buscar.Descripcion);

            }
        }


        #endregion

      
    }
}
