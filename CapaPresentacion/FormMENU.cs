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
    public partial class FormMENU: Form
    {
        public FormMENU()
        {
            InitializeComponent();
        }

        private void cLIENTESToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormABMClientes form = new FormABMClientes();
            form.ShowDialog();
        }
        private void pROVEEDORESToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormABMProveedores form = new FormABMProveedores();
            form.ShowDialog();
        }
        private void pRODUCTOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormABMProductos form = new FormABMProductos();
            form.ShowDialog();
        }
        private void mATERIASPRIMASToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormABMMateriasPrimas form = new FormABMMateriasPrimas();
            form.ShowDialog();
        }
        private void bARRIOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormABMBarrios form = new FormABMBarrios();
            form.ShowDialog();
        }
        private void clientesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormPAPELERAClientes form = new FormPAPELERAClientes();
            form.ShowDialog();
        }
        private void productosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormPAPELERAProductos form = new FormPAPELERAProductos();
            form.ShowDialog();
        }
        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPAPELERAProveedores form = new FormPAPELERAProveedores();
            form.ShowDialog();
        }
        private void materiaPrimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPAPELERAMateriaprima form = new FormPAPELERAMateriaprima();
            form.ShowDialog();
        }
        private void iconMenuItem5_Click(object sender, EventArgs e)
        {

            FormPAPELERABarrios form = new FormPAPELERABarrios();
            form.ShowDialog();
        }
        private void rubrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormPAPELERACategoria form = new FormPAPELERACategoria();
            form.ShowDialog();
        }
        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormPAPELERALocalidades form = new FormPAPELERALocalidades();
            form.ShowDialog();
        }
        private void metodosDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormPAPELERAMetodosdepago form = new FormPAPELERAMetodosdepago();
            form.ShowDialog();
        }
        private void rEALIZARCOMPRAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCOMPRAS form = new FormCOMPRAS();
            form.ShowDialog();
        }
        private void pEDIDOSENTREGADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPEDIDOSentregados form = new FormPEDIDOSentregados();
            form.ShowDialog();
        }
        private void cABCELADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormPEDIDOScancelados form = new FormPEDIDOScancelados();
            form.ShowDialog();
        }
        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPEDIDOS form = new FormPEDIDOS();
            form.ShowDialog();
        }
        private void pRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPEDIDOSpendientes form = new FormPEDIDOSpendientes();
            form.ShowDialog();
        }

        private void FormMENU_Load(object sender, EventArgs e)
        {
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Reloj.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
