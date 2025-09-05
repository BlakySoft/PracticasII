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

        // ----------------- Agregar Cliente -----------------
        public void AgregarCliente(Cliente Cli)
        {
            using (OleDbConnection con = new OleDbConnection(ConectarDB()))
            using (OleDbCommand cm = new OleDbCommand())
            {
                cm.Connection = con;
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "INSERT INTO Clientes(Apellido, Nombre, Documento, Telefono, Domicilio, Estado) " +
                                 "VALUES (@Apellido, @Nombre, @Documento, @Telefono, @Domicilio, true)";

                cm.Parameters.AddWithValue("@Apellido", Cli.Apellido);
                cm.Parameters.AddWithValue("@Nombre", Cli.Nombre);
                cm.Parameters.AddWithValue("@Documento", Cli.Documento);
                cm.Parameters.AddWithValue("@Telefono", Cli.Telefono);
                cm.Parameters.AddWithValue("@Domicilio", Cli.Domicilio);

                con.Open();
                cm.ExecuteNonQuery();
            }
        }

        // ----------------- Actualizar Cliente -----------------
        public void ActualizarCliente(Cliente Cli)
        {
            using (OleDbConnection con = new OleDbConnection(ConectarDB()))
            using (OleDbCommand cm = new OleDbCommand())
            {
                cm.Connection = con;
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "UPDATE Clientes SET Apellido=@Apellido, Nombre=@Nombre, Documento=@Documento, " +
                                 "Telefono=@Telefono, Domicilio=@Domicilio WHERE IdCliente=@IdCliente";

                cm.Parameters.AddWithValue("@Apellido", Cli.Apellido);
                cm.Parameters.AddWithValue("@Nombre", Cli.Nombre);
                cm.Parameters.AddWithValue("@Documento", Cli.Documento);
                cm.Parameters.AddWithValue("@Telefono", Cli.Telefono);
                cm.Parameters.AddWithValue("@Domicilio", Cli.Domicilio);
                cm.Parameters.AddWithValue("@IdCliente", Cli.IdCliente);

                con.Open();
                cm.ExecuteNonQuery();
            }
        }

        // ----------------- Borrar Cliente -----------------
        public void BorrarCliente(Cliente Cli)
        {
            using (OleDbConnection con = new OleDbConnection(ConectarDB()))
            using (OleDbCommand cm = new OleDbCommand())
            {
                cm.Connection = con;
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "UPDATE Clientes SET Estado=false WHERE IdCliente=@IdCliente";
                cm.Parameters.AddWithValue("@IdCliente", Cli.IdCliente);

                con.Open();
                cm.ExecuteNonQuery();
            }
        }

        // ----------------- Recuperar Cliente -----------------
        public void RecuperarCliente(Cliente Cli)
        {
            using (OleDbConnection con = new OleDbConnection(ConectarDB()))
            using (OleDbCommand cm = new OleDbCommand())
            {
                cm.Connection = con;
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "UPDATE Clientes SET Estado=true WHERE IdCliente=@IdCliente";
                cm.Parameters.AddWithValue("@IdCliente", Cli.IdCliente);

                con.Open();
                cm.ExecuteNonQuery();
            }
        }

        // ----------------- Listar Clientes -----------------
        public List<Cliente> ListarCliente()
        {
            List<Cliente> list = new List<Cliente>();
            using (OleDbConnection con = new OleDbConnection(ConectarDB()))
            using (OleDbCommand cm = new OleDbCommand("SELECT * FROM Clientes WHERE Estado=true", con))
            {
                con.Open();
                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente Cli = new Cliente
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            Apellido = reader["Apellido"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Documento = reader["Documento"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Domicilio = reader["Domicilio"].ToString(),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        };
                        list.Add(Cli);
                    }
                }
            }
            return list;
        }

        // ----------------- Listar Clientes Papelera -----------------
        public List<Cliente> ListarClientePapelera()
        {
            List<Cliente> list = new List<Cliente>();
            using (OleDbConnection con = new OleDbConnection(ConectarDB()))
            using (OleDbCommand cm = new OleDbCommand("SELECT * FROM Clientes WHERE Estado=false", con))
            {
                con.Open();
                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente Cli = new Cliente
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            Apellido = reader["Apellido"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Documento = reader["Documento"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Domicilio = reader["Domicilio"].ToString(),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        };
                        list.Add(Cli);
                    }
                }
            }
            return list;
        }

        // ----------------- Buscar Cliente -----------------
        public List<Cliente> BuscarCliente(string letra)
        {
            List<Cliente> list = new List<Cliente>();
            using (OleDbConnection con = new OleDbConnection(ConectarDB()))
            using (OleDbCommand cm = new OleDbCommand(
                "SELECT IdCliente, Apellido, Nombre, Documento, Telefono, Domicilio, Estado " +
                "FROM Clientes " +
                "WHERE Apellido LIKE @letra + '%' AND Estado = true " +
                "ORDER BY Apellido, Nombre", con))
            {
                cm.Parameters.AddWithValue("@letra", letra);

                con.Open();
                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente Cli = new Cliente
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            Apellido = reader["Apellido"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Documento = reader["Documento"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Domicilio = reader["Domicilio"].ToString(),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        };
                        list.Add(Cli);
                    }
                }
            }
            return list;
        }

        // ----------------- Buscar Cliente Papelera -----------------
        public List<Cliente> BuscarPapelera(string letra)
        {
            List<Cliente> list = new List<Cliente>();
            using (OleDbConnection con = new OleDbConnection(ConectarDB()))
            using (OleDbCommand cm = new OleDbCommand(
                "SELECT IdCliente, Apellido, Nombre, Documento, Telefono, Domicilio, Estado " +
                "FROM Clientes " +
                "WHERE Apellido LIKE @letra + '%' AND Estado = False " +
                "ORDER BY Apellido, Nombre", con))
            {
                cm.Parameters.AddWithValue("@letra", letra);

                con.Open();
                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente Cli = new Cliente
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            Apellido = reader["Apellido"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Documento = reader["Documento"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Domicilio = reader["Domicilio"].ToString(),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        };
                        list.Add(Cli);
                    }
                }
            }
            return list;

        }
    }
}
