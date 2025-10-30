using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class ConeCompras
    {
        #region conexion a BD
        Conexion cn = new Conexion();
        #endregion
        public void Agregar(Compra Compra)
        {
            OleDbConnection conexion = new OleDbConnection();
            OleDbCommand comando = new OleDbCommand();

            conexion.ConnectionString = cn.ConectarDB();
            comando.CommandType = System.Data.CommandType.Text;

            comando.CommandText = "INSERT INTO Compras(IdProveedor, IdMetodo, Total) VALUES (@IdProveedor, @IdMetodo, @Total)";
            comando.Connection = conexion;

            comando.Parameters.AddWithValue("@IdProveedor", Compra.IdProveedor);
            comando.Parameters.AddWithValue("@IdMetodo", Compra.IdMetodo);
            comando.Parameters.AddWithValue("@TotalCompra", Compra.Total);
          
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public List<Compra> ListarComprasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Compra> ventas = new List<Compra>();
            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            {
                string query = "SELECT c.IdCompra, c.IdProveedor, c.IdMetodo, c.Total, c.Fecha, " +
                               "p.RazonSocial, m.Descripcion AS MetodoDescripcion " +
                               "FROM (Compras AS c " +
                               "INNER JOIN Proveedores AS p ON c.IdProveedor = p.IdProveedor) " +
                               "INNER JOIN Metodos AS m ON c.IdMetodo = m.IdMetodo " +
                               "WHERE c.Fecha >= ? AND c.Fecha <= ?;";


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
                        Compra compra = new Compra()
                        {
                            IdCompra = reader.GetInt32(0),
                            IdProveedor = reader.GetInt32(1),
                            IdMetodo = reader.GetInt32(2),
                            Total = reader.GetDecimal(3),
                            FechaCompra = reader.GetDateTime(4),
                            RazonSocial = reader.GetString(5),
                            MetodoDescripcion = reader.GetString(6)
                        };

                        ventas.Add(compra);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al listar las compras por fecha: " + ex.Message);
                }
            }

            return ventas;
        }
    }
}
