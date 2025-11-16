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
    public partial class FormINFORMEproveedores : Form
    {
        private ConeProveedores coneProveedores;
        private BindingSource bindingSourceProveedores;
        private int filaActual = 0;
        private string filtroCampo = "";
        private string filtroTexto = "";

        public FormINFORMEproveedores()
        {
            InitializeComponent();
            coneProveedores = new ConeProveedores();
            bindingSourceProveedores = new BindingSource();
            listar();
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
        }
        private void listar()
        {
            List<Proveedores> proveedores = coneProveedores.ListarProveedorINNERJOIN();

            bindingSourceProveedores.DataSource = proveedores;
            Grilla1.DataSource = bindingSourceProveedores;

            if (Grilla1.Columns.Contains("IdProveedor"))
                Grilla1.Columns["IdProveedor"].HeaderText = "ID";

            if (Grilla1.Columns.Contains("Documento"))
                Grilla1.Columns["Documento"].HeaderText = "CUIT";

            if (Grilla1.Columns.Contains("Domicilio"))
                Grilla1.Columns["Domicilio"].Visible = true;
            if (Grilla1.Columns.Contains("Localidad"))
                Grilla1.Columns["Localidad"].Visible = true;
            if (Grilla1.Columns.Contains("IdLocalidad"))
                Grilla1.Columns["IdLocalidad"].Visible = false;
            if (Grilla1.Columns.Contains("Estado"))
                Grilla1.Columns["Estado"].Visible = false;
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string textoFiltro = txtBuscar.Text.Trim().ToUpper();
            List<Proveedores> todosLosProveedores = coneProveedores.ListarProveedorINNERJOIN();
            List<Proveedores> proveedoresFiltrados;

            if (string.IsNullOrEmpty(textoFiltro))
            {
                proveedoresFiltrados = todosLosProveedores;
                filtroCampo = "Sin filtro";
                filtroTexto = "";
            }
            else
            {
                if (textoFiltro.Length == 1)
                {
                    proveedoresFiltrados = todosLosProveedores
                        .Where(p => !string.IsNullOrEmpty(p.Localidad) &&
                                    p.Localidad.Trim().ToUpper().StartsWith(textoFiltro))
                        .ToList();

                    filtroCampo = "Localidad (inicial)";
                    filtroTexto = textoFiltro;
                }
                else
                {
                    proveedoresFiltrados = todosLosProveedores
                        .Where(p => !string.IsNullOrEmpty(p.Localidad) &&
                                    p.Localidad.Trim().ToUpper() == textoFiltro)
                        .ToList();

                    filtroCampo = "Localidad";
                    filtroTexto = textoFiltro;
                }
            }

            bindingSourceProveedores.DataSource = proveedoresFiltrados;
            bindingSourceProveedores.ResetBindings(false);
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
            g.DrawString("Informe de Proveedores", subtitulo, Brushes.Black, xPos + anchoPagina / 2, yPos, formatoCentrado);
            yPos += espacio * 1.5f;

   
            if (!string.IsNullOrEmpty(filtroCampo))
            {
                g.DrawString($"Filtrado por: {filtroCampo} = {filtroTexto}",
                             new Font("Arial", 10, FontStyle.Italic),
                             Brushes.Gray,
                             xPos,
                             yPos);
                yPos += espacio;
            }

            string[] colKeys = new[] { "RazonSocial", "Documento", "Telefono", "Domicilio", "Localidad" };
            string[] encabezados = new[] { "Razón Social", "CUIT", "Teléfono", "Dirección", "Localidad" };
            float[] columnasAncho = new float[] { 180f, 90f, 110f, 200f, 90f };

            if (Grilla1.Rows.Count == 0 || Grilla1.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                g.DrawString("No hay proveedores para imprimir.", subtitulo, Brushes.Gray, xPos, yPos);
                e.HasMorePages = false;
                return;
            }

            float xTemp = xPos;
            for (int i = 0; i < encabezados.Length; i++)
            {
                g.DrawString(encabezados[i], new Font(contenido, FontStyle.Bold), Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[i] + 10;
            }

            yPos += contenido.GetHeight(g) + 6;
            g.DrawLine(Pens.Black, xPos, yPos, xPos + columnasAncho.Sum() + (10 * encabezados.Length), yPos);
            yPos += 6;

            float alturaFila = contenido.GetHeight(g) + 6;

 
            while (filaActual < Grilla1.Rows.Count)
            {
                DataGridViewRow row = Grilla1.Rows[filaActual];
                if (row.IsNewRow)
                {
                    filaActual++;
                    continue;
                }

                xTemp = xPos;

                for (int colIndex = 0; colIndex < colKeys.Length; colIndex++)
                {
                    string key = colKeys[colIndex];
                    string valor = GetCellTextSafe(row, key); // uso método seguro
                    g.DrawString(valor, contenido, Brushes.Black, xTemp, yPos);
                    xTemp += columnasAncho[colIndex] + 10;
                }

                yPos += alturaFila;
                filaActual++;

                if (yPos + alturaFila > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }
        private string GetCellTextSafe(DataGridViewRow row, string columnName)
        {
            try
            {
                if (row == null) return string.Empty;
                if (!Grilla1.Columns.Contains(columnName)) return string.Empty;
                var cell = row.Cells[columnName];
                return GetStringValue(cell);
            }
            catch
            {
                return string.Empty;
            }
        }
        private string GetStringValue(DataGridViewCell cell)
        {
            if (cell == null || cell.Value == null || cell.Value == DBNull.Value)
            {
                return string.Empty;
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