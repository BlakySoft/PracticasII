using CapaDatos;
using CapaNegocios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormABMMetododepago : Form
    {
        #region Metodos y declaraciones
        Boolean nuevo;
        public FormABMMetododepago()
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
            LblIdMetodo.Text = "";
            TxtDescripcion.Clear();
        }
        private void Listar()
        {
            ConeMetododepago cone = new ConeMetododepago();
            Grilla.DataSource = cone.Listar();
            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].HeaderText = "Metodo de pago";
            Grilla.Columns[1].Width = 150;
            Grilla.Columns[2].Visible = false;

        }

        #endregion

        #region Botones
        private void iconButton2_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Ingrese el Metodo de pago", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (nuevo == true)
                {
                    ConeMetododepago cone = new ConeMetododepago();
                    Metododepago Agregar = new Metododepago
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
                    ConeMetododepago cone = new ConeMetododepago();
                    Metododepago Actualizar = new Metododepago
                    {
                        IdMetodo = int.Parse(LblIdMetodo.Text),
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
            LimpiarTextos();
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
            ConeMetododepago cone = new ConeMetododepago();
            Metododepago Eliminar = new Metododepago
            {
                IdMetodo = int.Parse(LblIdMetodo.Text)
            };

            cone.Borrar(Eliminar);

            try
            {
                MessageBox.Show("El Metodo de pago se eliminó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        private void iconButton1_Click(object sender, EventArgs e)
        {
            using (FormPAPELERAMetodosdepago form = new FormPAPELERAMetodosdepago())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Listar();
                }
            }
        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Interacciones con formulario
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text == "")
            {
                Listar();
            }
            else
            {
                ConeMetododepago cone = new ConeMetododepago();
                Metododepago Buscar = new Metododepago
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.Buscar(Buscar.Descripcion);

            }
        }
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LblIdMetodo.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
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
