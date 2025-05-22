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
    public partial class FormPAPELERACategoria : Form
    {
        #region Metodos
        public FormPAPELERACategoria()
        {
            InitializeComponent();
            LimpiarTextos();
            Listar();
        }
        private void LimpiarTextos()
        {
            LblIdCat.Text = "";
        }
        private void Listar()
        {
            ConeCategoria cone = new ConeCategoria();
            Grilla.DataSource = cone.ListarCatPapelera();
            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Categoria";
            Grilla.Columns[2].Visible = false;

        }
        #endregion

        #region Botones
        private void BtnRecuperar_Click(object sender, EventArgs e)
        {
            ConeCategoria cone = new ConeCategoria();
            Categoria Recuperar = new Categoria
            {
                IdCat = int.Parse(LblIdCat.Text)
            };

            cone.RecuperarCat(Recuperar);

            try
            {
                MessageBox.Show("El Categoria se recuperó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            LblIdCat.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
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

                Grilla.DataSource = cone.BuscarPapelera(Buscar.Descripcion);
            }
        }
        #endregion
    }
}
