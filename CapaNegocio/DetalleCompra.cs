using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class DetalleCompra
    {
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public string DetalleProducto { get; set; }
        public decimal PrecioCompra { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
