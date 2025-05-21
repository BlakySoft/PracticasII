using CapaDatos;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormPEDIDOSentregados: Form
    {
        #region Listar
        private ConePedidos conePedidos;
        public FormPEDIDOSentregados()
        {
            InitializeComponent();  
            conePedidos = new ConePedidos();
            ListarPedidos();
        }
        private void ListarPedidos()
        {
            List<Pedido> pedidos = conePedidos.ListarPedidoEntregado();
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
        private void BtnImprimir_Click(object sender, EventArgs e)
        {

            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Landscape = false;
            printDoc.PrintPage += new PrintPageEventHandler(Imprimir_PrintPage);
            printDoc.Print();
        }
        #endregion

        #region Informe
        private void Imprimir_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Font fuenteTitulo = new Font("Arial", 12, FontStyle.Bold);
            Font fuenteDetalle = new Font("Arial", 10);
            Font fuenteTotal = new Font("Arial", 10, FontStyle.Bold); 
            int margenIzquierdo = 40;
            int margenSuperior = 40;
            int espacioEntreLineas = 20;

            e.Graphics.DrawString("Informe de Pedidos Entregados", fuenteTitulo, Brushes.Black, margenIzquierdo, margenSuperior);
            int lineaY = margenSuperior + 30;
            e.Graphics.DrawLine(Pens.Black, margenIzquierdo, lineaY, 770, lineaY);


            e.Graphics.DrawString("ID Pedido", fuenteTitulo, Brushes.Black, margenIzquierdo, lineaY + espacioEntreLineas);
            e.Graphics.DrawString("Cliente", fuenteTitulo, Brushes.Black, margenIzquierdo + 80, lineaY + espacioEntreLineas);
            e.Graphics.DrawString("Total", fuenteTitulo, Brushes.Black, margenIzquierdo + 300, lineaY + espacioEntreLineas);
            e.Graphics.DrawString("Fecha", fuenteTitulo, Brushes.Black, margenIzquierdo + 450, lineaY + espacioEntreLineas);
            e.Graphics.DrawString("Método de Pago", fuenteTitulo, Brushes.Black, margenIzquierdo + 540, lineaY + espacioEntreLineas);
            lineaY += espacioEntreLineas + 20;


            ConePedidos conePedidos = new ConePedidos();
            List<Pedido> pedidos = conePedidos.ListarPedidoEntregado();
            decimal totalPedidos = 0;


            foreach (var pedido in pedidos)
            {
                
                e.Graphics.DrawString(pedido.IdPedido.ToString(), fuenteDetalle, Brushes.Black, margenIzquierdo, lineaY);
                e.Graphics.DrawString(pedido.ClienteNombre, fuenteDetalle, Brushes.Black, margenIzquierdo + 80, lineaY);
                e.Graphics.DrawString(pedido.Total.ToString("C"), fuenteDetalle, Brushes.Black, margenIzquierdo + 300, lineaY); // Formateamos el total como moneda
                e.Graphics.DrawString(pedido.Fecha.ToString("dd/MM/yyyy"), fuenteDetalle, Brushes.Black, margenIzquierdo + 450, lineaY); // Formateamos la fecha
                e.Graphics.DrawString(pedido.MetodoDescripcion, fuenteDetalle, Brushes.Black, margenIzquierdo + 540, lineaY);
                lineaY += espacioEntreLineas;
                totalPedidos += pedido.Total;
            }

            lineaY += 20; 
            e.Graphics.DrawLine(Pens.Black, margenIzquierdo, lineaY, 770, lineaY);
            lineaY += 20; 
            e.Graphics.DrawString("Total de Todos los Pedidos: " + totalPedidos.ToString("C"), fuenteTotal, Brushes.Black, margenIzquierdo, lineaY);

  
            if (lineaY > e.MarginBounds.Height)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }
        #endregion


    }
}
