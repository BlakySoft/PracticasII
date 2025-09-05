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

        public FormABMClientes()
        {
            InitializeComponent();
            LimpiarTextos();
            ListarClientes();

            BtnModificar.Enabled = false;
            PanelDatos.Enabled = false;
            BtnGrabar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnEliminar.Enabled = false;
            TxtBuscar.Enabled = true;
        }

        private void LimpiarTextos()
        {
            LblIdCliente.Text = "";
            TxtApellido.Clear(); // NUEVO
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
            Grilla.Columns[0].Width = 85;
            Grilla.Columns[1].Width = 120; // Apellido
            Grilla.Columns[2].Width = 120; // Nombre
            Grilla.Columns[3].Width = 130;
            Grilla.Columns[4].Width = 130;
            Grilla.Columns[5].Width = 300;

            Grilla.Columns[1].HeaderText = "Apellido"; // NUEVO
            Grilla.Columns[2].HeaderText = "Nombre";
            Grilla.Columns[3].HeaderText = "Documento";
            Grilla.Columns[4].HeaderText = "Teléfono";
            Grilla.Columns[5].HeaderText = "Domicilio";
        }

        #endregion

        #region Botones
        private void BtnPapelera_Click(object sender, EventArgs e)
        {
            using (FormPAPELERAClientes form = new FormPAPELERAClientes())
            {
                if (form.ShowDialog() == DialogResult.OK )
                {
                    ListarClientes();
                }
            }
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            nuevo = false;
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
            BtnPapelera.Enabled = true;
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
            // Pregunta de confirmación
            DialogResult result = MessageBox.Show(
                "¿Está seguro de eliminar este cliente?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                ConeClientes cone = new ConeClientes();
                Cliente Borrar = new Cliente
                {
                    IdCliente = int.Parse(LblIdCliente.Text)
                };

                try
                {
                    cone.BorrarCliente(Borrar);

                    MessageBox.Show("El Cliente se eliminó correctamente!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarTextos();
                    ListarClientes();

                    #region Enabled yes/no 
                    BtnNuevo.Enabled = true;
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;
                    BtnEliminar.Enabled = false;
                    #endregion

                    BtnNuevo.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Si el usuario cancela, no hace nada
                return;
            }
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


            LimpiarTextos();
            TxtApellido.Focus();
        }
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtApellido.Text == "")
                {
                    MessageBox.Show("Ingrese el Apellido", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtApellido.Focus();
                }
                else if (TxtNombre.Text == "")
                {
                    MessageBox.Show("Ingrese el Nombre", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtNombre.Focus();
                }
                else if (TxtDocumento.Text == "")
                {
                    MessageBox.Show("Ingrese el Numero de documento", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtDocumento.Focus();
                }
                else if (TxtTelefono.Text == "")
                {
                    MessageBox.Show("Ingrese el Teléfono", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtTelefono.Focus();
                }
                else if (TxtDomicilio.Text == "")
                {
                    MessageBox.Show("Ingrese la Domicilio", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtDomicilio.Focus();
                }
                else
                {
                    // Pregunta de confirmación antes de guardar o actualizar
                    DialogResult result = MessageBox.Show(
                        nuevo ? "¿Está seguro de agregar este cliente?" : "¿Está seguro de actualizar este cliente?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        ConeClientes cone = new ConeClientes();

                        if (nuevo)
                        {
                            Cliente Agregar = new Cliente
                            {
                                Apellido = TxtApellido.Text,
                                Nombre = TxtNombre.Text,
                                Documento = TxtDocumento.Text,
                                Telefono = TxtTelefono.Text,
                                Domicilio = TxtDomicilio.Text
                            };

                            cone.AgregarCliente(Agregar);
                            MessageBox.Show("Cliente agregado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Cliente Actualizar = new Cliente
                            {
                                IdCliente = int.Parse(LblIdCliente.Text),
                                Apellido = TxtApellido.Text,
                                Nombre = TxtNombre.Text,
                                Documento = TxtDocumento.Text,
                                Telefono = TxtTelefono.Text,
                                Domicilio = TxtDomicilio.Text
                            };

                            cone.ActualizarCliente(Actualizar);
                            MessageBox.Show("Cliente actualizado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        #region Enabled yes/no
                        Grilla.Enabled = true;
                        BtnNuevo.Enabled = true;
                        BtnPapelera.Enabled = true;
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
                        return; // Cancelar la operación
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                TxtBuscar.Enabled = true;
                Grilla.Enabled = true;
                BtnNuevo.Enabled = true;
                BtnGrabar.Enabled = false;
                BtnCancelar.Enabled = false;
                BtnEliminar.Enabled = false;
                PanelDatos.Enabled = false;

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

        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            TxtBuscar.Clear();
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
                TxtApellido.Text = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString(); // NUEVO
                TxtNombre.Text = Grilla.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtDocumento.Text = Grilla.Rows[e.RowIndex].Cells[3].Value.ToString();
                TxtTelefono.Text = Grilla.Rows[e.RowIndex].Cells[4].Value.ToString();
                TxtDomicilio.Text = Grilla.Rows[e.RowIndex].Cells[5].Value.ToString();

                BtnCancelar.Enabled = true;
                BtnEliminar.Enabled = true;
                BtnModificar.Enabled = true;
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
                TxtApellido.Text = Grilla.Rows[e.RowIndex].Cells[1].Value.ToString(); // NUEVO
                TxtNombre.Text = Grilla.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtDocumento.Text = Grilla.Rows[e.RowIndex].Cells[3].Value.ToString();
                TxtTelefono.Text = Grilla.Rows[e.RowIndex].Cells[4].Value.ToString();
                TxtDomicilio.Text = Grilla.Rows[e.RowIndex].Cells[5].Value.ToString();

                nuevo = false;

                BtnGrabar.Enabled = true;
                BtnCancelar.Enabled = true;
                PanelDatos.Enabled = true;
                BtnEliminar.Enabled = false;
                Grilla.Enabled = false;
                BtnNuevo.Enabled = false;

                TxtApellido.Focus(); // NUEVO
            }
            catch (Exception)
            {
                MessageBox.Show("Imposible seleccionar desde la cabecera.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            // 1️⃣ Validar que solo sean letras, espacios y teclas de control
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Cancela la tecla
                MessageBox.Show("Solo se permiten letras en el apellido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // 2️⃣ Si el usuario presiona Enter, mover al siguiente TextBox
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita el sonido de "ding"
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, espacios y teclas de control
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras en el Nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Mover al siguiente control con Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void TxtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo números
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números en Documento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Limitar a 8 caracteres
            TextBox txt = sender as TextBox;
            if (txt.Text.Length >= 8 && !char.IsControl(e.KeyChar))
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
        #endregion

        #region Informes
        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            BtnImprimir.Enabled = false; //Evitar varios clicks
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

