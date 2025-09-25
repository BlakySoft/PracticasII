using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class DetalleVenta
    {

        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }

        // Propiedades adicionales para los detalles del JOIN
        public string DetalleProducto{ get; set; }
    }
}
