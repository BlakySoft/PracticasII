using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConeMateria
    {
        #region conexion a BD
        public string ConectarDB()
        {
            OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|elfrancesrances.mdb;");
            string cadenaconexion = ("Provider =Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|elfrances.mdb;");
            return cadenaconexion;
        }
            #endregion

        public void Agregar(Materia materia)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = "insert into Materias (Descripcion, Detalle, Precio, Stock, Estado) values (@Descripcion, @Detalle, @Precio, @Stock, true)";
            cm.Connection = con;

            cm.Parameters.AddWithValue("Descripcion", materia.Descripcion);
            cm.Parameters.AddWithValue("Detalle", materia.Detalle);
            cm.Parameters.AddWithValue("Precio", materia.Precio);
            cm.Parameters.AddWithValue("Stock", materia.Stock);

            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
        }
        public void Actualizar(Materia materia)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Materias set Descripcion=@Descripcion, Detalle=@Detalle, Precio=@Precio, Stock=@Stock where IdMateria = {materia.IdMateria}";
            cm.Connection = con;


            cm.Parameters.AddWithValue("Descripcion", materia.Descripcion);
            cm.Parameters.AddWithValue("Detalle", materia.Detalle);
            cm.Parameters.AddWithValue("Precio", materia.Precio);
            cm.Parameters.AddWithValue("Stock", materia.Stock);

            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
        }
        public void Borrar(Materia materia)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Materias set Estado = false where IdMateria = {materia.IdMateria}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void Recuperar(Materia materia)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Materias set Estado = true where IdMateria = {materia.IdMateria}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public List<Materia> ListarPapelera()
        {
            List<Materia> list = new List<Materia>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Materias WHERE Estado = false";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Materia materia = new Materia();

                materia.IdMateria = reader.GetInt32(0);
                materia.Descripcion = reader.GetString(1);
                materia.Detalle = reader.GetString(2);
                materia.Precio = reader.GetDecimal(3);
                materia.Stock = reader.GetInt32(4);


                list.Add(materia);
            }
            con.Close();

            return list;
        }
        public List<Materia> Listar()
        {
            List<Materia> list = new List<Materia>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Materias WHERE Estado = true";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Materia materia = new Materia();

                materia.IdMateria = reader.GetInt32(0);
                materia.Descripcion = reader.GetString(1);
                materia.Detalle = reader.GetString(2);
                materia.Precio = reader.GetDecimal(3);
                materia.Stock = reader.GetInt32(4);


                list.Add(materia);
            }
            con.Close();

            return list;
        }
        public List<Materia> Buscar(string Descripcion)
        {
            List<Materia> list = new List<Materia>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"SELECT IdMateria, Descripcion, Detalle, Precio, Stock FROM Materias WHERE Descripcion LIKE ('%{Descripcion}%') AND Estado = true";
            cm.Connection = con;
            con.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {
                Materia materia = new Materia();

                materia.IdMateria = reader.GetInt32(0);
                materia.Descripcion = reader.GetString(1);
                materia.Detalle = reader.GetString(2);
                materia.Precio = reader.GetDecimal(3);
                materia.Stock = reader.GetInt32(4);


                list.Add(materia);
            }

            con.Close();
            return list;
        }
        public List<Materia> BuscarPapelera(string Descripcion)
        {
            List<Materia> list = new List<Materia>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"SELECT IdMateria, Descripcion, Detalle, Precio, Stock FROM Materias WHERE Descripcion LIKE ('%{Descripcion}%') AND Estado = false";
            cm.Connection = con;
            con.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {
                Materia materia = new Materia();

                materia.IdMateria = reader.GetInt32(0);
                materia.Descripcion = reader.GetString(1);
                materia.Detalle = reader.GetString(2);
                materia.Precio = reader.GetDecimal(3);
                materia.Stock = reader.GetInt32(4);


                list.Add(materia);
            }

            con.Close();
            return list;
        }
    }
}
