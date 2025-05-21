using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Productos
    {
        public int IdProducto { get; set; }
         public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public int IdRubro { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }

    }
}
