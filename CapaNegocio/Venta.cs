using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdMetodo { get; set; }
        public string ClienteNombre { get; set; }
        public string MetodoDescripcion { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

       
    }
}
