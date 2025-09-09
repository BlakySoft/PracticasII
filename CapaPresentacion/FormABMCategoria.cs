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
    public partial class FormABMCategoria: Form
    {
        #region Metodos
        Boolean nuevo;
        public FormABMCategoria()
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
            LblIdCat.Text = "";
            TxtDescripcion.Clear();
        }
        private void Listar()
        {
            ConeCategoria cone = new ConeCategoria();
            Grilla.DataSource = cone.ListarCat();
            Grilla.Columns[0].HeaderText = "Código";
            Grilla.Columns[0].Width = 100;
            Grilla.Columns[1].Width = 300;
            Grilla.Columns[1].HeaderText = "Categoria";
            Grilla.Columns[2].Visible = false;

        }

        #endregion

        #region Botones
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
                if (string.IsNullOrWhiteSpace(TxtDescripcion.Text))
                {
                    MessageBox.Show("Ingrese la categoría", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // Preguntar al usuario antes de guardar o actualizar
                string mensaje = nuevo
                    ? "¿Está seguro de que desea guardar esta categoría?"
                    : "¿Está seguro de que desea actualizar esta categoría?";

                DialogResult resultado = MessageBox.Show(
                    mensaje,
                    "Confirmar acción",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    ConeCategoria cone = new ConeCategoria();

                    if (nuevo)
                    {
                        Categoria agregar = new Categoria
                        {
                            Descripcion = TxtDescripcion.Text
                        };

                        cone.AgregarCat(agregar);
                    }
                    else
                    {
                        Categoria actualizar = new Categoria
                        {
                            IdCat = int.Parse(LblIdCat.Text),
                            Descripcion = TxtDescripcion.Text
                        };

                        cone.ActualizarCat(actualizar);
                    }

                    #region Enabled yes/no 
                    TxtDescripcion.Enabled = false;
                    BtnNuevo.Enabled = true;
                    BtnGrabar.Enabled = false;
                    BtnCancelar.Enabled = false;
                    #endregion

                    LimpiarTextos();
                    Listar();
                    BtnNuevo.Focus();
                }
                // Si el usuario elige "No", no hace nada
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                #region Enabled yes/no
                TxtBuscar.Enabled = true;
                BtnNuevo.Enabled = true;
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
            DialogResult resultado = MessageBox.Show(
         "¿Está seguro de que desea cancelar la carga de la categoría?",
         "Confirmar cancelación",
         MessageBoxButtons.YesNo,
         MessageBoxIcon.Question
     );

            if (resultado == DialogResult.Yes)
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

                Listar(); // Volver a listar categorías
                BtnNuevo.Focus();
                LimpiarTextos();
            }
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            #region Enabled yes/no
            //true
            PnlBarraLateral.Enabled = true;
            BtnGrabar.Enabled = true;
            TxtDescripcion.Enabled = true;

            //false
            Grilla.Enabled = false;
            BtnNuevo.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnModificar.Enabled = false;
            #endregion

        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta categoría?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    ConeCategoria cone = new ConeCategoria();
                    Categoria eliminar = new Categoria
                    {
                        IdCat = int.Parse(LblIdCat.Text)
                    };

                    cone.BorrarCat(eliminar);

                    MessageBox.Show("La categoría se eliminó correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarTextos();
                    Listar();

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
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BtnPapelera_Click(object sender, EventArgs e)
        {
            using (FormPAPELERACategoria form = new FormPAPELERACategoria())
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
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return; 
                LblIdCat.Text = Grilla.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                TxtDescripcion.Text = Grilla.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";

                #region Enabled yes/no
                //false
                nuevo = false;
                BtnNuevo.Enabled = false;
                TxtDescripcion.Enabled = false;
                //true

                BtnGrabar.Enabled = true;
                BtnCancelar.Enabled = true;
                BtnEliminar.Enabled = true;
                BtnModificar.Enabled = true;
                #endregion

                TxtDescripcion.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la fila: " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {

            if (TxtBuscar.Text == "")
            {
                Listar();
            }
            else
            {
                ConeCategoria cone = new ConeCategoria();
                Categoria Buscar = new Categoria
                {
                    Descripcion = TxtBuscar.Text
                };

                Grilla.DataSource = cone.BuscarCat(Buscar.Descripcion);

            }
        }

        #endregion

      
    }
}
