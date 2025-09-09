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
            Grilla.Columns[0].HeaderText = "Codigo";
            Grilla.Columns[0].Width = 85;
            Grilla.Columns[1].Width = 120; // Apellido
            Grilla.Columns[2].Width = 120; // Nombre
            Grilla.Columns[3].Width = 130;
            Grilla.Columns[4].Width = 130;
            Grilla.Columns[5].Width = 300;

            Grilla.Columns[1].HeaderText = "Apellido"; // NUEVO
            Grilla.Columns[2].HeaderText = "Nombre";
            Grilla.Columns[3].HeaderText = "Documento";
            Grilla.Columns[4].HeaderText = "Teléfono";
            Grilla.Columns[5].HeaderText = "Domicilio";
            Grilla.Columns[6].Visible = false;

        }
        #endregion

        #region Botones
        private void iconButton1_Click(object sender, EventArgs e)
        {
            TxtBuscar.Clear();
        }
        private void BtnRecuperar_Click(object sender, EventArgs e)
        {
            ConeClientes cone = new ConeClientes();
            Cliente Recuperar = new Cliente
            {
                IdCliente = int.Parse(LblIdClientes.Text)
            };

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea recuperar este cliente?",
                "Confirmar recuperación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                cone.RecuperarCliente(Recuperar);

                try
                {
                    MessageBox.Show("El Cliente se recuperó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
            {
                MessageBox.Show("Recuperación cancelada.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region Interacciones con formulario
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
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
