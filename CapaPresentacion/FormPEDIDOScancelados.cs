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
    public partial class FormPEDIDOScancelados: Form
    {
        #region Listar
        private ConePedidos conePedidos;
        public FormPEDIDOScancelados()
        {
            InitializeComponent();       
            conePedidos = new ConePedidos();
            ListarPedidos();
        }
        private void ListarPedidos()
        {
            List<Pedido> pedidos = conePedidos.ListarPedidoCancelado();
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

        #region Boton
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
