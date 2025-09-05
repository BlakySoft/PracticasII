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
            TxtNombre.Clear();
            TxtDocumento.Clear();
            TxtTelefono.Clear();
            TxtDomicilio.Clear();
        }
        #endregion

        #region Botones
        //private void BtnBarrios_Click(object sender, EventArgs e)
        //{
        //    unuFormABMBarrios form = new unuFormABMBarrios();
        //    form.ShowDialog();
        //}
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
                if (TxtNombre.Text == "")
                {
                    MessageBox.Show("Ingrese el Nombre y Apellido", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (TxtDocumento.Text == "")
                {
                    MessageBox.Show("Ingrese el Numero de documento ", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (TxtTelefono.Text == "")
                {
                    MessageBox.Show("Ingrese el Teléfono", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (TxtDomicilio.Text == "")
                {
                    MessageBox.Show("Ingrese la Domicilio", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (nuevo == true)
                {
                    ConeClientes cone = new ConeClientes();
                    Cliente Agregar = new Cliente
                    {
                        Nombre = TxtNombre.Text,
                        Documento = TxtDocumento.Text,
                        Telefono = TxtTelefono.Text,
                        Domicilio = TxtDomicilio.Text,
                        //IdBarrio = VarBarrio No se encuentra en uso
                    };

                    cone.AgregarCliente(Agregar);

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
            catch
            {
                MessageBox.Show("Error!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {

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

        #endregion


    }
}
