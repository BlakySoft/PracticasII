using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Extras
{
    /* 
       Esto es un form modificiado para que funcione como un tooltip totalmente personalizable.

       Tuve bastante ayuda de chatGPT pero igual no saben lo que costó llegar a la configuracion correcta.
       Espero que sepan valorar este codigo, yo me lo voy a guardar para futuros proyectos. 

       Traté de que sea lo más personalizable posible e intenté dejar comentarios en cada parte importante.
       Son libres de modificarlo a su gusto.
    */

    public class CustomToolTipForm : Form  
    {

        #region Configuracion General

        public bool IsRounded { get; set; } = false; //Con esto se define si el tooltip es redondeado o cuadrado (En el futuro...)
        public int cornerRad { get; set; } = 10; // Con esto se define el radio de las esquinas redondeadas (En el futuro...
        public Color bgColor { get; set; } = Color.FromArgb(40, 40, 40); //Fondo del tooltip

        public Color bdColor { get; set; } = Color.DeepPink; //Color del borde del tooltip
        public float bdThick { get; set; } = 4f; //Grosor del borde del tooltip

        public int ArrowH { get; set; } = 20; //Altura de la flecha del tooltip 
        public int ArrowW { get; set; } = 20; //Ancho de la flecha del tooltip

        #endregion

        #region Controles Internos
        private readonly Label lblMensaje = new Label
        {
            ForeColor = Color.White,
            TextAlign = ContentAlignment.MiddleLeft,
            AutoSize = true,
            Font = new Font("Segoe UI", 10),

        };

        private readonly PictureBox picIcono = new PictureBox
        {
            Image = SystemIcons.Warning.ToBitmap(),
            SizeMode = PictureBoxSizeMode.AutoSize,
        };
        #endregion

        public enum ArrowDirection
        {
            Up,
            Down,
            Left,
            Right
        }
        private ArrowDirection arrowDirection = ArrowDirection.Up;

        public CustomToolTipForm(string mensaje) //Constructor que recibe el mensaje que se va a mostrar
        {
            
            lblMensaje.Text = mensaje;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = bgColor;
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            AutoSize = true;
            Size = new Size(0,0);
            TopMost = true;
            Opacity = 0.9;
            Padding = new Padding(8);
            

            const int separacion = 10; 

            lblMensaje.Location = new Point(10 + picIcono.Right, ArrowH + separacion +7 );
            picIcono.Location = new Point(10, ArrowH + separacion);


            Controls.Add(lblMensaje);
            Controls.Add(picIcono);

            
            Region = new Region(CreateRegionN(ClientRectangle, cornerRad));

            

        }

        private void AjustarLayoutInterno() //No es lo ideal pero antes de reescribir el constructor mejor esto
        {
            const int separacion = 10;

            if (arrowDirection == ArrowDirection.Up)
            {
                lblMensaje.Location = new Point(10 + picIcono.Right, ArrowH + separacion + 7);
                picIcono.Location = new Point(10, ArrowH + separacion);
            }
            else if (arrowDirection == ArrowDirection.Down)
            {
                lblMensaje.Location = new Point(10 + picIcono.Right, separacion);
                picIcono.Location = new Point(10, separacion);
            }
        }
        public void MostrarN(Control target)
        {
            var screenArea = Screen.GetWorkingArea(target);
            var controlRect = target.RectangleToScreen(target.ClientRectangle);
            var tipSize = this.Size;
            const int marginV = 0;
            int marginH = (target.Width + ArrowW) / 2 ;

            // Espacio disponible en cada dirección
            int espacioArriba = controlRect.Top - screenArea.Top;
            int espacioAbajo = screenArea.Bottom - controlRect.Bottom;

            Point location;

            // Elegir dirección con más espacio
            if (espacioAbajo >= tipSize.Height + marginV)
            {
                // Mostrar debajo del control
                arrowDirection = ArrowDirection.Up; 
                location = new Point(
                    controlRect.Left - Width + marginH,
                    controlRect.Bottom + marginV
                );

            }
            else
            {
                // Mostrar arriba del control
                arrowDirection = ArrowDirection.Down;
                location = new Point(
                    controlRect.Left - Width + marginH,
                    controlRect.Top - tipSize.Height - marginV
                );
            }

            AjustarLayoutInterno();

            // Mostrar tooltip
            this.Location = location;
            this.Opacity = 0;
            this.Show();

            // Animación fade-in
            var fadeIn = new Timer { Interval = 30 };
            fadeIn.Tick += (s, e) =>
            {
                if (this.Opacity < 0.9)
                    this.Opacity += 0.05;
                else
                {
                    fadeIn.Stop();
                    fadeIn.Dispose();
                }
            };
            fadeIn.Start();

            // Cierre automático
            var hideTimer = new Timer { Interval = 6000 };
            hideTimer.Tick += (s, e) =>
            {
                this.Close();
                hideTimer.Stop();
                hideTimer.Dispose();
            };
            hideTimer.Start();


        }

        private GraphicsPath CreateRegionN(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int i = ArrowH;
            int A = ArrowW;
            int p = A / 2;

            switch (arrowDirection)
            {
                case ArrowDirection.Up:
                    // Flecha arriba
                    path.AddLine(bounds.X, bounds.Y + i, bounds.X + bounds.Width - A, bounds.Y + i);
                    path.AddLine(bounds.X + bounds.Width - A, bounds.Y + i, bounds.X + bounds.Width - p, bounds.Y);
                    path.AddLine(bounds.X + bounds.Width - p, bounds.Y, bounds.X + bounds.Width, bounds.Y + i);

                    path.AddLine(bounds.X + bounds.Width, bounds.Y + i, bounds.Right, bounds.Bottom);
                    path.AddLine(bounds.Right, bounds.Bottom, bounds.X, bounds.Bottom);
                    break;

                case ArrowDirection.Down:
                    // Flecha abajo
                    path.AddLine(bounds.X, bounds.Y, bounds.Right, bounds.Y);
                    path.AddLine(bounds.Right, bounds.Y, bounds.Right, bounds.Bottom - i);

                    path.AddLine(bounds.Right, bounds.Bottom - i, bounds.Right - p, bounds.Bottom);
                    path.AddLine(bounds.Right - p, bounds.Bottom, bounds.Right - A, bounds.Bottom - i);
                    path.AddLine(bounds.Right - A, bounds.Bottom - i, bounds.X, bounds.Bottom - i);
                    break;

                
            }


            path.CloseFigure();
            return path;
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            this.Region = new Region(CreateRegionN(ClientRectangle, cornerRad));
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) //Esto le da el borde al tooltip
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            
            using (GraphicsPath path = CreateRegionN(ClientRectangle, cornerRad))
            using (Pen pen = new Pen(bdColor, bdThick))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

    }
}
