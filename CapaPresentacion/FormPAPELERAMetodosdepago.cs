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
    public partial class FormPAPELERAMetodosdepago : Form
    {
        #region Metodos
        public FormPAPELERAMetodosdepago()
        {
            InitializeComponent();
            LimpiarTextos();
            ListarPapelera();
        }
        private void Listar()
        {
            Grilla.Columns[0].Visible = true;
            Grilla.Columns[1].Visible = true;
            Grilla.Columns[2].Visible = false;

            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Metodo de pago";
        }
        private void LimpiarTextos()
        {
            LblIdMetodos.Text = "";
        }
        private void ListarPapelera()
        {
            ConeMetododepago cone = new ConeMetododepago();
            Grilla.DataSource = cone.ListarPapelera();
            Listar();
        }
        #endregion

        #region Botones
        private void BtnRecuperar_Click(object sender, EventArgs e)
        {

            ConeMetododepago cone = new ConeMetododepago();
            Metododepago Recuperar = new Metododepago
            {
                IdMetodo = int.Parse(LblIdMetodos.Text)
            };

            cone.Recuperar(Recuperar);

            try
            {
                MessageBox.Show("El Metodo de pago se recuperó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarTextos();
                ListarPapelera();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.ToString()}");
                throw;
            }

            iconButton1.Focus();
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Interacciones con formulario
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblIdMetodos.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text == "")
            {
                ListarPapelera();
            }
            else
            {
                ConeMetododepago cone = new ConeMetododepago();
                Metododepago Buscar = new Metododepago
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarPapelera(Buscar.Descripcion);
                Listar();
            }
        }
        #endregion
    }
}
