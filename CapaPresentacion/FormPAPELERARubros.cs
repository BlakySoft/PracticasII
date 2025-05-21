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
    public partial class FormPAPELERARubros : Form
    {
        #region Metodos
        public FormPAPELERARubros()
        {
            InitializeComponent();
            LimpiarTextos();
            Listar();
        }
        private void LimpiarTextos()
        {
            LblIdRubro.Text = "";
        }
        private void Listar()
        {
            ConeRubros cone = new ConeRubros();
            Grilla.DataSource = cone.ListarRubroPapelera();
            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Rubro";
            Grilla.Columns[2].Visible = false;

        }
        #endregion

        #region Botones
        private void BtnRecuperar_Click(object sender, EventArgs e)
        {
            ConeRubros cone = new ConeRubros();
            Rubro Recuperar = new Rubro
            {
                IdRubro = int.Parse(LblIdRubro.Text)
            };

            cone.RecuperarRubro(Recuperar);

            try
            {
                MessageBox.Show("El Rubro se recuperó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Interacciones con Formulario
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblIdRubro.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {

            if (TxtBuscar.Text == "")
            {
                Listar();
            }
            else
            {
                ConeRubros cone = new ConeRubros();
                Rubro Buscar = new Rubro
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarPapelera(Buscar.Descripcion);
            }
        }
        #endregion
    }
}
