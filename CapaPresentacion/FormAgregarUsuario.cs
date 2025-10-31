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
    public partial class FormAgregarUsuarios: Form
    {
        #region Metodo y constructor
        public FormAgregarUsuarios()
        {
            InitializeComponent();
        }
        private void LimpiarTextos()
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtRepetir.Clear();
            cboTipo.SelectedIndex = 1;
            txtUsuario.Focus();
        }
        private void FormAgregarUsuarios_Load(object sender, EventArgs e)
        {
            cboTipo.Items.Clear();
            cboTipo.Items.Add("Administrador"); 
            cboTipo.Items.Add("Empleado");      
            cboTipo.SelectedIndex = 1;
            txtContraseña.PasswordChar = '•';
            txtRepetir.PasswordChar = '•';
        }
        #endregion

        #region Botones y eventos
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text) || string.IsNullOrWhiteSpace(txtRepetir.Text))
            {
                MessageBox.Show("Debe ingresar y repetir la contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtContraseña.Text != txtRepetir.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de usuario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tipoUsuario = (cboTipo.SelectedItem.ToString() == "Administrador") ? 1 : 2;

            CapaNegocio.Usuario nuevo = new CapaNegocio.Usuario
            {
                Usuarios = txtUsuario.Text.Trim(),
                Pass = txtContraseña.Text.Trim(),
                TipoUsuario = tipoUsuario
            };

            CapaDatos.ConeUsuario datos = new CapaDatos.ConeUsuario();

            try
            {
                if (datos.ExisteUsuario(nuevo.Usuarios))
                {
                    MessageBox.Show("El usuario ya existe. Elija otro nombre.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool agregado = datos.AgregarUsuario(nuevo);

                if (agregado)
                {
                    MessageBox.Show("Usuario agregado correctamente.", "Liz Showroom", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarTextos();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el usuario.", "Liz Showroom", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar usuario: " + ex.Message, "Liz Showroom", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarTextos();
        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtContraseña.Focus();
            }
        }
        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtRepetir.Focus();
            }
        }
        private void txtRepetir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                cboTipo.Focus();
            }
        }
        private void cboTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                BtnGrabar.Focus();
            }
        }
        #endregion
    }
}
