using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConeColores
    {
        public string ConectarDB()
        {
            OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            string cadenaconexion = ("Provider =Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            return cadenaconexion;
        }
        public void Agregar(Colores Color)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "insert into Color (Descripcion, Estado) values (@Descripcion, true)";
            cm.Connection = cone;
            cm.Parameters.AddWithValue("Descripcion", Color.Descripcion);

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void Actualizar(Colores Color)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Color set Descripcion=@Descripcion where IdColor = {Color.IdColor}";
            cm.Connection = cone;

            cm.Parameters.AddWithValue("Descripcion", Color.Descripcion);

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void Recuperar(Colores Color)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Color set Estado = true where IdColor = {Color.IdColor}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void Borrar(Colores Color)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Color set Estado = false where IdColor = {Color.IdColor}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public List<Colores> ListarColorPapelera()
        {
            List<Colores> list = new List<Colores>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Color WHERE Estado = false";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Colores color = new Colores();

                color.IdColor = reader.GetInt32(0);
                color.Descripcion = reader.GetString(1);


                list.Add(color);
            }
            con.Close();

            return list;
        }
        public List<Colores> ListarColor()
        {
            List<Colores> list = new List<Colores>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Color WHERE Estado = true";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Colores Color = new Colores();

                Color.IdColor = reader.GetInt32(0);
                Color.Descripcion = reader.GetString(1);


                list.Add(Color);
            }
            con.Close();

            return list;
        }
        public List<Colores> BuscarIdColor(int IdColor)
        {
            List<Colores> list = new List<Colores>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdColor, Descripcion from Color where IdColor like ('%{IdColor}%')";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {

                Colores color = new Colores();

                color.IdColor = reader.GetInt32(0);
                color.Descripcion = reader.GetString(1);


                list.Add(color);
            }

            cone.Close();
            return list;
        }
        public List<Colores> BuscarColor(string Descripcion)
        {
            List<Colores> list = new List<Colores>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdColor, Descripcion from Color where Descripcion like ('%{Descripcion}%')";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {

                Colores color = new Colores();

                color.IdColor = reader.GetInt32(0);
                color.Descripcion = reader.GetString(1);


                list.Add(color);
            }

            cone.Close();
            return list;
        }
        public List<Colores> BuscarPapelera(string Descripcion)
        {
            List<Colores> list = new List<Colores>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdColor, Descripcion from Color where Descripcion like ('%{Descripcion}%') AND Estado = false";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {

                Colores color = new Colores();

                color.IdColor = reader.GetInt32(0);
                color.Descripcion = reader.GetString(1);


                list.Add(color);
            }

            cone.Close();
            return list;
        }
    }
}
