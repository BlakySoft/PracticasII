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
    public partial class FormConfiguracion: Form
    {
        public FormConfiguracion()
        {
            InitializeComponent();
        }

        private void FormConfiguracion_Load(object sender, EventArgs e)
        {
            txtLimiteStock.Text = Properties.Settings.Default.LimiteAlertaStock.ToString();
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtLimiteStock.Text, out int nuevoLimite) && nuevoLimite >= 0)
            {
                Properties.Settings.Default.LimiteAlertaStock = nuevoLimite;
                Properties.Settings.Default.Save();

                MessageBox.Show($"El límite de alerta se actualizó a {nuevoLimite}.", "Éxito");

            }
            else
            {
                MessageBox.Show("Ingrese un número entero válido (igual o mayor a cero).", "Error");
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            txtLimiteStock.Clear();
        }
    }
}
