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
        #region conexion a BD
        Conexion cn = new Conexion();
        #endregion
        public void Agregar(Marca Marcas)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = cn.ConectarDB();
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

            cone.ConnectionString = cn.ConectarDB();
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

            cone.ConnectionString = cn.ConectarDB();
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

            cone.ConnectionString = cn.ConectarDB();
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

            con.ConnectionString = cn.ConectarDB();
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

            con.ConnectionString = cn.ConectarDB();
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
        public List<Marca> BuscarMarca(string letra)
        {
            List<Marca> list = new List<Marca>();
            using (OleDbConnection cone = new OleDbConnection(cn.ConectarDB()))
            using (OleDbCommand cm = cone.CreateCommand())
            {
                cm.CommandType = System.Data.CommandType.Text;

                // Buscar marcas por primera letra y activas
                cm.CommandText = $"SELECT IdMarca, Descripcion FROM Marcas WHERE Descripcion LIKE '{letra}%' AND Estado = true";
                cone.Open();

                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Marca mar = new Marca
                        {
                            IdMarca = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        };
                        list.Add(mar);
                    }
                }
            }
            return list;
        }
        public List<Marca> BuscarPapelera(string letra)
        {
            List<Marca> list = new List<Marca>();
            using (OleDbConnection cone = new OleDbConnection(cn.ConectarDB()))
            using (OleDbCommand cm = cone.CreateCommand())
            {
                cm.CommandType = System.Data.CommandType.Text;

                cm.CommandText = $"SELECT IdMarca, Descripcion FROM Marcas WHERE Descripcion LIKE '{letra}%' AND Estado = false";
                cone.Open();

                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Marca mar = new Marca
                        {
                            IdMarca = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        };
                        list.Add(mar);
                    }
                }
            }
            return list;
        }
    }
}
