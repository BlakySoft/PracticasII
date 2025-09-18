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
    public partial class FormAgregarProveedor: Form
    {
        #region Metodos y declaraciones

        Boolean nuevo;
        int VarLocalidad;
        public FormAgregarProveedor()
        {
            InitializeComponent();
            CargarCbo();
            PanelDatos.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
        }
        private void CargarCbo()
        {
            ConeLocalidades cone = new ConeLocalidades();

            CboIdLocalidad.ValueMember = "IdLocalidad";
            CboIdLocalidad.DisplayMember = "Descripcion";
            CboIdLocalidad.DataSource = cone.ListarLocalidad();
        }
        private void LimpiarTextos()
        {
            LblIdProveedor.Text = "";
            TxtRazon.Clear();
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

            CargarCbo();
            LimpiarTextos();
            TxtRazon.Focus();
        }
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(TxtRazon.Text))
            {
                MessageBox.Show("Ingrese la Razon Social", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtDocumento.Text))
            {
                MessageBox.Show("Ingrese el Numero de documento", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtTelefono.Text))
            {
                MessageBox.Show("Ingrese el Teléfono", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtDomicilio.Text))
            {
                MessageBox.Show("Ingrese la Dirección", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (nuevo)
            {
                // Preguntar antes de agregar
                var resultado = MessageBox.Show(
                    "¿Está seguro que desea agregar este proveedor?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado != DialogResult.Yes) return;

                // Crear y agregar proveedor
                var cone = new ConeProveedores();
                var proveedor = new Proveedores
                {
                    RazonSocial = TxtRazon.Text,
                    Documento = TxtDocumento.Text,
                    Telefono = TxtTelefono.Text,
                    Domicilio = TxtDomicilio.Text,
                    IdLocalidad = VarLocalidad
                };
                cone.AgregarProveedor(proveedor);
           
                #region Enabled yes/no
                //true
                BtnNuevo.Enabled = true;
                //false
                BtnGrabar.Enabled = false;
                BtnCancelar.Enabled = false;
                PanelDatos.Enabled = false;
                #endregion

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
        private void BtnLocalidad_Click(object sender, EventArgs e)
        {
            FormABMLocalidades form = new FormABMLocalidades();
            form.ShowDialog();
        }

        #endregion

        #region Interaccion
        private void CboIdLocalidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VarLocalidad = int.Parse(CboIdLocalidad.SelectedValue.ToString());
        }
        #endregion

        #region Validadores
        private void TxtRazon_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Letras, números, control y espacio
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void TxtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
              //  MessageBox.Show("Solo se permiten números en el Cuit.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Limitar a 8 caracteres
            TextBox txt = sender as TextBox;
            if (txt.Text.Length >= 11 && !char.IsControl(e.KeyChar))
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
             //   MessageBox.Show("Solo se permiten números en Teléfono.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            // Permitir letras, números, espacios y algunos símbolos básicos
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar)
                && e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != '.' && e.KeyChar != '/')
            {
                e.Handled = true;
               // MessageBox.Show("Caracter no válido en Dirección.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Limitar a 50 caracteres
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
        private void CboIdLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                if (CboIdLocalidad.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar una Localidad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CboIdLocalidad.Focus();
                    return;
                }

                SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion
    }
}
