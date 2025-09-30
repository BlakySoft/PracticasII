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
    public class ConeProductos
    {
        #region conexion a BD
        Conexion cn = new Conexion();
        #endregion
        public void Agregar(Productos Prod)
        {
            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            {
                using (OleDbCommand cm = new OleDbCommand())
                {
                    cm.Connection = con;
                    cm.CommandType = System.Data.CommandType.Text;
                    cm.CommandText = @"INSERT INTO Productos
                               (Descripcion, Detalle, IdCat, IdMarca, IdColor, PrecioCompra, PrecioVenta, Stock, Estado)
                               VALUES (@Descripcion, @Detalle, @IdCat, @IdMarca, @IdColor, @PrecioCompra, @PrecioVenta, @Stock, true)";

                    cm.Parameters.AddWithValue("Descripcion", Prod.Descripcion);
                    cm.Parameters.AddWithValue("Detalle", Prod.Detalle);
                    cm.Parameters.AddWithValue("IdCat", Prod.IdCat);
                    cm.Parameters.AddWithValue("IdMarca", Prod.IdMarca);
                    cm.Parameters.AddWithValue("IdColor", Prod.IdColor);
                    cm.Parameters.AddWithValue("PrecioCompra", Prod.PrecioCompra);
                    cm.Parameters.AddWithValue("PrecioVenta", Prod.PrecioVenta);
                    cm.Parameters.AddWithValue("Stock", Prod.Stock);

                    con.Open();
                    cm.ExecuteNonQuery();
                }
            }
        }
        public void Actualizar(Productos Prod)
        {
            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            {
                using (OleDbCommand cm = new OleDbCommand())
                {
                    cm.Connection = con;
                    cm.CommandType = System.Data.CommandType.Text;

                    cm.CommandText = @"UPDATE Productos
                               SET Descripcion=@Descripcion,
                                   Detalle=@Detalle,
                                   IdCat=@IdCat,
                                   IdMarca=@IdMarca,
                                   IdColor=@IdColor,
                                   PrecioCompra=@PrecioCompra,
                                   PrecioVenta=@PrecioVenta,
                                   Stock=@Stock
                               WHERE IdProducto=@IdProducto";

                    cm.Parameters.AddWithValue("Descripcion", Prod.Descripcion);
                    cm.Parameters.AddWithValue("Detalle", Prod.Detalle);
                    cm.Parameters.AddWithValue("IdCat", Prod.IdCat);
                    cm.Parameters.AddWithValue("IdMarca", Prod.IdMarca);
                    cm.Parameters.AddWithValue("IdColor", Prod.IdColor);
                    cm.Parameters.AddWithValue("PrecioCompra", Prod.PrecioCompra);
                    cm.Parameters.AddWithValue("PrecioVenta", Prod.PrecioVenta);
                    cm.Parameters.AddWithValue("Stock", Prod.Stock);

                    cm.Parameters.AddWithValue("IdProducto", Prod.IdProducto);

                    con.Open();
                    cm.ExecuteNonQuery();
                }
            }
        }
        public void Borrar(Productos Prod)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = cn.ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Productos set Estado = false where IdProducto = {Prod.IdProducto}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public void Recuperar(Productos Prod)
        {
            OleDbConnection cone = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            cone.ConnectionString = cn.ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;


            cm.CommandText = $"update Productos set Estado = true where IdProducto = {Prod.IdProducto}";
            cm.Connection = cone;

            cone.Open();
            cm.ExecuteNonQuery();
            cone.Close();
        }
        public List<Productos> ListarPapelera()
        {
            List<Productos> list = new List<Productos>();
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cm = new OleDbCommand();

            OleDbDataReader reader;

            con.ConnectionString = cn.ConectarDB();
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "SELECT * FROM Productos WHERE Estado = false";
            cm.Connection = con;

            con.Open();
            reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Productos Prod = new Productos();

                Prod.IdProducto = reader.GetInt32(0);
                Prod.Descripcion = reader.GetString(1);
                Prod.Detalle = reader.GetString(2);
                Prod.IdCat = reader.GetInt32(3);
                Prod.IdMarca = reader.GetInt32(4);
                Prod.IdColor = reader.GetInt32(5);
                Prod.PrecioCompra = reader.GetDecimal(6);
                Prod.PrecioVenta = reader.GetDecimal(7);
                Prod.Stock = reader.GetInt32(8);


                list.Add(Prod);
            }
            con.Close();

            return list;
        }
        public List<Productos> Buscar(string Descripcion)
        {
            List<Productos> lista = new List<Productos>();

            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            using (OleDbCommand cm = con.CreateCommand())
            {
                cm.CommandText = @"
            SELECT p.IdProducto, p.Descripcion, p.Detalle,
                   c.IdCat, c.Descripcion AS Categoria,
                   m.IdMarca, m.Descripcion AS Marca,
                   col.IdColor, col.Descripcion AS Color,
                   p.PrecioCompra, p.PrecioVenta, p.Stock, p.Estado
            FROM ((Productos p
            INNER JOIN Categoria c ON p.IdCat = c.IdCat)
            INNER JOIN Marcas m ON p.IdMarca = m.IdMarca)
            INNER JOIN Color col ON p.IdColor = col.IdColor
            WHERE p.Estado = True
              AND p.Descripcion LIKE @desc
            ORDER BY p.IdProducto";

                // 🔹 Usamos parámetros para evitar errores y SQL Injection
                cm.Parameters.AddWithValue("@desc", Descripcion + "%");

                con.Open();
                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Productos prod = new Productos
                        {
                            IdProducto = reader["IdProducto"] != DBNull.Value ? Convert.ToInt32(reader["IdProducto"]) : 0,
                            Descripcion = reader["Descripcion"] != DBNull.Value ? reader["Descripcion"].ToString() : string.Empty,
                            Detalle = reader["Detalle"] != DBNull.Value ? reader["Detalle"].ToString() : string.Empty,
                            IdCat = reader["IdCat"] != DBNull.Value ? Convert.ToInt32(reader["IdCat"]) : 0,
                            Categoria = reader["Categoria"] != DBNull.Value ? reader["Categoria"].ToString() : string.Empty,
                            IdMarca = reader["IdMarca"] != DBNull.Value ? Convert.ToInt32(reader["IdMarca"]) : 0,
                            Marca = reader["Marca"] != DBNull.Value ? reader["Marca"].ToString() : string.Empty,
                            IdColor = reader["IdColor"] != DBNull.Value ? Convert.ToInt32(reader["IdColor"]) : 0,
                            Color = reader["Color"] != DBNull.Value ? reader["Color"].ToString() : string.Empty,
                            PrecioCompra = reader["PrecioCompra"] != DBNull.Value ? Convert.ToDecimal(reader["PrecioCompra"]) : 0m,
                            PrecioVenta = reader["PrecioVenta"] != DBNull.Value ? Convert.ToDecimal(reader["PrecioVenta"]) : 0m,
                            Stock = reader["Stock"] != DBNull.Value ? Convert.ToInt32(reader["Stock"]) : 0,
                            Estado = reader["Estado"] != DBNull.Value ? Convert.ToBoolean(reader["Estado"]) : false
                        };

                        lista.Add(prod);
                    }
                }
            }

            return lista;
        }
        public List<Productos> BuscarPapelera(string Descripcion)
        {
            List<Productos> lista = new List<Productos>();

            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            using (OleDbCommand cm = con.CreateCommand())
            {
                cm.CommandText = @"
            SELECT p.IdProducto, p.Descripcion, p.Detalle,
                   c.IdCat, c.Descripcion AS Categoria,
                   m.IdMarca, m.Descripcion AS Marca,
                   col.IdColor, col.Descripcion AS Color,
                   p.PrecioCompra, p.PrecioVenta, p.Stock, p.Estado
            FROM ((Productos p
            INNER JOIN Categoria c ON p.IdCat = c.IdCat)
            INNER JOIN Marcas m ON p.IdMarca = m.IdMarca)
            INNER JOIN Color col ON p.IdColor = col.IdColor
            WHERE p.Estado = False
              AND p.Descripcion LIKE @desc
            ORDER BY p.IdProducto";

                cm.Parameters.AddWithValue("@desc", Descripcion + "%");

                con.Open();
                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Productos prod = new Productos
                        {
                            IdProducto = reader["IdProducto"] != DBNull.Value ? Convert.ToInt32(reader["IdProducto"]) : 0,
                            Descripcion = reader["Descripcion"] != DBNull.Value ? reader["Descripcion"].ToString() : string.Empty,
                            Detalle = reader["Detalle"] != DBNull.Value ? reader["Detalle"].ToString() : string.Empty,
                            IdCat = reader["IdCat"] != DBNull.Value ? Convert.ToInt32(reader["IdCat"]) : 0,
                            Categoria = reader["Categoria"] != DBNull.Value ? reader["Categoria"].ToString() : string.Empty,
                            IdMarca = reader["IdMarca"] != DBNull.Value ? Convert.ToInt32(reader["IdMarca"]) : 0,
                            Marca = reader["Marca"] != DBNull.Value ? reader["Marca"].ToString() : string.Empty,
                            IdColor = reader["IdColor"] != DBNull.Value ? Convert.ToInt32(reader["IdColor"]) : 0,
                            Color = reader["Color"] != DBNull.Value ? reader["Color"].ToString() : string.Empty,
                            PrecioCompra = reader["PrecioCompra"] != DBNull.Value ? Convert.ToDecimal(reader["PrecioCompra"]) : 0m,
                            PrecioVenta = reader["PrecioVenta"] != DBNull.Value ? Convert.ToDecimal(reader["PrecioVenta"]) : 0m,
                            Stock = reader["Stock"] != DBNull.Value ? Convert.ToInt32(reader["Stock"]) : 0,
                            Estado = reader["Estado"] != DBNull.Value ? Convert.ToBoolean(reader["Estado"]) : false
                        };

                        lista.Add(prod);
                    }
                }
            }

            return lista;
        }
        private bool ColumnExists(IDataRecord r, string columnName)
        {
            for (int i = 0; i < r.FieldCount; i++)
                if (r.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase)) return true;
            return false;
        }
        public List<Productos> ListarINNERJOIN()
        {
            List<Productos> lista = new List<Productos>();

            using (OleDbConnection con = new OleDbConnection(cn.ConectarDB()))
            using (OleDbCommand cm = con.CreateCommand())
            {

                cm.CommandText = @"
                SELECT p.IdProducto, p.Descripcion, p.Detalle,
                       c.IdCat, c.Descripcion AS Categoria,
                       m.IdMarca, m.Descripcion AS Marca,
                       col.IdColor, col.Descripcion AS Color,
                       p.PrecioCompra, p.PrecioVenta, p.Stock, p.Estado
                FROM ((Productos p
                INNER JOIN Categoria c ON p.IdCat = c.IdCat)
                INNER JOIN Marcas m ON p.IdMarca = m.IdMarca)
                INNER JOIN Color col ON p.IdColor = col.IdColor
                WHERE p.Estado = True
                ORDER BY p.IdProducto";

                con.Open();
                using (OleDbDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Productos prod = new Productos
                        {
                            IdProducto = reader["IdProducto"] != DBNull.Value ? Convert.ToInt32(reader["IdProducto"]) : 0,
                            Descripcion = reader["Descripcion"] != DBNull.Value ? reader["Descripcion"].ToString() : string.Empty,
                            Detalle = reader["Detalle"] != DBNull.Value ? reader["Detalle"].ToString() : string.Empty,
                            IdCat = reader["IdCat"] != DBNull.Value ? Convert.ToInt32(reader["IdCat"]) : 0,
                            Categoria = ColumnExists(reader, "Categoria") ? reader["Categoria"].ToString() :
                                               (ColumnExists(reader, "Categoria") ? reader["Categoria"].ToString() : string.Empty),
                            IdMarca = reader["IdMarca"] != DBNull.Value ? Convert.ToInt32(reader["IdMarca"]) : 0,
                            Marca = ColumnExists(reader, "Marca") ? reader["Marca"].ToString() :
                                            (ColumnExists(reader, "Marca") ? reader["Marca"].ToString() : string.Empty),
                            IdColor = reader["IdColor"] != DBNull.Value ? Convert.ToInt32(reader["IdColor"]) : 0,
                            Color = ColumnExists(reader, "Color") ? reader["Color"].ToString() :
                                            (ColumnExists(reader, "Color") ? reader["Color"].ToString() : string.Empty),
                            PrecioCompra = reader["PrecioCompra"] != DBNull.Value ? Convert.ToDecimal(reader["PrecioCompra"]) : 0m,
                            PrecioVenta = reader["PrecioVenta"] != DBNull.Value ? Convert.ToDecimal(reader["PrecioVenta"]) : 0m,
                            Stock = reader["Stock"] != DBNull.Value ? Convert.ToInt32(reader["Stock"]) : 0,
                            Estado = reader["Estado"] != DBNull.Value ? Convert.ToBoolean(reader["Estado"]) : false
                        };

                        lista.Add(prod);
                    }
                }
            }

            return lista;
        }
    }
}

    





