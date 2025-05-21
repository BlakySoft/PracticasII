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
    public partial class FormPAPELERABarrios: Form
    {
        #region Metodos
        public FormPAPELERABarrios()
        {
            InitializeComponent();
            LimpiarTextos();
            ListarBarriosPapelera();
        }
        private void Listar()
        {
            Grilla.Columns[0].Visible = true;
            Grilla.Columns[1].Visible = true;
            Grilla.Columns[2].Visible = false;

            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Descripcion";
        }
        private void LimpiarTextos()
        {
            LblIdBarrio.Text = "";
       }
        private void ListarBarriosPapelera()
        {
            ConeBarrios cone = new ConeBarrios();
            Grilla.DataSource = cone.ListarBarrioPapelera();
            Listar();
        }
        #endregion

        #region Botones
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnRecuperar_Click(object sender, EventArgs e)
        {
            ConeBarrios cone = new ConeBarrios();
            Barrio Recuperar = new Barrio
            {
                IdBarrio = int.Parse(LblIdBarrio.Text)
            };

            cone.RecuperarBarrio(Recuperar);

            try
            {
                MessageBox.Show("El barrio se recuperó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarTextos();
                ListarBarriosPapelera();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.ToString()}");
                throw;
            }

            iconButton1.Focus();
 
        }
        #endregion

        #region Interacciones con formulario
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text == "")
            {
                ListarBarriosPapelera();
            }
            else
            {
                ConeBarrios cone = new ConeBarrios();
                Barrio Buscar = new Barrio
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarPapelera(Buscar.Descripcion);
                Listar();
            }
        }
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblIdBarrio.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        #endregion
    }
}

