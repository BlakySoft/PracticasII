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
    public partial class FormPAPELERAProveedores: Form
    {
        #region Metodos
        public FormPAPELERAProveedores()
        {
            InitializeComponent();
            LimpiarTextos();
            ListarProveedorPapelera();
        }
        private void LimpiarTextos()
        {
            LblIdProveedor.Text = "";
        }
        private void ListarProveedorPapelera()
        {
            ConeProveedores cone = new ConeProveedores();
            Grilla.DataSource = cone.ListarProveedorPapelera();

            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 50;
            Grilla.Columns[1].Width = 150;
            Grilla.Columns[1].HeaderText = "Razón Social";
            Grilla.Columns[2].HeaderText = "CUIT";
            Grilla.Columns[3].HeaderText = "Teléfono";
            Grilla.Columns[4].HeaderText = "Direccion";
            Grilla.Columns[5].HeaderText = "Localidad";
            Grilla.Columns[6].Visible = false;

        }
        #endregion

        #region Botones
        private void BtnRecuperar_Click(object sender, EventArgs e)
        {
            ConeProveedores cone = new ConeProveedores();
            Proveedores Recuperar = new Proveedores
            {
                IdProveedor = int.Parse(LblIdProveedor.Text)
            };

            cone.RecuperarProveedor(Recuperar);

            try
            {
                MessageBox.Show("El Proveedor se recuperó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarTextos();
                ListarProveedorPapelera();
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

        #region Interacciones con formulario
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblIdProveedor.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text == "")
            {
                ListarProveedorPapelera();
            }
            else
            {
                ConeProveedores cone = new ConeProveedores();
                Proveedores Buscar = new Proveedores
                {
                    RazonSocial = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarPapelera(Buscar.RazonSocial);

            }

        }
        #endregion
    }
}
