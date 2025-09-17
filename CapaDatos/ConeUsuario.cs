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
        public string ConectarDB()
        {
            OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            string cadenaconexion = ("Provider =Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|DB.mdb;");
            return cadenaconexion;
        }

        static ConeUsuario conexion = new ConeUsuario();

        public bool VerificarUsuario(Usuario user)
        {

            // Lógica para verificar usuario

            bool xst = false;

            using (OleDbConnection con = new OleDbConnection(conexion.ConectarDB()))
            {
                try
                {
                    con.Open();

                    string consulta = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = ? AND Pass = ?";
                    using (OleDbCommand com = new OleDbCommand(consulta, con))
                    {
                        com.Parameters.AddWithValue("?", user.Nombre);
                        com.Parameters.AddWithValue("?", user.Pass);

                        int cont = (int)com.ExecuteScalar();
                        if (cont > 1)
                        {
                           throw new Exception("Error: Se encontraron múltiples usuarios con las mismas credenciales."); //Por las dudas no vaya ser...
                        }
                        else
                        if (cont > 0)
                        {
                            xst = true;
                        }

                    }




                }
                catch (Exception)
                {

                }
            }


            return xst;

        }
    }
}
