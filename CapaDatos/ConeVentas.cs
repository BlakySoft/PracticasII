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
        
        public void AgregarPedido(Venta pedido)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
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
        public string ConectarDB()
        {
            _ = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            return "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|DB.mdb;";

        }
        public List<Venta> ListarPedidoPendiente()
        {
            List<Venta> pedidos = new List<Venta>();
            OleDbConnection con = new OleDbConnection(ConectarDB());  

            string query = "SELECT p.IdVenta, p.IdCliente, p.IdMetodo, p.IdEntrega, p.Total, p.Fecha, c.Nombre AS ClienteNombre, m.Descripcion AS MetodoDescripcion, e.Descripcion AS EntregaDescripcion " +
                           "FROM ((Pedidos AS p " +
                           "INNER JOIN Clientes AS c ON p.IdCliente = c.IdCliente) " +
                           "INNER JOIN Metodos AS m ON p.IdMetodo = m.IdMetodo) " +
                           "INNER JOIN Entregas AS e ON p.IdEntrega = e.IdEntrega " +
                           "WHERE p.IdEntrega = 1;";

            OleDbCommand cmd = new OleDbCommand(query, con);

            try
            {
                con.Open();  
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Venta pedido = new Venta()
                    {
                        IdVenta = reader.GetInt32(0),
                        IdCliente = reader.GetInt32(1),
                        IdMetodo = reader.GetInt32(2),
                        IdEntrega = reader.GetInt32(3),
                        Total = reader.GetDecimal(4),
                        Fecha = reader.GetDateTime(5)
                    };

                
                    pedido.ClienteNombre = reader.GetString(6);
                    pedido.MetodoDescripcion = reader.GetString(7);
                    pedido.EntregaDescripcion = reader.GetString(8); 

                    pedidos.Add(pedido);
                }
            }
            catch (Exception ex)
            {
                // Muestra el error en la consola o en el lugar apropiado
                Console.WriteLine("Error al listar pedidos: " + ex.Message);
            }
            finally
            {
                con.Close();  // Cierra la conexión
            }

            return pedidos;
        }
        public List<Venta> ListarPedidoEntregado()
        {
            List<Venta> pedidos = new List<Venta>();
            OleDbConnection con = new OleDbConnection(ConectarDB()); 

            string query = "SELECT p.IdVenta, p.IdCliente, p.IdMetodo, p.IdEntrega, p.Total, p.Fecha, c.Nombre AS ClienteNombre, m.Descripcion AS MetodoDescripcion, e.Descripcion AS EntregaDescripcion " +
                           "FROM ((Pedidos AS p " +
                           "INNER JOIN Clientes AS c ON p.IdCliente = c.IdCliente) " +
                           "INNER JOIN Metodos AS m ON p.IdMetodo = m.IdMetodo) " +
                           "INNER JOIN Entregas AS e ON p.IdEntrega = e.IdEntrega " +
                           "WHERE p.IdEntrega = 2;";

            OleDbCommand cmd = new OleDbCommand(query, con);

            try
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Venta pedido = new Venta()
                    {
                        IdVenta = reader.GetInt32(0),
                        IdCliente = reader.GetInt32(1),
                        IdMetodo = reader.GetInt32(2),
                        IdEntrega = reader.GetInt32(3),
                        Total = reader.GetDecimal(4),
                        Fecha = reader.GetDateTime(5)
                    };

                    pedido.ClienteNombre = reader.GetString(6);
                    pedido.MetodoDescripcion = reader.GetString(7);
                    pedido.EntregaDescripcion = reader.GetString(8); 

                    pedidos.Add(pedido);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar pedidos: " + ex.Message);
            }
            finally
            {
                con.Close(); 
            }

            return pedidos;
        }
        public List<Venta> ListarPedidoCancelado()
        {
            List<Venta> pedidos = new List<Venta>();

            OleDbConnection con = new OleDbConnection(ConectarDB());  

            string query = "SELECT p.IdVenta, p.IdCliente, p.IdMetodo, p.IdEntrega, p.Total, p.Fecha, c.Nombre AS ClienteNombre, m.Descripcion AS MetodoDescripcion, e.Descripcion AS EntregaDescripcion " +
                           "FROM ((Pedidos AS p " +
                           "INNER JOIN Clientes AS c ON p.IdCliente = c.IdCliente) " +
                           "INNER JOIN Metodos AS m ON p.IdMetodo = m.IdMetodo) " +
                           "INNER JOIN Entregas AS e ON p.IdEntrega = e.IdEntrega " +
                           "WHERE p.IdEntrega = 3;";

            OleDbCommand cmd = new OleDbCommand(query, con);

            try
            {
                con.Open();  // Abre la conexión
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Venta pedido = new Venta()
                    {
                        IdVenta = reader.GetInt32(0),
                        IdCliente = reader.GetInt32(1),
                        IdMetodo = reader.GetInt32(2),
                        IdEntrega = reader.GetInt32(3),
                        Total = reader.GetDecimal(4),
                        Fecha = reader.GetDateTime(5)
                    };

                    // Asignamos las propiedades adicionales obtenidas en el JOIN
                    pedido.ClienteNombre = reader.GetString(6);
                    pedido.MetodoDescripcion = reader.GetString(7);
                    pedido.EntregaDescripcion = reader.GetString(8); // Descripción de la entrega

                    pedidos.Add(pedido);
                }
            }
            catch (Exception ex)
            {
                // Muestra el error en la consola o en el lugar apropiado
                Console.WriteLine("Error al listar pedidos: " + ex.Message);
            }
            finally
            {
                con.Close();  // Cierra la conexión
            }

            return pedidos;
        }
        public void EntregarPedido(int IdVenta)
        {
            OleDbConnection con = new OleDbConnection(ConectarDB());

            string query = "UPDATE Pedidos SET IdEntrega = 2 WHERE IdVenta = @IdVenta";
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@IdVenta", IdVenta);

            con.Open();
            cmd.ExecuteNonQuery();

            con.Close();
        }
        public void CancelarPedido(int IdVenta)
        {
            OleDbConnection con = new OleDbConnection(ConectarDB());

            string query = "UPDATE Pedidos SET IdEntrega = 3 WHERE IdVenta = @IdVenta";

            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@IdVenta", IdVenta);

            con.Open();
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
