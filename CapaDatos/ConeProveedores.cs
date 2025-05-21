using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConeProveedores
    {
        #region conexion a BD
        public string ConectarDB()
        {
            OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|elfrancesrances.mdb;");
            string cadenaconexion = ("Provider =Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|elfrances.mdb;");
            return cadenaconexion;
        }
        #endregion
        public void AgregarProveedor(Proveedores Pro)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            con.ConnectionString = ConectarDB();
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

            con.ConnectionString = ConectarDB();
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

            cone.ConnectionString = ConectarDB();
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

            cone.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Proveedores set Estado = true where IdProveedor = {Pro.IdProveedor}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public List<Proveedores> ListarProveedorPapelera()
        {
            List<Proveedores> list = new List<Proveedores>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Proveedores WHERE Estado = false";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Proveedores Pro = new Proveedores();

                Pro.IdProveedor = reader.GetInt32(0);
                Pro.RazonSocial = reader.GetString(1);
                Pro.Documento = reader.GetString(2);
                Pro.Telefono = reader.GetString(3);
                Pro.Domicilio = reader.GetString(4);
                Pro.IdLocalidad = reader.GetInt32(5);


                list.Add(Pro);
            }
            con.Close();

            return list;
        }
        public List<Proveedores> ListarProveedor()
        {
            List<Proveedores> list = new List<Proveedores>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Proveedores WHERE Estado = true";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Proveedores Pro = new Proveedores();

                Pro.IdProveedor = reader.GetInt32(0);
                Pro.RazonSocial = reader.GetString(1);
                Pro.Documento = reader.GetString(2);
                Pro.Telefono = reader.GetString(3);
                Pro.Domicilio = reader.GetString(4);
                Pro.IdLocalidad = reader.GetInt32(5);


                list.Add(Pro);
            }
            con.Close();

            return list;
        }
        public List<Proveedores> Buscar(string RazonSocial)
        {
            List<Proveedores> list = new List<Proveedores>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdProveedor, RazonSocial, Documento, Telefono, Domicilio, IdLocalidad from Proveedores where RazonSocial like ('%{RazonSocial}%')";
            cm.Connection = con;
            con.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {
                Proveedores Pro = new Proveedores();


                Pro.IdProveedor = reader.GetInt32(0);
                Pro.RazonSocial = reader.GetString(1);
                Pro.Documento = reader.GetString(2);
                Pro.Telefono = reader.GetString(3);
                Pro.Domicilio = reader.GetString(4);
                Pro.IdLocalidad = reader.GetInt32(5);


                list.Add(Pro);
            }

            con.Close();
            return list;
        }
        public List<Proveedores> BuscarPapelera(string RazonSocial)
        {
            List<Proveedores> list = new List<Proveedores>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();
            OleDbDataReader reader;

            con.ConnectionString = ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;

            cm.CommandText = $"Select IdProveedor, RazonSocial, Documento, Telefono, Domicilio, IdLocalidad from Proveedores where RazonSocial like ('%{RazonSocial}%') AND Estado = false";
            cm.Connection = con;
            con.Open();

            reader = cm.ExecuteReader();

            while (reader.Read())
            {
                Proveedores Pro = new Proveedores();


                Pro.IdProveedor = reader.GetInt32(0);
                Pro.RazonSocial = reader.GetString(1);
                Pro.Documento = reader.GetString(2);
                Pro.Telefono = reader.GetString(3);
                Pro.Domicilio = reader.GetString(4);
                Pro.IdLocalidad = reader.GetInt32(5);


                list.Add(Pro);
            }

            con.Close();
            return list;
        }
    }
}
