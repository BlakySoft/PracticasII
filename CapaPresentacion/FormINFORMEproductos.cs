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
        private string filtroCampo = "";
        private string filtroTexto = "";
        public FormINFORMEproductos()
        {
            InitializeComponent();
            coneProductos = new ConeProductos();
            bindingSourceProductos = new BindingSource();
            listar();
            CargarCbo();
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
        }

        private void CargarCbo()
        {
            cboFiltro.Items.Clear();

            cboFiltro.Items.Add("Categoría");
            cboFiltro.Items.Add("Marca");
            cboFiltro.Items.Add("Descripción");
            cboFiltro.Items.Add("Color");

            cboFiltro.SelectedIndex = 0;
        }
        private void listar()
        {
            List<Productos> productos = coneProductos.ListarINNERJOIN();

            bindingSourceProductos.DataSource = productos;
            Grilla1.DataSource = bindingSourceProductos;
            Grilla1.Columns["IdProducto"].HeaderText = "ID";
            Grilla1.Columns["BarCode"].HeaderText = "Cód. Barra";
            Grilla1.Columns["Descripcion"].HeaderText = "Descripción";
            Grilla1.Columns["Categoria"].HeaderText = "Categoría";
            Grilla1.Columns["Marca"].HeaderText = "Marca";
            Grilla1.Columns["Color"].HeaderText = "Color";
            Grilla1.Columns["PrecioVenta"].HeaderText = "P. Venta";
            Grilla1.Columns["Stock"].HeaderText = "Stock";

            Grilla1.Columns["PrecioCompra"].Visible = false;
            Grilla1.Columns["BarCode"].Visible=false;
            Grilla1.Columns["Detalle"].Visible = false;
            Grilla1.Columns["IdCat"].Visible = false;
            Grilla1.Columns["IdMarca"].Visible = false;
            Grilla1.Columns["IdColor"].Visible = false;
            Grilla1.Columns["Estado"].Visible = false;
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtroCampo = cboFiltro.Text;
            filtroTexto = txtBuscar.Text;
            string textoFiltro = txtBuscar.Text.Trim().ToUpperInvariant();
            string campoFiltro = cboFiltro.SelectedItem?.ToString();

            // Si no hay filtro o texto, mostrar todo
            if (string.IsNullOrEmpty(textoFiltro) || string.IsNullOrEmpty(campoFiltro))
            {
                listar();
                return;
            }

            // Traemos todos los productos desde la base
            var todos = coneProductos.ListarINNERJOIN();

            IEnumerable<Productos> filtrados = todos;

            switch (campoFiltro)
            {
                case "Categoría":
                    filtrados = todos.Where(p =>
                        (p.Categoria ?? string.Empty)
                        .ToUpperInvariant()
                        .StartsWith(textoFiltro));
                    break;

                case "Marca":
                    filtrados = todos.Where(p =>
                        (p.Marca ?? string.Empty)
                        .ToUpperInvariant()
                        .StartsWith(textoFiltro));
                    break;

                case "Descripción":
                    filtrados = todos.Where(p =>
                        (p.Descripcion ?? string.Empty)
                        .ToUpperInvariant()
                        .StartsWith(textoFiltro));
                    break;

                case "Color":
                    filtrados = todos.Where(p =>
                        (p.Color ?? string.Empty)
                        .ToUpperInvariant()
                        .StartsWith(textoFiltro));
                    break;
            }

            Grilla1.DataSource = filtrados.ToList();
        }
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
        private void ImprimirGrilla(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            float margenIzquierdo = e.MarginBounds.Left;
            float margenSuperior = e.MarginBounds.Top;
            float yPos = margenSuperior;
            float xPos = margenIzquierdo;
            float anchoPagina = e.MarginBounds.Width;

            Font titulo = new Font("Arial", 20, FontStyle.Bold);
            Font subtitulo = new Font("Arial", 13, FontStyle.Regular);
            Font contenido = new Font("Arial", 10, FontStyle.Regular);
            float espacio = 28;

            StringFormat formatoCentro = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Título bla bla
            g.DrawString("Liz Showroom ", titulo, Brushes.Black, xPos + anchoPagina / 2, yPos, formatoCentro);
            yPos += espacio;
            g.DrawString("Informe de Productos", subtitulo, Brushes.Black, xPos + anchoPagina / 2, yPos, formatoCentro);
            yPos += espacio * 1.5f;

            // Mostrar filtro si hay
            if (!string.IsNullOrEmpty(filtroCampo) && !string.IsNullOrEmpty(filtroTexto))
            {
                g.DrawString($"Filtrado por: {filtroCampo} = {filtroTexto}",
                             new Font("Arial", 10, FontStyle.Italic),
                             Brushes.DimGray,
                             xPos + 10,
                             yPos);
                yPos += espacio;
            }

            // ====== Encabezados de columnas ======
            float[] columnasAncho = { 160, 100, 100, 80, 100, 70 };
            string[] encabezados = { "Descripción", "Categoría", "Marca", "Color", "Precio", "Stock" };

            if (Grilla1.Rows.Count == 0 || Grilla1.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                g.DrawString("No hay productos para imprimir.", subtitulo, Brushes.Gray, xPos, yPos);
                e.HasMorePages = false;
                return;
            }

            float xTemp = xPos + 15;
            for (int i = 0; i < encabezados.Length; i++)
            {
                g.DrawString(encabezados[i], new Font(contenido, FontStyle.Bold), Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[i] + 15; // Más espacio entre columnas xdddddd
            }

            yPos += contenido.GetHeight(g) + 8;
            g.DrawLine(Pens.Black, xPos, yPos, xPos + columnasAncho.Sum() + 120, yPos);
            yPos += 8;

            float alturaFila = contenido.GetHeight(g) + 6;

            // Filas de productos 
            while (filaActual < Grilla1.Rows.Count)
            {
                DataGridViewRow row = Grilla1.Rows[filaActual];
                if (row.IsNewRow)
                {
                    filaActual++;
                    continue;
                }

                xTemp = xPos + 15;

                g.DrawString(GetStringValue(row.Cells["Descripcion"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[0] + 15;

                g.DrawString(GetStringValue(row.Cells["Categoria"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[1] + 15;

                g.DrawString(GetStringValue(row.Cells["Marca"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[2] + 15;

                g.DrawString(GetStringValue(row.Cells["Color"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[3] + 15;

                // esto le saca los decimales 
                string precio = GetStringValue(row.Cells["PrecioVenta"]);
                if (decimal.TryParse(precio, out decimal p))
                    precio = "$ " + ((int)p).ToString();

                g.DrawString(precio, contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[4] + 15;

                g.DrawString(GetStringValue(row.Cells["Stock"]), contenido, Brushes.Black, xTemp, yPos);

                yPos += alturaFila;
                filaActual++;

                // salta pagina para evitar error
                if (yPos + alturaFila > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

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

            if (cell.Value is bool b)
            {
                return b ? "Activo" : "Inactivo";
            }

            return cell.Value.ToString();
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
        }
    }
}