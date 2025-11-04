using CapaNegocio;
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
        private Usuario usuarioActual;
        public FormMENU(CapaNegocio.Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            menuStrip1.Renderer = new CustomRenderer();
           
        }
        #region Botones

        private void cLIENTESToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFrmHijo(new FormABMClientes(), cLIENTESToolStripMenuItem1);
        }
        private void pROVEEDORESToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFrmHijo(new FormABMProveedores(), pROVEEDORESToolStripMenuItem1);
        }
        private void pRODUCTOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFrmHijo(new FormABMProductos(), pRODUCTOSToolStripMenuItem1);
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

        private void mARCASToolStripMenuItem_Click(object sender, EventArgs e)

        {
            FormPAPELERAMarca form = new FormPAPELERAMarca();
            form.ShowDialog();
        }
        private void cOLORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPAPELERAColor form = new FormPAPELERAColor();
            form.ShowDialog();
        }
        private void iconMenuItem2_Click(object sender, EventArgs e)
        {
            AbrirFrmHijo(new FormCOMPRAS(), btnCompras);
        }
        private void iconMenuItem3_Click(object sender, EventArgs e)
        {
            string nombreCajero = lblUsuario.Text;
            AbrirFrmHijo(new FormVENTAS(nombreCajero), iconMenuItem3);
        }
        private void vENTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormINFORMESventas form = new FormINFORMESventas();
            form.ShowDialog();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormINFORMESclientes form = new FormINFORMESclientes();
            form.ShowDialog();
        }
        private void btnINPoductos_Click(object sender, EventArgs e)
        {
            FormINFORMEproductos form = new FormINFORMEproductos();
            form.ShowDialog();
        }
        private void btnINProveedores_Click(object sender, EventArgs e)
        {
            FormINFORMEproveedores form = new FormINFORMEproveedores();
            form.ShowDialog();

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FormINFORMEcompras form = new FormINFORMEcompras();
            form.ShowDialog();
        }

        private void aGREGARUSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormAgregarUsuarios form = new FormAgregarUsuarios();
            form.ShowDialog();
        }

        private void eLIMINARUSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormELIMINARusuarios form = new FormELIMINARusuarios();
            form.ShowDialog();
        }

        #endregion

        #region Varios 
        private void FormMENU_Load(object sender, EventArgs e)
        {
            Timer.Start();
            lblUsuario.Text = "" + usuarioActual.Usuarios;
            if (usuarioActual.TipoUsuario == 2)
            {
               btnUsuarios.Visible = false; 
                btnRegistros.Visible = false;
                btnCompras.Visible = false;
                btnInformes.Visible = false;
            }
            else if (usuarioActual.TipoUsuario == 1)
            {
                btnUsuarios.Enabled = true;
                btnRegistros.Enabled = true;
                btnCompras.Enabled = true;
                btnInformes.Visible = true;
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Reloj.Text = DateTime.Now.ToString("HH:mm");
        }
        public class CustomRenderer : ToolStripProfessionalRenderer
        {
            public CustomRenderer() : base(new CustomColorTable()) { }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.Selected || e.Item.Pressed)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(163, 135, 136)), e.Item.ContentRectangle);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(245, 203, 204)), e.Item.ContentRectangle);
                }

                var menuItem = e.Item as ToolStripMenuItem;
                if (menuItem != null && menuItem.Checked)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(243, 106, 158)), e.Item.ContentRectangle);
                }
                else if (e.Item.Selected || e.Item.Pressed)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(163, 135, 136)), e.Item.ContentRectangle);
                } 
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(245, 203, 204)), e.Item.ContentRectangle);
                }
            }

            protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
            {
            }
        }
        public class CustomColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(245, 203, 204);
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(245, 203, 204);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(245, 203, 204);
            public override Color ToolStripDropDownBackground => Color.FromArgb(245, 203, 204);
            public override Color MenuBorder => Color.FromArgb(163, 135, 136);
            public override Color MenuItemBorder => Color.FromArgb(163, 135, 136);
            public override Color ImageMarginGradientBegin => Color.FromArgb(245, 203, 204);
            public override Color ImageMarginGradientMiddle => Color.FromArgb(245, 203, 204);
            public override Color ImageMarginGradientEnd => Color.FromArgb(245, 203, 204);
        }
        private Form frmActivo = null;
        public void AbrirFrmHijo(Form FrmHijo, ToolStripMenuItem menuItem)
        {

            if (frmActivo != null && frmActivo.GetType() == FrmHijo.GetType())
                return;
            if (frmActivo != null)
                frmActivo.Close();

            FormHelper.ResetearMenuItems(menuStrip1.Items, frmActivo);

            frmActivo = FrmHijo;
            FrmHijo.TopLevel = false;
            FrmHijo.FormBorderStyle = FormBorderStyle.None;
            FrmHijo.Dock = DockStyle.Fill;
            

            PanelVisual.Controls.Clear();   
            PanelVisual.Controls.Add(FrmHijo);
            PanelVisual.Tag = FrmHijo;

            FrmHijo.BringToFront();

            FormHelper.ResaltarMenuItem(menuItem);

            FrmHijo.FormClosed += (s, e) =>
            {
                FormHelper.ResetearMenuItems(menuStrip1.Items, frmActivo);
                frmActivo = null;
            };

            FrmHijo.Show();


        }
        #endregion

    
    }
}
    

