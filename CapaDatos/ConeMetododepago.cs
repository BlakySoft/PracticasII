using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConeMetododepago
    {
        public string ConectarDB()
        {
            OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            string cadenaconexion = ("Provider =Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            return cadenaconexion;
        }
        public void Agregar(Metododepago Metodo)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "insert into Metodos(Descripcion, Estado) values (@Descripcion, true)";
            cm.Connection = cone;
            cm.Parameters.AddWithValue("Descripcion", Metodo.Descripcion);

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void Actualizar(Metododepago Metodo)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Metodos set Descripcion=@Descripcion where IdMetodo = {Metodo.IdMetodo}";
            cm.Connection = cone;

            cm.Parameters.AddWithValue("Descripcion", Metodo.Descripcion);

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void Recuperar(Metododepago Metodo)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Metodos set Estado = true where IdMetodo = {Metodo.IdMetodo}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void Borrar(Metododepago Metodo)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Metodos set Estado = false where IdMetodo = {Metodo.IdMetodo}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public List<Metododepago> ListarPapelera()
        {
            List<Metododepago> list = new List<Metododepago>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Metodos WHERE Estado = false";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Metododepago Metodo = new Metododepago();

                Metodo.IdMetodo = reader.GetInt32(0);
                Metodo.Descripcion = reader.GetString(1);


                list.Add(Metodo);
            }
            con.Close();

            return list;
        }
        public List<Metododepago> Listar()
        {
            List<Metododepago> list = new List<Metododepago>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Metodos WHERE Estado = true";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Metododepago Metodo = new Metododepago();

                Metodo.IdMetodo = reader.GetInt32(0);
                Metodo.Descripcion = reader.GetString(1);


                list.Add(Metodo);
            }
            con.Close();

            return list;
        }

        public List<Metododepago> BuscarPapelera(string Descripcion)
        {
            List<Metododepago> list = new List<Metododepago>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdMetodo, Descripcion from Metodos where Descripcion like ('%{Descripcion}%') AND Estado = false";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {
                Metododepago Metodo = new Metododepago();

                Metodo.IdMetodo = reader.GetInt32(0);
                Metodo.Descripcion = reader.GetString(1);


                list.Add(Metodo);
            }

            cone.Close();
            return list;
        }
        public List<Metododepago> Buscar(string Descripcion)
        {
            List<Metododepago> list = new List<Metododepago>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdMetodo, Descripcion from Metodos where Descripcion like ('%{Descripcion}%')";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {
                Metododepago Metodo = new Metododepago();

                Metodo.IdMetodo = reader.GetInt32(0);
                Metodo.Descripcion = reader.GetString(1);


                list.Add(Metodo);
            }

            cone.Close();
            return list;
        }
    }
}
