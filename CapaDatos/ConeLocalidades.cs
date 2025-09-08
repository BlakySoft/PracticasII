using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConeLocalidades
    {

        public string ConectarDB()
        {
            OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            string cadenaconexion = ("Provider =Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            return cadenaconexion;
        }
        public void AgregarLocalidad(Localidad Localidad)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "insert into Localidades(Descripcion, Estado) values (@Descripcion, true)";
            cm.Connection = cone;
            cm.Parameters.AddWithValue("Descripcion", Localidad.Descripcion);

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void ActualizarLocalidad(Localidad localidad)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Localidades set Descripcion=@Descripcion where IdLocalidad = {localidad.IdLocalidad}";
            cm.Connection = cone;

            cm.Parameters.AddWithValue("Descripcion", localidad.Descripcion);

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void RecuperarLocalidad(Localidad Localidad)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Localidades set Estado = true where IdLocalidad = {Localidad.IdLocalidad}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void BorrarLocalidades(Localidad Localidad)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Localidades set Estado = false where IdLocalidad = {Localidad.IdLocalidad}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public List<Localidad> ListarLocalidadPapelera()
        {
            List<Localidad> list = new List<Localidad>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Localidades WHERE Estado = false";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Localidad Localidades = new Localidad();

                Localidades.IdLocalidad = reader.GetInt32(0);
                Localidades.Descripcion = reader.GetString(1);


                list.Add(Localidades);
            }
            con.Close();

            return list;
        }
        public List<Localidad> ListarLocalidad()
        {
            List<Localidad> list = new List<Localidad>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Localidades WHERE Estado = true";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Localidad Localidades = new Localidad();

                Localidades.IdLocalidad = reader.GetInt32(0);
                Localidades.Descripcion = reader.GetString(1);


                list.Add(Localidades);
            }
            con.Close();

            return list;
        }
        public List<Localidad> BuscarPapelera(string letra)
        {
            List<Localidad> list = new List<Localidad>();
            using (OleDbConnection cone = new OleDbConnection(ConectarDB()))
            using (OleDbCommand cm = cone.CreateCommand())
            {
                cm.CommandType = System.Data.CommandType.Text;

                // Buscar localidades por primera letra
                cm.CommandText = $"SELECT IdLocalidad, Descripcion FROM Localidades WHERE Descripcion LIKE '{letra}%' AND Estado = false";
                cone.Open();

                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Localidad loc = new Localidad
                        {
                            IdLocalidad = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        };
                        list.Add(loc);
                    }
                }
            }
            return list;
        }
        public List<Localidad> BuscarLocalidad(string letra)
        {
            List<Localidad> list = new List<Localidad>();
            using (OleDbConnection cone = new OleDbConnection(ConectarDB()))
            using (OleDbCommand cm = cone.CreateCommand())
            {
                cm.CommandType = System.Data.CommandType.Text;

                // Buscar localidades por primera letra
                cm.CommandText = $"SELECT IdLocalidad, Descripcion FROM Localidades WHERE Descripcion LIKE '{letra}%'AND Estado = true";
                cone.Open();

                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Localidad loc = new Localidad
                        {
                            IdLocalidad = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        };
                        list.Add(loc);
                    }
                }
            }
            return list;
        }
        public List<Localidad> BuscarIdLocalidad(int IdLocalidad)
        {
            List<Localidad> list = new List<Localidad>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdLocalidad, Descripcion from Localidades where IdLocalidad like ('%{IdLocalidad}%');";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {
                Localidad Localidades = new Localidad();

                Localidades.IdLocalidad = reader.GetInt32(0);
                Localidades.Descripcion = reader.GetString(1);


                list.Add(Localidades);
            }

            cone.Close();
            return list;
        }
    }
}
