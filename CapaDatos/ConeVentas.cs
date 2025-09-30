using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConeVentas
    {
        #region conexion a BD
        Conexion cn = new Conexion();
        #endregion
        public void AgregarPedido(Venta pedido)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = cn.ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = "insert into Ventas (IdCliente, IdMetodo, Total) values (@IdCliente, @IdMetodo, @Total)";
            cm.Connection = cone;

            cm.Parameters.AddWithValue("@IdCliente", pedido.IdCliente);
            cm.Parameters.AddWithValue("@IdMetodo", pedido.IdMetodo);
            cm.Parameters.AddWithValue("@Total", pedido.Total);

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        
        public List<Venta> ListarVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Venta> ventas = new List<Venta>();
            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            {
                string query = "SELECT v.IdVenta, v.IdCliente, v.IdMetodo, v.Total, v.Fecha, " +
                               "c.Nombre AS ClienteNombre, m.Descripcion AS MetodoDescripcion " +
                               "FROM (Ventas AS v " +
                               "INNER JOIN Clientes AS c ON v.IdCliente = c.IdCliente) " +
                               "INNER JOIN Metodos AS m ON v.IdMetodo = m.IdMetodo " +
                               "WHERE v.Fecha >= ? AND v.Fecha <= ?;";


                DateTime inicio = fechaInicio.Date;               
                DateTime fin = fechaFin.Date.AddDays(1).AddSeconds(-1);
                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.Parameters.Add("?", OleDbType.Date).Value = inicio;
                cmd.Parameters.Add("?", OleDbType.Date).Value = fin;

                try
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Venta venta = new Venta()
                        {
                            IdVenta = reader.GetInt32(0),
                            IdCliente = reader.GetInt32(1),
                            IdMetodo = reader.GetInt32(2),
                            Total = reader.GetDecimal(3),
                            Fecha = reader.GetDateTime(4),
                            ClienteNombre = reader.GetString(5),
                            MetodoDescripcion = reader.GetString(6)
                        };

                        ventas.Add(venta);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al listar ventas por fecha: " + ex.Message);
                }
            }

            return ventas;
        }

    }
}
