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

            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Descripcion";
            Grilla.Columns[2].HeaderText = "Detalle";
            Grilla.Columns[3].Visible = false;
            Grilla.Columns[4].HeaderText = "Precio";
            Grilla.Columns[5].HeaderText = "Stock";
            Grilla.Columns[6].Visible = false;

        }

        #endregion

        #region Botones
        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            TxtBuscar.Clear();
        }
        private void BtnRecuperar_Click(object sender, EventArgs e)
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
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblIdProducto.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        #endregion

      
    }
}
