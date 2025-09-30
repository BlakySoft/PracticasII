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
        #region Conexion a BD
        Conexion cn = new Conexion();
        #endregion
        public void AgregarCat(Categoria Categoria)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = cn.ConectarDB();
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

            cone.ConnectionString = cn.ConectarDB();
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

            cone.ConnectionString = cn.ConectarDB();
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

            cone.ConnectionString = cn.ConectarDB();
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

            con.ConnectionString = cn.ConectarDB();
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

            con.ConnectionString = cn.ConectarDB();
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
        public List<Categoria> BuscarCat(string letra)
        {
            List<Categoria> list = new List<Categoria>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = cn.ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            // Buscar por primera letra
            cm.CommandText = $"SELECT IdCat, Descripcion FROM Categoria WHERE Descripcion LIKE '{letra}%' AND Estado = true";
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
        public List<Categoria> BuscarPapelera(string letra)
        {
            List<Categoria> list = new List<Categoria>();
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            cone.ConnectionString = cn.ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            // Buscar por primera letra
            cm.CommandText = $"SELECT IdCat, Descripcion FROM Categoria WHERE Descripcion LIKE '{letra}%' AND Estado = false";
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
