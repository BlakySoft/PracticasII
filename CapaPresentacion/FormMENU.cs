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
            menuStrip1.Renderer = new CustomRenderer();
        }
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
        private void FormMENU_Load(object sender, EventArgs e)
        {
            Timer.Start();
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
                //// Fondo del botón al pasar el mouse o al estar seleccionado
                //if (e.Item.Selected || e.Item.Pressed)
                //{
                //    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(163, 135, 136)), e.Item.ContentRectangle);
                //}
                //else
                //{
                //    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(245, 203, 204)), e.Item.ContentRectangle);
                //}

                var menuItem = e.Item as ToolStripMenuItem;
                if (menuItem != null && menuItem.Checked)
                {
                    //Fondo del boton activo
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(252, 154, 3)), e.Item.ContentRectangle);
                }
                else if (e.Item.Selected || e.Item.Pressed)
                {
                    // Fondo al pasar el mouse o presionar
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(163, 135, 136)), e.Item.ContentRectangle);
                } 
                else
                {
                    // Fondo por defecto
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(245, 203, 204)), e.Item.ContentRectangle);
                }
            }

            protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
            {
               //Si no llama a nada no se ve el check
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
            if (frmActivo != null)
                frmActivo.Close();

            FormHelper.ResetearMenuItems(menuStrip1.Items);

            frmActivo = FrmHijo;
            FrmHijo.TopLevel = false;
            FrmHijo.FormBorderStyle = FormBorderStyle.None;
            FrmHijo.Dock = DockStyle.Fill;

            PanelVisual.Controls.Clear();   
            PanelVisual.Controls.Add(FrmHijo);

            PanelVisual.Tag = FrmHijo;
            FrmHijo.BringToFront();
            FrmHijo.Show();

            menuItem.Checked = true;
            
            menuItem.BackColor = Color.FromArgb(32, 160, 32);


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
            AbrirFrmHijo(new FormCOMPRAS(), iconMenuItem2);
        }
        private void iconMenuItem3_Click(object sender, EventArgs e)
        {
            AbrirFrmHijo(new FormVENTAS(), iconMenuItem3);
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
    }
    }
    

