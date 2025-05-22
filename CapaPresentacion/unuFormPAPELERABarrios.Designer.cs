namespace CapaPresentacion
{
    partial class unuFormPAPELERABarrios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlBarraLateral = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.BtnRecuperar = new FontAwesome.Sharp.IconButton();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.LblBuscar = new System.Windows.Forms.Label();
            this.LblIdBarrio = new System.Windows.Forms.Label();
            this.PnlBarraLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlBarraLateral
            // 
            this.PnlBarraLateral.BackColor = System.Drawing.Color.AntiqueWhite;
            this.PnlBarraLateral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlBarraLateral.Controls.Add(this.iconButton1);
            this.PnlBarraLateral.Controls.Add(this.BtnRecuperar);
            this.PnlBarraLateral.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBarraLateral.Location = new System.Drawing.Point(0, 226);
            this.PnlBarraLateral.Name = "PnlBarraLateral";
            this.PnlBarraLateral.Size = new System.Drawing.Size(321, 66);
            this.PnlBarraLateral.TabIndex = 2;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.Tan;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(257, 12);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(51, 41);
            this.iconButton1.TabIndex = 45;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // BtnRecuperar
            // 
            this.BtnRecuperar.BackColor = System.Drawing.Color.Tan;
            this.BtnRecuperar.FlatAppearance.BorderSize = 0;
            this.BtnRecuperar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRecuperar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRecuperar.ForeColor = System.Drawing.Color.White;
            this.BtnRecuperar.IconChar = FontAwesome.Sharp.IconChar.SquareCheck;
            this.BtnRecuperar.IconColor = System.Drawing.Color.White;
            this.BtnRecuperar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnRecuperar.IconSize = 30;
            this.BtnRecuperar.Location = new System.Drawing.Point(12, 12);
            this.BtnRecuperar.Name = "BtnRecuperar";
            this.BtnRecuperar.Size = new System.Drawing.Size(129, 41);
            this.BtnRecuperar.TabIndex = 30;
            this.BtnRecuperar.Text = "Recuperar";
            this.BtnRecuperar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnRecuperar.UseVisualStyleBackColor = false;
            this.BtnRecuperar.Click += new System.EventHandler(this.BtnRecuperar_Click);
            // 
            // Grilla
            // 
            this.Grilla.AllowUserToAddRows = false;
            this.Grilla.AllowUserToDeleteRows = false;
            this.Grilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grilla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Grilla.BackgroundColor = System.Drawing.Color.Linen;
            this.Grilla.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Grilla.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.BurlyWood;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.BurlyWood;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grilla.DefaultCellStyle = dataGridViewCellStyle6;
            this.Grilla.EnableHeadersVisualStyles = false;
            this.Grilla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Grilla.Location = new System.Drawing.Point(12, 37);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.BurlyWood;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grilla.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.Grilla.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(296, 177);
            this.Grilla.TabIndex = 37;
            this.Grilla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grilla_CellClick);
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.BackColor = System.Drawing.Color.White;
            this.TxtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.ForeColor = System.Drawing.Color.Black;
            this.TxtBuscar.Location = new System.Drawing.Point(99, 6);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(209, 26);
            this.TxtBuscar.TabIndex = 35;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // LblBuscar
            // 
            this.LblBuscar.AutoSize = true;
            this.LblBuscar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBuscar.ForeColor = System.Drawing.Color.Black;
            this.LblBuscar.Location = new System.Drawing.Point(23, 9);
            this.LblBuscar.Name = "LblBuscar";
            this.LblBuscar.Size = new System.Drawing.Size(70, 19);
            this.LblBuscar.TabIndex = 34;
            this.LblBuscar.Text = "Buscar:";
            // 
            // LblIdBarrio
            // 
            this.LblIdBarrio.AutoSize = true;
            this.LblIdBarrio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIdBarrio.ForeColor = System.Drawing.Color.Black;
            this.LblIdBarrio.Location = new System.Drawing.Point(9, 9);
            this.LblIdBarrio.Name = "LblIdBarrio";
            this.LblIdBarrio.Size = new System.Drawing.Size(17, 18);
            this.LblIdBarrio.TabIndex = 1;
            this.LblIdBarrio.Text = "0";
            // 
            // FormPAPELERABarrios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(321, 292);
            this.Controls.Add(this.LblIdBarrio);
            this.Controls.Add(this.Grilla);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.LblBuscar);
            this.Controls.Add(this.PnlBarraLateral);
            this.Name = "FormPAPELERABarrios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Papelera de barrios";
            this.PnlBarraLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlBarraLateral;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.Label LblBuscar;
        private FontAwesome.Sharp.IconButton BtnRecuperar;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Label LblIdBarrio;
    }
}