using CapaDatos;
using CapaNegocio;
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
    public partial class FormABMColor: Form
    {
        #region Metodos
        Boolean nuevo;
        public FormABMColor()
        {
            InitializeComponent();
            BtnModificar.Enabled = false;
            TxtDescripcion.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;

            LimpiarTextos();
            Listar();
        }
        private void LimpiarTextos()
        {
            LblIdColor.Text = "";
            TxtDescripcion.Clear();
        }
        private void Listar()
        {
            ConeColores cone = new ConeColores();
            Grilla.DataSource = cone.ListarColor();
            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[2].Width = 300;
            Grilla.Columns[1].HeaderText = "Colores";
            Grilla.Columns[2].Visible = false;
        }
        #endregion

        #region Botones
        private void BtnPapelera_Click(object sender, EventArgs e)
        {
            using (FormPAPELERAColor form = new FormPAPELERAColor())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Listar();
                }
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            TxtBuscar.Clear();
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
                    MessageBox.Show("Ingrese el Color", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (nuevo == true)
                {
                    ConeColores cone = new ConeColores();
                    Colores Agregar = new Colores
                    {
                        Descripcion = TxtDescripcion.Text
                    };

                    cone.Agregar(Agregar);

                    #region Enabled yes/no 
                    //true
                    BtnNuevo.Enabled = true;
                    //false
                    TxtDescripcion.Enabled = false;
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;
                    #endregion

                    LimpiarTextos();
                    Listar();
                    BtnNuevo.Focus();
                }
                else
                {
                    ConeColores cone = new ConeColores();
                    Colores Actualizar = new Colores
                    {
                        IdColor = int.Parse(LblIdColor.Text),
                        Descripcion = TxtDescripcion.Text
                    };

                    cone.Actualizar(Actualizar);

                    TxtDescripcion.Enabled = false;
                    BtnNuevo.Enabled = true;
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;

                    LimpiarTextos();
                    Listar();
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
                Listar();
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

            Listar();
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
            ConeColores cone = new ConeColores();
            Colores Eliminar = new Colores
            {
                IdColor = int.Parse(LblIdColor.Text)
            };

            cone.Borrar(Eliminar);

            try
            {
                MessageBox.Show("El Color se eliminó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarTextos();
                Listar();
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
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Interaccion con el formulario
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            LblIdColor.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
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
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text == "")
            {
                Listar();
            }
            else
            {
                ConeColores cone = new ConeColores();
                Colores Buscar = new Colores
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarColor(Buscar.Descripcion);

            }
        }
        #endregion

    
    }
}

    

