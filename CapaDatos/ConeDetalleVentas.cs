using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using CapaNegocio;

namespace CapaDatos
{
    public class ConeDetalleVentas
    {
        #region conexion a BD
        Conexion cn = new Conexion();
        #endregion
        public List<DetalleVenta> ListarDetallesPorVenta(int idVenta)
        {
            List<DetalleVenta> detalles = new List<DetalleVenta>();

            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            {
                string query = "SELECT d.IdVenta, d.IdProducto, p.[Descripcion] AS DetalleProducto, " +
                               "d.PrecioVenta, d.Cantidad, d.Subtotal " +
                               "FROM DetalleVentas AS d " +
                               "INNER JOIN Productos AS p ON d.IdProducto = p.IdProducto " +
                               "WHERE d.IdVenta = ?";

                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("?", idVenta);

                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DetalleVenta detalle = new DetalleVenta()
                        {
                            IdVenta = reader.GetInt32(0),
                            IdProducto = reader.GetInt32(1),
                            DetalleProducto = reader.GetString(2),
                            PrecioVenta = reader.GetDecimal(3),
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
