using CapaDatos;
using CapaNegocios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormABMMetododepago : Form
    {
        #region Metodos y declaraciones
        Boolean nuevo;
        public FormABMMetododepago()
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
            LblIdMetodo.Text = "";
            TxtDescripcion.Clear();
        }
        private void Listar()
        {
            ConeMetododepago cone = new ConeMetododepago();
            Grilla.DataSource = cone.Listar();
            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Metodo de pago";
            Grilla.Columns[1].Width = 150;
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

            nuevo = true;
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
            if (!int.TryParse(LblIdMetodo.Text, out int idMetodo))
            {
                MessageBox.Show("Seleccione un método de pago válido primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro que desea eliminar este método de pago?",
                                "Confirmar eliminación",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                new ConeMetododepago().Borrar(new Metododepago { IdMetodo = idMetodo });
                MessageBox.Show("El método de pago se eliminó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTextos();
                Listar();
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
            LimpiarTextos();
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
            if (!int.TryParse(LblIdMetodo.Text, out int idMetodo))
            {
                MessageBox.Show("Seleccione un método de pago válido primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro que desea eliminar este método de pago?",
                                "Confirmar eliminación",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                new ConeMetododepago().Borrar(new Metododepago { IdMetodo = idMetodo });
                MessageBox.Show("El método de pago se eliminó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarTextos();
                Listar();
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
            using (FormPAPELERAMetodosdepago form = new FormPAPELERAMetodosdepago())
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
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text == "")
            {
                Listar();
            }
            else
            {
                ConeMetododepago cone = new ConeMetododepago();
                Metododepago Buscar = new Metododepago
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.Buscar(Buscar.Descripcion);

            }
        }
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            LblIdMetodo.Text = Grilla.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
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

        #endregion


    }
}
