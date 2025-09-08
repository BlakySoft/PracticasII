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
    public partial class FormABMCategoria: Form
    {
        #region Metodos
        Boolean nuevo;
        public FormABMCategoria()
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
            LblIdCat.Text = "";
            TxtDescripcion.Clear();
        }
        private void Listar()
        {
            ConeCategoria cone = new ConeCategoria();
            Grilla.DataSource = cone.ListarCat();
            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Categoria";
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
                    MessageBox.Show("Ingrese el Categoria", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (nuevo == true)
                {
                    ConeCategoria cone = new ConeCategoria();
                    Categoria Agregar = new Categoria
                    {
                        Descripcion = TxtDescripcion.Text
                    };

                    cone.AgregarCat(Agregar);

                    #region Enabled yes/no 
                    //true
                    BtnNuevo.Enabled = true;
                    //false
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
                    ConeCategoria cone = new ConeCategoria();
                    Categoria Actualizar = new Categoria
                    {
                        IdCat = int.Parse(LblIdCat.Text),
                        Descripcion = TxtDescripcion.Text
                    };

                    cone.ActualizarCat(Actualizar);

                    TxtDescripcion.Enabled = false;
                    BtnNuevo.Enabled = true;
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;

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
                //true
                TxtBuscar.Enabled = true;
                BtnNuevo.Enabled = true;
                //false
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
            //true
            TxtBuscar.Enabled = true;
            BtnNuevo.Enabled = true;
            //false
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
            //true
            PnlBarraLateral.Enabled = true;
            BtnGrabar.Enabled = true;
            //false
            Grilla.Enabled = false;
            BtnNuevo.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnModificar.Enabled = false;
            #endregion

        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {

            ConeCategoria cone = new ConeCategoria();
            Categoria Eliminar = new Categoria
            {
                IdCat = int.Parse(LblIdCat.Text)
            };

            cone.BorrarCat(Eliminar);

            try
            {
                MessageBox.Show("La Categoria se eliminó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            using (FormPAPELERACategoria form = new FormPAPELERACategoria())
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

        #region Interacciones con formulario
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblIdCat.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDescripcion.Text = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();

            #region Enabled yes/no
            //false
            nuevo = false;
            BtnNuevo.Enabled = false;
            //true
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
                ConeCategoria cone = new ConeCategoria();
                Categoria Buscar = new Categoria
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarCat(Buscar.Descripcion);

            }
        }

        #endregion

      
    }
}
