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
    public partial class FormAgregarCliente: Form
    {
        #region Metodos y declaraciones

        Boolean nuevo;
  
        public FormAgregarCliente()
        {
            InitializeComponent();
            PanelDatos.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
        }
        private void LimpiarTextos()
        {
            LblIdCliente.Text = "";
            TxtApellido.Clear();
            TxtNombre.Clear();
            TxtDocumento.Clear();
            TxtTelefono.Clear();
            TxtDomicilio.Clear();
        }
        #endregion

        #region Botones
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;

            #region Enabled yes/no 
            //true
            BtnGrabar.Enabled = true;
            BtnCancelar.Enabled = true;
            PanelDatos.Enabled = true;
            //false
            BtnNuevo.Enabled = false;
            #endregion

            LimpiarTextos();
            TxtNombre.Focus();
        }
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtApellido.Text == "")
                {
                    MessageBox.Show("Ingrese el Apellido", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtApellido.Focus();
                }
                else if (TxtNombre.Text == "")
                {
                    MessageBox.Show("Ingrese el Nombre", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtNombre.Focus();
                }
                else if (TxtDocumento.Text == "")
                {
                    MessageBox.Show("Ingrese el Numero de documento", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtDocumento.Focus();
                }
                else if (TxtTelefono.Text == "")
                {
                    MessageBox.Show("Ingrese el Teléfono", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtTelefono.Focus();
                }
                else if (TxtDomicilio.Text == "")
                {
                    MessageBox.Show("Ingrese el Domicilio", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtDomicilio.Focus();
                }
                else
                {
                    DialogResult result = MessageBox.Show(
                        nuevo ? "¿Está seguro de agregar este cliente?" : "¿Está seguro de actualizar este cliente?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        ConeClientes cone = new ConeClientes();

                        if (nuevo)
                        {
                            Cliente Agregar = new Cliente
                            {
                                Apellido = TxtApellido.Text,
                                Nombre = TxtNombre.Text,
                                Documento = TxtDocumento.Text,
                                Telefono = TxtTelefono.Text,
                                Domicilio = TxtDomicilio.Text
                            };

                            cone.AgregarCliente(Agregar);
                            MessageBox.Show("Cliente agregado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Cliente Actualizar = new Cliente
                            {
                                IdCliente = int.Parse(LblIdCliente.Text),
                                Apellido = TxtApellido.Text,
                                Nombre = TxtNombre.Text,
                                Documento = TxtDocumento.Text,
                                Telefono = TxtTelefono.Text,
                                Domicilio = TxtDomicilio.Text
                            };

                            cone.ActualizarCliente(Actualizar);
                            MessageBox.Show("Cliente actualizado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        #region Enabled yes/no
                        BtnNuevo.Enabled = true;
                        BtnGrabar.Enabled = false;
                        BtnCancelar.Enabled = false;
                        PanelDatos.Enabled = false;
                        #endregion

                        LimpiarTextos();
                        BtnNuevo.Focus();
                    }
                    else
                    {
                        return; 
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                BtnNuevo.Enabled = true;
                BtnGrabar.Enabled = false;
                BtnCancelar.Enabled = false;
                PanelDatos.Enabled = false;
                LimpiarTextos();
                BtnNuevo.Focus();
            }
         
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            #region Enabled yes/no
            //true
            BtnNuevo.Enabled = true;
            //false
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            PanelDatos.Enabled = false;
            #endregion

            BtnNuevo.Focus();
        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Close();       
        }


        #endregion

        #region Validaciones
        private void TxtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Cancela la tecla
               // MessageBox.Show("Solo se permiten letras en el apellido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; 
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
               // MessageBox.Show("Solo se permiten letras en el Nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void TxtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo números
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
               // MessageBox.Show("Solo se permiten números en Documento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Limitar a 8 caracteres
            TextBox txt = sender as TextBox;
            if (txt.Text.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Enter → siguiente control
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo números
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
              //  MessageBox.Show("Solo se permiten números en Teléfono.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Limitar a 15 caracteres
            TextBox txt = sender as TextBox;
            if (txt.Text.Length >= 15 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Enter → siguiente control
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void TxtDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar)
                && e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != '.' && e.KeyChar != '/')
            {
                e.Handled = true;
              //  MessageBox.Show("Caracter no válido en Dirección.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TextBox txt = sender as TextBox;
            if (txt.Text.Length >= 50 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Enter → siguiente control
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion
    }
}
