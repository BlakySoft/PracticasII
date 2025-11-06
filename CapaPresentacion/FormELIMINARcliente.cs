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
    public partial class FormELIMINARusuarios: Form
    {
        public FormELIMINARusuarios()
        {
            InitializeComponent();
        }

        private void FormELIMINARusuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }
        private void CargarUsuarios()
        {
            CapaDatos.ConeUsuario datos = new CapaDatos.ConeUsuario();
            var lista = datos.ListarUsuarios();

            Grilla.DataSource = lista;

            Grilla.Columns["Id"].HeaderText = "ID";
            Grilla.Columns["Usuarios"].HeaderText = "Usuario";
            Grilla.Columns["TipoUsuario"].HeaderText = "Tipo de Usuario";
            Grilla.Columns[2].Visible = false;
            Grilla.Columns[3].HeaderText = "Tipo de Usuario";   

            foreach (DataGridViewRow row in Grilla.Rows)
            {
                if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() == "1")
                {
                    Grilla.Rows[row.Index].Cells[3].Value = "Administrador";
                }
                else if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() == "2")
                {
                    Grilla.Rows[row.Index].Cells[3].Value = "Empleado";
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un usuario para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuario = Convert.ToInt32(Grilla.CurrentRow.Cells["Id"].Value);
            string nombre = Grilla.CurrentRow.Cells["Usuarios"].Value.ToString();

            DialogResult confirmar = MessageBox.Show($"¿Está seguro de eliminar al usuario '{nombre}'?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                CapaDatos.ConeUsuario datos = new CapaDatos.ConeUsuario();
                bool eliminado = datos.EliminarUsuario(idUsuario);

                if (eliminado)
                {
                    MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Grilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnEliminar.PerformClick(); 
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

