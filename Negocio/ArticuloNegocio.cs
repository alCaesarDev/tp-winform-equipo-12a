using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;
using Infraestructura;
using Negocio.DTO;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = null;

            try
            {
                conexion = BaseDeDatos.ObtenerConexion();
                string consulta = @"
                SELECT A.Id          AS Id,
                       Codigo,
                       Nombre,
                       A.Descripcion,
                       M.Descripcion   AS MarcaDescripcion,
                       C.Descripcion AS CategoriaDescripcion,
                       Precio,
                       IdMarca,
                       IdCategoria
                FROM ARTICULOS A
                         LEFT JOIN CATEGORIAS C ON C.Id = A.IdCategoria
                         LEFT JOIN MARCAS M ON M.Id = A.IdMarca 
                ";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)lector["IdCategoria"];
                    categoria.Descripcion = lector["CategoriaDescripcion"].ToString();

                    Marca marca = new Marca();
                    marca.Id = (int)lector["IdMarca"];
                    marca.Descripcion = lector["MarcaDescripcion"].ToString();

                    Articulo articulo = new Articulo
                    {
                        Id = (int)lector["Id"],
                        Codigo = lector["Codigo"].ToString(),
                        Nombre = lector["Nombre"].ToString(),
                        Descripcion = lector["Descripcion"].ToString(),
                        Precio = (decimal)lector["Precio"],
                        IdMarca = (int)lector["IdMarca"],
                        IdCategoria = (int)lector["IdCategoria"],
                        Marca = marca,
                        Categoria = categoria
                    };

                    lista.Add(articulo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar artículos", ex);
            }
            finally
            {
                conexion?.Close();
            }

            return lista;
        }

        public List<Articulo> Filtrar(FiltroArticuloDto filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = null;

            try
            {
                conexion = BaseDeDatos.ObtenerConexion();
                string consulta = @"        
            SELECT A.Id          AS Id,
                   Codigo,
                   Nombre,
                   A.Descripcion,
                   M.Descripcion   AS MarcaDescripcion,
                   C.Descripcion   AS CategoriaDescripcion,
                   Precio,
                   IdMarca,
                   IdCategoria
            FROM ARTICULOS A
                     LEFT JOIN CATEGORIAS C ON C.Id = A.IdCategoria
                     LEFT JOIN MARCAS M ON M.Id = A.IdMarca
            WHERE 1=1
        ";

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                if (!string.IsNullOrWhiteSpace(filtro.Codigo))
                {
                    consulta += " AND Codigo LIKE @Codigo";
                    comando.Parameters.AddWithValue("@Codigo", $"%{filtro.Codigo}%");
                }

                if (!string.IsNullOrWhiteSpace(filtro.Nombre))
                {
                    consulta += " AND Nombre LIKE @Nombre";
                    comando.Parameters.AddWithValue("@Nombre", $"%{filtro.Nombre}%");
                }

                comando.CommandText = consulta;

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Categoria categoria = new Categoria
                    {
                        Id = (int)lector["IdCategoria"],
                        Descripcion = lector["CategoriaDescripcion"].ToString()
                    };

                    Marca marca = new Marca
                    {
                        Id = (int)lector["IdMarca"],
                        Descripcion = lector["MarcaDescripcion"].ToString()
                    };

                    Articulo articulo = new Articulo
                    {
                        Id = (int)lector["Id"],
                        Codigo = lector["Codigo"].ToString(),
                        Nombre = lector["Nombre"].ToString(),
                        Descripcion = lector["Descripcion"].ToString(),
                        Precio = (decimal)lector["Precio"],
                        IdMarca = (int)lector["IdMarca"],
                        IdCategoria = (int)lector["IdCategoria"],
                        Marca = marca,
                        Categoria = categoria
                    };

                    lista.Add(articulo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar articulos", ex);
            }
            finally
            {
                conexion?.Close();
            }

            return lista;
        }


        public void Agregar(Articulo nuevo)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = BaseDeDatos.ObtenerConexion();
                string consulta = @"
                INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) 
                VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @precio);
                SELECT CAST(SCOPE_IDENTITY() as int);
                ";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@codigo", nuevo.Codigo);
                comando.Parameters.AddWithValue("@nombre", nuevo.Nombre);
                comando.Parameters.AddWithValue("@descripcion", nuevo.Descripcion);
                comando.Parameters.AddWithValue("@idMarca", nuevo.Marca.Id);
                comando.Parameters.AddWithValue("@idCategoria", nuevo.Categoria.Id);
                comando.Parameters.AddWithValue("@precio", nuevo.Precio);

                int idGenerado = (int)comando.ExecuteScalar();

                if (nuevo.Imagenes.Count > 0)
                {
                    ImagenNegocio imagenNegocio = new ImagenNegocio();

                    foreach (Imagen imagen in nuevo.Imagenes)
                    {
                        imagen.IdArticulo = idGenerado;
                        imagenNegocio.Agregar(imagen);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el articulo", ex);
            }
            finally
            {
                conexion?.Close();
            }
        }


        public Articulo BuscarPorId(int id)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = BaseDeDatos.ObtenerConexion();
                string consulta = @"SELECT A.Id, Codigo, Nombre, A.Descripcion,M.Descripcion 
                                  AS MarcaDescripcion, C.Descripcion AS CategoriaDescripcion,
                                  Precio, IdMarca ,IdCategoria FROM ARTICULOS A LEFT JOIN CATEGORIAS C ON C.Id = A.IdCategoria
                                  LEFT JOIN MARCAS M ON M.Id = A.IdMarca
                                  WHERE A.Id = @id";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)lector["IdCategoria"];
                    categoria.Descripcion = lector["CategoriaDescripcion"].ToString();
                    Marca marca = new Marca();
                    marca.Id = (int)lector["IdMarca"];
                    marca.Descripcion = lector["MarcaDescripcion"].ToString();

                    Articulo articulo = new Articulo
                    {
                        Id = (int)lector["Id"],
                        Codigo = lector["Codigo"].ToString(),
                        Nombre = lector["Nombre"].ToString(),
                        Descripcion = lector["Descripcion"].ToString(),
                        Precio = (decimal)lector["Precio"],
                        IdMarca = (int)lector["IdMarca"],
                        IdCategoria = (int)lector["IdCategoria"],
                        Marca = marca,
                        Categoria = categoria
                    };
                    return articulo;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el articulo por ID", ex);
            }
            finally
            {
                conexion?.Close();
            }
        }
    }
}