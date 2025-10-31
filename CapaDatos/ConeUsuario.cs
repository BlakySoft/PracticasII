using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConeUsuario
    {
        #region conectar a BD
        Conexion cn = new Conexion();
        #endregion

        static ConeUsuario conexion = new ConeUsuario();
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

    }
}
