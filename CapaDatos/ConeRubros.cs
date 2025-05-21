using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class ConeRubros
    {
        public string ConectarDB()
        {
            OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|elfrances.mdb;");
            string cadenaconexion = ("Provider =Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|elfrances.mdb;");
            return cadenaconexion;
        }
        public void AgregarRubro(Rubro Rubro)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "insert into Rubros (Descripcion, Estado) values (@Descripcion, true)";
            cm.Connection = cone;
            cm.Parameters.AddWithValue("Descripcion", Rubro.Descripcion);

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void ActualizarRubro(Rubro Rubro)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Rubros set Descripcion=@Descripcion where IdRubro = {Rubro.IdRubro}";
            cm.Connection = cone;

            cm.Parameters.AddWithValue("Descripcion", Rubro.Descripcion);

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void RecuperarRubro(Rubro Rubro)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Rubros set Estado = true where IdRubro = {Rubro.IdRubro}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void BorrarRubro(Rubro Rubro)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Rubros set Estado = false where IdRubro = {Rubro.IdRubro}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public List<Rubro> ListarRubroPapelera()
        {
            List<Rubro> list = new List<Rubro>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Rubros WHERE Estado = false";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Rubro Rubros = new Rubro();

                Rubros.IdRubro = reader.GetInt32(0);
                Rubros.Descripcion = reader.GetString(1);


                list.Add(Rubros);
            }
            con.Close();

            return list;
        }
        public List<Rubro> ListarRubro()
        {
            List<Rubro> list = new List<Rubro>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Rubros WHERE Estado = true";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Rubro rubros = new Rubro();

                rubros.IdRubro = reader.GetInt32(0);
                rubros.Descripcion = reader.GetString(1);


                list.Add(rubros);
            }
            con.Close();

            return list;
        }
        public List<Rubro> BuscarIdRubro(int IdRubro)
        {
            List<Rubro> list = new List<Rubro>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdRubro, Descripcion from Rubros where IdRubro like ('%{IdRubro}%')";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {

                Rubro rubros = new Rubro();

                rubros.IdRubro = reader.GetInt32(0);
                rubros.Descripcion = reader.GetString(1);


                list.Add(rubros);
            }

            cone.Close();
            return list;
        }
        public List<Rubro> BuscarRubro(string Descripcion)
        {
            List<Rubro> list = new List<Rubro>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdRubro, Descripcion from Rubros where Descripcion like ('%{Descripcion}%')";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {

                Rubro rubros = new Rubro();

                rubros.IdRubro = reader.GetInt32(0);
                rubros.Descripcion = reader.GetString(1);


                list.Add(rubros);
            }

            cone.Close();
            return list;
        }
        public List<Rubro> BuscarPapelera(string Descripcion)
        {
            List<Rubro> list = new List<Rubro>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdRubro, Descripcion from Rubros where Descripcion like ('%{Descripcion}%') AND Estado = false";
            cm.Connection = cone;
            cone.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {

                Rubro rubros = new Rubro();

                rubros.IdRubro = reader.GetInt32(0);
                rubros.Descripcion = reader.GetString(1);


                list.Add(rubros);
            }

            cone.Close();
            return list;
        }
    }
}
