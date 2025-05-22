using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using CapaNegocios;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConeBarrios
    {
        public string ConectarDB()
        {
            OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            string cadenaconexion = ("Provider =Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            return cadenaconexion;
        }
        public void AgregarBarrio(Barrio Barrio)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "insert into Barrios(Descripcion, Estado) values (@Descripcion, true)";
            cm.Connection = cone;
            cm.Parameters.AddWithValue("Descripcion", Barrio.Descripcion);

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void ActualizarBarrio(Barrio Barrio)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Barrios set Descripcion=@Descripcion where IdBarrio = {Barrio.IdBarrio}";
            cm.Connection = cone;

            cm.Parameters.AddWithValue("Descripcion", Barrio.Descripcion);

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void RecuperarBarrio(Barrio Barrio)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Barrios set Estado = true where IdBarrio = {Barrio.IdBarrio}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void BorrarBarrio(Barrio Barrio)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Barrios set Estado = false where IdBarrio = {Barrio.IdBarrio}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public List<Barrio> ListarBarrioPapelera()
        {
            List<Barrio> list = new List<Barrio>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Barrios WHERE Estado = false";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Barrio Barrios = new Barrio();

                Barrios.IdBarrio = reader.GetInt32(0);
                Barrios.Descripcion = reader.GetString(1);


                list.Add(Barrios);
            }
            con.Close();

            return list;
        }
        public List<Barrio> ListarBarrio()
        {
            List<Barrio> list = new List<Barrio>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Barrios WHERE Estado = true";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Barrio Barrios = new Barrio();

                Barrios.IdBarrio = reader.GetInt32(0);
                Barrios.Descripcion = reader.GetString(1);


                list.Add(Barrios);
            }
            con.Close();

            return list;
        }
        public List<Barrio> BuscarBarrio(string Descripcion)
        {
            List<Barrio> list = new List<Barrio>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdBarrio, Descripcion from Barrios where Descripcion like ('%{Descripcion}%') order by IdBarrio, Descripcion";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {
                Barrio Barrio = new Barrio();

                Barrio.IdBarrio = reader.GetInt32(0);
                Barrio.Descripcion = reader.GetString(1);


                list.Add(Barrio);
            }

            cone.Close();
            return list;
        }
        public List<Barrio> BuscarIdBarrio(int IdBarrio)
        {
            List<Barrio> list = new List<Barrio>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdBarrio, Descripcion from Barrios where IdBarrio like ('%{IdBarrio}%')";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {
                Barrio Barrio = new Barrio();

                Barrio.IdBarrio = reader.GetInt32(0);
                Barrio.Descripcion = reader.GetString(1);


                list.Add(Barrio);
            }

            cone.Close();
            return list;
        }
        public List<Barrio> BuscarPapelera(string Descripcion)
        {
            List<Barrio> list = new List<Barrio>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdBarrio, Descripcion from Barrios where Descripcion like ('%{Descripcion}%') AND Estado = false";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {
                Barrio Barrio = new Barrio();

                Barrio.IdBarrio = reader.GetInt32(0);
                Barrio.Descripcion = reader.GetString(1);


                list.Add(Barrio);
            }

            cone.Close();
            return list;
        }
    }
}
