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
    public partial class FormAgregarMateria: Form
    {
        #region Metodos y declaraciones
        Boolean nuevo;
        public FormAgregarMateria()
        {
            InitializeComponent();
            LimpiarTextos();
            PanelDatos.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;

        }
        private void LimpiarTextos()
        {
            LblIdMateria.Text = "";
            TxtDescripcion.Clear();
            TxtDetalle.Clear();
            TxtPrecio.Clear();
            TxtStock.Clear();
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
            TxtDescripcion.Focus();
        }
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtDescripcion.Text == "")
                {
                    MessageBox.Show("Ingrese la Descripción.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (TxtDetalle.Text == "")
                {
                    MessageBox.Show("Ingrese el detalle de la Materia Prima.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (TxtStock.Text == "")
                {
                    MessageBox.Show("Ingrese el Stock.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (TxtPrecio.Text == "")
                {
                    MessageBox.Show("Ingrese el Precio.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (nuevo == true)
                {

                    ConeMateria cone = new ConeMateria();
                    Materia Agregar = new Materia
                    {
                        Descripcion = TxtDescripcion.Text,
                        Detalle = TxtDetalle.Text,
                        Precio = Convert.ToDecimal(TxtPrecio.Text),
                        Stock = int.Parse(TxtStock.Text),
                    };

                    cone.Agregar(Agregar);

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
                PanelDatos.Enabled = false;
                BtnGrabar.Enabled = false;
                BtnCancelar.Enabled = false;
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
            PanelDatos.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
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
