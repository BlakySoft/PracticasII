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
            Grilla.DataSource = listar.Listar();
            Grilla.Columns[0].HeaderText = "Codigo";
            Grilla.Columns[0].Width = 70;
            Grilla.Columns[1].Width = 140;
            Grilla.Columns[2].Width = 100;
            Grilla.Columns[3].Width = 60;
            Grilla.Columns[4].Width = 60;
            Grilla.Columns[5].Width = 60;
            Grilla.Columns[1].HeaderText = "Descripcion";
            Grilla.Columns[2].HeaderText = "Detalle";
            Grilla.Columns[3].HeaderText = "Rubro";
            Grilla.Columns[4].HeaderText = "Precio";
            Grilla.Columns[5].HeaderText = "Stock";
            Grilla.Columns[6].Visible = false;

        }
        #endregion

        #region Interaccion con formulario
        private void Grilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IdProducto != 0)
                {
                    FormPEDIDOS pedidos = Owner as FormPEDIDOS;
                    pedidos.TxtIdProducto.Text = IdProducto.ToString();
                    pedidos.TxtDescripcion.Text = Descripcion;
                    pedidos.TxtDetalle.Text = Detalle;
                    pedidos.TxtPrecio.Text = Precio.ToString();
                    pedidos.TxtStock.Text = Stock.ToString();

                    pedidos.Precio = Precio;

                    Close();
                }
                else
                {
                    MessageBox.Show("Seleccione un producto.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede seleccionar desde la cabecera.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IdProducto = int.Parse(Grilla.Rows[e.RowIndex].Cells[0].Value.ToString());
                Descripcion = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();
                Detalle = Grilla.Rows[e.RowIndex].Cells[2].Value.ToString();
                Precio = decimal.Parse(Grilla.Rows[e.RowIndex].Cells[4].Value.ToString());
                Stock = int.Parse(Grilla.Rows[e.RowIndex].Cells[5].Value.ToString());
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
