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
    public partial class FormBuscarProducto: Form
    {
        #region Metodos y Declaraciones
        int IdProducto, Stock;
        string Descripcion, Detalle;
        decimal Precio;

        public FormBuscarProducto()
        {
            InitializeComponent();
            Listar();
        }

        public void Listar()
        {

            ConeProductos listar = new ConeProductos();
            Grilla.DataSource = listar.ListarINNERJOIN();
            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[3].Visible = false;
            Grilla.Columns[4].Visible = false;
            Grilla.Columns[5].Visible = false;
            Grilla.Columns[11].Visible = false;

            Grilla.Columns[0].Width = 83;
            Grilla.Columns[1].Width = 140;
            Grilla.Columns[2].Width = 110;
            Grilla.Columns[6].Width = 110;
            Grilla.Columns[7].Width = 110;
            Grilla.Columns[8].Width = 130;
        }
        #endregion

        #region Interaccion con formulario
        private void Grilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = Grilla.Rows[e.RowIndex];

                int idProducto = Convert.ToInt32(fila.Cells["IdProducto"].Value);
                string descripcion = fila.Cells["Descripcion"].Value?.ToString() ?? "";
                string detalle = fila.Cells["Detalle"].Value?.ToString() ?? "";
                decimal precio = Convert.ToDecimal(fila.Cells["PrecioVenta"].Value);
                int stock = Convert.ToInt32(fila.Cells["Stock"].Value);

                FormVENTAS ventas = Owner as FormVENTAS;

                if (ventas != null)
                {
                    ventas.TxtIdProducto.Text = idProducto.ToString();
                    ventas.TxtDescripcion.Text = descripcion;
                    ventas.TxtDetalle.Text = detalle;
                    ventas.TxtPrecio.Text = precio.ToString("0.00");
                    ventas.TxtStock.Text = stock.ToString();

                    ventas.Precio = precio;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se encontró el formulario padre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto válido.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text != "")
            {
                ConeProductos cone = new ConeProductos();
                Productos Buscar = new Productos
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.Buscar(Buscar.Descripcion);

            }
            else
            {
                Listar();
            }
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            TxtBuscar.Clear();
        }
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) 
                {
                    IdProducto = int.Parse(Grilla.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Descripcion = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Detalle = Grilla.Rows[e.RowIndex].Cells[2].Value.ToString();
                    Precio = decimal.Parse(Grilla.Rows[e.RowIndex].Cells[9].Value.ToString()); // Corrige índice
                    Stock = int.Parse(Grilla.Rows[e.RowIndex].Cells[10].Value.ToString());     // Corrige índice
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede seleccionar desde la cabecera.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

    }
}
