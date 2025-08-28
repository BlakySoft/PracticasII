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
            LblIdMarca.Text = ""; 
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
        private void BtnRecuperar_Click(object sender, EventArgs e)
        {
            ConeMarca cone = new ConeMarca();
            Marca Recuperar = new Marca
            {
                IdMarca = int.Parse(LblIdMarca.Text)
            };

            cone.Recuperar(Recuperar);

            try
            {
                MessageBox.Show("La Marca se recuperó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarTextos();
                Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.ToString()}");
                throw;
            }

            BtnVolver.Focus();
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

                Grilla.DataSource = cone.BuscarPapelera(Buscar.Descripcion);
            }
        }
        #endregion
    }
}

