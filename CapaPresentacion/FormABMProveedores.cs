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
            Grilla.DataSource = cone.ListarProveedorINNERJOIN();

            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].Width = 200;
            Grilla.Columns[1].HeaderText = "Razón Social";
            Grilla.Columns[2].HeaderText = "CUIT";
            Grilla.Columns[3].HeaderText = "Teléfono";
            Grilla.Columns[4].HeaderText = "Direccion";
            Grilla.Columns[4].Width = 200;
            Grilla.Columns[5].Visible = false; //IdLocalidad
            Grilla.Columns[6].HeaderText = "Localidad";
            Grilla.Columns[7].Visible = false; //Estado
        }

        #endregion

        #region Botones
        private void iconButton1_Click(object sender, EventArgs e)
        {
            TxtBuscar.Clear();
        }
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
            BtnPapelera.Enabled = false;
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
                    TxtRazon.Focus();
                }
                else if (TxtDocumento.Text == "")
                {
                    MessageBox.Show("Ingrese el Numero de documento ", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtDocumento.Focus();
                }
                else if (TxtTelefono.Text == "")
                {
                    MessageBox.Show("Ingrese el Teléfono", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtTelefono.Focus();
                }
                else if (TxtDomicilio.Text == "")
                {
                    MessageBox.Show("Ingrese la Direccion", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtDomicilio.Focus();
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

                //#region Enabled yes/no
                ////true
                //TxtBuscar.Enabled = true;
                //Grilla.Enabled = true;
                //BtnNuevo.Enabled = true;
                ////false
                //BtnGrabar.Enabled = false;
                //BtnCancelar.Enabled = false;
                //BtnEliminar.Enabled = false;
                //PanelDatos.Enabled = false;
                //#endregion

                //ListarProveedores();
                //LimpiarTextos();
                //BtnNuevo.Focus();
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(LblIdProveedor.Text, out int idProveedor))
            {
                MessageBox.Show("Seleccione un proveedor válido primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro que desea eliminar este proveedor?",
                                "Confirmar eliminación",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                new ConeProveedores().BorrarProveedor(new Proveedores { IdProveedor = idProveedor });
                MessageBox.Show("El proveedor se eliminó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarTextos();
                ListarProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            BtnCancelar.Enabled = true;

            //false
            BtnNuevo.Enabled = false;
            Grilla.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnModificar.Enabled = false;
            BtnPapelera.Enabled = false;
            #endregion
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            #region Enabled yes/no
            //true
            TxtBuscar.Enabled = true;
            Grilla.Enabled = true;
            BtnNuevo.Enabled = true;
            BtnPapelera.Enabled = true;
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
            using (FormPAPELERAProveedores form = new FormPAPELERAProveedores())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ListarProveedores();
                }
            }
            
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Interaccion con el formulario
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
        private void Grilla_CellClick_1(object sender, DataGridViewCellEventArgs e)
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
        private void Grilla_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
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
                MessageBox.Show("Solo se permiten números en el Cuit.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Solo se permiten números en Teléfono.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Caracter no válido en Dirección.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
