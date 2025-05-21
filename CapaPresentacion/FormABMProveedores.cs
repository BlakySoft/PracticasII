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
    public partial class FormABMProveedores : Form
    {
        #region Metodos y declaraciones

        Boolean nuevo;
        int VarLocalidad;
        public FormABMProveedores()
        {
            InitializeComponent();
            LimpiarTextos();
            ListarProveedores();
            CargarCbo();
            BtnModificar.Enabled = false;
            PanelDatos.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;
            TxtBuscar.Enabled = false;
           
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
        private void ListarProveedores()
        {
            ConeProveedores cone = new ConeProveedores();
            Grilla.DataSource = cone.ListarProveedor();

            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 50;
            Grilla.Columns[1].Width = 150;
            Grilla.Columns[1].HeaderText = "Razón Social";
            Grilla.Columns[2].HeaderText = "CUIT";
            Grilla.Columns[3].HeaderText = "Teléfono";
            Grilla.Columns[4].HeaderText = "Direccion";
            Grilla.Columns[5].HeaderText = "Localidad";
            Grilla.Columns[6].Visible = false;
        }


        #endregion

        #region Botones
        private void BtnLocalidad_Click(object sender, EventArgs e)
        {
            FormABMLocalidades form = new FormABMLocalidades();
            form.ShowDialog();
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;

            #region Enabled yes/no 
            //true
            BtnGrabar.Enabled = true;
            BtnCancelar.Enabled = true;
            PanelDatos.Enabled = true;
            //false
            BtnEliminar.Enabled = false;
            TxtBuscar.Enabled = false;
            Grilla.Enabled = false;
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
                    Grilla.Enabled = true;
                    BtnNuevo.Enabled = true;
                    //false
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;
                    PanelDatos.Enabled = false;
                    #endregion

                    LimpiarTextos();
                    ListarProveedores();
                    BtnNuevo.Focus();
                }
                else
                {

                    ConeProveedores cone = new ConeProveedores();
                    Proveedores Actualizar = new Proveedores
                    {
                        IdProveedor = int.Parse(LblIdProveedor.Text),
                        RazonSocial = TxtRazon.Text,
                        Documento = TxtDocumento.Text,
                        Telefono = TxtTelefono.Text,
                        Domicilio = TxtDomicilio.Text,
                        IdLocalidad = VarLocalidad
                    };

                    cone.ActualizarProveedor(Actualizar);

                    #region Enabled yes/no
                    //true
                    Grilla.Enabled = true;
                    BtnNuevo.Enabled = true;
                    //false
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;
                    PanelDatos.Enabled = false;
                    #endregion

                    LimpiarTextos();
                    ListarProveedores();
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
                Grilla.Enabled = true;
                BtnNuevo.Enabled = true;
                //false
                BtnGrabar.Enabled = false;
                BtnCancelar.Enabled = false;
                BtnEliminar.Enabled = false;
                PanelDatos.Enabled = false;
                #endregion

                ListarProveedores();
                LimpiarTextos();
                BtnNuevo.Focus();
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ConeProveedores cone = new ConeProveedores();
            Proveedores Borrar = new Proveedores
            {
                IdProveedor = int.Parse(LblIdProveedor.Text)
            };

            cone.BorrarProveedor(Borrar);

            try
            {
                MessageBox.Show("El Proveedor se eliminó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarTextos();
                ListarProveedores();
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
            #endregion

            BtnNuevo.Focus();
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            nuevo = false;
            CargarCbo();
            CboIdLocalidad.SelectedValue = VarLocalidad;
            
            #region Enabled yes/no
            //true
            PanelDatos.Enabled = true;
            BtnGrabar.Enabled = true;

            //false
            BtnNuevo.Enabled = false;
            Grilla.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnModificar.Enabled = false;
            BtnCancelar.Enabled = true;
            #endregion
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            #region Enabled yes/no
            //true
            TxtBuscar.Enabled = true;
            Grilla.Enabled = true;
            BtnNuevo.Enabled = true;
            //false
            BtnModificar.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;
            PanelDatos.Enabled = false;
            #endregion
            LimpiarTextos();
            ListarProveedores();
            BtnNuevo.Focus();
        }
        private void BtnPapelera_Click(object sender, EventArgs e)
        {
            FormPAPELERAProveedores form = new FormPAPELERAProveedores();
            form.ShowDialog();
        }
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ListarProveedores();
            CargarCbo();
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Interaccion con el formulario
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LblIdProveedor.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtRazon.Text = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtDocumento.Text = Grilla.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtTelefono.Text = Grilla.Rows[e.RowIndex].Cells[3].Value.ToString();
                TxtDomicilio.Text = Grilla.Rows[e.RowIndex].Cells[4].Value.ToString();
                VarLocalidad = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[5].Value.ToString());

                ConeLocalidades cone = new ConeLocalidades();

                _ = new Localidad
                {
                    IdLocalidad = VarLocalidad
                };

                CboIdLocalidad.ValueMember = "IdLocalidad";
                CboIdLocalidad.DisplayMember = "Descripcion";
                CboIdLocalidad.DataSource = cone.BuscarIdLocalidad(VarLocalidad);

                #region Enabled yes/no

                BtnCancelar.Enabled = true;
                BtnEliminar.Enabled = true;
                BtnModificar.Enabled = true;
                #endregion
            }
            catch (Exception)
            {
                MessageBox.Show("Imposible seleccionar desde aquí.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Grilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LblIdProveedor.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtRazon.Text = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtDocumento.Text = Grilla.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtTelefono.Text = Grilla.Rows[e.RowIndex].Cells[3].Value.ToString();
                TxtDomicilio.Text = Grilla.Rows[e.RowIndex].Cells[4].Value.ToString();
                VarLocalidad = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[5].Value.ToString());

                nuevo = false;

                #region Enables yes/no
                //true
                BtnGrabar.Enabled = true;
                BtnCancelar.Enabled = true;
                PanelDatos.Enabled = true;
                //false
                BtnEliminar.Enabled = false;
                Grilla.Enabled = false;
                BtnNuevo.Enabled = false;
                #endregion 

                CargarCbo();
                TxtRazon.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Imposible seleccionar desde la cabecera.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void CboIdLocalidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VarLocalidad = int.Parse(CboIdLocalidad.SelectedValue.ToString());
        }


        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                ListarProveedores();
            }
            else
            {
                ConeProveedores cone = new ConeProveedores();
                Proveedores Buscar = new Proveedores
                {
                    RazonSocial = textBox1.Text
                };

                Grilla.DataSource = cone.Buscar(Buscar.RazonSocial);
            }
        }
    }
}
