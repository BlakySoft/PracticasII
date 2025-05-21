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
    public partial class FormABMLocalidades: Form
    {
        #region Metodos y declaraciones
        Boolean nuevo;
        public FormABMLocalidades()
        {
            InitializeComponent();
            BtnModificar.Enabled = false;
            TxtDescripcion.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;

            LimpiarTextos();
            ListarLocalidades();
        }

        private void LimpiarTextos()
        {
            LblIdLocalidad.Text = "";
            TxtDescripcion.Clear();
        }
        private void ListarLocalidades()
        {
            ConeLocalidades cone = new ConeLocalidades();
            Grilla.DataSource = cone.ListarLocalidad();
            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 50;
            Grilla.Columns[1].Width = 150;
            Grilla.Columns[1].HeaderText = "Localidad";
            Grilla.Columns[2].Visible = false;

        }
        #endregion

        #region Botones
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ListarLocalidades();
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
                    MessageBox.Show("Ingrese la Descripción", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (nuevo == true)
                {
                    ConeLocalidades cone = new ConeLocalidades();
                    Localidad Agregar = new Localidad
                    {
                        Descripcion = TxtDescripcion.Text
                    };

                    cone.AgregarLocalidad(Agregar);

                    #region Enabled yes/no 
                    //true
                    BtnNuevo.Enabled = true;
                    //false
                    TxtDescripcion.Enabled = false;
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;
                    #endregion

                    LimpiarTextos();
                    ListarLocalidades();
                    BtnNuevo.Focus();
                }
                else
                {
                    ConeLocalidades cone = new ConeLocalidades();
                    Localidad Actualizar = new Localidad
                    {
                        IdLocalidad = int.Parse(LblIdLocalidad.Text),
                        Descripcion = TxtDescripcion.Text
                    };

                    cone.ActualizarLocalidad(Actualizar);

                    TxtDescripcion.Enabled = false;
                    BtnNuevo.Enabled = true;
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;

                    LimpiarTextos();
                    ListarLocalidades();
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
                ListarLocalidades();
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
            LimpiarTextos();
            ListarLocalidades();
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
            ConeLocalidades cone = new ConeLocalidades();
            Localidad Eliminar = new Localidad
            {
                IdLocalidad = int.Parse(LblIdLocalidad.Text)
            };

            cone.BorrarLocalidades(Eliminar);

            try
            {
                MessageBox.Show("La localidad se eliminó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarTextos();
                ListarLocalidades();
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
        private void iconButton1_Click(object sender, EventArgs e)
        {
            FormPAPELERALocalidades form = new FormPAPELERALocalidades();
            form.ShowDialog();
        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Interacciones con formulario
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {

            if (TxtBuscar.Text == "")
            {
                ListarLocalidades();
            }
            else
            {
                ConeLocalidades cone = new ConeLocalidades();
                Localidad Buscar = new Localidad
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarLocalidad(Buscar.Descripcion);

            }
        }
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblIdLocalidad.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
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

        #endregion

      
    }
}
