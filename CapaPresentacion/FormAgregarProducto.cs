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
    public partial class FormAgregarProducto: Form
    {

        #region Metodos y declaraciones
        Boolean nuevo;
        int VarRubro;
        public FormAgregarProducto()
        {
            InitializeComponent();
            PanelDatos.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;

            CargarCbo();
            LimpiarTextos();
        }
        private void CargarCbo()
        {
            ConeRubros cone = new ConeRubros();

            CboIdRubro.ValueMember = "IdRubro";
            CboIdRubro.DisplayMember = "Descripcion";
            CboIdRubro.DataSource = cone.ListarRubro();
        }
        private void LimpiarTextos()
        {
            LblIdProducto.Text = "";
            TxtDescripcion.Clear();
            TxtStock.Clear();
            TxtPrecio.Clear();
            TxtDetalle.Clear();
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
                    MessageBox.Show("Ingrese el detalle del producto.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                    ConeProductos cone = new ConeProductos();
                    Productos Agregar = new Productos
                    {
                        Descripcion = TxtDescripcion.Text,
                        Detalle = TxtDetalle.Text,
                        IdRubro = VarRubro,
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

            CargarCbo();
            BtnNuevo.Focus();
        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnRubro_Click(object sender, EventArgs e)
        {
            FormABMRubros form = new FormABMRubros();
            form.ShowDialog();
            CargarCbo();
        }
        private void CboIdRubro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VarRubro = int.Parse(CboIdRubro.SelectedValue.ToString());
        }
        #endregion


    }
}
