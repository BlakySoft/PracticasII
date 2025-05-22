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
    public partial class FormPAPELERAClientes: Form
    {
        #region Metodos
        public FormPAPELERAClientes()
        {
            InitializeComponent();
            LimpiarTextos();
            ListarClientesPapelera();
        } 
        private void LimpiarTextos()
        {
            LblIdClientes.Text = "";
        }
        private void ListarClientesPapelera()
        {
            ConeClientes cone = new ConeClientes();
            Grilla.DataSource = cone.ListarClientePapelera();

            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Nombre";
            Grilla.Columns[2].HeaderText = "Documento";
            Grilla.Columns[3].HeaderText = "Teléfono";
            Grilla.Columns[4].HeaderText = "Domicilio";
            //Grilla.Columns[5].HeaderText = "Barrio"; No se encuentra en uso
            Grilla.Columns[5].Visible = false;

        }
        #endregion

        #region Botones
        private void BtnRecuperar_Click(object sender, EventArgs e)
        {
            ConeClientes cone = new ConeClientes();
            Cliente Recuperar = new Cliente
            {
                IdCliente = int.Parse(LblIdClientes.Text)
            };

            cone.RecuperarCliente(Recuperar);

            try
            {
                MessageBox.Show("El Cliente se recuperó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarTextos();
                ListarClientesPapelera();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.ToString()}");
                throw;
            }

            BtnVolver.Focus();
        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Interacciones con formulario
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblIdClientes.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text == "")
            {
                ListarClientesPapelera();
            }
            else
            {
                ConeClientes cone = new ConeClientes();
                Cliente Buscar = new Cliente
                {
                    Nombre = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarPapelera(Buscar.Nombre);
               
            }
        }
        #endregion
    }
}
