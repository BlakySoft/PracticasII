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
    public partial class FormPAPELERALocalidades: Form
    {
        #region Metodos
        public FormPAPELERALocalidades()
        {
            InitializeComponent();
            LimpiarTextos();
            ListarLocalidadPapelera();
        }
        private void LimpiarTextos()
        {
            LblIdLocalidad.Text = "";
        }
        private void ListarLocalidadPapelera()
        {
            ConeLocalidades cone = new ConeLocalidades();
            Grilla.DataSource = cone.ListarLocalidadPapelera();
            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Localidad";
            Grilla.Columns[2].Visible = false;

        }
        #endregion

        #region Botones
        private void BtnRecuperar_Click(object sender, EventArgs e)
        {
            ConeLocalidades cone = new ConeLocalidades();
            Localidad Recuperar = new Localidad
            {
                IdLocalidad = int.Parse(LblIdLocalidad.Text)
            };

            cone.RecuperarLocalidad(Recuperar);

            try
            {
                MessageBox.Show("La Localidad se recuperó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarTextos();
                ListarLocalidadPapelera();
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
            LblIdLocalidad.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text == "")
            {
                ListarLocalidadPapelera();
            }
            else
            {
                ConeLocalidades cone = new ConeLocalidades();
                Localidad Buscar = new Localidad
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarPapelera(Buscar.Descripcion);

            }
        }
        #endregion
    }
}
