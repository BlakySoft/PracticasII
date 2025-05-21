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
    public partial class FormBuscarMaterias: Form
    {
        #region Metodos y declaraciones
        int IdMateria, Stock;
        string Descripcion, Detalle;
        decimal Precio;
        public FormBuscarMaterias()
        {
            InitializeComponent();
            Listar();
        }
        private void Listar()
        {
            ConeMateria cone = new ConeMateria();
            Grilla.DataSource = cone.Listar();

            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Descripcion";
            Grilla.Columns[2].HeaderText = "Detalle";
            Grilla.Columns[3].HeaderText = "Precio";
            Grilla.Columns[4].HeaderText = "Stock";
            Grilla.Columns[5].Visible = false;
        }
        #endregion

        #region Interaccion
        private void Grilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IdMateria != 0)
                {
                    FormCOMPRAS compras = Owner as FormCOMPRAS;
                    compras.TxtIdMateria.Text = IdMateria.ToString();
                    compras.TxtDescripcion.Text = Descripcion;
                    compras.TxtDetalle.Text = Detalle;
                    compras.TxtPrecio.Text = Precio.ToString();
                    compras.TxtStock.Text = Stock.ToString();

                    compras.Precio = Precio;
                    
                    Close();
                }
                else
                {
                    MessageBox.Show("Seleccione una materia prima.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede seleccionar desde la cabecera.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text == "")
            {
                Listar();
            }
            else
            {
                ConeMateria cone = new ConeMateria();
                Materia Buscar = new Materia
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.Buscar(Buscar.Descripcion);
                Listar();
            }
        }
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IdMateria = int.Parse(Grilla.Rows[e.RowIndex].Cells[0].Value.ToString());
                Descripcion = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();
                Detalle = Grilla.Rows[e.RowIndex].Cells[2].Value.ToString();
                Precio = decimal.Parse(Grilla.Rows[e.RowIndex].Cells[3].Value.ToString());
                Stock = int.Parse(Grilla.Rows[e.RowIndex].Cells[4].Value.ToString());
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
