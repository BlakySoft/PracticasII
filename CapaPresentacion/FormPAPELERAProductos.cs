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
    public partial class FormPAPELERAProductos: Form
    {
        #region Metodos
        public FormPAPELERAProductos()
        {
            InitializeComponent();
            LimpiarTextos();
            ListarPapelera();
        }
        private void LimpiarTextos()
        {
            LblIdProducto.Text = "";
        }
        private void ListarPapelera()
        {
            ConeProductos cone = new ConeProductos();
            Grilla.DataSource = cone.ListarPapelera();

            
            Grilla.Columns[1].Visible = false;
            Grilla.Columns[4].Visible = false;
            Grilla.Columns[5].Visible = false;
            Grilla.Columns[6].Visible = false;
            Grilla.Columns[7].Visible = false;
            Grilla.Columns[8].Visible = false;
            Grilla.Columns[9].Visible = false;
            Grilla.Columns[13].Visible = false;


        }

        #endregion

        #region Botones
        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            TxtBuscar.Clear();
        }
        private void BtnRecuperar_Click(object sender, EventArgs e)
        {
            try
            {
                ConeProductos cone = new ConeProductos();
                Productos Recuperar = new Productos
                {
                    IdProducto = int.Parse(LblIdProducto.Text)
                };

                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea recuperar este producto?",
                    "Confirmar recuperación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    cone.Recuperar(Recuperar);

                    try
                    {
                        MessageBox.Show("El Producto se recuperó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarTextos();
                        ListarPapelera();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.ToString()}");
                        throw;
                    }

                    BtnVolver.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Seleccione un Producto para recuperar.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region Interacciones con formulario
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text == "")
            {
                ListarPapelera();
            }
            else
            {
                ConeProductos cone = new ConeProductos();
                Productos Buscar = new Productos
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarPapelera(Buscar.Descripcion);

            }
        }
        private void Grilla_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            LblIdProducto.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        #endregion

        private void FormPAPELERAProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
