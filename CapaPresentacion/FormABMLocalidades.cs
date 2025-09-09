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
        private void iconButton2_Click(object sender, EventArgs e)
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
            if (string.IsNullOrWhiteSpace(TxtDescripcion.Text))
            {
                MessageBox.Show("Ingrese la Descripción", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ConeLocalidades cone = new ConeLocalidades();
            Localidad loc = new Localidad
            {
                Descripcion = TxtDescripcion.Text
            };

            string mensaje = nuevo
                ? "¿Está seguro que desea agregar esta localidad?"
                : "¿Está seguro que desea actualizar esta localidad?";

            if (MessageBox.Show(mensaje, "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                if (nuevo)
                {
                    cone.AgregarLocalidad(loc);
                    MessageBox.Show("Localidad agregada correctamente!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    loc.IdLocalidad = int.Parse(LblIdLocalidad.Text);
                    cone.ActualizarLocalidad(loc);
                    MessageBox.Show("Localidad actualizada correctamente!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarTextos();
                ListarLocalidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!int.TryParse(LblIdLocalidad.Text, out int idLocalidad))
            {
                MessageBox.Show("Seleccione una localidad válida primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro que desea eliminar esta localidad?",
                                "Confirmar eliminación",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                new ConeLocalidades().BorrarLocalidades(new Localidad { IdLocalidad = idLocalidad });
                MessageBox.Show("La localidad se eliminó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTextos();
                ListarLocalidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            using (FormPAPELERALocalidades form = new FormPAPELERALocalidades())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ListarLocalidades();
                }
            }
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
            if (e.RowIndex < 0) return;

            try
            {
                LblIdLocalidad.Text = Grilla.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                TxtDescripcion.Text = Grilla.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";

                nuevo = false;
                BtnNuevo.Enabled = false;

                TxtDescripcion.Enabled = true;
                BtnGrabar.Enabled = true;
                BtnCancelar.Enabled = true;
                BtnEliminar.Enabled = true;
                BtnModificar.Enabled = true;

                TxtDescripcion.Focus();
            }
            catch
            {
            }
        }

        #endregion


    }
}
