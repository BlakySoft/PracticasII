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
        #region Conexion a BD
        Conexion cn = new Conexion();
        #endregion
        
        public void Agregar(Colores Color)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = cn.ConectarDB();
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

            cone.ConnectionString = cn.ConectarDB();
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

            cone.ConnectionString = cn.ConectarDB();
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

            cone.ConnectionString = cn.ConectarDB();
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

            con.ConnectionString = cn.ConectarDB();
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

            con.ConnectionString = cn.ConectarDB();
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
        public List<Colores> BuscarColor(string letra)
        {
            List<Colores> list = new List<Colores>();
            using (OleDbConnection cone = new OleDbConnection(cn.ConectarDB()))
            using (OleDbCommand cm = cone.CreateCommand())
            {
                cm.CommandType = System.Data.CommandType.Text;

                // Buscar colores por primera letra
                cm.CommandText = $"SELECT IdColor, Descripcion FROM Color WHERE Descripcion LIKE '{letra}%' AND Estado = true";
                cone.Open();

                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Colores color = new Colores
                        {
                            IdColor = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        };
                        list.Add(color);
                    }
                }
            }
            return list;
        }
        public List<Colores> BuscarPapelera(string letra)
        {
            List<Colores> list = new List<Colores>();
            using (OleDbConnection cone = new OleDbConnection(cn.ConectarDB()))
            using (OleDbCommand cm = cone.CreateCommand())
            {
                cm.CommandType = System.Data.CommandType.Text;

                // Buscar colores por primera letra
                cm.CommandText = $"SELECT IdColor, Descripcion FROM Color WHERE Descripcion LIKE '{letra}%' AND Estado = false";
                cone.Open();

                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Colores color = new Colores
                        {
                            IdColor = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        };
                        list.Add(color);
                    }
                }
            }
            return list;
        }
    }
}
