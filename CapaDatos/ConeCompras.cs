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
    }
}
