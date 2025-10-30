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

        public FormINFORMEproveedores()
        {
            InitializeComponent();
            coneProveedores = new ConeProveedores();
            bindingSourceProveedores = new BindingSource();
            listar();
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
        }

        // --- Métodos de Gestión de Datos y Visualización ---

        private void listar()
        {
            List<Proveedores> proveedores = coneProveedores.ListarProveedorINNERJOIN();

            bindingSourceProveedores.DataSource = proveedores;
            Grilla1.DataSource = bindingSourceProveedores;

            Grilla1.Columns["IdProveedor"].HeaderText = "ID";
            Grilla1.Columns["Localidad"].Visible = false;
            Grilla1.Columns["IdLocalidad"].Visible = false;
            Grilla1.Columns["Estado"].Visible = false;
        }

        // --- Lógica de Filtrado (Buscador) ---

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string textoFiltro = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(textoFiltro))
            {
                listar();
            }
            else
            {
                List<Proveedores> todosLosProveedores = coneProveedores.ListarProveedorINNERJOIN();

                var proveedoresFiltrados = todosLosProveedores
                    .Where(p => p.RazonSocial.IndexOf(textoFiltro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 p.Documento.IndexOf(textoFiltro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 p.Telefono.IndexOf(textoFiltro, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

                bindingSourceProveedores.DataSource = proveedoresFiltrados;
                bindingSourceProveedores.ResetBindings(false);
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
            Font contenido = new Font("Arial", 10, FontStyle.Regular);
            float espacio = 30;

            StringFormat formatoCentrado = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            g.DrawString("Liz Showroom", titulo, Brushes.Black, xPos + anchoPagina / 2, yPos, formatoCentrado);
            yPos += espacio;
            g.DrawString("Informe de Proveedores", subtitulo, Brushes.Black, xPos + anchoPagina / 2, yPos, formatoCentrado);
            yPos += espacio * 1.5f;

            float[] columnasAncho = { 50, 150, 100, 100, 150 };
            string[] encabezados = { "ID", "Razón Social", "Documento", "Teléfono", "Domicilio" };

            if (Grilla1.Rows.Count == 0 || Grilla1.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                g.DrawString("No hay datos de proveedores para imprimir.", subtitulo, Brushes.Gray, xPos, yPos);
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

                g.DrawString(GetStringValue(row.Cells["IdProveedor"]), contenido, Brushes.Black, xTemp, yPos);
                xTemp += columnasAncho[0];
                g.DrawString(GetStringValue(row.Cells["RazonSocial"]), contenido, Brushes.Black, xTemp, yPos);
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

        // --- Método Auxiliar ---

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
    }
}