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
using CapaNegocio;

namespace CapaPresentacion
{

    public partial class FormINFORMESventas : Form
    {
        private ConeVentas coneVentas;
        private int filaActual = 0;
        private CapaDatos.ConeDetalleVentas dtll = new CapaDatos.ConeDetalleVentas();
        public DateTime fechaInicio, fechaFin;

        public FormINFORMESventas()
        {
            InitializeComponent();
            coneVentas = new ConeVentas();
            fechaFin = DateTime.Now;
            dateTimePickerFin.Value = fechaFin;
            dateTimePickerInicio.Value = fechaFin.AddMonths(-1);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            fechaInicio = dateTimePickerInicio.Value.Date;
            fechaFin = dateTimePickerFin.Value.Date.AddDays(1).AddTicks(-1);

            List<Venta> ventasFiltradas = coneVentas.ListarVentasPorFecha(fechaInicio, fechaFin);
            Grilla1.DataSource = ventasFiltradas;

            Grilla1.Columns["IdVenta"].HeaderText = "ID";
            Grilla1.Columns["ClienteNombre"].HeaderText = "Cliente";
            Grilla1.Columns["MetodoDescripcion"].HeaderText = "Método de Pago";
            Grilla1.Columns["Total"].HeaderText = "Total";
            Grilla1.Columns["Fecha"].HeaderText = "Fecha";

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
            if (Grilla1.Rows.Count == 0 || Grilla1.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("No hay ventas para imprimir.", "Impresión de Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            filaActual = 0;
            PrintDocument pd = new PrintDocument();

            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            pd.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);

            pd.PrintPage += new PrintPageEventHandler(ImprimirGrilla);

            PrintPreviewDialog printPreview = new PrintPreviewDialog();
            printPreview.Document = pd;
            printPreview.WindowState = FormWindowState.Maximized;
            printPreview.ShowDialog();
        }

        private void ImprimirGrilla(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            float margenIzquierdo = e.MarginBounds.Left;
            float margenSuperior = e.MarginBounds.Top;
            float yPos = margenSuperior;
            float xPos = margenIzquierdo;
            float anchoPagina = e.MarginBounds.Width;

            Font titulo = new Font("Arial", 18, FontStyle.Bold);
            Font subtitulo = new Font("Arial", 14, FontStyle.Regular);
            Font contenido = new Font("Arial", 9, FontStyle.Regular);
            Font contenidoNegrita = new Font("Arial", 9, FontStyle.Bold);

            float espacio = 25;
            float alturaFila = contenido.GetHeight(g) + 5;

            StringFormat formatoCentrado = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Títulos del Informe
            g.DrawString("Liz Showroom", titulo, Brushes.Black, xPos + anchoPagina / 2, yPos, formatoCentrado);
            yPos += espacio;
            g.DrawString("Informe de Ventas", subtitulo, Brushes.Black, xPos + anchoPagina / 2, yPos, formatoCentrado);
            yPos += espacio;

            // Rango de Fechas
            string rangoFechas = $"Desde: {dateTimePickerInicio.Value.ToShortDateString()} - Hasta: {dateTimePickerFin.Value.ToShortDateString()}";
            g.DrawString(rangoFechas, new Font(contenido, FontStyle.Bold), Brushes.DarkGray, xPos + anchoPagina / 2, yPos, formatoCentrado);
            yPos += espacio * 1.5f;

            // Configuración y Encabezados de Columnas
            float[] columnasAncho = { 50, 150, 150, 100, 100 }; // ID, Cliente, Método, Fecha, Total
            string[] encabezados = { "ID", "Cliente", "Método de Pago", "Fecha", "Total" };
            float anchoTotalGrilla = columnasAncho.Sum();

            // Dibujar Encabezados
            float xTemp = xPos;
            for (int i = 0; i < encabezados.Length; i++)
            {
                g.DrawString(encabezados[i], contenidoNegrita, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[i];
            }

            yPos += contenido.GetHeight(g) + 5;
            // Dibujar línea separadora
            g.DrawLine(Pens.Black, xPos, yPos, xPos + anchoTotalGrilla, yPos);
            yPos += 5;


            // Dibujar Contenido (Datos de Grilla1)
            while (filaActual < Grilla1.Rows.Count)
            {
                DataGridViewRow row = Grilla1.Rows[filaActual];
                if (row.IsNewRow)
                {
                    filaActual++;
                    continue;
                }

                // Lógica de Paginación
                if (yPos + alturaFila > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                xTemp = xPos;

                // 1. ID
                g.DrawString(GetStringValue(row.Cells["IdVenta"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[0];

                // 2. Cliente
                g.DrawString(GetStringValue(row.Cells["ClienteNombre"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[1];

                // 3. Método de Pago
                g.DrawString(GetStringValue(row.Cells["MetodoDescripcion"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[2];

                // 4. Fecha
                string fechaStr = (row.Cells["Fecha"].Value is DateTime dt) ? dt.ToShortDateString() : GetStringValue(row.Cells["Fecha"]);
                g.DrawString(fechaStr, contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[3];

                // 5. Total
                g.DrawString("$ " + GetStringValue(row.Cells["Total"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[4];

                yPos += alturaFila;
                filaActual++;
            }

            // Totalizador General
            yPos += alturaFila;
            g.DrawLine(Pens.Black, xPos, yPos, xPos + anchoTotalGrilla, yPos);
            yPos += 2;
            g.DrawLine(Pens.Black, xPos, yPos, xPos + anchoTotalGrilla, yPos);
            yPos += 5;

            // Calcular el Gran Total
            decimal granTotal = Grilla1.Rows.Cast<DataGridViewRow>()
                                            .Where(r => !r.IsNewRow && r.Cells["Total"].Value != null)
                                            .Sum(r => Convert.ToDecimal(r.Cells["Total"].Value));

            // Posición para el valor total (alineado con la columna 'Total')
            float xPosValorTotal = xPos + columnasAncho[0] + columnasAncho[1] + columnasAncho[2] + columnasAncho[3];
            float xPosTituloTotal = xPosValorTotal - 100;

            g.DrawString("TOTAL:", new Font(contenido, FontStyle.Bold), Brushes.Black, xPosTituloTotal, yPos);
            g.DrawString("$ " + granTotal.ToString("N2"), new Font(contenido, FontStyle.Bold), Brushes.Black, xPosValorTotal, yPos);

            // Termina el informe
            e.HasMorePages = false;
        }

        private string GetStringValue(DataGridViewCell cell)
        {
            if (cell == null || cell.Value == null || cell.Value == DBNull.Value)
            {
                return string.Empty;
            }

            if (cell.Value is decimal d)
            {
                return d.ToString("N2");
            }

            if (cell.Value is DateTime dt)
            {
                return dt.ToShortDateString();
            }

            return cell.Value.ToString();
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

                    if (Grilla2.Columns.Contains("IdVenta")) Grilla2.Columns["IdVenta"].Width = 45;
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