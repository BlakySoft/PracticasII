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
    public partial class FormPAPELERAMarca: Form
    {
        #region Metodos
        public FormPAPELERAMarca()
        {
            InitializeComponent();
            LimpiarTextos();
            Listar();
        }
        private void LimpiarTextos()
        {
            LblMar.Text = ""; 
        }
        private void Listar()
        {
            ConeMarca cone = new ConeMarca();
            Grilla.DataSource = cone.ListarMarcaPapelera(); 
            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Marca";
            Grilla.Columns[2].Visible = false;
        }
        #endregion

        #region Botones
        private void iconButton1_Click(object sender, EventArgs e)
        {
            TxtBuscar.Clear();
        }
        private void BtnRecuperar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(LblMar.Text))
    {
                MessageBox.Show("No hay ninguna marca seleccionada. Seleccione una marca primero.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(LblMar.Text, out int idMarca))
            {
                MessageBox.Show("El Id de la marca no es válido.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea recuperar esta marca?",
                "Confirmar recuperación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado != DialogResult.Yes) return;

            try
            {
                ConeMarca cone = new ConeMarca();
                cone.Recuperar(new Marca { IdMarca = idMarca });

                MessageBox.Show("La marca se recuperó correctamente.",
                    "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarTextos();
                Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BtnVolver.Focus();
            }
        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region Interacciones con el formulario
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

                Grilla.DataSource = cone.BuscarPapelera(Buscar.Descripcion);
            }
        }
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = Grilla.Rows[e.RowIndex];

                LblMar.Text = fila.Cells[0].Value?.ToString() ?? "";
            }
        }
        #endregion


    }
}

