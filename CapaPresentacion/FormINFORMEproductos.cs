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
    public partial class FormINFORMEproductos : Form
    {
        private ConeProductos coneProductos;
        private BindingSource bindingSourceProductos;
        private int filaActual = 0;

        public FormINFORMEproductos()
        {
            InitializeComponent();
            coneProductos = new ConeProductos();
            bindingSourceProductos = new BindingSource();
            listar();
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
        }


        private void listar()
        {
            List<Productos> productos = coneProductos.ListarINNERJOIN();

            bindingSourceProductos.DataSource = productos;
            Grilla1.DataSource = bindingSourceProductos;

            Grilla1.Columns["IdProducto"].HeaderText = "ID";
            Grilla1.Columns["BarCode"].HeaderText = "Cód. Barra";
            Grilla1.Columns["PrecioVenta"].HeaderText = "P. Venta";
            Grilla1.Columns["PrecioCompra"].Visible = false;
            Grilla1.Columns["Detalle"].Visible = false;
            Grilla1.Columns["IdCat"].Visible = false;
            Grilla1.Columns["IdMarca"].Visible = false;
            Grilla1.Columns["IdColor"].Visible = false;
            Grilla1.Columns["Estado"].Visible = false;
        }

        // --- Lógica de Filtrado ---

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string textoFiltro = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(textoFiltro))
            {
                listar();
            }
            else
            {
                List<Productos> todosLosProductos = coneProductos.ListarINNERJOIN();

                var productosFiltrados = todosLosProductos
                    .Where(p => p.Descripcion.IndexOf(textoFiltro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 p.BarCode.ToString().IndexOf(textoFiltro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 p.Categoria.IndexOf(textoFiltro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 p.Marca.IndexOf(textoFiltro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 p.Color.IndexOf(textoFiltro, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

                bindingSourceProductos.DataSource = productosFiltrados;
                bindingSourceProductos.ResetBindings(false);
            }
        }

        // --- Eventos de Botones ---

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
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

        // --- Métodos de Impresión ---

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
            float espacio = 25;

            StringFormat formatoCentrado = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            g.DrawString("Liz Showroom", titulo, Brushes.Black, xPos + anchoPagina / 2, yPos, formatoCentrado);
            yPos += espacio;
            g.DrawString("Informe de Productos", subtitulo, Brushes.Black, xPos + anchoPagina / 2, yPos, formatoCentrado);
            yPos += espacio * 1.5f;

            float[] columnasAncho = { 30, 110, 160, 90, 70, 50, 90, 50 };
            string[] encabezados = { "ID", "Cód. Barra", "Descripción", "Categoría", "Marca", "Color", "P. Venta", "Stock" };

            if (Grilla1.Rows.Count == 0 || Grilla1.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                g.DrawString("No hay productos para imprimir.", subtitulo, Brushes.Gray, xPos, yPos);
                e.HasMorePages = false;
                return;
            }

            float xTemp = xPos;
            for (int i = 0; i < encabezados.Length; i++)
            {
                g.DrawString(encabezados[i], new Font(contenido, FontStyle.Bold), Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[i];
            }

            yPos += contenido.GetHeight(g) + 5;
            g.DrawLine(Pens.Black, xPos, yPos, xPos + columnasAncho.Sum(), yPos);
            yPos += 5;

            float alturaFila = contenido.GetHeight(g) + 5;

            while (filaActual < Grilla1.Rows.Count)
            {
                DataGridViewRow row = Grilla1.Rows[filaActual];
                if (row.IsNewRow)
                {
                    filaActual++;
                    continue;
                }

                xTemp = xPos;

                g.DrawString(GetStringValue(row.Cells["IdProducto"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[0];
                g.DrawString(GetStringValue(row.Cells["BarCode"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[1];
                g.DrawString(GetStringValue(row.Cells["Descripcion"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[2];
                g.DrawString(GetStringValue(row.Cells["Categoria"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[3];
                g.DrawString(GetStringValue(row.Cells["Marca"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[4];
                g.DrawString(GetStringValue(row.Cells["Color"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[5];
                g.DrawString("$ " + GetStringValue(row.Cells["PrecioVenta"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[6];
                g.DrawString(GetStringValue(row.Cells["Stock"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[7];

                yPos += alturaFila;
                filaActual++;

                // Paginación
                if (yPos + alturaFila > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }

        // --- Método Auxiliar ---

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

            if (cell.Value is bool b)
            {
                return b ? "Activo" : "Inactivo";
            }

            return cell.Value.ToString();
        }
    }
}