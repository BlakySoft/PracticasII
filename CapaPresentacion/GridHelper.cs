using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public static class GridHelper
    {
        public static void ResizeColumns(DataGridView dgv)
        {
            //Esta funcion solo necesita la grilla que se requiera redimencionar

            int wGrilla = dgv.ClientSize.Width; // Ancho total de la grilla
            int n = dgv.Columns.GetColumnCount(DataGridViewElementStates.Visible); // Cantidad de columnas visibles
            int sumaColumnas = dgv.Columns.GetColumnsWidth(DataGridViewElementStates.Visible); // Suma del ancho de las columnas visibles

            int resto = wGrilla - sumaColumnas; // Calculo el espacio restante
            int sizable = resto / n; // Calculo cuánto le corresponde incrementar a cada columna


            if (resto > 0) //Si hay espacio restante, lo distribuyo
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    col.Width = col.Width + sizable; // Incremento el ancho de cada columna

                }

            }
            else if (resto < 0) // Si no hay espacio, reduzco proporcionalmente
            {

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    col.Width = col.Width + sizable; // Decremento el ancho de cada columna
                }
            }

        }
    }
}
