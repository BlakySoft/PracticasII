using CapaDatos;
using CapaNegocio;
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
    public partial class FormPAPELERAColor: Form
    {
        #region Metodos
        public FormPAPELERAColor()
        {
            InitializeComponent();
            LimpiarTextos();
            Listar();
        }

        private void LimpiarTextos()
        {
            LblIdColor.Text = ""; 
        }

        private void Listar()
        {
            ConeColores cone = new ConeColores();
            Grilla.DataSource = cone.ListarColorPapelera(); 
            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Color";
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
            ConeColores cone = new ConeColores();
            Colores Recuperar = new Colores
            {
                IdColor = int.Parse(LblIdColor.Text)
            };

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea recuperar este color?",
                "Confirmar recuperación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                cone.Recuperar(Recuperar);

                try
                {
                    MessageBox.Show("El Color se recuperó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Interaccion con el formulario
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblIdColor.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text == "")
            {
                Listar();
            }
            else
            {
                ConeColores cone = new ConeColores();
                Colores Buscar = new Colores
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarPapelera(Buscar.Descripcion);
            }
        }
        #endregion

    }
}
