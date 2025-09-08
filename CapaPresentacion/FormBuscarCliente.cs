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
        string IdCliente, Nombre;
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
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IdCliente = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
                Nombre = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede seleccionar desde la cabecera.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Grilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IdCliente != "")
                {
                    FormVENTAS pedidos = Owner as FormVENTAS;
                    pedidos.TxtCliente.Text = $"{Nombre}";
                    pedidos.IdCliente = Convert.ToInt32(IdCliente);
                    Close();
                }
                else
                {
                    MessageBox.Show("Seleccione un Cliente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede seleccionar desde la cabecera.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
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
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion


    }
}
