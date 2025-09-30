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
        #region conexion a BD
        Conexion cn = new Conexion();
        #endregion
        public void Agregar(Metododepago Metodo)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = cn.ConectarDB();
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

            cone.ConnectionString = cn.ConectarDB();
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

            cone.ConnectionString = cn.ConectarDB();
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

            cone.ConnectionString = cn.ConectarDB();
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

            con.ConnectionString = cn.ConectarDB();
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

            con.ConnectionString = cn.ConectarDB();
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
        public List<Metododepago> BuscarPapelera(string letra)
        {
            List<Metododepago> list = new List<Metododepago>();
            using (OleDbConnection cone = new OleDbConnection(cn.ConectarDB()))
            using (OleDbCommand cm = cone.CreateCommand())
            {
                cm.CommandType = System.Data.CommandType.Text;

                // Buscar métodos activos que comiencen con la letra indicada
                cm.CommandText = $"SELECT IdMetodo, Descripcion FROM Metodos WHERE Descripcion LIKE '{letra}%' AND Estado = false";
                cone.Open();

                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Metododepago metodo = new Metododepago
                        {
                            IdMetodo = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        };
                        list.Add(metodo);
                    }
                }
            }
            return list;
        }
        public List<Metododepago> Buscar(string letra)
        {
            List<Metododepago> list = new List<Metododepago>();
            using (OleDbConnection cone = new OleDbConnection(cn.ConectarDB()))
            using (OleDbCommand cm = cone.CreateCommand())
            {
                cm.CommandType = System.Data.CommandType.Text;

                // Buscar métodos activos que comiencen con la letra indicada
                cm.CommandText = $"SELECT IdMetodo, Descripcion FROM Metodos WHERE Descripcion LIKE '{letra}%' AND Estado = true";
                cone.Open();

                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Metododepago metodo = new Metododepago
                        {
                            IdMetodo = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        };
                        list.Add(metodo);
                    }
                }
            }
            return list;
        }
    }
}
