using CapaNegocios;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing.Printing;

namespace CapaPresentacion
{
    public partial class FormABMClientes : Form
    {
        #region Metodos y declaraciones

        Boolean nuevo;
        int VarBarrio;
        public FormABMClientes()
        {
            InitializeComponent();
            LimpiarTextos();
            ListarClientes();
            CargarCbo();
            BtnModificar.Enabled = false;
            PanelDatos.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;
            TxtBuscar.Enabled = true;
        }
        private void CargarCbo()
        {
            ConeBarrios cone = new ConeBarrios();

            CboIdBarrio.ValueMember = "IdBarrio";
            CboIdBarrio.DisplayMember = "Descripcion";
            CboIdBarrio.DataSource = cone.ListarBarrio();
        }
        private void LimpiarTextos()
        {
            LblIdCliente.Text = "";
            TxtNombre.Clear();
            TxtDocumento.Clear();
            TxtTelefono.Clear();
            TxtDomicilio.Clear();
        }
        private void ListarClientes()
        {
            ConeClientes cone = new ConeClientes();
            Grilla.DataSource = cone.ListarCliente();

            Grilla.Columns[0].HeaderText = "Codigo";
            Grilla.Columns[0].Width = 70;
            Grilla.Columns[1].Width = 140;
            Grilla.Columns[2].Width = 100;
            Grilla.Columns[3].Width = 100;
            Grilla.Columns[4].Width = 110;
            Grilla.Columns[5].Width = 60;
            Grilla.Columns[1].HeaderText = "Nombre y apellido";
            Grilla.Columns[2].HeaderText = "Documento";
            Grilla.Columns[3].HeaderText = "Teléfono";
            Grilla.Columns[4].HeaderText = "Domicilio";
            //Grilla.Columns[5].HeaderText = "Barrio";
            //Grilla.Columns[6].Visible = false;
        }

        #endregion

        #region Botones
        private void BtnPapelera_Click(object sender, EventArgs e)
        {
            FormPAPELERAClientes form = new FormPAPELERAClientes();
            form.ShowDialog();
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            nuevo = false;
            CargarCbo();
            CboIdBarrio.SelectedValue = VarBarrio;
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
            BtnNuevo.Focus();
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ConeClientes cone = new ConeClientes();
            Cliente Borrar = new Cliente
            {
                IdCliente = int.Parse(LblIdCliente.Text)
            };

            cone.BorrarCliente(Borrar);

            try
            {
                MessageBox.Show("El Cliente se eliminó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarTextos();
                ListarClientes();
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
        private void BtnBarrio_Click(object sender, EventArgs e)
        {
            FormABMBarrios form = new FormABMBarrios();
            form.ShowDialog();
            CargarCbo();
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
            TxtNombre.Focus();
        }
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtNombre.Text == "")
                {
                    MessageBox.Show("Ingrese el Nombre", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    Grilla.Enabled = true;
                    BtnNuevo.Enabled = true;
                    //false
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;
                    PanelDatos.Enabled = false;
                    #endregion

                    LimpiarTextos();
                    ListarClientes();
                    BtnNuevo.Focus();
                }
                else
                {
                    ConeClientes cone = new ConeClientes();
                    Cliente Actualizar = new Cliente
                    {
                        IdCliente = int.Parse(LblIdCliente.Text),
                        Nombre = TxtNombre.Text,
                        Documento = TxtDocumento.Text,
                        Telefono = TxtTelefono.Text,
                        Domicilio = TxtDomicilio.Text,
                        //IdBarrio = VarBarrio No se encuentra en uso
                    };

                    cone.ActualizarCliente(Actualizar);

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
                    ListarClientes();
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

                ListarClientes();
                LimpiarTextos();


                BtnNuevo.Focus();
            }


        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ListarClientes();
            CargarCbo();
        }
        #endregion

        #region Interacciones con Formulario
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text != "")
            {
                ConeClientes cone = new ConeClientes();
                Cliente Buscar = new Cliente
                {
                    Nombre = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarCliente(Buscar.Nombre);
            }
            else
            {
                ListarClientes();
            }
        }
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LblIdCliente.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtNombre.Text = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtDocumento.Text = Grilla.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtTelefono.Text = Grilla.Rows[e.RowIndex].Cells[3].Value.ToString();
                TxtDomicilio.Text = Grilla.Rows[e.RowIndex].Cells[4].Value.ToString();
                //VarBarrio = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[5].Value.ToString()); No se encuentra en uso 

                //ConeBarrios cone = new ConeBarrios();

                // _ = new Barrio
                // {
                //     IdBarrio = VarBarrio
                // };

                //CboIdBarrio.ValueMember = "IdBarrio";
                //CboIdBarrio.DisplayMember = "Descripcion";
                //CboIdBarrio.DataSource = cone.BuscarIdBarrio(VarBarrio);

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
                LblIdCliente.Text = Grilla.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtNombre.Text = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtDocumento.Text = Grilla.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtTelefono.Text = Grilla.Rows[e.RowIndex].Cells[3].Value.ToString();
                TxtDomicilio.Text = Grilla.Rows[e.RowIndex].Cells[4].Value.ToString();
                VarBarrio = Convert.ToInt32(Grilla.Rows[e.RowIndex].Cells[5].Value.ToString());

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
                TxtNombre.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Imposible seleccionar desde la cabecera.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void CboIdBarrio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VarBarrio = int.Parse(CboIdBarrio.SelectedValue.ToString());
        }
        #endregion

