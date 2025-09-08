namespace CapaPresentacion
{
    partial class FormBuscarProducto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.LblBuscar = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grilla
            // 
            this.Grilla.AllowUserToAddRows = false;
            this.Grilla.AllowUserToDeleteRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White;
            this.Grilla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.Grilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grilla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Grilla.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(216)))), ((int)(((byte)(228)))));
            this.Grilla.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Grilla.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.Grilla.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grilla.DefaultCellStyle = dataGridViewCellStyle18;
            this.Grilla.EnableHeadersVisualStyles = false;
            this.Grilla.GridColor = System.Drawing.Color.Tan;
            this.Grilla.Location = new System.Drawing.Point(12, 63);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grilla.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.White;
            this.Grilla.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(343, 269);
            this.Grilla.TabIndex = 43;
            this.Grilla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grilla_CellClick);
            this.Grilla.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grilla_CellDoubleClick);
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.BackColor = System.Drawing.Color.White;
            this.TxtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBuscar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.ForeColor = System.Drawing.Color.Black;
            this.TxtBuscar.Location = new System.Drawing.Point(94, 14);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(228, 26);
            this.TxtBuscar.TabIndex = 42;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // LblBuscar
            // 
            this.LblBuscar.AutoSize = true;
            this.LblBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.LblBuscar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBuscar.ForeColor = System.Drawing.Color.White;
            this.LblBuscar.Location = new System.Drawing.Point(3, 16);
            this.LblBuscar.Name = "LblBuscar";
            this.LblBuscar.Size = new System.Drawing.Size(95, 19);
            this.LblBuscar.TabIndex = 41;
            this.LblBuscar.Text = "Productos:";
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(212, 338);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(115, 38);
            this.iconButton1.TabIndex = 44;
            this.iconButton1.Text = "&Volver";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.iconButton2);
            this.panel1.Controls.Add(this.TxtBuscar);
            this.panel1.Controls.Add(this.LblBuscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 57);
            this.panel1.TabIndex = 45;
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.iconButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 30;
            this.iconButton2.Location = new System.Drawing.Point(327, 13);
            this.iconButton2.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(29, 26);
            this.iconButton2.TabIndex = 50;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // FormBuscarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(234)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(375, 388);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.Grilla);
            this.Name = "FormBuscarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Poductos";
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.Label LblBuscar;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton2;
    }
}