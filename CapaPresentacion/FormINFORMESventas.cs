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

namespace CapaPresentacion
{

    public partial class FormINFORMESventas : Form
    {
        private ConeVentas coneVentas;
        private int filaActual = 0; 
        public FormINFORMESventas()
        {
            InitializeComponent();
            coneVentas = new ConeVentas();
        }
   
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dateTimePickerInicio.Value;
            DateTime fechaFin = dateTimePickerFin.Value;

            List<Venta> ventasFiltradas = coneVentas.ListarVentasPorFecha(fechaInicio, fechaFin);
            Grilla.DataSource = ventasFiltradas;

            Grilla.Columns["IdVenta"].HeaderText = "ID Venta";
            Grilla.Columns["ClienteNombre"].HeaderText = "Cliente";
            Grilla.Columns["MetodoDescripcion"].HeaderText = "Método de Pago";
            Grilla.Columns["Total"].HeaderText = "Total";
            Grilla.Columns["Fecha"].HeaderText = "Fecha";

            // Ocultar columnas si quieres
            Grilla.Columns["IdCliente"].Visible = false;
            Grilla.Columns["IdMetodo"].Visible = false;
            Grilla.Columns["IdEntrega"].Visible = false;
            Grilla.Columns[1].Width = 0;
            Grilla.Columns[2].Width = 0;
            Grilla.Columns[3].Width = 0;
            Grilla.Columns[4].Width = 100;
            Grilla.Columns[5].Width = 150;
            Grilla.Columns[6].Width = 150;
            Grilla.Columns[7].Width = 150;

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
            while (filaActual < Grilla.Rows.Count)
            {
                DataGridViewRow row = Grilla.Rows[filaActual];
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

      
    }
    }


