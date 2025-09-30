using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConeProveedores
    {
        #region conexion a BD
        Conexion cn = new Conexion();
        #endregion
        public void AgregarProveedor(Proveedores Pro)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            con.ConnectionString = cn.ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = "insert into Proveedores (RazonSocial, Documento, Telefono, Domicilio, IdLocalidad, Estado) values (@RazonSocial, @Documento, @Telefono, @Domicilio, @IdLocalidad, true)";
            cm.Connection = con;

            cm.Parameters.AddWithValue("RazonSocial", Pro.RazonSocial);
            cm.Parameters.AddWithValue("Documento", Pro.Documento);
            cm.Parameters.AddWithValue("Telefono", Pro.Telefono);
            cm.Parameters.AddWithValue("Domicilio", Pro.Domicilio);
            cm.Parameters.AddWithValue("IdLocalidad", Pro.IdLocalidad);

            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
        }
        public void ActualizarProveedor(Proveedores Pro)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            con.ConnectionString = cn.ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Proveedores set RazonSocial=@RazonSocial, Documento=@Documento, Telefono=@Telefono, Domicilio=@Domicilio where IdProveedor = {Pro.IdProveedor}";
            cm.Connection = con;


            cm.Parameters.AddWithValue("Nombre", Pro.RazonSocial);
            cm.Parameters.AddWithValue("Documento", Pro.Documento);
            cm.Parameters.AddWithValue("Telefono", Pro.Telefono);
            cm.Parameters.AddWithValue("Domicilio", Pro.Domicilio);
            cm.Parameters.AddWithValue("IdBarrio", Pro.IdLocalidad);

            con.Open();
            cm.ExecuteNonQuery();
            con.Close();
        }
        public void BorrarProveedor(Proveedores Pro)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = cn.ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Proveedores set Estado = false where IdProveedor = {Pro.IdProveedor}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void RecuperarProveedor(Proveedores Pro)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = cn.ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Proveedores set Estado = true where IdProveedor = {Pro.IdProveedor}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public List<Proveedores> ListarProveedorPapelera()
        {
            List<Proveedores> lista = new List<Proveedores>();

            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            using (OleDbCommand cm = con.CreateCommand())
            {
                cm.CommandType = CommandType.Text;

                cm.CommandText = @"
            SELECT p.IdProveedor, p.RazonSocial, p.Documento, p.Telefono, p.Domicilio,
                   p.IdLocalidad, l.Descripcion AS Localidad
            FROM Proveedores p
            INNER JOIN Localidades l ON p.IdLocalidad = l.IdLocalidad
            WHERE p.Estado = false
            ORDER BY p.RazonSocial";

                con.Open();

                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Proveedores Pro = new Proveedores
                        {
                            IdProveedor = reader["IdProveedor"] != DBNull.Value ? Convert.ToInt32(reader["IdProveedor"]) : 0,
                            RazonSocial = reader["RazonSocial"] != DBNull.Value ? reader["RazonSocial"].ToString() : string.Empty,
                            Documento = reader["Documento"] != DBNull.Value ? reader["Documento"].ToString() : string.Empty,
                            Telefono = reader["Telefono"] != DBNull.Value ? reader["Telefono"].ToString() : string.Empty,
                            Domicilio = reader["Domicilio"] != DBNull.Value ? reader["Domicilio"].ToString() : string.Empty,
                            IdLocalidad = reader["IdLocalidad"] != DBNull.Value ? Convert.ToInt32(reader["IdLocalidad"]) : 0,
                            Localidad = reader["Localidad"] != DBNull.Value ? reader["Localidad"].ToString() : string.Empty
                        };

                        lista.Add(Pro);
                    }
                }
            }

            return lista;
        }
        public List<Proveedores> ListarProveedorINNERJOIN()
        {
            List<Proveedores> lista = new List<Proveedores>();

            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            using (OleDbCommand cm = con.CreateCommand())
            {
                cm.CommandType = CommandType.Text;

                cm.CommandText = @"
            SELECT p.IdProveedor, p.RazonSocial, p.Documento, p.Telefono, p.Domicilio,
                   p.IdLocalidad, l.Descripcion AS Localidad
            FROM Proveedores p
            INNER JOIN Localidades l ON p.IdLocalidad = l.IdLocalidad
            WHERE p.Estado = True
            ORDER BY p.RazonSocial";

                con.Open();

                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Proveedores Pro = new Proveedores
                        {
                            IdProveedor = reader["IdProveedor"] != DBNull.Value ? Convert.ToInt32(reader["IdProveedor"]) : 0,
                            RazonSocial = reader["RazonSocial"] != DBNull.Value ? reader["RazonSocial"].ToString() : string.Empty,
                            Documento = reader["Documento"] != DBNull.Value ? reader["Documento"].ToString() : string.Empty,
                            Telefono = reader["Telefono"] != DBNull.Value ? reader["Telefono"].ToString() : string.Empty,
                            Domicilio = reader["Domicilio"] != DBNull.Value ? reader["Domicilio"].ToString() : string.Empty,
                            IdLocalidad = reader["IdLocalidad"] != DBNull.Value ? Convert.ToInt32(reader["IdLocalidad"]) : 0,
                            Localidad = reader["Localidad"] != DBNull.Value ? reader["Localidad"].ToString() : string.Empty
                        };

                        lista.Add(Pro);
                    }
                }
            }

            return lista;
        }
        public List<Proveedores> Buscar(string letra)
        {
            List<Proveedores> lista = new List<Proveedores>();

            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            using (OleDbCommand cm = con.CreateCommand())
            {
                cm.CommandType = CommandType.Text;

                cm.CommandText = @"
            SELECT p.IdProveedor, p.RazonSocial, p.Documento, p.Telefono, p.Domicilio,
                   p.IdLocalidad, l.Descripcion AS Localidad
            FROM Proveedores p
            INNER JOIN Localidades l ON p.IdLocalidad = l.IdLocalidad
            WHERE p.Estado = True
              AND p.RazonSocial LIKE @razon
            ORDER BY p.RazonSocial";

                cm.Parameters.AddWithValue("@razon", letra + "%");

                con.Open();

                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Proveedores Pro = new Proveedores
                        {
                            IdProveedor = reader["IdProveedor"] != DBNull.Value ? Convert.ToInt32(reader["IdProveedor"]) : 0,
                            RazonSocial = reader["RazonSocial"] != DBNull.Value ? reader["RazonSocial"].ToString() : string.Empty,
                            Documento = reader["Documento"] != DBNull.Value ? reader["Documento"].ToString() : string.Empty,
                            Telefono = reader["Telefono"] != DBNull.Value ? reader["Telefono"].ToString() : string.Empty,
                            Domicilio = reader["Domicilio"] != DBNull.Value ? reader["Domicilio"].ToString() : string.Empty,
                            IdLocalidad = reader["IdLocalidad"] != DBNull.Value ? Convert.ToInt32(reader["IdLocalidad"]) : 0,
                            Localidad = reader["Localidad"] != DBNull.Value ? reader["Localidad"].ToString() : string.Empty
                        };

                        lista.Add(Pro);
                    }
                }
            }

            return lista;
        }
        public List<Proveedores> BuscarPapelera(string letra)
        {
            List<Proveedores> lista = new List<Proveedores>();

            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            using (OleDbCommand cm = con.CreateCommand())
            {
                cm.CommandType = CommandType.Text;

                // Parámetro @razon para buscar coincidencias que comiencen con la letra ingresada
                cm.CommandText = @"
            SELECT p.IdProveedor, p.RazonSocial, p.Documento, p.Telefono, p.Domicilio,
                   p.IdLocalidad, l.Descripcion AS Localidad
            FROM Proveedores p
            INNER JOIN Localidades l ON p.IdLocalidad = l.IdLocalidad
            WHERE p.Estado = false
              AND p.RazonSocial LIKE @razon
            ORDER BY p.RazonSocial";

                cm.Parameters.AddWithValue("@razon", letra + "%");

                con.Open();

                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Proveedores Pro = new Proveedores
                        {
                            IdProveedor = reader["IdProveedor"] != DBNull.Value ? Convert.ToInt32(reader["IdProveedor"]) : 0,
                            RazonSocial = reader["RazonSocial"] != DBNull.Value ? reader["RazonSocial"].ToString() : string.Empty,
                            Documento = reader["Documento"] != DBNull.Value ? reader["Documento"].ToString() : string.Empty,
                            Telefono = reader["Telefono"] != DBNull.Value ? reader["Telefono"].ToString() : string.Empty,
                            Domicilio = reader["Domicilio"] != DBNull.Value ? reader["Domicilio"].ToString() : string.Empty,
                            IdLocalidad = reader["IdLocalidad"] != DBNull.Value ? Convert.ToInt32(reader["IdLocalidad"]) : 0,
                            Localidad = reader["Localidad"] != DBNull.Value ? reader["Localidad"].ToString() : string.Empty
                        };

                        lista.Add(Pro);
                    }
                }
            }

            return lista;
        }
    }
}
