using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class ConeCategoria
    {
        public string ConectarDB()
        {
            OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            string cadenaconexion = ("Provider =Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            return cadenaconexion;
        }
        public void AgregarCat(Categoria Categoria)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "insert into Categoria (Descripcion, Estado) values (@Descripcion, true)";
            cm.Connection = cone;
            cm.Parameters.AddWithValue("Descripcion", Categoria.Descripcion);

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void ActualizarCat(Categoria Categoria)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Categoria set Descripcion=@Descripcion where IdCat = {Categoria.IdCat}";
            cm.Connection = cone;

            cm.Parameters.AddWithValue("Descripcion", Categoria.Descripcion);

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void RecuperarCat(Categoria Categoria)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Categoria set Estado = true where IdCat = {Categoria.IdCat}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void BorrarCat(Categoria Categoria)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Categoria set Estado = false where IdCat = {Categoria.IdCat}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public List<Categoria> ListarCatPapelera()
        {
            List<Categoria> list = new List<Categoria>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Categoria WHERE Estado = false";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Categoria Categoria = new Categoria();

                Categoria.IdCat = reader.GetInt32(0);
                Categoria.Descripcion = reader.GetString(1);


                list.Add(Categoria);
            }
            con.Close();

            return list;
        }
        public List<Categoria> ListarCat()
        {
            List<Categoria> list = new List<Categoria>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Categoria WHERE Estado = true";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Categoria cat = new Categoria();

                cat.IdCat = reader.GetInt32(0);
                cat.Descripcion = reader.GetString(1);


                list.Add(cat);
            }
            con.Close();

            return list;
        }
        public List<Categoria> BuscarIdCat(int IdCat)
        {
            List<Categoria> list = new List<Categoria>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdCat, Descripcion from Categoria where IdCat like ('%{IdCat}%')";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {

                Categoria cat = new Categoria();

                cat.IdCat = reader.GetInt32(0);
                cat.Descripcion = reader.GetString(1);


                list.Add(cat);
            }

            cone.Close();
            return list;
        }
        public List<Categoria> BuscarCat(string Descripcion)
        {
            List<Categoria> list = new List<Categoria>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdCat, Descripcion from Categoria where Descripcion like ('%{Descripcion}%')";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {

                Categoria cat = new Categoria();

                cat.IdCat = reader.GetInt32(0);
                cat.Descripcion = reader.GetString(1);


                list.Add(cat);
            }

            cone.Close();
            return list;
        }
        public List<Categoria> BuscarPapelera(string Descripcion)
        {
            List<Categoria> list = new List<Categoria>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdCat, Descripcion from Categoria where Descripcion like ('%{Descripcion}%') AND Estado = false";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {

                Categoria cat = new Categoria();

                cat.IdCat = reader.GetInt32(0);
                cat.Descripcion = reader.GetString(1);


                list.Add(cat);
            }

            cone.Close();
            return list;
        }
     
    }
}
