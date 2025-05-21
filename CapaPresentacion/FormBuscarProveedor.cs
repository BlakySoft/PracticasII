using CapaNegocios;
using System;
using CapaDatos;
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
    public partial class FormBuscarProveedor: Form
    {
        #region Metodos y declaraciones
        string IdProveedor, RazonSocial;
        public FormBuscarProveedor()
        {
            InitializeComponent();
            ListarProveedores();
        }
        private void ListarProveedores()
        {

            ConeProveedores cone = new ConeProveedores();
            Grilla.DataSource = cone.ListarProveedor();
            
            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Razón Social";
            Grilla.Columns[2].HeaderText = "CUIT";
            Grilla.Columns[3].HeaderText = "Teléfono";
            Grilla.Columns[4].HeaderText = "Direccion";
            Grilla.Columns[5].HeaderText = "Localidad";
            Grilla.Columns[6].Visible = false;

        }
        #endregion

        #region Interaccion
        private void Grilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IdProveedor != "")
                {
                    FormCOMPRAS compras = Owner as FormCOMPRAS;
                    compras.TxtRazon.Text = $"{RazonSocial}";
                    compras.IdProveedorCompra = IdProveedor;
                    Close();
                }
                else
                {
                    MessageBox.Show("Seleccione un proveedor.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede seleccionar desde la cabecera.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {

            if (TxtBuscar.Text == "")
            {
                ListarProveedores();
            }
            else
            {
                ConeProveedores cone = new ConeProveedores();
                Proveedores Buscar = new Proveedores
                {
                    RazonSocial = TxtBuscar.Text
                };

                Grilla.DataSource = cone.Buscar(Buscar.RazonSocial);

            }

        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                IdProveedor = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
                RazonSocial = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede seleccionar desde la cabecera.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion


    }
}
