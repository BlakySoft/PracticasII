namespace CapaPresentacion
{
    partial class FormMENU
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Reloj = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Panelinf = new System.Windows.Forms.Panel();
            this.PanelVisual = new System.Windows.Forms.Panel();
            this.iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            this.cLIENTESToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pROVEEDORESToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pRODUCTOSToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            this.iconMenuItem3 = new FontAwesome.Sharp.IconMenuItem();
            this.iconMenuItem5 = new FontAwesome.Sharp.IconMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.vENTASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconMenuItem4 = new FontAwesome.Sharp.IconMenuItem();
            this.clientesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rubrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metodosDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mARCASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOLORESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconSplitButton1 = new FontAwesome.Sharp.IconSplitButton();
            this.menuStrip1.SuspendLayout();
            this.Panelinf.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.menuStrip1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconMenuItem1,
            this.iconMenuItem2,
            this.iconMenuItem3,
            this.iconMenuItem5,
            this.iconMenuItem4});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1264, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Reloj
            // 
            this.Reloj.AutoSize = true;
            this.Reloj.Dock = System.Windows.Forms.DockStyle.Right;
            this.Reloj.Font = new System.Drawing.Font("Bernard MT Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reloj.ForeColor = System.Drawing.Color.Black;
            this.Reloj.Location = new System.Drawing.Point(1173, 0);
            this.Reloj.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Reloj.Name = "Reloj";
            this.Reloj.Size = new System.Drawing.Size(91, 38);
            this.Reloj.TabIndex = 1;
            this.Reloj.Text = "RELOJ";
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Panelinf
            // 
            this.Panelinf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(203)))), ((int)(((byte)(204)))));
            this.Panelinf.Controls.Add(this.Reloj);
            this.Panelinf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panelinf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Panelinf.Location = new System.Drawing.Point(0, 640);
            this.Panelinf.Name = "Panelinf";
            this.Panelinf.Size = new System.Drawing.Size(1264, 41);
            this.Panelinf.TabIndex = 2;
            // 
            // PanelVisual
            // 
            this.PanelVisual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.PanelVisual.BackgroundImage = global::CapaPresentacion.Properties.Resources.LizLogo2;
            this.PanelVisual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PanelVisual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelVisual.Location = new System.Drawing.Point(0, 27);
            this.PanelVisual.Name = "PanelVisual";
            this.PanelVisual.Size = new System.Drawing.Size(1264, 613);
            this.PanelVisual.TabIndex = 3;
            // 
            // iconMenuItem1
            // 
            this.iconMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cLIENTESToolStripMenuItem1,
            this.pROVEEDORESToolStripMenuItem1,
            this.pRODUCTOSToolStripMenuItem1});
            this.iconMenuItem1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.BoxesPacking;
            this.iconMenuItem1.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem1.Name = "iconMenuItem1";
            this.iconMenuItem1.Size = new System.Drawing.Size(132, 23);
            this.iconMenuItem1.Text = "REGISTROS";
            // 
            // cLIENTESToolStripMenuItem1
            // 
            this.cLIENTESToolStripMenuItem1.Name = "cLIENTESToolStripMenuItem1";
            this.cLIENTESToolStripMenuItem1.Size = new System.Drawing.Size(204, 24);
            this.cLIENTESToolStripMenuItem1.Text = "CLIENTES";
            this.cLIENTESToolStripMenuItem1.Click += new System.EventHandler(this.cLIENTESToolStripMenuItem1_Click);
            // 
            // pROVEEDORESToolStripMenuItem1
            // 
            this.pROVEEDORESToolStripMenuItem1.Name = "pROVEEDORESToolStripMenuItem1";
            this.pROVEEDORESToolStripMenuItem1.Size = new System.Drawing.Size(204, 24);
            this.pROVEEDORESToolStripMenuItem1.Text = "PROVEEDORES";
            this.pROVEEDORESToolStripMenuItem1.Click += new System.EventHandler(this.pROVEEDORESToolStripMenuItem1_Click);
            // 
            // pRODUCTOSToolStripMenuItem1
            // 
            this.pRODUCTOSToolStripMenuItem1.Name = "pRODUCTOSToolStripMenuItem1";
            this.pRODUCTOSToolStripMenuItem1.Size = new System.Drawing.Size(204, 24);
            this.pRODUCTOSToolStripMenuItem1.Text = "PRODUCTOS";
            this.pRODUCTOSToolStripMenuItem1.Click += new System.EventHandler(this.pRODUCTOSToolStripMenuItem1_Click);
            // 
            // iconMenuItem2
            // 
            this.iconMenuItem2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconMenuItem2.ForeColor = System.Drawing.Color.Black;
            this.iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.Shopify;
            this.iconMenuItem2.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem2.Name = "iconMenuItem2";
            this.iconMenuItem2.Size = new System.Drawing.Size(119, 23);
            this.iconMenuItem2.Text = "COMPRAS";
            this.iconMenuItem2.Click += new System.EventHandler(this.iconMenuItem2_Click);
            // 
            // iconMenuItem3
            // 
            this.iconMenuItem3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconMenuItem3.ForeColor = System.Drawing.Color.Black;
            this.iconMenuItem3.IconChar = FontAwesome.Sharp.IconChar.BreadSlice;
            this.iconMenuItem3.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem3.Name = "iconMenuItem3";
            this.iconMenuItem3.Size = new System.Drawing.Size(102, 23);
            this.iconMenuItem3.Text = "VENTAS";
            this.iconMenuItem3.Click += new System.EventHandler(this.iconMenuItem3_Click);
            // 
            // iconMenuItem5
            // 
            this.iconMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.vENTASToolStripMenuItem});
            this.iconMenuItem5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconMenuItem5.ForeColor = System.Drawing.Color.Black;
            this.iconMenuItem5.IconChar = FontAwesome.Sharp.IconChar.Paperclip;
            this.iconMenuItem5.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem5.Name = "iconMenuItem5";
            this.iconMenuItem5.Size = new System.Drawing.Size(122, 23);
            this.iconMenuItem5.Text = "iNFORMES";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(204, 24);
            this.toolStripMenuItem1.Text = "CLIENTES";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(204, 24);
            this.toolStripMenuItem2.Text = "PRODUCTOS";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(204, 24);
            this.toolStripMenuItem3.Text = "PROVEEDORES";
            // 
            // vENTASToolStripMenuItem
            // 
            this.vENTASToolStripMenuItem.Name = "vENTASToolStripMenuItem";
            this.vENTASToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.vENTASToolStripMenuItem.Text = "VENTAS";
            this.vENTASToolStripMenuItem.Click += new System.EventHandler(this.vENTASToolStripMenuItem_Click);
            // 
            // iconMenuItem4
            // 
            this.iconMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem2,
            this.productosToolStripMenuItem2,
            this.proveedoresToolStripMenuItem,
            this.rubrosToolStripMenuItem,
            this.localidadesToolStripMenuItem,
            this.metodosDePagoToolStripMenuItem,
            this.mARCASToolStripMenuItem,
            this.cOLORESToolStripMenuItem});
            this.iconMenuItem4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconMenuItem4.ForeColor = System.Drawing.Color.Black;
            this.iconMenuItem4.IconChar = FontAwesome.Sharp.IconChar.TrashRestore;
            this.iconMenuItem4.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem4.Name = "iconMenuItem4";
            this.iconMenuItem4.Size = new System.Drawing.Size(124, 23);
            this.iconMenuItem4.Text = "PAPELERA";
            // 
            // clientesToolStripMenuItem2
            // 
            this.clientesToolStripMenuItem2.Name = "clientesToolStripMenuItem2";
            this.clientesToolStripMenuItem2.Size = new System.Drawing.Size(235, 24);
            this.clientesToolStripMenuItem2.Text = "CLIENTES";
            this.clientesToolStripMenuItem2.Click += new System.EventHandler(this.clientesToolStripMenuItem2_Click);
            // 
            // productosToolStripMenuItem2
            // 
            this.productosToolStripMenuItem2.Name = "productosToolStripMenuItem2";
            this.productosToolStripMenuItem2.Size = new System.Drawing.Size(235, 24);
            this.productosToolStripMenuItem2.Text = "PRODUCTOS";
            this.productosToolStripMenuItem2.Click += new System.EventHandler(this.productosToolStripMenuItem2_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(235, 24);
            this.proveedoresToolStripMenuItem.Text = "PROVEEDORES";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // rubrosToolStripMenuItem
            // 
            this.rubrosToolStripMenuItem.Name = "rubrosToolStripMenuItem";
            this.rubrosToolStripMenuItem.Size = new System.Drawing.Size(235, 24);
            this.rubrosToolStripMenuItem.Text = "CATEGORIA";
            this.rubrosToolStripMenuItem.Click += new System.EventHandler(this.rubrosToolStripMenuItem_Click);
            // 
            // localidadesToolStripMenuItem
            // 
            this.localidadesToolStripMenuItem.Name = "localidadesToolStripMenuItem";
            this.localidadesToolStripMenuItem.Size = new System.Drawing.Size(235, 24);
            this.localidadesToolStripMenuItem.Text = "LOCALIDADES";
            this.localidadesToolStripMenuItem.Click += new System.EventHandler(this.localidadesToolStripMenuItem_Click);
            // 
            // metodosDePagoToolStripMenuItem
            // 
            this.metodosDePagoToolStripMenuItem.Name = "metodosDePagoToolStripMenuItem";
            this.metodosDePagoToolStripMenuItem.Size = new System.Drawing.Size(235, 24);
            this.metodosDePagoToolStripMenuItem.Text = "METODOS DE PAGO";
            this.metodosDePagoToolStripMenuItem.Click += new System.EventHandler(this.metodosDePagoToolStripMenuItem_Click);
            // 
            // mARCASToolStripMenuItem
            // 
            this.mARCASToolStripMenuItem.Name = "mARCASToolStripMenuItem";
            this.mARCASToolStripMenuItem.Size = new System.Drawing.Size(235, 24);
            this.mARCASToolStripMenuItem.Text = "MARCAS";
            this.mARCASToolStripMenuItem.Click += new System.EventHandler(this.mARCASToolStripMenuItem_Click);
            // 
            // cOLORESToolStripMenuItem
            // 
            this.cOLORESToolStripMenuItem.Name = "cOLORESToolStripMenuItem";
            this.cOLORESToolStripMenuItem.Size = new System.Drawing.Size(235, 24);
            this.cOLORESToolStripMenuItem.Text = "COLORES";
            this.cOLORESToolStripMenuItem.Click += new System.EventHandler(this.cOLORESToolStripMenuItem_Click);
            // 
            // iconSplitButton1
            // 
            this.iconSplitButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconSplitButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconSplitButton1.IconColor = System.Drawing.Color.Black;
            this.iconSplitButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSplitButton1.IconSize = 48;
            this.iconSplitButton1.Name = "iconSplitButton1";
            this.iconSplitButton1.Rotation = 0D;
            this.iconSplitButton1.Size = new System.Drawing.Size(23, 23);
            this.iconSplitButton1.Text = "iconSplitButton1";
            // 
            // FormMENU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(140)))), ((int)(((byte)(174)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.PanelVisual);
            this.Controls.Add(this.Panelinf);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FormMENU";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormMENU_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Panelinf.ResumeLayout(false);
            this.Panelinf.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cLIENTESToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pROVEEDORESToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pRODUCTOSToolStripMenuItem1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem3;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rubrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metodosDePagoToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconSplitButton iconSplitButton1;
        private System.Windows.Forms.Label Reloj;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Panel Panelinf;
        private System.Windows.Forms.Panel PanelVisual;
        private System.Windows.Forms.ToolStripMenuItem mARCASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOLORESToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem vENTASToolStripMenuItem;
    }
}