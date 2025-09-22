using CapaPresentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginTry
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("Ingrese un usuario");
                    txtUsuario.Focus();
                }
                else if (string.IsNullOrWhiteSpace(txtContraseña.Text))
                {
                    MessageBox.Show("Ingrese una contraseña");
                    txtContraseña.Focus();
                }
                else
                {
                    CapaDatos.ConeUsuario verif = new CapaDatos.ConeUsuario();
                    CapaNegocio.Usuario user = new CapaNegocio.Usuario();

                    // Comparar datos
                    user.Nombre = txtUsuario.Text;
                    user.Pass = txtContraseña.Text;
                    bool existe = verif.VerificarUsuario(user);

                    if (!existe)
                    {
                        lblAlerta.Text = "Usuario o contraseña incorrecta";
                        lblAlerta.Visible = true;
                        lblAlerta.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; 
                txtContraseña.Focus(); 
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black ;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
          if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.IndianRed;
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.Black;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.ForeColor = Color.IndianRed;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


    }
}
