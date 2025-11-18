using LoginTry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (FormLogin login = new FormLogin())
            {
                //if (login.ShowDialog() == DialogResult.OK)
                //{
                    CapaNegocio.Usuario usuarioLogueado = login.UsuarioAutenticado;
                usuarioLogueado = new CapaNegocio.Usuario
                {
                    Id = 1,
                    Usuarios = "Cristian",
                    Pass = "1234",
                    TipoUsuario = 1
                };
                    Application.Run(new FormMENU(usuarioLogueado));
                //}
            }
        }
    }
}
