using System;
using CapaDatos;
using CapaNegocios;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{

    public partial class FormINFORMESventas : Form
    {
        private ConeVentas coneVentas;
        private int filaActual = 0;
        private CapaDatos.ConeDetalleVentas dtll = new CapaDatos.ConeDetalleVentas();
        public FormINFORMESventas()
        {
            InitializeComponent();
            coneVentas = new ConeVentas();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

            // Fecha inicio a las 00:00:00
            DateTime fechaInicio = dateTimePickerInicio.Value.Date;

            // Fecha fin a las 23:59:59
            DateTime fechaFin = dateTimePickerFin.Value.Date.AddDays(1).AddTicks(-1);

            List<Venta> ventasFiltradas = coneVentas.ListarVentasPorFecha(fechaInicio, fechaFin);
            Grilla1.DataSource = ventasFiltradas;

            Grilla1.Columns["IdVenta"].HeaderText = "ID";
            Grilla1.Columns["ClienteNombre"].HeaderText = "Cliente";
            Grilla1.Columns["MetodoDescripcion"].HeaderText = "Método de Pago";
            Grilla1.Columns["Total"].HeaderText = "Total";
            Grilla1.Columns["Fecha"].HeaderText = "Fecha";

            // Ocultar columnas si quieres      
            Grilla1.Columns[0].Width = 40;
            Grilla1.Columns["IdCliente"].Visible = false;
            Grilla1.Columns["IdMetodo"].Visible = false;
            Grilla1.Columns[3].Width = 150;
            Grilla1.Columns[4].Width = 150;
            Grilla1.Columns[5].Width = 90;
            Grilla1.Columns[6].Width = 150;


        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            filaActual = 0; // Reiniciar contador de filas
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(ImprimirGrilla);
            PrintPreviewDialog printPreview = new PrintPreviewDialog();
            printPreview.Document = pd;
            printPreview.ShowDialog();
        }
        private void ImprimirGrilla(object sender, PrintPageEventArgs e)
        {

            Graphics g = e.Graphics;
            float margenIzquierdo = 50;
            float margenSuperior = 100;
            float yPos = margenSuperior;
            float xPos = margenIzquierdo;

            Font titulo = new Font("Arial", 18, FontStyle.Bold);
            Font subtitulo = new Font("Arial", 14, FontStyle.Regular);
            Font contenido = new Font("Arial", 12, FontStyle.Regular);
            float espacio = 30;

            // Título y subtítulo
            g.DrawString("Liz Showroom", titulo, Brushes.Black, xPos + 150, yPos);
            yPos += espacio;
            g.DrawString("Informe de Ventas por Fecha", subtitulo, Brushes.Black, xPos + 120, yPos);
            yPos += espacio;

            // Rango de fechas
            g.DrawString($"Desde: {dateTimePickerInicio.Value.ToShortDateString()}  Hasta: {dateTimePickerFin.Value.ToShortDateString()}", contenido, Brushes.Black, xPos, yPos);
            yPos += espacio;

            // Encabezados de la grilla
            float[] columnasAncho = { 80, 180, 180, 120, 120 }; // Columnas más separadas
            string[] encabezados = { "ID Venta", "Cliente", "Método de Pago", "Total (ARS)", "Fecha" };

            float xTemp = xPos;
            for (int i = 0; i < encabezados.Length; i++)
            {
                g.DrawString(encabezados[i], contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[i];
            }

            yPos += contenido.GetHeight(g) + 5;
            g.DrawLine(Pens.Black, xPos, yPos, xPos + 680, yPos);
            yPos += 5;

            // Contenido de la grilla
            decimal sumaTotal = 0;
            while (filaActual < Grilla1.Rows.Count)
            {
                DataGridViewRow row = Grilla1.Rows[filaActual];
                if (row.IsNewRow) { filaActual++; continue; }

                xTemp = xPos;
                g.DrawString(row.Cells["IdVenta"].Value.ToString(), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[0];
                g.DrawString(row.Cells["ClienteNombre"].Value.ToString(), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[1];
                g.DrawString(row.Cells["MetodoDescripcion"].Value.ToString(), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[2];

                // Total en ARS sin decimales
                decimal total = Convert.ToDecimal(row.Cells["Total"].Value);
                g.DrawString("ARS " + total.ToString("N0"), contenido, Brushes.Black, xTemp, yPos);
                sumaTotal += total;
                xTemp += columnasAncho[3];

                g.DrawString(Convert.ToDateTime(row.Cells["Fecha"].Value).ToShortDateString(), contenido, Brushes.Black, xTemp, yPos);

                yPos += contenido.GetHeight(g) + 5;
                filaActual++;

                // Pagina siguiente si se acaba el espacio
                if (yPos + 50 > e.MarginBounds.Height)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            // Línea antes del total
            g.DrawLine(Pens.Black, xPos, yPos, xPos + 680, yPos);
            yPos += 5;

            // Total de ganancias en ARS sin decimales
            g.DrawString("Total Ganancias: ARS " + sumaTotal.ToString("N0"), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, xPos + 400, yPos);

            e.HasMorePages = false;
        }
        private void Grilla1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idVenta = Convert.ToInt32(Grilla1.Rows[e.RowIndex].Cells["IdVenta"].Value);

                List<DetalleVenta> detalles = dtll.ListarDetallesPorVenta(idVenta);
                Grilla2.DataSource = detalles;
                Grilla2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                Grilla2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                Grilla2.AllowUserToResizeColumns = false;
                Grilla2.AllowUserToResizeRows = false;
                Grilla2.RowTemplate.Height = 30;
                Grilla2.ScrollBars = ScrollBars.Vertical;


                if (Grilla2.Columns.Count > 0)
                {
                    if (Grilla2.Columns.Contains("IdVenta")) Grilla2.Columns["IdVenta"].HeaderText = "ID";
                    if (Grilla2.Columns.Contains("DetalleProducto")) Grilla2.Columns["DetalleProducto"].HeaderText = "Producto";
                    if (Grilla2.Columns.Contains("PrecioVenta")) Grilla2.Columns["PrecioVenta"].HeaderText = "Precio";
                    if (Grilla2.Columns.Contains("Cantidad")) Grilla2.Columns["Cantidad"].HeaderText = "Cantidad";
                    if (Grilla2.Columns.Contains("Subtotal")) Grilla2.Columns["Subtotal"].HeaderText = "Subtotal";

                    if (Grilla2.Columns.Contains("IdVenta")) Grilla2.Columns["IdVenta"].Width= 45;
                    if (Grilla2.Columns.Contains("IdProducto")) Grilla2.Columns["IdProducto"].Visible = false;

                    if (Grilla2.Columns.Contains("DetalleProducto")) Grilla2.Columns["DetalleProducto"].Width = 220;
                    if (Grilla2.Columns.Contains("PrecioVenta")) Grilla2.Columns["PrecioVenta"].Width = 100;
                    if (Grilla2.Columns.Contains("Cantidad")) Grilla2.Columns["Cantidad"].Width = 100;
                    if (Grilla2.Columns.Contains("Subtotal")) Grilla2.Columns["Subtotal"].Width = 120;

                }
            }
        }
    }
}



