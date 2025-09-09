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
            if (string.IsNullOrWhiteSpace(TxtDescripcion.Text))
            {
                MessageBox.Show("Debe ingresar una descripción para la marca.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConeMarca cone = new ConeMarca();
            Marca marca = new Marca
            {
                Descripcion = TxtDescripcion.Text
            };

            if (nuevo) 
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro de que desea agregar esta marca?",
                    "Confirmar alta",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado != DialogResult.Yes) return;

                try
                {
                    cone.Agregar(marca);
                    MessageBox.Show("La marca se agregó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                if (string.IsNullOrEmpty(LblIdMarca.Text))
                {
                    MessageBox.Show("Debe seleccionar una marca para actualizar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro de que desea actualizar esta marca?",
                    "Confirmar actualización",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado != DialogResult.Yes) return;

                try
                {
                    marca.IdMarca = int.Parse(LblIdMarca.Text);
                    cone.Actualizar(marca);
                    MessageBox.Show("La marca se actualizó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LimpiarTextos();
            Listar();

            #region Enabled yes/no
            BtnNuevo.Enabled = true;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnModificar.Enabled = false;
            BtnNuevo.Focus();
            #endregion
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
            if (string.IsNullOrEmpty(LblIdMarca.Text))
            {
                MessageBox.Show("Debe seleccionar una marca antes de eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta marca?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                ConeMarca cone = new ConeMarca();
                Marca Eliminar = new Marca
                {
                    IdMarca = int.Parse(LblIdMarca.Text)
                };

                try
                {
                    cone.Borrar(Eliminar);

                    MessageBox.Show("La Marca se eliminó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarTextos();
                    Listar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                #region Enabled yes/no
                BtnNuevo.Enabled = true;
                BtnGrabar.Enabled = false;
                BtnCancelar.Enabled = false;
                BtnEliminar.Enabled = false;
                BtnNuevo.Focus();
                #endregion
            }
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

            if (e.RowIndex < 0) return;

            LblIdMarca.Text = Grilla.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
            TxtDescripcion.Text = Grilla.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";

            #region Enabled yes/no
            nuevo = false;
            BtnNuevo.Enabled = false;
            TxtDescripcion.Enabled = true;
            BtnGrabar.Enabled = true;
            BtnCancelar.Enabled = true;
            BtnEliminar.Enabled = true;
            BtnModificar.Enabled = true;
            #endregion

         
            TxtDescripcion.Enabled = false;
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
