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
    public partial class FormBuscarCliente: Form
    {
        #region Metodos y declaraciones 
        string IdCliente, Apellido, Nombre;
        public FormBuscarCliente()
        {
            InitializeComponent();
            ListarClientes();
        }
        private void ListarClientes()
        {
            ConeClientes cone = new ConeClientes();
            Grilla.DataSource = cone.ListarCliente();
            Grilla.Columns[6].Visible = false;
        }
        #endregion

        #region Interacciones
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text != "")
            {
                ConeClientes cone = new ConeClientes();
                Cliente Buscar = new Cliente
                {
                    Nombre = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarCliente(Buscar.Nombre);
            }
            else
            {
                ListarClientes();
            }
        }
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show("No se puede seleccionar desde la cabecera.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            IdCliente = Grilla.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
            Nombre = Grilla.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
        }
        private void Grilla_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
            {
                MessageBox.Show("Seleccione un cliente válido.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {

                DataGridViewRow fila = Grilla.Rows[e.RowIndex];

                string apellido = fila.Cells["Apellido"].Value?.ToString() ?? "";
                string nombre = fila.Cells["Nombre"].Value?.ToString() ?? "";
                string idClienteStr = fila.Cells["IdCliente"].Value?.ToString() ?? "";

                if (string.IsNullOrEmpty(idClienteStr))
                {
                    MessageBox.Show("El cliente seleccionado no tiene ID válido.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!int.TryParse(idClienteStr, out int idCliente))
                {
                    MessageBox.Show("El ID del cliente no es válido.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (Owner is FormVENTAS pedidos)
                {
                    pedidos.TxtCliente.Text = $"{apellido} {nombre}";
                    pedidos.IdCliente = idCliente;
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al seleccionar el cliente: {ex.Message}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion


    }
}
