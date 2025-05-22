using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocios;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class ConeClientes
    {
        #region conexion a BD
        public string ConectarDB()
        {
            OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            string cadenaconexion = ("Provider =Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            return cadenaconexion;
        }
        #endregion
        public void AgregarCliente(Cliente Cli)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = "insert into Clientes(Nombre, Documento, Telefono, Domicilio, IdBarrio, Estado) values (@Nombre, @Documento, @Telefono, @Domicilio, @IdBarrio, true)";
            cm.Connection = con;

            cm.Parameters.AddWithValue("Nombre", Cli.Nombre);
            cm.Parameters.AddWithValue("Documento", Cli.Documento);
            cm.Parameters.AddWithValue("Telefono", Cli.Telefono);
            cm.Parameters.AddWithValue("Domicilio", Cli.Domicilio);
            //cm.Parameters.AddWithValue("IdBarrio", Cli.IdBarrio); No se encuentra en uso

            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
        }
        public void ActualizarCliente(Cliente Cli)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Clientes set Nombre=@Nombre, Documento=@Documento, Telefono=@Telefono, Domicilio=@Domicilio, IdBarrio=@IdBarrio where IdCliente = {Cli.IdCliente}";
            cm.Connection = con;


            cm.Parameters.AddWithValue("Nombre", Cli.Nombre);
            cm.Parameters.AddWithValue("Documento", Cli.Documento);
            cm.Parameters.AddWithValue("Telefono", Cli.Telefono);
            cm.Parameters.AddWithValue("Domicilio", Cli.Domicilio);
            //cm.Parameters.AddWithValue("IdBarrio", Cli.IdBarrio); No se encuentra en uso

            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
        }
        public void BorrarCliente(Cliente Cli)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Clientes set Estado = false where IdCliente = {Cli.IdCliente}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void RecuperarCliente(Cliente Cli)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Clientes set Estado = true where IdCliente = {Cli.IdCliente}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public List<Cliente> ListarClientePapelera()
        {
            List<Cliente> list = new List<Cliente>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Clientes WHERE Estado = false";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Cliente Cli = new Cliente();

                Cli.IdCliente = reader.GetInt32(0);
                Cli.Nombre = reader.GetString(1);
                Cli.Documento = reader.GetString(2);
                Cli.Telefono = reader.GetString(3);
                Cli.Domicilio = reader.GetString(4);
                //Cli.IdBarrio = reader.GetInt32(5); No se encuentra en uso


                list.Add(Cli);
            }
            con.Close();

            return list;
        }
        public List<Cliente> ListarCliente()
        {
            List<Cliente> list = new List<Cliente>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Clientes WHERE Estado = true";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Cliente Cli = new Cliente();

                Cli.IdCliente = reader.GetInt32(0);
                Cli.Nombre = reader.GetString(1);
                Cli.Documento = reader.GetString(2);
                Cli.Telefono = reader.GetString(3);
                Cli.Domicilio = reader.GetString(4);
                //Cli.IdBarrio = reader.GetInt32(5); No se encuentra en uso


                list.Add(Cli);
            }
            con.Close();

            return list;
        }
        public List<Cliente> BuscarCliente(string Nombre)
        {
            List<Cliente> list = new List<Cliente>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdCliente, Nombre, Documento, Telefono, Domicilio, IdBarrio from Clientes where Nombre like ('%{Nombre}%') order by IdCliente, Nombre, Documento, Telefono, Domicilio";
            cm.Connection = con;
            con.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {
                Cliente Cli = new Cliente();


                Cli.IdCliente = reader.GetInt32(0);
                Cli.Nombre = reader.GetString(1);
                Cli.Documento = reader.GetString(2);
                Cli.Telefono = reader.GetString(3);
                Cli.Domicilio = reader.GetString(4);
                //Cli.IdBarrio = reader.GetInt32(5); No se encuentra en uso


                list.Add(Cli);
            }

            con.Close();
            return list;
        }
        public List<Cliente> BuscarPapelera(string Nombre)
        {
            List<Cliente> list = new List<Cliente>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdCliente, Nombre, Documento, Telefono, Domicilio, IdBarrio from Clientes where Nombre like ('%{Nombre}%') AND Estado = false";
            cm.Connection = con;
            con.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {
                Cliente Cli = new Cliente();


                Cli.IdCliente = reader.GetInt32(0);
                Cli.Nombre = reader.GetString(1);
                Cli.Documento = reader.GetString(2);
                Cli.Telefono = reader.GetString(3);
                Cli.Domicilio = reader.GetString(4);
                //Cli.IdBarrio = reader.GetInt32(5); No se encuentra en uso


                list.Add(Cli);
            }

            con.Close();
            return list;
        }

    }
}
