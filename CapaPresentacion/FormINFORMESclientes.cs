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
    public partial class FormINFORMESclientes : Form
    {
        private ConeClientes coneClientes;
        private BindingSource bindingSourceClientes;
        private int filaActual = 0;
        private string filtroCampo = "";
        private string filtroTexto = "";

        public FormINFORMESclientes()
        {
            InitializeComponent();
            coneClientes = new ConeClientes();
            bindingSourceClientes = new BindingSource();
            listar();
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
        }

        // --- Métodos de Listado y Eventos ---

        private void listar()
        {
            List<Cliente> clientes = coneClientes.ListarCliente();

            bindingSourceClientes.DataSource = clientes;
            Grilla1.DataSource = bindingSourceClientes;

            Grilla1.Columns["IdCliente"].HeaderText = "ID";
            Grilla1.Columns["Estado"].Visible = false;
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToUpper();
            List<Cliente> todos = coneClientes.ListarCliente();
            List<Cliente> filtrados;

            if (string.IsNullOrEmpty(texto))
            {
                filtrados = todos;
                filtroCampo = "Sin filtro";
                filtroTexto = "";
            }
            else if (texto.All(char.IsDigit))
            {
                filtrados = todos
                    .Where(c => c.Documento != null && c.Documento.Contains(texto))
                    .ToList();
                filtroCampo = "DNI";
                filtroTexto = texto;
            }
            else
            {
                if (texto.Length == 1)
                {
                    filtrados = todos
                        .Where(c => !string.IsNullOrEmpty(c.Apellido) &&
                                    c.Apellido.ToUpper().StartsWith(texto))
                        .ToList();
                    filtroCampo = "Apellido (inicial)";
                }
                else
                {
                    filtrados = todos
                        .Where(c => !string.IsNullOrEmpty(c.Apellido) &&
                                    c.Apellido.ToUpper().Contains(texto))
                        .ToList();
                    filtroCampo = "Apellido";
                }

                filtroTexto = texto;
            }

            bindingSourceClientes.DataSource = filtrados;
            bindingSourceClientes.ResetBindings(false);
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

            g.DrawString("Liz Showroom ", titulo, Brushes.Black, xPos + anchoPagina / 2, yPos, formatoCentrado);
            yPos += espacio;
            g.DrawString("Informe de Clientes", subtitulo, Brushes.Black, xPos + anchoPagina / 2, yPos, formatoCentrado);
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

            // 🔸 Columnas
            float[] columnasAncho = { 120, 120, 80, 100, 200 };
            string[] encabezados = { "Nombre", "Apellido", "Documento", "Teléfono", "Dirección" };

            if (Grilla1.Rows.Count == 0 || Grilla1.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                g.DrawString("No hay clientes para imprimir.", subtitulo, Brushes.Gray, xPos, yPos);
                e.HasMorePages = false;
                return;
            }

            // Encabezados
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

                g.DrawString(GetStringValue(row.Cells["Nombre"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[0];
                g.DrawString(GetStringValue(row.Cells["Apellido"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[1];
                g.DrawString(GetStringValue(row.Cells["Documento"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[2];
                g.DrawString(GetStringValue(row.Cells["Telefono"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[3];
                g.DrawString(GetStringValue(row.Cells["Domicilio"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[4];

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
        private string GetStringValue(DataGridViewCell cell)
        {
            if (cell == null || cell.Value == null || cell.Value == DBNull.Value)
            {
                return string.Empty;
            }

            if (cell.Value is bool b)
            {
                return b ? "Sí" : "No";
            }

            return cell.Value.ToString();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
        }
    }
}
