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
                if (txtUsuario.Text == "")
                {
                    MessageBox.Show("Ingrese un usuario");
                    txtUsuario.Focus();
                }
                else if (txtContraseña.Text == "")
                {
                    MessageBox.Show("Ingrese una contraseña");
                    txtContraseña.Focus();
                } else
                {
                    CapaDatos.ConeUsuario verif = new CapaDatos.ConeUsuario();
                    CapaNegocio.Usuario user = new CapaNegocio.Usuario();

                    //Comparar datos 

                    user.Nombre = txtUsuario.Text;
                    user.Pass = txtContraseña.Text;
                    bool existe = verif.VerificarUsuario(user);

                    if (existe == false)
                    {
                        lblAlerta.Text = "Usuario o contraseña incorrecta";
                        lblAlerta.Visible = true;
                        lblAlerta.ForeColor = Color.Red;
                    } else
                    {
                        using (FormMENU menu = new FormMENU())
                        {
                            this.Hide();
                            menu.ShowDialog();
                            this.Show();
                        }

                    }



                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("A ocurrido un error: " + ex.Message);

            }
        }
    }
}
