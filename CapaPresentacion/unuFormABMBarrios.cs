using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class unuFormABMBarrios: Form
    {
        #region Metodos y declaraciones
        Boolean nuevo;
        public unuFormABMBarrios()
        {
            InitializeComponent();
            BtnModificar.Enabled = false;
            TxtDescripcion.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;

            LimpiarTextos();
            ListarBarrios();
        }
       
        private void LimpiarTextos()
        {
            LblIdBarrio.Text = "";
            TxtDescripcion.Clear();
        }
        private void ListarBarrios()
        {
            ConeBarrios cone = new ConeBarrios();
            Grilla.DataSource = cone.ListarBarrio();
            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Barrio";
            Grilla.Columns[2].Visible = false;

        }
        #endregion

        #region Botones
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ListarBarrios();
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {

            #region Enabled yes/no
            //true
            nuevo = true;
            TxtDescripcion.Enabled = true;
            BtnGrabar.Enabled = true;
            BtnCancelar.Enabled = true;
            //false
            TxtBuscar.Enabled = false;   
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
                    MessageBox.Show("Ingrese el Barrio", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (nuevo == true)
                {
                    ConeBarrios cone = new ConeBarrios();
                    Barrio Agregar = new Barrio
                    {
                        Descripcion = TxtDescripcion.Text
                    };

                    cone.AgregarBarrio(Agregar);

                    #region Enabled yes/no 
                    //true
                    BtnNuevo.Enabled = true;
                    //false
                    TxtDescripcion.Enabled = false;                 
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;
                    #endregion

                    LimpiarTextos();
                    ListarBarrios();
                    BtnNuevo.Focus();
                }
                else
                {
                    ConeBarrios cone = new ConeBarrios();
                    Barrio Actualizar = new Barrio
                    {
                        IdBarrio = int.Parse(LblIdBarrio.Text),
                        Descripcion = TxtDescripcion.Text
                    };

                    cone.ActualizarBarrio(Actualizar);

                    TxtDescripcion.Enabled = false;
                    BtnNuevo.Enabled = true;
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;

                    LimpiarTextos();
                    ListarBarrios();
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
                TxtBuscar.Enabled = true;
                BtnNuevo.Enabled = true;
                //false
                BtnGrabar.Enabled = false;
                BtnCancelar.Enabled = false;
                BtnEliminar.Enabled = false;
                TxtDescripcion.Enabled = false;
                #endregion

                LimpiarTextos();
                ListarBarrios();
                BtnNuevo.Focus();
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            #region Enabled yes/no
            //true
            TxtBuscar.Enabled = true;
            BtnNuevo.Enabled = true;
            //false
            BtnModificar.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;
            TxtDescripcion.Enabled = false;
            #endregion
            LimpiarTextos();
            ListarBarrios();
            BtnNuevo.Focus();
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            #region Enabled yes/no
            //true
            PnlBarraLateral.Enabled = true;
            BtnGrabar.Enabled = true;
            //false
            Grilla.Enabled = false;
            BtnNuevo.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnModificar.Enabled = false;
            #endregion
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ConeBarrios cone = new ConeBarrios();
            Barrio Eliminar = new Barrio
            {
                IdBarrio = int.Parse(LblIdBarrio.Text)
            };

            cone.BorrarBarrio(Eliminar);

            try
            {
                MessageBox.Show("El barrio se eliminó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarTextos();
                ListarBarrios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.ToString()}");
                throw;
            }

            #region Enabled yes/no
            //true
            BtnNuevo.Enabled = true;
            //false
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;

            BtnNuevo.Focus();
            #endregion
        }
        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            unuFormPAPELERABarrios form = new unuFormPAPELERABarrios();
            form.ShowDialog();
        }
        #endregion 

        #region Interacciones con formulario
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text == "")
            {
                ListarBarrios();
            }
            else
            {
                ConeBarrios cone = new ConeBarrios();
                Barrio Buscar = new Barrio
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarBarrio(Buscar.Descripcion);
                
            }
        }
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            LblIdBarrio.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDescripcion.Text = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();

            #region Enabled yes/no
            //false
            nuevo = false;
            BtnNuevo.Enabled = false;
            //true
            TxtDescripcion.Enabled = true;   
            BtnGrabar.Enabled = true;
            BtnCancelar.Enabled = true;
            BtnEliminar.Enabled = true;
            BtnModificar.Enabled = true;
            #endregion
            TxtDescripcion.Focus();
        }
        #endregion

      
    }
}
