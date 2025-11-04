namespace CapaPresentacion
{
    partial class FormConfiguracion
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
            this.lblAlerta = new System.Windows.Forms.Label();
            this.txtLimiteStock = new System.Windows.Forms.TextBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.BtnSalir = new FontAwesome.Sharp.IconButton();
            this.BtnGrabar = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // lblAlerta
            // 
            this.lblAlerta.AutoSize = true;
            this.lblAlerta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlerta.Location = new System.Drawing.Point(28, 9);
            this.lblAlerta.Name = "lblAlerta";
            this.lblAlerta.Size = new System.Drawing.Size(203, 19);
            this.lblAlerta.TabIndex = 0;
            this.lblAlerta.Text = "Stock Mínimo para Alerta:";
            // 
            // txtLimiteStock
            // 
            this.txtLimiteStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLimiteStock.Location = new System.Drawing.Point(32, 42);
            this.txtLimiteStock.Name = "txtLimiteStock";
            this.txtLimiteStock.Size = new System.Drawing.Size(180, 26);
            this.txtLimiteStock.TabIndex = 1;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(230, 43);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(29, 26);
            this.iconButton1.TabIndex = 51;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.IconChar = FontAwesome.Sharp.IconChar.X;
            this.BtnSalir.IconColor = System.Drawing.Color.White;
            this.BtnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnSalir.IconSize = 30;
            this.BtnSalir.Location = new System.Drawing.Point(235, 124);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(24, 25);
            this.BtnSalir.TabIndex = 52;
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGrabar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.BtnGrabar.FlatAppearance.BorderSize = 0;
            this.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGrabar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGrabar.ForeColor = System.Drawing.Color.White;
            this.BtnGrabar.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            this.BtnGrabar.IconColor = System.Drawing.Color.White;
            this.BtnGrabar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnGrabar.IconSize = 30;
            this.BtnGrabar.Location = new System.Drawing.Point(55, 90);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(126, 41);
            this.BtnGrabar.TabIndex = 53;
            this.BtnGrabar.Text = "Grabar";
            this.BtnGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGrabar.UseVisualStyleBackColor = false;
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // FormConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(266, 161);
            this.Controls.Add(this.BtnGrabar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.txtLimiteStock);
            this.Controls.Add(this.lblAlerta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion";
            this.Load += new System.EventHandler(this.FormConfiguracion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAlerta;
        private System.Windows.Forms.TextBox txtLimiteStock;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton BtnSalir;
        private FontAwesome.Sharp.IconButton BtnGrabar;
    }
}