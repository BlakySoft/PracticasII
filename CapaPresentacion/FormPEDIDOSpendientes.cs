using CapaDatos;
using CapaNegocios;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormPEDIDOSpendientes: Form
    {
        #region Listar
        private ConePedidos conePedidos;
        public FormPEDIDOSpendientes()
        {
            InitializeComponent();
            conePedidos = new ConePedidos();
            ListarPedidos();
        }
        private void ListarPedidos()
        {
            List<Pedido> pedidos = conePedidos.ListarPedidoPendiente();
            Grilla.DataSource = pedidos;

            Grilla.Columns["IdPedido"].HeaderText = "ID Pedido";
            Grilla.Columns["ClienteNombre"].HeaderText = "Cliente";
            Grilla.Columns["MetodoDescripcion"].HeaderText = "Método de Pago";
            Grilla.Columns["EntregaDescripcion"].HeaderText = "Método de Entrega";
            Grilla.Columns["Total"].HeaderText = "Total";
            Grilla.Columns["Fecha"].HeaderText = "Fecha";

            Grilla.Columns[1].Visible = false;
            Grilla.Columns[2].Visible = false;
            Grilla.Columns[3].Visible = false;
        }
        #endregion

        #region Botones
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnEntregado_Click(object sender, EventArgs e)
        {
            if (Grilla.SelectedRows.Count > 0)
            {
                int idPedido = Convert.ToInt32(Grilla.SelectedRows[0].Cells[0].Value);

                ConePedidos pedido = new ConePedidos();
                pedido.EntregarPedido(idPedido);

                ListarPedidos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un pedido.");
            }
        }
        private void BtnCancelado_Click(object sender, EventArgs e)
        {
            if (Grilla.SelectedRows.Count > 0)
            {
                int idPedido = Convert.ToInt32(Grilla.SelectedRows[0].Cells[0].Value);

                ConePedidos pedido = new ConePedidos();
                pedido.CancelarPedido(idPedido);

                ListarPedidos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un pedido.");
            }
        }
        #endregion
    }
}
