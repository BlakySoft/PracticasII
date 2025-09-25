using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace CapaDatos
{
    public class ConeDetalleVentas
    {
        CapaDatos.ConeClientes cone = new CapaDatos.ConeClientes();
        public DataTable ListarVentaDtll() 
        {
            DataTable DtllVenta = new DataTable();
            OleDbConnection con = new OleDbConnection(cone.ConectarDB());
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM DetalleVentas", con);
            con.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            
            DtllVenta.Load(reader);



            return DtllVenta;
        }
    }
}
