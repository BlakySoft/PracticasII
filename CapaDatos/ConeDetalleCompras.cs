using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConeDetalleCompras
    {
        #region conexion a BD
        Conexion cn = new Conexion();
        #endregion
        public List<DetalleCompra> ListarDetallesPorCompra(int idVenta)
        {
            List<DetalleCompra> detalles = new List<DetalleCompra>();

            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            {
                string query = "SELECT d.IdCompra, d.IdProducto, p.Descripcion AS DetalleProducto, " +
                               "d.PrecioCompra, d.Cantidad, d.Subtotal " +
                               "FROM DetalleCompras AS d " +
                               "INNER JOIN Productos AS p ON d.IdProducto = p.IdProducto " +
                               "WHERE d.IdCompra = ?";

                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("?", idVenta);

                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DetalleCompra detalle = new DetalleCompra()
                        {
                            IdCompra = reader.GetInt32(0),
                            IdProducto = reader.GetInt32(1),
                            DetalleProducto = reader.GetString(2),
                            PrecioCompra = reader.GetDecimal(3),
                            Cantidad = reader.GetInt32(4),
                            Subtotal = reader.GetDecimal(5)
                        };

                        detalles.Add(detalle);
                    }
                }
                finally
                {
                    con.Close();
                }
            }

            return detalles;
        }
    }
}
