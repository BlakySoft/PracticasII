using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Extras
{
    public class CustomToolTip : ToolTip //Esto es experimental y esta sujeto a muchos cambios
    {

        #region Prueba de dibujado manual
        public CustomToolTip()
        {
            OwnerDraw = true;
            Draw += CustomToolTip_Draw;
        }
        

        private void CustomToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            int radio = 5; // radio del borde redondeado
            Rectangle rect = new Rectangle(Point.Empty, e.Bounds.Size);

            using (GraphicsPath path = CrearBordeRedondeado(rect, radio))
            using (SolidBrush fondo = new SolidBrush(Color.White))
            using (Pen borde = new Pen(Color.Gray, 1.5f))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(fondo, path);
                e.Graphics.DrawPath(borde, path);

                // Dibuja el texto centrado dentro del rectángulo
                TextRenderer.DrawText(
                    e.Graphics,
                    e.ToolTipText,
                    SystemFonts.DefaultFont,
                    rect,
                    Color.Black,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );
            }

        }

        GraphicsPath CrearBordeRedondeado(Rectangle rect, int radio)
        {
            float r = radio * 2f;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, r, r, 180, 90);

            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();

            return path;
        }




        GraphicsPath CrearBordeConPunta(Rectangle rectInt, int radio, int puntaAncho = 16, int puntaAlto = 8) //No esta terminado
        {
            // Convertimos a float para trabajar con precisión
            RectangleF rect = new RectangleF(rectInt.X, rectInt.Y, rectInt.Width, rectInt.Height);
            float d = radio * 2f;
            GraphicsPath path = new GraphicsPath();

            // ----- ESQUINA SUPERIOR IZQUIERDA (arco) -----
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);

            // Punto donde terminaría el arco superior-izq y comienza la línea superior
            float topArcEndX = rect.X + rect.Width - d; // x donde normalmente empezaría el arco superior derecho

            // ----- LÍNEA HASTA INICIO DE LA PUNTA -----
            // Dejamos un pequeño espacio antes de la punta para que no toque el arco inferior derecho
            float inicioPuntaX = topArcEndX - puntaAncho; // punto en el borde superior donde inicia la punta
            path.AddLine(rect.X + radio, rect.Y, inicioPuntaX, rect.Y);

            // ----- PUNTA (triángulo hacia arriba) -----
            float apexX = inicioPuntaX + (puntaAncho / 2f); // centro de la punta
            float apexY = rect.Y - puntaAlto;               // altura de la punta (por encima del borde superior)
                                                            // Línea desde inicioPuntaX hacia ápice y luego hacia el borde derecho (ligeramente hacia abajo para conectar)
            path.AddLine(inicioPuntaX, rect.Y, apexX, apexY);
            path.AddLine(apexX, apexY, rect.Right, rect.Y + radio); // conecta hacia la zona de la "esquina derecha"

            // ----- ESQUINA INFERIOR DERECHA (arco) -----
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 270, 90);

            // ----- ESQUINA INFERIOR IZQUIERDA (arco) -----
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);

            path.CloseFigure();
            return path;
        }

        #endregion
    }
}