        #region Informes
        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Landscape = false;
            printDoc.PrintPage += new PrintPageEventHandler(Imprimir_PrintPage);
            printDoc.Print();
        }

        private void Imprimir_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fuenteTitulo = new Font("Arial", 12, FontStyle.Bold);
            Font fuenteDetalle = new Font("Arial", 10);
            int margenIzquierdo = 40;
            int margenSuperior = 40;
            int espacioEntreLineas = 20;

            e.Graphics.DrawString("Informe de Clientes", fuenteTitulo, Brushes.Black, margenIzquierdo, margenSuperior);

            int lineaY = margenSuperior + 30;
            e.Graphics.DrawLine(Pens.Black, margenIzquierdo, lineaY, 770, lineaY);

            e.Graphics.DrawString("Código", fuenteTitulo, Brushes.Black, margenIzquierdo, lineaY + espacioEntreLineas);
            e.Graphics.DrawString("Nombre", fuenteTitulo, Brushes.Black, margenIzquierdo + 80, lineaY + espacioEntreLineas);
            e.Graphics.DrawString("Documento", fuenteTitulo, Brushes.Black, margenIzquierdo + 300, lineaY + espacioEntreLineas);
            e.Graphics.DrawString("Teléfono", fuenteTitulo, Brushes.Black, margenIzquierdo + 450, lineaY + espacioEntreLineas);
            e.Graphics.DrawString("Domicilio", fuenteTitulo, Brushes.Black, margenIzquierdo + 540, lineaY + espacioEntreLineas);

            lineaY += espacioEntreLineas + 20;

            ConeClientes cone = new ConeClientes();
            List<Cliente> clientes = cone.ListarCliente();

            foreach (var cli in clientes)
            {
                e.Graphics.DrawString(cli.IdCliente.ToString(), fuenteDetalle, Brushes.Black, margenIzquierdo, lineaY);
                e.Graphics.DrawString(cli.Nombre, fuenteDetalle, Brushes.Black, margenIzquierdo + 80, lineaY);
                e.Graphics.DrawString(cli.Documento, fuenteDetalle, Brushes.Black, margenIzquierdo + 300, lineaY);
                e.Graphics.DrawString(cli.Telefono, fuenteDetalle, Brushes.Black, margenIzquierdo + 450, lineaY);
                e.Graphics.DrawString(cli.Domicilio, fuenteDetalle, Brushes.Black, margenIzquierdo + 540, lineaY);

                lineaY += espacioEntreLineas;
            }

            if (lineaY > e.MarginBounds.Height)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        #endregion
    }
}

