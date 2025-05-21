using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public int IdProveedor { get; set; }
        public int IdMetodo { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
