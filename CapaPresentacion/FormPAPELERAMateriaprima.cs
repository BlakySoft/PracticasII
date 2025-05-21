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
    public partial class FormPAPELERAMateriaprima: Form
    {
        #region Metodos
        public FormPAPELERAMateriaprima()
        {
            InitializeComponent();
            LimpiarTextos();
            ListarPapelera();
        }
        private void LimpiarTextos()
        {
            LblIdMateria.Text = "";
        }
        private void ListarPapelera()
        {
            ConeMateria cone = new ConeMateria();
            Grilla.DataSource = cone.ListarPapelera();

            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Descripcion";
            Grilla.Columns[2].HeaderText = "Detalle";
            Grilla.Columns[3].HeaderText = "Precio";
            Grilla.Columns[4].HeaderText = "Stock";
            Grilla.Columns[5].Visible = false;

        }

        #endregion

        #region Botones
        private void BtnRecuperar_Click(object sender, EventArgs e)
        {
            ConeMateria cone = new ConeMateria();
            Materia Recuperar = new Materia
            {
                IdMateria = int.Parse(LblIdMateria.Text)
            };

            cone.Recuperar(Recuperar);

            try
            {
                MessageBox.Show("La materia prima se recuperó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        #region Interaccion con Formulario
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblIdMateria.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text == "")
            {
                ListarPapelera();
            }
            else
            {
                ConeMateria cone = new ConeMateria();
                Materia Buscar = new Materia
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarPapelera(Buscar.Descripcion);

            }
        }
        #endregion
    }
}
