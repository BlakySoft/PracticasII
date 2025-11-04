using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
    public class ConeUsuario
    {
        #region conectar a BD
        Conexion cn = new Conexion();
        #endregion

        static ConeUsuario conexion = new ConeUsuario();
        public bool ExisteUsuario(string nombreUsuario)
        {
            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuarios = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", nombreUsuario);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public bool AgregarUsuario(Usuario nuevo)
        {
            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            {
                con.Open();

                string query = "INSERT INTO Usuarios (Usuarios, Pass, Tipousuario) VALUES (?, ?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", nuevo.Usuarios);
                    cmd.Parameters.AddWithValue("?", nuevo.Pass);
                    cmd.Parameters.AddWithValue("?", nuevo.TipoUsuario);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public Usuario VerificarUsuario(Usuario user)
        {
            Usuario usuarioEncontrado = null;

            using (OleDbConnection con = new OleDbConnection(conexion.cn.ConectarDB()))
            {
                try
                {
                    con.Open();

                    string consulta = "SELECT * FROM Usuarios WHERE Usuarios = ? AND Pass = ?";
                    using (OleDbCommand com = new OleDbCommand(consulta, con))
                    {
                        com.Parameters.AddWithValue("?", user.Usuarios.Trim());
                        com.Parameters.AddWithValue("?", user.Pass.Trim());

                        using (OleDbDataReader reader = com.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuarioEncontrado = new Usuario
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Usuarios = reader["Usuarios"].ToString().Trim(),
                                    Pass = reader["Pass"].ToString().Trim(),
                                    TipoUsuario = Convert.ToInt32(reader["Tipousuario"])
                                };
                            }
                        }
                    }
                }
                catch (Exception)
                {
                   
                }
            }

            return usuarioEncontrado;
        }
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            {
                try
                {
                    con.Open();
                    string query = "SELECT Id, Usuarios, Pass, Tipousuario FROM Usuarios";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Usuario u = new Usuario
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Usuarios = reader["Usuarios"].ToString(),
                                    Pass = reader["Pass"].ToString(),
                                    TipoUsuario = Convert.ToInt32(reader["Tipousuario"])
                                };
                                lista.Add(u);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                  
                }
            }

            return lista;
        }

        public bool EliminarUsuario(int idUsuario)
        {
            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            {
                try
                {
                    con.Open();
                    string query = "DELETE FROM Usuarios WHERE Id = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("?", idUsuario);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


    }
}
