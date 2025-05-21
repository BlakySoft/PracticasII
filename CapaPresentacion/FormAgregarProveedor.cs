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
            try
            {
                if (TxtRazon.Text == "")
                {
                    MessageBox.Show("Ingrese la Razon Social", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("Ingrese la Direccion", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (nuevo == true)
                {
                    ConeProveedores cone = new ConeProveedores();
                    Proveedores Agregar = new Proveedores
                    {
                        RazonSocial = TxtRazon.Text,
                        Documento = TxtDocumento.Text,
                        Telefono = TxtTelefono.Text,
                        Domicilio = TxtDomicilio.Text,
                        IdLocalidad = VarLocalidad
                    };

                    cone.AgregarProveedor(Agregar);

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
    }
}
