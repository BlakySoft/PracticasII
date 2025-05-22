using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class ConeProductos
    {
        #region conexion a BD
        public string ConectarDB()
        {
            OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|elfrancesrances.mdb;");
            string cadenaconexion = ("Provider =Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            return cadenaconexion;
        }
        #endregion
        public void Agregar(Productos Prod)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = "insert into Productos(Descripcion, Detalle, IdCat, Precio, Stock, Estado) values (@Descripcion, @Detalle, @IdCat, @Precio, @Stock, true)";
            cm.Connection = con;

            cm.Parameters.AddWithValue("Descripcion", Prod.Descripcion);
            cm.Parameters.AddWithValue("Detalle", Prod.Detalle);
            cm.Parameters.AddWithValue("IdCat", Prod.IdCat);
            cm.Parameters.AddWithValue("Precio", Prod.Precio);
            cm.Parameters.AddWithValue("Stock", Prod.Stock);

            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
        }
        public void Actualizar(Productos Prod)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Productos set Descripcion=@Descripcion, Detalle=@Detalle, IdCat=@IdCat, Precio=@Precio, Stock=@Stock where IdProducto = {Prod.IdProducto}";
            cm.Connection = con;


            cm.Parameters.AddWithValue("Descripcion", Prod.Descripcion);
            cm.Parameters.AddWithValue("Detalle", Prod.Detalle);
            cm.Parameters.AddWithValue("IdCat", Prod.IdCat);
            cm.Parameters.AddWithValue("Precio", Prod.Precio);
            cm.Parameters.AddWithValue("Stock", Prod.Stock);

            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
        }
        public void Borrar(Productos Prod)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Productos set Estado = false where IdProducto = {Prod.IdProducto}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void Recuperar(Productos Prod)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Productos set Estado = true where IdProducto = {Prod.IdProducto}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public List<Productos> ListarPapelera()
        {
            List<Productos> list = new List<Productos>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Productos WHERE Estado = false";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Productos Prod = new Productos();

                Prod.IdProducto = reader.GetInt32(0);
                Prod.Descripcion = reader.GetString(1);
                Prod.Detalle = reader.GetString(2);
                Prod.IdCat = reader.GetInt32(3);
                Prod.IdOrigen = reader.GetInt32(4);
                Prod.IdMarca = reader.GetInt32(5);
                Prod.IdColor = reader.GetInt32(6);
                Prod.Precio = reader.GetDecimal(7);
                Prod.Stock = reader.GetInt32(8);


                list.Add(Prod);
            }
            con.Close();

            return list;
        }
        public List<Productos> Listar()
        {
            List<Productos> list = new List<Productos>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Productos WHERE Estado = true";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Productos Prod = new Productos();

                Prod.IdProducto = reader.GetInt32(0);
                Prod.Descripcion = reader.GetString(1);
                Prod.Detalle = reader.GetString(2);
                Prod.IdCat = reader.GetInt32(3);
                Prod.IdOrigen = reader.GetInt32(4);

                Prod.IdMarca = reader.GetInt32(5);
                Prod.IdColor = reader.GetInt32(6);
                Prod.Precio = reader.GetDecimal(7);
                Prod.Stock = reader.GetInt32(8);

                list.Add(Prod);
            }
            con.Close();

            return list;
        }
        public List<Productos> Buscar(string Descripcion)
        {
            List<Productos> list = new List<Productos>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"SELECT IdProducto, Descripcion, Detalle, IdCat, Precio, Stock FROM Productos WHERE Descripcion LIKE ('%{Descripcion}%') AND Estado = true";
            cm.Connection = con;
            con.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {
                Productos Prod = new Productos();

                Prod.IdProducto = reader.GetInt32(0);
                Prod.Descripcion = reader.GetString(1);
                Prod.Detalle = reader.GetString(2);
                Prod.IdCat = reader.GetInt32(3);
                Prod.Precio = reader.GetDecimal(4);
                Prod.Stock = reader.GetInt32(5);


                list.Add(Prod);
            }

            con.Close();
            return list;
        }
        public List<Productos> BuscarPapelera(string Descripcion)
        {
            List<Productos> list = new List<Productos>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"SELECT IdProducto, Descripcion, Detalle, IdCat, Precio, Stock FROM Productos WHERE Descripcion LIKE ('%{Descripcion}%') AND Estado = false";
            cm.Connection = con;
            con.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {
                Productos Prod = new Productos();

                Prod.IdProducto = reader.GetInt32(0);
                Prod.Descripcion = reader.GetString(1);
                Prod.Detalle = reader.GetString(2);
                Prod.IdCat = reader.GetInt32(3);
                Prod.Precio = reader.GetDecimal(4);
                Prod.Stock = reader.GetInt32(5);


                list.Add(Prod);
            }

            con.Close();
            return list;
        }
    }
}
