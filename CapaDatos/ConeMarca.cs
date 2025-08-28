using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocios;
using System.Data.OleDb;
using CapaNegocio;


namespace CapaDatos
{
    public class ConeMarca
    {
        public string ConectarDB()
        {
            OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            string cadenaconexion = ("Provider =Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            return cadenaconexion;
        }

        public void Agregar(Marca Marcas)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "insert into Marcas (Descripcion, Estado) values (@Descripcion, true)";
            cm.Connection = cone;
            cm.Parameters.AddWithValue("Descripcion", Marcas.Descripcion);

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void Actualizar(Marca Marca)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Marcas set Descripcion=@Descripcion where IdMarca = {Marca.IdMarca}";
            cm.Connection = cone;

            cm.Parameters.AddWithValue("Descripcion", Marca.Descripcion);

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void Recuperar(Marca Marca)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Marcas set Estado = true where IdMarca = {Marca.IdMarca}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void Borrar(Marca Marca)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Marcas set Estado = false where IdMarca = {Marca.IdMarca}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public List<Marca> ListarMarcaPapelera()
        {
            List<Marca> list = new List<Marca>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Marcas WHERE Estado = false";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Marca marca = new Marca();

                marca.IdMarca = reader.GetInt32(0);
                marca.Descripcion = reader.GetString(1);


                list.Add(marca);
            }
            con.Close();

            return list;
        }
        public List<Marca> ListarMarca()
        {
            List<Marca> list = new List<Marca>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Marcas WHERE Estado = true";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Marca marca = new Marca();

                marca.IdMarca = reader.GetInt32(0);
                marca.Descripcion = reader.GetString(1);


                list.Add(marca);
            }
            con.Close();

            return list;
        }
        public List<Marca> BuscarIdMarca(int IdMarca)
        {
            List<Marca> list = new List<Marca>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdMarca, Descripcion from Marcas where IdMarca like ('%{IdMarca}%')";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {

                Marca marca = new Marca();

                marca.IdMarca = reader.GetInt32(0);
                marca.Descripcion = reader.GetString(1);


                list.Add(marca);
            }

            cone.Close();
            return list;
        }
        public List<Marca> BuscarMarca(string Descripcion)
        {
            List<Marca> list = new List<Marca>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdMarca, Descripcion from Marcas where Descripcion like ('%{Descripcion}%')";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {

                Marca marca = new Marca();

                marca.IdMarca = reader.GetInt32(0);
                marca.Descripcion = reader.GetString(1);
             

                list.Add(marca);
            }

            cone.Close();
            return list;
        }
        public List<Marca> BuscarPapelera(string Descripcion)
        {
            List<Marca> list = new List<Marca>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdMarca, Descripcion from Marcas where Descripcion like ('%{Descripcion}%') AND Estado = false";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {

                Marca marca = new Marca();

                marca.IdMarca = reader.GetInt32(0);
                marca.Descripcion = reader.GetString(1);


                list.Add(marca);
            }

            cone.Close();
            return list;
        }
    }
}
